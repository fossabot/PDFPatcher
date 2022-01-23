using System;
using System.ComponentModel;
using PDFPatcher.Common;

namespace PDFPatcher.Functions.Editor;

public partial class InsertBookmarkForm : DraggableForm
{
    private int _TargetPageNumber;

    public InsertBookmarkForm()
    {
        InitializeComponent();

        VisibleChanged += (_, _) =>
        {
            if (!Visible)
            {
                return;
            }

            _TitleBox.Focus();
            _TitleBox.SelectAll();
        };
        _AfterCurrentBox.DoubleClick += InsertModeBox_DoubleClick;
        _AfterParentBox.DoubleClick += InsertModeBox_DoubleClick;
        _AsChildBox.DoubleClick += InsertModeBox_DoubleClick;
        _BeforeCurrentBox.DoubleClick += InsertModeBox_DoubleClick;
        _ReplaceBookmarkBox.DoubleClick += InsertModeBox_DoubleClick;
        _OkButton.Click += (_, args) =>
        {
            OkClicked?.Invoke(this, args);
            if (_AsChildBox.Checked || _AfterParentBox.Checked)
            {
                _AfterCurrentBox.Checked = true;
            }

            Hide();
        };
        _CancelButton.Click += (_, _) => Hide();
    }

    /// <summary>
    ///     Get or set the bookmark title.
    /// </summary>
    public string Title
    {
        get => _TitleBox.Text;
        set => _TitleBox.Text = value;
    }

    public string Comment
    {
        get => _CommentBox.Text;
        set => _CommentBox.Text = value;
    }

    /// <summary>
    ///     Get or set the location of the bookmark.
    /// </summary>
    public float TargetPosition
    {
        get => (float)_PositionBox.Value;
        set => _PositionBox.SetValue(value);
    }

    public int TargetPageNumber
    {
        get => _TargetPageNumber;
        set
        {
            _TargetPageNumber = value;
            _PageLabel.Text = "page" + value.ToText() + "page";
        }
    }

    /// <summary>
    ///     Get the insertion position of the new bookmark (after the current bookmark: 1; child bookmark: 2; post-parent
    ///     bookmark: 3; the current bookmark: 4)
    /// </summary>
    public int InsertMode => _AfterCurrentBox.Checked ? 1
        : _AsChildBox.Checked ? 2
        : _AfterParentBox.Checked ? 3
        : _BeforeCurrentBox.Checked ? 4
        : 0;

    [Browsable(false)] internal Controller Controller { get; set; }

    public event EventHandler OkClicked;

    private void InsertModeBox_DoubleClick(object sender, EventArgs e) => _OkButton.PerformClick();

    protected override void OnDeactivate(EventArgs e)
    {
        Hide();
        base.OnDeactivate(e);
    }
}
