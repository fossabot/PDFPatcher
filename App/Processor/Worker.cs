using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using iTextSharp.text;
using iTextSharp.text.exceptions;
using iTextSharp.text.pdf;
using MuPdfSharp;
using PDFPatcher.Common;
using PDFPatcher.Model;
using PDFPatcher.Processor.Imaging;
using Ext = PDFPatcher.Constants.FileExtensions;
using Rectangle = iTextSharp.text.Rectangle;

namespace PDFPatcher.Processor;

internal static class Worker
{
    private const string OperationCanceled = "The operation has been canceled.";

    private static PdfReader OpenPdf(string sourceFile, bool loadPartial, bool removeUnusedObjects)
    {
        try
        {
            Tracker.TraceMessage(Tracker.Category.ImportantMessage,
                string.Concat("Open the PDF file: <<", sourceFile, ">>。"));
            return PdfHelper.OpenPdfFile(sourceFile, loadPartial, removeUnusedObjects);
        }
        catch (FileNotFoundException)
        {
            FormHelper.ErrorBox(string.Concat("Can't find the file: \"", sourceFile, "\"."));
            return null;
        }
        catch (BadPasswordException)
        {
            Tracker.TraceMessage(Tracker.Category.Error, Messages.PasswordInvalid);
            FormHelper.ErrorBox(Messages.PasswordInvalid);
            return null;
        }
        catch (Exception ex)
        {
            FormHelper.ErrorBox("When you open the PDF file: \n" + ex.Message);
#if DEBUG
            Tracker.TraceMessage(ex);
#endif
            return null;
        }
    }

    internal static void ExtractImages(string sourceFile, ImageExtracterOptions options)
    {
        const int loadDocProgressWeight = 10;
        Tracker.TraceMessage(Tracker.Category.InputFile, sourceFile);
        PdfReader
            pdf = OpenPdf(sourceFile, true,
                false); //Since the export image is generally not required to recover the document, this option can be used to reduce memory and improve the opening speed.
        if (pdf == null)
        {
            return;
        }

        string targetPath = options.OutputPath;
        if (Directory.Exists(targetPath) == false)
        {
            Directory.CreateDirectory(targetPath);
        }

        PageRangeCollection ranges = PageRangeCollection.Parse(options.PageRange, 1, pdf.NumberOfPages, true);
        int loadCount = loadDocProgressWeight + ranges.TotalPages;
        Tracker.SetProgressGoal(loadCount);
        string om = options.FileMask;
        try
        {
            Tracker.TraceMessage("Export the picture.");
            Tracker.TrackProgress(loadDocProgressWeight);
            if (FileHelper.HasFileNameMacro(targetPath))
            {
                options.OutputPath = ReplaceTargetFileNameMacros(sourceFile, targetPath, pdf);
            }

            if (FileHelper.HasFileNameMacro(om))
            {
                options.FileMask = ReplaceTargetFileNameMacros(sourceFile, om, pdf);
            }

            ImageExtractor exp = new(options);
            foreach (int i in ranges.SelectMany(range => range))
            {
                exp.ExtractPageImages(pdf, i);
                if (exp.InfoList.Count > 0)
                {
                    Tracker.TraceMessage(Tracker.Category.OutputFile,
                        exp.InfoList[exp.InfoList.Count - 1].FileName);
                }

                Tracker.IncrementProgress(1);
            }

            Tracker.TrackProgress(loadCount);
            Tracker.TraceMessage(Tracker.Category.Alert,
                "Successfully extract image files, save the directory: <<" + targetPath + ">>。");
        }
        catch (OperationCanceledException)
        {
            Tracker.TraceMessage(Tracker.Category.ImportantMessage, OperationCanceled);
        }
        catch (Exception ex)
        {
            Tracker.TraceMessage(ex);
            FormHelper.ErrorBox("When exporting pictures, you encounter an error: \n" + ex.Message);
        }
        finally
        {
            options.OutputPath = targetPath;
            options.FileMask = om;
            pdf.Close();
        }
    }

    internal static void RenderPages(string sourceFile, ImageRendererOptions options)
    {
        const int loadDocProgressWeight = 10;
        Tracker.TraceMessage(Tracker.Category.InputFile, sourceFile);
        options.TintColor = Color.Transparent;
        if (Directory.Exists(options.ExtractImagePath) == false)
        {
            Directory.CreateDirectory(options.ExtractImagePath);
        }

        MuDocument mupdf = null;
        try
        {
            mupdf = PdfHelper.OpenMuDocument(sourceFile);
            PageRangeCollection ranges = PageRangeCollection.Parse(options.ExtractPageRange, 1, mupdf.PageCount, true);
            int loadCount = loadDocProgressWeight + ranges.TotalPages;
            Tracker.SetProgressGoal(loadCount);
            Tracker.TraceMessage("Convert the picture.");
            Tracker.TrackProgress(loadDocProgressWeight);
            foreach (PageRange range in ranges)
                foreach (int i in range)
                {
                    string fn = FileHelper.CombinePath(options.ExtractImagePath,
                        i.ToString(options.FileMask) + options.FileFormatExtension);
                    using (MuPage p = mupdf.LoadPage(i))
                    using (Bitmap bmp = p.RenderBitmapPage(options.ImageWidth, 0, options))
                    {
                        if (bmp == null)
                        {
                            Tracker.TraceMessage(Tracker.Category.Error, "The dimension of page" + i + " is empty.");
                        }
                        else if (options.FileFormat == ImageFormat.Tiff)
                        {
                            using Bitmap b = bmp.ToBitonal();
                            b.SaveAs(fn);
                        }
                        else
                        {
                            Color[] uc = bmp.GetPalette();
                            switch (uc.Length)
                            {
                                case > 256 when options.Quantize:
                                    {
                                        using Bitmap b = WuQuantizer.QuantizeImage(bmp);
                                        b.SaveAs(fn);
                                        break;
                                    }
                                case <= 256 when bmp.IsIndexed() == false:
                                    {
                                        using Bitmap b = bmp.ToIndexImage(uc);
                                        b.SaveAs(fn);
                                        break;
                                    }
                                default:
                                    {
                                        if (options.FileFormat == ImageFormat.Jpeg)
                                        {
                                            bmp.Save(fn, options.JpegQuality);
                                        }
                                        else
                                        {
                                            bmp.SaveAs(fn);
                                        }

                                        break;
                                    }
                            }
                        }
                    }

                    Tracker.TraceMessage(Tracker.Category.OutputFile, fn);
                    Tracker.IncrementProgress(1);
                }

            Tracker.TrackProgress(loadCount);
            Tracker.TraceMessage(Tracker.Category.Alert,
                "Successfully converted the image file, the storage directory is: <<" + options.ExtractImagePath +
                ">>.");
        }
        catch (OperationCanceledException)
        {
            Tracker.TraceMessage(Tracker.Category.ImportantMessage, OperationCanceled);
        }
        catch (Exception ex)
        {
            Tracker.TraceMessage(ex);
            FormHelper.ErrorBox("An error was encountered while converting the image:\n" + ex.Message);
        }
        finally
        {
            mupdf?.Dispose();
        }
    }

    internal static void ExportInfo(string sourceFile, string targetFile)
    {
        Tracker.TraceMessage(Tracker.Category.InputFile, sourceFile);
        Tracker.TraceMessage(Tracker.Category.OutputFile, targetFile);
        PdfReader r = OpenPdf(sourceFile, AppContext.LoadPartialPdfFile, false);
        if (r == null)
        {
            return;
        }

        if (FileHelper.IsPathValid(targetFile) == false || Path.GetFileName(targetFile).Length == 0)
        {
            Tracker.TraceMessage(Tracker.Category.Error, Messages.InfoFileNameInvalid);
            FormHelper.ErrorBox(Messages.InfoFileNameInvalid);
            return;
        }

        targetFile = FileHelper.MakePathRootedAndWithExtension(targetFile, sourceFile, Ext.Xml, false);
        DocInfoExporter export = new(r, AppContext.Exporter);
        if (AppContext.Exporter.ExtractImages)
        {
            AppContext.Exporter.Images.OutputPath = FileHelper.CombinePath(Path.GetDirectoryName(targetFile),
                Path.GetFileNameWithoutExtension(targetFile) + "Picture file\\");
        }

        try
        {
            Tracker.TraceMessage("Exporting message file.");
            if (targetFile.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
            {
                Tracker.SetProgressGoal(50);
                using TextWriter w = new StreamWriter(targetFile, false, AppContext.Exporter.GetEncoding());
                DocInfoExporter.WriteDocumentInfoAttributes(w, sourceFile, r.NumberOfPages);
                export.ExportDocument(w);
                w.WriteLine();
                Tracker.SetProgressGoal(10);
                r.ConsolidateNamedDestinations();
                export.ExportBookmarks(OutlineManager.GetBookmark(r, new UnitConverter()), w, 0, false);
            }
            else
            {
                int workload = export.EstimateWorkload();
                Tracker.SetProgressGoal(workload);
                using XmlWriter w = XmlWriter.Create(targetFile, DocInfoExporter.GetWriterSettings());
                w.WriteStartDocument();
                w.WriteStartElement(Constants.PdfInfo);
                DocInfoExporter.WriteDocumentInfoAttributes(w, sourceFile, r.NumberOfPages);
                export.ExportDocument(w);
                w.WriteEndElement();
            }

            Tracker.TraceMessage(Tracker.Category.Alert,
                "Successfully exported message file to <<" + targetFile + ">>.");
            //if (this._BookmarkBox.Text.Length == 0) {
            // this._BookmarkBox.Text = targetFile;
            //}
            //if (Common.Form.YesNoBox ("Completed exporting the information file to " + targetFile + ", do you want to use the built-in editor to edit the file?") == DialogResult.Yes) {
            // ShowInfoFileEditorForm (targetFile);
            //}
        }
        catch (OperationCanceledException)
        {
            Tracker.TraceMessage(Tracker.Category.ImportantMessage, OperationCanceled);
        }
        catch (EncoderFallbackException ex)
        {
            Tracker.TraceMessage(ex);
            FormHelper.ErrorBox("An error was encountered while exporting the message file:\n" + ex.Message +
                                "\n\nPlease choose another encoding method in the export message option.");
        }
        catch (Exception ex)
        {
            Tracker.TraceMessage(ex);
            FormHelper.ErrorBox("An error was encountered while exporting the message file:\n" + ex.Message);
        }
        finally
        {
            r.Close();
        }
    }

    internal static void PatchDocument(SourceItem.Pdf sourceFile, FilePath targetFile, object infoDoc,
        ImporterOptions options, PatcherOptions pdfSettings)
    {
        string sourcePath = sourceFile.FilePath.ToString();
        if (sourceFile.FilePath.IsEmpty)
        {
            Tracker.TraceMessage(Tracker.Category.Error, "The input filename is empty.");
            return;
        }

        if (string.IsNullOrEmpty(targetFile) || targetFile.IsEmpty)
        {
            Tracker.TraceMessage(Tracker.Category.Error, "The output filename is empty.");
            return;
        }

        Tracker.TraceMessage(Tracker.Category.InputFile, sourcePath);
        Tracker.TraceMessage(Tracker.Category.OutputFile, targetFile);
        bool overwriteSource = false;
        PdfReader pdf = OpenPdf(sourcePath, AppContext.LoadPartialPdfFile, true);
        if (pdf == null)
        {
            return;
        }

        try
        {
            DocInfoImporter import;
            PdfInfoXmlDocument xInfoDoc = infoDoc as PdfInfoXmlDocument;
            string docPath = infoDoc as string;
            if (xInfoDoc != null)
            {
                import = new DocInfoImporter(options, pdf, pdfSettings, xInfoDoc.BookmarkRoot);
            }
            else if (string.IsNullOrEmpty(docPath))
            {
                Tracker.TraceMessage(
                    "The information file is not specified, the patch will be executed according to the settings of the program interface.");
                import = new DocInfoImporter(options, pdf, pdfSettings, null);
                Tracker.TraceMessage(
                    "The information of the source PDF file is loaded, and the patch operation is ready.");
            }
            else
            {
                Tracker.TraceMessage(Tracker.Category.ImportantMessage,
                    string.Concat("Load information file: <<", docPath, ">>."));
                import = new DocInfoImporter(options, docPath);
                if (import.InfoDoc != null && VerifyInfoDocument(import.InfoDoc) == false)
                {
                    return;
                }
            }

            PdfProcessingEngine pdfEngine = new(pdf);
            pdfEngine.CreateProcessors(pdfSettings);
            int workload = 110;
            workload += pdfEngine.EstimateWorkload();
            Tracker.SetProgressGoal(workload);
            Tracker.TrackProgress(10);

            if (pdf.ConfirmUnethicalMode() == false)
            {
                return;
            }

            Tracker.TraceMessage("Import document properties.");
            //var pdfInfo = DocInfoExporter.RewriteDocInfoWithEncoding (pdf.Trailer.GetAsDict (PdfName.INFO), AppContext.Encodings.DocInfoEncoding);
            GeneralInfo info = pdfSettings.MetaData.SpecifyMetaData
                ? pdfSettings.MetaData
                //: sourceFile.DocInfo;
                // File properties of the bookmark file no longer use
                : import.ImportDocumentInformation()
                  ?? sourceFile.DocInfo;
            DocInfoImporter.ImportDocumentInformation(info, pdf, sourcePath);
            Tracker.TrackProgress(20);

            if (FileHelper.HasFileNameMacro(targetFile))
            {
                targetFile = ReplaceTargetFileNameMacros(sourcePath, targetFile, pdf);
            }

            targetFile = FileHelper.MakePathRootedAndWithExtension(targetFile, sourcePath, Ext.Pdf, true);
            targetFile = targetFile.Normalize();

            Tracker.TraceMessage(Tracker.Category.OutputFile, targetFile);
            if (FileHelper.ComparePath(sourcePath, targetFile))
            {
                if (FormHelper.YesNoBox(
                        "Would you like to overwrite the original PDF file?\nIf there is an error in the processing process, the overwriting operation will cause the original data to be unrecoverable!") ==
                    DialogResult.No)
                {
                    Tracker.TraceMessage(Tracker.Category.Error, Messages.SourceFileEqualsTargetFile);
                    return;
                }

                overwriteSource = true;
                targetFile = sourceFile.FilePath.ChangeExtension(Ext.Tmp).ToString();
            }
            else if (FileHelper.CheckOverwrite(targetFile) == false)
            {
                return;
            }

            targetFile.CreateContainingDirectory();

            using Stream s = new FileStream(targetFile, FileMode.Create);
            PdfStamper st = new(pdf, s);
            pdfEngine.ProcessDocument(st.Writer);

            #region Processing information files

            List<IInfoDocProcessor> processors = new();
            if (pdfSettings.ViewerPreferences.RemoveZoomRate)
            {
                processors.Add(new RemoveZoomRateProcessor());
            }

            if (pdfEngine.ExtraData.ContainsKey(DocProcessorContext.CoordinateTransition) &&
                pdfSettings.UnifiedPageSettings.ScaleContent)
            {
                processors.Add(new GotoDestinationProcessor
                {
                    TransitionMapper =
                        pdfEngine.ExtraData[DocProcessorContext.CoordinateTransition] as
                            CoordinateTranslationSettings[]
                });
            }

            if (pdfSettings.ViewerPreferences.ForceInternalLink)
            {
                processors.Add(new ForceInternalDestinationProcessor());
            }

            //var cts = new CoordinateTranslationSettings[pdf.NumberOfPages + 1]; // Page position offset
            //var sc = false;
            //if (pdfSettings.PageSettings.Count > 0) {
            //    Tracker.TraceMessage ("Reset page size.");
            //    pdf.ResetReleasePage ();
            //    foreach (var item in pdfSettings.PageSettings) {
            //        var ranges = PageRangeCollection.Parse (item.PageRanges, 1, pdf.NumberOfPages, true);
            //        foreach (var range in ranges) {
            //            foreach (var i in range) {
            //                var s = PageDimensionProcessor.ResizePage (pdf.GetPageN (i), item.PaperSize, item.HorizontalAlign, item.VerticalAlign, -1, item.ScaleContent);
            //                if (item.ScaleContent && s.XScale != 1 && s.YScale != 1) {
            //                    PageDimensionProcessor.ScaleContent (pdf, i, s);
            //                    cts[i] = s; // TODO: Need to resolve the issue of repeated designation of the same page
            //                    sc = true;
            //                }
            //            }
            //        }
            //    }
            //    pdf.ResetReleasePage ();
            //}
            if (pdfSettings.UnifiedPageSettings.PaperSize.PaperName == PaperSize.AsPageSize)
            {
                import.ImportPageSettings(pdf);
            }

            //if (sc == false) {
            //    cts = null;
            //}

            #endregion

            if (pdfSettings.FullCompression)
            {
                st.SetFullCompression();
            }

            //st.Writer.CompressionLevel = ContextData.CreateDocumentOptions.CompressionLevel;
            PdfPageLabels labels = DocInfoImporter.ImportPageLabels(pdfSettings.PageLabels) ??
                                   import.ImportPageLabels();
            if (labels != null)
            {
                st.Writer.PageLabels = labels;
            }

            if (options.ImportPageLinks ||
                pdfSettings.UnifiedPageSettings.PaperSize.PaperName != PaperSize.AsPageSize /* sc*/)
            {
                import.ImportPageLinks(pdf, st);
            }

            PdfDocumentCreator.ProcessInfoItem(
                import.InfoDoc.DocumentElement.SelectSingleNode(Constants.PageLink) as XmlElement, processors);
            PdfDocumentCreator.ProcessInfoItem(
                import.InfoDoc.DocumentElement.SelectSingleNode(Constants.NamedDestination) as XmlElement,
                processors);
            XmlElement bookmarks = null;
            if (options.ImportBookmarks && pdfSettings.RemoveBookmarks == false || xInfoDoc != null)
            {
                Tracker.TraceMessage("Import bookmarks.");
                bookmarks = import.GetBookmarks() ??
                            OutlineManager.GetBookmark(pdf, new UnitConverter { Unit = Constants.Units.Point });
            }

            if (bookmarks != null)
            {
                // Pretreatment bookmark
                processors.Add(new CollapseBookmarkProcessor
                {
                    BookmarkStatus = pdfSettings.ViewerPreferences.CollapseBookmark
                });
                PdfDocumentCreator.ProcessInfoItem(bookmarks, processors);
                if (bookmarks.ChildNodes.Count > 0 || xInfoDoc != null)
                {
                    import.ImportNamedDestinations(pdf, st.Writer);
                    OutlineManager.KillOutline(pdf);
                    PdfIndirectReference bm = OutlineManager.WriteOutline(st.Writer, bookmarks, pdf.NumberOfPages);
                    if (bm != null)
                    {
                        pdf.Catalog.Put(PdfName.OUTLINES, bm);
                    }

                    if (pdf.Catalog.Contains(PdfName.PAGEMODE) == false)
                    {
                        pdf.Catalog.Put(PdfName.PAGEMODE, PdfName.USEOUTLINES);
                    }
                }
                else if (string.IsNullOrEmpty(docPath) == false)
                {
                    OutlineManager.KillOutline(pdf);
                }
            }

            Tracker.IncrementProgress(10);
            Tracker.TraceMessage("Import documentation settings.");
            import.ImportViewerPreferences(pdf);
            DocInfoImporter.OverrideViewerPreferences(pdfSettings.ViewerPreferences, pdf, st.Writer);
            //import.OverrideDocumentSettings (pdf);
            Tracker.IncrementProgress(5);
            Tracker.TraceMessage("Clean up the output file.");
            pdf.RemoveUnusedObjects();
            if (pdf.AcroForm == null)
            {
                pdf.Trailer.Locate<PdfDictionary>(PdfName.ROOT).Remove(PdfName.ACROFORM);
            }

            Tracker.IncrementProgress(10);
            Tracker.TraceMessage("save document: " + targetFile);
            st.Close();
            Tracker.TrackProgress(workload);
        }
        catch (OperationCanceledException)
        {
            Tracker.TraceMessage(Tracker.Category.ImportantMessage, OperationCanceled);
            return;
        }
        catch (Exception ex)
        {
            Tracker.TraceMessage(ex);
            FormHelper.ErrorBox("An error occurred while importing information: \n" + ex.Message);
            return;
        }
        finally
        {
            if (pdf != null)
            {
                try
                {
                    pdf.Close();
                }
                catch (Exception ex)
                {
                    // ignore exception
                    Tracker.TraceMessage(ex);
                }
            }
        }

        if (overwriteSource)
        {
            try
            {
                Tracker.TraceMessage("Overwrite the input file.");
                File.Delete(sourcePath);
                File.Move(targetFile, sourcePath);
                targetFile = sourcePath;
            }
            catch (Exception)
            {
                FormHelper.ErrorBox(
                    "The input file cannot be overwritten.\nPlease manually rename the temporary file suffixed with \"" +
                    Ext.Tmp + "\" to the input file.");
            }
        }

        Tracker.TraceMessage(Tracker.Category.Alert, "Successfully imported message to <<" + targetFile + ">>.");
    }

    internal static string ReplaceTargetFileNameMacros(string sourceFile, string targetFile, PdfReader pdf)
    {
        try
        {
            return ReplaceTargetFileNameMacros(sourceFile, targetFile, pdf.Trailer.GetAsDict(PdfName.INFO));
        }
        catch (IOException)
        {
            return ReplaceTargetFileNameMacros(sourceFile, targetFile, null as PdfDictionary);
        }
    }

    /// <summary>
    ///     Replace the alternative of the target file name.
    /// </summary>
    /// <param name="sourceFile">The source file used for replacement.</param>
    /// <param name="targetFile">contains the target file name of the alternative.</param>
    /// <param name="info">The metadata properties of the source file.</param>
    /// <returns>replaces the file name after the target file name.</returns>
    internal static string ReplaceTargetFileNameMacros(string sourceFile, string targetFile, PdfDictionary info)
    {
        string p = null; // Document property
        if (info == null)
        {
            return targetFile
                .Replace(Constants.FileNameMacros.FileName, Path.GetFileNameWithoutExtension(sourceFile))
                .Replace(Constants.FileNameMacros.FolderName, Path.GetFileName(Path.GetDirectoryName(sourceFile)))
                .Replace(Constants.FileNameMacros.PathName,
                    FileHelper.CombinePath(sourceFile.Substring(0, sourceFile.LastIndexOf(Path.DirectorySeparatorChar)),
                        string.Empty));
        }

        if (info.Contains(PdfName.TITLE))
        {
            p = FileHelper.GetValidFileName(info.GetAsString(PdfName.TITLE).ToUnicodeString());
        }

        targetFile = targetFile.Replace(Constants.FileNameMacros.TitleProperty,
            p ?? Path.GetFileNameWithoutExtension(sourceFile));
        p = string.Empty;
        if (info.Contains(PdfName.SUBJECT))
        {
            p = FileHelper.GetValidFileName(info.GetAsString(PdfName.SUBJECT).ToUnicodeString());
        }

        targetFile = targetFile.Replace(Constants.FileNameMacros.SubjectProperty, p);
        p = string.Empty;
        if (info.Contains(PdfName.AUTHOR))
        {
            p = FileHelper.GetValidFileName(info.GetAsString(PdfName.AUTHOR).ToUnicodeString());
        }

        targetFile = targetFile.Replace(Constants.FileNameMacros.AuthorProperty, p);
        p = string.Empty;
        if (info.Contains(PdfName.KEYWORDS))
        {
            p = FileHelper.GetValidFileName(info.GetAsString(PdfName.KEYWORDS).ToUnicodeString());
        }

        targetFile = targetFile.Replace(Constants.FileNameMacros.KeywordsProperty, p);

        return targetFile
            .Replace(Constants.FileNameMacros.FileName, Path.GetFileNameWithoutExtension(sourceFile))
            .Replace(Constants.FileNameMacros.FolderName, Path.GetFileName(Path.GetDirectoryName(sourceFile)))
            .Replace(Constants.FileNameMacros.PathName,
                FileHelper.CombinePath(sourceFile.Substring(0, sourceFile.LastIndexOf(Path.DirectorySeparatorChar)),
                    string.Empty));
    }

    private static bool VerifyInfoDocument(XmlDocument infoDoc)
    {
        XmlElement root = infoDoc.DocumentElement;
        switch (root.Name)
        {
            case Constants.PdfInfo:
                // Use Chinese bookmarks
                string v = root.GetAttribute(Constants.Info.ProductVersion);
                if (v != Constants.InfoDocVersion
                    && FormHelper.YesNoBox(string.Concat(
                        "The information file is not generated by this version of the program, it may be imported unsuccessfully, do you want to continue?\nThe current program version is: ",
                        Application.ProductVersion, "\nThe exporter version of the info file is:", v)) ==
                    DialogResult.No)
                {
                    return false;
                }

                break;
            default:
                FormHelper.ErrorBox("The format of the information file is incorrect, the root element is not \"" +
                                    Constants.PdfInfo + "\".");
                return false;
        }

        return true;
    }

    internal static void ExtractPages(ExtractPageOptions options, string sourceFile, string targetFile)
    {
        Tracker.TraceMessage(Tracker.Category.InputFile, sourceFile);
        Tracker.TraceMessage(Tracker.Category.OutputFile, targetFile);
        PdfReader r = OpenPdf(sourceFile, AppContext.LoadPartialPdfFile, false);
        if (r == null)
        {
            return;
        }

        try
        {
            if (r.ConfirmUnethicalMode() == false)
            {
                return;
            }

            PdfPageExtractor.ExtractPages(options, sourceFile, targetFile, r);
        }
        catch (OperationCanceledException)
        {
            Tracker.TraceMessage(Tracker.Category.ImportantMessage, OperationCanceled);
        }
        catch (Exception ex)
        {
            Tracker.TraceMessage(ex);
            FormHelper.ErrorBox("An error occurred while exporting the page content: \n" + ex.Message);
        }
        finally
        {
            try
            {
                r.Close();
            }
            catch (Exception ex)
            {
                // ignore exception
                Tracker.TraceMessage(ex);
            }
        }
    }

    internal static void MergeDocuments(ICollection<SourceItem> sources, FilePath targetFile, string infoFile)
    {
        targetFile = targetFile.EnsureExtension(Ext.Pdf);
        Tracker.TraceMessage(Tracker.Category.OutputFile, targetFile.ToString());
        MergerOptions option = AppContext.Merger;
        ImporterOptions impOptions = AppContext.Importer;
        Document doc = null;
        DocumentSink sink = new(sources, true);
        if (sink.Workload == 0)
        {
            Tracker.TraceMessage(Tracker.Category.ImportantMessage,
                "The merged file list does not include a picture or PDF file.");
            return;
        }

        Tracker.SetProgressGoal(10 + sink.Workload);
        Tracker.TrackProgress(1);
        try
        {
            GeneralInfo info = null;
            PdfPageLabels labels = null;
            BookmarkContainer bookmarks = null;
            if (string.IsNullOrEmpty(infoFile) == false)
            {
                Tracker.TraceMessage(Tracker.Category.ImportantMessage,
                    string.Concat("Load information file: <<", infoFile, ">>。"));
                DocInfoImporter import = new(impOptions, infoFile);
                info = import.ImportDocumentInformation();
                labels = import.ImportPageLabels();
                bookmarks = import.GetBookmarks();
            }

            if (labels == null && option.PageLabels.Count > 0)
            {
                labels = DocInfoImporter.ImportPageLabels(option.PageLabels);
            }

            FilePath f = targetFile.EnsureExtension(Ext.Pdf);
            Tracker.TraceMessage(Tracker.Category.OutputFile, f.ToString());
            Tracker.TraceMessage(Tracker.Category.ImportantMessage, string.Concat("Output to the file: ", f, "。"));
            if (f.IsValidPath == false)
            {
                Tracker.TraceMessage(Tracker.Category.Error, "The output file path is invalid.");
                return;
            }

            f.CreateContainingDirectory();
            using Stream s = new FileStream(f, FileMode.Create);
            PageBoxSettings ps = option.PageSettings;
            doc = new Document(
                new Rectangle(ps.PaperSize.Width, ps.PaperSize.Height),
                ps.Margins.Left, ps.Margins.Right, ps.Margins.Top, ps.Margins.Bottom
            );
            PdfSmartCopy w = new(doc, s);
            if (option.FullCompression)
            {
                w.SetFullCompression();
            }

            //w.CompressionLevel = ContextData.CreateDocumentOptions.CompressionLevel;
            doc.Open();
            doc.AddCreator(Application.ProductName + " " + Application.ProductVersion);
            if (labels != null)
            {
                w.PageLabels = labels;
            }

            Tracker.IncrementProgress(10);
            PdfDocumentCreator creator = new(sink, option, impOptions, doc, w);
            foreach (SourceItem item in sources)
            {
                creator.ProcessFile(item, creator.PdfBookmarks.BookmarkRoot);
            }

            Tracker.TraceMessage("Set the document option.");
            DocInfoImporter.ImportDocumentInformation(option.MetaData.SpecifyMetaData
                ? option.MetaData
                : info, doc);
            DocInfoImporter.OverrideViewerPreferences(option.ViewerPreferences, null, w);
            if ((bookmarks == null || bookmarks.HasChildNodes == false) &&
                creator.PdfBookmarks.DocumentElement.HasChildNodes)
            {
                bookmarks = creator.PdfBookmarks.BookmarkRoot;
            }

            if (bookmarks is { HasChildNodes: true })
            {
                Tracker.TraceMessage("Write document bookmarks.");
                OutlineManager.WriteOutline(w, bookmarks,
                    w.PageEmpty ? w.CurrentPageNumber - 1 : w.CurrentPageNumber);
                w.ViewerPreferences = PdfWriter.PageModeUseOutlines;
            }

            Tracker.TraceMessage("Write file index.");
            Tracker.TraceMessage(Tracker.Category.Alert, "Generated file: <<" + targetFile + ">>.");
            w.Close();
        }
        catch (OperationCanceledException)
        {
            Tracker.TraceMessage(Tracker.Category.ImportantMessage, OperationCanceled);
        }
        catch (Exception ex)
        {
            Tracker.TraceMessage(ex);
            FormHelper.ErrorBox("Error generating document:\n" + ex.Message);
        }
        finally
        {
            if (doc != null)
            {
                try
                {
                    doc.Close();
                }
                catch (Exception ex)
                {
                    // ignore exception
                    Tracker.TraceMessage(ex);
                }
            }
        }
    }

    internal static void CreateBookmark(string sourceFile, string bookmarkFile, AutoBookmarkOptions options)
    {
        Tracker.TraceMessage(Tracker.Category.InputFile, sourceFile);
        Tracker.TraceMessage(Tracker.Category.OutputFile, bookmarkFile);
        PdfReader r = OpenPdf(sourceFile, AppContext.LoadPartialPdfFile, false);
        if (r == null)
        {
            return;
        }

        if (FileHelper.IsPathValid(bookmarkFile) == false || Path.GetFileName(bookmarkFile).Length == 0)
        {
            Tracker.TraceMessage(Tracker.Category.Error, Messages.InfoFileNameInvalid);
            FormHelper.ErrorBox(Messages.InfoFileNameInvalid);
            return;
        }

        bookmarkFile = FileHelper.MakePathRootedAndWithExtension(bookmarkFile, sourceFile, Ext.Xml, true);
        Tracker.TraceMessage(Tracker.Category.OutputFile, bookmarkFile);

        if (options.CreateBookmarkForFirstPage)
        {
            options.FirstPageTitle = Path.GetFileNameWithoutExtension(sourceFile);
        }

        AutoBookmarkCreator creator = new(r, options);

        try
        {
            Tracker.TraceMessage("Analyzing PDF file.");
            int workload = creator.EstimateWorkload();
            Tracker.SetProgressGoal(workload);
            using (XmlWriter w = XmlWriter.Create(bookmarkFile, DocInfoExporter.GetWriterSettings()))
            {
                w.WriteStartDocument();
                w.WriteStartElement(Constants.PdfInfo);
                w.WriteAttributeString(Constants.Info.ProductName, Application.ProductName);
                w.WriteAttributeString(Constants.Info.ProductVersion, Constants.InfoDocVersion);
                w.WriteAttributeString(Constants.Info.ExportDate,
                    DateTime.Now.ToString("MM month dd day yyyy HH:mm:ss"));
                //w.WriteAttributeString (Constants.Info.DocumentName, Path.GetFileNameWithoutExtension (sourceFile));
                w.WriteAttributeString(Constants.Info.DocumentPath, sourceFile);
                w.WriteAttributeString(Constants.Info.PageNumber, r.NumberOfPages.ToText());
                creator.ExportAutoBookmarks(w, options);
                w.WriteEndElement();
            }

            Tracker.TraceMessage(Tracker.Category.Alert,
                "Successfully exported message file to <<" + bookmarkFile + ">>.");
        }
        catch (OperationCanceledException)
        {
            Tracker.TraceMessage(Tracker.Category.ImportantMessage, OperationCanceled);
        }
        catch (EncoderFallbackException ex)
        {
            Tracker.TraceMessage(ex);
            FormHelper.ErrorBox("An error was encountered while exporting the message file:\n" + ex.Message +
                                "\n\nPlease choose another encoding method in the export message option.");
        }
        catch (Exception ex)
        {
            Tracker.TraceMessage(ex);
            FormHelper.ErrorBox("An error was encountered while exporting the message file:\n" + ex.Message);
        }
        finally
        {
            r.Close();
        }
    }

    internal static void Ocr(string sourceFile, string bookmarkFile, OcrOptions options)
    {
        Tracker.TraceMessage(Tracker.Category.InputFile, sourceFile);
        Tracker.TraceMessage(Tracker.Category.OutputFile, bookmarkFile);
        PdfReader r = OpenPdf(sourceFile, AppContext.LoadPartialPdfFile, false);
        if (r == null)
        {
            return;
        }

        bool noOutputFile = false;
        if (string.IsNullOrEmpty(bookmarkFile))
        {
            noOutputFile = true;
        }
        else if (FileHelper.IsPathValid(bookmarkFile) == false || Path.GetFileName(bookmarkFile).Length == 0)
        {
            Tracker.TraceMessage(Tracker.Category.Error, Messages.InfoFileNameInvalid);
            FormHelper.ErrorBox(Messages.InfoFileNameInvalid);
            return;
        }

        try
        {
            if (FileHelper.CheckOverwrite(bookmarkFile) == false)
            {
                return;
            }
        }
        catch (OperationCanceledException)
        {
            return;
        }

        bookmarkFile = FileHelper.MakePathRootedAndWithExtension(bookmarkFile, sourceFile, Ext.Xml, false);
        Tracker.TraceMessage(Tracker.Category.OutputFile, bookmarkFile);

        OcrProcessor ocr;
        try
        {
            ocr = new OcrProcessor(r, options);
        }
        catch (FileNotFoundException ex)
        {
            Tracker.TraceMessage(ex);
            FormHelper.ErrorBox(ex.Message);
            return;
        }

        try
        {
            Tracker.TraceMessage("Analyzing PDF file.");
            int workload = ocr.EstimateWorkload();
            Tracker.SetProgressGoal(workload);
            if (noOutputFile)
            {
                ocr.PerformOcr();
            }
            else if (new FilePath(bookmarkFile).HasExtension(Ext.Txt))
            {
                Tracker.TraceMessage(Tracker.Category.OutputFile, bookmarkFile);
                Tracker.TraceMessage("Output brief information file: " + bookmarkFile);
                using TextWriter w = new StreamWriter(bookmarkFile, false, AppContext.Exporter.GetEncoding());
                DocInfoExporter.WriteDocumentInfoAttributes(w, sourceFile, r.NumberOfPages);
                ocr.SetWriter(w);
                ocr.PerformOcr();
            }
            else
            {
                Tracker.TraceMessage(Tracker.Category.OutputFile, bookmarkFile);
                Tracker.TraceMessage("Output message file: " + bookmarkFile);
                using XmlWriter w = XmlWriter.Create(bookmarkFile, DocInfoExporter.GetWriterSettings());
                w.WriteStartDocument();
                w.WriteStartElement(Constants.PdfInfo);
                DocInfoExporter.WriteDocumentInfoAttributes(w, sourceFile, r.NumberOfPages);
                ocr.SetWriter(w);
                ocr.PerformOcr();
                w.WriteEndElement();
            }

            if (noOutputFile == false)
            {
                Tracker.TraceMessage(Tracker.Category.Alert,
                    "Completed exporting message file to <<" + bookmarkFile + ">>.");
            }
            else
            {
                Tracker.TraceMessage(Tracker.Category.Alert, "Completed analyzing the document.");
            }
        }
        catch (OperationCanceledException)
        {
            Tracker.TraceMessage(Tracker.Category.ImportantMessage, OperationCanceled);
        }
        catch (EncoderFallbackException ex)
        {
            Tracker.TraceMessage(ex);
            FormHelper.ErrorBox("An error was encountered while exporting the message file:\n" + ex.Message +
                                "\n\nPlease choose another encoding method in the export message option.");
        }
        catch (Exception ex)
        {
            Tracker.TraceMessage(ex);
            FormHelper.ErrorBox("An error was encountered while exporting the message file:\n" + ex.Message);
        }
        finally
        {
            r.Close();
        }
    }

    internal static string RenameFile(string template, SourceItem.Pdf item)
    {
        FilePath s = item.FilePath;
        PdfDictionary d = new();
        DocInfoImporter.UpdateInfoValue(d, PdfName.TITLE, item.DocInfo.Title, s);
        DocInfoImporter.UpdateInfoValue(d, PdfName.AUTHOR, item.DocInfo.Author, s);
        DocInfoImporter.UpdateInfoValue(d, PdfName.SUBJECT, item.DocInfo.Subject, s);
        DocInfoImporter.UpdateInfoValue(d, PdfName.KEYWORDS, item.DocInfo.Keywords, s);
        string t = ReplaceTargetFileNameMacros(s.ToString(), template, d);
        if (FileHelper.IsPathValid(t) == false)
        {
            return t;
        }

        if (Path.GetFileName(t).Length > 0)
        {
            t = new FilePath(t).EnsureExtension(Ext.Pdf).ToString();
        }

        return Path.GetFullPath(t);
    }

    internal static void RenameFiles(List<SourceItem.Pdf> items, string template, bool keepSourceFile)
    {
        Tracker.SetTotalProgressGoal(items.Count);
        Tracker.TraceMessage(string.Concat("Rename using \"", template, "\" template."));
        foreach (SourceItem.Pdf item in items)
        {
            try
            {
                FilePath s = item.FilePath.ToFullPath();
                if (s.ExistsFile == false)
                {
                    Tracker.TraceMessage(Tracker.Category.Error, string.Concat("Cannot find PDF file: ", s));
                    continue;
                }

                string t = RenameFile(template, item);
                Tracker.TraceMessage(Tracker.Category.InputFile, s.ToString());
                Tracker.TraceMessage(Tracker.Category.OutputFile, t);
                Tracker.TraceMessage(Tracker.Category.ImportantMessage, string.Concat("Rename PDF file: ", s));
                Tracker.TraceMessage(Tracker.Category.ImportantMessage,
                    string.Concat("To the target PDF file: <<", t, ">>."));
                if (FileHelper.IsPathValid(t) == false)
                {
                    Tracker.TraceMessage(Tracker.Category.Error, string.Concat("Output filename", t, "Invalid."));
                    goto Exit;
                }

                if (s.Equals(t))
                {
                    Tracker.TraceMessage("The source file has the same name as the target file. No need to rename.");
                    goto Exit;
                }

                if (Path.GetFileName(t).Trim().Length == 0)
                {
                    Tracker.TraceMessage("The output file name is empty and cannot be renamed.");
                    goto Exit;
                }

                if (File.Exists(t))
                {
                    DialogResult r = FormHelper.YesNoCancelBox("Whether to overwrite the existing PDF file: " + t);
                    switch (r)
                    {
                        case DialogResult.No:
                            goto Exit;
                        case DialogResult.Cancel:
                            throw new OperationCanceledException();
                    }

                    // r == DialogResult.Yes
                    File.Delete(t);
                }

                if (Directory.Exists(Path.GetDirectoryName(t)) == false)
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(t));
                }

                if (keepSourceFile)
                {
                    File.Copy(s.ToString(), t);
                }
                else
                {
                    File.Move(s.ToString(), t);
                }
            }
            catch (OperationCanceledException)
            {
                Tracker.TraceMessage(Tracker.Category.Alert, "Removal operation has been canceled.");
                return;
            }
            catch (Exception ex)
            {
                Tracker.TraceMessage(ex);
            }

        Exit:
            Tracker.IncrementTotalProgress();
        }

        Tracker.TraceMessage("Rename operation completed.");
    }

    internal static void ImportOcr(string sourceFile, string infoFile, string targetFile)
    {
        if (FileHelper.IsPathValid(sourceFile) == false)
        {
            Tracker.TraceMessage(Tracker.Category.Error, "The input PDF file path is invalid.");
            return;
        }

        if (FileHelper.IsPathValid(targetFile) == false)
        {
            Tracker.TraceMessage(Tracker.Category.Error, "The output PDF file path is invalid.");
            return;
        }

        if (FileHelper.IsPathValid(infoFile) == false)
        {
            Tracker.TraceMessage(Tracker.Category.Error, "Invalid message file path.");
            return;
        }

        Tracker.TraceMessage(Tracker.Category.InputFile, sourceFile);
        Tracker.TraceMessage(Tracker.Category.OutputFile, targetFile);
        if (FileHelper.ComparePath(sourceFile, targetFile))
        {
            Tracker.TraceMessage(Tracker.Category.Error, "The input file and output file cannot be the same.");
            return;
        }

        if (FileHelper.CheckOverwrite(targetFile) == false)
        {
            return;
        }

        PdfReader pdf = OpenPdf(sourceFile, AppContext.LoadPartialPdfFile, false);
        if (pdf == null)
        {
            return;
        }

        try
        {
            using (XmlReader infoReader = XmlReader.Create(infoFile,
                       new XmlReaderSettings { IgnoreComments = true, IgnoreProcessingInstructions = true }))
            {
                infoReader.MoveToContent(); // Move to root elements
                using (Stream s = new FileStream(targetFile, FileMode.Create))
                {
                    PdfStamper st = new(pdf, s);
                    PdfProcessingEngine en = new(pdf) { ExtraData = { [DocProcessorContext.OcrData] = infoReader } };
                    en.DocumentProcessors.Add(new ImportOcrResultProcessor());
                    Tracker.SetProgressGoal(en.EstimateWorkload());
                    en.ProcessDocument(st.Writer);
                    st.Close();
                }
            }

            Tracker.TraceMessage(Tracker.Category.ImportantMessage,
                "Successfully write recognition result to file: <<" + targetFile + ">>.");
        }
        catch (OperationCanceledException)
        {
            Tracker.TraceMessage(Tracker.Category.ImportantMessage, OperationCanceled);
        }
        catch (Exception ex)
        {
            Tracker.TraceMessage(ex);
            FormHelper.ErrorBox("Error importing message:\n" + ex.Message);
        }
        finally
        {
            try
            {
                pdf.Close();
            }
            catch (Exception ex)
            {
                // ignore exception
                Tracker.TraceMessage(ex);
            }
        }
    }
}
