using iTextSharp.text.pdf;

namespace PDFPatcher.Processor;

internal interface IDocProcessor : IProcessor
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
    void BeginProcess(DocProcessorContext context);

    /// <summary>
    ///     Process the incoming document.
    /// </summary>
    /// <param name="context">
    ///     <see cref="docprocessorContext" />
    /// </param>
    /// of incoming document
    /// <returns>Returns true after changing the document.</returns>
    bool Process(DocProcessorContext context);

    /// <summary>
    ///     Call after processing the page.
    /// </summary>
    /// <param name="context">
    ///     <see cref="docprocessorContext" />
    /// </param>
    /// of incoming document
    void EndProcess(DocProcessorContext context);
}
