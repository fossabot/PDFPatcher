using System;
using System.Xml;
using PDFPatcher.Common;
using A = PDFPatcher.Constants.ActionType;
using D = PDFPatcher.Constants.DestinationAttributes;

namespace PDFPatcher.Processor;

internal sealed class ForceInternalLinkProcessor : IPdfInfoXmlProcessor
{
    #region IInfoDocProcessor member

    public string Name => "Set click target to page";

    public IUndoAction Process(XmlElement item)
    {
        if (!item.HasAttribute(D.Action) ||
            !item.GetAttribute(D.Path).EndsWith(".pdf", StringComparison.InvariantCultureIgnoreCase) ||
            !ValueHelper.IsInCollection(item.GetAttribute(D.Action), A.GotoR, A.Launch, A.Uri))
        {
            return null;
        }

        UndoActionGroup undo = new();
        undo.Add(UndoAttributeAction.GetUndoAction(item, D.Action, A.Goto));
        if (item.HasAttribute(D.Page) == false
            && item.HasAttribute(D.Named) == false
            && item.HasAttribute(D.NamedN) == false
           )
        {
            undo.Add(UndoAttributeAction.GetUndoAction(item, D.Page, "1"));
        }

        return undo;
    }

    #endregion
}
