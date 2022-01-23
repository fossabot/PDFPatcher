using System.Collections.Generic;
using System.Diagnostics;

namespace PDFPatcher.Model;

[DebuggerDisplay("{Direction}({Region.Top},{Region.Left})Lines={Lines.Count}")]
internal sealed class TextRegion
{
    internal TextRegion() => Lines = new List<TextLine>();

    internal TextRegion(TextLine text) : this()
    {
        Region = new Bound(text.Region);
        AddLine(text);
    }

    internal WritingDirection Direction { get; set; }
    internal Bound Region { get; private set; }

    /// <summary>
    ///     Get the line in the text area.
    ///     should not call the Add method of this property to add a line, but should use the <see cref="TextRegion.AddLine" />
    ///     method.
    /// </summary>
    internal List<TextLine> Lines { get; private set; }

    internal void AddLine(TextLine line)
    {
        if (Direction == WritingDirection.Unknown)
        {
            DistanceInfo d = Region.GetDistance(line.Region, WritingDirection.Unknown);
            Direction = d.Location switch
            {
                DistanceInfo.Placement.Up or DistanceInfo.Placement.Down => WritingDirection.Vertical,
                DistanceInfo.Placement.Left or DistanceInfo.Placement.Right => WritingDirection.Horizontal,
                _ => WritingDirection.Unknown
            };
        }

        Lines.Add(line);
        Region.Merge(line.Region);
    }
}
