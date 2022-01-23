using System.Windows.Forms;

namespace PDFPatcher.Functions;

public partial class TextViewerForm : Form
{
    public TextViewerForm() => InitializeComponent();

    public TextViewerForm(string textContent, bool isTextReadonly) : this()
    {
        TextContent = textContent;
        IsTextReadOnly = isTextReadonly;
    }

    /// <summary>Get or specify whether the text content is read.</summary>
    public bool IsTextReadOnly
    {
        get => _TextBox.ReadOnly;
        set
        {
            _TextBox.ReadOnly = value;
            _OkButton.Visible = !value;
        }
    }

    /// <summary>Get or specify text content.</summary>
    public string TextContent
    {
        get => _TextBox.Text;
        set => _TextBox.Text = value;
    }
}
