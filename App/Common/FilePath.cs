using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using NameList = System.Collections.Generic.List<string>;
using SysDirectory = System.IO.Directory;

namespace PDFPatcher.Common;

/// <summary>
///     Represents the structure of the file path. This structure can be implicitly converted to a string,
///     <see cref="FileInfo" />、<see cref="DirectoryInfo" /> and <see cref="Uri" />.
/// </summary>
public readonly struct FilePath : IEquatable<FilePath>
{
    internal static readonly char[] InvalidFileNameChars = Path.GetInvalidFileNameChars();
    internal static readonly char[] InvalidPathChars = Path.GetInvalidPathChars();
    internal static readonly Func<string, string, bool> __PathComparer = StringComparer.OrdinalIgnoreCase.Equals;

    /// <summary>A wildcard that matches any file.</summary>
    public const string Wildcard = "*";

    /// <summary>A wildcard that matches the current directory, the recipient library, and any file.</summary>
    public const string RecursiveWildcard = "**";

    /// <summary>Indicates that there is no path to any content.</summary>
    public static readonly FilePath Empty = new(string.Empty, false);

    /// <summary>Get the directory path where the application is located.</summary>
    public static readonly FilePath AppRoot = ((FilePath)AppDomain.CurrentDomain.BaseDirectory).AppendPathSeparator();

    private static readonly char[] __PathSeparators = { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar };
    private readonly string _value;

    /// <summary>
    ///     Introducing a string of file path, creating a new <see cref="FilePath" /> instance.When you create an
    ///     instance, delete all the preambles and trailing gaps in the incoming string.
    /// </summary>
    /// <param name="path">The string of the file path.</param>
    public FilePath(string path) : this(path, true)
    {
    }

    internal FilePath(string path, bool trim) =>
        _value = string.IsNullOrEmpty(path)
            ? string.Empty
            : trim
                ? path.Trim()
                : path;

    /// <summary>
    ///     Returns the directory section of the current path. If the directory is a relative path, first convert to an
    ///     absolute path based on the directory path where the current program is located.
    /// </summary>
    /// <returns>The directory section of the current path.</returns>
    public FilePath Directory
    {
        get
        {
            const int None = 0, EndWithSep = 1, EndWithLetter = 2;
            string p = AppRoot.Combine(_value)._value;
            int s = None;
            for (int i = p.Length - 1; i >= 0; i--)
            {
                char c = p[i];
                bool d = IsDirectorySeparator(c);
                switch (s)
                {
                    case None:
                        if (d)
                        {
                            s = EndWithSep;
                        }
                        else if (char.IsWhiteSpace(c) == false)
                        {
                            s = EndWithLetter;
                        }

                        continue;
                    case EndWithSep:
                        if (d)
                        {
                            continue;
                        }
                        else if (c == Path.VolumeSeparatorChar)
                        {
                            return Empty;
                        }
                        else
                        {
                            return p.Substring(0, i + 1);
                        }
                    case EndWithLetter:
                        if (d)
                        {
                            return p.Substring(0, i == 2 && p[1] == Path.VolumeSeparatorChar || i == 0 ? i + 1 : i);
                        }
                        else if (c == Path.VolumeSeparatorChar)
                        {
                            return p.Substring(0, i + 1) + Path.DirectorySeparatorChar;
                        }

                        break;
                }
            }

            return Empty;
        }
    }

    /// <summary>Returns whether the current path ends with a directory separator.</summary>
    public bool EndsWithPathSeparator
    {
        get
        {
            if (string.IsNullOrEmpty(_value))
            {
                return false;
            }

            for (int i = _value.Length - 1; i >= 0; i--)
            {
                char c = _value[i];
                if (char.IsWhiteSpace(c))
                {
                    continue;
                }

                return IsDirectorySeparator(c);
            }

            return false;
        }
    }

    /// <summary>Checks if the file corresponding to the current path exists.</summary>
    public bool ExistsFile => File.Exists(ToFullPath()._value);

    /// <summary>Checks if the directory corresponding to the current path exists.</summary>
    public bool ExistsDirectory => SysDirectory.Exists(ToFullPath()._value);

    /// <summary>Gets the file name section of the file path.</summary>
    public string FileName
    {
        get
        {
            if (IsEmpty)
            {
                return string.Empty;
            }

            for (int i = _value.Length - 1; i >= 0; i--)
            {
                char c = _value[i];
                if (IsDirectorySeparator(c) || c == Path.VolumeSeparatorChar)
                {
                    return _value.Substring(++i);
                }
            }

            return _value;
        }
    }

    /// <summary>Gets the file name (not including the extension) section of the file path.</summary>
    public string FileNameWithoutExtension
    {
        get
        {
            if (IsEmpty)
            {
                return string.Empty;
            }

            int l = _value.Length;
            int d = l;
            for (int i = d - 1; i >= 0; i--)
            {
                char c = _value[i];
                if (c == '.')
                {
                    if (d == l)
                    {
                        d = i;
                    }
                }
                else if (IsDirectorySeparator(c) || c == Path.VolumeSeparatorChar)
                {
                    return d != l ? _value.Substring(++i, d - i) : _value.Substring(++i);
                }
            }

            return d != l ? _value.Substring(0, d) : _value;
        }
    }

    /// <summary>Gets the file extension section of the file path.</summary>
    public string FileExtension
    {
        get
        {
            if (IsEmpty)
            {
                return string.Empty;
            }

            int i;
            for (i = _value.Length - 1; i >= 0; i--)
            {
                char c = _value[i];
                if (IsDirectorySeparator(c))
                {
                    i = -1;
                    break;
                }

                if (c == '.')
                {
                    break;
                }
            }

            return i > -1 && i < _value.Length - 1 ? _value.Substring(i) : string.Empty;
        }
    }

    /// <summary>Returns whether the current path is empty.</summary>
    public bool IsEmpty => string.IsNullOrEmpty(_value);

    /// <summary>Returns whether the current file path is valid.</summary>
    public bool IsValidPath => _value?.Trim().Length > 0 && _value.IndexOfAny(InvalidPathChars) == -1;

    /// <summary>Additional <see cref="path.directoryseparatorcha" /> character after the path.</summary>
    /// <returns>The path to "\" characters is attached.</returns>
    public FilePath AppendPathSeparator() =>
        IsEmpty == false && _value[_value.Length - 1] == Path.DirectorySeparatorChar
            ? this
            : (FilePath)(_value + Path.DirectorySeparatorChar);

    /// <summary>Replaces the extension of the file path as a new extension.</summary>
    /// <param name="extension">New extension.</param>
    /// <returns>Replace the path after the extension.</returns>
    public FilePath ChangeExtension(string extension)
    {
        if (IsEmpty)
        {
            return Empty;
        }

        if (extension == null)
        {
            extension = string.Empty;
        }
        else if ((extension = extension.TrimEnd()).Length == 0)
        {
            extension = ".";
        }
        else if (extension[0] != '.')
        {
            extension = "." + extension;
        }

        int i;
        for (i = _value.Length - 1; i >= 0; i--)
        {
            char c = _value[i];
            if (IsDirectorySeparator(c))
            {
                i = -1;
                break;
            }

            if (c == '.')
            {
                break;
            }
        }

        return new FilePath(i >= 0 ? _value.Substring(0, i) + extension : _value + extension, false);
    }

    /// <inheritdoc cref="Combine(FilePath, bool)" />
    public FilePath Combine(FilePath path) => Combine(path, false);

    /// <summary>combines two file paths.If <paramref name="path" /> is an absolute path, the path is returned.</summary>
    /// <param name="path">subpath.</param>
    /// <param name="rootAsRelative">
    ///     For the case of <see cref="Path.DirectorySeparatorChar" /> in <see cref="Path.DirectorySeparatorChar" />
    ///     <see language="true" /> is considered to be based on the current directory; otherwise <paramref name="path" /> will
    ///     be deemed from the root directory, return <paramref name="path" /".
    /// 
    /// </param>
    /// <returns>After the merged path.</returns>
    public FilePath Combine(FilePath path, bool rootAsRelative)
    {
        if (path.IsEmpty)
        {
            return _value != null ? this : Empty;
        }

        if (IsEmpty)
        {
            return path._value != null ? path : Empty;
        }

        string p2 = path._value;
        char ps = p2[0];
        bool p2r;
        if ((p2r = IsDirectorySeparator(ps)) &&
            rootAsRelative == false // Note cannot be modified in the order of && parameters, and p2r is useful later.
            || p2.Length > 1 && p2[1] == Path.VolumeSeparatorChar)
        {
            return path;
        }

        string p1 = _value /*.TrimEnd()*/; // _value has been created when Trim is over, no need to Trim
        if (ps == '.')
        {
            // Merge expansion name to the current path
            return p1 + p2;
        }

        return IsDirectorySeparator(p1[p1.Length - 1]) == false && p2r == false
            ? new FilePath(p1 + Path.DirectorySeparatorChar + p2)
            : new FilePath(p1 + p2, false);
    }

    /// <summary>Create a directory for the current file path. If the file path is empty, the path is not created.</summary>
    /// <returns>The path to the creation of the directory.</returns>
    public FilePath CreateDirectory()
    {
        if (IsEmpty)
        {
            return Empty;
        }

        FilePath p = ToFullPath();
        if (SysDirectory.Exists(p) == false)
        {
            SysDirectory.CreateDirectory(p);
        }

        return p;
    }

    /// <summary>Creates the directory you belong to the current file path. If the file path is empty, the path is not created.</summary>
    /// <returns>The path to the creation of the directory.</returns>
    public FilePath CreateContainingDirectory()
    {
        if (IsEmpty)
        {
            return Empty;
        }

        FilePath f = Directory;
        if (SysDirectory.Exists(f._value) == false)
        {
            SysDirectory.CreateDirectory(f._value);
        }

        return f;
    }

    /// <summary>
    ///     Deletes the directory corresponding to the current file path. If the directory pointed to by the path does not
    ///     exist, no operation is performed.
    /// </summary>
    /// <param name="recursive">Whether it is recursively deleted subdirectory file </param>
    public void DeleteDirectory(bool recursive)
    {
        string p = ToFullPath()._value;
        SysDirectory.Delete(p, recursive);
    }

    /// <summary>
    ///     Returns an instance of the additional specified extension. If the current path already contains the specified
    ///     extension, return the current path, otherwise returns an instance of the attached extension.
    /// </summary>
    /// <param name="extension">An additional file extension is required.</param>
    /// <returns>An instance of the specified extension is added.</returns>
    public FilePath EnsureExtension(string extension) =>
        HasExtension(extension) ? this : new FilePath(_value + extension);

    /// <summary>
    ///     Gets the current <see cref="FilePath" /> that meets the matching mode.Convert the current instance to the full
    ///     path before performing the match.The directory where the current user has no right to access will be ignored.
    /// </summary>
    /// <param name="patter">
    ///     Match the mode of the file."\" In the mode is used to split the directory, "**" means the current
    ///     directory and all directories therebet, "*" matches 0 to multiple characters, "?" Matches 1 character.When the mode
    ///     is empty, return all files.
    /// </param>
    /// <returns>Returns all files in matching mode.</returns>
    public FilePath[] GetFiles(string pattern) => GetFiles(pattern, null);

    /// <summary>
    ///     Gets files that meet the matching mode and filter conditions under <see cref="FilePath" />.Convert the current
    ///     instance to the full path before performing the match.The directory where the current user has no right to access
    ///     will be ignored.
    /// </summary>
    /// <param name="patter">
    ///     Match the mode of the file."\" In the mode is used to split the directory, "**" means the current
    ///     directory and all directories therebet, "*" matches 0 to multiple characters, "?" Matches 1 character.
    /// </param>
    /// <param name="filter">For the purpose of filtering the file name.</param>
    /// <returns>Returns all files in matching mode.</returns>
    public FilePath[] GetFiles(string pattern, Predicate<string> filter)
    {
        FilePath f = ToFullPath();
        if (string.IsNullOrEmpty(pattern))
        {
            return SysDirectory.Exists(f._value)
                ? GetFiles(f._value, Wildcard, filter)
                : new FilePath[0];
        }

        string fp;
        bool rp = pattern == RecursiveWildcard;
        string[] p = new FilePath(pattern).GetParts(false);
        int pl = p.Length;
        NameList t = GetDirectories(f._value, p, rp ? 1 : pl - 1);
        if (rp)
        {
            fp = Wildcard;
        }
        else
        {
            if (t.Count == 0)
            {
                return new FilePath[0];
            }

            fp = p[pl - 1];
        }

        List<FilePath> r = new();
        foreach (string item in t)
        {
            try
            {
                r.AddRange(GetFiles(item, fp, filter));
            }
            catch (UnauthorizedAccessException)
            {
                // continue;
            }
        }

        return r.ToArray();
    }

    private static FilePath[] GetFiles(string directory, string filePattern, Predicate<string> filter) =>
        SysDirectory.Exists(directory)
            ? Array.ConvertAll(
                filter != null
                    ? Array.FindAll(SysDirectory.GetFiles(directory, filePattern), filter)
                    : SysDirectory.GetFiles(directory, filePattern)
                , i => (FilePath)i)
            : new FilePath[0];

    private static NameList GetDirectories(string path, IList<string> parts, int partCount)
    {
        NameList t = new(1) { path };
        for (int i = 0; i < partCount; i++)
        {
            NameList r = new(10);
            string pi = parts[i];
            if (pi.Length == 0)
            {
                t = new NameList(1) { Path.GetPathRoot(path) };
                continue;
            }

            switch (pi)
            {
                case "..":
                    {
                        foreach (string n in t.Select(item => IsDirectorySeparator(item[item.Length - 1])
                                     ? Path.GetDirectoryName(item.Substring(0, item.Length - 1))
                                     : Path.GetDirectoryName(item)).Where(n => n != null && r.Contains(n) == false))
                        {
                            r.Add(n);
                        }

                        break;
                    }
                case RecursiveWildcard:
                    {
                        foreach (string item in t)
                        {
                            r.Add(item);
                            GetDirectoriesRecursively(item, ref r);
                        }

                        break;
                    }
                default:
                    {
                        foreach (string item in t)
                        {
                            try
                            {
                                r.AddRange(SysDirectory.GetDirectories(item, pi));
                            }
                            catch (UnauthorizedAccessException)
                            {
                            }
                        }

                        break;
                    }
            }

            t = r;
        }

        return t;
    }

    private static void GetDirectoriesRecursively(string directoryPath, ref NameList results)
    {
        try
        {
            string[] r = SysDirectory.GetDirectories(directoryPath, "*");
            results.AddRange(r);
            foreach (string item in r)
            {
                GetDirectoriesRecursively(item, ref results);
            }
        }
        catch (UnauthorizedAccessException)
        {
        }
    }

    /// <summary>Spread the path into multiple parts by directory, and delete the invalid part.</summary>
    /// <returns>Directory of the directory.</returns>
    public string[] GetParts() => GetParts(true);

    /// <summary>Spread the path into multiple parts by directory.</summary>
    /// <param name="removeinvalidparts">Whether to delete an invalid part.</param>
    /// <returns>Directory of the directory.</returns>
    public string[] GetParts(bool removeInvalidParts)
    {
        if (IsEmpty)
        {
            return new string[0];
        }

        string[] p = _value.Split(__PathSeparators);
        bool r = false;
        int v = 0;
        for (int i = 0; i < p.Length; i++)
        {
            string s = p[i].Trim();
            switch (s.Length)
            {
                case 0:
                    {
                        // Retain the first root directory reference
                        if (i == 0)
                        {
                            r = true;
                            ++v;
                        }

                        continue;
                    }
                case 1 when s[0] == '.':
                    continue;
            }

            if (s == ".." || s.StartsWith("..", StringComparison.Ordinal) && s.TrimEnd('.').Length == 0)
            {
                // The previous level is rooted
                if (r && v == 1)
                {
                    // Delete the root-based directory part
                    if (p[0].Length > 2)
                    {
                        p[0] = p[0].Substring(0, 2);
                    }

                    continue;
                }

                // Keep 0 or last level ".." catalog
                if (v == 0 || p[v - 1] == "..")
                {
                    s = "..";
                    p[v] = s;
                    ++v;
                    continue;
                }

                // Delete the previous level
                --v;
                continue;
            }

            s = s.TrimEnd('.');
            if (removeInvalidParts)
            {
                if (i == 0)
                {
                    if (s.Length > 1)
                    {
                        // Root directory
                        if (s[1] == Path.VolumeSeparatorChar)
                        {
                            if (Array.IndexOf(InvalidFileNameChars, s[0]) != -1
                                || s.IndexOfAny(InvalidFileNameChars, 2) != -1)
                            {
                                continue;
                            }

                            r = true;
                        }
                        else if (s.IndexOfAny(InvalidFileNameChars) != -1)
                        {
                            continue;
                        }
                    }
                }
                else if (s.IndexOfAny(InvalidFileNameChars) != -1)
                {
                    continue;
                }
            }

            p[v] = s;
            ++v;
        }

        if (v < 1)
        {
            return new string[0];
        }

        if (v < p.Length)
        {
            Array.Resize(ref p, v);
        }

        return p;
    }


    /// <summary>Checks if the current path ends with the specified extension (not case sensitive).</summary>
    /// <param name="extension">file extension.</param>
    public bool HasExtension(string extension) =>
        string.IsNullOrEmpty(extension)
        || IsEmpty == false && _value.EndsWith(extension, StringComparison.OrdinalIgnoreCase)
                            && (extension[0] == '.' || _value.Length > extension.Length &&
                                _value[_value.Length - extension.Length - 1] == '.');

    /// <summary>Returns whether the file name is tail with any of the specified extension (not case sensitive).</summary>
    /// <param name="extensions">extension list.</param>
    public bool HasExtension(params string[] extensions)
    {
        string ext = FileExtension;
        if (extensions == null || extensions.Length == 0)
        {
            return true;
        }

        return ext.Length != 0 && extensions.Where(item => !string.IsNullOrEmpty(item)).Any(item =>
            ext.EndsWith(item, StringComparison.OrdinalIgnoreCase) && (item[0] == '.' ||
                                                                       ext.Length > item.Length &&
                                                                       ext[ext.Length - item.Length - 1] == '.'));
    }

    /// <summary>Checks if the current path belongs to the specified path (subdirectory, or next file).</summary>
    /// <param name="containingPath">The upper directory.</param>
    /// <param name="rootAsRelative">
    ///     Whether the current directory will be regarded as the relative path in the case of
    ///     <see cref="Path.DirectorySeparatorChar" />.
    /// </param>
    public bool IsInDirectory(FilePath containingPath, bool rootAsRelative)
    {
        string p = containingPath.ToFullPath()._value;
        string v = ToFullPath()._value;
        return v.StartsWith(p, StringComparison.OrdinalIgnoreCase)
               && (IsDirectorySeparator(p[p.Length - 1]) || v.Length > p.Length && IsDirectorySeparator(v[p.Length]) &&
                   new FilePath(v.Substring(p.Length)).IsSubPath(
                       rootAsRelative));
    }

    /// <summary>
    ///     Returns whether the specified character is <see cref="path.directoryseparetor" /> or
    ///     <see cref="path.altdirectoryseparatorchar" />.
    /// </summary>
    /// <param name="ch">The characters to check.</param>
    private static bool IsDirectorySeparator(char ch) =>
        ch == Path.DirectorySeparatorChar || ch == Path.AltDirectorySeparatorChar;

    /// <summary>Returns whether the current path is a sub-path (not pointing to the current directory).</summary>
    /// <param name="rootAsRelative">
    ///     Whether the directory is treated as a sub-path in the case where
    ///     <see cref="Path.DirectorySeparatorChar" />.
    /// </param>
    public bool IsSubPath(bool rootAsRelative)
    {
        if (string.IsNullOrEmpty(_value))
        {
            return true;
        }

        int i, n;
        if (IsDirectorySeparator(_value[i = 0]))
        {
            // rooted
            if (rootAsRelative)
            {
                if (_value.Length == 1)
                {
                    return true;
                }

                i = 1;
            }
            else
            {
                return false;
            }
        }

        if (_value.Length >= 2 && (_value[1] == Path.VolumeSeparatorChar || _value == ".." || _value.Contains("...")))
        {
            // rooted, or starts with "..", or contains "..."
            return false;
        }

        int d = 0;
        while ((n = _value.IndexOfAny(__PathSeparators, i)) >= 0)
        {
            string p = _value.Substring(i, n - i).Trim();
            if (p.Length == 0 // treat double separators as rooted
                || p == ".." && --d < 0)
            {
                // ".." points to parent folder
                return false;
            }

            if (p.Length != 1 || p[0] != '.')
            {
                // ignore "."
                ++d;
            }

            i = n + 1;
        }

        return n != -1
               || _value.Substring(i).TrimStart() != ".."
               || --d >= 0; // not end with ".."
    }

    private static readonly string __DirectorySeparator = Path.DirectorySeparatorChar.ToString();

    /// <summary>
    ///     Translate the file path to the absolute positioning path and delete the blank in the directory name.At the same
    ///     time, <see cref="path.altdirectoryseparatorchar" /> is converted to
    ///     <see cref="Path.DirectorySeparatorChar" />.
    /// </summary>
    /// <returns>The absolute positioning path of the standard.</returns>
    public FilePath Normalize()
    {
        if (_value.IsNullOrWhiteSpace())
        {
            return AppRoot;
        }

        if (_value.Length == 3 && _value[1] == Path.VolumeSeparatorChar && IsDirectorySeparator(_value[2]))
        {
            return this;
        }

        string[] p = GetParts();
        // fixes "?:\" (where ? is active directory drive letter) becomes active directory
        if (EndsWithPathSeparator && p.Length > 0)
        {
            p[p.Length - 1] += Path.DirectorySeparatorChar;
        }

        return p.Length == 1 && p[0].Length == 3 && p[0][1] == Path.VolumeSeparatorChar
            ? new FilePath(p[0] + Path.DirectorySeparatorChar)
            : new FilePath(Path.GetFullPath(AppRoot.Combine(string.Join(__DirectorySeparator, p))._value));
    }

    /// <summary>Returns <see cref="Stream" /> of the read and write file.</summary>
    /// <inheritdoc cref="OpenFile(FileMode, FileAccess, FileShare, int)" />
    public Stream OpenFile(FileMode mode, FileAccess access, FileShare share) =>
        new FileStream(ToFullPath()._value, mode, access, share);

    /// <summary>Returns <see cref="Stream" /> of the read and write file.</summary>
    /// <param name="mode">Specify file access method.</param>
    /// <param name="access">Specifies the file read and write mode.</param>
    /// <param name="share">Specifies the file access sharing method.</param>
    /// <param name="buffersize">The size of the read and write buffer.</param>
    public Stream OpenFile(FileMode mode, FileAccess access, FileShare share, int bufferSize) =>
        new FileStream(ToFullPath()._value, mode, access, share, bufferSize);

    /// <summary>Create to read files with specified encoding <see cref="StreamReader" /> instance.</summary>
    /// <param name="encoding">Used to read the encoding of the file.UTF-8 encoding is encoded as NULL.</param>
    /// <returns>Read file <see cref="StreamReader" /> instance.</returns>
    public StreamReader OpenTextReader(Encoding encoding) =>
        new(ToFullPath()._value, encoding ?? Encoding.UTF8, true);

    /// <summary>
    ///     Opens the file corresponding to the current path and read all content as byte arrays. If the file does not
    ///     exist, return a zyte array of 0 lengths.This method uses FileStream to read files, open or read files may return an
    ///     exception.
    /// </summary>
    /// <returns>The byte array of files.</returns>
    public byte[] ReadAllBytes() => ReadAllBytes(-1);

    /// <summary>
    ///     Opens the file corresponding to the current path and read all content as byte arrays. If the file does not
    ///     exist, return a zyte array of 0 lengths.This method uses FileStream to read files, open or read files may return an
    ///     exception.
    /// </summary>
    /// <param name="maxBytes">
    ///     Allows the maximum number of bytes to be read.Such a value is not positively integer, then read
    ///     the most <see cref="int.maxvalue" /> by the size of the read file.
    /// </param>
    /// <returns>The byte array of files.</returns>
    public byte[] ReadAllBytes(int maxBytes)
    {
        if (ExistsFile == false)
        {
            return new byte[0];
        }

        using FileStream s = new(ToFullPath()._value, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        if (s.CanRead == false)
        {
            return new byte[0];
        }

        long l = s.Length;
        byte[] r = new byte[maxBytes < 1 || maxBytes > l ? l : maxBytes];
        s.Read(r, 0, r.Length);
        return r;
    }

    /// <summary>replaces the invalid character in the path to <paramref name="substitution" />.</summary>
    /// <param name="substitution">The characters used to replace invalid characters.</param>
    /// <returns>Replace the path of invalid characters.</returns>
    public FilePath SubstituteInvalidChars(char substitution)
    {
        if (IsEmpty)
        {
            return Empty;
        }

        char[] a = _value.ToCharArray();
        bool r = false;
        for (int i = 0; i < a.Length; i++)
        {
            ref char c = ref a[i];
            if (Array.IndexOf(InvalidFileNameChars, c) == -1)
            {
                continue;
            }

            c = substitution;
            r = true;
        }

        return r ? new FilePath(new string(a)) : this;
    }

    /// <summary>
    ///     converts the path to an absolute positioning path.The reference position of the path is <see cref="AppRoot" />
    ///     .Before performing this method, you must ensure that you do not include invalid characters in the path, otherwise
    ///     you will throw an exception.
    /// </summary>
    /// <returns>An example of an absolute positioning path.</returns>
    /// <exception cref="ArgumentException">The path is invalid.</exception>
    public FilePath ToFullPath() => Path.GetFullPath(Path.Combine(AppRoot._value, _value));

    /// <summary>
    ///     <para>
    ///         converts the <see cref="FilePath" /> instance into a full path, and then implicitly converted to the
    ///         <see cref="FileInfo" /> instance.The reference position of the path is <see cref="AppRoot" />.
    ///     </para>
    ///     <note type="note">
    ///         In fact, <see cref="FilePath" /> instance can be implicitly converted to <see cref="FileInfo" />
    ///         instance.
    ///     </note>
    /// </summary>
    /// <returns>Convert the current path to the <see cref="FileInfo" /> instance after the full path.</returns>
    [DebuggerStepThrough]
    public FileInfo ToFileInfo() => this;

    #region Type mapping

    /// <summary>
    ///     Assume the string to <see cref="FilePath" /> instance, deleting all the preambles and trailing blank in
    ///     incoming strings.
    /// </summary>
    /// <param name="path">The path string that needs to be converted.</param>
    /// <returns><see cref="FilePath" /> instance.</returns>
    [DebuggerStepThrough]
    public static implicit operator FilePath(string path) => new(path);

    /// <summary>implicitly converted <see cref="FilePath" /> instance to strings.</summary>
    /// <param name="path">The path to the conversion is required.</param>
    /// <returns>The instance represented by a string.</returns>
    [DebuggerStepThrough]
    public static implicit operator string(FilePath path) => path._value;

    /// <summary>Explicitly converts <see cref="FileInfo" /> to <see cref="FilePath" /> instance.</summary>
    /// <param name="file">The path to the conversion is required.</param>
    [DebuggerStepThrough]
    public static explicit operator FilePath(FileInfo file) =>
        file == null ? Empty : new FilePath(file.FullName, false);

    /// <summary>
    ///     convert the <see cref="FilePath" /> instance to a full path, and then implicitly converted to
    ///     <see cref="FileInfo" /> instance.The reference position of the path is <see cref="AppRoot" />.
    /// </summary>
    /// <param name="path">The path to the conversion is required.</param>
    /// <returns>Convert the current path to the <see cref="FileInfo" /> instance after the full path.</returns>
    /// <seealso cref="ToFullPath" />
    [DebuggerStepThrough]
    public static implicit operator FileInfo(FilePath path) => new(path.ToFullPath()._value);

    /// <summary>Explicitly converts <see cref="DirectoryInfo" /> to the <see cref="FilePath" /> instance.</summary>
    /// <param name="Directory">The path to the conversion is required.</param>
    [DebuggerStepThrough]
    public static explicit operator FilePath(DirectoryInfo directory) =>
        directory == null ? Empty : new FilePath(directory.FullName, false);

    /// <summary>
    ///     convert the <see cref="FilePath" /> instance to a full path, and then implicitly converted to
    ///     <see cref="DirectoryInfo" /> instance.The reference position of the path is <see cref="AppRoot" />.
    /// </summary>
    /// <param name="path">The path to the conversion is required.</param>
    /// <returns>converts the current path to the <see cref="DirectoryInfo" /> instance after the full path.</returns>
    /// <seealso cref="ToFullPath" />
    [DebuggerStepThrough]
    public static implicit operator DirectoryInfo(FilePath path) => new(path.ToFullPath()._value);

    /// <summary>implicitly converted <see cref="FilePath" /> instance Implicit to <see cref="Uri" /> instance.</summary>
    /// <param name="path">The path to the conversion is required.</param>
    [DebuggerStepThrough]
    public static implicit operator Uri(FilePath path) => new(path._value);

    #endregion

    #region IEquatable<FilePath> Implement

    /// <summary>Compares whether the two file paths are the same.</summary>
    /// <param name="path1">The first path that needs to be compared.</param>
    /// <param name="path2">The second path that needs to be compared.</param>
    /// <returns>Returns True.</returns>
    [DebuggerStepThrough]
    public static bool operator ==(FilePath path1, FilePath path2) => path1.Equals(path2);

    /// <summary>Compares whether the two file paths are different.</summary>
    /// <param name="path1">The first path that needs to be compared.</param>
    /// <param name="path2">The second path that needs to be compared.</param>
    /// <returns>Non-identical time, return true.</returns>
    [DebuggerStepThrough]
    public static bool operator !=(FilePath path1, FilePath path2) => !path1.Equals(path2);

    /// <summary>Indicates if the current file path is equal to another file path of the same type.</summary>
    /// <param name="other">Objects compared to this object.</param>
    /// <returns>
    ///     If the current object is equal to <paramref name="other" /> parameter, it is <see langword="true" />;
    ///     otherwise, for <see langword="false" />.
    /// </returns>
    public bool Equals(FilePath other) =>
        __PathComparer(_value, other._value)
        || __PathComparer(
            Path.Combine(AppRoot._value, _value ?? string.Empty),
            Path.Combine(AppRoot._value, other._value ?? string.Empty));

    /// <summary>Determines if the current file path is equal to another instance.</summary>
    /// <param name="obj">An object that needs to be compared with the current instance.</param>
    /// <returns>Returns True when two file paths are equal.</returns>
    [DebuggerStepThrough]
    public override bool Equals(object obj) => obj is FilePath && Equals((FilePath)obj);

    /// <summary>Returns the hash value of the path string.</summary>
    /// <returns>The hash value of the path string.</returns>
    [DebuggerStepThrough]
    public override int GetHashCode() => _value == null ? 0 : _value.GetHashCode();

    #endregion

    /// <summary>Returns the <see cref="string" /> instance representing the current file path.</summary>
    /// <returns>represents the <see cref="string" /> instance of the current file path.</returns>
    [DebuggerStepThrough]
    public override string ToString() => _value ?? string.Empty;
}
