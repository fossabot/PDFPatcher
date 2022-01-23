using System;
using System.Text;
using System.Xml.Serialization;
using PDFPatcher.Common;

namespace PDFPatcher;

public class EncodingOptions
{
    private Encoding _bookmarkEncoding;

    private string _bookmarkEncodingName;

    private Encoding _docInfoEncoding;
    private string _docInfoEncodingName;

    private Encoding _fontNameEncoding;
    private string _fontNameEncodingName;

    private Encoding _textEncoding;
    private string _textEncodingName;

    public Encoding BookmarkEncoding
    {
        get
        {
            GetEncoding(_bookmarkEncodingName, ref _bookmarkEncoding);
            return _bookmarkEncoding;
        }
    }

    /// <summary>Gets or specifies the encoding used when reading a bookmark.</summary>
    [XmlAttribute("Bookmark text encoding")]
    public string BookmarkEncodingName
    {
        get => _bookmarkEncodingName;
        set => SetEncoding(ref _bookmarkEncodingName, ref _bookmarkEncoding, value);
    }

    public Encoding DocInfoEncoding
    {
        get
        {
            GetEncoding(_docInfoEncodingName, ref _docInfoEncoding);
            return _docInfoEncoding;
        }
    }

    /// <summary>Gets or specifies the encoding used when reading the document metadata.</summary>
    [XmlAttribute("Document metadata encoding")]
    public string DocInfoEncodingName
    {
        get => _docInfoEncodingName;
        set => SetEncoding(ref _docInfoEncodingName, ref _docInfoEncoding, value);
    }

    public Encoding TextEncoding
    {
        get
        {
            GetEncoding(_textEncodingName, ref _textEncoding);
            return _textEncoding;
        }
    }

    /// <summary>Gets or specifies the encoding used when reading text.</summary>
    [XmlAttribute("Content text encoding")]
    public string TextEncodingName
    {
        get => _textEncodingName;
        set => SetEncoding(ref _textEncodingName, ref _textEncoding, value);
    }

    public Encoding FontNameEncoding
    {
        get
        {
            GetEncoding(_fontNameEncodingName, ref _fontNameEncoding);
            return _fontNameEncoding;
        }
    }

    /// <summary>Gets or specifies the encoding used when reading text.</summary>
    [XmlAttribute("font name encoding")]
    public string FontNameEncodingName
    {
        get => _fontNameEncodingName;
        set => SetEncoding(ref _fontNameEncodingName, ref _fontNameEncoding, value);
    }

    public static void SetEncoding(ref string encodingName, ref Encoding encoding, string value)
    {
        if (encodingName == null)
        {
            throw new ArgumentNullException(nameof(encodingName));
        }

        if (encoding == null)
        {
            throw new ArgumentNullException(nameof(encoding));
        }

        if (value == null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        encoding = null;
        encodingName = value == Constants.Encoding.Automatic ? null : value;
    }

    private static void GetEncoding(string encodingName, ref Encoding encoding)
    {
        if (encoding == null && string.IsNullOrEmpty(encodingName) == false)
        {
            encoding = ValueHelper.MapValue(encodingName, Constants.Encoding.EncodingNames,
                Constants.Encoding.Encodings);
        }
    }
}
