using System.Xml.Serialization;
using PDFPatcher.Model;

namespace PDFPatcher;

public class ViewerOptions
{
    /// <summary>Gets or specifies the value of the initial view status.</summary>
    [XmlAttribute("initial state")]
    public string InitialView { get; set; }

    /// <summary>Gets or specifies the value of the double page reading direction.</summary>
    [XmlAttribute("reading direction")]
    public string Direction { get; set; }

    /// <summary>Gets or specifies the value of the reader initial mode.</summary>
    [XmlAttribute("Initial Mode")]
    public string InitialMode { get; set; }

    /// <summary>Get or specifies whether to delete the zoom ratio of the XYZ target, or convert Fit, Fit, into XYZ.</summary>
    [XmlAttribute("Remove scaling")]
    public bool RemoveZoomRate { get; set; }

    [XmlAttribute("Force Internal Link")] public bool ForceInternalLink { get; set; }

    /// <summary>Get or specifies whether to set the bookmark status to shut down.</summary>
    [XmlAttribute("Bookmark Status")]
    public BookmarkStatus CollapseBookmark { get; set; }

    [XmlAttribute("Specify Viewer Settings")]
    public bool SpecifyViewerPreferences { get; set; }

    [XmlAttribute("Hide Menu")] public bool HideMenu { get; set; }

    [XmlAttribute("Hide Toolbar")] public bool HideToolbar { get; set; }

    [XmlAttribute("Hide program interface")]
    public bool HideUI { get; set; }

    [XmlAttribute("Fit Window")] public bool FitWindow { get; set; }

    [XmlAttribute("Window Center")] public bool CenterWindow { get; set; }

    [XmlAttribute("Display document title")]
    public bool DisplayDocTitle { get; set; }
}
