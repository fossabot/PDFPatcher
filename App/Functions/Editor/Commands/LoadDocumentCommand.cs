using System;
using System.Windows.Forms;
using PDFPatcher.Common;

namespace PDFPatcher.Functions.Editor;

internal sealed class LoadDocumentCommand : IEditorCommand
{
    private readonly bool _showDialog, _importBookmark;

    public LoadDocumentCommand(bool showDialog, bool importBookmark)
    {
        _showDialog = showDialog;
        _importBookmark = importBookmark;
    }

    public void Process(Controller controller, params string[] parameters)
    {
        if (_showDialog)
        {
            using OpenFileDialog f = new()
            {
                DefaultExt = _importBookmark ? Constants.FileExtensions.Xml : Constants.FileExtensions.Pdf,
                Title = _importBookmark ? "Open bookmark file for import" : "Open file for editing",
                Filter = Constants.FileExtensions.AllEditableFilter
            };
            if (f.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            parameters = new[] { f.FileName };
        }

        try
        {
            controller.LoadDocument(parameters[0], _importBookmark);
        }
        catch (Exception ex)
        {
            FormHelper.ErrorBox("An error occurred while loading the information file: " + ex.Message);
        }
    }
}
