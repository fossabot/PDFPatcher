﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PDFPatcher.Common;
using PDFPatcher.Model;

namespace PDFPatcher.Functions.Editor;

internal sealed class OcrPageCommand : IEditorCommand
{
    public void Process(Controller controller, params string[] parameters)
    {
        PdfViewerControl v = controller.View.Viewer;
        PagePosition pp = v.TransposeVirtualImageToPagePosition(v.PinPoint.X, v.PinPoint.Y);
        if (pp.Page == 0)
        {
            return;
        }

        List<TextLine> or = v.OcrPage(pp.Page, true);
        if (or != null)
        {
            Clipboard.SetText(string.Join(Environment.NewLine, v.CleanUpOcrResult(or)));
        }
        else
        {
            FormHelper.InfoBox("The page does not contain identifiable text, or the recognition engine error occurs.");
        }
    }
}
