using System.Xml;

namespace PDFPatcher.Processor;

internal sealed class LevelDownProcessor : IPdfInfoXmlProcessor
{
    #region IInfoDocProcessor member

    public string Name => "Set bookmark as a sub-bookmark";

    public IUndoAction Process(XmlElement item)
    {
        if (item == item.ParentNode.FirstChild)
        {
            return null;
        }

        UndoActionGroup undo = new();
        XmlNode n = item.SelectSingleNode("preceding-sibling::" + Constants.Bookmark + "[1]");
        if (n == null)
        {
            return null;
        }

        undo.Add(new AddElementAction(item));
        n.AppendChild(item);
        undo.Add(new RemoveElementAction(item));
        return undo;
    }

    #endregion
}
