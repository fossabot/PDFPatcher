using System.Collections.Generic;
using iTextSharp.text.pdf;
using PDFPatcher.Common;
using PDFPatcher.Model;

namespace PDFPatcher.Processor;

internal sealed class RemoveFormProcessor : IPageProcessor
{
    private int _processedPageCount;

    private static bool ProcessCommands(IList<PdfPageCommand> parent, ICollection<PdfName> formNames)
    {
        bool r = false;
        for (int i = parent.Count - 1; i >= 0; i--)
        {
            PdfPageCommand cmd = parent[i];
            if (cmd is EnclosingCommand ec)
            {
                r |= ProcessCommands(ec.Commands, formNames);
            }

            if (cmd.Name.ToString() != "Do" || !cmd.HasOperand || !formNames.Contains(cmd.Operands[0] as PdfName))
            {
                continue;
            }

            parent.RemoveAt(i);
            r = true;
        }

        return r;
    }

    #region IPageProcessor member

    public string Name => "Delete form area";

    public void BeginProcess(DocProcessorContext context) => _processedPageCount = 0;

    public bool EndProcess(PdfReader pdf)
    {
        Tracker.TraceMessage(Tracker.Category.Notice, Name + "Function:");
        Tracker.TraceMessage(" Deleted the " + _processedPageCount + " page's form area.");
        return false;
    }

    public int EstimateWorkload(PdfReader pdf) => pdf.NumberOfPages * 3;

    public bool Process(PageProcessorContext context)
    {
        Tracker.IncrementProgress(3);
        IPdfPageCommandContainer p = context.PageCommands;
        bool r = false;
        HashSet<PdfName> fl = ProcessFormContent(context);
        if (fl.HasContent())
        {
            r = true;
            ProcessCommands(p.Commands, fl);
        }

        if (!r)
        {
            return false;
        }

        context.IsPageContentModified = true;
        _processedPageCount++;

        return true;
    }

    private static HashSet<PdfName> ProcessFormContent(PageProcessorContext context)
    {
        PdfDictionary fl = context.Page.Locate<PdfDictionary>(PdfName.RESOURCES, PdfName.XOBJECT);
        if (fl == null)
        {
            return null;
        }

        HashSet<PdfName> r = new();
        foreach (KeyValuePair<PdfName, PdfObject> item in fl)
        {
            if (PdfReader.GetPdfObject(item.Value) is not PRStream f
                || PdfName.FORM.Equals(f.GetAsName(PdfName.SUBTYPE)) == false)
            {
                continue;
            }

            r.Add(item.Key);
        }

        foreach (PdfName item in r)
        {
            fl.Remove(item);
        }

        if (fl.Size == 0)
        {
            context.Page.Locate<PdfDictionary>(PdfName.RESOURCES).Remove(PdfName.XOBJECT);
        }

        return r;
    }

    #endregion
}
