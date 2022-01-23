using System;
using System.Diagnostics;
using System.Drawing;
using PDFPatcher.Common;
using PDFPatcher.Properties;
using TheArtOfDev.HtmlRenderer.Core.Entities;

namespace PDFPatcher.Functions;

internal class HtmlPageControl : FunctionControl
{
    protected void HandleLinkClicked(string link)
    {
        int i = link.IndexOf(':');
        if (i == -1)
        {
            return;
        }

        string p = link.Substring(0, i);
        switch (p)
        {
            case "func":
                Function func = (Function)Enum.Parse(typeof(Function), link.Substring(i + 1));
                AppContext.MainForm.SelectFunctionList(func);
                break;
            case "recent":
                AppContext.MainForm.OpenFileWithEditor(
                    AppContext.Recent.SourcePdfFiles[link.Substring(i + 1).ToInt32()]);
                break;
            case "exec":
                ExecuteCommand(link.Substring(i + 1));
                break;
            case "http":
            case "https":
                Process.Start(link);
                break;
        }
    }

    protected void LoadResourceImage(HtmlImageLoadEventArgs e)
    {
        e.Callback(Resources.ResourceManager.GetObject(e.Src.Substring("res:".Length)) as Image);
        e.Handled = true;
    }

    /// <summary>Returns the sub-string containing the specified string in the string.</summary>
    /// <remarks>Returns an empty string if specified strings cannot be found.</remarks>
    protected static string SubstringAfter(string source, char value)
    {
        int index = source.LastIndexOf(value);
        return index != -1 ? source.Substring(index + 1) : string.Empty;
    }
}
