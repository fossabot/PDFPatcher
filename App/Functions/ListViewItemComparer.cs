using System.Collections;
using System.Windows.Forms;
using PDFPatcher.Common;

namespace PDFPatcher;

internal sealed class ListViewItemComparer : IComparer
{
    public ListViewItemComparer(int column) => Col = column;

    public ListViewItemComparer(int column, bool useSmartSort)
    {
        Col = column;
        UseSmartSort = useSmartSort;
        SortOrder = SortOrder.Ascending;
    }

    public ListViewItemComparer(int column, bool useSmartSort, SortOrder sortOrder)
    {
        Col = column;
        UseSmartSort = useSmartSort;
        SortOrder = sortOrder;
    }

    /// <summary>Gets or specifies the value of the sequence of sequences.</summary>
    public int Col { get; }

    /// <summary>Get or specifies whether to use intelligent sort.</summary>
    public bool UseSmartSort { get; }

    /// <summary>Get or specify how lists are sorted.</summary>
    public SortOrder SortOrder { get; }

    #region IComparer member

    int IComparer.Compare(object x, object y)
    {
        if (SortOrder == SortOrder.None)
        {
            return 0;
        }

        string a = ((ListViewItem)x).SubItems[Col].Text;
        string b = ((ListViewItem)y).SubItems[Col].Text;
        int r = UseSmartSort ? FileHelper.NumericAwareComparePath(a, b) : string.CompareOrdinal(a, b);
        return SortOrder == SortOrder.Ascending ? r : -r;
    }

    #endregion
}
