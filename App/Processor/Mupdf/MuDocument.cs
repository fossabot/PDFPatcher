using System;
using System.IO;
using iTextSharp.text.exceptions;

namespace MuPdfSharp;

public sealed class MuDocument : IDisposable
{
    public MuDocument(string fileName) : this() => LoadPdf(fileName, null);

    public MuDocument(string fileName, string password) : this() => LoadPdf(fileName, password);

    private MuDocument()
    {
        Context = ContextHandle.Create();
        _cookie = new MuCookie();

        NativeMethods.LoadSystemFontFuncs(Context, NativeMethods.LoadSystemFont, NativeMethods.LoadSystemCjkFont,
            NativeMethods.LoadSystemFallbackFont);
        PageCount = -1;
    }

    private void LoadPdf(string fileName, string password)
    {
        if (File.Exists(fileName) == false)
        {
            throw new FileNotFoundException("找不到 PDF 文件：" + fileName);
        }

        try
        {
            _sourceStream = new StreamHandle(Context, fileName);
            _document = new DocumentHandle(Context, _sourceStream);
            FilePath = fileName;
            InitPdf(password);
        }
        catch (AccessViolationException)
        {
            _sourceStream.DisposeHandle();
            _document.DisposeHandle();
            throw new IOException("PDF 文件无效：" + fileName);
        }
    }

    /// <summary>
    ///     Release the handle corresponding to the document, no longer occupying the PDF file.
    /// </summary>
    public void ReleaseFile()
    {
        lock (SyncObj)
        {
            _document.DisposeHandle();
            _sourceStream.DisposeHandle();
        }
    }

    /// <summary>
    ///     Re-open the file.
    /// </summary>
    public void Reopen()
    {
        lock (SyncObj)
        {
            ReleaseFile();
            LoadPdf(FilePath, null);
        }
    }

    public void AbortAsync() => _cookie.CancelAsync();

    public MuPage LoadPage(int pageNumber) => new(Context, _document, pageNumber, ref _cookie);

    private void InitPdf(string password)
    {
        if (NativeMethods.NeedsPdfPassword(Context, _document))
        {
            if (string.IsNullOrEmpty(password) == false)
            {
                if (NativeMethods.AuthenticatePassword(Context, _document, password) == false)
                {
                    throw new BadPasswordException("密码无效。");
                }
            }
            else
            {
                throw new BadPasswordException("需要提供打开 PDF 文档的密码。");
            }
        }

        PageCount = NativeMethods.CountPages(Context, _document);
    }

    #region Non-hosting resource member

    private StreamHandle _sourceStream;
    private DocumentHandle _document;

    #endregion

    #region Managed resource

    /// <summary>Get the path to the loaded document.</summary>
    public string FilePath { get; private set; }

    /// <summary>Get the number of pages of the document.</summary>
    public int PageCount { get; private set; }

    /// <summary>Get the file handle to open.</summary>
    public bool IsDocumentOpened => _document.IsValid() && _sourceStream.IsValid();

    /// <summary>Gets whether the document is set to open your password.</summary>
    public bool NeedsPassword => NativeMethods.NeedsPdfPassword(Context, _document);

    public object SyncObj { get; private set; } = new();

    internal ContextHandle Context { get; }

    private MuPdfDictionary _trailer;

    internal MuPdfDictionary Trailer =>
        _trailer ??= new MuPdfDictionary(Context, NativeMethods.GetTrailer(Context, _document));

    internal MuPdfDictionary Root => Trailer["Root"].AsDictionary();
    internal MuDocumentInfo Info => new(Trailer["Info"].AsDictionary());
    private PageLabelCollection _PageLabels;

    /// <summary>
    ///     Returns the page number tab of the document.
    /// </summary>
    public PageLabelCollection PageLabels => _PageLabels ??= new PageLabelCollection(this);

    private MuCookie _cookie;

    #endregion

    #region Implement the properties and methods of iDisposable interface

    public bool IsDisposed { get; private set; }

    /// <summary>Release the resources occupied by MuDocument.</summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>Release the resources occupied by MuDocument.</summary>
    /// <param name="disposing">Whether to manually release the hosted resource.</param>
    private void Dispose(bool disposing)
    {
        if (!IsDisposed)
        {
            if (disposing)
            {
                #region Release managed resources

                _trailer = null;
                SyncObj = null;
                if (_PageLabels != null)
                {
                    _PageLabels.Clear();
                    _PageLabels = null;
                }

                #endregion
            }

            #region Release non-managed resources

            // Note that this is not a thread safe
            _document.DisposeHandle();
            _sourceStream.DisposeHandle();
            Context.DisposeHandle();

            #endregion
        }

        IsDisposed = true;
    }

    // The descent function is only called when the Dispose method is not called.
    // Don't provide a destructor in the derived class
    ~MuDocument() => Dispose(false);

    #endregion

    #region Generate objects

    public MuPdfObject Create(bool value) => new(Context, NativeMethods.NewBoolean(Context, _document, value ? 1 : 0));

    public MuPdfObject Create(int value) => new(Context, NativeMethods.NewInteger(Context, _document, value));

    public MuPdfObject Create(float value) => new(Context, NativeMethods.NewFloat(Context, _document, value));

    public MuPdfObject Create(string value) =>
        new(Context, NativeMethods.NewString(Context, _document, value, value.Length));

    public MuPdfObject CreateName(string value) => new(Context, NativeMethods.NewName(Context, _document, value));

    public MuPdfObject Create(int number, int generation) => new(Context,
        NativeMethods.NewIndirectReference(Context, _document, number, generation));

    public MuPdfArray Create(Rectangle rect) => new(Context, NativeMethods.NewRect(Context, _document, rect));

    public MuPdfArray Create(Matrix matrix) => new(Context, NativeMethods.NewMatrix(Context, _document, matrix));

    public MuPdfArray CreateArray() => new(Context, NativeMethods.NewArray(Context, _document, 4));

    #endregion
}
