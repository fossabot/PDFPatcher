using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PDFPatcher.Common;

namespace PDFPatcher.Functions;

public class FunctionControl : UserControl
{
    public EventHandler ListRecentFiles;

    public EventHandler<ToolStripItemClickedEventArgs> RecentFileItemClicked;

    protected FunctionControl()
    {
        ListRecentFiles = (s, _) =>
        {
            ToolStripDropDownItem m = (ToolStripDropDownItem)s;
            ToolStripItemCollection l = m.DropDown.Items;
            l.ClearDropDownItems();
            l.AddSourcePdfFiles();
        };
        RecentFileItemClicked = (_, args) => ExecuteCommand(Commands.OpenFile, args.ClickedItem.ToolTipText);
    }

    [Browsable(false)] public virtual string FunctionName => null;

    [Browsable(false)] public virtual Bitmap IconImage => null;

    [Browsable(false)] public virtual Button DefaultButton => null;

    public void ExecuteCommand(ToolStripItem item)
    {
        item.HidePopupMenu();
        ExecuteCommand(item.Name);
    }

    public virtual void ExecuteCommand(string commandName, params string[] parameters)
    {
        if (Commands.OpenFile != commandName)
        {
            return;
        }

        // Set the first text box as a file path
        if (parameters.Length <= 0 || string.IsNullOrEmpty(parameters[0]) ||
            !FileHelper.HasExtension(parameters[0], Constants.FileExtensions.Pdf))
        {
            return;
        }

        foreach (Control c in Controls)
        {
            if (c is not SourceFileControl i)
            {
                continue;
            }

            i.Text = parameters[0];
            return;
        }
    }

    public virtual void SetupCommand(ToolStripItem item)
    {
    }

    internal virtual void OnSelected()
    {
    }

    internal virtual void OnDeselected()
    {
    }

    internal void SetupMenu(ToolStripMenuItem menu) => SetupMenu(menu.DropDownItems);

    internal void SetupMenu(ToolStripItemCollection items)
    {
        bool pvs = false; // The previous visible item is a separator
        foreach (ToolStripItem item in items)
        {
            switch (item.Name)
            {
                case Commands.Action:
                    if (DefaultButton != null)
                    {
                        Button b = DefaultButton;
                        item.Image = b.Image;
                        item.Text = b.Text.Trim();
                        item.ToolTipText = b.Tag as string;
                    }

                    EnableCommand(item, true, true);
                    break;
                case Commands.SaveBookmark:
                    item.Text = "&Save bookmark file";
                    item.ToolTipText =
                        "Save bookmarks as an XML-formatted info file that can be used to migrate bookmarks";
                    goto default;
                case Commands.ResetOptions:
                    EnableCommand(item, this is IResettableControl, true);
                    break;
                case Commands.ShowGeneralToolbar:
                    ToolStripMenuItem m = item as ToolStripMenuItem;
                    m.Checked = AppContext.Toolbar.ShowGeneralToolbar;
                    break;
                default:
                    EnableCommand(item,
                        Commands.DefaultDisabledItems.Contains(item.Name) == false,
                        Commands.DefaultHiddenItems.Contains(item.Name) == false
                    );
                    break;
            }

            SetupCommand(item);
            if (!item.Visible)
            {
                continue;
            }

            bool s = item is ToolStripSeparator;
            if (s)
            {
                item.Visible = pvs == false;
                pvs = true;
            }
            else
            {
                pvs = false;
            }
        }
    }

    internal void EnableCommand(ToolStripItem item, bool enabled, bool visible)
    {
        if (item == null)
        {
            return;
        }

        item.Enabled = enabled;
        item.Visible = visible;
    }
}
