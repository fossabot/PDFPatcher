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

    [XmlElement("Specify metadata")] public GeneralInfo MetaData { get; set; }

    [XmlElement("Reader settings")] public ViewerOptions ViewerPreferences { get; set; }

    [XmlIgnore] internal List<PageLabel> PageLabels { get; }

    [XmlAttribute("compress index table and bookmarks")]
    public bool FullCompression { get; set; }

    [XmlAttribute("Unify Page Orientation")]
    public bool UnifyPageOrientation { get; set; }

    /// <summary>
    ///     Set the page to rotate in the unified page. The default rotates the horizontal page.
    /// </summary>
    [XmlAttribute("Rotate source page orientation")]
    public bool RotateVerticalPages { get; set; }

    /// <summary>
    ///     Set the direction of the unified page to rotate the page. The default is rotated clockwise.
    /// </summary>
    [XmlAttribute("Rotation direction")]
    public bool RotateAntiClockwise { get; set; }
}
