﻿using System.Xml;
using PDFPatcher.Common;

namespace PDFPatcher.Processor;

internal sealed class ChangeZoomRateProcessor : IPdfInfoXmlProcessor
{
    public ChangeZoomRateProcessor(object zoomRate)
    {
        switch (zoomRate)
        {
            case string or null:
                ZoomMethod = zoomRate as string;
                ZoomRate = -1;
                break;
            case float rate:
                ZoomRate = rate;
                break;
        }
    }

    public string ZoomMethod { get; }
    public float ZoomRate { get; }

    #region IInfoDocProcessor member

    public string Name => "Change zoom ratio";

    public IUndoAction Process(XmlElement item)
    {
        UndoActionGroup undo;
        if (ZoomRate >= 0)
        {
            undo = new UndoActionGroup();
            undo.SetAttribute(item, Constants.DestinationAttributes.View, Constants.DestinationAttributes.ViewType.XYZ);
            undo.SetAttribute(item, Constants.Coordinates.ScaleFactor, ZoomRate.ToText());
        }
        else if (string.IsNullOrEmpty(ZoomMethod))
        {
            undo = new UndoActionGroup();
            undo.SetAttribute(item, Constants.DestinationAttributes.View, Constants.DestinationAttributes.ViewType.XYZ);
            undo.RemoveAttribute(item, Constants.Coordinates.ScaleFactor);
        }
        else
        {
            return UndoAttributeAction.GetUndoAction(item, Constants.DestinationAttributes.View, ZoomMethod);
        }

        return undo;
    }

    #endregion
}
