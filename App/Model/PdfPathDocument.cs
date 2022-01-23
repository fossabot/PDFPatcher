using System;
using System.Collections.Generic;
using System.IO;
using iTextSharp.text.pdf;
using PDFPatcher.Processor;

namespace PDFPatcher.Model;

internal sealed class PdfPathDocument : IHierarchicalObject<DocumentObject>
{
    private const int pageGroupNumber = 100;
    private readonly Dictionary<int, int> _pageMapper;
    private readonly DocumentObject[] _rootObjects;

    public PdfPathDocument(string pdfPath)
    {
        Document = PdfHelper.OpenPdfFile(pdfPath, AppContext.LoadPartialPdfFile, false);
        _pageMapper = Document.GetPageRefMapper();
        Trailer = new DocumentObject(this, null, "Trailer", Document.Trailer, PdfObjectType.Trailer)
        {
            IsKeyObject = true,
            Description = "Document root node",
            FriendlyValue = Path.GetFileNameWithoutExtension(pdfPath)
        };
        DocumentObject hiddenObjects = new(this, null, "Hidden object", null, PdfObjectType.Hidden);
        int l = Document.NumberOfPages;
        if (l > 301)
        {
            DocumentObject[] c = new DocumentObject[1 + (l + pageGroupNumber - 1) / pageGroupNumber + 1];
            c[0] = Trailer;
            for (int i = 1; i < c.Length - 1; i++)
            {
                int a = (i - 1) * pageGroupNumber + 1;
                int b = Math.Min(l, i * pageGroupNumber);
                c[i] = new DocumentObject(this, null, "Pages", null, PdfObjectType.Pages)
                {
                    IsKeyObject = true,
                    ExtensiveObject = a + "-" + b,
                    FriendlyValue = string.Concat("page ", a, " to ", b, " pages of ", l, " pages")
                };
            }

            c[c.Length - 1] = hiddenObjects;
            _rootObjects = c;
        }
        else
        {
            _rootObjects = new[]
            {
                Trailer,
                new(this, null, "Pages", null, PdfObjectType.Pages)
                {
                    IsKeyObject = true, FriendlyValue = "Total" + l + "Pages"
                },
                hiddenObjects
            };
        }
    }

    public PdfReader Document { get; }

    public DocumentObject Trailer { get; }

    public int PageCount => Document.NumberOfPages;

    #region IHierarchicalObject<DocumentObject> member

    ICollection<DocumentObject> IHierarchicalObject<DocumentObject>.Children
    {
        get
        {
            DocumentObject[] c = new DocumentObject[_rootObjects.Length];
            Array.Copy(_rootObjects, c, _rootObjects.Length);
            return c;
        }
    }

    #endregion

    public void Close() => Document.Close();

    public int GetPageNumber(PdfIndirectReference pdfRef)
    {
        _pageMapper.TryGetValue(pdfRef.Number, out int page);
        return page;
    }
}
