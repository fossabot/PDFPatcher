using System.Xml.Serialization;

namespace PDFPatcher.Model;

public enum BookmarkStatus
{
    [XmlEnum("keep unchanged")] AsIs,
    [XmlEnum("Close all")] CollapseAll,
    [XmlEnum("Open all")] ExpandAll,
    [XmlEnum("Open the first layer")] ExpandTop
}
