using System.Collections.Generic;
using iTextSharp.text.pdf;
using PDFPatcher.Model;

namespace PDFPatcher.Processor;

internal sealed class FixContentProcessor : IPageProcessor
{
    private int _processedPageCount;

    private static bool ProcessCommands(IPdfPageCommandContainer container)
    {
        bool r = false;
        IList<PdfPageCommand> cl = container.Commands;
        int l = cl.Count;
        for (int i = 0; i < l; i++)
        {
            if (cl[i] is EnclosingCommand ec)
            {
                r |= ProcessCommands(ec);
            }
        }

        return r;
    }

    #region IPageProcessor member

    public string Name => "Fix and remove redundant content";

    public void BeginProcess(DocProcessorContext context) => _processedPageCount = 0;

    public bool EndProcess(PdfReader pdf)
    {
        Tracker.TraceMessage(Tracker.Category.Notice, Name + "Function:");
        Tracker.TraceMessage(" Deleted the redundant content of " + _processedPageCount + " page.");
        return false;
    }

    public int EstimateWorkload(PdfReader pdf) => pdf.NumberOfPages * 3;

    public bool Process(PageProcessorContext context)
    {
        Tracker.IncrementProgress(3);
        if (!ProcessCommands(context.PageCommands))
        {
            return false;
        }

        context.IsPageContentModified = true;
        _processedPageCount++;
        return true;
    }

    #endregion
}
