using iTextSharp.text.pdf;

namespace PDFPatcher.Processor;

internal interface IPageProcessor : IProcessor
{
    /// <summary>
    ///     Estimate the workload.
    /// </summary>
    /// <param name="pdf">The document that needs to be processed.</param>
    /// <returns>Integer workload (for displaying progress bar).</returns>
    int EstimateWorkload(PdfReader pdf);

    /// <summary>
    ///     Call the processor in front of the processing page.
    /// </summary>
    /// <param name="context">
    ///     <see cref="docprocessorContext" />
    /// </param>
    /// of incoming document
    /// <returns>Returns true after changing the document.</returns>
    void BeginProcess(DocProcessorContext context);

    /// <summary>
    ///     Process the incoming page.
    /// </summary>
    /// <param name="context">Contains <see cref="pageProcessorContext" /></param>
    /// of the incoming page
    /// <returns>Returns True after changing the page.</returns>
    bool Process(PageProcessorContext context);

    /// <summary>
    ///     Complete the operation of the processing document, is called after completing all the pages.
    /// </summary>
    /// <param name="pdf">The document that needs to be processed.</param>
    /// <returns>Returns true after changing the document.</returns>
    bool EndProcess(PdfReader pdf);
}
