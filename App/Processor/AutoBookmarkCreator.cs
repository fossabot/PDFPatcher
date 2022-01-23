using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using PDFPatcher.Common;
using PDFPatcher.Model;
using GraphicsState = PDFPatcher.Model.GraphicsState;

namespace PDFPatcher.Processor;

internal sealed class AutoBookmarkCreator
{
    private const string __AddSpaceAfterCharacters = ":.,\"'?!)]};";
    private const string __InsertSpaceBeforeCharacters = "\"'([{";
    private const int OpenWorkload = 10;
    private readonly AutoBookmarkOptions _options;

    private readonly PdfReader _reader;

    public AutoBookmarkCreator(PdfReader reader, AutoBookmarkOptions options)
    {
        _reader = reader;
        _options = options;
        TextLine.DefaultDirection = options.WritingDirection;
    }

    internal int EstimateWorkload()
    {
        int n = _reader.NumberOfPages;
        int load = 0;
        load += OpenWorkload;
        int t = PageRangeCollection.Parse(_options.PageRanges, 1, n, true).TotalPages;
        load += t > 0 ? t : n;
        return load;
    }

    internal void ExportAutoBookmarks(XmlWriter w, AutoBookmarkOptions options) =>
        AutoCreateBookmarks(w, _reader, options);

    internal void AutoCreateBookmarks(XmlWriter writer, PdfReader reader, AutoBookmarkOptions options)
    {
        Tracker.IncrementProgress(OpenWorkload);
        int pn = reader.NumberOfPages + 1;
        AutoBookmarkContext c = new() { TotalPageNumber = reader.NumberOfPages };
        TextToBookmarkProcessor p = new(options, c);
        LevelProcessor lp = new(options.LevelAdjustment);
        PageRangeCollection ranges = PageRangeCollection.Parse(options.PageRanges, 1, reader.NumberOfPages, true);
        XmlDocument doc = new();
        XmlElement be = doc.AppendChild(doc.CreateElement(Constants.Bookmark)) as XmlElement;
        Stack<float> sizes = new();
        float yOffset = 1 + options.YOffset;
        int level = 0;
        const string indentString = "　　　　　　　　　　";
        List<MatchPattern.IMatcher> ig;
        FontOccurance fontOccurances = new();
        if (options.IgnorePatterns.Count == 0)
        {
            ig = null;
        }
        else
        {
            ig = new List<MatchPattern.IMatcher>();
            foreach (MatchPattern item in options.IgnorePatterns)
            {
                if (string.IsNullOrEmpty(item.Text))
                {
                    continue;
                }

                try
                {
                    ig.Add(item.CreateMatcher());
                }
                catch (ArgumentException ex)
                {
                    Tracker.TraceMessage(Tracker.Category.Alert,
                        string.Concat("Ignore text (", item, ") is invalid: ", ex.Message));
                }
            }
        }

        XmlWriter oldWriter = null;
        if (options.ExportTextCoordinates == false)
        {
            oldWriter = writer;
            writer = new NullXmlWriter();
        }

        foreach (PageRange r in ranges)
        {
            for (int i = r.StartValue; i <= r.EndValue && i < pn; i++)
            {
                if (i == 1 && options.CreateBookmarkForFirstPage)
                {
                    continue;
                }

                //Tracker.TraceMessage(String.Concat("Analyze page ", i, "."));
                Rectangle box = reader.GetCropBox(i);
                p.Reset();
                c.PageBox = box;
                c.CurrentPageNumber = i;
                int pr = reader.GetPageRotation(i);
                pr = PdfHelper.NormalizeRotationNumber(pr);
                if (pr != 0)
                {
                    p.RotationMatrix = pr switch
                    {
                        90 => new Matrix(0, 1, -1, 0, 0, 0),
                        180 => new Matrix(0, -1, -1, 0, 0, 0),
                        270 => new Matrix(0, -1, 1, 0, 0, 0),
                        _ => p.RotationMatrix
                    };
                }

                p.ProcessContent(reader.GetPageContent(i), reader.GetPageNRelease(i).GetAsDict(PdfName.RESOURCES));
                //p.SortTextList ();
                //p.PostProcessTextList ();

                //var tr = p.TextList;
                c.IsTextMerged = false;
                c.TextLine = null;
                // TODO: Automatically correct the typographic direction according to the known typesetting direction
                // Screening before merge
                List<TextInfo> ptl = p.TextList;
                for (int li = ptl.Count - 1; li >= 0; li--)
                {
                    c.TextInfo = ptl[li];
                    if (lp.ChangeSizeLevel(c) < options.TitleThreshold)
                    {
                        ptl.RemoveAt(li);
                    }
                }

                List<TextLine> tl = MergeTextInfoList(box, ptl, _options);
                // TODO: Filter text
                c.IsTextMerged = true;
                for (int li = tl.Count - 1; li >= 0; li--)
                {
                    c.TextLine = tl[li];
                    c.TextInfo = c.TextLine.FirstText;
                    if ((c.TextInfo.Size = lp.ChangeSizeLevel(c)) < options.TitleThreshold)
                    {
                        tl.RemoveAt(li);
                    }
                }

                List<TextRegion> tr = MergeTextLines(box, tl);
                if (tr is { Count: > 0 })
                {
                    if (options.WritingDirection != WritingDirection.Unknown)
                    {
                        tr.Sort((a, b) =>
                        {
                            Bound ra = a.Region;
                            Bound rb = b.Region;
                            if (ra.Middle < rb.Middle)
                            {
                                return 1;
                            }

                            if (ra.Middle > rb.Middle)
                            {
                                return -1;
                            }

                            if (ra.Center > rb.Center)
                            {
                                return 1;
                            }

                            if (ra.Center < rb.Center)
                            {
                                return -1;
                            }

                            return 0;
                        });
                    }

                    writer.WriteStartElement(Constants.Content.Texts);
                    writer.WriteValue(Constants.Content.PageNumber, i);
                    foreach (TextRegion item in tr)
                    {
                        string t = PdfHelper.GetValidXmlString(ConcatRegionText(item)).Trim();
                        FontInfo f = item.Lines[0].FirstText.Font;
                        float s = item.Lines[0].FirstText.Size;
                        writer.WriteStartElement("text");
                        writer.WriteAttributeString(Constants.Font.ThisName, f != null ? f.FontID.ToText() : "OCR");
                        writer.WriteValue(Constants.Coordinates.Top, item.Region.Top);
                        writer.WriteValue(Constants.Coordinates.Bottom, item.Region.Bottom);
                        writer.WriteValue(Constants.Coordinates.Left, item.Region.Left);
                        writer.WriteValue(Constants.Coordinates.Width, item.Region.Width);
                        writer.WriteValue(Constants.Coordinates.Height, item.Region.Height);
                        writer.WriteValue("size", s);
                        writer.WriteString(t);
                        writer.WriteEndElement();

                        if (t.Length == 0
                            || t.Length == 1 && options.IgnoreSingleCharacterTitle
                            || options.IgnoreNumericTitle && AutoBookmarkOptions.NumericPattern.IsMatch(t)
                           )
                        {
                            continue;
                        }

                        if (ig != null)
                        {
                            bool ignore = false;
                            foreach (MatchPattern.IMatcher unused in ig.Where(rg => rg.Matches(t)))
                            {
                                ignore = true;
                            }

                            if (ignore)
                            {
                                continue;
                            }
                        }

                        if (options.AutoHierarchicalArrangement)
                        {
                            float size;
                            do
                            {
                                //if (ValueHelper.TryParse (be.GetAttribute (Constants.Font.Size), out size) == false || s < size) {
                                if (sizes.Count == 0 || s < (size = sizes.Peek()))
                                {
                                    be = be.AppendChild(doc.CreateElement(Constants.Bookmark)) as XmlElement;
                                    sizes.Push(s);
                                    level++;
                                    break;
                                }

                                if (s == size)
                                {
                                    be = (be.ParentNode ?? be).AppendChild(doc.CreateElement(Constants.Bookmark)) as
                                        XmlElement;
                                    break;
                                }

                                be = be.ParentNode as XmlElement;
                                sizes.Pop();
                                level--;
                            } while (s > size && be.NodeType == XmlNodeType.Element);
                        }
                        else
                        {
                            be = doc.DocumentElement.AppendChild(doc.CreateElement(Constants.Bookmark)) as XmlElement;
                        }

                        be.SetAttribute(Constants.BookmarkAttributes.Title, t);
                        be.SetAttribute(Constants.DestinationAttributes.Page, i.ToText());
                        be.SetAttribute(Constants.DestinationAttributes.View,
                            Constants.DestinationAttributes.ViewType.XYZ);
                        be.SetAttribute(Constants.Coordinates.Top, (item.Region.Top + s * yOffset).ToText());
                        be.SetAttribute(Constants.Font.Size, s.ToText());
                        if (f != null)
                        {
                            be.SetAttribute(Constants.Font.ThisName, f.FontID.ToText());
                            //fontOccurances.AddOccurance (f.FontID, s, i, t);
                        }

                        CountFontOccuranceInRegion(fontOccurances, i, item);
#if DEBUG
                        Tracker.TraceMessage(string.Concat(item.Direction.ToString()[0], ':',
                            level < 11 ? indentString.Substring(0, level) : indentString, t, " .... ", i.ToText()));
#else
							Tracker.TraceMessage (String.Concat (level < 11 ? indentString.Substring (0, level) : indentString, t, " .... ", ValueHelper.ToText (i)));
#endif
                    }

                    writer.WriteEndElement();
                }

                Tracker.IncrementProgress(1);
            }
        }

        if (oldWriter != null)
        {
            writer = oldWriter;
        }

        WriteDocumentFontOccurances(writer, options, p, fontOccurances);
        SetGoToTop(options, doc);
        writer.WriteStartElement(Constants.DocumentBookmark);
        if (options.CreateBookmarkForFirstPage && string.IsNullOrEmpty(options.FirstPageTitle) == false)
        {
            writer.WriteStartElement(Constants.Bookmark);
            writer.WriteAttributeString(Constants.BookmarkAttributes.Title, options.FirstPageTitle);
            writer.WriteAttributeString(Constants.DestinationAttributes.Page, "1");
            writer.WriteAttributeString(Constants.DestinationAttributes.Action, Constants.ActionType.Goto);
            writer.WriteEndElement();
        }

        doc.DocumentElement.WriteContentTo(writer);
        writer.WriteEndElement();
    }

    private static void SetGoToTop(AutoBookmarkOptions options, XmlDocument doc)
    {
        if (options.PageTopForLevel <= 0)
        {
            return;
        }

        XmlNodeList topics =
            doc.DocumentElement.SelectNodes(".//Bookmarks[count(ancestor::Bookmarks) < " +
                                            (options.PageTopForLevel + 1) + "]");
        foreach (XmlElement t in topics)
        {
            t.RemoveAttribute(Constants.Coordinates.Top);
        }
    }

    private static void WriteDocumentFontOccurances(XmlWriter writer, AutoBookmarkOptions options,
        TextToBookmarkProcessor p, FontOccurance fontOccurances)
    {
        writer.WriteStartElement(Constants.Font.DocumentFont);
        Tracker.TraceMessage("\nThe font used in the document");
        List<string> dl = new();
        foreach (KeyValuePair<int, string> item in p.FontList)
        {
            string fo = "0";
            List<SizeOccurrence> sl = fontOccurances.GetOccurance(item.Value);
            if (sl != null)
            {
                if (dl.Contains(item.Value) == false)
                {
                    int o = sl.Sum(s => s.Occurrence);

                    fo = o.ToText();
                    dl.Add(item.Value);
                }
                else
                {
                    sl = null;
                }
            }

            if (options.DisplayFontStatistics && (sl != null || options.DisplayAllFonts))
            {
                Tracker.TraceMessage(string.Concat("Number:", item.Key, "\tNumber of occurrences:", fo, "\tName:",
                    item.Value));
            }

            writer.WriteStartElement(Constants.Font.ThisName);
            writer.WriteAttributeString(Constants.Font.ID, item.Key.ToText());
            writer.WriteAttributeString(Constants.Font.Name, item.Value);
            writer.WriteAttributeString(Constants.FontOccurance.Count, fo);
            if (sl != null)
            {
                foreach (SizeOccurrence s in sl)
                {
                    writer.WriteStartElement(Constants.Font.Size);
                    writer.WriteAttributeString(Constants.Font.Size, s.Size.ToText());
                    writer.WriteAttributeString(Constants.FontOccurance.Count, s.Occurrence.ToText());
                    writer.WriteAttributeString(Constants.FontOccurance.FirstText, s.FirstInstance);
                    writer.WriteAttributeString(Constants.FontOccurance.FirstPage, s.FirstPage.ToText());
                    if (options.DisplayFontStatistics && (s.Occurrence > 0 || options.DisplayAllFonts))
                    {
                        Tracker.TraceMessage(string.Concat("\tSize:", s.Size.ToText(), "\tNumber of occurrences:",
                            s.Occurrence.ToText(),
                            "\tFirst appeared on page", s.FirstPage.ToText(), "Page(", s.FirstInstance, ")"));
                    }

                    writer.WriteEndElement();
                }
            }

            writer.WriteEndElement();
        }

        writer.WriteEndElement();
    }

    private static void CountFontOccuranceInRegion(FontOccurance fontOccurances, int i, TextRegion item)
    {
        FontInfo f = null;
        foreach (TextLine il in item.Lines)
        {
            foreach (TextInfo ii in il.Texts)
            {
                if (ii.Font == null || f != null && ii.Font.FontID == f.FontID)
                {
                    continue;
                }

                fontOccurances.AddOccurance(ii.Font.FontName, ii.Size, i, il.Text);
                f = ii.Font;
            }
        }
    }

    private static string ConcatRegionText(TextRegion region)
    {
        List<TextLine> ls = region.Lines;
        switch (ls.Count)
        {
            case 0:
                return string.Empty;
            case 1:
                return ls[0].Text;
        }

        ls = new List<TextLine>(ls);
        if (region.Direction == WritingDirection.Vertical)
        {
            ls.Sort((a, b) =>
            {
                if (a.Region.Middle < b.Region.Middle)
                {
                    return 1;
                }

                if (a.Region.Middle > b.Region.Middle)
                {
                    return -1;
                }

                return 0;
            });
        }

        StringBuilder sb = new();
        sb.Append(ls[0].Text);
        for (int i = 1; i < ls.Count; i++)
        {
            string l = ls[i].Text;
            string ll = ls[i - 1].Text;
            if (ll.Length > 0 && l.Length > 0)
            {
                char c1 = l[l.Length - 1];
                char c2 = ll[0];
                if ((__AddSpaceAfterCharacters.IndexOf(c1) != -1
                     || char.IsLetterOrDigit(c1) && c1 < 0x4E00)
                    && (__InsertSpaceBeforeCharacters.IndexOf(c2) != -1
                        || char.IsLetterOrDigit(c2) && c2 < 0x4E00))
                {
                    sb.Append(' ');
                }
            }

            sb.Append(l);
        }

        return sb.ToString();
    }

    /// <summary>
    ///     Use the minimum distance method to cluster the text of the <paramref name="textinfos" /> to the list of "see cref
    ///     =" textline "/>.
    /// </summary>
    /// <param name="textInfos"><see cref="textInfo" /> collection containing text locations and dimension information.</param>
    /// <returns>The <see cref="TextLine" /> list obtained after cluster.</returns>
    internal static List<TextLine> MergeTextInfoList(Rectangle pageBox, IList<TextInfo> textInfos,
        AutoBookmarkOptions options)
    {
        List<TextLine> ll = new();
        // Width width minimum
        float cw = pageBox.Width / 6;

        int[] dirCount = new int[4];
        // Traverse the TextInfo that identifies the resulting, clustering it into a line using the minimum distance clustering method
        foreach (TextInfo item in textInfos)
        {
            Bound ir = item.Region;
            DistanceInfo md = new(DistanceInfo.Placement.Unknown, float.MaxValue, float.MaxValue); // shortest distance
            TextLine ml = null; // Minimum distance TextLine

            // Ask minimum distances of TextLine
            float ds = item.Size / 10;
            // The loop contains only TextLine, and the rest of the text of text textinfo is not included.
            int end = ll.Count > 5 ? ll.Count - 5 : 0;
            for (int i = ll.Count - 1; i >= end; i--)
            {
                TextLine li = ll[i];
                // Text size should be within the range of errors
                if (Math.Abs(item.Size - li.FirstText.Size) > ds && options.MergeDifferentSizeTitles == false)
                {
                    continue;
                }

                if (options.MergeDifferentFontTitles == false && li.FirstText.Font.FontID != item.Font.FontID)
                {
                    break;
                }

                DistanceInfo cd = li.GetDistance(ir); // Distance from TextInfo to TextLine
                if ((!cd.IsOverlapping || md.IsOverlapping && !(cd.DistanceRadial < md.DistanceRadial)) &&
                    (md.Location != DistanceInfo.Placement.Unknown && (cd.IsOverlapping ||
                                                                       md.IsOverlapping ||
                                                                       !(cd.MinDistance < md.MinDistance)) ||
                     (!cd.IsHorizontallyAligned || li.Direction == WritingDirection.Vertical ||
                      !item.Region.IsAlignedWith(li.Region, WritingDirection.Horizontal)) &&
                     (!cd.IsVerticallyAligned || li.Direction == WritingDirection.Horizontal ||
                      !item.Region.IsAlignedWith(li.Region, WritingDirection.Vertical)) ||
                     options.DetectColumns && !(cd.MinDistance < cw) || !options.MergeDifferentFontTitles &&
                     li.FirstText.Font.FontID != item.Font.FontID))
                {
                    continue;
                }

                md = cd;
                ml = li;
                if (cd.IsLeft)
                {
                    dirCount[0]++;
                }
                else if (cd.IsRight)
                {
                    dirCount[1]++;
                }
                else if (cd.IsAbove)
                {
                    dirCount[2]++;
                }
                else if (cd.IsBelow)
                {
                    dirCount[3]++;
                }
            }

            // Otherwise, create new TextLine with item
            if (item.Text.Length == 0)
            {
                item.Text = " ";
            }

            if (ml != null)
            {
                // If there is a minimum distance of TextLine and can be merged, you will be classified into TextLine.
                if (md.IsOverlapping && options.IgnoreOverlappedText)
                {
                    // Check if there is an overlapping duplicate text
                    foreach (TextInfo t in ml.Texts)
                    {
                        if (t.Region.IntersectWith(item.Region) // Item is overlapped in TextLine
                            && (t.Text.Contains(item.Text) ||
                                item.Text.Contains(t.Text) // Overlapping text and item text
                            )
                           )
                        {
                            goto Next; // Ignore this item
                        }
                    }
                }

                ml.AddText(item);
            }
            else
            {
                ll.Add(new TextLine(item));
            }

        Next:;
        }

        return ll;
    }

    internal List<TextRegion> MergeTextLines(Rectangle pageBox, IList<TextLine> textLines)
    {
        List<TextRegion> ll = new();
        // Width width minimum
        float cw = pageBox.Width / 6;

        // Traverse the TextInfo that identifies the resulting, clustering it into a line using the minimum distance clustering method
        foreach (TextLine item in textLines)
        {
            Bound ir = item.Region;
            DistanceInfo md = new(DistanceInfo.Placement.Unknown, float.MaxValue, float.MaxValue); // shortest distance
            TextRegion mr = null; // Minimum distance TEXTREGION

            // Ask minimum distances of TextLine
            float ds = item.FirstText.Size / 10;
            // The loop contains only TextLine, and the rest of the text of text textinfo is not included.
            for (int i = ll.Count - 1; i >= 0; i--)
            {
                TextRegion li = ll[i];
                // Text size should be within the range of errors
                if (Math.Abs(item.FirstText.Size - li.Lines[0].FirstText.Size) > ds && _options.MergeAdjacentTitles)
                {
                    continue;
                }

                if (_options.MergeDifferentFontTitles == false &&
                    li.Lines[0].FirstText.Font.FontID != item.FirstText.Font.FontID)
                {
                    break;
                }

                DistanceInfo cd = li.Region.GetDistance(ir, li.Direction); // Distance from TextInfo to TextLine
                if ((!cd.IsOverlapping || md.IsOverlapping && !(cd.DistanceRadial < md.DistanceRadial)) &&
                    (md.Location != DistanceInfo.Placement.Unknown && (cd.IsOverlapping ||
                                                                       md.IsOverlapping ||
                                                                       !(cd.MinDistance < md.MinDistance)) ||
                     (!cd.IsHorizontallyAligned || li.Direction == WritingDirection.Vertical ||
                      !item.Region.IsAlignedWith(li.Region, WritingDirection.Horizontal) ||
                      !(cd.MinDistance < item.Region.Width * _options.MaxDistanceBetweenLines) ||
                      !_options.MergeAdjacentTitles ||
                      !_options.MergeDifferentSizeTitles && li.Lines[0].Region.Width != item.Region.Width) &&
                     (!cd.IsVerticallyAligned || li.Direction == WritingDirection.Horizontal ||
                      !item.Region.IsAlignedWith(li.Region, WritingDirection.Vertical) ||
                      !(cd.MinDistance < item.Region.Height * _options.MaxDistanceBetweenLines) ||
                      !_options.MergeAdjacentTitles ||
                      !_options.MergeDifferentSizeTitles && li.Lines[0].Region.Height != item.Region.Height) ||
                     !(cd.MinDistance < cw)))
                {
                    continue;
                }

                md = cd;
                mr = li;
            }

            // Otherwise, create new TextLine with item
            if (mr != null)
            {
                // If there is a minimum distance of TextLine and can be merged, you will be classified into TextLine.
                mr.AddLine(item);
            }
            else
            {
                ll.Add(new TextRegion(item));
            }
        }

        return ll;
    }

    private sealed class SizeOccurrence
    {
        public SizeOccurrence(float size, int page, string instance)
        {
            Size = size;
            Occurrence = 1;
            FirstPage = page;
            FirstInstance = instance.Length > 50 ? instance.Substring(0, 50) : instance;
        }

        public float Size { get; }
        public int FirstPage { get; }
        public string FirstInstance { get; }
        public int Occurrence { get; set; }
    }

    private sealed class FontOccurance
    {
        private readonly Dictionary<string, List<SizeOccurrence>> oc = new();

        internal List<SizeOccurrence> GetOccurance(string fontName) =>
            oc.TryGetValue(fontName, out List<SizeOccurrence> s) ? s : null;

        internal void AddOccurance(string fontName, float size, int page, string instance)
        {
            if (oc.ContainsKey(fontName) == false)
            {
                oc.Add(fontName, new List<SizeOccurrence> { new(size, page, instance) });
            }
            else
            {
                SizeOccurrence o = oc[fontName].Find(s => s.Size == size);
                if (o != null)
                {
                    o.Occurrence++;
                }
                else
                {
                    oc[fontName].Add(new SizeOccurrence(size, page, instance));
                }
            }
        }
    }

    private sealed class TextToBookmarkProcessor : PdfContentStreamProcessor
    {
        private readonly AutoBookmarkContext _context;
        private readonly float _fontSizeThreshold;
        private readonly LevelProcessor _levelProcessor;

        //Rectangle _positionRectangle;
        private readonly bool _mergeAdjacentTitles;
        private readonly bool _mergeDifferentSizeTitles;
        private float _textWidth, _charWidth;

        public TextToBookmarkProcessor(AutoBookmarkOptions options, AutoBookmarkContext context)
        {
            _fontSizeThreshold = options.TitleThreshold;
            //_positionRectangle = options.PositionRectangle;
            _mergeAdjacentTitles = options.MergeAdjacentTitles;
            _mergeDifferentSizeTitles = options.MergeDifferentSizeTitles;
            _levelProcessor = new LevelProcessor(options.LevelAdjustment);
            TextList = new List<TextInfo>();
            PopulateOperators();
            RegisterContentOperator("TJ", new AccumulatedShowTextArray());
            _context = context;
        }

        /// <summary>
        ///     Get the text for page content.
        /// </summary>
        internal List<TextInfo> TextList { get; }

        /// <summary>
        ///     Get a list of fonts.
        /// </summary>
        internal IDictionary<int, string> FontList => Fonts;

        public Matrix RotationMatrix { get; set; }

        internal override void Reset()
        {
            base.Reset();
            TextList?.Clear();
        }

        protected override void DisplayPdfString(PdfString str)
        {
            GraphicsState gs = CurrentGraphicState;
            FontInfo font = gs.Font;
            char[] chars = font.DecodeText(str).ToCharArray();
            float totalWidth = 0, charWidth = 0;
            foreach (char c in chars)
            {
                float w = font.GetWidth(c) / 1000.0f;
                if (w == 0 && (font.CjkType & FontInfo.CjkFontType.CJK) > 0)
                {
                    w = c < 0xFF ? 0.5f : 1f;
                }

                float wordSpacing = c == ' ' ? gs.WordSpacing : 0f;
                if (char.IsLetterOrDigit(c))
                {
                    charWidth += w * gs.FontSize * gs.HorizontalScaling;
                }

                totalWidth += (w * gs.FontSize + gs.CharacterSpacing + wordSpacing) * gs.HorizontalScaling;
            }

            _textWidth = totalWidth;
            _charWidth = charWidth;
            AdjustTextMatrixX(totalWidth);
        }

        protected override void InvokeOperator(PdfLiteral oper, List<PdfObject> operands)
        {
            string o = oper.ToString();
            string text;
            float size;
            Matrix tm;
            switch (o)
            {
                case "TJ":
                    tm = GetTextMatrix();
                    size = GetFontSize(tm);
                    text = DecodeTJText(operands, size);
                    break;
                case "Tj":
                case "'":
                case "\"":
                    tm = GetTextMatrix();
                    size = GetFontSize(tm);
                    if (size < 0)
                    {
                        size = -size;
                    }

                    //if (size < _fontSizeThreshold) {
                    //    goto default;
                    //}
                    text = CurrentGraphicState.Font.DecodeText(operands[0] as PdfString);
                    break;
                default:
                    // Execute the default operation instruction
                    base.InvokeOperator(oper, operands);
                    return;
            }

            // Processing text
            base.InvokeOperator(oper, operands);
            //if (tm[Matrix.I12] != 0 || tm[Matrix.I21] != 0) {
            //    // Ignore non-lateral text
            //    goto Exit;
            //}
            if (size < 0.0001)
            {
                size = 0.0001f;
            }
            else
            {
                size = (float)Math.Round(size, 4);
            }

            TextInfo ti = new()
            {
                Text = text.Length > 1 ? text.TrimEnd(' ') : text,
                Size = size,
                Region = CreateBoundFromMatrix(tm, _textWidth, size),
                Font = CurrentGraphicState.Font,
                LetterWidth = _charWidth * tm[Matrix.I22]
            };
            if (ti.LetterWidth < 0)
            {
                ti.LetterWidth = -ti.LetterWidth;
            }

            if (IsBoundOutOfRectangle(_context.PageBox, ti.Region))
            {
                // Text falls outside the page
                goto Exit;
            }
            //TODO: Filter text
            //this._context.TextInfo = ti;
            //ti.Size = _levelProcessor.ChangeSizeLevel (this._context);
            //if (ti.Size < _fontSizeThreshold) {
            //    return;
            //}

            //if (_positionRectangle != null && ti.Region.Right < this._positionRectangle.Left
            //    || ti.Region.Top < this._positionRectangle.Top - this._positionRectangle.Height
            //    || ti.Region.Bottom > this._positionRectangle.Top
            //    || ti.Region.Left > this._positionRectangle.Right) {
            //    // Text outside the range box
            //    goto Exit;
            //}
            TextList.Add(ti);
        Exit:;
        }

        private string DecodeTJText(IList<PdfObject> operands, float size)
        {
            //if (size < _fontSizeThreshold) {
            //    goto default;
            //}
            PdfArray array = (PdfArray)operands[0];
            float d = size * CurrentGraphicState.HorizontalScaling * 4f / 1000f;
            string[] t = new string[array.Size];
            int i = 0;
            foreach (PdfObject item in array.ArrayList)
            {
                switch (item.Type)
                {
                    case PdfObject.STRING:
                        t[i++] = CurrentGraphicState.Font.DecodeText(item as PdfString);
                        break;
                    case PdfObject.NUMBER:
                        {
                            if (-(item as PdfNumber).FloatValue * d > size)
                            {
                                t[i++] = " ";
                            }

                            break;
                        }
                }
            }

            return string.Concat(t);
        }

        private float GetFontSize(Matrix tm)
        {
            float size = CurrentGraphicState.FontSize * tm[Matrix.I22];
            if (size < 0)
            {
                size = -size;
            }

            return size;
        }

        private Matrix GetTextMatrix() =>
            RotationMatrix != null
                ? RotationMatrix.Multiply(TextMatrix).Multiply(CurrentGraphicState.TransMatrix)
                : TextMatrix.Multiply(CurrentGraphicState.TransMatrix);

        private static Bound CreateBoundFromMatrix(Matrix tm, float textWidth, float size)
        {
            float l = tm[Matrix.I31];
            float b = tm[Matrix.I32];
            float r = tm[Matrix.I31] + textWidth * tm[Matrix.I11];
            float t = tm[Matrix.I32] + size;
            float x;
            if (l > r)
            {
                x = r;
                r = l;
                l = x;
            }

            if (!(b > t))
            {
                return new Bound(l, b, r, t);
            }

            x = t;
            t = b;
            b = x;

            return new Bound(l, b, r, t);
        }

        /// <summary>
        ///     Check if <paramref name="b" /> is within <paramref name="a".
        /// </summary>
        /// <param name="a">Big border.</param>
        /// <param name="b">Small border.</param>
        /// <returns>Small borders are completely in the bigide frame, then returns true.</returns>
        private static bool IsBoundOutOfRectangle(Rectangle a, Bound b) =>
            b.Right < a.Left
            || b.Top < a.Bottom
            || b.Bottom > a.Top
            || b.Left > a.Right;
    }

    private sealed class LevelProcessor
    {
        private readonly AutoBookmarkFilter[] _filters;
        private readonly AutoBookmarkOptions.LevelAdjustmentOption[] _options;

        internal LevelProcessor(IList<AutoBookmarkOptions.LevelAdjustmentOption> options)
        {
            int l = options.Count;
            _filters = new AutoBookmarkFilter[l];
            _options = new AutoBookmarkOptions.LevelAdjustmentOption[l];
            for (int i = 0; i < l; i++)
            {
                _filters[i] = options[i].Condition.CreateFilter();
                _options[i] = options[i];
            }
        }

        internal float ChangeSizeLevel(AutoBookmarkContext context)
        {
            for (int i = 0; i < _options.Length; i++)
            {
                AutoBookmarkOptions.LevelAdjustmentOption o = _options[i];
                if (o.FilterBeforeMergeTitle && context.IsTextMerged)
                {
                    continue;
                }

                if (_filters[i].Matches(context))
                {
                    return o.RelativeAdjustment ? o.AdjustmentLevel + context.TextInfo.Size : o.AdjustmentLevel;
                }
            }

            return context.TextInfo.Size;
        }
    }
}
