using System;
using System.Runtime.InteropServices;

namespace PDFPatcher.Common;

internal static class PInvokeHelper
{
    /// <summary>
    ///     Convert the data corresponding to the <paramref name="ptr" /> pointer to a <typeparamref name="T" /> type instance.
    /// </summary>
    /// <typeparam name="T">Outgoing type instance. </typeparam>
    /// <param name="ptr">Pointer to the data. </param>
    /// <returns> The managed instance encapsulated by the pointer. </returns>
    internal static T Unwrap<T>(this IntPtr ptr) where T : class, new()
    {
        T t = new();
        Marshal.PtrToStructure(ptr, t);
        return t;
    }
}
