﻿using System;
using System.Collections.Generic;
using iTextSharp.text.pdf;
using PDFPatcher.Model;

namespace PDFPatcher.Processor;

/// <summary>
///     A document pool used to merge the PDF document.
/// </summary>
internal sealed class DocumentSink
{
    private readonly Dictionary<string, PdfReaderReference> _sink = new(StringComparer.OrdinalIgnoreCase);

    public DocumentSink(IEnumerable<SourceItem> items, bool useSink) => EvaluateWorkload(items, useSink);

    public int Workload { get; private set; }
    public bool HasDuplicateFiles { get; private set; }

    public PdfReader GetPdfReader(string path)
    {
        if (!_sink.TryGetValue(path, out PdfReaderReference rr))
        {
            return null;
        }

        return rr.Reader ?? (rr.Reader = PdfHelper.OpenPdfFile(path, AppContext.LoadPartialPdfFile, false));
    }

    public int DecrementReference(string path)
    {
        if (!_sink.TryGetValue(path, out PdfReaderReference r))
        {
            return 0;
        }

        int c = --r.Reference;
        if (c == 0)
        {
            _sink.Remove(path);
        }

        return c;
    }

    private void EvaluateWorkload(IEnumerable<SourceItem> items, bool useSink)
    {
        foreach (SourceItem item in items)
        {
            switch (item.Type)
            {
                case SourceItem.ItemType.Empty:
                    break;
                case SourceItem.ItemType.Pdf:
                    SourceItem.Pdf p = item as SourceItem.Pdf;
                    Workload += PageRangeCollection.Parse(p.PageRanges, 1, p.PageCount, true).TotalPages;
                    if (useSink)
                    {
                        if (_sink.TryGetValue(item.FilePath.ToString(), out PdfReaderReference r))
                        {
                            r.Reference++;
                            HasDuplicateFiles = true;
                            break;
                        }

                        _sink.Add(item.FilePath.ToString(), new PdfReaderReference());
                    }

                    Workload += item.FileSize;
                    break;
                case SourceItem.ItemType.Image:
                    Workload += item.FileSize;
                    break;
                case SourceItem.ItemType.Folder:
                    break;
            }

            if (item.HasSubItems)
            {
                EvaluateWorkload(item.Items, useSink);
            }
        }
    }

    private sealed class PdfReaderReference
    {
        internal PdfReader Reader;
        internal int Reference = 1;
    }
}
