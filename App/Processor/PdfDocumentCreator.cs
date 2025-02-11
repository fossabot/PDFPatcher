﻿using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Xml;
using FreeImageAPI;
using iTextSharp.text;
using iTextSharp.text.pdf;
using PDFPatcher.Common;
using PDFPatcher.Model;
using PDFPatcher.Processor.Imaging;
using iTextImage = iTextSharp.text.Image;

namespace PDFPatcher.Processor;

internal sealed class PdfDocumentCreator
{
    private static readonly string[] __BuiltInImageTypes = { ".png", ".jpg", ".jpeg", ".bmp", ".jp2", ".j2k" };
    private static readonly string[] __ExtImageTypes = { ".tif", ".tiff", ".gif" };

    private static readonly PixelFormat[] __JpgFormats =
    {
        PixelFormat.Format16bppGrayScale, PixelFormat.Format16bppRgb555, PixelFormat.Format16bppRgb565,
        PixelFormat.Format24bppRgb, PixelFormat.Format32bppRgb, PixelFormat.Format48bppRgb
    };

    internal static readonly PaperSize[] PaperSizes =
    {
        new(PaperSize.AsPageSize, 0, 0), new(PaperSize.FixedWidthAutoHeight, 0, 0),
        new(PaperSize.AsWidestPage, 0, 0), new(PaperSize.AsNarrowestPage, 0, 0), new(PaperSize.AsLargestPage, 0, 0),
        new(PaperSize.AsSmallestPage, 0, 0), new("16 open (18.4*26.0)", 1840, 2601),
        new("32K (13.0*18.4)", 1300, 1840), new("Large 32K (14.0*20.3)", 1400, 2030),
        new("A4 (21.0*29.7)", 2100, 2970), new("A3 (29.7*42.0)", 2971, 4201), new("Custom", 0, 0),
        new("————————————", 0, 0), new("8 open(26.0*36.8)", 2601, 3681), new("16 open(18.4*26.0)", 1840, 2601),
        new("Large 16K (21.0*28.5)", 2100, 2851), new("32K (13.0*18.4)", 1300, 1840),
        new("Large 32 K (14.0*20.3)", 1400, 2030), new("8 K (27.3*39.3)", 2731, 3931),
        new("16 K (19.6*27.3)", 1960, 2731), new("A0 (84.1*118.9)", 8410, 11890), new("A1 (59.4*84.1)", 5940, 8410),
        new("A2 (42.0*59.4)", 4200, 5940), new("A3 (29.7*42.0)", 2971, 4201), new("A4 (21.0*29.7)", 2100, 2971),
        new("A5 (14.8*21.0)", 1480, 2100), new("A6 (10.5*14.8)", 1050, 1480), new("B0 (100.0*141.3)", 10000, 14130),
        new("B1 (70.7*100.0)", 7070, 10000), new("B2 (50.0*70.7)", 5000, 7070), new("B3 (35.3*50.0)", 3530, 5000),
        new("B4 (25.0*35.3)", 2500, 3530), new("B5 (17.6*25.0)", 1760, 2501), new("B6 (12.5*17.6)", 1250, 1760)
    };

    private readonly bool _autoRotate;
    private readonly PaperSize _content;
    private readonly Document _doc;
    private readonly ImporterOptions _impOptions;
    private readonly MergerOptions _option;
    private readonly PageBoxSettings _pageSettings;
    private readonly DocumentSink _sink;
    private readonly PdfSmartCopy _writer;
    private readonly bool areMarginsEqual;
    private readonly HorizontalAlignment hAlign;
    private readonly bool scaleUp, scaleDown;
    private readonly VerticalAlignment vAlign;
    private bool _portrait;

    public PdfDocumentCreator(DocumentSink sink, MergerOptions option, ImporterOptions impOptions, Document document,
        PdfSmartCopy writer)
    {
        _sink = sink;
        _option = option;
        _impOptions = impOptions;
        _doc = document;
        _writer = writer;
        PageBoxSettings ps = _pageSettings = option.PageSettings;
        _content = new PaperSize(ps.PaperSize.PaperName, option.ContentWidth, option.ContentHeight);
        _portrait = _content.Height > _content.Width;
        _autoRotate = ps.AutoRotation && _content.Height != _content.Width;
        hAlign = ps.HorizontalAlign;
        vAlign = ps.VerticalAlign;
        scaleUp = option.AutoScaleUp;
        scaleDown = option.AutoScaleDown;
        areMarginsEqual = ps.Margins.Top == ps.Margins.Left
                          && ps.Margins.Top == ps.Margins.Right
                          && ps.Margins.Top == ps.Margins.Bottom;
        if (impOptions.ImportBookmarks)
        {
            PdfBookmarks = new PdfInfoXmlDocument();
        }

        if (_content.SpecialSize == SpecialPaperSize.None)
        {
            _doc.SetPageSize(new Rectangle(ps.PaperSize.Width, ps.PaperSize.Height));
        }
    }

    /// <summary>
    ///     When the link is retained in the Incoming Construction Function option, get the bookmark for the recently processed
    ///     PDF document.
    /// </summary>
    public PdfInfoXmlDocument PdfBookmarks { get; }

    internal void ProcessFile(SourceItem sourceFile, BookmarkContainer bookmarkContainer)
    {
        if (sourceFile.Type != SourceItem.ItemType.Empty)
        {
            Tracker.TraceMessage(Tracker.Category.InputFile, sourceFile.FilePath.ToString());
        }

        BookmarkElement b = CreateAutoBookmark(sourceFile, bookmarkContainer);
        switch (sourceFile.Type)
        {
            case SourceItem.ItemType.Empty:
                Tracker.TraceMessage("Add a blank page.");
                AddEmptyPage();
                SetBookmarkAction(b);
                break;
            case SourceItem.ItemType.Pdf:
                Tracker.TraceMessage("Add document: " + sourceFile);
                AddPdfPages(sourceFile as SourceItem.Pdf, b);
                Tracker.IncrementProgress(sourceFile.FileSize);
                break;
            case SourceItem.ItemType.Image:
                Tracker.TraceMessage("Add image: " + sourceFile);
                AddImagePage(sourceFile, b);
                Tracker.IncrementProgress(sourceFile.FileSize);
                break;
            case SourceItem.ItemType.Folder:
                Tracker.TraceMessage("Add folder: " + sourceFile);
                break;
        }

        if (!sourceFile.HasSubItems)
        {
            return;
        }

        bool p = false;
        int pn = _writer.CurrentPageNumber;
        foreach (SourceItem item in sourceFile.Items)
        {
            ProcessFile(item, b ?? bookmarkContainer);
            if (p)
            {
                continue;
            }

            p = true;
            BookmarkElement t = b;
            while (b?.Page == 0)
            {
                b.Page = pn;
                b.DestinationView = Constants.DestinationAttributes.ViewType.XYZ;
                b.Top = _doc.PageSize.Height;
                b = b.ParentBookmark;
            }

            b = t;
        }
    }

    private void AddImagePage(SourceItem source, BookmarkElement bookmark)
    {
        string ext = source.FilePath.FileExtension.ToLowerInvariant();
        if (__BuiltInImageTypes.Contains(ext))
        {
            Image image = LoadImage(source, ext);
            if (ext is Constants.FileExtensions.Jpg or Constants.FileExtensions.Jpeg)
            {
                if (JpgHelper.TryGetExifOrientation(source.FilePath, out ushort o) && o != 0)
                {
                    switch (o)
                    {
                        case 6:
                            image.RotationDegrees = -90;
                            break;
                        case 3:
                            image.RotationDegrees = 180;
                            break;
                        case 8:
                            image.RotationDegrees = 90;
                            break;
                    }
                }
            }

            if (image == null)
            {
                Tracker.TraceMessage("Unable to add files:" + source.FilePath);
            }
            else
            {
                AddImage(image);
                SetBookmarkAction(bookmark);
            }
        }
        else if (__ExtImageTypes.Contains(ext))
        {
            FreeImageBitmap fi = null;
            try
            {
                fi = FreeImageBitmap.FromFile(source.FilePath);
                int c = fi.FrameCount;
                for (int i = 0; i < c; i++)
                {
                    Image img = LoadImageFrame(source as SourceItem.Image, _option.RecompressWithJbig2, ref fi);
                    AddImage(img);
                    if (i == 0)
                    {
                        SetBookmarkAction(bookmark);
                    }
                }
            }
            finally
            {
                if (fi != null)
                {
                    fi.Dispose();
                }
            }
        }
    }

    private void SetBookmarkAction(BookmarkElement bookmark)
    {
        if (bookmark == null)
        {
            return;
        }

        bookmark.Page = _writer.PageEmpty ? _writer.CurrentPageNumber - 1 : _writer.CurrentPageNumber;
        bookmark.DestinationView = Constants.DestinationAttributes.ViewType.XYZ;
        bookmark.Top = _doc.PageSize.Height;
    }

    private void AddEmptyPage()
    {
        if (_content.SpecialSize is SpecialPaperSize.None or SpecialPaperSize.AsSpecificPage)
        {
            // Insert blank page
            _doc.NewPage();
            _writer.PageEmpty = false;
        }
        else
        {
            Tracker.TraceMessage("No page size is specified, you cannot insert a blank page.");
        }
    }

    private void AddPdfPages(SourceItem.Pdf sourceFile, BookmarkContainer bookmark)
    {
        PdfReader pdf = _sink.GetPdfReader(sourceFile.FilePath);
        if (pdf.ConfirmUnethicalMode() == false)
        {
            Tracker.TraceMessage("Ignore the file with no permission processing:" + sourceFile.FilePath);
            if (_sink.DecrementReference(sourceFile.FilePath) < 1)
            {
                pdf.Close();
            }

            return;
        }

        PageRangeCollection ranges = PageRangeCollection.Parse(sourceFile.PageRanges, 1, pdf.NumberOfPages, true);
        int[] pageRemapper = new int[pdf.NumberOfPages + 1];
        // Unified page rotation angle
        if (_option.UnifyPageOrientation)
        {
            bool rv = _option.RotateVerticalPages;
            int a = _option.RotateAntiClockwise ? -90 : 90;
            for (int i = pdf.NumberOfPages; i > 0; i--)
            {
                PdfDictionary p = pdf.GetPageN(i);
                Rectangle r = p.GetPageVisibleRectangle();
                if (rv && r.Width < r.Height
                    || rv == false && r.Width > r.Height)
                {
                    p.Put(PdfName.ROTATE, (r.Rotation + a) % 360);
                }
            }
        }

        if (bookmark != null)
        {
            int n = _writer.CurrentPageNumber + 1;
            if (_writer.PageEmpty)
            {
                n--;
            }

            bookmark.SetAttribute(Constants.DestinationAttributes.Page, n.ToText());
            bookmark.SetAttribute(Constants.DestinationAttributes.View, Constants.DestinationAttributes.ViewType.XYZ);
            Rectangle r = pdf.GetPageN(ranges[0].StartValue).GetPageVisibleRectangle();
            float t = (r.Rotation % 360 / 90) switch
            {
                0 => r.Top,
                1 => r.Right,
                2 => r.Bottom,
                3 => r.Left,
                _ => 0
            };

            bookmark.SetAttribute(Constants.Coordinates.Top, t.ToText());
        }

        bool importImagesOnly = sourceFile.ImportImagesOnly;
        int pn = pdf.NumberOfPages;
        ImageExtractor imgExp = null;
        if (importImagesOnly)
        {
            imgExp = new ImageExtractor(sourceFile.ExtractImageOptions);
        }

        if (_option.KeepBookmarks)
        {
            pdf.ConsolidateNamedDestinations();
        }

        byte[] pp = new byte[pdf.NumberOfPages + 1]; // Processable page
        CoordinateTranslationSettings[] cts = _pageSettings.PaperSize.SpecialSize != SpecialPaperSize.AsPageSize
            ? new CoordinateTranslationSettings[pdf.NumberOfPages + 1]
            : null; // Page position offset
        foreach (int i in ranges.SelectMany(r => r))
        {
            if (i < 1 || i > pn)
            {
                goto Exit;
            }

            pageRemapper[i] = _writer.CurrentPageNumber;

            _doc.NewPage();
            if (imgExp != null)
            {
                imgExp.ExtractPageImages(pdf, i);
                foreach (ImageInfo item in imgExp.InfoList.Where(item => item.FileName != null))
                {
                    ProcessFile(new SourceItem.Image(item.FileName), bookmark);
                    File.Delete(item.FileName);
                }
            }
            else
            {
                if (pp[i] == 0)
                {
                    PdfDictionary page = pdf.GetPageN(i);
                    //if (DocInfoImporter.RemovePageAdditionalInfo (_docSettings, page)) {
                    //    pdf.ResetReleasePage ();
                    //}
                    //if (_docSettings.AutoMaskBWImages) {
                    //    SetBWImageMask (page);
                    //    pdf.ResetReleasePage ();
                    //}
                    //PdfHelper.ClearPageLinks (pdf, i);
                    if (_pageSettings.PaperSize.SpecialSize != SpecialPaperSize.AsPageSize)
                    {
                        pdf.ResetReleasePage();
                        CoordinateTranslationSettings ct =
                            PageDimensionProcessor.ResizePage(page, _pageSettings, null);
                        if (_pageSettings.ScaleContent)
                        {
                            PageDimensionProcessor.ScaleContent(pdf, i, ct);
                        }

                        if (cts != null)
                        {
                            cts[i] = ct;
                        }

                        pdf.ResetReleasePage();
                    }
                    //var og = new OperatorGroup (null);
                    //if (_docSettings.FixContents) {
                    //    og.Operators.Add (PdfContentStreamProcessor.NopOperator);
                    //}
                    //if (og.Operators.Count > 0) {
                    //    var cp = new PdfPageCommandProcessor ();
                    //    cp.ProcessContent (cb ?? pdf.GetPageContent (i), pdf.GetPageN (i).GetAsDict (PdfName.RESOURCES));
                    //    cp.WritePdfCommands (pdf, i);
                    //}

                    pp[i] = 1;
                }

                _writer.AddPage(_writer.GetImportedPage(pdf, i));
            }

        Exit:
            Tracker.IncrementProgress(1);
        }

        if (_option.KeepBookmarks)
        {
            KeepBookmarks(bookmark, pdf, pageRemapper, cts);
        }

        if (_sink.DecrementReference(sourceFile.FilePath) >= 1)
        {
            return;
        }

        _writer.FreeReader(pdf);
        pdf.Close();
    }

    private void KeepBookmarks(BookmarkContainer bookmark, PdfReader pdf, int[] pageRemapper,
        CoordinateTranslationSettings[] cts)
    {
        XmlElement bm = OutlineManager.GetBookmark(pdf, new UnitConverter { Unit = Constants.Units.Point });
        List<IInfoDocProcessor> processors = new();
        if (_option.ViewerPreferences.CollapseBookmark != BookmarkStatus.AsIs)
        {
            processors.Add(new CollapseBookmarkProcessor { BookmarkStatus = _option.ViewerPreferences.CollapseBookmark });
        }

        if (_option.ViewerPreferences.RemoveZoomRate)
        {
            processors.Add(new RemoveZoomRateProcessor());
        }

        if (_option.ViewerPreferences.ForceInternalLink)
        {
            processors.Add(new ForceInternalDestinationProcessor());
        }

        processors.Add(new GotoDestinationProcessor
        {
            RemoveOrphanDestination = _option.RemoveOrphanBookmarks,
            PageRemapper = pageRemapper,
            TransitionMapper = cts
        });
        ProcessInfoItem(bm, processors);
        if (bookmark != null)
        {
            bookmark.SetAttribute(Constants.BookmarkAttributes.Open,
                _option.ViewerPreferences.CollapseBookmark == BookmarkStatus.CollapseAll
                    ? Constants.Boolean.False
                    : Constants.Boolean.True);
        }
        else if (PdfBookmarks != null)
        {
            bookmark = PdfBookmarks.BookmarkRoot;
        }
        else
        {
            return;
        }

        if (bm == null)
        {
            return;
        }

        while (bm.FirstChild != null)
        {
            if (bm.FirstChild.NodeType == XmlNodeType.Element)
            {
                bookmark.AppendChild(bookmark.OwnerDocument.ImportNode(bm.FirstChild, true));
            }

            bm.RemoveChild(bm.FirstChild);
        }
    }

    internal static void ProcessInfoItem(XmlElement item, ICollection<IInfoDocProcessor> processors)
    {
        if (item == null)
        {
            return;
        }

        foreach (IInfoDocProcessor p in processors)
        {
            p.Process(item);
        }

        XmlNode c = item.FirstChild;
        while (c != null)
        {
            XmlElement ce = c as XmlElement;
            XmlNode r = c.PreviousSibling;
            if (ce != null)
            {
                ProcessInfoItem(ce, processors);
            }

            if (c.ParentNode == null) // The node is deleted during processing
                                      //while (c.HasChildNodes) {
                                      //    var cc = c.FirstChild as XmlElement;
                                      //    if (cc == null ||
                                      //        (cc.HasAttribute (Constants.DestinationAttributes.Action) == false
                                      //            && cc.HasChildNodes == false)) {
                                      //        c.RemoveChild (cc);
                                      //        continue;
                                      //    }
                                      //    item.InsertAfter (cc, r);
                                      //}
            {
                c = r != null ? r.NextSibling : item.FirstChild;
            }
            else
            {
                c = c.NextSibling;
            }
        }
    }

    //internal static void SetBWImageMask (PdfDictionary page) {
    //    var xo = PdfHelper.Locate<PdfDictionary> (page, true, PdfName.RESOURCES, PdfName.XOBJECT);
    //    foreach (var item in xo) {
    //        var o = PdfReader.GetPdfObject (item.Value) as PdfDictionary;
    //        if (o == null
    //            || PdfName.IMAGE.Equals(o.Get(PdfName.SUBTYPE)) == false
    //            || PdfHelper.ValueIs (o.GetAsBoolean (PdfName.IMAGEMASK), true)
    //            || PdfHelper.ValueIs (o.GetAsNumber (PdfName.BITSPERCOMPONENT), 1) == false) {
    //            continue;
    //        }
    //        o.Put (PdfName.IMAGEMASK, PdfBoolean.PDFTRUE);
    //        o.Remove (PdfName.MASK);
    //        var cs = o.GetAsArray (PdfName.COLORSPACE);
    //        if (cs != null && cs.Size == 4
    //            && PdfHelper.ValueIs (cs.GetAsName (0), PdfName.INDEXED)
    //            && PdfHelper.ValueIs (cs.GetAsName (1), PdfName.DEVICERGB)
    //            && PdfHelper.ValueIs (cs.GetAsNumber (2), 1)) {
    //            PdfObject cl = cs.GetDirectObject (3);
    //            byte[] l = null;
    //            if (cs.IsString ()) {
    //                l = (cl as PdfString).GetOriginalBytes ();
    //            }
    //            else if (cs.IsStream ()) {
    //                l = PdfReader.GetStreamBytes (cl as PRStream);
    //            }
    //            Array.Resize (ref l, 6);
    //            if (l[0] == 0xFF) {

    //            }
    //        }
    //        o.Remove (PdfName.COLORSPACE);
    //    }
    //}

    private static iTextImage LoadImage(SourceItem sourceFile, string ext)
    {
        SourceItem.Image imageItem = sourceFile as SourceItem.Image;
        SourceItem.CropOptions cropOptions = imageItem.Cropping;
        if (cropOptions.NeedCropping == false)
        {
            return Image.GetInstance(sourceFile.FilePath.ToString());
        }

        ext = ext.ToLowerInvariant();
        using FreeImageBitmap fi = new(sourceFile.FilePath);
        if (fi.Height < cropOptions.MinHeight // Do not meet dimensional limitations
            || fi.Width < cropOptions.MinWidth
            || fi.Height <= cropOptions.Top + cropOptions.Bottom // Cropped size less than 0
            || fi.Width <= cropOptions.Left + cropOptions.Right
           )
        {
            return Image.GetInstance(sourceFile.FilePath.ToString());
        }

        if (ext is Constants.FileExtensions.Jpg or ".jpeg")
        {
            // is JPEG file
            FilePath t = sourceFile.FilePath.EnsureExtension(Constants.FileExtensions.Jpg);
            if (FreeImageBitmap.JPEGCrop(sourceFile.FilePath, t, cropOptions.Left, cropOptions.Top,
                    fi.Width - cropOptions.Right, fi.Height - cropOptions.Bottom))
            {
                iTextImage image;
                using (FileStream fs = new(t, FileMode.Open))
                {
                    image = Image.GetInstance(fs);
                }

                File.Delete(t);
                return image;
            }
        }

        using FreeImageBitmap tmp = fi.Copy(cropOptions.Left, cropOptions.Top, fi.Width - cropOptions.Right,
            fi.Height - cropOptions.Bottom);
        using MemoryStream ms = new();
        tmp.Save(ms, fi.ImageFormat);
        ms.Flush();
        ms.Position = 0;
        return Image.GetInstance(ms);
    }

    private BookmarkElement CreateAutoBookmark(SourceItem sourceFile, XmlNode bookmarkContainer)
    {
        if (PdfBookmarks == null
            || sourceFile.Bookmark == null
            || string.IsNullOrEmpty(sourceFile.Bookmark.Title))
        {
            return null;
        }

        BookmarkElement b = PdfBookmarks.CreateBookmark(sourceFile.Bookmark);
        bookmarkContainer.AppendChild(b);
        return b;
    }

    private void AddImage(iTextImage image)
    {
        if (_option.AutoMaskBWImages && image.IsMaskCandidate())
        {
            image.MakeMask();
        }

        image.ScalePercent(72f / image.DpiX.SubstituteDefault(72) * 100f,
            72f / image.DpiY.SubstituteDefault(72) * 100f);
        switch (_content.SpecialSize)
        {
            case SpecialPaperSize.AsPageSize:
                _doc.SetPageSize(new Rectangle(image.ScaledWidth + _doc.LeftMargin + _doc.RightMargin,
                    image.ScaledHeight + _doc.TopMargin + _doc.BottomMargin));
                break;
            case SpecialPaperSize.FixedWidthAutoHeight:
                {
                    if (scaleDown && image.ScaledWidth > _content.Width ||
                        scaleUp && image.ScaledWidth < _content.Width)
                    {
                        image.ScaleToFit(_content.Width, 999999);
                    }

                    _doc.SetPageSize(new Rectangle(_content.Width,
                        image.ScaledHeight + _doc.TopMargin + _doc.BottomMargin));
                    break;
                }
            default:
                {
                    if (_autoRotate
                        && ( // Page is not enough to put down the image of the current size
                            (image.ScaledHeight > _content.Height || image.ScaledWidth > _content.Width)
                            && (image.ScaledWidth > image.ScaledHeight && _portrait
                                || image.ScaledHeight > image.ScaledWidth && _portrait == false)
                            ||
                            // The image is small, you can restore the original page direction
                            _portrait != _option.ContentHeight > _option.ContentWidth
                            && image.ScaledHeight <= _content.Height && image.ScaledWidth <= _content.Width
                            && image.ScaledHeight <= _content.Width && image.ScaledWidth <= _content.Height
                        )
                       )
                    {
                        float t = _content.Height;
                        _content.Height = _content.Width;
                        _content.Width = t;
                        _doc.SetPageSize(new Rectangle(_doc.PageSize.Height, _doc.PageSize.Width));
                        if (areMarginsEqual == false)
                        {
                            if (_portrait)
                            {
                                _doc.SetMargins(_doc.BottomMargin, _doc.TopMargin, _doc.LeftMargin, _doc.RightMargin);
                            }
                            else
                            {
                                _doc.SetMargins(_doc.TopMargin, _doc.BottomMargin, _doc.RightMargin, _doc.LeftMargin);
                            }
                        }

                        _portrait = !_portrait;
                    }

                    if (scaleDown && (image.ScaledHeight > _content.Height || image.ScaledWidth > _content.Width)
                        || scaleUp && image.ScaledHeight < _content.Height && image.ScaledWidth < _content.Width)
                    {
                        image.ScaleToFit(_content.Width, _content.Height);
                    }

                    float px = 0, py = 0;
                    px = hAlign switch
                    {
                        HorizontalAlignment.Center => (_content.Width - image.ScaledWidth) / 2f,
                        HorizontalAlignment.Right => _content.Width - image.ScaledWidth,
                        _ => px
                    };

                    py = vAlign switch
                    {
                        VerticalAlignment.Middle => (_content.Height - image.ScaledHeight) / 2f,
                        VerticalAlignment.Top => _content.Height - image.ScaledHeight,
                        _ => py
                    };

                    image.SetAbsolutePosition(_doc.LeftMargin + px, _doc.BottomMargin + py);
                    break;
                }
        }

        _doc.NewPage();
        _doc.Add(image);
        _doc.NewPage();
    }

    private static Image LoadImageFrame(SourceItem.Image source, bool recompressWithJbig2, ref FreeImageBitmap fi)
    {
        iTextImage image;
        SourceItem.CropOptions cropOptions = source.Cropping;
        FREE_IMAGE_FORMAT format;
        if (fi.ImageFormat == FREE_IMAGE_FORMAT.FIF_GIF
            || fi.InfoHeader.biCompression == FreeImage.BI_PNG)
        {
            format = FREE_IMAGE_FORMAT.FIF_PNG;
        }
        else if (fi.ColorDepth > 8
                 && fi.ColorType == FREE_IMAGE_COLOR_TYPE.FIC_RGB
                 && fi.HasPalette == false
                 && __JpgFormats.Contains(fi.PixelFormat))
        {
            format = FREE_IMAGE_FORMAT.FIF_JPEG;
        }
        else if (fi.InfoHeader.biCompression == FreeImage.BI_JPEG)
        {
            format = FREE_IMAGE_FORMAT.FIF_JPEG;
        }
        else if (fi.ColorDepth > 16)
        {
            format = FREE_IMAGE_FORMAT.FIF_PNG;
        }
        else
        {
            format = fi.ImageFormat;
        }

        using (MemoryStream ms = new())
        {
            if (cropOptions.NeedCropping
                && (fi.Height < cropOptions.MinHeight // Do not meet dimensional limitations
                    || fi.Width < cropOptions.MinWidth
                    || fi.Height <= cropOptions.Top + cropOptions.Bottom // Cropped size less than 0
                    || fi.Width <= cropOptions.Left + cropOptions.Right) == false)
            {
                FreeImageBitmap temp = fi.Copy(cropOptions.Left, cropOptions.Top, fi.Width - cropOptions.Right,
                    fi.Height - cropOptions.Bottom);
                temp.Save(ms, format);
                fi.Dispose();
                fi = temp;
            }
            else
            {
                fi.Save(ms, format);
            }

            ms.Flush();
            ms.Position = 0;
            if (recompressWithJbig2 && fi.PixelFormat == PixelFormat.Format1bppIndexed)
            {
                image = iTextImage.GetInstance(fi.Width, fi.Height, JBig2Encoder.Encode(fi), null);
            }
            else
            {
                try
                {
                    image = iTextImage.GetInstance(ms.ToArray(), true);
                }
                catch (IndexOutOfRangeException)
                {
                    // In some cases, the flow of FreeImage is not read, try reading the original file, let ITextImage resolve themselves
                    image = iTextImage.GetInstance(source.FilePath.ReadAllBytes(), true);
                }
            }
        }

        if (fi.HorizontalResolution != fi.VerticalResolution)
        {
            image.SetDpi(fi.HorizontalResolution.ToInt32(), fi.VerticalResolution.ToInt32());
        }

        //image.ScaleAbsoluteHeight (fi.Height * 72 / fi.VerticalResolution);
        //image.ScaleAbsoluteWidth (fi.Width * 72 / fi.HorizontalResolution);
        return image;
    }
}
