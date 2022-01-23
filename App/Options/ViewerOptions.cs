using System.Xml.Serialization;
using PDFPatcher.Model;

namespace PDFPatcher;

public class ViewerOptions
{
    /// <summary>Gets or specifies the value of the initial view status.</summary>
    [XmlAttribute("初始状态")]
    public string InitialView { get; set; }

    /// <summary>Gets or specifies the value of the double page reading direction.</summary>
    [XmlAttribute("阅读方向")]
    public string Direction { get; set; }

    /// <summary>Gets or specifies the value of the reader initial mode.</summary>
    [XmlAttribute("初始模式")]
    public string InitialMode { get; set; }

    /// <summary>Get or specifies whether to delete the zoom ratio of the XYZ target, or convert Fit, Fit, into XYZ.</summary>
    [XmlAttribute("删除缩放比例")]
    public bool RemoveZoomRate { get; set; }

    [XmlAttribute("强制内部链接")] public bool ForceInternalLink { get; set; }

    /// <summary>Get or specifies whether to set the bookmark status to shut down.</summary>
    [XmlAttribute("书签状态")]
    public BookmarkStatus CollapseBookmark { get; set; }

    [XmlAttribute("指定阅读器设置")] public bool SpecifyViewerPreferences { get; set; }

    [XmlAttribute("隐藏菜单")] public bool HideMenu { get; set; }

    [XmlAttribute("隐藏工具栏")] public bool HideToolbar { get; set; }

    [XmlAttribute("隐藏程序界面")] public bool HideUI { get; set; }

    [XmlAttribute("适合窗口")] public bool FitWindow { get; set; }

    [XmlAttribute("窗口居中")] public bool CenterWindow { get; set; }

    [XmlAttribute("显示文档标题")] public bool DisplayDocTitle { get; set; }
}
