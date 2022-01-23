using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using PDFPatcher.Model;
using PowerJson;

namespace PDFPatcher;

public class AutoBookmarkOptions
{
    public static readonly Regex NumericPattern = new("^[0-9]+$", RegexOptions.Compiled);

    public AutoBookmarkOptions()
    {
        AutoHierarchicalArrangement = true;
        CreateBookmarkForFirstPage = true;
        ExportTextCoordinates = false;
        IgnoreNumericTitle = false;
        IgnoreSingleCharacterTitle = false;
        MergeAdjacentTitles = true;
        MergeDifferentFontTitles = true;
        MergeDifferentSizeTitles = false;
        TitleThreshold = 13;
        YOffset = 1.0f;
        DisplayFontStatistics = true;
        MaxDistanceBetweenLines = 1.5f;
        DetectColumns = true;
    }

    /// <summary>
    ///     Whether or not to export the location information of the text.
    /// </summary>
    [XmlAttribute("导出文本位置信息")]
    public bool ExportTextCoordinates { get; set; }

    public class LevelAdjustmentOption
    {
        [XmlElement(AutoBookmarkCondition.MultiCondition.ThisName, typeof(AutoBookmarkCondition.MultiCondition))]
        [XmlElement(AutoBookmarkCondition.FontNameCondition.ThisName, typeof(AutoBookmarkCondition.FontNameCondition))]
        [XmlElement(AutoBookmarkCondition.TextSizeCondition.ThisName, typeof(AutoBookmarkCondition.TextSizeCondition))]
        [XmlElement(AutoBookmarkCondition.TextPositionCondition.ThisName,
            typeof(AutoBookmarkCondition.TextPositionCondition))]
        [XmlElement(AutoBookmarkCondition.PageRangeCondition.ThisName,
            typeof(AutoBookmarkCondition.PageRangeCondition))]
        [XmlElement(AutoBookmarkCondition.TextCondition.ThisName, typeof(AutoBookmarkCondition.TextCondition))]
        public AutoBookmarkCondition Condition { get; set; }

        [XmlAttribute("合并前筛选")] public bool FilterBeforeMergeTitle { get; set; }

        [XmlAttribute("相对级别调整")] public bool RelativeAdjustment { get; set; }

        /// <summary>
        ///     Title adjustment level.
        /// </summary>
        [XmlAttribute("调整级别")]
        public float AdjustmentLevel { get; set; }

        internal LevelAdjustmentOption Clone() =>
            new()
            {
                Condition = Condition.Clone() as AutoBookmarkCondition,
                RelativeAdjustment = RelativeAdjustment,
                AdjustmentLevel = AdjustmentLevel
            };
    }

    #region Identification option

    /// <summary>
    ///     Page size range.
    /// </summary>
    //[XmlAttribute ("页码范围")]
    [XmlIgnore]
    [JsonInclude(false)]
    public string PageRanges { get; set; }

    /// <summary>
    ///     minimum title font size.
    /// </summary>
    [XmlAttribute("最小标题尺寸")]
    public float TitleThreshold { get; set; }

    /// <summary>
    ///     The first line of each page is the title.
    /// </summary>
    [XmlAttribute("第一行为标题")]
    public bool FirstLineAsTitle { get; set; }

    /// <summary>
    ///     Ignore the title of only one character.
    /// </summary>
    [XmlAttribute("忽略单字符标题")]
    public bool IgnoreSingleCharacterTitle { get; set; }

    /// <summary>
    ///     Ignore only the title of only numbers.
    /// </summary>
    [XmlAttribute("忽略数字标题")]
    public bool IgnoreNumericTitle { get; set; }

    /// <summary>
    ///     The same level title is combined.
    /// </summary>
    [XmlAttribute("合并相邻标题")]
    public bool MergeAdjacentTitles { get; set; }

    /// <summary>
    ///     Whether to allow merged tabular titles.
    /// </summary>
    [XmlAttribute("合并不同尺寸标题")]
    public bool MergeDifferentSizeTitles { get; set; }

    [XmlAttribute("合并不同字体标题")] public bool MergeDifferentFontTitles { get; set; }

    [XmlAttribute("忽略重叠文本")] public bool IgnoreOverlappedText { get; set; }

    /// <summary>
    ///     Ignore the specified expression.
    /// </summary>
    [XmlArray("忽略表达式")]
    [XmlArrayItem("表达式")]
    public Collection<MatchPattern> IgnorePatterns { get; } = new();

    [XmlElement("级别调整")]
    [JsonField("级别调整")]
    public Collection<LevelAdjustmentOption> LevelAdjustment { get; } = new();

    [XmlAttribute("自动组织标题层次")] public bool AutoHierarchicalArrangement { get; set; }

    [XmlAttribute("列出字体统计信息")] public bool DisplayFontStatistics { get; set; }

    [XmlAttribute("列出所有字体")] public bool DisplayAllFonts { get; set; }

    [XmlAttribute("排版")] public WritingDirection WritingDirection { get; set; }

    [XmlAttribute("最大合并行距")] public float MaxDistanceBetweenLines { get; set; }

    [XmlAttribute("识别分栏")] public bool DetectColumns { get; set; }

    [XmlAttribute("为首页生成书签")] public bool CreateBookmarkForFirstPage { get; set; }

    /// <summary>
    ///     Home bookmark name.Specify this property to generate a bookmark for the first page.
    /// </summary>
    internal string FirstPageTitle { get; set; }

    #endregion

    #region Positioning option

    /// <summary>
    ///     Connect the page Y axis offset of the target.
    /// </summary>
    [XmlAttribute("Y轴偏移")]
    public float YOffset { get; set; }

    /// <summary>
    ///     Position the title level to the top of the page.
    /// </summary>
    [XmlAttribute("定位到页面顶端")]
    public int PageTopForLevel { get; set; }

    #endregion
}
