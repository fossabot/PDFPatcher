using System.ComponentModel;
using System.Xml.Serialization;
using PDFPatcher.Model;

namespace PDFPatcher;

public class MergerOptions : DocumentOptions
{
    public MergerOptions()
    {
        AutoBookmarkTitle = true;
        AutoMaskBWImages = true;
        AutoScaleDown = true;
        FullCompression = true;
        IgnoreLeadingNumbers = true;
        KeepBookmarks = true;
        NumericAwareSort = true;
        RemoveOrphanBookmarks = true;
        PageSettings = new PageBoxSettings();
        SubFolderBeforeFiles = true;
    }

    [XmlElement("页面布局")] public PageBoxSettings PageSettings { get; set; }

    /// <summary>Gets or specifies whether the image is automatically reduced to fit the page.</summary>
    [XmlAttribute("自动缩小")]
    [DefaultValue(true)]
    public bool AutoScaleDown { get; set; }

    /// <summary>Get or specify whether the image is automatically enlarged to fill the page.</summary>
    [XmlAttribute("自动放大")]
    [DefaultValue(false)]
    public bool AutoScaleUp { get; set; }

    /// <summary>
    ///     Gets the height of the above-down white.
    /// </summary>
    [XmlIgnore]
    public float ContentHeight
    {
        get
        {
            PageBoxSettings ps = PageSettings;
            return ps.PaperSize.Height - ps.Margins.Top - ps.Margins.Bottom;
        }
    }

    /// <summary>
    ///     Gets the width of the left and right leaves.
    /// </summary>
    [XmlIgnore]
    public float ContentWidth
    {
        get
        {
            PageBoxSettings ps = PageSettings;
            return ps.PaperSize.Width - ps.Margins.Left - ps.Margins.Right;
        }
    }

    [XmlAttribute("校正图片旋转角度")] public bool DeskewImages { get; set; }

    [XmlAttribute("优化黑白图片压缩算法")] public bool RecompressWithJbig2 { get; set; }

    //[XmlAttribute ("压缩比")]
    //[DefaultValue (-1)]
    //public int CompressionLevel { get; set; }

    /// <summary>Get or specify whether it is automatically set to a black and white picture (not available in the reader).</summary>
    [XmlAttribute("黑白图片自动透明")]
    public bool AutoMaskBWImages { get; set; }

    #region 文件列表选项

    /// <summary>Whether you get or specify whether you are sorted by value and text.</summary>
    [XmlAttribute("按数值排序文件")]
    [DefaultValue(true)]
    public bool NumericAwareSort { get; set; }

    /// <summary>Whether it is sorted by a seldera reader when getting or specifying a sort file.</summary>
    [XmlAttribute("按超星阅读器排序文件")]
    [DefaultValue(false)]
    public bool CajSort { get; set; }

    /// <summary>Get or specify whether the subdirectory is arranged in front of the file when you add a directory.</summary>
    [XmlAttribute("子目录排在文件前")]
    [DefaultValue(true)]
    public bool SubFolderBeforeFiles { get; set; }

    #endregion

    #region Automatically generate bookmark options

    /// <summary>Gets or specifies the leading value of ignoring the file name.</summary>
    [XmlAttribute("自动生成书签文本")]
    [DefaultValue(true)]
    public bool AutoBookmarkTitle { get; set; }

    /// <summary>Gets or specifies the leading value of ignoring the file name.</summary>
    [XmlAttribute("忽略前导数字")]
    [DefaultValue(true)]
    public bool IgnoreLeadingNumbers { get; set; }

    /// <summary>Get or specify whether to keep a bookmark for the PDF document.</summary>
    [XmlAttribute("保留书签")]
    [DefaultValue(true)]
    public bool KeepBookmarks { get; set; }

    /// <summary>Get or specify whether to delete a bookmark without a target (page failure).</summary>
    [XmlAttribute("删除失效书签")]
    [DefaultValue(true)]
    public bool RemoveOrphanBookmarks { get; set; }

    #endregion
}
