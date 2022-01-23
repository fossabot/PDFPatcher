using System.IO;
using System.Windows.Forms;
using System.Xml;
using MuPdfSharp;
using PDFPatcher.Common;
using PDFPatcher.Model;
using PDFPatcher.Processor;

namespace PDFPatcher.Functions.Editor;

internal sealed class SaveDocumentCommand : IEditorCommand
{
    private readonly bool _showDialog, _saveAsBookmark;

    public SaveDocumentCommand(bool showDialog, bool saveAsBookmark)
    {
        _saveAsBookmark = saveAsBookmark;
        _showDialog = showDialog;
    }

    public void Process(Controller controller, params string[] parameters)
    {
        if (_saveAsBookmark)
        {
            SaveBookmark(controller, _showDialog);
        }
        else
        {
            SavePdf(controller);
        }
    }

    private static void SaveBookmark(Controller controller, bool showDialog)
    {
        PdfInfoXmlDocument idoc = controller.Model.Document;
        MuDocument mudoc = controller.Model.PdfDocument;
        FilePath t = new(controller.Model.DocumentPath);
        if (idoc?.DocumentElement == null || t == null)
        {
            return;
        }

        if (t.HasExtension(Constants.FileExtensions.Xml) == false
            || showDialog)
        {
            using SaveFileDialog d = new()
            {
                DefaultExt = Constants.FileExtensions.Xml,
                Title = "Specify the path to save the file",
                Filter = Constants.FileExtensions.XmlFilter + "|" + Constants.FileExtensions.TxtFilter
            };
            if (t.ExistsFile)
            {
                d.InitialDirectory = t.Directory;
                d.FileName = t.FileNameWithoutExtension;
            }

            if (d.ShowDialog() == DialogResult.OK)
            {
                t = d.FileName;
            }
            else
            {
                return;
            }
        }

        if (t.HasExtension(Constants.FileExtensions.Txt))
        {
            using StreamWriter writer = new(t);
            const string indentString = "\t";
            writer.WriteLine("#Version=" + Constants.InfoDocVersion);
            if (mudoc != null)
            {
                writer.WriteLine("#" + Constants.Info.DocumentPath + "=" + mudoc.FilePath);
            }

            writer.WriteLine("#indent mark=" + indentString);
            writer.WriteLine("#First page number=1");
            writer.WriteLine();
            OutlineManager.WriteSimpleBookmark(writer, idoc.BookmarkRoot, 0, indentString);
        }
        else
        {
            t = t.EnsureExtension(Constants.FileExtensions.Xml);
            using (XmlWriter writer = XmlWriter.Create(t, DocInfoExporter.GetWriterSettings()))
            {
                if (mudoc != null)
                {
                    idoc.PdfDocumentPath = mudoc.FilePath;
                }

                idoc.WriteContentTo(writer);
            }

            controller.View.DocumentPath = t;

            RecentFileMenuHelper.AddRecentHistoryFile(t);
        }
    }

    private static void SavePdf(Controller controller)
    {
        EditModel m = controller.Model;
        PdfViewerControl vv = controller.View.Viewer;
        if (m.Document == null)
        {
            FormHelper.ErrorBox("The bookmark document has not been loaded.");
            return;
        }

        using SavePdfForm f = new(m.GetPdfFilePath(), m.LastSavedPdfPath, m.Document);
        f.DoWork = (_, _) => vv.CloseFile();
        f.Finished = (_, _) =>
        {
            vv.Reopen();
            vv.Enabled = true;
        };

        if (f.ShowDialog() != DialogResult.OK)
        {
            return;
        }

        vv.Enabled = false;
        m.Document.PdfDocumentPath = f.SourceFilePath;
        m.LastSavedPdfPath = f.TargetFilePath;
    }
}
