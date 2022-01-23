using iTextSharp.text.pdf;

namespace PDFPatcher.Processor;

internal sealed class CommonProcessor : IPageProcessor
{
    private readonly PatcherOptions _options;

    public CommonProcessor(PatcherOptions options) => _options = options;

    #region IPageProcessor member

    public string Name => "PDF General Processing";

    int IPageProcessor.EstimateWorkload(PdfReader pdf) => pdf.NumberOfPages;

    void IPageProcessor.BeginProcess(DocProcessorContext context)
    {
        if (context.OutputDocument == null)
        {
            PdfReader pdf = context.Pdf;
            PdfDictionary c = pdf.Catalog;
            if (_options.RemoveUsageRights)
            {
                Tracker.TraceMessage("Remove permission control.");
                pdf.RemoveUsageRights();
            }

            if (_options.RemoveXmlMetadata)
            {
                Tracker.TraceMessage("Remove XML metadata.");
                PdfReader.KillIndirect(c.Get(PdfName.METADATA));
                c.Remove(PdfName.METADATA);
            }

            if (_options.RemoveDocAutoActions)
            {
                Tracker.TraceMessage("Delete the automatic action when opening the document.");
                c.Remove(PdfName.OPENACTION);
                c.Remove(PdfName.AA);
            }

            if (_options.RemoveAnnotations)
            {
                Tracker.TraceMessage("Remove document comments.");
                pdf.Catalog.Remove(PdfName.ACROFORM);
            }
        }

        if (_options.RemovePageAutoActions)
        {
            Tracker.TraceMessage("Delete page automatic action.");
        }

        if (_options.RemovePageMetaData)
        {
            Tracker.TraceMessage("Remove page extension tag metadata attribute.");
        }
    }

    bool IPageProcessor.Process(PageProcessorContext context)
    {
        bool isTouched = false;
        PdfDictionary page = context.Page;
        if (_options.RemoveAnnotations && page.Contains(PdfName.ANNOTS))
        {
            page.Remove(PdfName.ANNOTS);
            isTouched = true;
        }

        if (_options.RemovePageAutoActions && page.Contains(PdfName.AA))
        {
            page.Remove(PdfName.AA);
            isTouched = true;
        }

        if (_options.RemovePageMetaData && page.Contains(PdfName.METADATA))
        {
            page.Remove(PdfName.METADATA);
            isTouched = true;
        }

        Tracker.IncrementProgress(1);
        return isTouched;
    }

    bool IPageProcessor.EndProcess(PdfReader pdf) => false;

    #endregion
}
