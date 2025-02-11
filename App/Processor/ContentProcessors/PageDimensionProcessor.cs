﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using PDFPatcher.Common;
using PDFPatcher.Model;

namespace PDFPatcher.Processor;

internal sealed class PageDimensionProcessor : IPageProcessor
{
    private CoordinateTranslationSettings[] _cts;
    private PageRangeCollection _pageRanges;
    private PaperSize _refPaperSize;
    private bool _resizePages, _adjustMargins;
    public PageBoxSettings Settings { get; set; }

    #region IProcessor member

    public string Name => "Modify page size";

    #endregion

    internal static CoordinateTranslationSettings ResizePage(PdfDictionary page, PageBoxSettings settings,
        PaperSize refPaperSize)
    {
        PaperSize size = refPaperSize ?? settings.PaperSize.Clone();
        HorizontalAlignment hAlign = settings.HorizontalAlign;
        VerticalAlignment vAlign = settings.VerticalAlign;
        PdfArray pb = page.GetAsArray(PdfName.CROPBOX);
        Rectangle b = pb != null ? PdfReader.GetNormalizedRectangle(pb) : null;
        pb = page.GetAsArray(PdfName.MEDIABOX);
        if (pb == null)
        {
            throw new PdfException("MediaBox is missing from the page.");
        }

        Rectangle mb = PdfReader.GetNormalizedRectangle(pb);
        int n = PdfHelper.GetPageRotation(page);
        if (n is 90 or 270)
        {
            size = new PaperSize(size.PaperName, size.Height, size.Width);
        }

        // Automatically rotate the page to adapt to the orientation of the original page
        if (settings.AutoRotation && size.SpecialSize == SpecialPaperSize.None &&
            (size.Width > size.Height) ^ (mb.Width > mb.Height))
        {
            size = new PaperSize(size.PaperName, size.Height, size.Width);
        }

        b ??= new Rectangle(mb);

        float d, z = 1;
        float dx = 0, dy = 0;
        float sw = b.Width, sh = b.Height; // resized width and height
        if (size.SpecialSize is SpecialPaperSize.FixedWidthAutoHeight or SpecialPaperSize.AsWidestPage
            or SpecialPaperSize.AsNarrowestPage)
        {
            size.Height = b.Height * size.Width / b.Width;
        }

        if (settings.ScaleContent)
        {
            float zx = size.Width / b.Width;
            float zy = size.Height / b.Height;
            z = zx < zy ? zx : zy;
            sw *= z;
            sh *= z;
            b.Left *= z;
            b.Bottom *= z;
            b.Top *= z;
            b.Right *= z;
        }

        if (b.Width != size.Width)
        {
            d = size.Width - sw;
            dx = hAlign switch
            {
                HorizontalAlignment.Left => 0,
                HorizontalAlignment.Right => d,
                _ => d / 2
            };
            b.Left -= dx;
            b.Right = b.Left + size.Width;
        }

        if (b.Height != size.Height)
        {
            d = size.Height - sh;
            dy = vAlign switch
            {
                VerticalAlignment.Bottom => d,
                VerticalAlignment.Top => 0,
                _ => d / 2
            };
            b.Top += dy;
            b.Bottom = b.Top - size.Height;
        }

        float[] a = { b.Left, b.Bottom, b.Right, b.Top };
        page.Put(PdfName.CROPBOX, new PdfArray(a));
        ResizeBox(page, mb, b);
        if (page.GetAsArray(PdfName.BLEEDBOX) != null)
        {
            ResizeBox(page, PdfReader.GetNormalizedRectangle(page.GetAsArray(PdfName.BLEEDBOX)), b);
        }

        if (page.GetAsArray(PdfName.TRIMBOX) != null)
        {
            ResizeBox(page, PdfReader.GetNormalizedRectangle(page.GetAsArray(PdfName.TRIMBOX)), b);
        }

        if (page.GetAsArray(PdfName.ARTBOX) != null)
        {
            ResizeBox(page, PdfReader.GetNormalizedRectangle(page.GetAsArray(PdfName.ARTBOX)), b);
        }
        //if (p.Contains (PdfName.BLEEDBOX)) {
        //    p.Put (PdfName.BLEEDBOX, pr);
        //}
        //if (p.Contains(PdfName.TRIMBOX)) {
        //    p.Put (PdfName.TRIMBOX, pr);
        //}
        //if (p.Contains(PdfName.ARTBOX)) {
        //    p.Put (PdfName.ARTBOX, pr);
        //}

        CoordinateTranslationSettings ct = new();
        if (settings.ScaleContent)
        {
            ct.XScale = ct.YScale = z;
        }
        else
        {
            ct.XTranslation = -dx;
            ct.YTranslation = -dy;
        }

        return ct;
    }

    private static void ResizeBox(PdfDictionary page, Rectangle box, Rectangle refBox) =>
        page.Put(PdfName.MEDIABOX,
            new PdfArray(new[]
            {
                box.Left < refBox.Left ? box.Left : refBox.Left,
                box.Bottom < refBox.Bottom ? box.Bottom : refBox.Bottom,
                box.Right > refBox.Right ? box.Right : refBox.Right, box.Top > refBox.Top ? box.Top : refBox.Top
            }));

    private static void RotatePage(PdfDictionary page, PageBoxSettings settings)
    {
        if (settings.Rotation == 0)
        {
            return;
        }

        Rectangle mb = GetPageBox(page);
        bool ls = mb.Width > mb.Height; // Landscape
        if (ls && (settings.Filter & PageFilterFlag.Portrait) == PageFilterFlag.Portrait
            || ls == false && (settings.Filter & PageFilterFlag.Landscape) == PageFilterFlag.Landscape)
        {
            return;
        }

        int n = (PdfHelper.GetPageRotation(page) + settings.Rotation) % 360;
        if (n != 0)
        {
            page.Put(PdfName.ROTATE, n);
        }
        else
        {
            page.Remove(PdfName.ROTATE);
        }
    }

    private static Rectangle GetPageBox(PdfDictionary page)
    {
        PdfArray pb = page.GetAsArray(PdfName.CROPBOX) ?? page.GetAsArray(PdfName.MEDIABOX);
        if (pb == null)
        {
            throw new PdfException("MediaBox is missing from the page.");
        }

        return PdfReader.GetNormalizedRectangle(pb);
    }

    private static bool FilterPageNumber(int pageNumber, PageFilterFlag filter)
    {
        bool odd = (pageNumber & 1) > 0;
        return (!odd || (filter & PageFilterFlag.Even) != PageFilterFlag.Even) &&
               (odd || (filter & PageFilterFlag.Odd) != PageFilterFlag.Odd);
    }

    /// <summary>
    ///     Non-destructive tensile flippage.
    /// </summary>
    /// <param name="pdf">PDF document.</param>
    /// <param name="panumber">page.</param>
    /// <param name="ct">stretching and translation parameters.</param>
    internal static byte[] ScaleContent(PdfReader pdf, int pageNumber, CoordinateTranslationSettings ct)
    {
        byte[] newContent = Encoding.ASCII.GetBytes(string.Join(" ", ct.XScale.ToText(), "0", "0", ct.YScale.ToText(),
            ct.XTranslation.ToText(), ct.YTranslation.ToText(), "cm "));
        byte[] cb = pdf.GetPageContent(pageNumber);
        Array.Resize(ref newContent, cb.Length + newContent.Length);
        cb.CopyTo(newContent, newContent.Length - cb.Length);
        pdf.SafeSetPageContent(pageNumber, newContent);

        PdfDictionary page = pdf.GetPageN(pageNumber);
        RewriteAnnotationCoordinates(ct, page);
        return newContent;
    }

    private static void ScaleContent(PageProcessorContext context, CoordinateTranslationSettings ct)
    {
        IList<PdfPageCommand> cmds = context.PageCommands.Commands;
        if (cmds.Count > 0 && cmds[0].Type == PdfPageCommandType.Matrix)
        {
            MatrixCommand c = cmds[0] as MatrixCommand;
            if (c.Name.ToString() == "cm")
            {
                c.Multiply(new double[] { ct.XScale, 0, 0, ct.YScale, ct.XTranslation, ct.YTranslation });
            }
        }
        else
        {
            cmds.Insert(0,
                new MatrixCommand(MatrixCommand.CM, ct.XScale, 0, 0, ct.YScale, ct.XTranslation, ct.YTranslation));
        }

        RewriteAnnotationCoordinates(ct, context.Page);
    }

    private static void RewriteAnnotationCoordinates(CoordinateTranslationSettings ct, PdfDictionary page)
    {
        PdfArray ann = page.GetAsArray(PdfName.ANNOTS);
        if (ann == null)
        {
            return;
        }

        foreach (PdfObject item in ann.ArrayList)
        {
            if (PdfReader.GetPdfObject(item) is not PdfDictionary an)
            {
                continue;
            }

            PdfArray rect = an.GetAsArray(PdfName.RECT);
            if (rect is not { Size: 4 })
            {
                continue;
            }

            rect[0] = new PdfNumber((rect[0] as PdfNumber).FloatValue * ct.XScale + ct.XTranslation);
            rect[1] = new PdfNumber((rect[1] as PdfNumber).FloatValue * ct.YScale + ct.YTranslation);
            rect[2] = new PdfNumber((rect[2] as PdfNumber).FloatValue * ct.XScale + ct.XTranslation);
            rect[3] = new PdfNumber((rect[3] as PdfNumber).FloatValue * ct.YScale + ct.YTranslation);
        }
    }

    internal static void AdjustMargins(PdfDictionary page, Margins margins)
    {
        if (margins.IsRelative)
        {
            PdfArray box = page.GetAsArray(PdfName.CROPBOX) ?? page.GetAsArray(PdfName.MEDIABOX);
            Rectangle r = PdfReader.GetNormalizedRectangle(box);
            margins = new Margins(margins.Left * r.Width, margins.Top * r.Height, margins.Right * r.Width,
                margins.Bottom * r.Height);
        }

        AdjustBoxDimension(page, margins, PdfName.CROPBOX);
        AdjustBoxDimension(page, margins, PdfName.MEDIABOX);
        AdjustBoxDimension(page, margins, PdfName.BLEEDBOX);
        AdjustBoxDimension(page, margins, PdfName.TRIMBOX);
        AdjustBoxDimension(page, margins, PdfName.ARTBOX);
    }

    private static void AdjustBoxDimension(PdfDictionary page, Margins margins, PdfName boxName)
    {
        PdfArray b = page.GetAsArray(boxName);
        if (b == null)
        {
            return;
        }

        Rectangle r = PdfReader.GetNormalizedRectangle(b);
        page.Put(boxName,
            new PdfArray(new[]
            {
                r.Left - margins.Left, r.Bottom - margins.Bottom, r.Right + margins.Right, r.Top + margins.Top
            }));
    }

    #region IPageProcessor member

    public int EstimateWorkload(PdfReader pdf) => pdf.NumberOfPages;

    public void BeginProcess(DocProcessorContext context)
    {
        _resizePages = Settings.NeedResize;
        if (_resizePages)
        {
            context.ExtraData[DocProcessorContext.CoordinateTransition]
                = _cts
                    = new CoordinateTranslationSettings[context.Pdf.NumberOfPages + 1];
        }

        _adjustMargins = Settings.NeedAdjustMargins;
        _pageRanges = string.IsNullOrEmpty(Settings.PageRanges)
            ? null
            : PageRangeCollection.Parse(Settings.PageRanges, 1, context.Pdf.NumberOfPages, true);
        //todo Set the reference size for the newly added adaptation stretch mode
        switch (Settings.PaperSize.SpecialSize)
        {
            case SpecialPaperSize.AsSpecificPage:
                break;
            case SpecialPaperSize.AsWidestPage:
            case SpecialPaperSize.AsNarrowestPage:
            case SpecialPaperSize.AsLargestPage:
            case SpecialPaperSize.AsSmallestPage:
                _refPaperSize = GetRefPaperSize(context);
                if (_refPaperSize == null)
                {
                    throw new InvalidOperationException(
                        "Unable to match the page that is consistent with the specified size and page size.");
                }

                break;
        }
    }

    private PaperSize GetRefPaperSize(DocProcessorContext context)
    {
        Rectangle refRectangle = null;
        SpecialPaperSize specialSize = Settings.PaperSize.SpecialSize;
        foreach (Rectangle r in from range in _pageRanges ??
                                              PageRangeCollection.CreateSingle(1, context.Pdf.NumberOfPages)
                                from page in range
                                select context.Pdf.GetPageSizeWithRotation(page))
        {
            if (refRectangle == null)
            {
                refRectangle = r;
                continue;
            }

            switch (specialSize)
            {
                case SpecialPaperSize.AsWidestPage:
                    if (r.Width > refRectangle.Width)
                    {
                        refRectangle = r;
                    }

                    break;
                case SpecialPaperSize.AsNarrowestPage:
                    if (r.Width < refRectangle.Width)
                    {
                        refRectangle = r;
                    }

                    break;
                case SpecialPaperSize.AsLargestPage:
                    if (r.Width * r.Height > refRectangle.Width * refRectangle.Height)
                    {
                        refRectangle = r;
                    }

                    break;
                case SpecialPaperSize.AsSmallestPage:
                    if (r.Width * r.Height < refRectangle.Width * refRectangle.Height)
                    {
                        refRectangle = r;
                    }

                    break;
            }
        }

        return refRectangle != null
            ? new PaperSize(Settings.PaperSize.PaperName, refRectangle.Width,
                specialSize != SpecialPaperSize.AsNarrowestPage && specialSize != SpecialPaperSize.AsWidestPage
                    ? refRectangle.Height
                    : 0)
            : null;
    }

    public bool Process(PageProcessorContext context)
    {
        PageFilterFlag f = Settings.Filter;
        if (FilterPageNumber(context.PageNumber, f) == false)
        {
            return false;
        }

        if (_pageRanges != null && _pageRanges.IsInRange(context.PageNumber) == false)
        {
            return false;
        }

        context.Pdf.ResetReleasePage();
        if (_resizePages)
        {
            CoordinateTranslationSettings ct = ResizePage(context.Page, Settings, _refPaperSize);
            if (Settings.ScaleContent)
            {
                ScaleContent(context, ct);
                context.IsPageContentModified = true;
            }

            _cts[context.PageNumber] = ct;
        }

        if (_adjustMargins)
        {
            AdjustMargins(context.Page, Settings.Margins);
        }

        if (Settings.Rotation != 0)
        {
            RotatePage(context.Page, Settings);
        }

        context.Pdf.ResetReleasePage();
        return true;
    }

    public bool EndProcess(PdfReader pdf) => false;

    #endregion
}
