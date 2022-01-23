using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using PDFPatcher.Common;
using PDFPatcher.Processor;
using PDFPatcher.Properties;

namespace PDFPatcher.Functions;

[ToolboxItem(false)]
public partial class ExtractPageControl : FunctionControl, IResettableControl
{
    public ExtractPageControl()
    {
        InitializeComponent();
        //Icon = FormHelper.ToIcon (Properties.Resources.ExtractPages);
        AppContext.MainForm.SetTooltip(_SourceFileControl.FileList,
            "The PDF file path of the page to be extracted, multiple files can be selected");
        AppContext.MainForm.SetTooltip(_ExtractPageRangeBox,
            "Extract the page number range of the page, extract all pages of the source file when the page number range is not specified");
        AppContext.MainForm.SetTooltip(_TargetFileControl.FileList,
            "The path of the output PDF file, right click to insert the file name substitute");
        AppContext.MainForm.SetTooltip(_ExtractButton,
            "Click this button to extract pages in the specified range of the source PDF file and generate a new file");
        AppContext.MainForm.SetTooltip(_SeparatingModeBox, "Choose how to split the source PDF document");
        AppContext.MainForm.SetTooltip(_SeperateByPageNumberBox, "Split the source PDF document by page number");
        AppContext.MainForm.SetTooltip(_NumberFileNamesBox,
            "Split by bookmarks: Add \"1 - \", \"2 - \" and other sequential numbers in front of the split file names; other splits: add numbers to the first file name");
        AppContext.MainForm.SetTooltip(_ExcludePageRangeBox, "Do not extract pages in this range");

        _TargetFileControl.FileMacroMenu.LoadStandardInfoMacros();
        _TargetFileControl.FileMacroMenu.LoadStandardSourceFileMacros();
    }

    public override string FunctionName => "Extraction page";

    public override Bitmap IconImage => Resources.ExtractPages;

    #region IDefaultButtonControl member

    public override Button DefaultButton => _ExtractButton;

    #endregion

    private void ExtractPageControl_Load(object sender, EventArgs e)
    {
        _SeparatingModeBox.SelectedIndexChanged += (_, _) =>
        {
            _NumberFileNamesBox.Text = _SeparatingModeBox.SelectedIndex == 1
                ? "Add a number in front of the file name"
                : "The first file name is also added to the number";
            _SeperateByPageNumberBox.Enabled = _SeparatingModeBox.SelectedIndex == 2;
        };
        ((IResettableControl)this).Reload();
    }

    private void _ExtractButton_Click(object sender, EventArgs e)
    {
        if (File.Exists(_SourceFileControl.FirstFile) == false)
        {
            FormHelper.ErrorBox(Messages.SourceFileNotFound);
            return;
        }

        if (_TargetFileControl.Text.IsNullOrWhiteSpace())
        {
            FormHelper.ErrorBox(Messages.TargetFileNotSpecified);
            return;
        }

        AppContext.SourceFiles = _SourceFileControl.Files;
        if (AppContext.SourceFiles.Length == 1)
        {
            _SourceFileControl.FileList.AddHistoryItem();
            _TargetFileControl.FileList.AddHistoryItem();
        }

        ExtractPageOptions o = AppContext.ExtractPage;
        o.KeepBookmarks = _KeepBookmarkBox.Checked;
        o.KeepDocumentProperties = _KeepDocInfoPropertyBox.Checked;
        o.RemoveOrphanBookmarks = _RemoveOrphanBoomarksBox.Checked;
        o.PageRanges = _ExtractPageRangeBox.Text;
        o.RemoveDocumentRestrictions = _RemoveRestrictionBox.Checked;
        o.ExcludePageRanges = _ExcludePageRangeBox.Text;
        o.SeparatingMode = _SeparatingModeBox.SelectedIndex;
        o.SeparateByPage = (int)_SeperateByPageNumberBox.Value;
        o.NumberFileNames = _NumberFileNamesBox.Checked;

        AppContext.MainForm.ResetWorker();
        BackgroundWorker worker = AppContext.MainForm.GetWorker();
        worker.DoWork += (_, arg) =>
        {
            object[] a = arg.Argument as object[];
            string[] files = a[0] as string[];
            string t = a[1] as string;
            ExtractPageOptions options = a[2] as ExtractPageOptions;
            if (files.Length > 1)
            {
                bool m = FileHelper.HasFileNameMacro(t); // Contains alternative
                string p = m ? null : Path.GetDirectoryName(t);
                Tracker.SetTotalProgressGoal(files.Length);
                foreach (string file in files)
                {
                    Worker.ExtractPages(options,
                        file,
                        m
                            ? t
                            : FileHelper.CombinePath(p,
                                Path.GetFileNameWithoutExtension(file) + Constants.FileExtensions.Pdf));
                    Tracker.IncrementTotalProgress();
                    if (AppContext.Abort)
                    {
                        return;
                    }
                }
            }
            else
            {
                Worker.ExtractPages(options, files[0], t);
            }
        };
        worker.RunWorkerAsync(new object[] { AppContext.SourceFiles, _TargetFileControl.Text, AppContext.ExtractPage });
    }

    private void _ExtractPageRangeBox_TextChanged(object sender, EventArgs e) =>
        AppContext.Exporter.ExtractPageRange = _ExtractPageRangeBox.Text;


    #region IResettableControl member

    void IResettableControl.Reset()
    {
        AppContext.ExtractPage = new ExtractPageOptions();
        ((IResettableControl)this).Reload();
    }

    void IResettableControl.Reload()
    {
        ExtractPageOptions options = AppContext.ExtractPage;
        _KeepBookmarkBox.Checked = options.KeepBookmarks;
        _KeepDocInfoPropertyBox.Checked = options.KeepDocumentProperties;
        _RemoveRestrictionBox.Checked = options.RemoveDocumentRestrictions;
        _RemoveOrphanBoomarksBox.Checked = options.RemoveOrphanBookmarks;
        _SeparatingModeBox.Select(options.SeparatingMode);
        _NumberFileNamesBox.Checked = options.NumberFileNames;
        _SeperateByPageNumberBox.SetValue(options.SeparateByPage);
    }

    #endregion
}
