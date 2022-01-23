using System.Xml;

namespace PDFPatcher.Processor;

internal sealed class BookmarkOpenStatusProcessor : IPdfInfoXmlProcessor<bool>
{
    public BookmarkOpenStatusProcessor()
    {
    }

    public BookmarkOpenStatusProcessor(bool open) => Parameter = open;

    /// <summary>
    ///     Indicates whether the processor should open a bookmark.
    /// </summary>
    public bool Parameter { get; set; }

    #region IInfoDocProcessor member

    public string Name => "Set bookmark status to" + (Parameter ? "Open" : "Close");

    public IUndoAction Process(XmlElement item)
    {
        if (item.SelectSingleNode(Constants.Bookmark) == null)
        {
            return null;
        }

        string v = item.HasChildNodes && item.SelectSingleNode(Constants.Bookmark) != null && Parameter
            ? Constants.Boolean.True
            : null;
        return UndoAttributeAction.GetUndoAction(item, Constants.BookmarkAttributes.Open, v);
    }

    #endregion
}
