using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using PDFPatcher.Common;
using PDFPatcher.Functions.Editor;
using PDFPatcher.Model;
using PDFPatcher.Processor;

namespace PDFPatcher.Functions;

public sealed partial class SearchBookmarkForm : Form
{
    private static BookmarkMatcher.MatcherType _matcherType = BookmarkMatcher.MatcherType.Normal;
    private static bool _replaceInSelection = true;

    //static char[] __TrimChars = new char[] { ' ', '\t', '\r', '\n', '　' };
    private readonly Controller _controller;

    internal SearchBookmarkForm(Controller controller)
    {
        InitializeComponent();
        _controller = controller;
    }

    private void _SearchTextBox_TextChanged(object sender, EventArgs e) => _ResultLabel.Text = string.Empty;

    private void SearchBookmarkForm_Load(object sender, EventArgs e)
    {
        MinimumSize = Size;
        ShowInTaskbar = false;
        _SearchTextBox.Contents = AppContext.Recent.SearchPatterns;
        _ReplaceTextBox.Contents = AppContext.Recent.ReplacePatterns;
        RadioButton b = _NormalSearchBox;
        switch (_matcherType)
        {
            case BookmarkMatcher.MatcherType.Normal:
                goto default;
            case BookmarkMatcher.MatcherType.Regex:
                b = _RegexSearchBox;
                goto default;
            case BookmarkMatcher.MatcherType.XPath:
                b = _XPathSearchBox;
                goto default;
            default:
                b.Checked = true;
                break;
        }

        if (_replaceInSelection)
        {
            _ReplaceInSelectionBox.Checked = true;
        }
        else
        {
            _ReplaceInAllBox.Checked = true;
        }

        _SearchTextBox.TextChanged += _SearchTextBox_TextChanged;
    }

    private BookmarkMatcher CreateMatcher() =>
        BookmarkMatcher.Create(_SearchTextBox.Text,
            _RegexSearchBox.Checked ? BookmarkMatcher.MatcherType.Regex
            : _XPathSearchBox.Checked ? BookmarkMatcher.MatcherType.XPath
            : BookmarkMatcher.MatcherType.Normal,
            _MatchCaseBox.Checked,
            _FullMatchBox.Checked);

    private void _SearchButton_Click(object sender, EventArgs args)
    {
        if (string.IsNullOrEmpty(_SearchTextBox.Text))
        {
            FormHelper.InfoBox("Please enter the query keyword first.");
            return;
        }

        BookmarkMatcher matcher;
        try
        {
            matcher = CreateMatcher();
        }
        catch (Exception ex)
        {
            FormHelper.ErrorBox("The search expression is wrong: " + ex.Message);
            return;
        }

        _SearchTextBox.AddHistoryItem();
        if (sender == _SearchButton)
        {
            List<BookmarkElement> matches = _controller.View.Bookmark.SearchBookmarks(matcher);
            if (matches.Count > 0)
            {
                _ResultLabel.Text = "Found " + matches.Count + " matching bookmarks.";
                _controller.View.Bookmark.FindForm().Activate();
            }
            else
            {
                _ResultLabel.Text = "No matching bookmarks were found.";
            }
        }
        else
        {
            BookmarkElement m = _controller.View.Bookmark.SearchBookmark(matcher);
            _ResultLabel.Text = m == null ? "The corresponding bookmark was not found." : string.Empty;
        }
    }


    private void _ReplaceButton_Click(object sender, EventArgs e)
    {
        BookmarkMatcher matcher;
        try
        {
            matcher = CreateMatcher();
        }
        catch (Exception ex)
        {
            FormHelper.ErrorBox("The search expression is wrong: " + ex.Message);
            return;
        }

        int i = ReplaceBookmarks(_replaceInSelection, matcher, _ReplaceTextBox.Text);
        _ResultLabel.Text = i > 0 ? "Replaced " + i + " matching bookmarks." : "No bookmarks were replaced.";
        _SearchTextBox.AddHistoryItem();
        _ReplaceTextBox.AddHistoryItem();
    }

    private void _CloseButton_Click(object source, EventArgs args)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void MatchModeChanged(object sender, EventArgs e)
    {
        if (_NormalSearchBox.Checked)
        {
            _matcherType = BookmarkMatcher.MatcherType.Normal;
        }
        else if (_RegexSearchBox.Checked)
        {
            _matcherType = BookmarkMatcher.MatcherType.Regex;
        }
        else if (_XPathSearchBox.Checked)
        {
            _matcherType = BookmarkMatcher.MatcherType.XPath;
        }

        _MatchCaseBox.Enabled = _FullMatchBox.Enabled =
            _ReplaceButton.Enabled = _ReplaceTextBox.Enabled = !_XPathSearchBox.Checked;
    }

    private void ReplaceModeChanged(object sender, EventArgs e) => _replaceInSelection = _ReplaceInSelectionBox.Checked;

    private int ReplaceBookmarks(bool replaceInSelection, BookmarkMatcher matcher, string replacement)
    {
        BookmarkEditorView b = _controller.View.Bookmark;
        if (b.GetItemCount() == 0)
        {
            return 0;
        }

        IEnumerable ol = replaceInSelection
            ? b.SelectedObjects
            : (b.GetModelObject(0) as XmlElement).ParentNode.SelectNodes(".//" + Constants.Bookmark);
        List<XmlNode> si = ol.Cast<XmlNode>().ToList();

        UndoActionGroup undo = new();
        ReplaceTitleTextProcessor p = new(matcher, replacement);
        try
        {
            foreach (XmlNode item in si)
            {
                if (item is not XmlElement x)
                {
                    continue;
                }

                undo.Add(p.Process(x));
            }
        }
        catch (Exception ex)
        {
            FormHelper.ErrorBox("An error occurred while replacing the matching text:" + ex.Message);
        }

        if (undo.Count <= 0)
        {
            return 0;
        }

        _controller.Model.Undo.AddUndo(p.Name, undo);
        si.Clear();
        si.AddRange(undo.AffectedElements);
        b.RefreshObjects(si);
        return si.Count;
    }
}
