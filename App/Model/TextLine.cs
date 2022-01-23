using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PDFPatcher.Model;

[DebuggerDisplay("{Direction}({Region.Middle},{Region.Center}):Text = {Text}")]
internal sealed class TextLine : IDirectionalBoundObject
{
    private readonly List<TextInfo> _Texts;

    private string _Text;

    private TextLine()
    {
        _Texts = new List<TextInfo>();
        Direction = DefaultDirection;
    }

    internal TextLine(TextInfo text) : this()
    {
        _Texts.Add(text);
        Region = new Bound(text.Region);
        if (text.Text.Length > 2 && text.Region.Height > 0 && text.Region.Width > text.Region.Height * 2)
        {
            Direction = WritingDirection.Horizontal;
        }
    }

    /// <summary>Get the text included in this line.</summary>
    internal IEnumerable<TextInfo> Texts => _Texts;

    /// <summary>Get the first <see cref="TextInfo" /> within <see cref="Texts" />. </summary>
    internal TextInfo FirstText => _Texts[0];

    internal bool SuppressTextInfoArrangement { get; set; }

    /// <summary>
    ///     The default writing direction.
    /// </summary>
    internal static WritingDirection DefaultDirection { get; set; }

    public WritingDirection Direction { get; private set; }
    public Bound Region { get; private set; }

    /// <summary>
    ///     Get strings that are connected in series in all texts in <see cref="Texts" />.
    /// </summary>
    public string Text => _Text ??= GetConcatenatedText();

    internal void AddText(TextInfo text)
    {
        if (Direction == WritingDirection.Unknown)
        {
            DistanceInfo d = GetDistance(text.Region);
            Direction = InferWritingDirection(d);
            if (Direction == WritingDirection.Unknown)
            {
                d = GetDistance(new Bound(text.Region.Center, text.Region.Middle));
                Direction = InferWritingDirection(d);
            }
        }

        _Text = null;
        _Texts.Add(text);
        Region.Merge(text.Region);
    }

    private static WritingDirection InferWritingDirection(DistanceInfo d) =>
        d.IsVerticallyAligned ? WritingDirection.Vertical
        : d.IsHorizontallyAligned ? WritingDirection.Horizontal
        : WritingDirection.Unknown;

    internal void Merge(TextLine source)
    {
        _Text = null;
        Region.Merge(source.Region);
        _Texts.AddRange(source.Texts);
    }

    /// <summary>
    ///     Get zone <paramref name="other" /> Distance between the current line lines.
    /// </summary>
    /// <param name="other">Another area.</param>
    /// <returns><paramref name="other" /> Distance relative to this area.</returns>
    internal DistanceInfo GetDistance(Bound other) => Region.GetDistance(other, Direction);

    /// <summary>
    ///     Get strings that are connected in series in all texts in <see cref="Texts" />.
    /// </summary>
    private string GetConcatenatedText()
    {
        int l = _Texts.Count;
        switch (l)
        {
            case 0:
                return string.Empty;
            case 1:
                return _Texts[0].Text;
        }

        if (SuppressTextInfoArrangement == false)
        {
            if (Direction == WritingDirection.Vertical)
            {
                _Texts.Sort(TextInfo.CompareRegionY);
            }
            else
            {
                _Texts.Sort(TextInfo.CompareRegionX);
            }
        }

        float cs = GetAverageCharSize();
        StringBuilder sb = new();
        sb.Append(_Texts[0].Text);
        for (int i = 1; i < l; i++)
        {
            if (cs > 0)
            {
                float dx = Direction == WritingDirection.Vertical
                    ? _Texts[i].Region.Top - _Texts[i - 1].Region.Bottom
                    : _Texts[i].Region.Left - _Texts[i - 1].Region.Right;
                if (dx > cs)
                {
                    string t = _Texts[i - 1].Text;
                    // Adjustment punctuation
                    char c;
                    if (t.Length > 0)
                    {
                        c = t[t.Length - 1];
                        if (char.IsPunctuation(c) && c > 128)
                        {
                            dx -= cs;
                        }
                    }

                    t = _Texts[i].Text;
                    if (t.Length > 0)
                    {
                        c = _Texts[i].Text[0];
                        if (char.IsPunctuation(c) && c > 128)
                        {
                            dx -= cs;
                        }
                    }
                }

                while ((dx -= cs) > 0)
                {
                    sb.Append(' ');
                }
            }

            sb.Append(_Texts[i].Text);
        }

        return sb.ToString();
    }

    /// <summary>Gets the average size of <see cref="Texts" />.</summary>
    /// <returns>Returns average character size.</returns>
    internal float GetAverageCharSize()
    {
        float ts = 0, cc = 0;
        if (Direction == WritingDirection.Vertical)
        {
            _Texts.ForEach(t =>
            {
                ts += t.LetterWidth;
                cc += t.Text.Length;
            });
        }
        else
        {
            foreach (TextInfo t in _Texts)
            {
                ts += t.LetterWidth;
                cc = t.Text.Where(char.IsLetterOrDigit).Aggregate(cc, (current, c) => current + (c > 0x36F ? 2 : 1));
            }
        }

        return ts / cc; // Average character width
    }
}
