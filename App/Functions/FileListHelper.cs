﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BrightIdeasSoftware;
using PDFPatcher.Common;
using PDFPatcher.Model;

namespace PDFPatcher.Functions;

internal sealed class FileListHelper
{
    public delegate void AddFilesCallback(string[] files, bool alertInvalidFiles);

    private readonly ObjectListView _fileList;

    public FileListHelper(ObjectListView fileList) => _fileList = fileList;

    /// <summary>
    ///     Set the drag and drop operation of the PDF file list.
    /// </summary>
    /// <param name="addFilesCallback">Add a file's callback function.</param>
    public void SetupDragAndDrop(AddFilesCallback addFilesCallback)
    {
        _fileList.DragSource = new SimpleDragSource(true);
        RearrangingDropSink ds = new(false);
        _fileList.DropSink = ds;

        ds.CanDrop += (_, args) =>
        {
            string[] files = args.DragEventArgs.DropFileOver(Constants.FileExtensions.Pdf);
            if (files.Length <= 0)
            {
                return;
            }

            args.Effect = DragDropEffects.Link;
            args.InfoMessage = "Add " + files.Length + " files";
            args.Handled = true;
        };
        ds.Dropped += (_, args) =>
        {
            string[] files = args.DragEventArgs.DropFileOver(Constants.FileExtensions.Pdf);
            if (files.Length <= 0)
            {
                return;
            }

            _fileList.SelectedIndex
                = args.DropTargetLocation == DropTargetLocation.Background
                    ? _fileList.GetItemCount() - 1
                    : args.DropTargetIndex + (args.DropTargetLocation == DropTargetLocation.AboveItem ? -1 : 0);
            addFilesCallback(files, false);
            args.Handled = true;
        };
    }

    /// <summary>
    ///     Open the PDF file <see cref="ToolStripSplitButton" /> displays the event handler of the drop-down file list.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public static void OpenPdfButtonDropDownOpeningHandler(object sender, EventArgs e)
    {
        ToolStripSplitButton b = sender as ToolStripSplitButton;
        ToolStripItemCollection l = b.DropDown.Items;
        l.ClearDropDownItems();
        foreach (string item in AppContext.Recent.SourcePdfFiles)
        {
            l.Add(FileHelper.GetEllipticPath(item, 50)).ToolTipText = item;
        }

        if (l.Count == 0)
        {
            b.PerformButtonClick();
        }
    }

    /// <summary>
    ///     Selected items for the specified encoding refresh file list.
    /// </summary>
    /// <param name="encoding">Used to read document metadata <see cref="Enocding" />.</param>
    public void RefreshInfo(Encoding encoding)
    {
        IList ol = _fileList.SelectedObjects;
        if (ol.Count == 0)
        {
            _fileList.SelectAll();
            ol = _fileList.SelectedObjects;
        }

        foreach (SourceItem.Pdf item in ol)
        {
            item.Refresh(encoding);
        }

        _fileList.RefreshObjects(ol);
    }

    /// <summary>
    ///     Setting write processing functions for <see cref="olvcolumn />).
    /// 
    /// 
    /// </summary>
    /// <param name="columns">A column that needs to be set.</param>
    public static void SetupCommonPdfColumns(params OLVColumn[] columns)
    {
        foreach (OLVColumn item in columns)
        {
            switch (item.Text)
            {
                case "source filename":
                    SetupFileNameColumn(item);
                    break;
                case "folder":
                    SetupFolderNameColumn(item);
                    break;
                case "title":
                    SetupTitleColumn(item);
                    break;
                case "author":
                    SetupAuthorColumn(item);
                    break;
                case "subject":
                    SetupSubjectColumn(item);
                    break;
                case "keyword":
                    SetupKeywordsColumn(item);
                    break;
                case "Number of pages":
                    SetupPageCountColumn(item);
                    break;
            }
        }
    }

    private static void SetupAuthorColumn(OLVColumn column) =>
        column.AsTyped<SourceItem.Pdf>(c =>
        {
            c.AspectGetter = o => o.DocInfo.Author;
            c.AspectPutter = (o, value) => o.DocInfo.Author = value as string;
        });

    private static void SetupKeywordsColumn(OLVColumn column) =>
        column.AsTyped<SourceItem.Pdf>(c =>
        {
            c.AspectGetter = o => o.DocInfo.Keywords;
            c.AspectPutter = (o, value) => o.DocInfo.Keywords = value as string;
        });

    private static void SetupSubjectColumn(OLVColumn column) =>
        column.AsTyped<SourceItem.Pdf>(c =>
        {
            c.AspectGetter = o => o.DocInfo.Subject;
            c.AspectPutter = (o, value) => o.DocInfo.Subject = value as string;
        });

    private static void SetupTitleColumn(OLVColumn column) =>
        column.AsTyped<SourceItem.Pdf>(c =>
        {
            c.AspectGetter = o => o.DocInfo.Title;
            c.AspectPutter = (o, value) => o.DocInfo.Title = value as string;
        });

    private static void SetupPageCountColumn(OLVColumn column) =>
        column.AsTyped<SourceItem.Pdf>(c => { c.AspectGetter = o => o.PageCount.ToText(); });

    private static void SetupFileNameColumn(OLVColumn column) =>
        column.AsTyped<SourceItem.Pdf>(c =>
        {
            c.AspectGetter = o => o.Type == SourceItem.ItemType.Empty ? "<Blank page>" : o.FileName;
            c.ImageGetter = _ => 0;
        });

    private static void SetupFolderNameColumn(OLVColumn column) =>
        column.AsTyped<SourceItem>(c =>
        {
            c.AspectGetter = o => o.Type != SourceItem.ItemType.Empty ? o.FolderName : string.Empty;
        });

    public void SetupHotkeys() =>
        _fileList.KeyUp += (_, args) =>
        {
            switch (args.KeyCode)
            {
                case Keys.Delete:
                    if (_fileList.IsCellEditing || _fileList.Focused == false)
                    {
                        return;
                    }

                    ProcessCommonMenuCommand(Commands.Delete);
                    break;
            }
        };

    public bool ProcessCommonMenuCommand(string commandID)
    {
        switch (commandID)
        {
            case Commands.Delete:
                if (_fileList.GetItemCount() == 0)
                {
                    return true;
                }

                IList l = _fileList.SelectedObjects;
                if (l.Count == 0)
                {
                    if (FormHelper.YesNoBox("Will it empty a list of files?") == DialogResult.Yes)
                    {
                        _fileList.ClearObjects();
                    }
                }
                else
                {
                    _fileList.RemoveObjects(_fileList.SelectedObjects);
                }

                break;
            case "_Copy":
                StringBuilder sb = new();
                foreach (SourceItem.Pdf item in GetSourceItems<SourceItem>(true))
                {
                    sb.AppendLine(string.Join("\t", item.FilePath.ToString(), item.PageCount.ToText(),
                        item.DocInfo.Title, item.DocInfo.Author, item.DocInfo.Subject, item.DocInfo.Keywords));
                }

                if (sb.Length > 0)
                {
                    Clipboard.SetText(sb.ToString());
                }

                break;
            case Commands.SelectAllItems:
                _fileList.SelectAll();
                break;
            case Commands.InvertSelectItem:
                foreach (ListViewItem item in _fileList.Items)
                {
                    item.Selected = !item.Selected;
                }

                break;
            case Commands.SelectNone:
                _fileList.SelectObjects(null);
                break;
            default:
                return false;
        }

        return true;
    }

    public List<T> GetSourceItems<T>(bool selectedOnly) where T : SourceItem
    {
        if (_fileList.GetItemCount() == 0)
        {
            return null;
        }

        IEnumerable l = selectedOnly ? _fileList.SelectedObjects : _fileList.Objects;
        List<T> items = new(selectedOnly ? 10 : _fileList.GetItemCount());
        items.AddRange(l.Cast<T>().Where(item => item != null));

        return items;
    }

    public void PrepareSourceFiles()
    {
        int c = _fileList.GetItemCount();
        if (c == 0)
        {
            return;
        }

        string[] f = new string[c];
        int i = 0;
        foreach (SourceItem item in _fileList.Objects)
        {
            if (item.Type == SourceItem.ItemType.Pdf)
            {
                f[i++] = item.FilePath.ToString();
            }
        }

        Array.Resize(ref f, i);
        AppContext.SourceFiles = f;
    }

    public void ResizeItemListColumns()
    {
        ColumnHeader c = _fileList.Columns[0];
        _fileList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        if (c.Width < 100)
        {
            c.Width = 100;
        }

        for (int i = 1; i < _fileList.Columns.Count; i++)
        {
            c = _fileList.Columns[i];
            if (c.Width < 50)
            {
                c.Width = 50;
            }
        }
    }
}
