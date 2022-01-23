using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using PDFPatcher.Common;

namespace PDFPatcher;

public partial class SourceFileControl : UserControl
{
    private bool _controlLockDown;

    public SourceFileControl()
    {
        _controlLockDown = true;
        InitializeComponent();
        _controlLockDown = false;
        Files = new string[] { };
    }

    /// <summary>Get the file drop-down list box.</summary>
    internal HistoryComboBox FileList { get; private set; }

    /// <summary>
    ///     Get a list of selected PDF files.
    /// </summary>
    internal string[] Files { get; private set; }

    /// <summary>
    ///     Get the first item of the selected PDF file list.
    /// </summary>
    internal string FirstFile => Files is { Length: > 0 } ? Files[0] : string.Empty;

    [DefaultValue(null)]
    public override string Text
    {
        get => FileList.Text;
        set => FileList.Text = value;
    }

    /// <summary>Click the Browse button to change the event triggered after the file.</summary>
    public event EventHandler BrowseSelectedFiles;

    ///// <summary>Gets or specifies the value of the text tag.</summary>
    //[Description ("Text tag value")]
    //public string Label {
    //    get { return this.label1.Text; }
    //    set { this.label1.Text = value; }
    //}

    ///// <summary>Get or specify whether it can be multi-selection file.</summary>
    //[Description ("Is there a multi-selection file?")]
    //public bool MultiSelect {
    //    get { return this._OpenPdfBox.Multiselect; }
    //    set { this._OpenPdfBox.Multiselect = value; }
    //}

    private void _BrowseSourcePdfButton_Click(object sender, EventArgs e)
    {
        string t = FileList.Text;
        if (t.Length > 0
            && FileHelper.IsPathValid(t)
            && Path.GetFileName(t).Length > 0)
        {
            _OpenPdfBox.FileName = t;
        }

        if (_OpenPdfBox.ShowDialog() != DialogResult.OK)
        {
            return;
        }

        SelectFiles(_OpenPdfBox.FileNames);
        BrowseSelectedFiles?.Invoke(sender, e);
    }

    private void SelectFiles(string[] files)
    {
        string t = FileList.Text;
        if (files.Length > 1)
        {
            Text = string.Concat("<选定了 ", files.Length, " 个文件>", Path.GetDirectoryName(files[0]));
        }
        else if (files[0] != t)
        {
            Text = files[0];
        }

        Files = files;
    }

    private void _SourcePdfBox_TextChanged(object sender, EventArgs e)
    {
        if (_controlLockDown)
        {
            return;
        }

        if (FileHelper.HasFileNameMacro(FileList.Text) == false)
        {
            SelectFiles(new[] { FileList.Text });
        }
    }

    private void _SourcePdfBox_DragEnter(object sender, DragEventArgs e) =>
        e.FeedbackDragFileOver(Constants.FileExtensions.Pdf);

    private void _SourcePdfBox_DragDrop(object sender, DragEventArgs e)
    {
        string[] files = e.DropFileOver(Constants.FileExtensions.Pdf);
        SelectFiles(files);
    }

    private void SourceFileControl_Show(object sender, EventArgs e)
    {
        _controlLockDown = true;
        string t = Text;
        FileList.Contents = Visible switch
        {
            true when AppContext.MainForm != null => AppContext.Recent.SourcePdfFiles,
            false => null,
            _ => FileList.Contents
        };

        Text = t;
        _controlLockDown = false;
    }

    private void label1_Click(object sender, EventArgs e)
    {
    }

    private void _SourcePdfBox_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
}
