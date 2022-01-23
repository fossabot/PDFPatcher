using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PDFPatcher.Properties;

namespace PDFPatcher;

internal sealed class Toolkit
{
    internal static readonly Toolkit[] Toolkits =
    {
        new("Edit", "BookmarkEditor", "Editor",
            "Create or modify bookmarks for PDF documents, modify settings for PDF documents", true),
        new("Batch", "Patcher", "DocumentProcessor",
            "Batch-process PDF documents according to the configuration and generate new documents", true),
        new("Merge", "Merger", "Merger", "Merge multiple images and PDF documents into a new PDF document",
            true),
        new("Recognize text", "Ocr", "Ocr",
            "Recognize text in scanned PDF documents (requires Microsoft Office 2003 or 2007 Optical Character Recognition (OCR) engine support)"),
        new("Auto Bookmark", "BookmarkGenerator", "AutoBookmark",
            "Generate bookmark file according to PDF text style"),
        new("Batch Rename", "Rename", "Rename", "Change file name according to PDF's text properties", false,
            false),
        new("Extract pages or split documents", "ExtractPages", "ExtractPages",
            "Extract pages or reflow pages of PDF documents"),
        new("Extract", "ExtractImages", "ExtractImage", "Extract images from PDF documents without loss",
            true),
        new("Convert pages to images", "RenderPages", "RenderDocument",
            "Convert pages of PDF documents to images"),
        new("Structure Inspector", "Inspector", "DocumentInspector",
            "Inspect the internal structure of a PDF document", false, false),
        new("Export or import info file", "InfoExchanger", "ExportInfoFile",
            "Export bookmarks, document metadata, reader settings and other information to info file"),
        new("Program Configuration", "Options", "AppOptions", "Modify PDF Patch Program Configuration", false,
            false)
    };

    private Toolkit(string name, string id, string icon, string description, bool showText)
        : this(name, id, icon, description, showText, true)
    {
    }

    private Toolkit(string name, string id, string icon, string description, bool showText = false,
        bool defaultVisible = true)
    {
        Name = name;
        Identifier = id;
        Icon = icon;
        Description = description;
        ShowText = showText;
        DefaultVisible = defaultVisible;
    }

    public string Identifier { get; }
    public string Icon { get; }
    public string Name { get; }
    public string Description { get; }
    public bool ShowText { get; }
    public bool DefaultVisible { get; }

    internal static Toolkit Get(string id) => Toolkits.FirstOrDefault(item => item.Identifier == id);

    internal ToolStripButton CreateButton() =>
        new(Name, Resources.ResourceManager.GetObject(Icon) as Image)
        {
            Name = Identifier,
            Tag = Identifier,
            ToolTipText = Description,
            DisplayStyle = ShowText ? ToolStripItemDisplayStyle.ImageAndText : ToolStripItemDisplayStyle.Image
        };
}
