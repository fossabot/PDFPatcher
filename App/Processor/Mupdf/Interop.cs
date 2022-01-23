using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace MuPdfSharp;

internal struct NativeObject<T> where T : struct
{
    internal IntPtr Ptr;
    internal T Data;

    public NativeObject(IntPtr ptr)
    {
        Ptr = ptr;
        Data = ptr.MarshalAs<T>();
    }
}

internal static class Interop
{
    internal static T MarshalAs<T>(this IntPtr ptr) where T : struct => (T)Marshal.PtrToStructure(ptr, typeof(T));

    internal static bool IsValid(this SafeHandle handle) =>
        handle != null && (handle.IsInvalid || handle.IsClosed == false);

    internal static void DisposeHandle(this SafeHandle handle)
    {
        if (handle != null && handle.IsValid())
        {
            handle.Dispose();
            //handle.SetHandleAsInvalid ();
        }
    }

    /// <summary>
    ///     Convert the list pointer to <see cref="IEnumerable{T}" />
    /// </summary>
    /// <typeparam name="T">The type of linked list.</typeparam>
    /// <param name="ptr">The pointer that needs to be converted.</param>
    /// <returns><see cref="IEnumerable{T}" /> instance.</returns>
    internal static IEnumerable<NativeObject<T>> EnumerateLinkedList<T>(this IntPtr ptr)
        where T : struct, ILinkedList => NativeLinkedList<T>.EnumerateLinkedList(ptr);

    internal interface ILinkedList
    {
        IntPtr Next { get; }
    }

    private static class NativeLinkedList<T> where T : struct, ILinkedList
    {
        internal static IEnumerable<NativeObject<T>> EnumerateLinkedList(IntPtr pointer) =>
            new LinkedListEnumerable<T>(pointer);

        private sealed class LinkedListEnumerable<Node> : IEnumerable<NativeObject<Node>>
            where Node : struct, ILinkedList
        {
            private readonly IntPtr _pointer;

            public LinkedListEnumerable(IntPtr pointer) => _pointer = pointer;

            IEnumerator<NativeObject<Node>> IEnumerable<NativeObject<Node>>.GetEnumerator() =>
                new LinkedListEnumerator<Node>(_pointer);

            IEnumerator IEnumerable.GetEnumerator() => new LinkedListEnumerator<Node>(_pointer);
        }

        private sealed class LinkedListEnumerator<Node> : IEnumerator<NativeObject<Node>>
            where Node : struct, ILinkedList
        {
            private readonly IntPtr _start;
            private IntPtr _current;
            private NativeObject<Node> _Node;

            public LinkedListEnumerator(IntPtr pointer) => _current = _start = pointer;

            #region IEnumerator<NativeObject<Node>>

            NativeObject<Node> IEnumerator<NativeObject<Node>>.Current => _Node;

            void IDisposable.Dispose()
            {
            }

            object IEnumerator.Current => _Node;

            bool IEnumerator.MoveNext()
            {
                if (_current == IntPtr.Zero)
                {
                    return false;
                }

                _Node = new NativeObject<Node>(_current);
                _current = _Node.Data.Next;
                return true;
            }

            void IEnumerator.Reset() => _current = _start;

            #endregion
        }
    }
}
