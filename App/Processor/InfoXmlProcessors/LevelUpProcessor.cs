﻿using System.Xml;

namespace PDFPatcher.Processor;

internal sealed class LevelUpProcessor : IPdfInfoXmlProcessor
{
    #region IInfoDocProcessor member

    public string Name => "Set bookmarks for parent signs";

    public IUndoAction Process(XmlElement item)
    {
        if (item.ParentNode.Name != Constants.Bookmark)
        {
            return null;
        }

        UndoActionGroup undo = new();
        XmlNodeList fs = item.SelectNodes("following-sibling::" + Constants.Bookmark);
        foreach (XmlElement f in fs)
        {
            undo.Add(new AddElementAction(f));
            item.AppendChild(f);
            undo.Add(new RemoveElementAction(f));
        }

        undo.Add(new AddElementAction(item));
        item.ParentNode.ParentNode.InsertAfter(item, item.ParentNode);
        undo.Add(new RemoveElementAction(item));
        return undo;
    }

    #endregion
}
