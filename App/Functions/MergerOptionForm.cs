﻿using System;
using System.ComponentModel;
using System.Windows.Forms;
using PDFPatcher.Common;
using PDFPatcher.Model;
using PDFPatcher.Processor;
using PDFPatcher.Properties;
using HorizontalAlignment = PDFPatcher.Model.HorizontalAlignment;

namespace PDFPatcher.Functions;

[ToolboxItem(false)]
public partial class MergerOptionForm : Form, IResettableControl
{
    private bool _uiLockDown;
    private string paperName;

    public MergerOptionForm()
    {
        InitializeComponent();
        this.SetIcon(Resources.PdfOptions);
        MinimumSize = Size;

        _AutoBookmarkTitleBox.CheckedChanged += CheckBoxChanged;
        _KeepSourcePdfBookmarkBox.CheckedChanged += CheckBoxChanged;
        _UnifyOrientationBox.CheckedChanged += CheckBoxChanged;
        _PageSizeBox.Items.AddRange(Array.FindAll(PdfDocumentCreator.PaperSizes,
            i => i.SpecialSize < SpecialPaperSize.AsSpecificPage));
        _ImageHAlignBox.Items.Add("Horizontal Center");
        _ImageHAlignBox.Items.Add("Left Align");
        _ImageHAlignBox.Items.Add("Right alignment");
        _ImageVAlignBox.Items.Add("Vertical Center");
        _ImageVAlignBox.Items.Add("Top");
        _ImageVAlignBox.Items.Add("Bottom");

        Reload();
    }

    public void Reset()
    {
        AppContext.Merger = new MergerOptions();
        Reload();
    }

    public void Reload()
    {
        _uiLockDown = true;
        MergerOptions options = AppContext.Merger;
        PageBoxSettings ps = options.PageSettings;
        _AutoBookmarkTitleBox.Checked = options.AutoBookmarkTitle;
        _AutoMaskBWImageBox.Checked = options.AutoMaskBWImages;
        _AutoRotateBox.Checked = ps.AutoRotation;
        _AutoScaleDownBox.Checked = options.AutoScaleDown;
        _AutoScaleUpBox.Checked = options.AutoScaleUp;
        _BottomMarginBox.SetValue(ps.Margins.Bottom / Constants.Units.CmToPoint);
        _CajSortBox.Checked = options.CajSort;
        _HeightBox.SetValue(ps.PaperSize.Height / Constants.Units.CmToPoint);
        _IgnoreLeadingNumbersBox.Checked = options.IgnoreLeadingNumbers;
        _ImageHAlignBox.SelectedIndex = (int)ps.HorizontalAlign;
        _ImageVAlignBox.SelectedIndex = (int)ps.VerticalAlign;
        _KeepSourcePdfBookmarkBox.Checked = options.KeepBookmarks;
        _LeftMarginBox.SetValue(ps.Margins.Left / Constants.Units.CmToPoint);
        for (int i = 0; i < _PageSizeBox.Items.Count; i++)
        {
            PaperSize p = _PageSizeBox.Items[i] as PaperSize;
            if (p.PaperName == ps.PaperSize.PaperName)
            {
                _PageSizeBox.SelectedIndex = i;
            }
        }

        if (_PageSizeBox.SelectedIndex == -1)
        {
            _PageSizeBox.SelectedIndex = 0;
        }

        _NumericAwareSortBox.Checked = options.NumericAwareSort;
        _RemoveOrphanBoomarksBox.Checked = options.RemoveOrphanBookmarks;
        _ResizePdfPagesBox.Checked = ps.ScaleContent == false;
        _RightMarginBox.SetValue(ps.Margins.Right / Constants.Units.CmToPoint);
        _SubFoldersBeforeFilesBox.Checked = options.SubFolderBeforeFiles;
        _ScalePdfPagesBox.Checked = ps.ScaleContent;
        _TopMarginBox.SetValue(ps.Margins.Top / Constants.Units.CmToPoint);
        _WidthBox.SetValue(ps.PaperSize.Width / Constants.Units.CmToPoint);
        if (_PageSizeBox.SelectedIndex == 0)
        {
            _HeightBox.Value = 26.01M;
            _WidthBox.Value = 18M;
        }

        _SourceOrientationBox.SelectedIndex = options.RotateVerticalPages ? 1 : 0;
        _RotationBox.SelectedIndex = options.RotateAntiClockwise ? 1 : 0;
        _UnifyOrientationBox.Checked = options.UnifyPageOrientation;

        _RecompressImageBox.Checked = options.RecompressWithJbig2;
        _FullCompressionBox.Checked = options.FullCompression;
        _DocumentInfoEditor.Options = options.MetaData;
        _ViewerSettingsEditor.Options = options.ViewerPreferences;
        _PageLabelEditor.Labels = options.PageLabels;

        //if (options.CompressionLevel >= 0 && options.CompressionLevel <= 9) {
        //    _CompressionLevelBox.SelectedIndex = 10 - options.CompressionLevel;
        //}
        //else {
        //    _CompressionLevelBox.SelectedIndex = 0;
        //}
        _uiLockDown = false;
    }

    protected override void OnClosed(EventArgs e)
    {
        MergerOptions option = AppContext.Merger;
        PageBoxSettings ps = option.PageSettings;
        option.AutoBookmarkTitle = _AutoBookmarkTitleBox.Checked;
        option.AutoMaskBWImages = _AutoMaskBWImageBox.Checked;
        ps.AutoRotation = _AutoRotateBox.Checked;
        option.AutoScaleDown = _AutoScaleDownBox.Checked;
        option.AutoScaleUp = _AutoScaleUpBox.Checked;
        option.CajSort = _CajSortBox.Checked;
        ps.Margins.Top = CmToPoint(_TopMarginBox);
        ps.Margins.Bottom = CmToPoint(_BottomMarginBox);
        ps.Margins.Left = CmToPoint(_LeftMarginBox);
        ps.Margins.Right = CmToPoint(_RightMarginBox);
        option.NumericAwareSort = _NumericAwareSortBox.Checked;
        ps.PaperSize.PaperName = paperName;
        ps.PaperSize.Width = CmToPoint(_WidthBox);
        ps.PaperSize.Height = CmToPoint(_HeightBox);
        ps.HorizontalAlign = (HorizontalAlignment)_ImageHAlignBox.SelectedIndex;
        ps.VerticalAlign = (VerticalAlignment)_ImageVAlignBox.SelectedIndex;
        ps.ScaleContent = _ScalePdfPagesBox.Checked;
        option.SubFolderBeforeFiles = _SubFoldersBeforeFilesBox.Checked;

        option.UnifyPageOrientation = _UnifyOrientationBox.Checked;
        option.RotateVerticalPages = _SourceOrientationBox.SelectedIndex == 1;
        option.RotateAntiClockwise = _RotationBox.SelectedIndex == 1;
        option.IgnoreLeadingNumbers = _IgnoreLeadingNumbersBox.Checked;
        option.KeepBookmarks = _KeepSourcePdfBookmarkBox.Checked;
        option.RemoveOrphanBookmarks = _RemoveOrphanBoomarksBox.Checked;

        option.RecompressWithJbig2 = _RecompressImageBox.Checked;
        option.FullCompression = _FullCompressionBox.Checked;

        //if (_CompressionLevelBox.SelectedIndex == 0) {
        //    option.CompressionLevel = -1;
        //}				//else {
        //    option.CompressionLevel = 10 - _CompressionLevelBox.SelectedIndex;
        //}
    }

    private static float CmToPoint(NumericUpDown box) => (float)box.Value * Constants.Units.CmToPoint;

    private void _PageSizeBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_PageSizeBox.SelectedIndex == -1)
        {
            return;
        }

        PaperSize p = _PageSizeBox.SelectedItem as PaperSize;
        if (p.Width > 0 && p.Height > 0)
        {
            _WidthBox.SetValue((decimal)p.Width / 100);
            _HeightBox.SetValue((decimal)p.Height / 100);
        }

        paperName = p.PaperName;
        switch (paperName)
        {
            case PaperSize.FixedWidthAutoHeight:
                _AutoRotateBox.Enabled =
                    _HeightBox.Enabled =
                        _ImageVAlignBox.Enabled =
                            false;
                _ImageHAlignBox.Enabled =
                    _PdfGroupBox.Enabled =
                        _ImageGroupBox.Enabled =
                            _WidthBox.Enabled = true;
                break;
            case PaperSize.AsPageSize:
                _AutoRotateBox.Enabled =
                    _WidthBox.Enabled =
                        _ImageHAlignBox.Enabled =
                            _ImageVAlignBox.Enabled =
                                _PdfGroupBox.Enabled =
                                    _ImageGroupBox.Enabled =
                                        _HeightBox.Enabled = false;
                break;
            default:
                _AutoRotateBox.Enabled =
                    _WidthBox.Enabled =
                        _HeightBox.Enabled =
                            _ImageHAlignBox.Enabled =
                                _ImageVAlignBox.Enabled =
                                    _PdfGroupBox.Enabled =
                                        _ImageGroupBox.Enabled =
                                            true;
                break;
        }
    }

    private void MarginBox_ValueChanged(object sender, EventArgs e)
    {
        if (_SyncMarginsBox.Checked == false || _uiLockDown)
        {
            return;
        }

        NumericUpDown c = sender as NumericUpDown;
        decimal d = c.Value;
        _TopMarginBox.Value = _BottomMarginBox.Value = _LeftMarginBox.Value = _RightMarginBox.Value = d;
    }

    private void CheckBoxChanged(object sender, EventArgs e)
    {
        _IgnoreLeadingNumbersBox.Enabled = _AutoBookmarkTitleBox.Checked;
        _RemoveOrphanBoomarksBox.Enabled = _KeepSourcePdfBookmarkBox.Checked;
        _SourceOrientationBox.Enabled = _RotationBox.Enabled = _UnifyOrientationBox.Checked;
    }
}
