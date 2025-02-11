﻿using System;
using System.Collections.Generic;
using System.Xml;
using PDFPatcher.Common;
using PDFPatcher.Model;

namespace PDFPatcher.Processor;

internal static class SourceItemSerializer
{
    private static readonly BookmarkSettings __EmptyBookmark = new();

    /// <summary>
    ///     Save a list of merge file functions.
    /// </summary>
    /// <param name="list">file list item.</param>
    /// <param name="path">The save path of the list of files.</param>
    internal static void Serialize(IList<SourceItem> list, string path)
    {
        PdfInfoXmlDocument d = new();
        BookmarkRootElement b = d.BookmarkRoot;
        foreach (SourceItem item in list)
        {
            SerializeSourceItem(d, b, item);
        }

        try
        {
            d.Save(path);
        }
        catch (Exception ex)
        {
            FormHelper.ErrorBox("An error was encountered while saving the file list: " + ex.Message);
        }
    }

    private static void SerializeSourceItem(PdfInfoXmlDocument doc, XmlNode container, SourceItem item)
    {
        BookmarkElement e = doc.CreateBookmark(item.Bookmark ?? __EmptyBookmark);
        e.SetValue(Constants.DestinationAttributes.Path, item.FilePath.ToString());
        if (item.Type == SourceItem.ItemType.Pdf)
        {
            e.SetValue(Constants.PageRange, ((SourceItem.Pdf)item).PageRanges);
        }

        container.AppendChild(e);
        if (!item.HasSubItems)
        {
            return;
        }

        foreach (SourceItem sub in item.Items)
        {
            SerializeSourceItem(doc, e, sub);
        }
    }

    internal static List<SourceItem> Deserialize(string path)
    {
        PdfInfoXmlDocument d = new();
        try
        {
            d.Load(path);
        }
        catch (Exception ex)
        {
            FormHelper.ErrorBox("An error was encountered while loading the file list: " + ex.Message);
        }

        XmlNodeList bl = d.Bookmarks;
        List<SourceItem> l = new(bl.Count);
        foreach (BookmarkElement item in bl)
        {
            DeserializeSourceItem(l, item);
        }

        return l;
    }

    private static void DeserializeSourceItem(ICollection<SourceItem> list, BookmarkElement bookmark)
    {
        BookmarkSettings b = new(bookmark);
        string p = bookmark.GetValue(Constants.DestinationAttributes.Path);
        SourceItem s = SourceItem.Create(p, false);
        if (b.Title.IsNullOrWhiteSpace() == false || b.IsOpened || b.IsBold || b.IsItalic ||
            b.ForeColor.IsEmptyOrTransparent() == false)
        {
            s.Bookmark = b;
        }

        if (s.Type == SourceItem.ItemType.Pdf)
        {
            ((SourceItem.Pdf)s).PageRanges = bookmark.GetValue(Constants.PageRange);
        }

        list.Add(s);
        if (!bookmark.HasSubBookmarks)
        {
            return;
        }

        foreach (BookmarkElement sub in bookmark.SubBookmarks)
        {
            DeserializeSourceItem(s.Items, sub);
        }
    }
}
