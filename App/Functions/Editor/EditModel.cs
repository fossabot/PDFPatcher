﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using MuPdfSharp;
using PDFPatcher.Common;
using PDFPatcher.Model;
using PDFPatcher.Processor;

namespace PDFPatcher.Functions.Editor;

internal sealed class EditModel
{
    public EditModel()
    {
        Undo = new UndoManager();
        TitleStyles = new List<AutoBookmarkStyle>();
    }

    internal bool IsLoadingDocument { get; set; }
    internal PdfInfoXmlDocument Document { get; set; }
    internal bool LockDownViewer { get; set; }
    internal bool InsertBookmarkWithOcrOnly { get; set; }
    internal UndoManager Undo { get; }
    internal string DocumentPath { get; set; }
    internal string LastSavedPdfPath { get; set; }
    internal MuDocument PdfDocument { get; set; }
    internal List<AutoBookmarkStyle> TitleStyles { get; }

    internal string GetPdfFilePath()
    {
        if (DocumentPath == null)
        {
            return null;
        }

        string s = FileHelper.HasExtension(DocumentPath, Constants.FileExtensions.Pdf) ? DocumentPath : null;
        if (string.IsNullOrEmpty(s))
        {
            s = Document.PdfDocumentPath;
            if (Path.IsPathRooted(s) == false)
            {
                s = Path.Combine(Path.GetDirectoryName(DocumentPath), s);
            }
        }

        if (File.Exists(s) == false)
        {
            s = null;
        }

        return s;
    }

    internal sealed class Region
    {
        public Region(PagePosition position, string text, TextSource source)
        {
            Position = position;
            Text = text;
            TextSource = source;
        }

        internal PagePosition Position { get; }
        internal string Text { get; }
        internal TextSource TextSource { get; }

        internal string LiteralTextSource =>
            TextSource switch
            {
                TextSource.Empty => "The current position does not contain text",
                TextSource.Text => "Automatically matched text layer text",
                TextSource.OcrText => "Automatically recognized image text",
                TextSource.OcrError =>
                    "The current page does not contain identifiable text, or there is an error in the recognition process",
                _ => throw new IndexOutOfRangeException("TextSource")
            };
    }

    internal enum TextSource
    {
        Empty,
        Text,
        OcrText,
        OcrError
    }

    internal sealed class AutoBookmarkStyle
    {
        internal readonly string FontName;
        internal readonly int FontSize;
        internal readonly string InternalFontName;
        internal readonly BookmarkSettings Style;

        internal int Level;
        internal MatchPattern MatchPattern = null;

        public AutoBookmarkStyle(int level, string internalFontName, int fontSize)
        {
            Level = level;
            InternalFontName = internalFontName;
            FontName = PdfDocumentFont.RemoveSubsetPrefix(internalFontName);
            FontSize = fontSize;
            Style = new BookmarkSettings();
        }
    }
}

internal interface IEditView
{
    bool AffectsDescendantBookmarks { get; }
    ToolStripSplitButton UndoButton { get; }
    AutoBookmarkForm AutoBookmark { get; }
    BookmarkEditorView Bookmark { get; }
    PdfViewerControl Viewer { get; }
    ToolStrip ViewerToolbar { get; }
    ToolStrip BookmarkToolbar { get; }
    SplitContainer MainPanel { get; }
    string DocumentPath { get; set; }
}
