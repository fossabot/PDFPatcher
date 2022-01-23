using System;
using System.Xml.Serialization;

namespace PDFPatcher.Model;

public class PaperSize
{
    public const string AsPageSize = "Same as original content size";
    public const string FixedWidthAutoHeight = "Fixed page width auto height";
    public const string AsSpecificPage = "Equal to the specified page size";
    public const string AsWidestPage = "The width is the same as the widest page, automatic height";
    public const string AsNarrowestPage = "The width is the same as the narrowest page, automatic height";
    public const string AsLargestPage = "Equal to maximum page size";
    public const string AsSmallestPage = "Smallest page size";

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

    [XmlAttribute("Name")]
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
    [XmlAttribute("Height")]
    public float Height
    {
        get => _Height;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("The page height cannot be less than 0.");
            }

            _Height = value;
        }
    }

    /// <summary>Gets or specifies the value of the page width.</summary>
    [XmlAttribute("Width")]
    public float Width
    {
        get => _Width;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("The page width cannot be less than 0.");
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
