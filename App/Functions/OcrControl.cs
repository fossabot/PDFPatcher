using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using PDFPatcher.Common;
using PDFPatcher.Model;
using PDFPatcher.Processor;
using PDFPatcher.Properties;

namespace PDFPatcher.Functions;

[ToolboxItem(false)]
public partial class OcrControl : FunctionControl, IResettableControl
{
    private OcrOptions _options;

    public OcrControl()
    {
        InitializeComponent();
        //this.Icon = Common.FormHelper.ToIcon (Properties.Resources.Ocr);
        _BookmarkControl.FileDialog.Filter = Constants.FileExtensions.TxtFilter + "|" +
                                             Constants.FileExtensions.XmlFilter + "|" +
                                             Constants.FileExtensions.XmlOrTxtFilter;

        AppContext.MainForm.SetTooltip(_SourceFileControl.FileList, "PDF source file path to recognize text");
        AppContext.MainForm.SetTooltip(_BookmarkControl.FileList,
            "Specify the information file or text file path generated after identifying the text, if the path is empty, the file will not be output");
        AppContext.MainForm.SetTooltip(_ExportBookmarkButton,
            "Click this button to export the recognized text to a file");
        AppContext.MainForm.SetTooltip(_ImportOcrResultButton,
            "Click this button to write the recognized text content to the target PDF file.");
        AppContext.MainForm.SetTooltip(_PageRangeBox, Messages.PageRanges);
        AppContext.MainForm.SetTooltip(_DetectColumnsBox,
            "Allows farther text to be merged into the same line of text");
        AppContext.MainForm.SetTooltip(_DetectContentPunctuationsBox,
            "Replace more than three consecutive punctuations with \"... \"");
        AppContext.MainForm.SetTooltip(_CompressWhiteSpaceBox,
            "Compress three or more consecutive spaces into two spaces");
        AppContext.MainForm.SetTooltip(_OrientBox,
            "Automatically detect the horizontal and vertical orientation of the page");
        AppContext.MainForm.SetTooltip(_StretchBox, "Automatically straighten skewed pages");
        AppContext.MainForm.SetTooltip(_OutputOriginalOcrResultBox,
            "Save the original unoptimized merged recognition result (can be used to write PDF documents)");

        ComboBox.ObjectCollection lb = _OcrLangBox.Items;
        if (ModiOcr.ModiInstalled)
        {
            foreach (int item in Constants.Ocr.LangIDs)
            {
                if (ModiOcr.IsLanguageInstalled(item))
                {
                    lb.Add(ValueHelper.MapValue(item, Constants.Ocr.LangIDs, Constants.Ocr.LangNames));
                }
            }
        }

        if (lb.Count == 0)
        {
            lb.Add("None");
        }

        _ExportBookmarkButton.Enabled = ModiOcr.ModiInstalled;
        if (_ExportBookmarkButton.Enabled == false)
        {
            AppContext.MainForm.SetTooltip(_OcrLangBox,
                "The current system has not installed the identification engine, please install the Microsoft Office text recognition engine, restart the program.");
        }

        Reload();

        FileDialog d = _BookmarkControl.FileDialog;
        d.CheckFileExists = false;
        d.CheckPathExists = false;

        if (d is SaveFileDialog sd)
        {
            sd.OverwritePrompt = false;
        }
    }

    public override string FunctionName => "Identify image text";

    public override Bitmap IconImage => Resources.Ocr;

    public override Button DefaultButton => _ExportBookmarkButton;

    public void Reset()
    {
        AppContext.Ocr = new OcrOptions();
        Reload();
    }

    public void Reload()
    {
        _options = AppContext.Ocr;
        _CompressWhiteSpaceBox.Checked = _options.CompressWhiteSpaces;
        _ConvertToMonoColorBox.Checked = !_options.PreserveColor;
        _DetectColumnsBox.Checked = _options.DetectColumns;
        _DetectContentPunctuationsBox.Checked = _options.DetectContentPunctuations;
        int i = Array.IndexOf(Constants.Ocr.LangIDs, _options.OcrLangID);
        _OcrLangBox.Select(i > 0 ? i : 0);
        _OrientBox.Checked = _options.OrientPage;
        _RemoveSpaceBetweenChineseBox.Checked = _options.RemoveWhiteSpacesBetweenChineseCharacters;
        _SaveOcredImageBox.Checked = !string.IsNullOrEmpty(_options.SaveOcredImagePath);
        _StretchBox.Checked = _options.StretchPage;
        _OutputOriginalOcrResultBox.Checked = _options.OutputOriginalOcrResult;
        _PrintOcrResultBox.Checked = _options.PrintOcrResult;

        _WritingDirectionBox.SelectedIndex = (int)_options.WritingDirection;
        _QuantitiveFactorBox.SetValue(_options.QuantitativeFactor);
    }

    public override void SetupCommand(ToolStripItem item)
    {
        string n = item.Name;
        switch (n)
        {
            case Commands.SaveBookmark:
                item.Text = "Write a PDF file (&Q)";
                item.ToolTipText = "Write the identification result into a PDF file";
                EnableCommand(item, true, true);
                break;
        }

        base.SetupCommand(item);
    }

    public override void ExecuteCommand(string commandName, params string[] parameters)
    {
        switch (commandName)
        {
            case Commands.SaveBookmark:
                _ImportOcrResultButton.PerformClick();
                return;
        }

        base.ExecuteCommand(commandName, parameters);
    }

    private void Button_Click(object sender, EventArgs e)
    {
        if (File.Exists(_SourceFileControl.FirstFile) == false)
        {
            FormHelper.ErrorBox(Messages.SourceFileNotFound);
            return;
        }

        if (sender == _ImportOcrResultButton)
        {
            if (FileHelper.IsPathValid(_TargetFileControl.Text) == false)
            {
                FormHelper.ErrorBox(Messages.TargetFileNameInvalid);
                return;
            }

            if (_BookmarkControl.Text.Length == 0)
            {
                FormHelper.ErrorBox("Please specify the identification result file.");
                return;
            }
        }
        //else if (String.IsNullOrEmpty (_BookmarkControl.Text)) {
        //    Common.Form.ErrorBox (Messages.InfoDocNotSpecified);
        //    return;
        //}

        AppContext.SourceFiles = _SourceFileControl.Files;
        AppContext.BookmarkFile = _BookmarkControl.Text;
        AppContext.TargetFile = _TargetFileControl.Text;
        if (_SourceFileControl.Files.Length == 1)
        {
            _SourceFileControl.FileList.AddHistoryItem();
            if (_BookmarkControl.Text.Length > 0)
            {
                _BookmarkControl.FileList.AddHistoryItem();
            }
        }

        if (sender == _ImportOcrResultButton)
        {
            _TargetFileControl.FileList.AddHistoryItem();
        }

        AppContext.MainForm.ResetWorker();

        SyncOptions();

        BackgroundWorker worker = AppContext.MainForm.GetWorker();
        if (sender != _ImportOcrResultButton)
        {
            worker.DoWork += OcrExport;
            worker.RunWorkerAsync(new object[] { AppContext.SourceFiles, AppContext.BookmarkFile, _options });
        }
        else
        {
            worker.DoWork += ImportOcr;
            worker.RunWorkerAsync(new object[]
            {
                AppContext.SourceFiles, AppContext.BookmarkFile, AppContext.TargetFile
            });
        }
    }

    private void SyncOptions()
    {
        _options.CompressWhiteSpaces = _CompressWhiteSpaceBox.Checked;
        _options.PreserveColor = !_ConvertToMonoColorBox.Checked;
        _options.DetectColumns = _DetectColumnsBox.Checked;
        _options.DetectContentPunctuations = _DetectContentPunctuationsBox.Checked;
        _options.PageRanges = _PageRangeBox.Text;
        _options.OcrLangID = ValueHelper.MapValue(_OcrLangBox.Text, Constants.Ocr.LangNames, Constants.Ocr.LangIDs, -1);
        _options.OrientPage = _OrientBox.Checked;
        _options.OutputOriginalOcrResult = _OutputOriginalOcrResultBox.Checked;
        _options.QuantitativeFactor = (float)_QuantitiveFactorBox.Value;
        _options.PrintOcrResult = _PrintOcrResultBox.Checked;
        _options.RemoveWhiteSpacesBetweenChineseCharacters = _RemoveSpaceBetweenChineseBox.Checked;
        _options.StretchPage = _StretchBox.Checked;
        // _options.SaveOcredImagePath = String.IsNullOrEmpty (this._BookmarkControl.Text) ? null : Common.FileHelper.CombinePath (Path.GetDirectoryName (this._BookmarkControl.Text), Path.GetFileNameWithoutExtension (_BookmarkControl.Text) + Constants.FileExtensions.Tif);
        _options.WritingDirection = (WritingDirection)_WritingDirectionBox.SelectedIndex;
    }

    private static void OcrExport(object sender, DoWorkEventArgs e)
    {
        object[] a = e.Argument as object[];
        string[] files = a[0] as string[];
        string b = a[1] as string;
        OcrOptions options = a[2] as OcrOptions;
        if (files.Length > 1)
        {
            string p = Path.GetDirectoryName(b);
            string ext = Path.GetExtension(b);
            foreach (string file in files)
            {
                Worker.Ocr(file, FileHelper.CombinePath(p, Path.GetFileNameWithoutExtension(file) + ext), options);
                if (AppContext.Abort)
                {
                    return;
                }
            }
        }
        else
        {
            Worker.Ocr(files[0], b, options);
        }
    }

    private static void ImportOcr(object sender, DoWorkEventArgs e)
    {
        object[] a = e.Argument as object[];
        string[] files = a[0] as string[];
        string b = a[1] as string;
        string target = a[2] as string;
        if (files.Length > 1)
        {
            string p = Path.GetDirectoryName(b);
            string ext = Path.GetExtension(b);
            foreach (string file in files)
            {
                Worker.ImportOcr(file, FileHelper.CombinePath(p, Path.GetFileNameWithoutExtension(file) + ext), target);
                if (AppContext.Abort)
                {
                    return;
                }
            }
        }
        else
        {
            Worker.ImportOcr(files[0], b, target);
        }
    }

    private void ControlEvent(object sender, EventArgs e)
    {
        if (sender == _WritingDirectionBox)
        {
            _DetectColumnsBox.Enabled = _WritingDirectionBox.SelectedIndex != 0;
        }
        else if (sender == _OutputOriginalOcrResultBox)
        {
            _DetectColumnsBox.Enabled
                = _DetectContentPunctuationsBox.Enabled
                    = _CompressWhiteSpaceBox.Enabled
                        = _RemoveSpaceBetweenChineseBox.Enabled
                            = !_OutputOriginalOcrResultBox.Checked;
        }
    }
}
