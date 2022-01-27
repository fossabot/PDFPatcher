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
public partial class ExtractImageControl : FunctionControl, IResettableControl
{
    public ExtractImageControl()
    {
        InitializeComponent();
        //this.Icon = Common.FormHelper.ToIcon (Properties.Resources.ExtractImage);
        _SourceFileControl.BrowseSelectedFiles += (_, _) =>
        {
            if (_AutoOutputDirBox.Checked == false)
            {
                return;
            }

            string sourceFile = _SourceFileControl.FirstFile;
            if (sourceFile.Length > 0)
            {
                _TargetBox.Text = FileHelper.CombinePath(Path.GetDirectoryName(sourceFile),
                    Path.GetFileNameWithoutExtension(sourceFile));
            }
        };
        _AutoOutputDirBox.CheckedChanged += (_, _) =>
        {
            AppContext.ImageExtracter.AutoOutputFolder = _AutoOutputDirBox.Checked;
        };
    }

    public override string FunctionName => "Extract Image";

    public override Bitmap IconImage => Resources.ExtractImage;

    #region IDefaultButtonControl member

    public override Button DefaultButton => _ExtractButton;

    #endregion

    public void Reset()
    {
        AppContext.ImageExtracter = new ImageExtracterOptions();
        Reload();
    }

    public void Reload()
    {
        ImageExtracterOptions o = AppContext.ImageExtracter;
        _AutoOutputDirBox.Checked = o.AutoOutputFolder;
        _FileNameMaskBox.Text = o.FileMask;
        _InvertBlackAndWhiteBox.Checked = o.InvertBlackAndWhiteImages;
        _MonoTiffBox.Checked = !o.MonoPng;
        _MergeImageBox.Checked = o.MergeImages;
        _MergeJpgToPngBox.Checked = o.MergeJpgToPng;
        _ExportAnnotImagesBox.Checked = o.ExtractAnnotationImages;
        _MinHeightBox.SetValue(o.MinHeight);
        _MinWidthBox.SetValue(o.MinWidth);
        _VerticalFlipImageBox.Checked = o.VerticalFlipImages;
        _ExportSoftMaskBox.Checked = o.ExtractSoftMask;
        _InvertSoftMaskBox.Checked = o.InvertSoftMask;
        _MonoPngBox.Checked = o.MonoPng;
        _SkipRedundantImagesBox.Checked = o.SkipRedundantImages;
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        ShowFileMaskPreview();
        AppContext.MainForm.SetTooltip(_SourceFileControl.FileList, "Path to PDF file containing images");
        AppContext.MainForm.SetTooltip(_TargetBox, "The path to the folder where the output image is placed");
        AppContext.MainForm.SetTooltip(_ExtractPageRangeBox,
            "Specify the page number range to extract the image here, if the page number range is not specified, extract the images of all pages");
        AppContext.MainForm.SetTooltip(_FileNameMaskBox,
            "The name of the extracted image file is named according to the number of the page where it is located, and the naming rules can be modified here\n\"0000\": If there are less than four digits, use 0 to make up the four digits\n\"0\": The file name is based on the actual page number, without 0 to make up the digits\n n You can enclose the text in English double quotation marks (such as \"\\\" is about 2000\"0\", the preceding \"2000\" will not be interpreted as a placeholder)");
        AppContext.MainForm.SetTooltip(_MergeImageBox,
            "Attempt to merge images under the same page into the same file\n①The format of the merged images must be the same\n②The width must be the same\n③Only in PNG and TIFF format");
        AppContext.MainForm.SetTooltip(_VerticalFlipImageBox,
            "The image exported from some PDF files is upside down, you can use this option to restore it");
        AppContext.MainForm.SetTooltip(_InvertBlackAndWhiteBox,
            "Invert the color of PNG and TIFF black and white images");
        AppContext.MainForm.SetTooltip(_MinHeightBox,
            "Ignore images whose height is less than the value specified here");
        AppContext.MainForm.SetTooltip(_MinWidthBox,
            "Ignore images with a width smaller than the value specified here");
        AppContext.MainForm.SetTooltip(_MergeJpgToPngBox,
            "Merge JPEG images with lossy compression into PNG images with lossless compression when merging images");
        AppContext.MainForm.SetTooltip(_ExtractButton,
            "Click this button to extract the image of the PDF file to the specified directory");
        AppContext.MainForm.SetTooltip(_SkipRedundantImagesBox,
            "Avoid exporting images with consistent internal reference values ​​in PDF");
        Reload();
    }

    private void _BrowseTargetPdfButton_Click(object sender, EventArgs e)
    {
        string sourceFile = _SourceFileControl.Text;
        if (_TargetBox.Text.Length > 0)
        {
            _SaveImageBox.SelectedPath = Path.GetDirectoryName(_TargetBox.Text);
        }
        else if (sourceFile.Length > 0)
        {
            _SaveImageBox.SelectedPath = Path.GetDirectoryName(sourceFile);
        }

        if (_SaveImageBox.ShowDialog() == DialogResult.OK)
        {
            _TargetBox.Text =
                _SaveImageBox.SelectedPath
                //+ (_SaveImageBox.SelectedPath.EndsWith ("\\") ? String.Empty : "\\")
                //+ Path.GetFileNameWithoutExtension (sourceFile)
                ;
        }
    }

    private void _ExtractButton_Click(object sender, EventArgs e)
    {
        if (File.Exists(_SourceFileControl.FirstFile) == false)
        {
            FormHelper.ErrorBox(Messages.SourceFileNotFound);
            return;
        }

        if (_TargetBox.Text.IsNullOrWhiteSpace())
        {
            _BrowseTargetPdfButton_Click(_BrowseTargetPdfButton, e);
            if (_TargetBox.Text.IsNullOrWhiteSpace())
            {
                return;
            }
        }

        AppContext.SourceFiles = _SourceFileControl.Files;
        if (_SourceFileControl.Files.Length == 1)
        {
            _SourceFileControl.FileList.AddHistoryItem();
            _TargetBox.AddHistoryItem();
        }

        AppContext.MainForm.ResetWorker();
        BackgroundWorker worker = AppContext.MainForm.GetWorker();
        worker.DoWork += (_, arg) =>
        {
            object[] a = arg.Argument as object[];
            string[] files = a[0] as string[];
            ImageExtracterOptions options = a[1] as ImageExtracterOptions;
            options.OutputPath = new FilePath(options.OutputPath).Normalize();
            if (files.Length > 1)
            {
                string ep = options.OutputPath;
                Tracker.SetTotalProgressGoal(files.Length);
                foreach (string file in files)
                {
                    options.OutputPath = new FilePath(ep).Combine(new FilePath(file).FileNameWithoutExtension)
                        .Normalize();
                    Worker.ExtractImages(file, options);
                    Tracker.IncrementTotalProgress();
                    if (AppContext.Abort)
                    {
                        return;
                    }
                }
            }
            else
            {
                Worker.ExtractImages(files[0], options);
            }
        };
        worker.RunWorkerCompleted += (_, _) => { AppContext.ImageExtracter.OutputPath = _ExtractPageRangeBox.Text; };
        ImageExtracterOptions option = AppContext.ImageExtracter;
        option.ExtractAnnotationImages = _ExportAnnotImagesBox.Checked;
        option.PageRange = _ExtractPageRangeBox.Text;
        option.OutputPath = _TargetBox.Text;
        option.FileMask = _FileNameMaskBox.Text;
        option.MergeImages = _MergeImageBox.Checked;
        option.MergeJpgToPng = _MergeJpgToPngBox.Checked;
        option.VerticalFlipImages = _VerticalFlipImageBox.Checked;
        option.InvertBlackAndWhiteImages = _InvertBlackAndWhiteBox.Checked;
        option.MonoPng = _MonoPngBox.Checked;
        option.MinHeight = (int)_MinHeightBox.Value;
        option.MinWidth = (int)_MinWidthBox.Value;
        option.ExtractSoftMask = _ExportSoftMaskBox.Checked;
        option.InvertSoftMask = _InvertSoftMaskBox.Checked;
        option.SkipRedundantImages = _SkipRedundantImagesBox.Checked;
        worker.RunWorkerAsync(
            new object[] { AppContext.SourceFiles, option });
    }

    private void _FileNameMaskBox_TextChanged(object sender, EventArgs e) => ShowFileMaskPreview();

    private void ShowFileMaskPreview()
    {
        try
        {
            string[] previews = new string[7];
            string f = _FileNameMaskBox.Text;
            previews[0] = 1.ToString(f) + ".jpg";
            previews[1] = 2.ToString(f) + ".jpg";
            previews[2] = 3.ToString(f) + ".jpg...";
            previews[3] = "\n" + 11.ToString(f) + ".jpg";
            previews[4] = 12.ToString(f) + ".jpg";
            previews[5] = 13.ToString(f) + ".jpg...";
            previews[6] = 100.ToString(f) + ".jpg";
            _FileMaskPreviewBox.Text = string.Join(" ", previews);
        }
        catch (Exception)
        {
            _FileMaskPreviewBox.Text = "The file name mask is invalid.";
        }
    }

    private void Control_Show(object sender, EventArgs e)
    {
        if (Visible && AppContext.MainForm != null)
        {
            _TargetBox.Contents = AppContext.Recent.Folders;
        }
        //else if (this.Visible == false) {
        //    this._TargetBox.DataSource = null;
        //}
    }
}
