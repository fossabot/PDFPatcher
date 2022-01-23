using System.Drawing;
using System.Drawing.Imaging;
using FreeImageAPI;
using MuPdfSharp;
using ImageFormat = System.Drawing.Imaging.ImageFormat;

namespace PDFPatcher.Processor.Imaging;

internal static class TiffHelper
{
    private static readonly ImageCodecInfo _tiffCodec = BitmapHelper.GetCodec("image/tiff");

    private static readonly EncoderParameters _encoderParameters = new(1)
    {
        Param = new EncoderParameter[] { new(Encoder.Compression, (long)EncoderValue.CompressionCCITT4) }
    };

    internal static void Save(FreeImageBitmap bmp, string fileName)
    {
        // Use the .NET TIFF Save mode, the file size is smaller
        if (_tiffCodec != null)
        {
            if (bmp.ColorType ==
                FREE_IMAGE_COLOR_TYPE
                    .FIC_MINISWHITE) // HACK: TIFF encoding black is 1, solve the .NET TIFF encoder does not properly save two-color image problem
            {
                bmp.Invert();
            }

            using Bitmap b = bmp.ToBitmap();
            b.Save(fileName, _tiffCodec, _encoderParameters);
        }
        else
        {
            bmp.Save(fileName, FREE_IMAGE_FORMAT.FIF_TIFF, FREE_IMAGE_SAVE_FLAGS.TIFF_CCITTFAX4);
        }
    }

    /// <summary>
    ///     Save the image as a black and white two-color image.If <see cref="PixelFormat" /> is not
    ///     <see cref="PixelFormat.Format1bppIndexed" />, saved by default format.
    /// </summary>
    /// <param name="bmp">The image to be saved.</param>
    /// <param name="fileName">Save the path.</param>
    internal static void SaveBinaryImage(this Image bmp, string fileName)
    {
        if (bmp.PixelFormat == PixelFormat.Format1bppIndexed)
        {
            bmp.Save(fileName, _tiffCodec, _encoderParameters);
        }
        else
        {
            bmp.Save(fileName, ImageFormat.Tiff);
        }
    }

    internal static byte[] Decode(ImageInfo info, byte[] bytes, int k, bool endOfLine, bool encodedByteAlign,
        bool endOfBlock, bool blackIs1)
    {
        using MuStream s = new(bytes);
        using MuStream img =
            s.DecodeTiffFax(info.Width, info.Height, k, endOfLine, encodedByteAlign, endOfBlock, blackIs1);
        return img.ReadAll(bytes.Length);
        //var outBuf = new byte[(info.Width + 7) / 8 * info.Height];
        //var decoder = new TIFFFaxDecoder (1, info.Width, info.Height);
        //if (k < 0) {
        //    // CCITT Fax Group 4
        //    decoder.DecodeT6 (outBuf, bytes, 0, info.Height, 0L);
        //}
        //else if (k == 0) {
        //    // CCITT Fax Group 3 (1-D)
        //    decoder.Decode1D (outBuf, bytes, 0, info.Height);
        //}
        //else {
        //    // CCITT Fax Group 3 (2-D)
        //    decoder.Decode2D (outBuf, bytes, 0, info.Height, 0L);
        //}
        //return outBuf;
    }
}
