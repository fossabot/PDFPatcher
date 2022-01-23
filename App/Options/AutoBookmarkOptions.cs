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
    [XmlAttribute("Export text location information")]
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

        [XmlAttribute("Filter before merging")]
        public bool FilterBeforeMergeTitle { get; set; }

        [XmlAttribute("Relative Level Adjustment")]
        public bool RelativeAdjustment { get; set; }

        /// <summary>
        ///     Title adjustment level.
        /// </summary>
        [XmlAttribute("adjustment level")]
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
    //[XmlAttribute ("page range")]
    [XmlIgnore]
    [JsonInclude(false)]
    public string PageRanges { get; set; }

    /// <summary>
    ///     minimum title font size.
    /// </summary>
    [XmlAttribute("Minimum title size")]
    public float TitleThreshold { get; set; }

    /// <summary>
    ///     The first line of each page is the title.
    /// </summary>
    [XmlAttribute("First line title")]
    public bool FirstLineAsTitle { get; set; }

    /// <summary>
    ///     Ignore the title of only one character.
    /// </summary>
    [XmlAttribute("Ignore single-character title")]
    public bool IgnoreSingleCharacterTitle { get; set; }

    /// <summary>
    ///     Ignore only the title of only numbers.
    /// </summary>
    [XmlAttribute("Ignore numeric headers")]
    public bool IgnoreNumericTitle { get; set; }

    /// <summary>
    ///     The same level title is combined.
    /// </summary>
    [XmlAttribute("Merge adjacent titles")]
    public bool MergeAdjacentTitles { get; set; }

    /// <summary>
    ///     Whether to allow merged tabular titles.
    /// </summary>
    [XmlAttribute("Merge titles of different sizes")]
    public bool MergeDifferentSizeTitles { get; set; }

    [XmlAttribute("Merge different font titles")]
    public bool MergeDifferentFontTitles { get; set; }

    [XmlAttribute("Ignore Overlapped Text")]
    public bool IgnoreOverlappedText { get; set; }

    /// <summary>
    ///     Ignore the specified expression.
    /// </summary>
    [XmlArray("Ignore expression")]
    [XmlArrayItem("expression")]
    public Collection<MatchPattern> IgnorePatterns { get; } = new();

    [XmlElement("Level Adjustment")]
    [JsonField("level adjustment")]
    public Collection<LevelAdjustmentOption> LevelAdjustment { get; } = new();

    [XmlAttribute("Automatically organize title hierarchy")]
    public bool AutoHierarchicalArrangement { get; set; }

    [XmlAttribute("List font statistics")] public bool DisplayFontStatistics { get; set; }

    [XmlAttribute("List all fonts")] public bool DisplayAllFonts { get; set; }

    [XmlAttribute("Typesetting")] public WritingDirection WritingDirection { get; set; }

    [XmlAttribute("Maximum merged line spacing")]
    public float MaxDistanceBetweenLines { get; set; }

    [XmlAttribute("Identify columns")] public bool DetectColumns { get; set; }

    [XmlAttribute("Create bookmarks for the first page")]
    public bool CreateBookmarkForFirstPage { get; set; }

    /// <summary>
    ///     Home bookmark name.Specify this property to generate a bookmark for the first page.
    /// </summary>
    internal string FirstPageTitle { get; set; }

    #endregion

    #region Positioning option

    /// <summary>
    ///     Connect the page Y axis offset of the target.
    /// </summary>
    [XmlAttribute("Y-axis offset")]
    public float YOffset { get; set; }

    /// <summary>
    ///     Position the title level to the top of the page.
    /// </summary>
    [XmlAttribute("Locate to the top of the page")]
    public int PageTopForLevel { get; set; }

    #endregion
}
