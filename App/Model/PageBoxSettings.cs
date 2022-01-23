using System.ComponentModel;
using System.Xml.Serialization;

namespace PDFPatcher.Model;

public class PageBoxSettings
{
    public PageBoxSettings()
    {
        PaperSize = new PaperSize(PaperSize.AsPageSize, 0, 0);
        Margins = new Margins();
        AutoRotation = true;
    }

    [XmlElement("border adjustment value")]
    public Margins Margins { get; set; }

    [XmlElement("Specify size")] public PaperSize PaperSize { get; set; }

    [XmlAttribute("Page Range")] public string PageRanges { get; set; }

    [XmlAttribute("Page Filter")] public PageFilterFlag Filter { get; set; }

    /// <summary>Gets or specifies whether to automatically rotate the page to fit the image aspect ratio. </summary>
    [XmlAttribute("Auto-rotate")]
    [DefaultValue(true)]
    public bool AutoRotation { get; set; }

    [XmlAttribute("Rotation Angle")] public int Rotation { get; set; }

    [XmlAttribute("Stretch Content")] public bool ScaleContent { get; set; }

    [XmlAttribute("Horizontal Alignment")] public HorizontalAlignment HorizontalAlign { get; set; }

    [XmlAttribute("Vertical Alignment")] public VerticalAlignment VerticalAlign { get; set; }

    [XmlAttribute("Base Page")] public int BasePage { get; set; }

    public bool NeedResize => PaperSize.SpecialSize != SpecialPaperSize.AsPageSize;
    public bool NeedAdjustMargins => Margins.IsEmpty == false;
}

public enum VerticalAlignment
{
    Middle,
    Top,
    Bottom
}

public enum HorizontalAlignment
{
    Center,
    Left,
    Right
}
