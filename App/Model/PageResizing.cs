using System.Xml.Serialization;

namespace PDFPatcher.Model;

public enum PageResizing
{
    [XmlEnum("keep unchanged")] None = 0,
    [XmlEnum("Change page size")] Resize = 1,
    [XmlEnum("stretch page content")] Scale = 2
}

public enum ResizingMode
{
    [XmlEnum("Relative Adjustment")] Relative = 0,
    [XmlEnum("Absolute adjustment")] Absolute = 1,

    [XmlEnum("Same as the specified page")]
    AsPage = 2
}
