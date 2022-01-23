using System.Xml.Serialization;
using PowerJson;

namespace PDFPatcher;

public class ImageExtracterOptions
{
    public ImageExtracterOptions()
    {
        AutoOutputFolder = true;
        FileMask = "0000";
        MergeJpgToPng = true;
    }

    [XmlAttribute("Automatically specify the output location")]
    public bool AutoOutputFolder { get; set; }

    [XmlAttribute("Avoid repeated export of images")]
    public bool SkipRedundantImages { get; set; }

    /// <summary>Gets or specifies whether to merge images of the same page and the same width. </summary>
    [XmlAttribute("Merge pictures")]
    public bool MergeImages { get; set; }

    /// <summary>Gets or specifies whether to save the merged JPEG image as a lossless PNG image. </summary>
    [XmlAttribute("Merge JPG images into PNG")]
    public bool MergeJpgToPng { get; set; }

    /// <summary>Gets or specifies whether to flip the exported PNG or TIFF image vertically. </summary>
    [XmlAttribute("Vertical flip picture")]
    public bool VerticalFlipImages { get; set; }

    /// <summary>Gets or specifies whether to invert the color of the black and white image. </summary>
    [XmlAttribute("Invert black and white picture color")]
    public bool InvertBlackAndWhiteImages { get; set; }

    [XmlAttribute("Export black and white images as PNG")]
    public bool MonoPng { get; set; }

    /// <summary>Gets or specifies whether to export the image in the annotation. </summary>
    [XmlAttribute("Export annotation image")]
    public bool ExtractAnnotationImages { get; set; }

    [XmlAttribute("Minimum Height")] public int MinHeight { get; set; }

    [XmlAttribute("Minimum Width")] public int MinWidth { get; set; }

    /// <summary>Get or specify the directory path saved by the export page image.</summary>
    [XmlAttribute("Export Path")]
    public string OutputPath { get; set; }

    /// <summary>Gets or specifies the name mask of the export file.</summary>
    [XmlAttribute("file name mask")]
    public string FileMask { get; set; }

    [XmlAttribute("Export Mask")] public bool ExtractSoftMask { get; set; }

    [XmlAttribute("Invert Mask")] public bool InvertSoftMask { get; set; }

    [XmlIgnore] [JsonInclude(false)] public string PageRange { get; set; }
}
