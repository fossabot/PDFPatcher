﻿using System;
using System.Xml;

namespace PDFPatcher.Processor;

internal sealed class ReplaceTitleTextProcessor : IPdfInfoXmlProcessor
{
    private static readonly BookmarkMatcher.SimpleReplacer __replacer = new();

    private readonly BookmarkMatcher _matcher;
    private readonly string _replacement;

    public ReplaceTitleTextProcessor(string replacement)
    {
        _matcher = __replacer;
        _replacement = replacement;
    }

    public ReplaceTitleTextProcessor(BookmarkMatcher matcher, string replacement)
    {
        _matcher = matcher ?? throw new ArgumentNullException(nameof(matcher));
        _replacement = replacement;
    }

    #region IInfoDocProcessor member

    public string Name => string.Concat("Replace text with \"", _replacement, "\"");

    public IUndoAction Process(XmlElement item)
    {
        XmlAttribute a = item.GetAttributeNode(Constants.BookmarkAttributes.Title);
        return a == null ? null : _matcher.Replace(item, _replacement);
    }

    #endregion
}
