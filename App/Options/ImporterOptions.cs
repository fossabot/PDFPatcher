using System.Xml.Serialization;

namespace PDFPatcher;

public class ImporterOptions
{
    public ImporterOptions()
    {
        ImportDocProperties = true;
        ImportBookmarks = true;
        ImportPageLinks = true;
        ImportViewerPreferences = true;
        ImportPageSettings = true;
    }

    /// <summary>Get or specify whether to import document property information.</summary>
    [XmlAttribute("Import document attributes")]
    public bool ImportDocProperties { get; set; }

    /// <summary>Get or specifies whether to import bookmarks.</summary>
    [XmlAttribute("Import document bookmarks")]
    public bool ImportBookmarks { get; set; }

    /// <summary>Get or specifies whether to import the connection within the page.</summary>
    [XmlAttribute("Import page link")]
    public bool ImportPageLinks { get; set; }

    /// <summary>Get or specifies whether to keep the connection within the page.</summary>
    [XmlAttribute("Keep page link")]
    public bool KeepPageLinks { get; set; }

    /// <summary>Get or specify whether to import reader settings.</summary>
    [XmlAttribute("Import reader settings")]
    public bool ImportViewerPreferences { get; set; }

    /// <summary>Get or specifies whether to import the reading settings for the page.</summary>
    [XmlAttribute("Import page settings")]
    public bool ImportPageSettings { get; set; }
}
