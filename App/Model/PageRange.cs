using System.Collections;
using System.Collections.Generic;
using PDFPatcher.Common;

namespace PDFPatcher.Model;

internal struct PageRange : IEnumerable<int>
{
    public int StartValue, EndValue;

    public PageRange(int startValue, int endValue)
    {
        StartValue = startValue;
        EndValue = endValue;
    }

    public bool Contains(int value) =>
        value >= StartValue && value <= EndValue
        || value >= EndValue && value <= StartValue;

    public override string ToString() =>
        StartValue != EndValue
            ? string.Concat(StartValue.ToText(), '-', EndValue.ToText())
            : StartValue.ToText();

    /// <summary>
    ///     The number included in the return range.
    /// </summary>
    public int Count => (EndValue > StartValue ? EndValue - StartValue : StartValue - EndValue) + 1;

    #region IEnumerable<int> member

    IEnumerator<int> IEnumerable<int>.GetEnumerator() => new PageRangeEnumerator(StartValue, EndValue);

    #endregion

    #region IEnumerable member

    IEnumerator IEnumerable.GetEnumerator() => new PageRangeEnumerator(StartValue, EndValue);

    #endregion

    private sealed class PageRangeEnumerator : IEnumerator<int>
    {
        private readonly bool _isIncremental;
        private readonly int _start, _end;

        public PageRangeEnumerator(int start, int end)
        {
            _start = start;
            _isIncremental = start < end;
            _end = end;
            Current = _isIncremental ? start - 1 : start + 1;
        }

        #region IEnumerator<int> member

        public int Current { get; private set; }

        #endregion

        #region IDisposable member

        public void Dispose()
        {
        }

        #endregion

        #region IEnumerator member

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (_isIncremental && Current < _end)
            {
                Current++;
                return true;
            }

            if (_isIncremental || Current <= _end)
            {
                return false;
            }

            Current--;
            return true;
        }

        public void Reset() => Current = _start < _end ? _start : _end;

        #endregion
    }
}
