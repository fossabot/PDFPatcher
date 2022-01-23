using System.Collections.Generic;
using System.Xml.Serialization;
using PDFPatcher.Model;
using PowerJson;

namespace PDFPatcher;

[XmlRoot("Documentation")]
public class PatcherOptions : DocumentOptions
{
    public PatcherOptions()
    {
        PageSettings = new List<PageBoxSettings>();
        FontSubstitutions = new List<FontSubstitution>();
        UnifiedPageSettings = new PageBoxSettings();
    }

    [XmlAttribute("Embedded Font")] public bool EmbedFonts { get; set; }

    [XmlAttribute("Remove text trailing whitespace")]
    public bool TrimTrailingWhiteSpace { get; set; }

    [XmlAttribute("Allow font substitution")]
    public bool EnableFontSubstitutions { get; set; }

    [XmlAttribute("Fix Content Stream")] public bool FixContents { get; set; }

    [XmlAttribute("Remove Annotations")] public bool RemoveAnnotations { get; set; }

    [XmlAttribute("Remove navigation bookmarks")]
    public bool RemoveBookmarks { get; set; }

    [XmlAttribute("Remove the page leading command")]
    [XmlIgnore]
    public int RemoveLeadingCommandCount { get; set; }

    [XmlAttribute("Remove page ending command")]
    [XmlIgnore]
    public int RemoveTrailingCommandCount { get; set; }

    [XmlAttribute("Remove usage restrictions")]
    public bool RemoveUsageRights { get; set; }

    [XmlAttribute("Delete document automatic action")]
    public bool RemoveDocAutoActions { get; set; }

    [XmlAttribute("Delete page auto action")]
    public bool RemovePageAutoActions { get; set; }

    [XmlAttribute("Remove Page Forms")] public bool RemovePageForms { get; set; }

    [XmlAttribute("Remove link annotation")]
    public bool RemovePageLinks { get; set; }

    [XmlAttribute("Remove page metadata")] public bool RemovePageMetaData { get; set; }

    [XmlAttribute("Remove page text")] public bool RemovePageTextBlocks { get; set; }

    [XmlAttribute("Remove page thumbnails")]
    public bool RemovePageThumbnails { get; set; }

    [XmlAttribute("Remove XML metadata")] public bool RemoveXmlMetadata { get; set; }

    [XmlAttribute("Optimize black and white image compression algorithm")]
    public bool RecompressWithJbig2 { get; set; }

    [XmlElement("page layout")] public PageBoxSettings UnifiedPageSettings { get; set; }

    [XmlArray("Page Setup")]
    [XmlArrayItem("Set item")]
    public List<PageBoxSettings> PageSettings { get; }

    [XmlArray("font substitution")]
    [XmlArrayItem("replacement item")]
    public List<FontSubstitution> FontSubstitutions { get; }
}

public class FontSubstitution
{
    [XmlAttribute("Original Font")] public string OriginalFont { get; set; }

    [XmlAttribute("new font")]
    [JsonField("SubstitutionFont")]
    public string Substitution { get; set; }

    [XmlAttribute("Original Characters")] public string OriginalCharacters { get; set; }

    [XmlAttribute("Substitute Characters")]
    public string SubstituteCharacters { get; set; }

    [XmlAttribute("Simplified and Traditional ChineseConversion")]
    public int TraditionalChineseConversion { get; set; }

    [XmlAttribute("Number Replacement")] public int NumericWidthConversion { get; set; }

    [XmlAttribute("Alphabetic Replacement")]
    public int AlphabeticWidthConversion { get; set; }

    [XmlAttribute("Symbol Substitution")] public int PunctuationWidthConversion { get; set; }
}
