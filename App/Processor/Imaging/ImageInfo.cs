﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using FreeImageAPI;
using iTextSharp.text.pdf;
using PDFPatcher.Model;

namespace PDFPatcher.Processor.Imaging;

[DebuggerDisplay("REF = {PdfRef}({ReferenceCount}); Size = {Width} * {Height}")]
internal sealed class ImageInfo
{
    internal ImageInfo()
    {
    }

    internal ImageInfo(PdfImageData image) => InlineImage = image;

    internal ImageInfo(PdfIndirectReference pdfIndirect) => InlineImage = new PdfImageData(pdfIndirect);

    internal ImageInfo(PRStream stream) => InlineImage = new PdfImageData(stream);

    public string FileName { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int BitsPerComponent { get; private set; }
    public PixelFormat PixelFormat { get; private set; }
    public int ReferenceCount { get; set; }
    public bool VerticalFlip { get; set; }
    public string ExtName { get; private set; }
    public string LastDecodeError { get; private set; }
    public PdfName ColorSpace { get; private set; }
    public PdfName PaletteColorSpace { get; private set; }
    public byte[] PaletteBytes { get; private set; }
    public byte[] ICCProfile { get; private set; }
    public Size MaskSize { get; private set; }
    public byte[] MaskBytes { get; private set; }
    public int PaletteEntryCount { get; private set; }
    public RGBQUAD[] PaletteArray { get; private set; }
    public PdfImageData InlineImage { get; }

    internal byte[] DecodeImage(ImageExtracterOptions options) => DecodeImage(this, options);

    private static byte[] DecodeImage(ImageInfo info, ImageExtracterOptions options)
    {
        PdfImageData data = info.InlineImage;
        info.ExtName = Constants.FileExtensions.Dat;

        info.Width = data.TryGetInt32(PdfName.WIDTH, 0);
        info.Height = data.TryGetInt32(PdfName.HEIGHT, 0);
        if (info.Width < options.MinWidth || info.Height < options.MinHeight)
        {
            if (info.InlineImage.PdfRef != null)
            {
                Tracker.TraceMessage(string.Concat("Ignored a image numbered ", info.InlineImage.ToString(),
                    ", size is ", info.Width, "*",
                    info.Height, "The image."));
            }
            else
            {
                Tracker.TraceMessage(string.Concat("Ignoring an inline image with dimensions ", info.Width, "*",
                    info.Height, "."));
            }

            return null;
        }

        info.BitsPerComponent = data.TryGetInt32(PdfName.BITSPERCOMPONENT, 1);
        info.PixelFormat = PixelFormat.Format8bppIndexed;
        IList<PdfObject> decParams =
            data.GetObjectDirectOrFromContainerArray(PdfName.DECODEPARMS, PdfObject.DICTIONARY);
        IList<PdfObject> filters = data.GetObjectDirectOrFromContainerArray(PdfName.FILTER, PdfObject.NAME);
        byte[] decodedBytes = DecodeStreamContent(data, filters);
        string filter = filters.Count > 0
            ? (filters[filters.Count - 1] as PdfName ?? PdfName.DEFAULT).ToString()
            : "BMP";
        PdfDictionary decParam = decParams.Count > 0 ? decParams[decParams.Count - 1] as PdfDictionary : null;
        ExportColorspace(data.GetDirectObject(PdfName.COLORSPACE), info);
        switch (filter)
        {
            case "/DCTDecode":
            case "/DCT":
                info.ExtName = Constants.FileExtensions.Jpg;
                goto case "JPG";
            case "/JPXDecode":
            case "/JPX":
                info.ExtName = Constants.FileExtensions.Jp2;
                //goto case "JPG";
                goto EXIT;
            case "/CCITTFaxDecode":
            case "/CCF":
            case "/JBIG2Decode":
                info.ExtName = Constants.FileExtensions.Tif;
                int k = 0;
                bool blackIs1 = false;
                bool byteAlign = false;
                bool endOfLine = false;
                bool endOfBlock = true;
                if (decParam != null)
                {
                    k = decParam.TryGetInt32(PdfName.K, 0);
                    blackIs1 = decParam.TryGetBoolean(PdfName.BLACKIS1, false);
                    byteAlign = decParam.TryGetBoolean(PdfName.ENCODEDBYTEALIGN, false);
                    endOfBlock = decParam.TryGetBoolean(PdfName.ENDOFBLOCK, true);
                    endOfLine = decParam.TryGetBoolean(PdfName.ENDOFLINE, false);
                }

                blackIs1 = IsDecodeParamInverted(data, blackIs1);
                if (options.InvertBlackAndWhiteImages)
                {
                    blackIs1 = !blackIs1;
                }

                byte[] outBuf;
                if (filter == "/JBIG2Decode")
                {
                    byte[] globals = new byte[0];
                    PdfIndirectReference gRef = decParam?.GetAsIndirectObject(PdfName.JBIG2GLOBALS);
                    if (gRef != null)
                    {
                        if (PdfReader.GetPdfObjectRelease(gRef) is PRStream gs)
                        {
                            globals = PdfReader.GetStreamBytes(gs);
                        }
                    }

                    outBuf = JBig2Decoder.Decode(decodedBytes, globals);
                    if (outBuf == null)
                    {
                        info.LastDecodeError = "Export JBIG2 coded image failed.";
                        return null;
                    }

                    if (blackIs1 == false)
                    {
                        InvertBits(outBuf);
                    }
                }
                else
                {
                    outBuf = TiffHelper.Decode(info, decodedBytes, k, endOfLine, byteAlign, endOfBlock, blackIs1);
                }

                info.PixelFormat = PixelFormat.Format1bppIndexed;
                info.BitsPerComponent = 1;
                decodedBytes = outBuf;
                break;
            case "/FlateDecode":
            case "/Fl":
            case "/LZWDecode":
                info.ExtName = Constants.FileExtensions.Png;
                info.PixelFormat = GetPixelFormat(decodedBytes.Length, info);
                switch (info.PixelFormat)
                {
                    case PixelFormat.Undefined:
                        info.LastDecodeError = "Unable to determine the color format of the image.";
                        info.ExtName = Constants.FileExtensions.Dat;
                        return null;
                    case PixelFormat.Format1bppIndexed:
                        {
                            blackIs1 = IsDecodeParamInverted(data, false);
                            if (options.InvertBlackAndWhiteImages)
                            {
                                blackIs1 = !blackIs1;
                            }

                            if (blackIs1)
                            {
                                InvertBits(decodedBytes);
                            }

                            break;
                        }
                }

                break;
            case "BMP":
                info.ExtName = Constants.FileExtensions.Png;
                break;
            case "JPG":
                if (options.MergeImages == false)
                {
                    goto EXIT;
                }

                using (MemoryStream ms = new(decodedBytes))
                using (FreeImageBitmap bm = PdfName.DEVICECMYK.Equals(info.ColorSpace)
                           ? new FreeImageBitmap(ms, FREE_IMAGE_LOAD_FLAGS.JPEG_CMYK)
                           : new FreeImageBitmap(ms))
                {
                    info.PixelFormat = bm.PixelFormat;
                    switch (bm.ColorType)
                    {
                        case FREE_IMAGE_COLOR_TYPE.FIC_CMYK:
                            info.ColorSpace = PdfName.DEVICECMYK;
                            break;
                        case FREE_IMAGE_COLOR_TYPE.FIC_MINISBLACK:
                        case FREE_IMAGE_COLOR_TYPE.FIC_MINISWHITE:
                            info.ColorSpace = PdfName.DEVICEGRAY;
                            break;
                        case FREE_IMAGE_COLOR_TYPE.FIC_PALETTE:
                            info.ColorSpace = PdfName.INDEXED;
                            break;
                        case FREE_IMAGE_COLOR_TYPE.FIC_RGB:
                        case FREE_IMAGE_COLOR_TYPE.FIC_RGBALPHA:
                            info.ColorSpace = PdfName.DEVICERGB;
                            break;
                    }

                    info.BitsPerComponent =
                        info.PixelFormat switch
                        {
                            PixelFormat.Format1bppIndexed => 1,
                            PixelFormat.Format4bppIndexed => 4,
                            _ => 8
                        };
                }

                goto EXIT;
            default:
                info.PixelFormat = PixelFormat.Undefined;
                info.LastDecodeError = "Unsuined image data format: " + filter;
                return null;
        }

        if (PdfName.DEVICECMYK.Equals(info.ColorSpace))
        {
            info.ExtName = Constants.FileExtensions.Tif;
        }

    EXIT:
        PRStream sm;
        if (!options.ExtractSoftMask || (sm = data.GetAsStream(PdfName.SMASK) as PRStream) == null &&
            (sm = data.GetAsStream(PdfName.MASK) as PRStream) == null)
        {
            return decodedBytes;
        }

        ImageInfo mi = new(sm);
        byte[] mask = DecodeImage(mi,
            new ImageExtracterOptions { InvertBlackAndWhiteImages = !options.InvertSoftMask });
        if (mask == null || mi.BitsPerComponent != 1)
        {
            return decodedBytes;
        }

        info.MaskBytes = mask;
        info.MaskSize = new Size(mi.Width, mi.Height);

        return decodedBytes;
    }

    private static void InvertBits(IList<byte> outBuf)
    {
        int len = outBuf.Count;
        for (int t = 0; t < len; ++t)
        {
            outBuf[t] ^= 0xff;
        }
    }

    internal void CreatePaletteAndIccProfile(FreeImageBitmap bmp)
    {
        if (PixelFormat == PixelFormat.Format1bppIndexed)
        {
            ColorSpace = PdfName.DEVICEGRAY;
        }

        CreatePalette(bmp);
        if (PaletteEntryCount > 0)
        {
            switch (PaletteEntryCount)
            {
                case < 3:
                    PixelFormat = PixelFormat.Format1bppIndexed;
                    bmp.ConvertColorDepth(FREE_IMAGE_COLOR_DEPTH.FICD_01_BPP);
                    break;
                case < 17:
                    PixelFormat = PixelFormat.Format4bppIndexed;
                    bmp.ConvertColorDepth(FREE_IMAGE_COLOR_DEPTH.FICD_04_BPP);
                    break;
            }
        }

        if (ICCProfile != null)
        {
            bmp.CreateICCProfile(ICCProfile);
        }
    }

    private void CreatePalette(FreeImageBitmap bmp)
    {
        //if (PaletteColorSpace == null) {
        //	//todo++ The image of the missing color gamut information is not necessarily a grayscale image
        //	if (bmp.HasPalette) {
        //		PaletteColorSpace = PdfName.DEVICEGRAY;
        //	}
        //	else {
        //		return;
        //	}
        //}
        if (bmp.HasPalette == false)
        {
            Trace.WriteLine("Bitmap does not have palette.");
            return;
        }

        Palette pal = bmp.Palette;
        if (PdfName.DEVICEGRAY.Equals(PaletteColorSpace))
        {
            if (PaletteBytes == null)
            {
                pal.CreateGrayscalePalette();
                PaletteEntryCount = pal.Count;
            }
            else
            {
                byte[] pattern = PaletteBytes;
                int l = pattern.Length;
                int l2 = pal.Count;
                int i;
                for (i = 0; i < l && i < l2; i++)
                {
                    byte p = pattern[i];
                    pal.SetValue(new RGBQUAD(Color.FromArgb(p, p, p)), i);
                }

                PaletteEntryCount = i;
            }
        }
        else
        {
            byte[] pattern = PaletteBytes;
            if (pattern == null)
            {
                bmp.Palette.CreateGrayscalePalette();
                return;
            }

            int i = 0;
            int l = pattern.Length;
            int l2 = pal.Count;
            for (int pi = 0; pi < l && i < l2; pi++)
            {
                pal.SetValue(
                    new RGBQUAD(Color.FromArgb(pattern[pi++], pi < l ? pattern[pi++] : 0, pi < l ? pattern[pi] : 0)),
                    i);
                i++;
            }

            PaletteEntryCount = i;
        }

        PaletteArray = pal.AsArray;
    }

    private static bool IsDecodeParamInverted(PdfDictionary data, bool blackIs1)
    {
        PdfArray a = data.GetAsArray(PdfName.DECODE);
        if (a is { Size: 2 } && a[0].Type == PdfObject.NUMBER)
        {
            blackIs1 = ((PdfNumber)a[0]).IntValue == (blackIs1 ? 0 : 1);
        }

        return blackIs1;
    }

    private static byte[] DecodeStreamContent(PdfImageData data, IList<PdfObject> filters)
    {
        byte[] buffer = data.RawBytes;
        if (filters.Count == 0)
        {
            return buffer;
        }

        List<PdfObject> dp = new();
        PdfObject dpo = PdfReader.GetPdfObjectRelease(data.Get(PdfName.DECODEPARMS));
        if (dpo == null || !dpo.IsDictionary() && !dpo.IsArray())
        {
            dpo = PdfReader.GetPdfObjectRelease(data.Get(PdfName.DP));
        }

        if (dpo != null)
        {
            if (dpo.IsDictionary())
            {
                dp.Add(dpo);
            }
            else if (dpo.IsArray())
            {
                dp = ((PdfArray)dpo).ArrayList;
            }
        }

        for (int i = 0; i < filters.Count; i++)
        {
            string name = (filters[i] as PdfName).ToString();
            switch (name)
            {
                case "/FlateDecode":
                case "/Fl":
                    buffer = PdfReader.FlateDecode(buffer);
                    goto case "DecodePredictor";
                case "/ASCIIHexDecode":
                case "/AHx":
                    buffer = PdfReader.ASCIIHexDecode(buffer);
                    break;
                case "/ASCII85Decode":
                case "/A85":
                    buffer = PdfReader.ASCII85Decode(buffer);
                    break;
                case "/LZWDecode":
                    buffer = PdfReader.LZWDecode(buffer);
                    goto case "DecodePredictor";
                case "/Crypt":
                    break;
                case "/DCTDecode":
                case "/JPXDecode":
                case "/CCITTFaxDecode":
                case "/JBIG2Decode":
                    if (i != filters.Count - 1)
                    {
                        Tracker.TraceMessage(Tracker.Category.Error,
                            "File format error: " + name + " decoder is not the last decoder.");
                    }

                    break;
                case "DecodePredictor":
                    if (i < dp.Count)
                    {
                        buffer = PdfReader.DecodePredictor(buffer, dp[i]);
                    }

                    break;
                default:
                    Trace.WriteLine(Tracker.Category.Error, "Unsupported stream encoding format: " + name);
                    break;
            }
        }

        return buffer;
    }

    private static PixelFormat GetPixelFormat(int byteLength, ImageInfo info)
    {
        PixelFormat pf = PixelFormat.Undefined;
        int components = byteLength / info.Width / info.Height;
        switch (info.BitsPerComponent)
        {
            case 1:
                pf = PixelFormat.Format1bppIndexed;
                break;
            case 2:
                pf = PixelFormat.Format1bppIndexed;
                Trace.WriteLine("Warning: unsupported bpc = 2");
                break;
            case 4:
                pf = PixelFormat.Format4bppIndexed;
                break;
            case 8:
                switch (components)
                {
                    case 1:
                        pf = PixelFormat.Format8bppIndexed;
                        break;
                    case 2:
                        pf = PixelFormat.Format16bppRgb555;
                        break;
                    case 3:
                        pf = PixelFormat.Format24bppRgb;
                        break;
                    case 4:
                        pf = PixelFormat.Format32bppRgb;
                        break;
                    default:
                        Trace.WriteLine("Warning: Unknown colors.");
                        break;
                }

                break;
            case 16:
                pf = PixelFormat.Format48bppRgb;
                break;
            default:
                Debug.WriteLine("Warning: bitsPerComponent missing or incorrect (" + info.BitsPerComponent + ").");
                if (components > 0)
                {
                    goto case 8;
                }
                else
                {
                    int areaPixels = (info.Width + 7) / 8 * info.Height;
                    switch (areaPixels / byteLength)
                    {
                        case 1:
                            pf = PixelFormat.Format1bppIndexed;
                            info.BitsPerComponent = 1;
                            break;
                        case 2:
                            pf = PixelFormat.Format1bppIndexed;
                            info.BitsPerComponent = 2;
                            break;
                        case 4:
                            pf = PixelFormat.Format4bppIndexed;
                            info.BitsPerComponent = 4;
                            break;
                        default:
                            pf = PixelFormat.Format8bppIndexed;
                            info.BitsPerComponent = 8;
                            break;
                    }
                }

                break;
        }

        return pf;
    }

    private static void ExportColorspace(PdfObject cs, ImageInfo info)
    {
        if (cs == null)
        {
            return;
        }

        info.ColorSpace = cs as PdfName;
        if (info.ColorSpace != null)
        {
            return;
        }

        if (cs.Type != PdfObject.ARRAY)
        {
            return;
        }

        PdfArray colorspace = cs as PdfArray;
        // todo: Do we need to change all ColorSpace to PaletteColorSpace
        if (PdfName.ICCBASED.Equals(colorspace.GetAsName(0)))
        {
            PRStream iccs = colorspace.GetDirectObject(1) as PRStream;
            info.ColorSpace = iccs.GetAsName(PdfName.ALTERNATE);
            return;
        }

        if (!PdfName.INDEXED.Equals(colorspace.GetAsName(0)))
        {
            return;
        }

        {
            PdfObject o = colorspace.GetDirectObject(1);
            info.PaletteColorSpace = o as PdfName;
            if (info.PaletteColorSpace == null)
            {
                if (o is PdfArray { Size: 2 } arr)
                {
                    if (PdfName.ICCBASED.Equals(arr.GetAsName(0)) && arr.Size == 2)
                    {
                        PRStream iccs = arr.GetDirectObject(1) as PRStream;
                        info.ColorSpace = iccs.GetAsName(PdfName.ALTERNATE) ?? PdfName.DEVICERGB;
                        info.ICCProfile = PdfReader.GetStreamBytes(iccs);
                    }
                    else
                    {
                        info.ColorSpace = arr.GetAsName(0);
                        //Tracker.TraceMessage (String.Concat ("The color gamut of this image is not supported: ", info.ColorSpace));
                    }
                }
            }

            PdfObject csp = colorspace.GetDirectObject(3);
            if (csp.IsString())
            {
                info.PaletteBytes = ((PdfString)csp).GetOriginalBytes();
            }
            else if (csp is PRStream)
            {
                info.PaletteBytes = PdfReader.GetStreamBytes((PRStream)csp);
            }
            //}
        }
    }

    internal void ConvertDecodedBytes(ref byte[] bytes)
    {
        switch (PixelFormat)
        {
            case PixelFormat.Format24bppRgb:
                {
                    // from RGB array to BGR GDI+ data
                    for (int i = 0; i < bytes.Length; i += 3)
                    {
                        byte b = bytes[i];
                        bytes[i] = bytes[i + 2];
                        bytes[i + 2] = b;
                    }

                    break;
                }
            case PixelFormat.Format1bppIndexed when BitsPerComponent == 2:
                {
                    // Support 4 grayscale images
                    int l = bytes.Length;
                    byte[] newBytes = new byte[l << 1];
                    int i = 0;
                    foreach (byte b in bytes)
                    {
                        newBytes[i++] = (byte)(((b & 0xC0) >> 0x02) + ((b & 0x30) >> 0x04));
                        newBytes[i++] = (byte)(((b & 0x0C) << 0x02) + (b & 0x03));
                    }

                    if (PaletteBytes != null)
                    {
                        byte[] pattern = PaletteBytes;
                        Array.Resize(ref pattern, 16 * 3);
                        PaletteBytes = pattern;
                    }

                    PixelFormat = PixelFormat.Format4bppIndexed;
                    BitsPerComponent = 4;
                    ColorSpace = PdfName.DEVICEGRAY;
                    bytes = newBytes;
                    break;
                }
        }
    }
}
