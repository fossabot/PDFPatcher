﻿using System.Xml;
using PDFPatcher.Common;

namespace PDFPatcher.Processor;

internal sealed class ChangeZoomRateProcessor : IPdfInfoXmlProcessor
{
	public ChangeZoomRateProcessor(object zoomRate) {
		if (zoomRate is string || zoomRate == null) {
			ZoomMethod = zoomRate as string;
			ZoomRate = -1;
		}
		else if (zoomRate is float) {
			ZoomRate = (float)zoomRate;
		}
	}

	public string ZoomMethod { get; }
	public float ZoomRate { get; }

	#region IInfoDocProcessor 成员

	public string Name => "更改缩放比例";

	public IUndoAction Process(XmlElement item) {
		UndoActionGroup undo;
		if (ZoomRate >= 0) {
			undo = new UndoActionGroup();
			undo.SetAttribute(item, Constants.DestinationAttributes.View, Constants.DestinationAttributes.ViewType.XYZ);
			undo.SetAttribute(item, Constants.Coordinates.ScaleFactor, ZoomRate.ToText());
		}
		else if (string.IsNullOrEmpty(ZoomMethod)) {
			undo = new UndoActionGroup();
			undo.SetAttribute(item, Constants.DestinationAttributes.View, Constants.DestinationAttributes.ViewType.XYZ);
			undo.RemoveAttribute(item, Constants.Coordinates.ScaleFactor);
		}
		else {
			return UndoAttributeAction.GetUndoAction(item, Constants.DestinationAttributes.View, ZoomMethod);
		}

		return undo;
	}

	#endregion
}