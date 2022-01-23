using System;
using System.Xml.Serialization;
using PDFPatcher.Common;
using E = System.Text.Encoding;

namespace PDFPatcher;

public class ExporterOptions
{
    private E _Encoding = E.Default;
    private string _EncodingName;

    /// <summary>Get or specify whether to export document properties.</summary>
    [XmlAttribute("Export document attribute")]
    public bool ExportDocProperties { get; set; } = true;

    /// <summary>Get or specify whether to export bookmarks.</summary>
    [XmlAttribute("Export document bookmarks")]
    public bool ExportBookmarks { get; set; } = true;

    /// <summary>Gets or specifies whether the connection within the page is exported.</summary>
    [XmlAttribute("Export page link")]
    public bool ExtractPageLinks { get; set; } = true;

    /// <summary>Get or specify whether to export reader settings.</summary>
    [XmlAttribute("Export reader settings")]
    public bool ExportViewerPreferences { get; set; } = true;

    /// <summary>Get or specify whether to export the reading settings for the page.</summary>
    [XmlAttribute("Export page settings")]
    public bool ExtractPageSettings { get; set; } = true;

    /// <summary>Get or specify whether to export document catalog information.</summary>
    [XmlAttribute("Export catalog information")]
    public bool ExportCatalog { get; set; }

    /// <summary>Get or specify whether to export page content information.</summary>
    [XmlAttribute("Export page content")]
    public bool ExtractPageContent { get; set; }

    /// <summary>
    ///     Get or specify the range range that needs to be exported.The page range can be used "-" to indicate the start
    ///     page code, if there are multiple page numbers, available ";", "," or "" (space), such as "1; 4-15; 2 56",
    ///     indicating that the first timePages, 4 to 15, page 2 and page 56.
    /// </summary>
    [XmlAttribute("Export page number range")]
    public string ExtractPageRange { get; set; }

    /// <summary>Gets or specifies the value of the page dictionary.</summary>
    [XmlAttribute("Export page dictionary")]
    public bool ExtractPageDictionary { get; set; }

    /// <summary>Get or specify whether the image in the export page is a separate file.</summary>
    [XmlAttribute("Export Image")]
    public bool ExtractImages { get; set; }

    /// <summary>Get or specify whether the text in the export page is decoded.</summary>
    [XmlAttribute("Export decoded text")]
    public bool ExportDecodedText { get; set; }

    /// <summary>Get or specify whether to decode the export page instruction.</summary>
    [XmlAttribute("Export Command Operator")]
    public bool ExportContentOperators { get; set; }

    /// <summary>Get or specify the number of bytes that export binary streams.</summary>
    [XmlAttribute("Export binary stream")]
    public int ExportBinaryStream { get; set; } = 200;

    /// <summary>Get or specify whether you pars the named location before the export.</summary>
    [XmlAttribute("Parse Named Location")]
    public bool ConsolidateNamedDestinations { get; set; }

    /// <summary>Get options for exporting images.</summary>
    [XmlIgnore]
    public ImageExtracterOptions Images { get; } = new();

    [XmlElement("Export size unit")] public UnitConverter UnitConverter { get; set; } = new();

    /// <summary>Gets or specifies the encoding used when exporting files.</summary>
    [XmlAttribute("text encoding")]
    public string Encoding
    {
        get => _Encoding.EncodingName == E.Default.EncodingName ? Constants.Encoding.SystemDefault : _EncodingName;
        set
        {
            if (string.IsNullOrEmpty(value) || value == Constants.Encoding.SystemDefault)
            {
                _Encoding = E.Default;
            }
            else
            {
                try
                {
                    _Encoding = E.GetEncoding(value);
                    _EncodingName = value;
                }
                catch (Exception)
                {
                    _EncodingName = Constants.Encoding.SystemDefault;
                }
            }
        }
    }

    public E GetEncoding() => _Encoding;
}
