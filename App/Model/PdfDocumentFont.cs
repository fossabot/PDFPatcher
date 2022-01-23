using System.Linq;
using iTextSharp.text.pdf;

namespace PDFPatcher.Model;

internal class PdfDocumentFont
{
    /// <summary>
    ///     Delete the subset prefix of the font name.
    /// </summary>
    /// <param name="name">The font name.</param>
    internal static string RemoveSubsetPrefix(string name) =>
        name.Length > 7 && name[6] == '+' ? name.Substring(7) : name;

    internal static bool HasEmbeddedFont(PdfDictionary font)
    {
        PdfObject df = font.Locate<PdfObject>(true, PdfName.DESCENDANTFONTS);
        if (df == null)
        {
            return IsEmbeddedFont(font);
        }

        if (df.Type == PdfObject.ARRAY)
        {
            return (df as PdfArray).ArrayList.All(item =>
                IsEmbeddedFont(PdfReader.GetPdfObjectRelease(item) as PdfDictionary));
        }

        df = PdfReader.GetPdfObjectRelease(df);
        return df.Type == PdfObject.DICTIONARY && IsEmbeddedFont(df as PdfDictionary);
    }

    private static bool IsEmbeddedFont(PdfDictionary font)
    {
        PdfDictionary fd = font.Locate<PdfDictionary>(true, PdfName.FONTDESCRIPTOR);
        if (fd == null)
        {
            return false;
        }

        return fd.Contains(PdfName.FONTFILE) || fd.Contains(PdfName.FONTFILE2) || fd.Contains(PdfName.FONTFILE3);
    }
}
