using System;
using System.Drawing;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using PDFPatcher.Common;

namespace PDFPatcher.Model;

/// <summary>
///     Bookmark settings used in the merged file function.
/// </summary>
public class BookmarkSettings : ICloneable, IXmlSerializable
{
    public BookmarkSettings() => ForeColor = Color.Transparent;

    public BookmarkSettings(string title) => Title = title;

    public BookmarkSettings(BookmarkElement element)
    {
        Title = element.Title;
        IsBold = (element.TextStyle & FontStyle.Bold) == FontStyle.Bold;
        IsItalic = (element.TextStyle & FontStyle.Italic) == FontStyle.Italic;
        IsOpened = element.IsOpen;
        ForeColor = element.ForeColor;
    }

    public string Title { get; set; }
    public bool IsBold { get; set; }
    public bool IsItalic { get; set; }
    public bool IsOpened { get; set; }
    public Color ForeColor { get; set; }

    #region ICloneable member

    object ICloneable.Clone() => Clone();

    #endregion

    public BookmarkSettings Clone() => (BookmarkSettings)MemberwiseClone();

    #region IXmlSerializable member

    public XmlSchema GetSchema() => null;

    public void ReadXml(XmlReader reader)
    {
        Title = reader.GetAttribute("title");
        IsBold = reader.GetValue("bold", false);
        IsItalic = reader.GetValue("italic", false);
        IsOpened = reader.GetValue("opened", false);
        ForeColor = Color.FromArgb(reader.GetValue("color", Color.Empty.ToArgb()));
    }

    public void WriteXml(XmlWriter writer)
    {
        writer.WriteStartElement("bookmark");
        writer.WriteAttributeString("title", Title);
        writer.WriteValue("bold", IsBold, false);
        writer.WriteValue("italic", IsItalic, false);
        writer.WriteValue("opened", IsOpened, false);
        writer.WriteValue("color", ForeColor.ToArgb(), Color.Empty.ToArgb());
        writer.WriteEndElement();
    }

    #endregion
}
