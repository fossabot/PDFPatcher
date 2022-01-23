using System.Windows.Forms;
using PDFPatcher.Common;
using PDFPatcher.Model;
using PDFPatcher.Processor;

namespace PDFPatcher.Functions.Editor;

internal sealed class QuickSelectCommand : IEditorCommand
{
    private const string __N = "[0-9０-９一二三四五六七八九十〇]+";
    private const string __S = @"\s*";
    private const string __D = __S + @"[\.． ]";
    private const string __ND = __N + __D;
    private const string __NN = @"(?:\s*[^0-9０-９\.．一二三四五六七八九十〇]|$)";

    private static readonly MatchPattern[] __commands =
    {
        new("^" + __S + "Part" + __S + __N + __S + "(?:part|part)|^" + __S + "part" + __S + "[0-9]", false, false, true)
        {
            Name = "\"Part N\""
        },
        new("^" + __S + "Number" + __S + __N + __S + "[Volume]|^" + __S + "(?:volume|vol)" + __S + "[0-9]",
            false, false,
            true) {Name = "\"Title N\" or \"Volume N\""},
        new("^" + __S + "chapter" + __S + __N + __S + "chapter|^" + __S + "chapter" + __S + "[0-9]", false, false, true)
        {
            Name = "\"Chapter N\""
        },
        new("^" + __S + "section" + __S + __N + __S + "section|^" + __S + "section" + __S + "[0-9]", false, false, true)
        {
            Name = "\"Section N\""
        },
        new("^" + __S + __ND + "?" + __NN, true, false, true) {Name = "\"N.\" mode"},
        new("^" + __S + __ND + __ND + "?" + __NN, true, false, true) {Name = "\"N.N\" mode"},
        new("^" + __S + __ND + __ND + __ND + "?" + __NN, true, false, true) {Name = "\"N.N.N\" mode"},
        new("^" + __S + __ND + __ND + __ND + __ND + "?" + __NN, true, false, true) {Name = "\"N.N.N.N\" mode"},
        new("^" + __S + __ND + __ND + __ND + __ND + __ND + "?" + __NN, true, false, true) {Name = "\"N.N.N.N.N\" mode"}
    };

    private readonly BookmarkMatcher _command;

    public QuickSelectCommand(MatchPattern command) =>
        _command = BookmarkMatcher.Create(command.Text, BookmarkMatcher.MatcherType.Regex, command.MatchCase,
            command.FullMatch);

    public void Process(Controller controller, params string[] parameters) =>
        controller.View.Bookmark.SearchBookmarks(_command);

    internal static void RegisterCommands(CommandRegistry<Controller> registry)
    {
        foreach (MatchPattern item in __commands)
        {
            registry.Register(new QuickSelectCommand(item), item.Name);
        }
    }

    internal static void RegisterMenuItems(ToolStripItemCollection container)
    {
        foreach (MatchPattern item in __commands)
        {
            container.Add(new ToolStripMenuItem(item.Name) { Name = item.Name });
        }
    }
}
