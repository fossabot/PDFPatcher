using System.Xml.Serialization;

namespace PDFPatcher.Model;

public enum WritingDirection
{
    [XmlEnum("Mixed")] Unknown,
    [XmlEnum("horizontal")] Horizontal,
    [XmlEnum("Vertical")] Vertical
}
