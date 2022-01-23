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

    [XmlElement("page layout")] public PageBoxSettings PageSettings { get; set; }

    /// <summary>Gets or specifies whether the image is automatically reduced to fit the page.</summary>
    [XmlAttribute("Auto-reduce")]
    [DefaultValue(true)]
    public bool AutoScaleDown { get; set; }

    /// <summary>Get or specify whether the image is automatically enlarged to fill the page.</summary>
    [XmlAttribute("Auto zoom")]
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

    [XmlAttribute("Correct image rotation angle")]
    public bool DeskewImages { get; set; }

    [XmlAttribute("Optimize black and white image compression algorithm")]
    public bool RecompressWithJbig2 { get; set; }

    //[XmlAttribute ("compression ratio")]
    //[DefaultValue (-1)]
    //public int CompressionLevel { get; set; }

    /// <summary>Get or specify whether it is automatically set to a black and white picture (not available in the reader).</summary>
    [XmlAttribute("Black and white pictures are automatically transparent")]
    public bool AutoMaskBWImages { get; set; }

    #region file list options

    /// <summary>Whether you get or specify whether you are sorted by value and text.</summary>
    [XmlAttribute("Sort files by value")]
    [DefaultValue(true)]
    public bool NumericAwareSort { get; set; }

    /// <summary>Whether it is sorted by a seldera reader when getting or specifying a sort file.</summary>
    [XmlAttribute("sort files by superstar reader")]
    [DefaultValue(false)]
    public bool CajSort { get; set; }

    /// <summary>Get or specify whether the subdirectory is arranged in front of the file when you add a directory.</summary>
    [XmlAttribute("Subdirectories come before files")]
    [DefaultValue(true)]
    public bool SubFolderBeforeFiles { get; set; }

    #endregion

    #region Automatically generate bookmark options

    /// <summary>Gets or specifies the leading value of ignoring the file name.</summary>
    [XmlAttribute("Automatically generate bookmark text")]
    [DefaultValue(true)]
    public bool AutoBookmarkTitle { get; set; }

    /// <summary>Gets or specifies the leading value of ignoring the file name.</summary>
    [XmlAttribute("Ignore leading numbers")]
    [DefaultValue(true)]
    public bool IgnoreLeadingNumbers { get; set; }

    /// <summary>Get or specify whether to keep a bookmark for the PDF document.</summary>
    [XmlAttribute("Keep bookmarks")]
    [DefaultValue(true)]
    public bool KeepBookmarks { get; set; }

    /// <summary>Get or specify whether to delete a bookmark without a target (page failure).</summary>
    [XmlAttribute("Delete invalid bookmark")]
    [DefaultValue(true)]
    public bool RemoveOrphanBookmarks { get; set; }

    #endregion
}
