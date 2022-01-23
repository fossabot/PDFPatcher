using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace MuPdfSharp;

internal sealed class MuStream : IDisposable
{
    private const int __CompressionBomb = 100 << 20;

    internal MuStream(ICollection<byte> data)
    {
        ContextHandle ctx = ContextHandle.Create();
        _knownDataLength = data.Count;
        _data = GCHandle.Alloc(data, GCHandleType.Pinned);
        _stream = new StreamHandle(ctx, NativeMethods.OpenMemory(ctx, _data.AddrOfPinnedObject(), _knownDataLength));
        _context = ctx;
    }

    internal MuStream(ContextHandle ctx, string fileName)
    {
        _stream = new StreamHandle(ctx, fileName);
        _knownDataLength = -1;
        _sharedContext = true;
    }

    private MuStream(ContextHandle ctx, StreamHandle stream)
    {
        _context = ctx;
        _stream = stream;
        NativeMethods.Keep(ctx, stream);
        _sharedContext = true;
    }

    /// <summary>
    ///     Read <paramref name="length" /> bytes into buffer array <see cref="buffer" />. (may throw exception)
    /// </summary>
    /// <param name="buffer">The array where the read data is placed. </param>
    /// <param name="length">Length of data to read. </param>
    /// <returns> The actual read length. </returns>
    public int Read(byte[] buffer, int length) => NativeMethods.Read(_context, _stream, buffer, length);

    /// <summary>
    ///     Read all content to the byte array. (May throw an exception)
    /// </summary>
    /// <returns>Contains an array of all content in the stream.</returns>
    public byte[] ReadAll(int initialSize)
    {
        if (_knownDataLength > 0)
        {
            byte[] b = new byte[_knownDataLength];
            NativeMethods.Read(_context, _stream, b, _knownDataLength);
            return b;
        }
        else
        {
            byte[] b = new byte[initialSize];
            using MemoryStream ms = new(initialSize);
            using BinaryWriter mw = new(ms);
            int l;
            while ((l = NativeMethods.Read(_context, _stream, b, initialSize)) > 0)
            {
                mw.Write(b, 0, l);
                if (ms.Length >= __CompressionBomb && ms.Length / 200 > initialSize)
                {
                    throw new IOException("Compression bomb detected.");
                }
            }

            ms.Flush();
            return ms.ToArray();
        }
    }

    /// <summary>
    ///     Jump to the specified location of the stream.
    /// </summary>
    /// <param name="offset">Offset position.</param>
    /// <param name="origin">Jump mode.</param>
    public void Seek(int offset, SeekOrigin origin) =>
        NativeMethods.Seek(_context, _stream, offset,
            origin switch
            {
                SeekOrigin.Begin => 0,
                SeekOrigin.Current => 1,
                _ => 2
            });

    /// <summary>
    ///     The current flow is decompressed as an image compressed by CCITT Fax.
    /// </summary>
    /// <param name="width">Image width.</param>
    /// <param name="height">Image height.</param>
    /// <param name="k"></param>
    /// <param name="endOfLine"></param>
    /// <param name="encodedByteAlign"></param>
    /// <param name="endOfBlock"></param>
    /// <param name="blackIs1"></param>
    /// <returns>Unzip the image data.</returns>
    public MuStream DecodeTiffFax(int width, int height, int k, bool endOfLine, bool encodedByteAlign, bool endOfBlock,
        bool blackIs1) =>
        new(
            _context,
            new StreamHandle(_context,
                NativeMethods.DecodeCcittFax(_context, _stream, k, endOfLine ? 1 : 0, encodedByteAlign ? 1 : 0, width,
                    height, endOfBlock ? 1 : 0, blackIs1 ? 1 : 0))
        );

    #region Non-managed resource member

    private readonly StreamHandle _stream;
    private readonly ContextHandle _context;
    private GCHandle _data;

    #endregion

    #region Managed resource

    private readonly int _knownDataLength;
    private readonly bool _sharedContext;

    /// <summary>Get or set the cursor position.</summary>
    public int Position
    {
        get => NativeMethods.GetPosition(_context, _stream);
        set => Seek(value, SeekOrigin.Begin);
    }

    #endregion

    #region Implement the properties and methods of iDisposable interface

    private bool disposed;

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this); // Inhibitory destructive function
    }

    /// <summary>Release the resources occupied by MuPdfPAGE.</summary>
    /// <param name="disposing">Whether to manually release the managed resource.</param>
    private void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                #region Release managed resources

                //_components.Dispose ();

                #endregion
            }

            #region Release non-managed resources

            // Note that this is not a thread safe
            if (_stream.IsValid())
            {
                _stream.Dispose();
            }

            if (_sharedContext == false && _context.IsValid())
            {
                _context.Dispose();
            }

            if (_data.IsAllocated)
            {
                _data.Free();
            }

            #endregion
        }

        disposed = true;
    }

    // The destructor is only called when the Dispose method is not called.
    // Don't provide a destructor in the derived class
    ~MuStream() => Dispose(false);

    #endregion
}
