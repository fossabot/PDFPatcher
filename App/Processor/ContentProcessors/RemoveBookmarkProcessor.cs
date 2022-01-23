using iTextSharp.text.pdf;

namespace PDFPatcher.Processor;

internal sealed class RemoveBookmarkProcessor : IDocProcessor
{
    #region IDocProcessor member

    public string Name => "Delete navigation bookmarks";

    public void BeginProcess(DocProcessorContext context)
    {
    }

    public void EndProcess(DocProcessorContext context)
    {
    }

    public int EstimateWorkload(PdfReader pdf) => 1;

    public bool Process(DocProcessorContext context)
    {
        Tracker.IncrementProgress(1);
        OutlineManager.KillOutline(context.Pdf);
        return true;
    }

    #endregion
}
