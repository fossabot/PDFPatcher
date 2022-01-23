using System.Xml.Serialization;
using PDFPatcher.Model;

namespace PDFPatcher;

public class OcrOptions
{
    public OcrOptions()
    {
        OcrLangID = 2052;
        DetectColumns = true;
    }

    //[XmlAttribute ("page range")]
    [XmlIgnore] public string PageRanges { get; set; }

    #region Optical character recognition option

    [XmlAttribute("Identify language")] public int OcrLangID { get; set; }

    [XmlAttribute("Rotation Correction")] public bool OrientPage { get; set; }

    [XmlAttribute("Stretch Correction")] public bool StretchPage { get; set; }

    [XmlIgnore] public float QuantitativeFactor { get; set; }

    [XmlAttribute("Typesetting")] public WritingDirection WritingDirection { get; set; }

    [XmlAttribute("Identify columns")] public bool DetectColumns { get; set; }

    [XmlAttribute("Directory Recognition Mode")]
    public bool DetectContentPunctuations { get; set; }

    [XmlAttribute("compress whitespace")] public bool CompressWhiteSpaces { get; set; }

    [XmlAttribute("Remove whitespace between Chinese characters")]
    public bool RemoveWhiteSpacesBetweenChineseCharacters { get; set; }

    [XmlAttribute("Preserve image color before recognition")]
    public bool PreserveColor { get; set; }

    [XmlAttribute("Export original recognition result")]
    public bool OutputOriginalOcrResult { get; set; }

    [XmlAttribute("Output recognition text on the screen")]
    public bool PrintOcrResult { get; set; }

    [XmlIgnore] public string SaveOcredImagePath { get; set; }

    #endregion
}
