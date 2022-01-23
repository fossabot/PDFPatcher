using System;
using System.IO;
using System.Windows.Forms;

namespace PDFPatcher;

public partial class PasswordEntryForm : Form
{
    public PasswordEntryForm(string sourceFile)
    {
        InitializeComponent();

        sourceFile = Path.GetFileName(sourceFile);
        Text += "：" + sourceFile;
        _MessageLabel.Text = _MessageLabel.Text.Replace("PDF file", string.Concat("PDF file ", sourceFile, " "));
    }

    /// <summary>
    ///     Get the text of the password box.
    /// </summary>
    public string Password => _PasswordBox.Text;

    private void _OkButton_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.OK;
        Close();
    }

    private void _CancelButton_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}
