using System.Collections;
using System.Collections.Generic;

namespace MuPdfSharp;

public sealed class PageLabelCollection : ICollection<PageLabel>
{
    private readonly List<PageLabel> _labels = new();

    internal PageLabelCollection(MuDocument document)
    {
        List<PageLabel> pl = new();
        MuPdfArray l = document.Trailer.Locate("Root/PageLabels/Nums").AsArray();
        if (l.Kind == MuPdfObjectKind.PDF_ARRAY)
        {
            for (int i = 0; i < l.Count; i++)
            {
                int n = l[i].IntegerValue;
                MuPdfDictionary d = l[++i].AsDictionary();
                int sp = d["St"].IntegerValue;
                string p = d["P"].StringValue;
                string s = d["S"].NameValue;
                pl.Add(new PageLabel(n, sp, p, s.Length == 0 ? PageLabelStyle.Digit : (PageLabelStyle)(byte)s[0]));
            }

            pl.Sort();
        }

        _labels = pl;
    }

    public PageLabel this[int index] => _labels[index];

    /// <summary>
    ///     Add a page number tab.If there is a page tab of the same page number in the collection, the old tag is deleted
    ///     first, then add a new page number tab.
    /// </summary>
    /// <param name="label">You need to add the page number tab.</param>
    public void Add(PageLabel label)
    {
        Remove(label);
        _labels.Add(label);
        _labels.Sort();
    }

    public void Clear() => _labels.Clear();

    /// <summary>
    ///     Returns whether the collection contains page number tags with the same starting page number as
    ///     <paramref name="item" />.
    /// </summary>
    /// <param name="item">The page number label that needs to check the starting page number. </param>
    /// <returns>If the page number label contains the same page number, return true, otherwise return false. </returns>
    public bool Contains(PageLabel item)
    {
        for (int i = _labels.Count - 1; i >= 0; i--)
        {
            if (_labels[i].FromPageNumber == item.FromPageNumber)
            {
                return true;
            }
        }

        return false;
    }

    public void CopyTo(PageLabel[] array, int arrayIndex) => _labels.CopyTo(array, arrayIndex);

    public int Count => _labels.Count;

    public bool IsReadOnly => false;

    /// <summary>
    ///     Removes page number tags in the collection that have the same starting page number as <paramref name="item" />.
    /// </summary>
    /// <param name="item">The page number label that needs to be deleted. </param>
    /// <returns>If the page number label contains the same page number, return true, otherwise return false. </returns>
    public bool Remove(PageLabel item)
    {
        for (int i = _labels.Count - 1; i >= 0; i--)
        {
            if (_labels[i].FromPageNumber != item.FromPageNumber)
            {
                continue;
            }

            _labels.RemoveAt(i);
            return true;
        }

        return false;
    }

    public IEnumerator<PageLabel> GetEnumerator() => _labels.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _labels.GetEnumerator();

    /// <summary>
    ///     According to the incoming page number, return the page number generated after formatting the current page number
    ///     label set.
    /// </summary>
    /// <param name="pageNumber">Absolute page number. </param>
    /// <returns>Formatted page number text. </returns>
    public string Format(int pageNumber)
    {
        int l = _labels.Count;
        if (l == 0)
        {
            return string.Empty;
        }

        for (int i = l - 1; i >= 0; i--)
        {
            PageLabel p = _labels[i];
            if (pageNumber > p.FromPageNumber)
            {
                return p.Format(pageNumber);
            }
        }

        return string.Empty;
    }

    public PageLabel Find(int pageNumber)
    {
        --pageNumber;
        for (int i = _labels.Count - 1; i >= 0; i--)
        {
            if (_labels[i].FromPageNumber == pageNumber)
            {
                return _labels[i];
            }
        }

        return PageLabel.Empty;
    }
}
