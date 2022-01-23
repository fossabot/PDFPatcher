using System;
using System.Diagnostics;
using System.Drawing;

namespace PDFPatcher.Model;

[DebuggerDisplay("T={Top},L={Left},B={Bottom},R={Right}; H={Height},W={Width}")]
public class Bound
{
    public Bound(float left, float bottom, float right, float top)
    {
        if (right < left)
        {
            Debug.WriteLine("The right end coordinates cannot be less than the left end coordinates.");
            float t = right;
            right = left;
            left = t;
        }

        Left = left;
        Bottom = bottom;
        Right = right;
        Top = top;
        RecalculateSize();
    }

    /// <summary>
    ///     Create a region (point) instance of the width and height of 0.
    /// </summary>
    /// <param name="x">X-axis.</param>
    /// <param name="y">Y-axis.</param>
    public Bound(float x, float y) : this(x, y, x, y)
    {
    }

    /// <summary>
    ///     Copy a copy from the specified area.
    /// </summary>
    /// <param name="Source">The area that needs to be replicated.</param>
    public Bound(Bound source) : this(source.Left, source.Bottom, source.Right, source.Top)
    {
    }

    internal float Top { get; private set; }
    internal float Left { get; private set; }
    internal float Bottom { get; private set; }
    internal float Right { get; private set; }

    /// <summary>
    ///     Get this area coordinate belongs to the Cartesian coordinate system.
    /// </summary>
    internal bool IsTopUp { get; private set; }

    /// <summary>
    ///     Gets whether this coordinate area belongs to the drawing coordinate system.
    /// </summary>
    internal bool IsTopDown { get; private set; }

    internal float Height { get; private set; }
    internal float Width { get; private set; }

    internal float Middle { get; private set; }
    internal float Center { get; private set; }

    private void RecalculateSize()
    {
        IsTopUp = Top >= Bottom;
        IsTopDown = Top <= Bottom;
        Height = IsTopUp ? Top - Bottom : Bottom - Top;
        Middle = (Top + Bottom) / 2;
        Width = Right - Left;
        Center = (Left + Right) / 2;
    }

    internal Bound Merge(Bound source)
    {
        // Cartesian coordinates
        if (IsTopUp)
        {
            if (Top < source.Top)
            {
                Top = source.Top;
            }

            if (Bottom > source.Bottom)
            {
                Bottom = source.Bottom;
            }
        }
        else
        {
            if (Top > source.Top)
            {
                Top = source.Top;
            }

            if (Bottom < source.Bottom)
            {
                Bottom = source.Bottom;
            }
        }

        if (Left > source.Left)
        {
            Left = source.Left;
        }

        if (Right < source.Right)
        {
            Right = source.Right;
        }

        RecalculateSize();
        return this;
    }

    /// <summary>
    ///     Get the distance between the area <paramref name="other" /> to the current area.
    /// </summary>
    /// <param name="other">Another area.</param>
    /// <param name="writingDirection">Assume the writing direction.</param>
    /// <returns><paramref name="other" /> The distance relationship relative to this area.</returns>
    internal DistanceInfo GetDistance(Bound other, WritingDirection writingDirection)
    {
        if (IsTopDown != other.IsTopDown && IsTopUp != other.IsTopUp)
        {
            throw new ArgumentException("The area coordinate system is different.");
        }

        float hd = float.MaxValue, vd = float.MaxValue;
        DistanceInfo.Placement hp = DistanceInfo.Placement.Unknown;
        DistanceInfo.Placement vp = DistanceInfo.Placement.Unknown;
        float au, ad, bu, bd;
        if (IsTopDown)
        {
            au = Top;
            ad = Bottom;
            bu = other.Top;
            bd = other.Bottom;
        }
        else
        {
            au = -Top;
            ad = -Bottom;
            bu = -other.Top;
            bd = -other.Bottom;
        }

        if (IntersectWith(other))
        {
            hd = other.Center - Center;
            switch (hd)
            {
                case > 0:
                    hp = DistanceInfo.Placement.Right;
                    break;
                case < 0:
                    hp = DistanceInfo.Placement.Left;
                    hd = -hd;
                    break;
            }

            vd = other.Middle - Middle;
            switch (vd)
            {
                case > 0:
                    vp = IsTopUp ? DistanceInfo.Placement.Up : DistanceInfo.Placement.Down;
                    break;
                case < 0:
                    vp = IsTopUp ? DistanceInfo.Placement.Down : DistanceInfo.Placement.Up;
                    break;
                case 0 when hd == 0:
                    return new DistanceInfo(DistanceInfo.Placement.Overlapping, 0, 0);
                case 0:
                    return new DistanceInfo(DistanceInfo.Placement.Overlapping | hp, hd, vd);
            }

            return hp == 0
                ? new DistanceInfo(DistanceInfo.Placement.Overlapping | vp, hd, vd)
                : new DistanceInfo(DistanceInfo.Placement.Overlapping, hd, vd);
        }

        if (other.Left >= Right)
        {
            hp = DistanceInfo.Placement.Right;
            hd = other.Left - Right;
        }
        else if (other.Right <= Left)
        {
            hp = DistanceInfo.Placement.Left;
            hd = Left - other.Right;
        }

        if (bd <= au)
        {
            vp = DistanceInfo.Placement.Up;
            vd = au - bd;
        }
        else if (bu >= ad)
        {
            vp = DistanceInfo.Placement.Down;
            vd = bu - ad;
        }

        if (hp == DistanceInfo.Placement.Unknown && vp == DistanceInfo.Placement.Unknown)
        {
            throw new ArgumentOutOfRangeException("Location error.");
        }

        DistanceInfo v = new(vp, hd, vd);
        DistanceInfo h = new(hp, hd, vd);
        return writingDirection switch
        {
            WritingDirection.Vertical => hp != DistanceInfo.Placement.Unknown ? h : v,
            WritingDirection.Horizontal => vp != DistanceInfo.Placement.Unknown ? v : h,
            _ => hd < vd ? h : v
        };
    }

    /// <summary>
    ///     Returns whether the current area is in the same row in the specified area (whether the center point is falling in
    ///     the two edges of <paramref name="other" />).
    /// </summary>
    /// <param name="other">The area that needs to be compared.</param>
    /// <param name="direction">The comparison direction.</param>
    /// <returns>Returns True at the same line.</returns>
    internal bool IsAlignedWith(Bound other, WritingDirection direction) =>
        direction switch
        {
            WritingDirection.Horizontal => IsTopDown
                ? other.Top < Middle && Middle < other.Bottom || Top < other.Middle && other.Middle < Bottom
                : other.Bottom < Middle && Middle < other.Top || Bottom < other.Middle && other.Middle < Top,
            WritingDirection.Vertical => other.Left < Center && Center < other.Right ||
                                         Left < other.Center && other.Center < Right,
            _ => IntersectWith(other)
        };

    internal bool IntersectWith(Bound other) =>
        other.Left < Right && Left < other.Right &&
        (IsTopDown
            ? other.Top < Bottom && Top < other.Bottom
            : other.Bottom < Top && Bottom < other.Top);

    internal bool Contains(float x, float y)
    {
        float y1, y2;
        float x1 = Left;
        float x2 = Right;
        if (IsTopUp)
        {
            y1 = Bottom;
            y2 = Top;
        }
        else
        {
            y1 = Top;
            y2 = Bottom;
        }

        return x1 <= x && x <= x2 && y1 <= y && y <= y2;
    }

    public static bool operator ==(Bound a, Bound b) =>
        a.Top == b.Top && a.Bottom == b.Bottom && a.Left == b.Left && a.Right == b.Right;

    public static bool operator !=(Bound a, Bound b) =>
        a.Top != b.Top || a.Bottom != b.Bottom || a.Left != b.Left || a.Right != b.Right;

    public override bool Equals(object obj) => this == (Bound)obj;

    public override int GetHashCode() =>
        Top.GetHashCode() ^ Bottom.GetHashCode() ^ Left.GetHashCode() ^ Right.GetHashCode();

    public static implicit operator RectangleF(Bound bound) =>
        new(Math.Min(bound.Left, bound.Right), Math.Min(bound.Top, bound.Bottom),
            Math.Abs(bound.Left - bound.Right), Math.Abs(bound.Top - bound.Bottom));
}
