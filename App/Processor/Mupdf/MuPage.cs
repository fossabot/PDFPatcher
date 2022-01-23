using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace MuPdfSharp;

public sealed class MuPage : IDisposable
{
    internal MuPage(ContextHandle context, DocumentHandle document, int pageNumber, ref MuCookie cookie)
    {
        try
        {
            _page = new PageHandle(document, pageNumber - 1);
            _document = document;
            _context = context;
            _cookie = cookie;
            PageNumber = pageNumber;
        }
        catch (AccessViolationException)
        {
            _page.DisposeHandle();
            throw new MuPdfException("Could not load page " + pageNumber + ".");
        }
    }

    ///// <summary>
    ///// Get the text of the specified area.
    ///// </summary>
    ///// <param name="selection"> area.</param>
    ///// <returns>Text in the area.</returns>
    //public string GetSelection (Rectangle selection) {
    //    return Interop.DecodeUtf8String (NativeMethods.CopySelection (_context, GetTextPage (), selection));
    //}

    ///// <summary>
    ///// Get the text of the specified area.
    ///// </summary>
    ///// <param name="selection">area.</param>
    ///// <returns>Text in the area.</returns>
    //public List<Rectangle> HighlightSelection (Rectangle selection) {
    //	var l =
    //	return Interop.DecodeUtf8String (NativeMethods.HighlightSelection (_context, _page, selection));
    //}

    /// <summary>
    ///     Use the specified configuration rendering page.
    /// </summary>
    /// <param name="width">Page width。</param>
    /// <param name="height">The height of the page.</param>
    /// <param name="options">Rendering options.</param>
    /// <returns>Generated after rendering <see cref="Bitmap" />.</returns>
    public Bitmap RenderBitmapPage(int width, int height, ImageRendererOptions options)
    {
        using PixmapData pix = InternalRenderPage(width, height, options);
        return pix?.ToBitmap(options);
    }

    public MuFont GetFont(MuTextChar character) => new(_context, character.FontID);

    public MuFont GetFont(MuTextSpan span) => new(_context, span.FontID);

    private DisplayListHandle GetDisplayList()
    {
        if (_displayList.IsValid())
        {
            return _displayList;
        }

        _displayList = _context.CreateDisplayList(Bound);
        using (DeviceHandle d = new(_context, _displayList))
        {
            //if (hideAnnotations) {
            //	NativeMethods.RunPageContents (_document, _page, d, ref m, _cookie);
            //}
            //else {
            NativeMethods.RunPage(_context, _page, d, Matrix.Identity, ref _cookie);
            d.EndOperations();
            //}
        }

        if (_cookie.ErrorCount > 0)
        {
            Debug.WriteLine("There are " + _cookie.ErrorCount + " errors on page " + PageNumber + ".");
        }

        return _displayList;
    }

    private void PopulateTextPage()
    {
        if (_TextPage != null)
        {
            return;
        }

        Rectangle vb = VisualBound;
        TextPageHandle text = new(_context, vb);
        try
        {
            using (DeviceHandle dev = new(_context, text))
            {
                NativeMethods.RunDisplayList(_context, GetDisplayList(), dev, Matrix.Identity, vb, ref _cookie);
                dev.EndOperations();
            }

            _TextPage = new MuTextPage(text);
        }
        catch (AccessViolationException)
        {
            text.DisposeHandle();
            throw;
        }
    }

    private PixmapData InternalRenderPage(int width, int height, ImageRendererOptions options)
    {
        Rectangle b = Bound;
        if (b.Width == 0 || b.Height == 0)
        {
            return null;
        }

        Matrix ctm = CalculateMatrix(width, height, options);
        BBox bbox = width > 0 && height > 0 ? new BBox(0, 0, width, height) : ctm.Transform(b).Round;

        PixmapHandle pix = _context.CreatePixmap(options.ColorSpace, bbox);
        try
        {
            NativeMethods.ClearPixmap(_context, pix, 0xFF);
            using DeviceHandle dev = new(_context, pix, Matrix.Identity);
            if (options.LowQuality)
            {
                NativeMethods.EnableDeviceHints(_context, dev,
                    DeviceHints.IgnoreShade | DeviceHints.DontInterperateImages | DeviceHints.NoCache);
            }

            if (_cookie.IsCancellationPending)
            {
                return null;
            }

            NativeMethods.RunPageContents(_context, _page, dev, ctm, ref _cookie);
            if (options.HideAnnotations == false)
            {
                NativeMethods.RunPageAnnotations(_context, _page, dev, ctm, ref _cookie);
                NativeMethods.RunPageWidgets(_context, _page, dev, ctm, ref _cookie);
            }
            //NativeMethods.BeginPage (dev, ref b, ref ctm);
            //NativeMethods.RunDisplayList (_context, GetDisplayList(), dev, ctm, ctm.Transform(VisualBound), ref _cookie);
            //NativeMethods.EndPage (dev);

            dev.EndOperations();

            if (_cookie.IsCancellationPending)
            {
                return null;
            }

            PixmapData pd = new(_context, pix);
            if (options.TintColor != Color.Transparent)
            {
                pd.Tint(options.TintColor);
            }

            if (options.Gamma != 1.0f)
            {
                pd.Gamma(options.Gamma);
            }

            return pd;
        }
        catch (AccessViolationException)
        {
            pix.DisposeHandle();
            throw new MuPdfException("Failed to render page: " + PageNumber);
        }
    }

    private Matrix CalculateMatrix(int width, int height, ImageRendererOptions options)
    {
        float w = width, h = height;
        Rectangle b = Bound;
        if (options.UseSpecificWidth)
        {
            if (w < 0)
            {
                w = -w;
            }

            if (h < 0)
            {
                h = -h;
            }

            if (options.FitArea && w != 0 && h != 0)
            {
                float rw = w / b.Width;
                float rh = h / b.Height;
                if (rw < rh)
                {
                    h = 0;
                }
                else
                {
                    w = 0;
                }
            }

            if (w == 0 && h == 0)
            {
                // No resize
                w = b.Width;
                h = b.Height;
            }
            else if (h == 0)
            {
                h = width * b.Height / b.Width;
            }
            else if (w == 0)
            {
                w = height * b.Width / b.Height;
            }
        }
        else if (w == 0 || h == 0)
        {
            w = b.Width * options.ScaleRatio * options.Dpi / 72;
            h = b.Height * options.ScaleRatio * options.Dpi / 72;
        }

        Matrix ctm = Matrix.Scale(w / b.Width, h / b.Height).RotateTo(options.Rotation);
        if (options.VerticalFlipImages)
        {
            ctm = Matrix.Concat(ctm, Matrix.VerticalFlip);
        }

        if (options.HorizontalFlipImages)
        {
            ctm = Matrix.Concat(ctm, Matrix.HorizontalFlip);
        }

        return ctm;
    }

    #region Non-Managed resource member

    private readonly ContextHandle _context;
    private DocumentHandle _document;
    private readonly PageHandle _page;
    private DisplayListHandle _displayList;

    #endregion

    #region Managed resource

    private MuCookie _cookie;
    private MuTextPage _TextPage;
    private bool _flattened;

    /// <summary>Get the page number of the current page。</summary>
    public int PageNumber { get; }

    /// <summary>
    ///     Get the size of the current page (the lower left corner is scheduled to "0,0").To get the original visual area
    ///     in the page dictionary, use the <see cref="VisualBound" /> property.
    /// </summary>
    public Rectangle Bound => NativeMethods.BoundPage(_context, _page);

    /// <summary>Get the coordinates and sizes of the current page visual area.</summary>
    public Rectangle VisualBound => Matrix.Identity.RotateTo(Rotation).Transform(VisualBox);

    public Rectangle ArtBox => LookupPageBox("ArtBox");
    public Rectangle BleedBox => LookupPageBox("BleedBox");
    public Rectangle CropBox => LookupPageBox("CropBox");
    public Rectangle TrimBox => LookupPageBox("TrimBox");
    public Rectangle MediaBox => LookupPageBox("MediaBox");

    public Rectangle VisualBox
    {
        get
        {
            Rectangle b = LookupPageBox("CropBox");
            return b.IsEmpty ? LookupPageBox("MediaBox") : b;
        }
    }

    public int Rotation => LookupPage("Rotate").IntegerValue;

    public MuTextPage TextPage
    {
        get
        {
            PopulateTextPage();
            return _TextPage;
        }
    }

    private Rectangle LookupPageBox(string name)
    {
        if (_flattened == false)
        {
            IntPtr d = _page.PageDictionary;
            NativeMethods.FlattenInheritablePageItems(_context, d);
            _flattened = true;
        }

        MuPdfDictionary a = new(_context, _page.PageDictionary);
        MuPdfArray ra = a[name].AsArray();
        return ra.Count == 4 ? Rectangle.FromArray(a[name]) : Rectangle.Empty;
    }

    private MuPdfObject LookupPage(string name)
    {
        MuPdfDictionary a = new(_context, _page.PageDictionary);
        return a[name];
    }

    #endregion

    #region Implement the properties and methods of iDisposable interface

    private bool disposed;

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this); // Inhibitory destructive function
    }

    /// <summary>Release the resources occupied by MpPDFPAGE。</summary>
    /// <param name="disposing">Whether to manually release the hosted resource.</param>
    [SuppressMessage("Microsoft.Usage", "CA2213:DisposableFieldsShouldBeDisposed", MessageId = "_page")]
    private void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                #region Release managed resources

                _TextPage?.Dispose();
                _TextPage = null;

                #endregion
            }

            #region Release non-managed resources

            // Note that this is not a thread safe
            //int retry = 0;
            //_cookie.CancelAsync ();
            //while (_cookie.IsRunning && ++retry < 10) {
            //    System.Threading.Thread.Sleep (100);
            //}
            _page.DisposeHandle();
            _displayList.DisposeHandle();
            _document = null;

            #endregion
        }

        disposed = true;
    }

    // The destructor is only called when the Dispose method is not called.
    // Don't provide a destructor in the derived class
    ~MuPage() => Dispose(false);

    #endregion

    //protected override bool ReleaseHandle () {
    //	NativeMethods.FreePage (_document, this.handle);
    //	return true;
    //}
}
