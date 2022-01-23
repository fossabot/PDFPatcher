using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MuPdfSharp;
using PDFPatcher.Common;
using PDFPatcher.Processor;
using PDFPatcher.Properties;

namespace PDFPatcher.Functions;

[ToolboxItem(false)]
public partial class RenderImageControl : FunctionControl, IResettableControl
{
    public RenderImageControl()
    {
        InitializeComponent();
        //this.Icon = Common.FormHelper.ToIcon (Properties.Resources.RenderImage);
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
            AppContext.ImageRenderer.AutoOutputFolder = _AutoOutputDirBox.Checked;
        };
        _ResolutionBox.TextChanged += (_, _) =>
        {
            float v = _ResolutionBox.Text.ToSingle();
            _ResolutionBox.Text = v switch
            {
                <= 0 => "72",
                > 3000 => "3000",
                _ => _ResolutionBox.Text
            };
        };
        _ExtractPageImageWidthBox.GotFocus += (_, _) => { _SpecificWidthBox.Checked = true; };
        _ExtractPageRatioBox.GotFocus += (_, _) => { _SpecificRatioBox.Checked = true; };
    }

    public override string FunctionName => "Convert page for image";

    public override Bitmap IconImage => Resources.RenderDocument;

    #region IDefaultButtonControl member

    public override Button DefaultButton => _ExtractButton;

    #endregion

    public void Reset()
    {
        AppContext.ImageRenderer = new ImageRendererOptions();
        Reload();
    }

    public void Reload()
    {
        ImageRendererOptions o = AppContext.ImageRenderer;
        _AutoOutputDirBox.Checked = o.AutoOutputFolder;
        _ColorSpaceRgbBox.Checked = !(_ColorSpaceGrayBox.Checked = o.ColorSpace == ColorSpace.Gray);
        _FileNameMaskBox.Text = o.FileMask;
        _HorizontalFlipImageBox.Checked = o.HorizontalFlipImages;
        _HideAnnotationsBox.Checked = o.HideAnnotations;
        _ImageFormatBox.SelectedIndex = ValueHelper.MapValue(o.FileFormat,
            new[] { ImageFormat.Png, ImageFormat.Jpeg, ImageFormat.Tiff }, new[] { 0, 1, 2 }, 0);
        _InvertColorBox.Checked = o.InvertColor;
        if (o.JpegQuality is > 0 and <= 100)
        {
            _JpegQualityBox.Text = o.JpegQuality.ToText();
        }
        else
        {
            o.JpegQuality = 75;
            _JpegQualityBox.Text = "75";
        }

        _QuantizeBox.Checked = o.Quantize;
        _ResolutionBox.Text = o.Dpi.ToText();
        _RotationBox.SelectedIndex =
            ValueHelper.MapValue(o.Rotation, new[] { 0, 90, 180, 270 }, new[] { 0, 1, 2, 3 }, 0);
        _SpecificRatioBox.Checked = !o.UseSpecificWidth;
        _SpecificWidthBox.Checked = o.UseSpecificWidth;
        _VerticalFlipImageBox.Checked = o.VerticalFlipImages;
        _ExtractPageImageWidthBox.SetValue(o.ImageWidth);
        _ExtractPageRatioBox.SetValue(o.ScaleRatio);
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        ShowFileMaskPreview();
        AppContext.MainForm.SetTooltip(_SourceFileControl.FileList, "Path to PDF file containing images");
        AppContext.MainForm.SetTooltip(_TargetBox, "The path to the folder where the output image is placed");
        AppContext.MainForm.SetTooltip(_ExtractPageRangeBox,
            "The page number range of the picture needs to be extracted, and the pictures of all pages are extracted when the page number range is not specified");
        AppContext.MainForm.SetTooltip(_FileNameMaskBox,
            "The name of the extracted image file is named according to the number of the page where it is located, and the naming rules can be modified here\n\"0000\": If there are less than four digits, use 0 to make up the four digits\n\"0\": The file name is based on the actual page number, without 0 to make up the digits\n n You can enclose the text in English double quotation marks (such as \"\\\" is about 2000\"0\", the preceding \"2000\" will not be interpreted as a placeholder)");
        AppContext.MainForm.SetTooltip(_VerticalFlipImageBox,
            "The image exported from some PDF files is upside down, you can use this option to restore it");
        AppContext.MainForm.SetTooltip(_InvertColorBox, "Invert the color of PNG and TIFF black and white images");
        AppContext.MainForm.SetTooltip(_QuantizeBox,
            "Minimize the colors used for exporting pictures, thereby reducing the disk space occupied by pictures");
        AppContext.MainForm.SetTooltip(_SpecificWidthBox,
            "Specify the width of the output image (in pixels, the height of the image will be scaled proportionally)");
        AppContext.MainForm.SetTooltip(_SpecificRatioBox, "Specify the magnification of the output image");
        AppContext.MainForm.SetTooltip(_ExtractPageImageWidthBox,
            "Specify the width of the output image (in pixels, the height of the image will be scaled proportionally), when the width is 0, it is equivalent to a 1:1 ratio output");
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
            ImageRendererOptions options = a[1] as ImageRendererOptions;
            options.ExtractImagePath = new FilePath(options.ExtractImagePath).Normalize();
            if (files.Length > 1)
            {
                string ep = options.ExtractImagePath;
                foreach (string file in files)
                {
                    options.ExtractImagePath = new FilePath(ep).Combine(new FilePath(file).FileNameWithoutExtension)
                        .Normalize();
                    Worker.RenderPages(file, options);
                    Tracker.IncrementTotalProgress();
                    if (AppContext.Abort)
                    {
                        return;
                    }
                }
            }
            else
            {
                Worker.RenderPages(files[0], options);
            }
        };
        worker.RunWorkerCompleted += (_, _) => { AppContext.ImageExtracter.OutputPath = _ExtractPageRangeBox.Text; };
        ImageRendererOptions option = AppContext.ImageRenderer;
        option.ColorSpace = _ColorSpaceRgbBox.Checked ? ColorSpace.Rgb : ColorSpace.Gray;
        option.ExtractPageRange = _ExtractPageRangeBox.Text;
        option.ExtractImagePath = _TargetBox.Text;
        option.FileMask = _FileNameMaskBox.Text;
        option.HideAnnotations = _HideAnnotationsBox.Checked;
        option.HorizontalFlipImages = _HorizontalFlipImageBox.Checked;
        option.InvertColor = _InvertColorBox.Checked;
        option.FileFormat = ValueHelper.MapValue(_ImageFormatBox.SelectedIndex, new[] { 0, 1, 2 },
            new[] { ImageFormat.Png, ImageFormat.Jpeg, ImageFormat.Tiff }, ImageFormat.Png);
        option.ImageWidth = (int)_ExtractPageImageWidthBox.Value;
        option.JpegQuality = _JpegQualityBox.Text.TryParse(out int j)
            ? j is > 0 and <= 100 ? j : 75
            : 75;
        option.Quantize = _QuantizeBox.Checked;
        option.Dpi = _ResolutionBox.Text.ToSingle();
        option.Rotation = _RotationBox.SelectedIndex * 90;
        option.ScaleRatio = (float)_ExtractPageRatioBox.Value;
        option.UseSpecificWidth = _SpecificWidthBox.Checked;
        option.VerticalFlipImages = _VerticalFlipImageBox.Checked;
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
            previews[2] = 3.ToString(f) + ".jpg ...";
            previews[3] = "\n" + 11.ToString(f) + ".jpg";
            previews[4] = 12.ToString(f) + ".jpg";
            previews[5] = 13.ToString(f) + ".jpg ...";
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
