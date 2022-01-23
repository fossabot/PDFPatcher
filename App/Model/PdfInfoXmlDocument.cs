using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using MuPdfSharp;
using PDFPatcher.Common;

namespace PDFPatcher.Model;

public sealed class PdfInfoXmlDocument : XmlDocument
{
    /// <summary>Returns already initialized <see cref="PdfInfoXmlDocument" /> instance.</summary>
    public PdfInfoXmlDocument() => Init();

    /// <summary>Gets or sets the PDF file path associated with the configuration file.</summary>
    public string PdfDocumentPath
    {
        get => DocumentElement.GetAttribute(Constants.Info.DocumentPath);
        set => DocumentElement.SetAttribute(Constants.Info.DocumentPath, value);
    }

    /// <summary>Returns the document information node.</summary>
    public DocumentInfoElement InfoNode =>
        DocumentElement.GetOrCreateElement(Constants.Info.ThisName) as DocumentInfoElement;

    /// <summary>Returns the page number tag node.</summary>
    public XmlElement PageLabelRoot => DocumentElement.GetOrCreateElement(Constants.PageLabels);

    public XmlNodeList PageLabels =>
        DocumentElement.SelectNodes(Constants.PageLabels + "[1]/" + Constants.PageLabelsAttributes.Style);

    /// <summary>Return to the bookmark root node.</summary>
    public BookmarkRootElement BookmarkRoot =>
        DocumentElement.GetOrCreateElement(Constants.DocumentBookmark) as BookmarkRootElement;

    /// <summary>Get root bookmarks.</summary>
    public XmlNodeList Bookmarks =>
        DocumentElement.SelectNodes(Constants.DocumentBookmark + "[1]/" + Constants.Bookmark);

    private void Init()
    {
        XmlElement root = DocumentElement ?? AppendChild(CreateElement(Constants.PdfInfo)) as XmlElement;

        root.SetAttribute(Constants.Info.ProductName, Application.ProductName);
        root.SetAttribute(Constants.Info.ProductVersion, Constants.InfoDocVersion);
        root.SetAttribute(Constants.Info.ExportDate, DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
    }

    public BookmarkElement CreateBookmark() => new(this);

    public BookmarkElement CreateBookmark(BookmarkSettings settings)
    {
        BookmarkElement b = new(this)
        {
            Title = settings.Title,
            IsOpen = settings.IsOpened,
            Action = Constants.ActionType.Goto
        };
        if (settings.ForeColor.IsEmptyOrTransparent() == false)
        {
            b.ForeColor = settings.ForeColor;
        }

        if (settings.IsBold || settings.IsItalic)
        {
            b.TextStyle = (settings.IsBold ? FontStyle.Bold : FontStyle.Regular) |
                          (settings.IsItalic ? FontStyle.Italic : FontStyle.Regular);
        }

        return b;
    }

    public PageLabelElement CreatePageLabel(MuPdfSharp.PageLabel label)
    {
        PageLabelElement l = new(this);
        l.SetAttributes(label);
        return l;
    }

    public override XmlElement CreateElement(string prefix, string localName, string namespaceURI)
    {
        if (!string.IsNullOrEmpty(prefix) || !string.IsNullOrEmpty(namespaceURI))
        {
            return base.CreateElement(prefix, localName, namespaceURI);
        }

        return localName switch
        {
            Constants.Bookmark => new BookmarkElement(this),
            Constants.DocumentBookmark => new BookmarkRootElement(this),
            Constants.PageLabelsAttributes.Style => new PageLabelElement(this),
            Constants.Info.ThisName => new DocumentInfoElement(this),
            _ => base.CreateElement(prefix, localName, namespaceURI)
        };
    }
}

/// <summary>Document metadata attribute elements.</summary>
public sealed class DocumentInfoElement : XmlElement
{
    internal DocumentInfoElement(XmlDocument doc)
        : base(string.Empty, Constants.Info.ThisName, string.Empty, doc)
    {
    }

    public string Title
    {
        get => this.GetValue(Constants.Info.Title);
        set => this.SetValue(Constants.Info.Title, value, null);
    }

    public string Author
    {
        get => this.GetValue(Constants.Info.Author);
        set => this.SetValue(Constants.Info.Author, value, null);
    }

    public string Creator
    {
        get => this.GetValue(Constants.Info.Creator);
        set => this.SetValue(Constants.Info.Creator, value, null);
    }

    public string Keywords
    {
        get => this.GetValue(Constants.Info.Keywords);
        set => this.SetValue(Constants.Info.Keywords, value, null);
    }

    public string Producer
    {
        get => this.GetValue(Constants.Info.Producer);
        set => this.SetValue(Constants.Info.Producer, value, null);
    }

    public string Subject
    {
        get => this.GetValue(Constants.Info.Subject);
        set => this.SetValue(Constants.Info.Subject, value, null);
    }
}

public abstract class BookmarkContainer : XmlElement
{
    protected BookmarkContainer(string name, XmlDocument doc)
        : base(string.Empty, name, string.Empty, doc)
    {
    }

    /// <summary>Get the current bookmark container has a sub-bookmark.</summary>
    public bool HasSubBookmarks => HasChildNodes && SelectSingleNode(Constants.Bookmark) != null;

    /// <summary>Get the child book signature of the current bookmark container.</summary>
    public XmlNodeList SubBookmarks => SelectNodes(Constants.Bookmark);

    public BookmarkElement ParentBookmark => ParentNode as BookmarkElement;
    public BookmarkContainer Parent => ParentNode as BookmarkContainer;

    /// <summary>Create a new sub-bookmark and return to the bookmark.</summary>
    public BookmarkElement AppendBookmark() =>
        AppendChild((OwnerDocument as PdfInfoXmlDocument).CreateBookmark()) as BookmarkElement;
}

/// <summary>Bookmark root element.</summary>
public sealed class BookmarkRootElement : BookmarkContainer
{
    internal BookmarkRootElement(XmlDocument doc)
        : base(Constants.DocumentBookmark, doc)
    {
    }
}

/// <summary>Bookmark elements.</summary>
[DebuggerDisplay(Constants.Bookmark + "：{Title}")]
public sealed class BookmarkElement : BookmarkContainer
{
    internal BookmarkElement(XmlDocument doc)
        : base(Constants.Bookmark, doc)
    {
    }

    /// <summary>Get or set the text of the bookmark.</summary>
    public string Title
    {
        get => GetAttribute(Constants.BookmarkAttributes.Title);
        set => SetAttribute(Constants.BookmarkAttributes.Title, value);
    }

    /// <summary>Gets or sets the color of the bookmark.</summary>
    public Color ForeColor
    {
        get
        {
            if (HasAttribute(Constants.Colors.Red) || HasAttribute(Constants.Colors.Green) ||
                HasAttribute(Constants.Colors.Blue))
            {
                float r = this.GetValue(Constants.Colors.Red, 0f),
                    g = this.GetValue(Constants.Colors.Green, 0f),
                    b = this.GetValue(Constants.Colors.Blue, 0f);
                return Color.FromArgb((int)(r * 255f), (int)(g * 255f), (int)(b * 255f));
            }

            if (!HasAttribute(Constants.Color))
            {
                return Color.Transparent;
            }

            string a = GetAttribute(Constants.Color);
            int c = a.ToInt32(int.MaxValue);
            return c != int.MaxValue ? Color.FromArgb(c) : Color.FromName(a);
        }
        set
        {
            RemoveAttribute(Constants.Color);
            if (value == Color.Transparent)
            {
                return;
            }

            SetAttribute(Constants.Color, value.ToArgb().ToText());
        }
    }

    /// <summary>Get or set the text style of bookmarks.</summary>
    public FontStyle TextStyle
    {
        get
        {
            string s = GetAttribute(Constants.BookmarkAttributes.Style);
            if (string.IsNullOrEmpty(s))
            {
                return FontStyle.Regular;
            }

            return s switch
            {
                Constants.BookmarkAttributes.StyleType.Bold => FontStyle.Bold,
                Constants.BookmarkAttributes.StyleType.Italic => FontStyle.Italic,
                Constants.BookmarkAttributes.StyleType.BoldItalic => FontStyle.Italic | FontStyle.Bold,
                _ => FontStyle.Regular
            };
        }
        set
        {
            string s;
            switch (value)
            {
                case FontStyle.Bold:
                    s = Constants.BookmarkAttributes.StyleType.Bold;
                    break;
                case FontStyle.Italic:
                    s = Constants.BookmarkAttributes.StyleType.Italic;
                    break;
                case FontStyle.Bold | FontStyle.Italic:
                    s = Constants.BookmarkAttributes.StyleType.BoldItalic;
                    break;
                case FontStyle.Regular:
                case FontStyle.Underline:
                case FontStyle.Strikeout:
                default:
                    RemoveAttribute(Constants.BookmarkAttributes.Style);
                    return;
            }

            SetAttribute(Constants.BookmarkAttributes.Style, s);
        }
    }

    /// <summary>Gets or sets the default open status of the bookmark.</summary>
    public bool IsOpen
    {
        get
        {
            if (HasChildNodes == false)
            {
                return false;
            }

            return GetAttribute(Constants.BookmarkAttributes.Open) == Constants.Boolean.True;
        }
        set
        {
            //if (HasSubBookmarks == false) {
            //	return;
            //}
            if (value)
            {
                SetAttribute(Constants.BookmarkAttributes.Open, Constants.Boolean.True);
            }
            else
            {
                RemoveAttribute(Constants.BookmarkAttributes.Open);
            }
        }
    }

    /// <summary>Get or set the target action.</summary>
    public string Action
    {
        get => this.GetValue(Constants.DestinationAttributes.Action, Constants.ActionType.Goto);
        set => this.SetValue(Constants.DestinationAttributes.Action, value);
    }

    /// <summary>Get or set the target page for bookmarks.</summary>
    public int Page
    {
        get => this.GetValue(Constants.DestinationAttributes.Page, 0);
        set
        {
            this.SetValue(Constants.DestinationAttributes.Page, value, 0);
            if (HasAttribute(Constants.DestinationAttributes.Action) == false)
            {
                SetAttribute(Constants.DestinationAttributes.Action, Constants.ActionType.Goto);
            }
        }
    }

    /// <summary>Return or set the target view.</summary>
    public string DestinationView
    {
        get => GetAttribute(Constants.DestinationAttributes.View);
        set => this.SetValue(Constants.DestinationAttributes.View, value);
    }

    /// <summary>Gets or sets the upper coordinates of the jump target.</summary>
    public float Top
    {
        get => this.GetValue(Constants.Coordinates.Top, 0f);
        set => this.SetValue(Constants.Coordinates.Top, value, 0);
    }

    /// <summary>Get or set the left coordinates of the jump target.</summary>
    public float Left
    {
        get => this.GetValue(Constants.Coordinates.Left, 0f);
        set => this.SetValue(Constants.Coordinates.Left, value, 0);
    }

    /// <summary>Get or set the down coordinates of the jump target.</summary>
    public float Bottom
    {
        get => this.GetValue(Constants.Coordinates.Bottom, 0f);
        set => this.SetValue(Constants.Coordinates.Bottom, value, 0);
    }

    /// <summary>Get or set the right coordinate of the jump target.</summary>
    public float Right
    {
        get => this.GetValue(Constants.Coordinates.Right, 0f);
        set => this.SetValue(Constants.Coordinates.Right, value, 0);
    }

    public int MarkerColor
    {
        get => this.GetValue("Tag color", 0);
        set => this.SetValue("Tag color", value, 0);
    }

    /// <summary>Set the bookmark action jump to the page.</summary>
    /// <param name="title">The title of bookmark.</param>
    /// <param name="Pagenumber">Jump page.</param>
    /// <param name="position">Jump position.</param>
    public void SetTitleAndGotoPagePosition(string title, int pageNumber, float position)
    {
        SetAttribute(Constants.BookmarkAttributes.Title, title);
        this.SetValue(Constants.DestinationAttributes.Page, pageNumber, 0);
        SetAttribute(Constants.DestinationAttributes.Action, Constants.ActionType.Goto);
        if (position == 0)
        {
            return;
        }

        SetAttribute(Constants.DestinationAttributes.View, Constants.DestinationAttributes.ViewType.XYZ);
        this.SetValue(Constants.Coordinates.Top, position, 0);
    }
}

/// <summary>Page size label set element.</summary>
public sealed class PageLabelElement : XmlElement
{
    internal PageLabelElement(XmlDocument doc)
        : base(string.Empty, Constants.PageLabelsAttributes.Style, string.Empty, doc)
    {
    }

    /// <summary>Get or specify the absolute page number that starts using the page number tag.</summary>
    public int PageNumber
    {
        get => GetAttribute(Constants.PageLabelsAttributes.PageNumber).ToInt32();
        set => this.SetValue(Constants.PageLabelsAttributes.PageNumber, value < 1 ? 0 : value, 0);
    }

    public string PrefixLabel
    {
        get => GetAttribute(Constants.PageLabelsAttributes.Prefix);
        set => this.SetValue(Constants.PageLabelsAttributes.Prefix, value);
    }

    /// <summary>Get or specify the page number tag style.</summary>
    public string Style
    {
        get => GetAttribute(Constants.PageLabelsAttributes.Style);
        set => this.SetValue(Constants.PageLabelsAttributes.Style, value, Constants.PageLabelStyles.Names[0]);
    }

    /// <summary>Gets or specifies the start number of the page tab.</summary>
    public int StartNumber
    {
        get => GetAttribute(Constants.PageLabelsAttributes.StartPage).ToInt32();
        set => this.SetValue(Constants.PageLabelsAttributes.StartPage, value < 1 ? 0 : value, 0);
    }

    public void SetAttributes(MuPdfSharp.PageLabel label)
    {
        this.SetValue(Constants.PageLabelsAttributes.PageNumber, label.FromPageNumber + 1, 0);
        SetAttribute(Constants.PageLabelsAttributes.Style,
            ValueHelper.MapValue((char)label.NumericStyle, Constants.PageLabelStyles.PdfValues,
                Constants.PageLabelStyles.Names));
        this.SetValue(Constants.PageLabelsAttributes.StartPage, label.StartAt, 0);
        this.SetValue(Constants.PageLabelsAttributes.Prefix, label.Prefix);
    }

    public MuPdfSharp.PageLabel ToPageLabel() =>
        new(
            PageNumber - 1,
            StartNumber,
            PrefixLabel,
            (PageLabelStyle)ValueHelper.MapValue(Style, Constants.PageLabelStyles.Names,
                Constants.PageLabelStyles.PdfValues));
}
