using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace MuPdfSharp;

internal sealed class PixmapData : IDisposable
{
    private readonly ContextHandle _context;
    private readonly PixmapHandle _pixmap;

    public PixmapData(ContextHandle context, PixmapHandle pixmap)
    {
        Width = NativeMethods.GetWidth(context, pixmap);
        Height = NativeMethods.GetHeight(context, pixmap);
        Components = NativeMethods.GetComponents(context, pixmap);
        Samples = NativeMethods.GetSamples(context, pixmap);
        _context = context;
        _pixmap = pixmap;
    }

    public int Width { get; }
    public int Height { get; }
    public int Components { get; }

    /// <summary>Get pointers that point to Pixmap data content.</summary>
    public IntPtr Samples { get; }

    /// <summary>Get the border of the Pixmap.</summary>
    public BBox BBox => NativeMethods.GetBBox(_context, _pixmap);

    /// <summary>Get the number of bytes of Pixmap a line pixel.</summary>
    public int Stride => NativeMethods.GetStride(_context, _pixmap);

    /// <summary>
    ///     Convert Pixmap data to <see cref="Bitmap" />。
    /// </summary>
    public unsafe Bitmap ToBitmap(ImageRendererOptions options)
    {
        bool grayscale = options.ColorSpace == ColorSpace.Gray;
        bool invert = options.InvertColor;
        Bitmap bmp = new(Width, Height, grayscale ? PixelFormat.Format8bppIndexed : PixelFormat.Format24bppRgb);
        BitmapData imageData = bmp.LockBits(new System.Drawing.Rectangle(0, 0, Width, Height), ImageLockMode.ReadWrite,
            bmp.PixelFormat);
        byte* ptrSrc = (byte*)Samples;
        byte* ptrDest = (byte*)imageData.Scan0;
        if (grayscale)
        {
            ColorPalette palette = bmp.Palette;
            for (int i = 0; i < 256; ++i)
            {
                palette.Entries[i] = Color.FromArgb(i, i, i);
            }

            bmp.Palette = palette;
            for (int y = 0; y < Height; y++)
            {
                byte* pl = ptrDest;
                byte* sl = ptrSrc;
                for (int x = 0; x < Width; x++)
                {
                    *pl = invert ? (byte)(*sl ^ 0xFF) : *sl;
                    pl++;
                    sl++;
                }

                ptrDest += imageData.Stride;
                ptrSrc = sl;
            }
        }
        else
        {
            // DeviceBGR
            for (int y = 0; y < Height; y++)
            {
                byte* pl = ptrDest;
                byte* sl = ptrSrc;
                if (invert)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        // Here, RGB to DIB BGR conversion (province's conversion work inside MuPDF)
                        pl[2] = (byte)(*sl ^ 0xFF);
                        sl++; // R
                        pl[1] = (byte)(*sl ^ 0xFF);
                        sl++; // G
                        pl[0] = (byte)(*sl ^ 0xFF);
                        sl++; // B
                        pl += 3;
                    }
                }
                else
                {
                    for (int x = 0; x < Width; x++)
                    {
                        // Here, RGB to DIB BGR conversion (province's conversion work inside MuPDF)
                        pl[2] = *sl;
                        sl++; // R
                        pl[1] = *sl;
                        sl++; // G
                        pl[0] = *sl;
                        sl++; // B
                        pl += 3;
                    }
                }

                ptrDest += imageData.Stride;
                ptrSrc = sl;
            }
        }

        bmp.UnlockBits(imageData);
        if (options.Dpi > 0)
        {
            bmp.SetResolution(options.Dpi, options.Dpi);
        }

        return bmp;
    }

    /// <summary>
    ///     Reverse Pixmap color.
    /// </summary>
    public void Invert() => NativeMethods.InvertPixmap(_context, _pixmap);

    /// <summary>
    ///     For the Pixmap, the color layer.
    /// </summary>
    /// <param name="color">Need a lot of colors.</param>
    public void Tint(Color color) => NativeMethods.TintPixmap(_context, _pixmap, 0, color.ToArgb());

    /// <summary>
    ///     Perform a Gamma correction for Pixmap.
    /// </summary>
    /// <param name="gamma">A Gamma value is required.1.0 means no change.</param>
    public void Gamma(float gamma)
    {
        if (gamma == 1)
        {
            return;
        }

        NativeMethods.GammaPixmap(_context, _pixmap, gamma);
    }

    #region Implement the properties and methods of iDisposable interface

    private bool disposed;

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this); // Inhibitory destructive function
    }

    /// <summary>Release the resources occupied by MuPdfPage.</summary>
    /// <param name="disposing">Whether to manually release the hosted resource.</param>
    private void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                #region Release managed resources

                //_components.Dispose ();

                #endregion
            }

            #region Release non-managed resources

            // Note that this is not a thread safe
            _pixmap.DisposeHandle();

            #endregion
        }

        disposed = true;
    }

    // The destructor is only called when the Dispose method is not called.
    // Don't provide a destructor in the derived class
    ~PixmapData() => Dispose(false);

    #endregion
}
