using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace PDFPatcher.Common;

/// <summary>Classs used to create or manage shortcut files.</summary>
public sealed class ShortcutFile
{
    private readonly IShellLink _link;

    private ShortcutFile() => _link = (IShellLink)new ShellLink();

    /// <summary>Create Shortcut.</summary>
    /// <param name="destination">Shortcuts pointing to the target file path.</param>
    public ShortcutFile(string destination)
    {
        _link = (IShellLink)new ShellLink();
        Destination = destination;
        _link.SetPath(destination);
    }

    /// <summary>Gets or sets a shortcut target path.</summary>
    public string Destination { get; private set; }

    /// <summary>Get or set up a shortcut working directory.</summary>
    public string WorkingDirectory { get; set; }

    /// <summary>Get or set a shortcut description text.</summary>
    public string Description { get; set; }

    /// <summary>Get or set up a shortcut startup parameter.</summary>
    public string Arguments { get; set; }

    /// <summary>Get or set a shortcut icon file location.</summary>
    public string IconLocation { get; set; }

    /// <summary>Get or set up a shortcut icon file index.</summary>
    public int IconIndex { get; set; }

    /// <summary>Load shortcut.</summary>
    /// <param name="shortcutFilePath">The location of the shortcut file.</param>
    /// <returns><see cref="ShortcutFile" /> Instance.</returns>
    public static ShortcutFile Load(string shortcutFilePath)
    {
        ShortcutFile s = new();
        IShellLink l = s._link;
        IPersistFile file = (IPersistFile)s._link;
        file.Load(shortcutFilePath, 0);
        s.Destination = shortcutFilePath;
        StringBuilder sb = new();
        l.GetDescription(sb, 512);
        s.Description = sb.ToString();
        sb.Length = 0;
        l.GetWorkingDirectory(sb, 256);
        s.WorkingDirectory = sb.ToString();
        sb.Length = 0;
        l.GetIconLocation(sb, 256, out int _);
        s.IconLocation = sb.ToString();
        sb.Length = 0;
        l.GetArguments(sb, 256);
        s.Arguments = sb.ToString();
        return s;
    }

    /// <summary>Save the shortcut to the target location.</summary>
    /// <param name="position">The location of the shortcut file.</param>
    public void Save(string position)
    {
        if (string.IsNullOrEmpty(WorkingDirectory) == false)
        {
            _link.SetWorkingDirectory(WorkingDirectory);
        }

        if (string.IsNullOrEmpty(Description) == false)
        {
            _link.SetDescription(Description);
        }

        if (string.IsNullOrEmpty(Arguments) == false)
        {
            _link.SetArguments(Arguments);
        }

        if (string.IsNullOrEmpty(IconLocation) == false)
        {
            _link.SetIconLocation(IconLocation, IconIndex >= 0 ? IconIndex : 0);
        }

        IPersistFile file = (IPersistFile)_link;
        file.Save(position, false);
    }

    #region COM Interops

    [ComImport]
    [Guid("00021401-0000-0000-C000-000000000046")]
    private class ShellLink
    {
    }

    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("000214F9-0000-0000-C000-000000000046")]
    private interface IShellLink
    {
        void GetPath([Out][MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszFile, int cchMaxPath, out IntPtr pfd,
            int fFlags);

        void GetIDList(out IntPtr ppidl);
        void SetIDList(IntPtr pidl);
        void GetDescription([Out][MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszName, int cchMaxName);
        void SetDescription([MarshalAs(UnmanagedType.LPWStr)] string pszName);
        void GetWorkingDirectory([Out][MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszDir, int cchMaxPath);
        void SetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] string pszDir);
        void GetArguments([Out][MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszArgs, int cchMaxPath);
        void SetArguments([MarshalAs(UnmanagedType.LPWStr)] string pszArgs);
        void GetHotkey(out short pwHotkey);
        void SetHotkey(short wHotkey);
        void GetShowCmd(out int piShowCmd);
        void SetShowCmd(int iShowCmd);

        void GetIconLocation([Out][MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszIconPath, int cchIconPath,
            out int piIcon);

        void SetIconLocation([MarshalAs(UnmanagedType.LPWStr)] string pszIconPath, int iIcon);
        void SetRelativePath([MarshalAs(UnmanagedType.LPWStr)] string pszPathRel, int dwReserved);
        void Resolve(IntPtr hwnd, int fFlags);
        void SetPath([MarshalAs(UnmanagedType.LPWStr)] string pszFile);
    }

    #endregion
}
