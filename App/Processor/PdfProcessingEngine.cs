﻿using System;
using System.Collections.Generic;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using PDFPatcher.Model;

namespace PDFPatcher.Processor;

internal sealed class PdfProcessingEngine
{
    public PdfProcessingEngine(PdfReader pdf)
    {
        DocumentProcessors = new List<IDocProcessor>();
        PageProcessors = new List<IPageProcessor>();
        Pdf = pdf;
        ExtraData = new Dictionary<int, object>();
    }

    /// <summary>Get a list of document processor.</summary>
    internal List<IDocProcessor> DocumentProcessors { get; }

    /// <summary>Get the page processor list.</summary>
    internal List<IPageProcessor> PageProcessors { get; }

    public PdfReader Pdf { get; }
    public Dictionary<int, object> ExtraData { get; }

    public void CreateProcessors(PatcherOptions settings)
    {
        if (settings.RemoveBookmarks)
        {
            DocumentProcessors.Add(new RemoveBookmarkProcessor());
        }

        if (settings.FixContents)
        {
            PageProcessors.Add(new FixContentProcessor());
        }

        if (settings.EmbedFonts || settings.EnableFontSubstitutions && settings.FontSubstitutions.Count > 0)
        {
            Dictionary<string, FontSubstitution> d = new(settings.FontSubstitutions.Count,
                StringComparer.CurrentCultureIgnoreCase);
            if (settings.EnableFontSubstitutions)
            {
                foreach (FontSubstitution item in settings.FontSubstitutions.Where(item =>
                             !string.IsNullOrEmpty(item.OriginalFont) && !string.IsNullOrEmpty(item.Substitution)))
                {
                    d[item.OriginalFont] = item;
                }
            }

            if (settings.EmbedFonts || d.Count > 0)
            {
                PageProcessors.Add(new ReplaceFontProcessor(settings.EmbedFonts, settings.TrimTrailingWhiteSpace, d));
            }
        }

        if (settings.RemovePageForms)
        {
            PageProcessors.Add(new RemoveFormProcessor());
        }

        if (settings.RemovePageLinks)
        {
            PageProcessors.Add(new RemoveAnnotationProcessor(PdfName.LINK));
        }

        if (settings.RecompressWithJbig2)
        {
            PageProcessors.Add(new ImageRecompressor());
        }
        //this.PageProcessors.Add (new ColorizeBinaryImageProcessor ());

        if (settings.RemovePageTextBlocks)
        {
            PageProcessors.Add(new RemoveTextBlockProcessor());
        }

        if (settings.RemovePageThumbnails)
        {
            PageProcessors.Add(new RemoveThumbnailProcessor());
        }

        if (settings.UnifiedPageSettings.NeedAdjustMargins || settings.UnifiedPageSettings.NeedResize)
        {
            PageProcessors.Add(new PageDimensionProcessor { Settings = settings.UnifiedPageSettings });
        }

        if (settings.RemoveLeadingCommandCount > 0 || settings.RemoveTrailingCommandCount > 0)
        {
            PageProcessors.Add(new RemoveWrappedCommandProcessor(settings.RemoveLeadingCommandCount,
                settings.RemoveTrailingCommandCount));
        }

        if (settings.PageSettings.Count > 0)
        {
            foreach (PageBoxSettings item in settings.PageSettings)
            {
                PageProcessors.Add(new PageDimensionProcessor { Settings = item });
            }
        }

        //if (settings.DeskewImages) {
        //    this.PageProcessors.Add (new ImageDeskewProcessor ());
        //}
        PageProcessors.Add(new CommonProcessor(settings));
    }

    internal int EstimateWorkload() => DocumentProcessors.Sum(p => p.EstimateWorkload(Pdf)) +
                                       PageProcessors.Sum(p => p.EstimateWorkload(Pdf));

    internal void ProcessDocument(PdfWriter writer) => ProcessDocument(writer, null);

    internal void ProcessDocument(PdfWriter writer, Document document)
    {
        IPageProcessor[] pp = PageProcessors.ToArray();
        DocProcessorContext dc = new(this, writer, document);
        foreach (IDocProcessor p in DocumentProcessors)
        {
            Tracker.TraceMessage(p.Name);
            p.BeginProcess(dc);
        }

        foreach (IPageProcessor p in pp)
        {
            Tracker.TraceMessage(p.Name);
            p.BeginProcess(dc);
        }

        foreach (IDocProcessor p in DocumentProcessors)
        {
            p.Process(dc);
        }

        int pn = Pdf.NumberOfPages;
        int i = 0;
        while (++i <= pn)
        {
            PageProcessorContext pc = new(Pdf, i);
            try
            {
                foreach (IPageProcessor p in pp)
                {
                    p.Process(pc);
                }

                if (pc.IsPageContentModified)
                {
                    pc.WritePageCommands();
                }
            }
            catch (Exception)
            {
                Tracker.TraceMessage("In handling the document " + i + " An error occurred.");
                throw;
            }
        }

        foreach (IDocProcessor p in DocumentProcessors)
        {
            p.EndProcess(dc);
        }

        foreach (IPageProcessor p in pp)
        {
            p.EndProcess(Pdf);
        }
    }
}
