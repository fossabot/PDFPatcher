using System.Drawing;
using System.Xml.Serialization;

namespace MuPdfSharp;

public class ImageRendererOptions
{
    private float _Dpi = 72f;

    public ImageRendererOptions()
    {
        AutoOutputFolder = true;
        FileMask = "0000";
        ScaleRatio = 1f;
        Gamma = 1.0f;
        TintColor = Color.Transparent;
    }

    [XmlAttribute("Automatically specify the output location")]
    public bool AutoOutputFolder { get; set; }

    /// <summary>Get or specify the format of the exported image.</summary>
    [XmlAttribute("image format")]
    public ImageFormat FileFormat { get; set; }

    public string FileFormatExtension =>
        FileFormat switch
        {
            ImageFormat.Jpeg => ".jpg",
            ImageFormat.Tiff => ".tif",
            _ => ".png"
        };

    /// <summary>Gets or specifies whether to flip the exported image.</summary>
    [XmlAttribute("Vertical flip image")]
    public bool VerticalFlipImages { get; set; }

    /// <summary>Gets or specifies the image that is horizontally flipped.</summary>
    [XmlAttribute("Flip image horizontally")]
    public bool HorizontalFlipImages { get; set; }

    /// <summary>Get or specify the color of the exported image.</summary>
    [XmlAttribute("Image Color")]
    public ColorSpace ColorSpace { get; set; }

    /// <summary>Gets or specifies whether to reverse the color of the image.</summary>
    [XmlAttribute("Invert image color")]
    public bool InvertColor { get; set; }

    [XmlAttribute("JPEG quality")] public int JpegQuality { get; set; }

    /// <summary>Gets or specifies the angle of rotating images.</summary>
    [XmlAttribute("Rotation Angle")]
    public int Rotation { get; set; }

    [XmlAttribute("image width")] public int ImageWidth { get; set; }

    [XmlAttribute("Image Ratio")] public float ScaleRatio { get; set; }

    [XmlAttribute("resolution")]
    public float Dpi
    {
        get => _Dpi;
        set => _Dpi = value > 0 ? value : 72f;
    }

    [XmlAttribute("size mode")] public bool UseSpecificWidth { get; set; }

    /// <summary>Get or specify the directory path saved by the export page image.</summary>
    [XmlAttribute("Export Path")]
    public string ExtractImagePath { get; set; }

    /// <summary>Gets or specifies the name mask of the export file.</summary>
    [XmlAttribute("file name mask")]
    public string FileMask { get; set; }

    [XmlIgnore] public string ExtractPageRange { get; set; }

    [XmlAttribute("Fit Area")] public bool FitArea { get; set; }

    [XmlAttribute("Hide Annotations")] public bool HideAnnotations { get; set; }

    [XmlAttribute("Reduce color")] public bool Quantize { get; set; }

    [XmlAttribute("Gamma Correction")] public float Gamma { get; set; }

    [XmlAttribute("dyeing")]
    public int Tint
    {
        get => TintColor.ToArgb();
        set => TintColor = Color.FromArgb(value);
    }

    [XmlIgnore] public Color TintColor { get; set; }

    internal bool LowQuality { get; set; }
}
