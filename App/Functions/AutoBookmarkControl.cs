using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using BrightIdeasSoftware;
using PDFPatcher.Common;
using PDFPatcher.Model;
using PDFPatcher.Processor;
using PDFPatcher.Properties;

namespace PDFPatcher.Functions;

[ToolboxItem(false)]
public partial class AutoBookmarkControl : FunctionControl, IResettableControl
{
    private static AutoBookmarkOptions.LevelAdjustmentOption[] _copiedLevelAdjustments;
    private AutoBookmarkOptions _options;

    public AutoBookmarkControl()
    {
        InitializeComponent();
        //this.Icon = FormHelper.ToIcon (Properties.Resources.ExportInfoFile);
        AppContext.MainForm.SetTooltip(_SourceFileControl.FileList,
            "Need to identify the PDF source file path titled bookmark");
        AppContext.MainForm.SetTooltip(_BookmarkControl.FileList,
            "Specify the path of the information file or simple text bookmark file generated after bookmark recognition");
        AppContext.MainForm.SetTooltip(_ExportBookmarkButton,
            "Click this button to identify the title of the PDF file as an information file");
        AppContext.MainForm.SetTooltip(_TitleSizeThresholdBox,
            "Specify the minimum size of the title text, text smaller than this size will be ignored");
        AppContext.MainForm.SetTooltip(_AutoHierarchicleArrangementBox,
            "Generate multi-level bookmarks according to the size level of the title text");
        AppContext.MainForm.SetTooltip(_YOffsetBox,
            "The line spacing to offset the positioning position of the title up");
        AppContext.MainForm.SetTooltip(_MergeAdjacentTitlesBox, "Merge consecutive titles into one title");
        AppContext.MainForm.SetTooltip(_MergeDifferentSizeTitlesBox, "Merge adjacent titles of different sizes");
        AppContext.MainForm.SetTooltip(_GoToPageTopLevelBox,
            "Titles smaller than the specified number of layers are positioned at the top of the page, not at the exact location");
        AppContext.MainForm.SetTooltip(_IgnoreOverlappedTextBox,
            "Ignore overlapping text used to make bold, shadow, etc.");
        AppContext.MainForm.SetTooltip(_CreateBookmarkForFirstPageBox,
            "Generate a bookmark pointing to the first page of the document, the bookmark text is the name of the PDF file");
        AppContext.MainForm.SetTooltip(_PageRangeBox, Messages.PageRanges);

        int i = 0;
        foreach (string item in EditAdjustmentForm.FilterNames)
        {
            _AddFilterMenu.Items.Add(item).Name = EditAdjustmentForm.FilterIDs[i++];
        }

        _LevelAdjustmentBox.CellEditUseWholeCell = true;
        _LevelAdjustmentBox.BeforeSorting += (_, e) => { e.Canceled = true; };
        _LevelAdjustmentBox.DropSink = new RearrangingDropSink(false);
        _AdvancedFilterColumn.AspectGetter = x =>
            x is not AutoBookmarkOptions.LevelAdjustmentOption f ? null : f.Condition.Description;
        _AdjustmentLevelColumn.AspectGetter = x =>
        {
            AutoBookmarkOptions.LevelAdjustmentOption f = x as AutoBookmarkOptions.LevelAdjustmentOption;
            return f?.AdjustmentLevel ?? 0;
        };
        _AdjustmentLevelColumn.AspectPutter = (x, value) =>
        {
            if (x is not AutoBookmarkOptions.LevelAdjustmentOption f)
            {
                return;
            }

            if ((value ?? "0").ToString().TryParse(out float a))
            {
                f.AdjustmentLevel = a;
            }
        };
        _RelativeAdjustmentColumn.AspectGetter = x =>
            (x as AutoBookmarkOptions.LevelAdjustmentOption)?.RelativeAdjustment == true;
        _RelativeAdjustmentColumn.AspectPutter = (x, value) =>
        {
            if (x is not AutoBookmarkOptions.LevelAdjustmentOption f)
            {
                return;
            }

            f.RelativeAdjustment = value is true;
        };
        _FilterBeforeMergeColumn.AspectGetter = x =>
            (x as AutoBookmarkOptions.LevelAdjustmentOption)?.FilterBeforeMergeTitle ?? false;
        _FilterBeforeMergeColumn.AspectPutter = (x, value) =>
        {
            if (x is AutoBookmarkOptions.LevelAdjustmentOption f)
            {
                f.FilterBeforeMergeTitle = value is true;
            }
        };

        Reload();

        FileDialog d = _BookmarkControl.FileDialog;
        d.CheckFileExists = false;
        d.CheckPathExists = false;

        if (d is SaveFileDialog sd)
        {
            sd.OverwritePrompt = false;
        }
    }

    public override string FunctionName => "Automatically generate bookmarks";

    public override Bitmap IconImage => Resources.AutoBookmark;

    public override Button DefaultButton => _ExportBookmarkButton;

    public void Reset()
    {
        AppContext.AutoBookmarker = new AutoBookmarkOptions();
        Reload();
    }

    public void Reload()
    {
        _options = AppContext.AutoBookmarker;
        _CreateBookmarkForFirstPageBox.Checked = _options.CreateBookmarkForFirstPage;
        _MergeAdjacentTitlesBox.Checked = _options.MergeAdjacentTitles;
        _MergeDifferentSizeTitlesBox.Checked = _options.MergeDifferentSizeTitles;
        _AutoHierarchicleArrangementBox.Checked = _options.AutoHierarchicalArrangement;
        _IgnoreNumericTitleBox.Checked = _options.IgnoreNumericTitle;
        _IgnoreOverlappedTextBox.Checked = _options.IgnoreOverlappedText;
        _IgnoreSingleCharacterTitleBox.Checked = _options.IgnoreSingleCharacterTitle;
        _ShowAllFontsBox.Checked = _options.DisplayAllFonts;
        _DisplayFontStatisticsBox.Checked = _options.DisplayFontStatistics;
        _WritingDirectionBox.SelectedIndex = (int)_options.WritingDirection;
        _MergeDifferentFontTitlesBox.Checked = _options.MergeDifferentFontTitles;
        _TitleSizeThresholdBox.SetValue(_options.TitleThreshold);
        _YOffsetBox.SetValue(_options.YOffset);
        _MaxDistanceBetweenLinesBox.SetValue(_options.MaxDistanceBetweenLines);
        _FirstLineAsTitleBox.Checked = _options.FirstLineAsTitle;

        for (int i = _options.LevelAdjustment.Count - 1; i >= 0; i--)
        {
            if (_options.LevelAdjustment[i].Condition == null)
            {
                _options.LevelAdjustment.RemoveAt(i);
            }
        }

        _LevelAdjustmentBox.SetObjects(_options.LevelAdjustment);
        _IgnorePatternsBox.Rows.Clear();
        foreach (MatchPattern item in _options.IgnorePatterns)
        {
            if (string.IsNullOrEmpty(item.Text))
            {
                continue;
            }

            _IgnorePatternsBox.Rows.Add(item.Text, item.MatchCase, item.FullMatch, item.UseRegularExpression);
        }
    }

    private void _ExportBookmarkButton_Click(object sender, EventArgs e)
    {
        if (File.Exists(_SourceFileControl.FirstFile) == false)
        {
            FormHelper.ErrorBox(Messages.SourceFileNotFound);
            return;
        }

        if (string.IsNullOrEmpty(_BookmarkControl.Text))
        {
            FormHelper.ErrorBox(Messages.InfoDocNotSpecified);
            return;
        }

        AppContext.SourceFiles = _SourceFileControl.Files;
        AppContext.BookmarkFile = _BookmarkControl.Text;
        if (_SourceFileControl.Files.Length == 1)
        {
            _SourceFileControl.FileList.AddHistoryItem();
            _BookmarkControl.FileList.AddHistoryItem();
        }

        AppContext.MainForm.ResetWorker();
        AppContext.MainForm.GetWorker().DoWork += ExportControl_DoWork;
        SyncOptions();
        AppContext.MainForm.GetWorker()
            .RunWorkerAsync(new object[] { AppContext.SourceFiles, AppContext.BookmarkFile, _options });
    }

    private void SyncOptions()
    {
        _options.CreateBookmarkForFirstPage = _CreateBookmarkForFirstPageBox.Checked;
        _options.PageRanges = _PageRangeBox.Text;
        _options.TitleThreshold = (float)_TitleSizeThresholdBox.Value;
        _options.MergeAdjacentTitles = _MergeAdjacentTitlesBox.Checked;
        _options.IgnoreNumericTitle = _IgnoreNumericTitleBox.Checked;
        _options.IgnoreOverlappedText = _IgnoreOverlappedTextBox.Checked;
        _options.IgnoreSingleCharacterTitle = _IgnoreSingleCharacterTitleBox.Checked;
        _options.MergeDifferentSizeTitles = _MergeDifferentSizeTitlesBox.Checked;
        _options.MergeDifferentFontTitles = _MergeDifferentFontTitlesBox.Checked;
        _options.YOffset = (float)_YOffsetBox.Value;
        _options.ExportTextCoordinates = _ExportTextCoordinateBox.Checked;
        _options.PageTopForLevel = (int)_GoToPageTopLevelBox.Value;
        _options.AutoHierarchicalArrangement = _AutoHierarchicleArrangementBox.Checked;
        _options.DisplayFontStatistics = _DisplayFontStatisticsBox.Checked;
        _options.DisplayAllFonts = _ShowAllFontsBox.Checked;
        _options.WritingDirection = (WritingDirection)_WritingDirectionBox.SelectedIndex;
        _options.MaxDistanceBetweenLines = (float)_MaxDistanceBetweenLinesBox.Value;
        _options.FirstLineAsTitle = _FirstLineAsTitleBox.Checked;
        _options.IgnorePatterns.Clear();
        foreach (DataGridViewRow item in _IgnorePatternsBox.Rows)
        {
            if (item.IsNewRow)
            {
                continue;
            }

            DataGridViewCellCollection cells = item.Cells;
            if (cells[0].Value == null)
            {
                continue;
            }

            _options.IgnorePatterns.Add(new MatchPattern(
                cells[0].Value.ToString(),
                (bool)(cells[_MatchCaseColumn.Index].Value ?? false),
                (bool)(cells[_FullMatchColumn.Index].Value ?? false),
                (bool)(cells[_PatternTypeColumn.Index].Value ?? false)));
        }

        _options.LevelAdjustment.Clear();
        if (_LevelAdjustmentBox.Items.Count <= 0)
        {
            return;
        }

        {
            foreach (ListViewItem item in _LevelAdjustmentBox.Items)
            {
                _options.LevelAdjustment.Add(
                    _LevelAdjustmentBox.GetModelObject(item.Index) as AutoBookmarkOptions.LevelAdjustmentOption);
            }
        }
    }

    private static void ExportControl_DoWork(object sender, DoWorkEventArgs e)
    {
        object[] a = e.Argument as object[];
        string[] files = a[0] as string[];
        string b = a[1] as string;
        AutoBookmarkOptions options = a[2] as AutoBookmarkOptions;
        if (files.Length > 1)
        {
            string p = Path.GetDirectoryName(b);
            string ext = Path.GetExtension(b);
            foreach (string file in files)
            {
                Worker.CreateBookmark(file, FileHelper.CombinePath(p, Path.GetFileNameWithoutExtension(file) + ext),
                    options);
                if (AppContext.Abort)
                {
                    return;
                }
            }
        }
        else
        {
            Worker.CreateBookmark(files[0], b, options);
        }
    }

    private void _IgnorePatternsBox_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == _RemovePatternColumn.Index)
        {
            _IgnorePatternsBox.Rows.RemoveAt(e.RowIndex);
        }
    }

    private void ControlEvent(object sender, EventArgs e)
    {
        if (sender == _DeleteAdjustmentButton && _LevelAdjustmentBox.Items.Count > 0 &&
            FormHelper.YesNoBox("Do you want to delete the selected item?") == DialogResult.Yes)
        {
            _LevelAdjustmentBox.RemoveObjects(_LevelAdjustmentBox.SelectedObjects);
        }
        else if (sender == _ClearTextFiltersButton && _IgnorePatternsBox.Rows.Count > 0 &&
                 FormHelper.YesNoBox("Do you wan to clear the text filters?") == DialogResult.Yes)
        {
            _IgnorePatternsBox.Rows.Clear();
        }
        else if (sender == _CopyFilterButton)
        {
            IList si = _LevelAdjustmentBox.SelectedObjects;
            if (si.Count == 0)
            {
                return;
            }

            _copiedLevelAdjustments = new AutoBookmarkOptions.LevelAdjustmentOption[si.Count];
            for (int i = 0; i < _copiedLevelAdjustments.Length; i++)
            {
                AutoBookmarkOptions.LevelAdjustmentOption item = si[i] as AutoBookmarkOptions.LevelAdjustmentOption;
                _copiedLevelAdjustments[i] = item;
            }
        }
        else if (sender == _PasteButton)
        {
            //var s = Clipboard.GetText ();
            //if (String.IsNullOrEmpty (s) == false && s.Length < 100) {
            //    _LevelAdjustmentBox.AddObject (new AutoBookmarkOptions.LevelAdjustmentOption () {
            //        Condition = new AutoBookmarkCondition.FontNameCondition (s, false)
            //    });
            //    return;
            //}
            if (_copiedLevelAdjustments.HasContent() == false)
            {
                return;
            }

            foreach (AutoBookmarkOptions.LevelAdjustmentOption item in _copiedLevelAdjustments)
            {
                _LevelAdjustmentBox.AddObject(item.Clone());
            }
        }
        else if (sender == _AddFilterFromInfoFileButton)
        {
            if (string.IsNullOrEmpty(_BookmarkControl.Text))
            {
                if (_BookmarkControl.FileDialog.ShowDialog() != DialogResult.OK)
                {
                    FormHelper.InfoBox("Please specify the path to the information file.");
                    return;
                }

                _BookmarkControl.Text = _BookmarkControl.FileDialog.FileName;
            }

            XmlDocument doc = new();
            XmlNode fontInfo;
            try
            {
                doc.Load(_BookmarkControl.Text);
                fontInfo = doc.SelectSingleNode(Constants.PdfInfo + "/" + Constants.Font.DocumentFont);
            }
            catch (Exception ex)
            {
                FormHelper.ErrorBox("Unable to load font information from the information file." + ex.Message);
                return;
            }

            if (fontInfo == null)
            {
                FormHelper.ErrorBox("Unable to load font information from the information file.");
                return;
            }

            using FontFilterForm f = new(fontInfo);
            if (f.ShowDialog() != DialogResult.OK || f.FilterConditions == null)
            {
                return;
            }

            foreach (AutoBookmarkCondition item in f.FilterConditions)
            {
                _LevelAdjustmentBox.AddObject(new AutoBookmarkOptions.LevelAdjustmentOption
                {
                    Condition = item,
                    AdjustmentLevel = 0,
                    RelativeAdjustment = false
                });
            }
        }
    }

    private void _LevelAdjustmentBox_ItemActivate(object sender, EventArgs e)
    {
        if (_LevelAdjustmentBox.FocusedItem == null)
        {
            return;
        }

        ListViewItem fi = _LevelAdjustmentBox.FocusedItem;
        int i = fi.Index;
        AutoBookmarkOptions.LevelAdjustmentOption o =
            _LevelAdjustmentBox.GetModelObject(i) as AutoBookmarkOptions.LevelAdjustmentOption;
        using EditAdjustmentForm dialog = new(o);
        if (dialog.ShowDialog() != DialogResult.OK)
        {
            return;
        }

        if (dialog.Filter.Condition != null)
        {
            _LevelAdjustmentBox.InsertObjects(i,
                new[] { dialog.Filter });
            _LevelAdjustmentBox.SelectedIndex = i;
        }

        _LevelAdjustmentBox.RemoveObject(o);
    }

    private void _AddFilterMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
        AutoBookmarkCondition c = EditAdjustmentForm.CreateCondition(e.ClickedItem.Name);
        if (c == null)
        {
            return;
        }

        using EditAdjustmentForm dialog = new(new AutoBookmarkOptions.LevelAdjustmentOption { Condition = c });
        if (dialog.ShowDialog() == DialogResult.OK && dialog.Filter.Condition != null)
        {
            _LevelAdjustmentBox.AddObject(dialog.Filter);
        }
    }
}
