using System;
using System.IO;
using System.Windows.Forms;
using FreeImageAPI;
using PDFPatcher.Common;
using PDFPatcher.Processor;
using PDFPatcher.Processor.Imaging;
using PDFPatcher.Properties;

namespace PDFPatcher.Functions;

public sealed partial class ImageViewerForm : Form
{
    internal ImageViewerForm(ImageInfo image, byte[] bytes)
    {
        InitializeComponent();
        this.SetIcon(Resources.ViewContent);
        if (image.ExtName is Constants.FileExtensions.Png or Constants.FileExtensions.Tif)
        {
            using FreeImageBitmap bmp = ImageExtractor.CreateFreeImageBitmap(image, ref bytes, false, true);
            _ImageBox.Image = bmp.ToBitmap();
        }
        else
        {
            try
            {
                using MemoryStream s = new(bytes);
                using FreeImageBitmap bmp = new(s);
                _ImageBox.Image = bmp.ToBitmap();
            }
            catch (Exception ex)
            {
                this.ErrorBox("Unable to load images", ex);
            }
        }
    }

    protected override void OnClosed(EventArgs e)
    {
        _ImageBox.Image.TryDispose();
        base.OnClosed(e);
    }

    private void _MainToolbar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
        string n = e.ClickedItem.Name;
        switch (n)
        {
            case "_Save":
                using (SaveFileDialog f = new()
                {
                    Title = "Save image files",
                    DefaultExt = Constants.FileExtensions.Png,
                    FileName = "ExportedImage.png",
                    Filter = Constants.FileExtensions.ImageFilter
                })
                {
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            using FreeImageBitmap fi = new(_ImageBox.Image);
                            fi.Save(f.FileName);
                        }
                        catch (Exception ex)
                        {
                            FormHelper.ErrorBox(ex.Message);
                        }
                    }
                }

                break;
            case "_ZoomReset":
                _ImageBox.ActualSize();
                break;
            case "_FitWindow":
                _ImageBox.ZoomToFit();
                break;
        }
    }
}
