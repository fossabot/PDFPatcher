using System.Collections.Generic;
using System.Xml.Serialization;
using PDFPatcher.Model;

namespace PDFPatcher;

public abstract class DocumentOptions
{
    protected DocumentOptions()
    {
        FullCompression = true;
        PageLabels = new List<PageLabel>();
        ViewerPreferences = new ViewerOptions();
        MetaData = new GeneralInfo();
    }

    [XmlElement("指定元数据")] public GeneralInfo MetaData { get; set; }

    [XmlElement("阅读器设置")] public ViewerOptions ViewerPreferences { get; set; }

    [XmlIgnore] internal List<PageLabel> PageLabels { get; }

    [XmlAttribute("压缩索引表和书签")] public bool FullCompression { get; set; }

    [XmlAttribute("统一页面方向")] public bool UnifyPageOrientation { get; set; }

    /// <summary>
    ///     Set the page to rotate in the unified page.The default rotates the horizontal page.
    /// </summary>
    [XmlAttribute("旋转源页面方向")]
    public bool RotateVerticalPages { get; set; }

    /// <summary>
    ///     Set the direction of the unified page to rotate the page.The default is rotated clockwise.
    /// </summary>
    [XmlAttribute("旋转方向")]
    public bool RotateAntiClockwise { get; set; }
}
