using System.Collections.Generic;
using iTextSharp.text.pdf;
using PDFPatcher.Model;

namespace PDFPatcher.Processor;

internal sealed class RemoveWrappedCommandProcessor : IPageProcessor
{
    private readonly int _RemoveLeading, _RemoveTrailing;
    private int _processedPageCount;

    public RemoveWrappedCommandProcessor(int removeLeadingCommandCount, int removeTrailingCommandCount)
    {
        _RemoveLeading = removeLeadingCommandCount;
        _RemoveTrailing = removeTrailingCommandCount;
    }

    private bool ProcessCommands(IList<PdfPageCommand> parent)
    {
        bool r = false;
        if (_RemoveLeading > 0)
        {
            for (int i = _RemoveLeading - 1; i >= 0 && parent.Count > 0; i--)
            {
                parent.RemoveAt(i);
            }

            r = true;
        }

        if (_RemoveTrailing <= 0)
        {
            return r;
        }

        {
            for (int i = _RemoveTrailing - 1; i >= 0 && parent.Count > 0; i--)
            {
                parent.RemoveAt(parent.Count - 1);
            }
        }

        return true;
    }

    #region IPageProcessor member

    public string Name => "Delete page start or end command";

    public void BeginProcess(DocProcessorContext context) => _processedPageCount = 0;

    public bool EndProcess(PdfReader pdf)
    {
        Tracker.TraceMessage(Tracker.Category.Notice, Name + "Function:");
        Tracker.TraceMessage(" Deleted the " + _processedPageCount + " page instruction.");
        return false;
    }

    public int EstimateWorkload(PdfReader pdf) => pdf.NumberOfPages * 3;

    public bool Process(PageProcessorContext context)
    {
        Tracker.IncrementProgress(3);
        IPdfPageCommandContainer p = context.PageCommands;
        bool r = ProcessCommands(p.Commands);
        if (!r)
        {
            return false;
        }

        context.IsPageContentModified = true;
        _processedPageCount++;

        return true;
    }

    #endregion
}
