using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using iTextSharp.text.exceptions;
using iTextSharp.text.pdf;
using MuPdfSharp;
using PDFPatcher.Common;
using PDFPatcher.Model;
using Matrix = iTextSharp.text.pdf.parser.Matrix;
using Rectangle = iTextSharp.text.Rectangle;

namespace PDFPatcher.Processor;

internal static class PdfHelper
{
    internal static readonly int[] CompoundTypes = { PdfObject.DICTIONARY, PdfObject.ARRAY, PdfObject.STREAM };

    private static readonly DualKeyDictionary<PdfName, string> __PdfNameMap;
    private static readonly Dictionary<string, byte[]> __PdfPasswordBox = new(StringComparer.OrdinalIgnoreCase);

    static PdfHelper() => __PdfNameMap = InitPdfNameMap();

    /// <summary>
    ///     Switch to enforce the encrypted document mode.
    /// </summary>
    /// <param name="unethicalreading">Whether to open forced read mode.</param>
    internal static void ToggleUnethicalMode(bool unethicalreading) => PdfReader.unethicalreading = unethicalreading;

    /// <summary>
    ///     Switch fault tolerance mode (ignore the error of the PDF document)。
    /// </summary>
    /// <param name="debugMode">Whether to open a fault-tolerant mode.</param>
    internal static void ToggleReaderDebugMode(bool debugMode) => PdfReader.debugmode = debugMode;

    /// <summary>
    ///     Open the PDF file, prompt to enter a password when there is a need.
    /// </summary>
    /// <param name="sourceFile">The PDF file that needs to be opened.</param>
    /// <param name="partial">Whether only the part of the file is opened.</param>
    /// <returns><see cref="PdfReader" /> example.</returns>
    internal static PdfReader OpenPdfFile(string sourceFile, bool partial, bool removeUnusedObjects)
    {
        __PdfPasswordBox.TryGetValue(sourceFile, out byte[] password);
        while (true)
        {
            try
            {
                if (File.Exists(sourceFile) == false)
                {
                    throw new FileNotFoundException(string.Concat("找不到文件：", sourceFile));
                }

                PdfReader r = partial
                    ? new PdfReader(new RandomAccessFileOrArray(sourceFile), password)
                    : new PdfReader(sourceFile, password);

                if (password is { Length: > 0 })
                {
                    __PdfPasswordBox[sourceFile] = password;
                }

                if (removeUnusedObjects)
                {
                    r.RemoveUnusedObjects();
                }

                return r;
            }
            catch (BadPasswordException)
            {
                PasswordEntryForm f = new(sourceFile);
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    throw new BadPasswordException("密码错误，没有权限打开 PDF 文件。");
                }

                password = Encoding.Default.GetBytes(f.Password);
            }
        }
    }

    internal static bool ConfirmUnethicalMode(this PdfReader pdf)
    {
        ToggleUnethicalMode(false);
        bool r = pdf.IsOpenedWithFullPermissions
                 || FormHelper.YesNoBox(Messages.UserRightRequired) == DialogResult.Yes;
        ToggleUnethicalMode(true);
        return r;
    }

    internal static MuDocument OpenMuDocument(string sourceFile)
    {
        __PdfPasswordBox.TryGetValue(sourceFile, out byte[] password);
        while (true)
        {
            MuDocument r = new(sourceFile, password != null ? Encoding.Default.GetString(password) : string.Empty);
            if (password is { Length: > 0 })
            {
                __PdfPasswordBox[sourceFile] = password;
            }

            if (!r.NeedsPassword)
            {
                return r;
            }

            PasswordEntryForm f = new(sourceFile);
            if (f.ShowDialog() == DialogResult.Cancel)
            {
                throw new BadPasswordException("密码错误，没有权限打开 PDF 文件。");
            }

            return r;
        }
    }

    private static DualKeyDictionary<PdfName, string> InitPdfNameMap()
    {
        DualKeyDictionary<PdfName, string> m = new()
        {
            { PdfName.PAGELAYOUT, Constants.PageLayout },
            { PdfName.PAGEMODE, Constants.PageMode },
            { PdfName.DIRECTION, Constants.ViewerPreferencesType.Direction },
            { PdfName.ST, Constants.PageLabelsAttributes.StartPage },
            { PdfName.P, Constants.PageLabelsAttributes.Prefix },
            { PdfName.S, Constants.PageLabelsAttributes.Style },
            { PdfName.XYZ, Constants.DestinationAttributes.ViewType.XYZ },
            { PdfName.FIT, Constants.DestinationAttributes.ViewType.Fit },
            { PdfName.FITB, Constants.DestinationAttributes.ViewType.FitB },
            { PdfName.FITBH, Constants.DestinationAttributes.ViewType.FitBH },
            { PdfName.FITBV, Constants.DestinationAttributes.ViewType.FitBV },
            { PdfName.FITH, Constants.DestinationAttributes.ViewType.FitH },
            { PdfName.FITR, Constants.DestinationAttributes.ViewType.FitR },
            { PdfName.FITV, Constants.DestinationAttributes.ViewType.FitV },
            { PdfName.GOTO, Constants.ActionType.Goto },
            { PdfName.GOTOR, Constants.ActionType.GotoR },
            { PdfName.LAUNCH, Constants.ActionType.Launch },
            { PdfName.URI, Constants.ActionType.Uri }
        };

        return m;
    }

    internal static string GetTypeName(int t) =>
        t switch
        {
            PdfObject.ARRAY => "array",
            PdfObject.BOOLEAN => "bool",
            PdfObject.DICTIONARY => "dictionary",
            PdfObject.INDIRECT => "reference",
            PdfObject.NAME => "name",
            PdfObject.NULL => "null",
            PdfObject.NUMBER => "number",
            PdfObject.STREAM => "stream",
            PdfObject.STRING => "string",
            _ => string.Empty
        };

    /// <summary>
    ///     获取友好的 PdfName 文本。
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    internal static string GetPdfFriendlyName(PdfName name) =>
        __PdfNameMap.ContainsKey(name) ? __PdfNameMap[name] : GetPdfNameString(name);

    /// <summary>
    ///     Analysis pdfname.
    /// </summary>
    /// <param name="friendlyName">Convert the resulting pdfname description text from <seealso cref="GetPdfFriendlyName" />.</param>
    /// <returns>PDFNAME corresponding to text description.</returns>
    internal static PdfName ResolvePdfName(string friendlyName) =>
        __PdfNameMap.ContainsValue(friendlyName)
            ? __PdfNameMap.GetKeyByValue(friendlyName)
            : new PdfName(friendlyName);

    internal static string DecodeKeyName(object name) =>
        name is PdfName ? PdfName.DecodeName(name.ToString()) : name.ToString();

    /// <summary>
    ///     Get the mapping relationship table of the PDF page reference to the number of pages.
    /// </summary>
    /// <param name="reader">Source PDF document.</param>
    /// <returns>The key for the <see cref="PdfIndirectReference" />, the value of the value is a dictionary.</returns>
    internal static Dictionary<int, int> GetPageRefMapper(this PdfReader reader)
    {
        int numPages = reader.NumberOfPages;
        Dictionary<int, int> pages = new(numPages);
        for (int k = 1; k <= numPages; ++k)
        {
            pages[reader.GetPageOrigRef(k).Number] = k;
            reader.ReleasePage(k);
        }

        return pages;
    }

    /// <summary>
    ///     Analytical shapes such as "D:20111021090818+08'00'" date format.
    /// </summary>
    /// <param name="date">Date format.</param>
    /// <returns></returns>
    internal static DateTimeOffset ParseDateTime(string date)
    {
        if (date == null
            || date.Length != 23 && date.Length != 16
            || date.StartsWith("D:") == false)
        {
            return DateTimeOffset.MinValue;
        }

        try
        {
            return new DateTimeOffset(
                date.Take(2, 4).ToInt32(), date.Take(6, 2).ToInt32(), date.Take(8, 2).ToInt32(),
                date.Take(10, 2).ToInt32(), date.Take(12, 2).ToInt32(), date.Take(14, 2).ToInt32(),
                new TimeSpan(date.Take(16, 3).ToInt32(), date.Take(20, 2).ToInt32(), 0)
            );
        }
        catch (Exception)
        {
            return DateTimeOffset.MinValue;
        }
    }

    //internal static int GetNumber (this PdfIndirectReference indirect) {
    //    PdfDictionary pdfObj = (PdfDictionary)PdfReader.GetPdfObjectRelease (indirect);
    //    if (pdfObj.Contains (PdfName.TYPE) && pdfObj.Get (PdfName.TYPE).Equals (PdfName.PAGES) && pdfObj.Contains (PdfName.KIDS)) {
    //        PdfArray kids = (PdfArray)pdfObj.Get (PdfName.KIDS);
    //        indirect = (PdfIndirectReference)kids.ArrayList[0];
    //    }
    //    return indirect.Number;
    //}

    /// <summary>
    ///     Get the decoded PDF name string.
    /// </summary>
    /// <param name="name">The PDF name that needs to decode.</param>
    /// <returns>Decoded PDF name string </returns>
    internal static string GetPdfNameString(PdfName name) => GetPdfNameString(name, PdfName.DefaultEncoding);

    /// <summary>
    ///     Get the decoded PDF name string.
    /// </summary>
    /// <param name="name">The PDF name that needs to decode.</param>
    /// <param name="encoding">Text coding for decoding.</param>
    /// <returns>Decoded PDF name string </returns>
    internal static string GetPdfNameString(PdfName name, Encoding encoding)
    {
        string s = name.ToString();
        int len = s.Length;
        byte[] buf = new byte[len];
        int l = 0;
        for (int k = 1; k < len; ++k)
        {
            char c = s[k];
            if (c == '#')
            {
                buf[l] = (byte)((PRTokeniser.GetHex(s[++k]) << 4) + PRTokeniser.GetHex(s[++k]));
            }
            else
            {
                buf[l] = (byte)c;
            }

            l++;
        }

        return (encoding ?? Encoding.Default).GetString(buf, 0, l);
    }

    /// <summary>
    ///     Get the border visible to the page.
    /// </summary>
    /// <param name="page">page dictionary.</param>
    /// <returns>The visible border of the page.</returns>
    internal static Rectangle GetPageVisibleRectangle(this PdfDictionary page)
    {
        if (page == null)
        {
            return null;
        }

        PdfArray box;
        float[] c = new float[4];
        if ((!page.Contains(PdfName.CROPBOX) || (box = page.GetAsArray(PdfName.CROPBOX)) == null || box.Size != 4) &&
            (!page.Contains(PdfName.MEDIABOX) || (box = page.GetAsArray(PdfName.MEDIABOX)) == null || box.Size != 4))
        {
            return null;
        }

        for (int i = 0; i < 4; i++)
        {
            c[i] = box.GetAsNumber(i).FloatValue;
        }

        Rectangle rect = new(c[0], c[1], c[2], c[3]);
        PdfNumber r = page.GetAsNumber(PdfName.ROTATE);
        return r != null ? new Rectangle(c[0], c[1], c[2], c[3], r.IntValue) : rect;
    }

    internal static void ClearPageLinks(this PdfReader r)
    {
        int pageCount = r.NumberOfPages + 1;
        for (int i = 1; i < pageCount; i++)
        {
            ClearPageLinks(r, i);
        }
    }

    internal static void ClearPageLinks(this PdfReader r, int pageNumber)
    {
        r.ResetReleasePage();
        PdfDictionary pageDic = r.GetPageN(pageNumber);
        PdfArray annots = (PdfArray)PdfReader.GetPdfObjectRelease(pageDic.Get(PdfName.ANNOTS));
        if (annots == null)
        {
            r.ReleasePage(pageNumber);
        }
        else
        {
            IList<PdfObject> arr = annots.ArrayList;
            for (int j = arr.Count - 1; j >= 0; j--)
            {
                PdfObject item = arr[j];
                PdfDictionary annot = (PdfDictionary)PdfReader.GetPdfObjectRelease(item);
                if (PdfName.LINK.Equals(annot.Get(PdfName.SUBTYPE)))
                {
                    arr.RemoveAt(j);
                }
            }

            if (annots.ArrayList.Count == 0)
            {
                pageDic.Remove(PdfName.ANNOTS);
            }
        }

        r.ResetReleasePage();
    }

    internal static string GetValidXmlString(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return string.Empty;
        }

        List<int> marks = new(3);
        int p = 0;
        foreach (char c in value)
        {
            switch (c)
            {
                case '\t':
                case '\r':
                case '\n':
                    break;
                default:
                    // invalid character
                    if (char.IsControl(c))
                    {
                        if (marks.Count == 0)
                        {
                            marks.Add(0);
                        }

                        marks.Add(p + 1);
                    }

                    break;
            }

            p++;
        }

        if (marks.Count > 0)
        {
            marks.Add(value.Length + 1);
        }

        if (marks.Count <= 1)
        {
            return value;
        }

        StringBuilder sb = new();
        for (int i = 1; i < marks.Count; i++)
        {
            if (i > 1)
            {
                sb.Append(' ');
            }

            sb.Append(value, marks[i - 1], marks[i] - 1 - marks[i - 1]);
        }

        return sb.ToString();
    }

    internal static string GetArrayString(PdfArray array) => GetArrayString(array.ArrayList);

    internal static string GetArrayString(ICollection<PdfObject> array)
    {
        StringBuilder sb = new();
        int k = 0;
        foreach (PdfObject item in array)
        {
            if (++k > 1)
            {
                sb.Append(' ');
            }

            switch (item.Type)
            {
                case PdfObject.ARRAY:
                    sb.Append('[');
                    sb.Append(GetArrayString(item as PdfArray));
                    sb.Append(']');
                    break;
                case PdfObject.DICTIONARY or PdfObject.STREAM:
                    sb.Append("<<...>>");
                    break;
                default:
                    sb.Append(item);
                    break;
            }
        }

        return sb.ToString();
    }

    internal static string GetNumericArrayString(PdfArray a, float unitFactor)
    {
        StringBuilder sb = new();
        for (int k = 0; k < a.ArrayList.Count; k++)
        {
            if (k != 0)
            {
                sb.Append(' ');
            }

            if (a.GetAsArray(k) != null)
            {
                sb.Append('[');
                sb.Append(a.GetAsArray(k));
                sb.Append(']');
            }
            else
            {
                PdfObject o = a.ArrayList[k];
                sb.Append(o.Type == PdfObject.NUMBER
                    ? UnitConverter.FromPoint(o.ToString(), unitFactor)
                    : o.ToString());
            }
        }

        return sb.ToString();
    }

    internal static void Put(this PdfDictionary dict, PdfName key, string value) => dict.Put(key, value.ToPdfString());

    internal static void Put(this PdfDictionary dict, PdfName key, int value) => dict.Put(key, new PdfNumber(value));

    internal static void Put(this PdfDictionary dict, PdfName key, double value) => dict.Put(key, new PdfNumber(value));

    internal static void Put(this PdfDictionary dict, PdfName key, float value) => dict.Put(key, new PdfNumber(value));

    internal static void Put(this PdfDictionary dict, PdfName key, bool value) => dict.Put(key, new PdfBoolean(value));

    internal static void Put(this PdfDictionary dict, PdfName key, float[] values) =>
        dict.Put(key, new PdfArray(values));

    internal static void Put(this PdfDictionary dict, PdfName key, int[] values) => dict.Put(key, new PdfArray(values));

    internal static PdfDictionary CreateDictionaryPath(this PdfDictionary source, params PdfName[] path)
    {
        foreach (PdfName item in path)
        {
            PdfDictionary d;
            if (source.Contains(item))
            {
                d = source.GetAsDict(item);

                source = d ?? throw new InvalidCastException(item + "不是 PdfDictionary。");
                continue;
            }

            d = new PdfDictionary();
            source.Put(item, d);
            source = d;
        }

        return source;
    }

    internal static bool PdfReferencesAreEqual(PdfIndirectReference r1, PdfIndirectReference r2)
    {
        if (r1 == null || r2 == null)
        {
            return false;
        }

        return r1.Number == r2.Number && r1.Generation == r2.Generation;
    }

    internal static int GetPageRotation(PdfDictionary page) =>
        NormalizeRotationNumber(page.TryGetInt32(PdfName.ROTATE, 0));

    internal static int NormalizeRotationNumber(int rotation)
    {
        switch (rotation)
        {
            case 0:
            case 90:
            case 180:
            case 270:
                return rotation;
            default:
                rotation %= 90;
                if (rotation < 0)
                {
                    rotation += 360;
                }

                return rotation / 90 * 90;
        }
    }

    internal static IList<PdfObject> GetObjectDirectOrFromContainerArray(this PdfDictionary d, PdfName name,
        int pdfObjectType)
    {
        List<PdfObject> results = new();

        PdfObject tmp = d.Get(name);
        if (tmp == null)
        {
        }
        else if (tmp.Type == pdfObjectType)
        {
            results.Add(tmp);
        }
        else if (tmp.Type == PdfObject.ARRAY)
        {
            PdfArray a = tmp as PdfArray;
            for (int i = 0; i < a.Size; i++)
            {
                tmp = a.GetDirectObject(i);
                if (tmp == null)
                {
                    continue;
                }

                if (tmp.Type == pdfObjectType)
                {
                    results.Add(tmp);
                }
            }
        }

        return results;
    }

    internal static string MatrixToString(Matrix ctm) =>
        string.Join(" ", ctm[0].ToText(), ctm[1].ToText(), ctm[3].ToText(), ctm[4].ToText(), ctm[6].ToText(),
            ctm[7].ToText());

    /// <summary>
    ///     Get a list of unused objects.
    /// </summary>
    /// <param name="pdf">The PDF document you need to check.</param>
    /// <param name="partial">Whether the PDF document is to be checked.</param>
    /// <returns>contains a list of unused object index values.</returns>
    internal static List<int> ListUnusedObjects(PdfReader pdf, bool partial)
    {
        bool[] hits = new bool[pdf.XrefSize];
        GetUnusedNode(pdf, partial, pdf.Trailer, hits);
        int i = 0;
        List<int> result = new();
        foreach (bool item in hits)
        {
            if (item == false && i > 0)
            {
                result.Add(i);
            }

            ++i;
        }

        return result;
    }

    internal static void SafeSetPageContent(this PdfReader pdf, int pageNumber, byte[] content)
    {
        PdfDictionary p = pdf.GetPageN(pageNumber);
        PdfObject c = p.GetDirectObject(PdfName.CONTENTS);
        if (c != null && c.IsArray())
        {
            PRStream cs = new(pdf, content);
            if (content.Length > 30)
            {
                cs.FlateCompress();
            }

            p.Put(PdfName.CONTENTS, pdf.AddPdfObject(cs));
        }
        else
        {
            pdf.SetPageContent(pageNumber, content);
        }
    }

    private static void GetUnusedNode(PdfReader pdf, bool partial, PdfObject obj, IList<bool> hits)
    {
        Stack<object> state = new();
        state.Push(obj);
        int oc = pdf.XrefSize;
        while (state.Count != 0)
        {
            object current = state.Pop();
            if (current == null)
            {
                continue;
            }

            List<PdfObject> ar = null;
            PdfDictionary dic = null;
            PdfName[] keys = null;
            object[] objs = null;
            int idx = 0;
            if (current is PdfObject pdfObject)
            {
                obj = pdfObject;
                switch (obj.Type)
                {
                    case PdfObject.DICTIONARY:
                    case PdfObject.STREAM:
                        dic = (PdfDictionary)obj;
                        keys = new PdfName[dic.Size];
                        dic.Keys.CopyTo(keys, 0);
                        break;
                    case PdfObject.ARRAY:
                        ar = ((PdfArray)obj).ArrayList;
                        break;
                    case PdfObject.INDIRECT:
                        PRIndirectReference refi = (PRIndirectReference)obj;
                        int num = refi.Number;
                        if (!hits[num])
                        {
                            hits[num] = true;
                            state.Push(PdfReader.GetPdfObjectRelease(refi));
                        }

                        continue;
                    default:
                        continue;
                }
            }
            else
            {
                objs = (object[])current;
                if (objs[0] is List<PdfObject>)
                {
                    ar = (List<PdfObject>)objs[0];
                    idx = (int)objs[1];
                }
                else
                {
                    keys = (PdfName[])objs[0];
                    dic = (PdfDictionary)objs[1];
                    idx = (int)objs[2];
                }
            }

            if (ar != null)
            {
                for (int k = idx; k < ar.Count; ++k)
                {
                    PdfObject v = ar[k];
                    if (v.IsIndirect())
                    {
                        int num = ((PRIndirectReference)v).Number;
                        if (num >= oc || !partial && pdf.GetPdfObjectRelease(num) == null)
                        {
                            ar[k] = PdfNull.PDFNULL;
                            continue;
                        }
                    }

                    if (objs == null)
                    {
                        state.Push(new object[] { ar, k + 1 });
                    }
                    else
                    {
                        objs[1] = k + 1;
                        state.Push(objs);
                    }

                    state.Push(v);
                    break;
                }
            }
            else
            {
                for (int k = idx; k < keys.Length; ++k)
                {
                    PdfName key = keys[k];
                    PdfObject v = dic.Get(key);
                    if (v.IsIndirect())
                    {
                        int num = ((PRIndirectReference)v).Number;
                        if (num >= oc || !partial && pdf.GetPdfObjectRelease(num) == null)
                        {
                            dic.Put(key, PdfNull.PDFNULL);
                            continue;
                        }
                    }

                    if (objs == null)
                    {
                        state.Push(new object[] { keys, dic, k + 1 });
                    }
                    else
                    {
                        objs[2] = k + 1;
                        state.Push(objs);
                    }

                    state.Push(v);
                    break;
                }
            }
        }
    }
}
