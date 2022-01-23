using iTextSharp.text.pdf;

namespace PDFPatcher.Processor;

internal sealed class RemoveThumbnailProcessor : IPageProcessor
{
    private int _processedItemCount;

    #region IPageProcessor member

    public string Name => "Delete Thumbnail";

    public void BeginProcess(DocProcessorContext context) => _processedItemCount = 0;

    public bool EndProcess(PdfReader pdf)
    {
        Tracker.TraceMessage(Tracker.Category.Notice, Name + "Function:");
        Tracker.TraceMessage(" Deleted " + _processedItemCount + " thumbnails.");
        return false;
    }

    public int EstimateWorkload(PdfReader pdf) => pdf.NumberOfPages;

    public bool Process(PageProcessorContext context)
    {
        Tracker.IncrementProgress(1);
        if (context.Page.Contains(PdfName.THUMB) == false)
        {
            return false;
        }

        context.Page.Remove(PdfName.THUMB);
        _processedItemCount++;
        return true;
    }

    #endregion
}
