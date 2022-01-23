﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;
using PDFPatcher.Common;
using PDFPatcher.Model;
using PDFPatcher.Processor;
using PDFPatcher.Properties;

namespace PDFPatcher.Functions;

[ToolboxItem(false)]
public partial class PatcherControl : FunctionControl
{
    private FileListHelper _listHelper;

    public PatcherControl() => InitializeComponent();

    public override string FunctionName => "Batch modified documentation";

    public override Bitmap IconImage => Resources.CreateDocument;

    public override Button DefaultButton => _ImportButton;

    private void PatcherControl_OnLoad(object sender, EventArgs e)
    {
        //this.Icon = Common.FormHelper.ToIcon (Properties.Resources.CreateDocument);

        AppContext.MainForm.SetTooltip(_ConfigButton, "Click here to set the PDF file modification options");
        AppContext.MainForm.SetTooltip(_ActionsBox,
            "Double-click the item to edit the action option; right-click the item to pop up the context menu");
        AppContext.MainForm.SetTooltip(_ItemList, "Add PDF files that need patch modification here");
        AppContext.MainForm.SetTooltip(_ImportButton,
            "Click this button to execute the patch to generate a new PDF file with the settings in the info file and PDF options");
        AppContext.MainForm.SetTooltip(_TargetPdfFile.FileList,
            "The generated target PDF file path (right-click the list to insert the file name substitute)");
        _ItemList.EmptyListMsg =
            "Please use the \"Add Files\" button to add PDF files to be processed, or drag and drop files from the Explorer to this list box";

        _ConfigButton.Click += (_, _) => AppContext.MainForm.SelectFunctionList(Function.PatcherOptions);

        _AddFilesButton.ButtonClick += (_, _) => { ExecuteCommand(Commands.Open); };
        _AddFilesButton.DropDownOpening += FileListHelper.OpenPdfButtonDropDownOpeningHandler;
        _AddFilesButton.DropDownItemClicked += (_, args) =>
        {
            _RecentFileMenu.Hide();
            ExecuteCommand(Commands.OpenFile, args.ClickedItem.ToolTipText);
        };

        _TargetPdfFile.FileMacroMenu.LoadStandardInfoMacros();
        _TargetPdfFile.FileMacroMenu.LoadStandardSourceFileMacros();
        _TargetPdfFile.BrowseForFile += FileControl_BrowseForFile;
        _TargetPdfFile.TargetFileChangedByBrowseButton += (_, args) =>
        {
            int i;
            string f = _TargetPdfFile.FileDialog.FileName;
            if (_ItemList.Items.Count <= 1 || (i = f.LastIndexOf(Path.DirectorySeparatorChar)) == -1)
            {
                return;
            }

            _TargetPdfFile.Text = string.Concat(f.Substring(0, i), Path.DirectorySeparatorChar,
                Constants.FileNameMacros.FileName, Path.GetExtension(f));
            args.Cancel = true;
        };
        ImageList.ImageCollection fi = _FileTypeList.Images;
        fi.AddRange(new Image[] { Resources.OriginalPdfFile });

        _ItemList.FixEditControlWidth();
        _ItemList.ListViewItemSorter = new ListViewItemComparer(0);
        _listHelper = new FileListHelper(_ItemList);
        _listHelper.SetupHotkeys();
        _listHelper.SetupDragAndDrop(AddFiles);
        FileListHelper.SetupCommonPdfColumns(_AuthorColumn, _KeywordsColumn, _SubjectColumn, _TitleColumn,
            _PageCountColumn, _NameColumn, _FolderColumn);
        _RefreshInfoButton.ButtonClick += (_, _) => _listHelper.RefreshInfo(AppContext.Encodings.DocInfoEncoding);
        _RefreshInfoButton.DropDown = _RefreshInfoMenu;
        foreach (string item in Constants.Encoding.EncodingNames)
        {
            _RefreshInfoMenu.Items.Add(item);
        }

        _RefreshInfoMenu.ItemClicked += (_, args) =>
        {
            _listHelper.RefreshInfo(ValueHelper.MapValue(args.ClickedItem.Text, Constants.Encoding.EncodingNames,
                Constants.Encoding.Encodings));
        };

        RecentFileItemClicked = (_, args) =>
        {
            args.ClickedItem.Owner.Hide();
            AddFiles(new[] { args.ClickedItem.ToolTipText }, true);
        };
    }

    public override void ExecuteCommand(string commandName, params string[] parameters)
    {
        switch (commandName)
        {
            case Commands.Open:
                {
                    OpenFileDialog b = _OpenPdfBox;
                    if (b.ShowDialog() == DialogResult.OK)
                    {
                        AddFiles(b.FileNames, true);
                    }

                    break;
                }
            case Commands.OpenFile:
                AddFiles(parameters, true);
                break;
            default:
                {
                    if (_listHelper.ProcessCommonMenuCommand(commandName) == false)
                    {
                        base.ExecuteCommand(commandName, parameters);
                    }

                    break;
                }
        }
    }

    public override void SetupCommand(ToolStripItem item)
    {
        string n = item.Name;
        if (Commands.CommonSelectionCommands.Contains(n) || n == Commands.Delete)
        {
            item.Enabled = _ItemList.GetItemCount() > 0 && _ItemList.Focused;
        }
        else if (n == Commands.Options)
        {
            item.Text = "Modify document settings (&S)...";
            item.ToolTipText = "Set the modified PDF document";
            EnableCommand(item, true, true);
            item.Tag = nameof(Function.PatcherOptions);
        }

        base.SetupCommand(item);
    }

    private void FileControl_BrowseForFile(object sender, EventArgs e) => _listHelper.PrepareSourceFiles();

    private void AddFiles(string[] files, bool alertInvalidFiles)
    {
        if (files == null || files.Length == 0)
        {
            return;
        }

        if ((ModifierKeys & Keys.Control) != Keys.None || _AutoClearListBox.Checked)
        {
            _ItemList.ClearObjects();
        }

        switch (files.Length)
        {
            case > 3:
                AppContext.MainForm.Enabled = false;
                break;
            case 0:
                return;
        }

        _AddDocumentWorker.RunWorkerAsync(files);
    }

    private void _ImportButton_Click(object sender, EventArgs e)
    {
        string targetPdfFile = _TargetPdfFile.Text.Trim();
        if (string.IsNullOrEmpty(targetPdfFile) &&
            string.IsNullOrEmpty(targetPdfFile = _TargetPdfFile.BrowseTargetFile()))
        {
            FormHelper.ErrorBox(Messages.TargetFileNotSpecified);
            return;
        }
        //if (_mode == ProcessMode.Merge && Common.FileHelper.IsPathValid (targetPdfFile) == false) {
        //    Common.FormHelper.ErrorBox ("The output file name is invalid." + (Common.FileUtility.HasFileNameMacro (targetPdfFile) ? "\nMaking the PDF file function does not support an alternative." : String.Empty));
        //    return;
        //}

        int l = _ItemList.GetItemCount();
        if (l == 0)
        {
            FormHelper.InfoBox("Add PDF files that need to be processed.");
            return;
        }

        List<SourceItem> files = GetSourceItemList();
        _TargetPdfFile.FileList.AddHistoryItem();

        AppContext.MainForm.ResetWorker();
        BackgroundWorker worker = AppContext.MainForm.GetWorker();
        worker.DoWork += (_, arg) =>
        {
            object[] a = arg.Argument as object[];
            string t = a[0] as string;
            if (files.Count > 1)
            {
                string targetFolder = null;
                bool m = FileHelper.HasFileNameMacro(t); // Contains alternative
                if (m == false)
                {
                    targetFolder = Path.GetDirectoryName(t);
                }

                Tracker.SetTotalProgressGoal(files.Count);
                foreach (SourceItem file in files)
                {
                    if (file.Type == SourceItem.ItemType.Pdf)
                    {
                        // Determine the information file name
                        // Take the XML information file with the same name as the input file
                        FilePath f = new(FileHelper.CombinePath(file.FolderName,
                            Path.ChangeExtension(file.FileName, Constants.FileExtensions.Xml)));
                        if (f.ExistsFile == false)
                        {
                            // TXT information file with the same name as the input file
                            f = f.ChangeExtension(Constants.FileExtensions.Txt);
                            if (f.ExistsFile == false)
                            {
                                // The same information file
                                f = file.FilePath.ChangeExtension(Constants.FileExtensions.Xml);
                                if (f.ExistsFile == false)
                                {
                                    f = FilePath.Empty;
                                }
                            }
                        }

                        Worker.PatchDocument(file as SourceItem.Pdf,
                            m ? t : FileHelper.CombinePath(targetFolder, file.FilePath.FileName),
                            f.ToString(),
                            AppContext.Importer,
                            AppContext.Patcher);
                    }
                    else
                    {
                        Tracker.TraceMessage("The input file is not a PDF file.");
                    }

                    Tracker.IncrementTotalProgress();
                    if (AppContext.Abort)
                    {
                        return;
                    }
                }
            }
            else
            {
                if (files[0].Type != SourceItem.ItemType.Pdf)
                {
                    Tracker.TraceMessage("The input file is not a PDF file.");
                    return;
                }

                Worker.PatchDocument(files[0] as SourceItem.Pdf,
                    t,
                    a[1] as string,
                    AppContext.Importer,
                    AppContext.Patcher);
            }
        };
        worker.RunWorkerAsync(new object[] { targetPdfFile, null });
    }

    private List<SourceItem> GetSourceItemList()
    {
        int l = _ItemList.GetItemCount();
        List<SourceItem> files = new(l);
        for (int i = 0; i < l; i++)
        {
            SourceItem item = _ItemList.GetModelObject(_ItemList.GetNthItemInDisplayOrder(i).Index) as SourceItem;
            if (item.Type == SourceItem.ItemType.Pdf
                && FileHelper.HasExtension(item.FilePath, Constants.FileExtensions.Pdf))
            {
                AppContext.RecentItems.AddHistoryItem(AppContext.Recent.SourcePdfFiles, item.FilePath.ToString());
            }

            files.Add(item);
        }

        return files;
    }

    private void _SortMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e) =>
        _ItemList.ListViewItemSorter = e.ClickedItem.Name switch
        {
            "_SortByAlphaItem" => new ListViewItemComparer(0, false),
            "_SortByNaturalNumberItem" => new ListViewItemComparer(0, true),
            _ => _ItemList.ListViewItemSorter
        };

    private void _ImageList_ColumnClick(object sender, ColumnClickEventArgs e)
    {
        int c = e.Column;
        bool ss = c == 0 || c == _PageCountColumn.Index;
        SortOrder o = _ItemList.PrimarySortOrder == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
        _ItemList.ListViewItemSorter = new ListViewItemComparer(e.Column, ss, o);
    }

    private void _MainToolbar_ItemClicked(object sender, ToolStripItemClickedEventArgs e) =>
        _listHelper.ProcessCommonMenuCommand(e.ClickedItem.Name);

    #region AddDocumentWorker

    private void _AddDocumentWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        string[] files = e.Argument as string[];
        Array.ForEach(files, f => { ((BackgroundWorker)sender).ReportProgress(0, f); });
    }

    private void _AddDocumentWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        AppContext.MainForm.Enabled = true;
        _listHelper.ResizeItemListColumns();
    }

    private void _AddDocumentWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        string item = e.UserState as string;
        AddItem(SourceItem.Create(item));
    }

    private void AddItem(SourceItem item)
    {
        if (item == null)
        {
            return;
        }

        AddItems(new[] { item });
    }

    private void AddItems(ICollection items)
    {
        int i = _ItemList.GetLastSelectedIndex();
        _ItemList.InsertObjects(++i, items);
        _ItemList.SelectedIndex = --i + items.Count;
    }

    #endregion
}
