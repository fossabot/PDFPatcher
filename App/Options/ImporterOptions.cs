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
    [XmlAttribute("导入文档属性")]
    public bool ImportDocProperties { get; set; }

    /// <summary>Get or specifies whether to import bookmarks.</summary>
    [XmlAttribute("导入文档书签")]
    public bool ImportBookmarks { get; set; }

    /// <summary>Get or specifies whether to import the connection within the page.</summary>
    [XmlAttribute("导入页面链接")]
    public bool ImportPageLinks { get; set; }

    /// <summary>Get or specifies whether to keep the connection within the page.</summary>
    [XmlAttribute("保留页面链接")]
    public bool KeepPageLinks { get; set; }

    /// <summary>Get or specify whether to import reader settings.</summary>
    [XmlAttribute("导入阅读器设置")]
    public bool ImportViewerPreferences { get; set; }

    /// <summary>Get or specifies whether to import the reading settings for the page.</summary>
    [XmlAttribute("导入页面设置")]
    public bool ImportPageSettings { get; set; }
}
