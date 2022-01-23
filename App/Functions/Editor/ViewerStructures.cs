using System.Collections.Generic;
using System.Drawing;
using MuPdfSharp;
using Point = MuPdfSharp.Point;
using Rectangle = MuPdfSharp.Rectangle;

namespace PDFPatcher.Functions.Editor;

public enum ContentDirection
{
    TopToDown,
    RightToLeft
}

public enum MouseMode
{
    Move,
    Selection
}

public readonly struct PagePoint
{
    public static readonly PagePoint Empty;

    public readonly int Page;
    public readonly float ImageX, ImageY;

    public PagePoint(int pageNumber, float imageX, float imageY)
    {
        Page = pageNumber;
        ImageX = imageX;
        ImageY = imageY;
    }
}

public readonly struct PagePosition
{
    public static readonly PagePosition Empty;

    /// <summary>
    ///     The page number is located.
    /// </summary>
    public readonly int Page;

    /// <summary>
    ///     The location on the PDF page space.
    /// </summary>
    public readonly float PageX, PageY;

    /// <summary>
    ///     The location on the rendering page.
    /// </summary>
    public readonly int ImageX, ImageY;

    /// <summary>
    ///     Whether the current point is on the page.
    /// </summary>
    public readonly bool IsInPage;

    public Point Location => new(PageX, PageY);

    internal PagePosition(int page, float x, float y, int imageX, int imageY, bool isInPage)
    {
        Page = page;
        PageX = x;
        PageY = y;
        ImageX = imageX;
        ImageY = imageY;
        IsInPage = isInPage;
    }
}

public readonly struct PageRegion
{
    public static readonly PageRegion Empty = new();

    public readonly int Page;
    public readonly Rectangle Region;

    internal PageRegion(PagePosition p1, PagePosition p2)
    {
        if (p1.Page != p2.Page)
        {
            Page = 0;
            Region = new Rectangle();
        }
        else
        {
            Page = p1.Page;
            Region = new Rectangle(p1.PageX, p1.PageY, p2.PageX, p2.PageY);
        }
    }
}

public readonly struct TextInfo
{
    public readonly MuPage Page;

    /// <summary>Get the location border of the text character.</summary>
    public readonly Rectangle CharBBox;

    /// <summary>Get the text of the text below the text.</summary>
    public readonly List<MuTextLine> TextLines;

    public readonly List<MuTextSpan> Spans;

    public TextInfo(MuPage page, Rectangle bbox, List<MuTextLine> textLines, List<MuTextSpan> spans)
    {
        Page = page;
        CharBBox = bbox;
        TextLines = textLines;
        Spans = spans;
    }
}

public readonly struct Selection
{
    private readonly RenderResultCache _cache;
    public static readonly Selection Empty;

    /// <summary>
    ///     Get the page number of the selected area.
    /// </summary>
    public readonly int Page;

    /// <summary>
    ///     Get the rectangular area selected on the page (the left corner coordinate of the screen is 0, 0).
    /// </summary>
    public readonly Rectangle PageRegion;

    /// <summary>
    ///     Get the rectangular area selected on the display image.
    /// </summary>
    public readonly RectangleF ImageRegion;

    public Bitmap GetSelectedBitmap()
    {
        _cache.LoadPage(Page);
        Bitmap p = _cache.GetBitmap(Page);
        Rectangle clip = new(
            ImageRegion.Left < 0 ? 0 : ImageRegion.Left,
            ImageRegion.Top < 0 ? 0 : ImageRegion.Top,
            ImageRegion.Right > p.Width ? p.Width : ImageRegion.Right,
            ImageRegion.Bottom > p.Height ? p.Height : ImageRegion.Bottom
        );
        return p.Clone(clip, p.PixelFormat);
    }

    public Selection(RenderResultCache cache, int page, Rectangle region, RectangleF imageRegion)
    {
        Page = page;
        PageRegion = region;
        ImageRegion = imageRegion;
        _cache = cache;
    }
}
