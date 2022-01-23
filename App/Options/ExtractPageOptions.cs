using System.Xml.Serialization;

namespace PDFPatcher;

public class ExtractPageOptions
{
    public ExtractPageOptions()
    {
        KeepBookmarks = true;
        KeepDocumentProperties = true;
        RemoveDocumentRestrictions = true;
        RemoveOrphanBookmarks = true;
        NumberFileNames = true;
        SeparateByPage = 1;
    }

    [XmlAttribute("Keep Document Properties")]
    public bool KeepDocumentProperties { get; set; }

    [XmlAttribute("Keep document bookmarks")]
    public bool KeepBookmarks { get; set; }

    [XmlAttribute("Remove invalid bookmarks")]
    public bool RemoveOrphanBookmarks { get; set; }

    [XmlAttribute("Remove document restrictions")]
    public bool RemoveDocumentRestrictions { get; set; }

    [XmlAttribute("Add number")] public bool NumberFileNames { get; set; }

    [XmlAttribute("Splitting Mode")] public int SeparatingMode { get; set; }

    [XmlAttribute("Split by page number")] public int SeparateByPage { get; set; }

    [XmlIgnore] public string PageRanges { get; set; }

    [XmlIgnore] public string ExcludePageRanges { get; set; }
}
