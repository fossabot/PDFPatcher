using System;
using System.Xml.Serialization;

namespace PDFPatcher.Model;

public class PaperSize
{
    public const string AsPageSize = "等同原始内容尺寸";
    public const string FixedWidthAutoHeight = "固定页宽自动高度";
    public const string AsSpecificPage = "等同指定页面尺寸";
    public const string AsWidestPage = "宽度同最宽页面，自动高度";
    public const string AsNarrowestPage = "宽度同最窄页面，自动高度";
    public const string AsLargestPage = "等同最大页面尺寸";
    public const string AsSmallestPage = "等同最小页面尺寸";

    private float _Height;

    private string _PaperName;

    private float _Width;

    public PaperSize()
    {
    }

    public PaperSize(float width, float height) : this(null, width, height)
    {
    }

    public PaperSize(string paperName, float width, float height)
    {
        PaperName = paperName;
        Width = width;
        Height = height;
    }

    [XmlAttribute("名称")]
    public string PaperName
    {
        get => _PaperName;
        set
        {
            _PaperName = value;
            SpecialSize = _PaperName switch
            {
                AsPageSize => SpecialPaperSize.AsPageSize,
                FixedWidthAutoHeight => SpecialPaperSize.FixedWidthAutoHeight,
                AsSpecificPage => SpecialPaperSize.AsSpecificPage,
                AsWidestPage => SpecialPaperSize.AsWidestPage,
                AsNarrowestPage => SpecialPaperSize.AsNarrowestPage,
                AsLargestPage => SpecialPaperSize.AsLargestPage,
                AsSmallestPage => SpecialPaperSize.AsSmallestPage,
                _ => SpecialPaperSize.None
            };
        }
    }

    [XmlIgnore] public SpecialPaperSize SpecialSize { get; private set; }

    /// <summary>Gets or specifies the value of the page height.</summary>
    [XmlAttribute("高度")]
    public float Height
    {
        get => _Height;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("页面高度不可小于 0。");
            }

            _Height = value;
        }
    }

    /// <summary>Gets or specifies the value of the page width.</summary>
    [XmlAttribute("宽度")]
    public float Width
    {
        get => _Width;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("页面宽度不可小于 0。");
            }

            _Width = value;
        }
    }

    internal PaperSize Scale(float xFactor, float yFactor) => new(PaperName, Width * xFactor, Height * yFactor);

    internal PaperSize Scale(float factor) => new(PaperName, Width * factor, Height * factor);

    internal PaperSize Clone() => (PaperSize)MemberwiseClone();

    public override string ToString() => PaperName;
}

public enum SpecialPaperSize
{
    None,
    AsPageSize,
    FixedWidthAutoHeight,
    AsSpecificPage,
    AsWidestPage,
    AsNarrowestPage,
    AsLargestPage,
    AsSmallestPage
}
