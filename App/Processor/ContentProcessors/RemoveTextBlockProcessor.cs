﻿using System.Collections.Generic;
using System.IO;
using iTextSharp.text.pdf;
using PDFPatcher.Model;

namespace PDFPatcher.Processor;

internal sealed class RemoveTextBlockProcessor : IPageProcessor
{
    private int _processedPageCount;

    private static bool ProcessCommands(IList<PdfPageCommand> parent)
    {
        bool r = false;
        for (int i = parent.Count - 1; i >= 0; i--)
        {
            EnclosingCommand ec = parent[i] as EnclosingCommand;
            if (ec == null)
            {
                continue;
            }

            if (ec.Name.ToString() == "BT")
            {
                parent.RemoveAt(i);
                r = true;
            }
            else
            {
                r |= ProcessCommands(ec.Commands);
            }
        }

        return r;
    }

    #region IPageProcessor member

    public string Name => "Delete text area";

    public void BeginProcess(DocProcessorContext context) => _processedPageCount = 0;

    public bool EndProcess(PdfReader pdf)
    {
        Tracker.TraceMessage(Tracker.Category.Notice, Name + "Function:");
        Tracker.TraceMessage(" Deleted " + _processedPageCount + " page text.");
        return false;
    }

    public int EstimateWorkload(PdfReader pdf) => pdf.NumberOfPages * 3;

    public bool Process(PageProcessorContext context)
    {
        Tracker.IncrementProgress(3);
        IPdfPageCommandContainer p = context.PageCommands;
        bool r = ProcessCommands(p.Commands);
        if (r)
        {
            context.IsPageContentModified = true;
            _processedPageCount++;
        }

        ProcessFormContent(context);
        return r;
    }

    private static void ProcessFormContent(PageProcessorContext context)
    {
        PdfDictionary fl = context.Page.Locate<PdfDictionary>(PdfName.RESOURCES, PdfName.XOBJECT);
        if (fl == null)
        {
            return;
        }

        foreach (KeyValuePair<PdfName, PdfObject> item in fl)
        {
            if (PdfReader.GetPdfObject(item.Value) is not PRStream f
                || PdfName.FORM.Equals(f.GetAsName(PdfName.SUBTYPE)) == false)
            {
                continue;
            }

            PdfPageCommandProcessor p = new(f);
            if (!ProcessCommands(p.Commands))
            {
                continue;
            }

            using MemoryStream ms = new();
            p.WritePdfCommands(ms);
            ms.Flush();
            f.SetData(ms.ToArray(), ms.Length > 32);
        }
    }

    #endregion
}
