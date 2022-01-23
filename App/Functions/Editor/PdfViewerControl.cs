using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Cyotek.Windows.Forms;
using Cyotek.Windows.Forms.Demo;
using MuPdfSharp;
using PDFPatcher.Common;
using PDFPatcher.Functions.Editor;
using PDFPatcher.Model;
using PDFPatcher.Processor;
using PDFPatcher.Processor.Imaging;
using PDFPatcher.Properties;
using DrawingPoint = System.Drawing.Point;
using DrawingRectangle = System.Drawing.Rectangle;
using Matrix = System.Drawing.Drawing2D.Matrix;
using MuPoint = MuPdfSharp.Point;
using MuRectangle = MuPdfSharp.Rectangle;
using TextInfo = PDFPatcher.Functions.Editor.TextInfo;

namespace PDFPatcher.Functions;

internal sealed class PdfViewerControl : ImageBoxEx
{
    private static readonly IComparer<int> __horizontalComparer = ValueHelper.GetReverseComparer<int>();

    private static readonly int __pageMargin =
        (int)(TextRenderer.MeasureText("国", SystemFonts.MessageBoxFont).Height * 1.2d);

    private readonly Timer _refreshTimer;
    private readonly ImageRendererOptions _renderOptions;

    private readonly BackgroundWorker _renderWorker;

    /// <summary>
    ///     Cache the buffer of the page rendering result.
    /// </summary>
    private RenderResultCache _cache;

    private bool _cancelRendering;
    private ContentDirection _contentFlow;

    private PageRange _DisplayRange;

    private string _LiteralZoom;
    private bool _lockDown;
    private SizeF _maxDimension;
    private MuDocument _mupdf;
    private Dictionary<int, List<TextLine>> _ocrResults;

    /// <summary>
    ///     The size information of the page.
    /// </summary>
    private MuRectangle[] _pageBounds;

    /// <summary>
    ///     The scrolling position of the page.
    /// </summary>
    private int[] _pageOffsets;

    private DrawingPoint _PinPoint;
    private bool _ShowPinPoint;

    private bool _ShowTextBorders;
    private float _zoomFactor;

    private ZoomMode _zoomMode;

    public PdfViewerControl()
    {
        VirtualMode = true;
        VirtualSize = Size.Empty;
        PanMode = ImageBoxPanMode.Both;
        AllowUnfocusedMouseWheel = true;
        _renderOptions = new ImageRendererOptions();
        //_ViewBox.SelectionMode = ImageBoxSelectionMode.Rectangle;

        _refreshTimer = new Timer { Interval = 200 };
        _refreshTimer.Tick += (_, _) =>
        {
            for (int i = _DisplayRange.StartValue; i <= _DisplayRange.EndValue; i++)
            {
                bool v;
                lock (_cache.SyncObj)
                {
                    v = _cache.GetBitmap(i) != null;
                }

                if (v || _renderWorker.IsBusy)
                {
                    continue;
                }

                _renderWorker.RunWorkerAsync();
                return;
            }
        };

        _renderWorker = new BackgroundWorker { WorkerSupportsCancellation = true };
        _renderWorker.DoWork += (_, args) =>
        {
            Tracker.DebugMessage("started prerender job: " + _DisplayRange);
            _refreshTimer.Stop();
            for (int i = _DisplayRange.StartValue;
                 i >= _DisplayRange.StartValue && i < _DisplayRange.EndValue + 2;
                 i++)
            {
                if (i < 1 || i > _mupdf.PageCount)
                {
                    continue;
                }

                if (_cancelRendering || _renderWorker.CancellationPending || _mupdf.IsDocumentOpened == false)
                {
                    _cancelRendering = false;
                    args.Cancel = true;
                    return;
                }

                if (_cache.GetBitmap(i) != null)
                {
                    continue;
                }

                lock (_cache.SyncObj)
                {
                    MuRectangle pb = _pageBounds[i];
                    Tracker.DebugMessage("load page " + i);
                    float z = GetZoomFactorForPage();
                    RenderPage(i, (pb.Width * z).ToInt32(), (pb.Height * z).ToInt32());
                    if (_DisplayRange.Contains(i))
                    {
                        Invalidate();
                    }
                }
            }
        };
        _renderWorker.RunWorkerCompleted += (_, _) =>
        {
            if (_cancelRendering == false)
            {
                _refreshTimer.Start();
            }
        };
    }

    /// <summary>
    ///     Gets or sets the displayed focus page.
    /// </summary>
    [DefaultValue(0)]
    public int CurrentPageNumber
    {
        get => HorizontalFlow ? _DisplayRange.EndValue : _DisplayRange.StartValue;
        set
        {
            if (value == CurrentPageNumber)
            {
                return;
            }

            ShowPage(value);
        }
    }

    /// <summary>
    ///     Get the currently visible first page.
    /// </summary>
    [Browsable(false)]
    public int FirstPage => _DisplayRange.StartValue;

    /// <summary>
    ///     Get text identification options.
    /// </summary>
    [Browsable(false)]
    public OcrOptions OcrOptions { get; } = new();

    /// <summary>
    ///     Get or set the display amplification ratio.
    /// </summary>
    [Browsable(false)]
    public string LiteralZoom
    {
        get => _LiteralZoom;
        set
        {
            if (value == null || !ChangeZoom(value))
            {
                return;
            }

            _LiteralZoom = value;
            ZoomChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public new float ZoomFactor => _zoomFactor * 72f / _renderOptions.Dpi;

    /// <summary>
    ///     Get or set up the reader to use the horizontal scroll mode of right to left.
    /// </summary>
    [DefaultValue(ContentDirection.TopToDown)]
    public ContentDirection ContentDirection
    {
        get => _contentFlow;
        set
        {
            if (value == _contentFlow)
            {
                return;
            }

            PagePosition pp = PagePosition.Empty;
            if (HorizontalScroll.Value != 0 || VerticalScroll.Value != 0)
            {
                pp = TransposeVirtualImageToPagePosition(HorizontalScroll.Value, VerticalScroll.Value);
            }

            Selection s = GetSelection();
            _contentFlow = value;
            UpdateDisplay(true);
            if (s.ImageRegion.IsEmpty == false)
            {
                RectangleF r = s.ImageRegion;
                DrawingPoint p = GetVirtualImageOffset(s.Page);
                r = new RectangleF(p.X + r.Left, p.Y + r.Top, r.Width, r.Height);
                SelectionRegion = r;
            }

            if (pp.Page <= 0)
            {
                return;
            }

            if (_zoomMode == ZoomMode.FitPage)
            {
                ShowPage(pp.Page);
            }
            else
            {
                ScrollToPosition(pp);
            }
        }
    }

    public bool HorizontalFlow => _contentFlow != ContentDirection.TopToDown;

    /// <summary>
    ///     Get or set up whether the reader renders the page as a grayscale image.
    /// </summary>
    [DefaultValue(false)]
    public bool GrayScale
    {
        get => _renderOptions.ColorSpace == ColorSpace.Gray;
        set
        {
            ColorSpace v = value ? ColorSpace.Gray : ColorSpace.Rgb;
            if (_renderOptions.ColorSpace == v)
            {
                return;
            }

            _renderOptions.ColorSpace = v;
            UpdateDisplay();
        }
    }

    /// <summary>
    ///     Gets or sets whether the reader renders the page as the effect of reversing the color.
    /// </summary>
    [DefaultValue(false)]
    public bool InvertColor
    {
        get => _renderOptions.InvertColor;
        set
        {
            if (_renderOptions.InvertColor == value)
            {
                return;
            }

            _renderOptions.InvertColor = value;
            UpdateDisplay();
        }
    }

    public Color TintColor
    {
        get => _renderOptions.TintColor;
        set
        {
            if (_renderOptions.TintColor == value)
            {
                return;
            }

            _renderOptions.TintColor = value;
            UpdateDisplay();
        }
    }

    [DefaultValue(false)]
    public bool HideAnnotations
    {
        get => _renderOptions.HideAnnotations;
        set
        {
            if (_renderOptions.HideAnnotations == value)
            {
                return;
            }

            _renderOptions.HideAnnotations = value;
            UpdateDisplay();
        }
    }

    /// <summary>
    ///     Gets or sets the mouse mode of the reader.
    /// </summary>
    [DefaultValue(MouseMode.Move)]
    public MouseMode MouseMode
    {
        get => PanMode != ImageBoxPanMode.None ? MouseMode.Move : MouseMode.Selection;
        set
        {
            if (value == MouseMode.Move)
            {
                PanMode = ImageBoxPanMode.Both;
                AllowZoom = false;
                SelectionMode = ImageBoxSelectionMode.None;
                SelectionRegion = RectangleF.Empty;
            }
            else
            {
                PanMode = ImageBoxPanMode.Both;
                AllowZoom = false;
                SelectionMode = ImageBoxSelectionMode.Rectangle;
            }
        }
    }

    [DefaultValue(false)] public bool FullPageScroll { get; set; }

    [Description("Specify mouse positioning point")]
    public DrawingPoint PinPoint
    {
        get => _PinPoint;
        set
        {
            if (_PinPoint == value)
            {
                return;
            }

            _PinPoint = value;
            if (IsPinPointVisible && DesignMode == false)
            {
                Invalidate();
            }
        }
    }

    [DefaultValue(false)]
    [Description("Specifies whether to display mouse positioning points")]
    public bool ShowPinPoint
    {
        get => _ShowPinPoint;
        set
        {
            if (_ShowPinPoint == value)
            {
                return;
            }

            _ShowPinPoint = value;
            if (IsPinPointVisible && DesignMode == false)
            {
                Invalidate();
            }
        }
    }

    private bool IsPinPointVisible
    {
        get
        {
            if (PinPoint == DrawingPoint.Empty)
            {
                return false;
            }

            DrawingPoint op = GetOffsetPoint(0, 0);
            DrawingRectangle vp = GetImageViewPort();
            DrawingPoint pp = PinPoint;
            pp.Offset(op);
            return vp.Contains(pp);
        }
    }

    [DefaultValue(false)]
    [Description("Display the border of the text layer")]
    public bool ShowTextBorders
    {
        get => _ShowTextBorders;
        set
        {
            if (_ShowTextBorders == value)
            {
                return;
            }

            _ShowTextBorders = value;
            if (DesignMode == false)
            {
                Invalidate();
            }
        }
    }

    [DefaultValue(0)]
    [Description("Specifies the language used to identify the text")]
    public int OcrLanguage
    {
        get => OcrOptions.OcrLangID;
        set
        {
            if (OcrOptions.OcrLangID == value)
            {
                return;
            }

            OcrOptions.OcrLangID = value;
            _ocrResults.Clear();
        }
    }

    [Description("Specify the PDF document you want to display")]
    [Browsable(false)]
    [DefaultValue(null)]
    public MuDocument Document
    {
        get => _mupdf;
        set
        {
            Enabled = false;
            InitViewer();
            _mupdf = value;
            if (value == null)
            {
                return;
            }

            Tracker.DebugMessage("Load document.");
            int l = _mupdf.PageCount + 1;
            _pageOffsets = new int[l];
            _pageBounds = new MuRectangle[l];
            LoadPageBounds();
            _cache = new RenderResultCache(_mupdf);
            Tracker.DebugMessage("Calculating document virtual size.");
            CalculateZoomFactor(_LiteralZoom);
            CalculateDocumentVirtualSize();
            ShowPage(1);
            _refreshTimer.Start();
            if (_renderWorker.IsBusy == false)
            {
                _renderWorker.RunWorkerAsync();
            }

            DocumentLoaded?.Invoke(this, EventArgs.Empty);
            Enabled = true;
        }
    }

    public event EventHandler DocumentLoaded;
    public new event EventHandler ZoomChanged;
    public event EventHandler<PageChangedEventArgs> PageChanged;
    public event EventHandler<SelectionChangedEventArgs> SelectionChanged;

    protected override void OnCreateControl()
    {
        base.OnCreateControl();
        using Graphics g = CreateGraphics();
        _renderOptions.Dpi = g.DpiX;
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        if (SelectionRegion.IsEmpty == false && (IsResizing || IsSelecting || IsMoving) &&
            e.Button == MouseButtons.Left)
        {
            LimitSelectionInPage(e.Location);
        }
    }

    //        protected override void SetCursor (DrawingPoint point) {
    //            if (IsPanning) {
    //                return;
    //            }
    //#if DEBUG
    //            if (!IsResizing || !IsSelecting) {
    //                var p = TransposeClientToPageImage (point.X, point.Y);
    //                if (p.ImageY < 0) {
    //                    this.Cursor = Cursors.Hand;
    //                    return;
    //                }
    //            }
    //#endif
    //            base.SetCursor (point);
    //        }

    protected override void OnSelectionRegionChanged(EventArgs e)
    {
        base.OnSelectionRegionChanged(e);
        if (_mupdf == null || MouseMode == MouseMode.Move || SelectionChanged == null)
        {
            return;
        }

        SelectionChanged(this, new SelectionChangedEventArgs(GetSelection()));
    }

    protected override void OnClientSizeChanged(EventArgs e)
    {
        base.OnClientSizeChanged(e);
        if (_zoomMode == ZoomMode.Custom || _lockDown)
        {
            return;
        }

        if (ChangeZoom(LiteralZoom) && ZoomChanged != null)
        {
            ZoomChanged(this, EventArgs.Empty);
        }

        //CalculateDocumentVirtualSize ();
        Invalidate();
    }

    private void LimitSelectionInPage(DrawingPoint location)
    {
        RectangleF r = SelectionRegion;
        PagePosition pp = TransposeClientToPagePosition(location.X, location.Y);
        DrawingPoint p = GetVirtualImageOffset(pp.Page);
        Tracker.DebugMessage(pp.Location.ToString());
        r.Offset(-p.X, -p.Y);
        MuRectangle b = _pageBounds[pp.Page];
        float z = GetZoomFactorForPage();

        float x1 = r.Left, y1 = r.Top, x2 = r.Right, y2 = r.Bottom;
        bool c = false;
        if (r.Left < 0)
        {
            x1 = 0;
            x2 -= r.Left;
            c = true;
        }

        if (r.Top < 0)
        {
            y1 = 0;
            y2 -= r.Top;
            c = true;
        }

        if (r.Right > b.Width * z)
        {
            x2 = b.Width * z;
            x1 -= r.Right - b.Width * z;
            if (x1 < 0)
            {
                x1 = 0;
            }

            c = true;
        }

        if (r.Bottom > b.Height * z)
        {
            y2 = b.Height * z;
            y1 -= r.Bottom - b.Height * z;
            if (y1 < 0)
            {
                y1 = 0;
            }

            c = true;
        }

        if (c)
        {
            SelectionRegion = new MuRectangle(p.X + x1, p.Y + y1, p.X + x2, p.Y + y2);
        }
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        switch (keyData)
        {
            case Keys.Space:
            case Keys.PageDown:
                if (FullPageScroll)
                {
                    ExecuteCommand("_NextPage");
                    return true;
                }

                if (HorizontalFlow)
                {
                    ScrollTo(HorizontalScroll.Value - (GetInsideViewPort().Width * 0.95).ToInt32(),
                        VerticalScroll.Value);
                }
                else
                {
                    ScrollTo(HorizontalScroll.Value,
                        VerticalScroll.Value + (GetInsideViewPort().Height * 0.95).ToInt32());
                }

                return true;
            case Keys.PageUp:
                if (FullPageScroll)
                {
                    ExecuteCommand("_PreviousPage");
                    return true;
                }

                if (HorizontalFlow)
                {
                    ScrollTo(HorizontalScroll.Value + (GetInsideViewPort().Width * 0.95).ToInt32(),
                        VerticalScroll.Value);
                }
                else
                {
                    ScrollTo(HorizontalScroll.Value,
                        VerticalScroll.Value - (GetInsideViewPort().Height * 0.95).ToInt32());
                }

                return true;
            case Keys.Home:
                ShowPage(1);
                return true;
            case Keys.End:
                if (_mupdf != null)
                {
                    ShowPage(_mupdf.PageCount);
                }

                return true;
        }

        return base.ProcessCmdKey(ref msg, keyData);
    }

    protected override void OnMouseWheel(MouseEventArgs e)
    {
        base.OnMouseWheel(e);
        if (HorizontalFlow)
        {
            ScrollTo(HorizontalScroll.Value + e.Delta, VerticalScroll.Value);
        }
        else
        {
            ScrollTo(HorizontalScroll.Value, VerticalScroll.Value - e.Delta);
        }
    }

    internal void CloseFile()
    {
        if (_mupdf == null)
        {
            return;
        }

        _cache.Clear();
        _mupdf.ReleaseFile();
    }

    internal void Reopen()
    {
        if (_mupdf is not { IsDocumentOpened: false })
        {
            return;
        }

        _mupdf.Reopen();
        UpdateDisplay(true);
    }

    protected override void OnVirtualDraw(PaintEventArgs e)
    {
        base.OnVirtualDraw(e);

        if (VirtualSize.IsEmpty || Enabled == false)
        {
            return;
        }

        _DisplayRange = GetDisplayingPageRange();
        int p = _DisplayRange.StartValue;
        PageChanged?.Invoke(this, new PageChangedEventArgs(p));
        Graphics g = e.Graphics;
        DrawingPoint op = GetOffsetPoint(0, 0); // Offset location point
        DrawingRectangle vp = GetImageViewPort();
        if (TintColor == Color.Transparent)
        {
            g.FillRectangle(Brushes.FloralWhite, vp);
        }
        else
        {
            using SolidBrush b = new(Color.Gainsboro.Tint(TintColor));
            g.FillRectangle(b, vp);
        }

        DrawingRectangle r;
        do
        {
            Debug.Assert(p > 0 && p < _mupdf.PageCount + 1, p.ToString());
            MuRectangle pb = _pageBounds[p];
            float z = GetZoomFactorForPage();
            int ox = HorizontalFlow ? _pageOffsets[p] : 0;
            int oy = HorizontalFlow ? 0 : _pageOffsets[p];
            r = new DrawingRectangle(
                ox + op.X + __pageMargin,
                oy + op.Y + __pageMargin,
                (pb.Width * z).ToInt32(),
                (pb.Height * z).ToInt32()
            );
            string pl = GetPageLabel(p);
            TextRenderer.DrawText(e.Graphics,
                string.Concat(pl, pl.Length > 0 ? " / 第 " : "第 ", p, " 页 (", pb.Width, " * ", pb.Height, ")"),
                SystemFonts.MessageBoxFont,
                new DrawingPoint(ox + op.X + __pageMargin, oy + op.Y),
                Color.Black);
            Bitmap bmp = _cache.GetBitmap(p);
            if (bmp == null)
            {
                g.FillRectangle(Brushes.White, r);
                if (_renderWorker.IsBusy == false)
                {
                    _renderWorker.RunWorkerAsync();
                }
            }
            else
            {
                g.DrawImage(bmp, r.Location);
            }

            g.DrawRectangle(Pens.Black, r.Left - 1, r.Top - 1, r.Width + 1, r.Height + 1);
            if (ShowTextBorders)
            {
                DrawTextBorders(g, p, op);
            }
        } while ((HorizontalFlow ? r.Right > 0 : r.Bottom < vp.Height)
                 && ++p < _pageOffsets.Length);

        if (ShowPinPoint && PinPoint != DrawingPoint.Empty)
        {
            DrawingPoint pp = PinPoint.Transpose(op);
            if (vp.Contains(pp))
            {
                g.DrawImage(Resources.Pin, pp.X, pp.Y - Resources.Pin.Height);
            }
        }

        if (_cache.GetBitmap(p + 1) == null && _renderWorker.IsBusy == false)
        {
            _renderWorker.RunWorkerAsync();
        }
    }

    private string GetPageLabel(int pageNumber) =>
        _mupdf.IsDocumentOpened == false ? string.Empty : _mupdf.PageLabels.Format(pageNumber);

    private PageRange GetDisplayingPageRange()
    {
        DrawingRectangle b = GetOffsetRectangle(GetImageViewPort());
        return new PageRange(GetPageNumberFromOffset(-b.Left + b.Width, -b.Y),
            GetPageNumberFromOffset(-b.Left, -(b.Y - b.Height)));
    }

    private void DrawTextBorders(Graphics g, int pageNumber, DrawingPoint offset)
    {
        if (_mupdf.IsDocumentOpened == false)
        {
            return;
        }

        lock (_mupdf.SyncObj)
        {
            MuPage p = _cache.LoadPage(pageNumber);
            float z = GetZoomFactorForPage();
            DrawingPoint o = GetVirtualImageOffset(pageNumber);
            using (Pen spanPen = new(Color.LightGray, 1))
            using (Pen blockPen = new(Color.Gray, 1))
            {
                blockPen.DashStyle = DashStyle.Dash;
                spanPen.DashStyle = DashStyle.Dash;
                using (Matrix m = new(z, 0, 0, z, offset.X + o.X, offset.Y + o.Y))
                {
                    g.MultiplyTransform(m);
                }

                foreach (MuTextBlock block in p.TextPage.Blocks)
                {
                    g.DrawRectangle(blockPen, block.BBox);

                    foreach (MuTextLine line in block.Lines)
                    {
                        g.DrawRectangle(spanPen, line.BBox);
                    }
                }
            }

            g.ResetTransform();
        }
    }

    /// <summary>
    ///     Returns the selected area.
    /// </summary>
    /// <returns>The selected rectangular area.</returns>
    internal Selection GetSelection()
    {
        PageRegion s = GetSelectionPageRegion();
        if (s.Page == 0 || _mupdf.IsDocumentOpened == false)
        {
            return Selection.Empty;
        }

        lock (_mupdf.SyncObj)
        {
            MuRectangle vb = _pageBounds[s.Page];
            MuRectangle sr = s.Region;
            MuRectangle pr = new(sr.Left - vb.Left, vb.Bottom - sr.Top, sr.Right - vb.Left, vb.Bottom - sr.Bottom);
            DrawingPoint o = GetVirtualImageOffset(s.Page);
            RectangleF area = SelectionRegion;
            area.Offset(-o.X, -o.Y);
            return new Selection(_cache, s.Page, pr, area);
        }
    }

    internal PageRegion GetSelectionPageRegion()
    {
        RectangleF area = SelectionRegion;
        if (area.IsEmpty)
        {
            return PageRegion.Empty;
        }

        GetOffsetRectangle(GetImageViewPort());
        PagePosition p1 = TransposeVirtualImageToPagePosition(area.Left.ToInt32(), area.Top.ToInt32());
        PagePosition p2 = TransposeVirtualImageToPagePosition(area.Right.ToInt32(), area.Bottom.ToInt32());
        return new PageRegion(p1, p2);
    }

    /// <summary>
    ///     Returns the text row of the specified location and the subsequent text line with the same style as the text.
    /// </summary>
    /// <param name="position">Find the location of the text line.</param>
    /// <returns>Returns the text row of the specified location and the subsequent text line with the same style as the text.</returns>
    internal TextInfo FindTextLines(PagePosition position)
    {
        MuRectangle rect = new();
        TextInfo ti = new();
        if (_mupdf.IsDocumentOpened == false)
        {
            return ti;
        }

        lock (_mupdf.SyncObj)
        {
            MuPage page = _cache.LoadPage(position.Page);
            MuPoint point = position.Location.ToPageCoordinate(page.VisualBound);
            if (page.VisualBound.Contains(point) == false
                || page.TextPage.BBox.Contains(point) == false)
            {
                return ti;
            }

            foreach (MuTextBlock block in page.TextPage.Blocks)
            {
                if (block.Type != ContentBlockType.Text || block.BBox.Contains(point) == false)
                {
                    continue;
                }

                HashSet<IntPtr> s = null;
                MuTextLine l = null;
                List<MuTextLine> r = null;
                foreach (MuTextLine line in block.Lines)
                {
                    if (l == null)
                    {
                        if (line.BBox.Contains(point) == false)
                        {
                            continue;
                        }

                        s = new HashSet<IntPtr>(); // Get text style collection of selected text rows
                        r = new List<MuTextLine>();
                        foreach (MuTextChar ch in line.Characters)
                        {
                            s.Add(ch.FontID);
                        }

                        rect = line.BBox;
                        l = line;
                        r.Add(l);
                    }
                    else
                    {
                        if (line.BBox.Top - l.BBox.Bottom > line.BBox.Height)
                        {
                            break;
                        }

                        // Get adjacency texts with the same style
                        foreach (MuTextChar ch in line.Characters)
                        {
                            if (!s.Contains(ch.FontID))
                            {
                                continue;
                            }

                            r.Add(line);
                            l = line;
                            goto NEXT;
                        }
                    }

                NEXT:;
                }

                if (l == null)
                {
                    continue;
                }

                List<MuTextSpan> spans = new(r.Count * 2);
                foreach (MuTextLine item in r)
                {
                    spans.AddRange(item.Spans);
                }

                return new TextInfo(page, rect, r, spans);
            }
        }

        return ti;
    }

    /// <summary>
    ///     Returns the text line in the specified area.
    /// </summary>
    /// <param name="region">Selected area.</param>
    /// <returns>Text line in the area.</returns>
    internal List<MuTextLine> FindTextLines(PageRegion region)
    {
        if (_mupdf.IsDocumentOpened == false)
        {
            return null;
        }

        lock (_mupdf.SyncObj)
        {
            MuPage page = _cache.LoadPage(region.Page);
            MuRectangle pr = region.Region.ToPageCoordinate(page.VisualBound);
            if (pr.Intersect(page.VisualBound).IsEmpty)
            {
                return null;
            }

            if (pr.Intersect(page.TextPage.BBox).IsEmpty)
            {
                return null;
            }

            foreach (MuTextBlock block in page.TextPage.Blocks)
            {
                if (block.Type != ContentBlockType.Text || pr.Intersect(block.BBox).IsEmpty)
                {
                    continue;
                }

                return block.Lines.Where(line => pr.Intersect(line.BBox).IsEmpty == false).ToList();
            }
        }

        return null;
    }

    private float GetZoomFactorForPage() => _zoomFactor;

    public List<TextLine> OcrPage(int pageNumber, bool cached)
    {
        if (cached && _ocrResults.TryGetValue(pageNumber, out List<TextLine> r))
        {
            return r;
        }

        r = Ocr(pageNumber);
        return _ocrResults[pageNumber] = r;
    }

    public string[] CleanUpOcrResult(List<TextLine> result) =>
        result.ConvertAll(t => OcrProcessor.CleanUpText(t.Text, OcrOptions)).ToArray();

    private List<TextLine> Ocr(int pageNumber)
    {
        try
        {
            Bitmap bmp = GetPageImage(pageNumber);
            return OcrProcessor.OcrBitmap(bmp, OcrOptions);
        }
        catch (COMException ex)
        {
            switch (ex.ErrorCode)
            {
                case -959971327:
                    FormHelper.InfoBox("识别引擎初始化时遇到错误。\n请尝试以管理员身份运行程序，或重新安装 Office 2007 的 MODI 组件。");
                    return new List<TextLine>();
                case -959967087:
                    FormHelper.ErrorBox("识别引擎无法识别本页文本。请尝试调整页面的显示比例，然后再执行识别。");
                    return new List<TextLine>();
                default:
                    throw;
            }
        }
        catch (Exception ex)
        {
            Tracker.DebugMessage("OCR error: " + ex.Message);
            return null;
        }
    }

    public Bitmap GetPageImage(int pageNumber)
    {
        MuRectangle b = _pageBounds[pageNumber];
        float z = GetZoomFactorForPage();
        return RenderPage(pageNumber, (z * b.Width).ToInt32(), (z * b.Height).ToInt32());
    }

    public MuRectangle GetPageBound(int pageNumber) => _pageBounds[pageNumber];

    private Bitmap RenderPage(int pageNumber, int width, int height)
    {
        Bitmap bmp = _cache.GetBitmap(pageNumber);
        if (bmp != null)
        {
            return bmp;
        }

        if (_mupdf == null || _mupdf.IsDocumentOpened == false || Enabled == false)
        {
            return null;
        }

        lock (_mupdf.SyncObj)
        {
            MuPage p = _cache.LoadPage(pageNumber);
            if (pageNumber < _DisplayRange.StartValue - 1 || pageNumber > _DisplayRange.EndValue + 1)
            {
                return null;
            }

            Tracker.DebugMessage("render page " + pageNumber);
            bmp = p.RenderBitmapPage(width, height, _renderOptions);
            _cache.AddBitmap(pageNumber, bmp);
        }

        return bmp;
    }

    private int GetPageNumberFromOffset(int offsetX, int offsetY)
    {
        if (_mupdf == null)
        {
            return 0;
        }

        int p = HorizontalFlow
            ? Array.BinarySearch(_pageOffsets, 1, _pageOffsets.Length - 1, offsetX, __horizontalComparer)
            : Array.BinarySearch(_pageOffsets, 1, _pageOffsets.Length - 1, offsetY);
        if (p < 0)
        {
            p = ~p;
            if (HorizontalFlow == false)
            {
                --p;
            }
        }

        if (p >= _pageOffsets.Length)
        {
            return _pageOffsets.Length - 1;
        }

        return p < 1 ? 1 : p;
    }

    private bool ChangeZoom(string zoomMode)
    {
        Selection s = GetSelection();
        PagePosition pp = PagePosition.Empty;
        float z = 0;
        if (s.Page > 0)
        {
            z = GetZoomFactorForPage();
        }

        if (HorizontalScroll.Value != 0 || VerticalScroll.Value != 0)
        {
            pp = TransposeVirtualImageToPagePosition(HorizontalScroll.Value, VerticalScroll.Value);
        }

        if (CalculateZoomFactor(zoomMode) == false)
        {
            return false;
        }

        if (_mupdf == null)
        {
            return false;
        }

        UpdateDisplay(true);
        // Keep the size ratio of the selection
        if (z > 0)
        {
            RectangleF r = s.ImageRegion;
            DrawingPoint p = GetVirtualImageOffset(s.Page);
            z = _zoomFactor / z;
            r = new RectangleF(p.X + r.Left * z, p.Y + r.Top * z, r.Width * z, r.Height * z);
            SelectionRegion = r;
        }

        if (pp.Page <= 0)
        {
            return true;
        }

        if (_zoomMode == ZoomMode.FitPage)
        {
            ShowPage(pp.Page);
        }
        else
        {
            ScrollToPosition(pp);
        }

        return true;
    }

    private bool CalculateZoomFactor(string zoomMode)
    {
        switch (zoomMode)
        {
            case Constants.DestinationAttributes.ViewType.Fit:
                _zoomMode = ZoomMode.FitPage;
                _zoomFactor = Math.Min(
                    (GetInsideViewPort().Width - __pageMargin - __pageMargin) / _maxDimension.Width,
                    (GetInsideViewPort().Height - __pageMargin - __pageMargin) / _maxDimension.Height
                );
                break;
            case Constants.DestinationAttributes.ViewType.FitH:
                _zoomMode = ZoomMode.FitHorizontal;
                _zoomFactor = (GetInsideViewPort().Width - __pageMargin - __pageMargin) / _maxDimension.Width;
                break;
            case Constants.DestinationAttributes.ViewType.FitV:
                _zoomMode = ZoomMode.FitVertical;
                _zoomFactor = (GetInsideViewPort().Height - __pageMargin - __pageMargin) / _maxDimension.Height;
                break;
            default:
                int f;
                if (zoomMode.EndsWith("%", StringComparison.Ordinal) && zoomMode.Length > 2)
                {
                    f = zoomMode.Substring(0, zoomMode.Length - 1).ToInt32();
                }
                else if (zoomMode.Length > 1)
                {
                    f = zoomMode.ToInt32();
                }
                else
                {
                    return false;
                }

                if (f == 0)
                {
                    return false;
                }

                _zoomMode = ZoomMode.Custom;
                _zoomFactor = f / 100f * _renderOptions.Dpi / 72f;
                break;
        }

        return true;
    }

    private void UpdateDisplay(bool resized = false)
    {
        if (DesignMode)
        {
            return;
        }

        _refreshTimer.Stop();
        _renderWorker.CancelAsync();
        _cancelRendering = true;
        if (_cache != null)
        {
            lock (_mupdf.SyncObj)
            {
                lock (_cache.SyncObj)
                {
                    _cache.Clear();
                }
            }
        }

        _ocrResults.Clear();
        _cancelRendering = false;
        _refreshTimer.Start();
        if (resized)
        {
            //var p = FirstPage;
            CalculateDocumentVirtualSize();
            //ShowPage (p);
        }
    }

    private int GetPageFullWidth(float pageWidth) => __pageMargin + __pageMargin + (pageWidth * _zoomFactor).ToInt32();

    private int GetPageFullHeight(float pageHeight) =>
        __pageMargin + __pageMargin + (pageHeight * _zoomFactor).ToInt32();

    private void ShowPage(int pageNumber)
    {
        if (_mupdf == null || _pageOffsets == null)
        {
            return;
        }

        if (pageNumber < 0)
        {
            pageNumber = _mupdf.PageCount + pageNumber + 1;
        }

        if (pageNumber <= 0 || pageNumber > _mupdf.PageCount)
        {
            return;
        }

        _DisplayRange.StartValue = pageNumber;
        try
        {
            if (HorizontalFlow)
            {
                ScrollTo(_pageOffsets[pageNumber], VerticalScroll.Value);
            }
            else
            {
                ScrollTo(HorizontalScroll.Value, _pageOffsets[pageNumber]);
            }
        }
        catch (Exception ex)
        {
            FormHelper.ErrorBox(ex.Message);
        }

        //if (PageChanged != null) {
        //	PageChanged (this, new PageChangedEventArgs (pageNumber));
        //}
    }

    internal void ScrollToPosition(PagePosition position)
    {
        DrawingPoint op = GetVirtualImageOffset(position.Page);
        MuPoint l = position.Location.ToPageCoordinate(_pageBounds[position.Page]);
        float z = GetZoomFactorForPage();
        bool h = HorizontalFlow;
        ScrollTo(
            position.PageX == 0 && h == false ? HorizontalScroll.Value : (l.X * z).ToInt32() + op.X,
            position.PageY == 0 && h
                ? VerticalScroll.Value
                : (position.Location.Y == 0 ? 0 : (l.Y * z).ToInt32()) + op.Y
        );
    }

    private void Next(int deltaPageNumber) => ShowPage(CurrentPageNumber + deltaPageNumber);

    private void LoadPageBounds()
    {
        float w = 0, h = 0;
        for (int i = _mupdf.PageCount; i > 0; i--)
        {
            using MuPage p = _mupdf.LoadPage(i);
            MuRectangle b = p.VisualBound;
            _pageBounds[i] = b;
            if (b.Width > w)
            {
                w = b.Width;
            }

            if (b.Height > h)
            {
                h = b.Height;
            }
        }

        _maxDimension = new SizeF(w, h);
    }

    private void CalculateDocumentVirtualSize()
    {
        if (_pageOffsets == null || _pageBounds == null)
        {
            return;
        }

        int h = 0, w = 0;
        int l = _mupdf.PageCount + 1;
        Size vs = GetInsideViewPort().Size;
        _lockDown = true;
        if (HorizontalFlow)
        {
            lock (_mupdf.SyncObj)
            {
                for (int i = l - 1; i >= 0; i--)
                {
                    MuRectangle b = _pageBounds[i];
                    _pageOffsets[i] = w;
                    w += GetPageFullWidth(b.Width);
                    if (b.Height > h)
                    {
                        h = b.Height.ToInt32();
                    }
                }

                int w1 = GetPageFullWidth(_pageBounds[1].Width);
                if (w1 < vs.Width)
                {
                    w += vs.Width - w1;
                }
            }

            VirtualSize = new Size(w, GetPageFullHeight(h));
        }
        else
        {
            lock (_mupdf.SyncObj)
            {
                for (int i = 1; i < l; i++)
                {
                    MuRectangle b = _pageBounds[i];
                    _pageOffsets[i] = h;
                    h += GetPageFullHeight(_pageBounds[i].Height);
                    if (b.Width > w)
                    {
                        w = b.Width.ToInt32();
                    }
                }

                int h1 = GetPageFullHeight(_pageBounds[1].Height);
                if (h1 < vs.Height)
                {
                    h += vs.Height - h1;
                }
            }

            VirtualSize = new Size(GetPageFullWidth(w), h);
        }

        _lockDown = false;
    }

    public void ExecuteCommand(string cmd)
    {
        switch (cmd)
        {
            case "_FirstPage":
                ShowPage(1);
                break;
            case "_PreviousPage":
                Next(-1);
                break;
            case "_NextPage":
                Next(1);
                break;
            case "_LastPage":
                ShowPage(-1);
                break;
            case "_ScrollVertical":
                ContentDirection = ContentDirection.TopToDown;
                break;
            case "_ScrollHorizontal":
                ContentDirection = ContentDirection.RightToLeft;
                break;
            case "_TrueColorSpace":
                GrayScale = false;
                break;
            case "_GrayColorSpace":
                GrayScale = true;
                break;
            case "_InvertColor":
                InvertColor = !InvertColor;
                break;
            case "_Refresh":
                UpdateDisplay();
                break;
        }
    }

    public void InitViewer()
    {
        _cancelRendering = true;
        _refreshTimer.Stop();
        SelectionRegion = DrawingRectangle.Empty;
        _DisplayRange = new PageRange();
        if (_LiteralZoom == null)
        {
            _zoomFactor = _renderOptions.Dpi / 72;
            _zoomMode = ZoomMode.FitHorizontal;
            _LiteralZoom = Constants.DestinationAttributes.ViewType.FitH;
            VirtualSize = new Size(1, 1);
        }

        ShowTextBorders = false;
        _pageBounds = null;
        _pageOffsets = null;
        if (_cache != null)
        {
            lock (_cache.SyncObj)
            {
                _cache.Clear();
            }
        }

        _contentFlow = ContentDirection.TopToDown;
        OcrOptions.CompressWhiteSpaces = true;
        _ocrResults = new Dictionary<int, List<TextLine>>();
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        Tracker.DebugMessage("PDF Viewer control destroyed.");
        _cancelRendering = true;
        _mupdf?.AbortAsync();
        _refreshTimer.Stop();
        if (_cache != null)
        {
            _renderWorker.CancelAsync();
            lock (_cache.SyncObj)
            {
                _cache.Dispose();
            }
        }

        _renderWorker.Dispose();
        _refreshTimer.Dispose();
    }

    private enum ZoomMode
    {
        Custom,
        FitPage = -1,
        FitHorizontal = -2,
        FitVertical = -3
    }

    internal sealed class PageChangedEventArgs : EventArgs
    {
        public PageChangedEventArgs(int pageNumber) => PageNumber = pageNumber;

        public int PageNumber { get; }
    }

    internal sealed class SelectionChangedEventArgs : EventArgs
    {
        public SelectionChangedEventArgs(Selection selection) => Selection = selection;

        public Selection Selection { get; }
    }

    #region Coordinate conversion

    internal bool IsClientPointInSelection(DrawingPoint point) => SelectionRegion.Contains(PointToImage(point));

    internal RectangleF MuRectangleToImageRegion(int pageNumber, MuRectangle box)
    {
        bool rtl = HorizontalFlow;
        int o = _pageOffsets[pageNumber];
        float z = _zoomFactor;
        if (rtl)
        {
            return new RectangleF(o + __pageMargin + box.Left * z, box.Top * z + __pageMargin, box.Width * z,
                box.Height * z);
        }

        return new RectangleF(box.Left * z + __pageMargin, box.Top * z + __pageMargin + o, box.Width * z,
            box.Height * z);
    }

    /// <summary>
    ///     Convert the position of the screen customer area to page coordinates.
    /// </summary>
    /// <param name="clientX">X-axis.</param>
    /// <param name="clientY">Y-axis.</param>
    /// <returns>Page coordinates.</returns>
    internal PagePosition TransposeClientToPagePosition(int clientX, int clientY)
    {
        if (_DisplayRange.StartValue <= 0 || _pageBounds == null)
        {
            return PagePosition.Empty;
        }

        DrawingPoint p = PointToImage(clientX, clientY);
        return TransposeVirtualImageToPagePosition(p.X, p.Y);
    }

    /// <summary>
    ///     Convert the coordinate points of the virtual canvas to the location of the screen customer area.
    /// </summary>
    /// <param name="imageX">Virtual canvas level horizontal somewhere.</param>
    /// <param name="imageY">Virtual canvas level horizontal somewhere.</param>
    /// <returns>The location of the screen customer area.</returns>
    internal DrawingPoint TransposeVirtualImageToClient(float imageX, float imageY)
    {
        DrawingRectangle vp = GetImageViewPort();
        return new DrawingPoint(vp.Left + AutoScrollPosition.X + imageX.ToInt32(),
            vp.Top + AutoScrollPosition.Y + imageY.ToInt32());
    }

    /// <summary>
    ///     Get the drawing coordinate point on the specified page on the virtual canvas.
    /// </summary>
    /// <param name="pageNumber">Page number.</param>
    /// <returns>The coordinate point on the virtual canvas on the upper left corner of the page.</returns>
    internal DrawingPoint GetVirtualImageOffset(int pageNumber)
    {
        bool rtl = HorizontalFlow;
        int ox = rtl ? _pageOffsets[pageNumber] : 0;
        int oy = rtl ? 0 : _pageOffsets[pageNumber];
        return new DrawingPoint(ox + __pageMargin, oy + __pageMargin);
    }

    /// <summary>
    ///     Convert the location of the virtual canvas to page coordinates.
    /// </summary>
    /// <param name="imageX">Virtual canvas level horizontal somewhere.</param>
    /// <param name="imageY">Merry coordinate of virtual canvas position.</param>
    /// <returns>页面坐标。</returns>
    internal PagePosition TransposeVirtualImageToPagePosition(int imageX, int imageY)
    {
        int n = GetPageNumberFromOffset(imageX, imageY);
        return TransposeVirtualImageToPagePosition(n, imageX, imageY);
    }

    /// <summary>
    ///     Convert the position of the screen customer area to the rendering page location.
    /// </summary>
    /// <param name="clientX">The abscissa of the screen area.</param>
    /// <param name="clientY">The ordinate of the screen area.</param>
    /// <returns>Rendering the location of the page.</returns>
    internal PagePoint TransposeClientToPageImage(int clientX, int clientY)
    {
        if (_DisplayRange.StartValue <= 0 || _pageBounds == null || IsPointInImage(clientX, clientY) == false)
        {
            return PagePoint.Empty;
        }

        DrawingPoint p = PointToImage(clientX, clientY);
        int n = GetPageNumberFromOffset(p.X, p.Y);
        DrawingPoint o = GetVirtualImageOffset(n);
        return new PagePoint(n, p.X - o.X, p.Y - o.Y);
    }

    /// <summary>
    ///     Convert the location of the virtual page to the PDF page location.
    /// </summary>
    /// <param name="pageNumber">page.</param>
    /// <param name="imageX">The abscissions of the virtual picture.</param>
    /// <param name="imageY">The ordinate of the virtual picture.</param>
    /// <returns>PDF page location.</returns>
    internal PagePosition TransposeVirtualImageToPagePosition(int pageNumber, int imageX, int imageY)
    {
        DrawingPoint o = GetVirtualImageOffset(pageNumber);
        MuRectangle b = _pageBounds[pageNumber];
        float z = GetZoomFactorForPage();
        float ox = (imageX - o.X) / z;
        float oy = (imageY - o.Y) / z;
        return new PagePosition(pageNumber,
            b.Left + ox, b.Top + b.Height - oy,
            imageX - o.X, imageY - o.Y,
            b.Contains(ox, oy));
    }

    #endregion
}
