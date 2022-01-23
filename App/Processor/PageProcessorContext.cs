using iTextSharp.text.pdf;
using PDFPatcher.Model;

namespace PDFPatcher.Processor;

internal sealed class PageProcessorContext
{
    private PdfDictionary _Page;

    private PdfPageCommandProcessor _processor;

    public PageProcessorContext(PdfReader pdf, int pageNumber)
    {
        Pdf = pdf;
        PageNumber = pageNumber;
    }

    /// <summary>PDF document being processed.</summary>
    public PdfReader Pdf { get; }

    /// <summary>Page number being processed.</summary>
    public int PageNumber { get; }

    /// <summary>The tag page content has been changed.</summary>
    public bool IsPageContentModified { get; set; }

    /// <summary>Get the page being processed.</summary>
    public PdfDictionary Page => _Page ??= Pdf.GetPageN(PageNumber);

    /// <summary>Get the page instruction collection being processed.</summary>
    public IPdfPageCommandContainer PageCommands
    {
        get
        {
            if (_processor != null)
            {
                return _processor;
            }

            _processor = new PdfPageCommandProcessor();
            PdfDictionary resources = Page.Locate<PdfDictionary>(PdfName.RESOURCES);
            _processor.ProcessContent(PdfReader.GetPageContent(Page), resources);

            return _processor;
        }
    }

    /// <summary>Write the page instruction to the currently processed page.</summary>
    internal void WritePageCommands() => _processor.WritePdfCommands(Pdf, PageNumber);

    //internal void UpdateContentBytes () {
    //    if (_ContentBytes == null) {
    //        return;
    //    }
    //    Pdf.SafeSetPageContent (PageNumber, _ContentBytes);
    //    Pdf.ResetReleasePage ();
    //}
}
