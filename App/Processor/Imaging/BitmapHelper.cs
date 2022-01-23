using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace PDFPatcher.Processor.Imaging;

internal static class BitmapHelper
{
    private const int threshold = 255 * 3 / 2;

    public static ImageCodecInfo GetCodec(string codecName)
    {
        ImageCodecInfo[] ie = ImageCodecInfo.GetImageEncoders();

        return ie.FirstOrDefault(t => t.MimeType == codecName);
    }

    /// <summary>
    ///     Get the collection of not repeated color colors for the specified image.
    /// </summary>
    /// <param name="bmp">The <see cref="Bitmap" /> of the color collection is required.</param>
    /// <returns>contains a list that does not repeat color collections.</returns>
    public static unsafe Color[] GetPalette(this Bitmap bmp)
    {
        HashSet<int> hs = new();
        if (bmp == null)
        {
            return null;
        }

        if (bmp.IsIndexed())
        {
            return Array.ConvertAll(bmp.Palette.Entries, c => c); //duplicates the array
        }

        if (bmp.PixelFormat != PixelFormat.Format24bppRgb && bmp.PixelFormat != PixelFormat.Format32bppArgb)
        {
            throw new InvalidOperationException("Only Format24bppRgb and Format32bppArgb are supported.");
        }

        int bw = bmp.PixelFormat == PixelFormat.Format24bppRgb ? 3 : 4;
        BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly,
            bmp.PixelFormat);
        byte* pl = (byte*)bmpData.Scan0;
        int w = bmp.Width, h = bmp.Height;
        for (int y = 0; y < h; y++)
        {
            byte* ps = pl;
            switch (bw)
            {
                case 3:
                    {
                        for (int x = 0; x < w; x++)
                        {
                            hs.Add(*ps + (*++ps << 8) + (*++ps << 16) + (0xFF << 24));
                            ++ps;
                        }

                        break;
                    }
                case 4:
                    {
                        for (int x = 0; x < w; x++)
                        {
                            hs.Add(*ps + (*++ps << 8) + (*++ps << 16) + (*++ps << 24));
                            ++ps;
                        }

                        break;
                    }
            }

            pl += bmpData.Stride;
        }

        bmp.UnlockBits(bmpData);
        Color[] r = new Color[hs.Count];
        int i = 0;
        foreach (Color item in hs.Select(Color.FromArgb))
        {
            r[i++] = item;
        }

        return r;
    }

    /// <summary>
    ///     Check if <see cref="Image" /> is an index palette image.
    /// </summary>
    /// <param name="image">The image you need to check.</param>
    /// <returns>Returns true if it is an index palette image, otherwise returns false.</returns>
    public static bool IsIndexed(this Image image) => (image.PixelFormat & PixelFormat.Indexed) == PixelFormat.Indexed;

    /// <summary>
    ///     Lock the contents of <see cref="bitmap" /> for reading and writing.
    /// </summary>
    /// <param name="bmp">The content that needs to be locked.</param>
    /// <param name="writable">Whether it is written.</param>
    /// <returns>Lock <see cref="bitmapdata" />.</returns>
    public static BitmapData LockBits(this Bitmap bmp, bool writable) =>
        bmp.LockBits(new Rectangle(Point.Empty, bmp.Size),
            writable ? ImageLockMode.ReadWrite : ImageLockMode.ReadOnly, bmp.PixelFormat);

    /// <summary>
    ///     Save the image file as the corresponding format according to the extension of the file name.
    /// </summary>
    /// <param name="image">The <see cref="Image" /> required to be saved.</param>
    /// <param name="fileName">Saved file path.</param>
    public static void SaveAs(this Image image, string fileName)
    {
        string ext = Path.GetExtension(fileName);
        switch (ext.ToUpperInvariant())
        {
            case ".PNG":
                image.Save(fileName, ImageFormat.Png);
                return;
            case ".BMP":
                image.Save(fileName, ImageFormat.Bmp);
                return;
            case ".JPG":
            case ".JPEG":
                image.Save(fileName, 75);
                return;
            case ".TIF":
            case ".TIFF":
                image.SaveBinaryImage(fileName);
                return;
            case ".GIF":
                image.Save(fileName, ImageFormat.Gif);
                return;
            default:
                goto case ".PNG";
        }
    }

    /// <summary>
    ///     Stain <paramref name="tint" /> color to <paramref name="color" />.
    /// </summary>
    /// <param name="color">base color.</param>
    /// <param name="tint">Dye color.</param>
    /// <returns>The new color after dyeing.</returns>
    public static Color Tint(this Color color, Color tint) => Color.FromArgb(color.A, mul255(color.R, tint.R),
        mul255(color.G, tint.G), mul255(color.B, tint.B));

    public static unsafe Bitmap ToIndexImage(this Bitmap source, Color[] pallette)
    {
        if (source == null)
        {
            return null;
        }

        if (source.PixelFormat != PixelFormat.Format24bppRgb && source.PixelFormat != PixelFormat.Format32bppArgb)
        {
            throw new InvalidOperationException("Only Format24bppRgb and Format32bppArgb are supported.");
        }

        Dictionary<int, byte> pi = new(pallette.Length);
        for (int i = pallette.Length - 1; i >= 0; i--)
        {
            pi[pallette[i].ToArgb()] = (byte)i;
        }

        Bitmap result = new(source.Width, source.Height, PixelFormat.Format8bppIndexed);
        BitmapData sourceData = source.LockBits(false);
        BitmapData targetData = result.LockBits(true);
        int bw = source.PixelFormat == PixelFormat.Format24bppRgb ? 3 : 4;
        byte* src = (byte*)sourceData.Scan0;
        byte* res = (byte*)targetData.Scan0;
        ColorPalette rp = result.Palette;
        for (int i = 0; i < pallette.Length; i++)
        {
            rp.Entries[i] = pallette[i];
        }

        result.Palette = rp;
        int w = source.Width, h = source.Height;
        for (int y = 0; y < h; y++)
        {
            byte* ps = src;
            byte* pr = res;
            switch (bw)
            {
                case 3:
                    {
                        for (int x = 0; x < w; x++)
                        {
                            *pr = pi[*ps + (*++ps << 8) + (*++ps << 16) + (0xFF << 24)];
                            ++pr;
                            ++ps;
                        }

                        break;
                    }
                case 4:
                    {
                        for (int x = 0; x < w; x++)
                        {
                            *pr = pi[*ps + (*++ps << 8) + (*++ps << 16) + (*++ps << 24)];
                            ++pr;
                            ++ps;
                        }

                        break;
                    }
            }

            src += sourceData.Stride;
            res += targetData.Stride;
        }

        source.UnlockBits(sourceData);
        result.UnlockBits(targetData);
        return result;
    }

    /// <summary>converts the image into black and white images.</summary>
    /// <param name="original">The image that needs to be converted.</param>
    /// <returns>The image after converting.</returns>
    /// <remarks>http://www.wischik.com/lu/programmer/1bpp.html</remarks>
    public static Bitmap ToBitonal(this Bitmap original)
    {
        Bitmap source;

        if (original.PixelFormat == PixelFormat.Format1bppIndexed)
        {
            return (Bitmap)original.Clone();
        }

        if (original.PixelFormat != PixelFormat.Format24bppRgb)
        {
            // If original bitmap is not already in 24 BPP, ARGB format, then convert
            // unfortunately Clone doesn't do this for us but returns a bitmap with the same pixel format
            // source = original.Clone( new Rectangle( Point.Empty, original.Size ), PixelFormat.Format24bppRgb );
            source = new Bitmap(original.Width, original.Height, PixelFormat.Format24bppRgb);
            source.SetResolution(original.HorizontalResolution, original.VerticalResolution);
            using Graphics g = Graphics.FromImage(source);
            //g.CompositingQuality = Drawing2D.CompositingQuality.GammaCorrected;
            //g.InterpolationMode = Drawing2D.InterpolationMode.Low;
            //g.SmoothingMode = Drawing2D.SmoothingMode.None;
            g.DrawImageUnscaled(original, 0, 0);
        }
        else
        {
            source = original;
        }

        // Lock source bitmap in memory
        BitmapData sourceData = source.LockBits(new Rectangle(0, 0, source.Width, source.Height),
            ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

        // Copy image data to binary array
        int imageSize = sourceData.Stride * sourceData.Height;
        byte[] sourceBuffer = new byte[imageSize];
        Marshal.Copy(sourceData.Scan0, sourceBuffer, 0, imageSize);

        // Unlock source bitmap
        source.UnlockBits(sourceData);

        // Dispose of source if not originally supplied bitmap
        if (source != original)
        {
            source.Dispose();
        }

        // Create destination bitmap
        Bitmap destination = new(sourceData.Width, sourceData.Height, PixelFormat.Format1bppIndexed);
        destination.SetResolution(original.HorizontalResolution, original.VerticalResolution);

        // Lock destination bitmap in memory
        BitmapData destinationData = destination.LockBits(new Rectangle(0, 0, destination.Width, destination.Height),
            ImageLockMode.WriteOnly, PixelFormat.Format1bppIndexed);

        // Create destination buffer
        byte[] destinationBuffer = SimpleThresholdBW(
            sourceBuffer,
            sourceData.Width,
            sourceData.Height,
            sourceData.Stride,
            destinationData.Stride);

        // Copy binary image data to destination bitmap
        Marshal.Copy(destinationBuffer, 0, destinationData.Scan0, destinationData.Stride * sourceData.Height);

        // Unlock destination bitmap
        destination.UnlockBits(destinationData);

        // Return
        return destination;
    }

    public static byte[] SimpleThresholdBW(byte[] sourceBuffer, int width, int height, int srcStride, int dstStride)
    {
        byte[] destinationBuffer = new byte[dstStride * height];
        int srcIx = 0;
        int dstIx = 0;

        // Iterate lines
        for (int y = 0; y < height; y++, srcIx += srcStride, dstIx += dstStride)
        {
            byte bit = 128;
            int i = srcIx;
            int j = dstIx;
            byte pix8 = 0;
            // Iterate pixels
            for (int x = 0; x < width; x++, i += 3)
            {
                // Compute pixel brightness (i.e. total of Red, Green, and Blue values)
                int newPixel = sourceBuffer[i] + sourceBuffer[i + 1] + sourceBuffer[i + 2];

                if (newPixel > threshold)
                {
                    pix8 |= bit;
                }

                if (bit == 1)
                {
                    destinationBuffer[j++] = pix8;
                    bit = 128;
                    pix8 = 0; // init next value with 0
                }
                else
                {
                    bit >>= 1;
                }
            } // line finished

            if (bit != 128)
            {
                destinationBuffer[j] = pix8;
            }
        } // all lines finished

        return destinationBuffer;
    }

    // MuPDF: pixmap.c
    private static int mul255(int a, int b)
    {
        /* see Jim Blinn's book "Dirty Pixels" for how this works */
        int x = a * b + 128;
        x += x >> 8;
        return x >> 8;
    }
}
