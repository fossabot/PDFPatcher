using System;
using System.Xml.Serialization;
using MuPdfSharp;
using PowerJson;

namespace PDFPatcher;

[XmlRoot("Processing options")]
public class ConfigurationSerialization
{
    [XmlAttribute("CheckUpdateDate")] public DateTime CheckUpdateDate { get; set; }

    [XmlAttribute("CheckUpdateInterval")]
    public int CheckUpdateInterval { get; set; } = 14;

    [XmlAttribute("SaveAppSettings")]
    public bool SaveAppSettings { get; set; }

    [XmlAttribute("PdfLoadMode")]
    public string PdfLoadMode { get; set; }

    [XmlElement("EncodingOptions")] public EncodingOptions Encodings { get; set; }

    /// <summary>Get export settings.</summary>
    [XmlElement("ExporterOptions")]
    public ExporterOptions ExporterOptions { get; set; }

    /// <summary>Get import settings.</summary>
    [XmlElement("ImporterOptions")]
    public ImporterOptions ImporterOptions { get; set; }

    /// <summary>Get the settings for generating a document.</summary>
    [XmlElement("MergerOptions")]
    public MergerOptions MergerOptions { get; set; }

    [XmlElement("PatcherOptions")] public PatcherOptions PatcherOptions { get; set; }

    [XmlElement("EditorOptions")] public PatcherOptions EditorOptions { get; set; }

    [XmlElement("AutoBookmarkOptions")]
    public AutoBookmarkOptions AutoBookmarkOptions { get; set; }

    [XmlElement("ImageExporterOptions")] public ImageExtracterOptions ImageExporterOptions { get; set; }

    [XmlElement("ImageRendererOptions")]
    public ImageRendererOptions ImageRendererOptions { get; set; }

    [XmlElement("ExtractPageOptions")] public ExtractPageOptions ExtractPageOptions { get; set; }

    [XmlElement("OcrOptions")]
    public OcrOptions OcrOptions { get; set; }

    [XmlElement("ToolbarOptions")] public ToolbarOptions ToolbarOptions { get; set; }

    [JsonField("Recent")]
    [JsonInclude]
    [JsonSerializable]
    internal AppContext.RecentItems Recent { get; set; }
}
