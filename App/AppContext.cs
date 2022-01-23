using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MuPdfSharp;
using PDFPatcher.Common;
using PowerJson;

namespace PDFPatcher;

internal static class AppContext
{
    internal const int MaxHistoryItemCount = 16;

    private static readonly string AppConfigFilePath = FileHelper.CombinePath(
        Path.GetDirectoryName(Application.ExecutablePath),
        //"config.json");
        "AppConfig.json");

    private static readonly SerializationManager JsonSm = new(new JsonReflectionController(true))
    {
        UseExtensions = false,
        SerializeEmptyCollections = false,
        SerializeNullValues = false,
        SerializeReadOnlyFields = false,
        SerializeReadOnlyProperties = false,
        CanSerializePrivateMembers = true
    };

    private static string[] _SourceFiles = new string[0];

    static AppContext()
    {
        SaveAppSettings = true;
        BookmarkFile = string.Empty;
        TargetFile = string.Empty;
        CheckUpdateDate = DateTime.Now;
        CheckUpdateInterval = 14;
        Exporter = new ExporterOptions();
        Importer = new ImporterOptions();
        Merger = new MergerOptions();
        Patcher = new PatcherOptions();
        Editor = new PatcherOptions();
        AutoBookmarker = new AutoBookmarkOptions();
        Encodings = new EncodingOptions();
        ImageExtracter = new ImageExtracterOptions();
        ImageRenderer = new ImageRendererOptions();
        ExtractPage = new ExtractPageOptions();
        Ocr = new OcrOptions();
        Toolbar = new ToolbarOptions();
        Recent = new RecentItems();
    }

    internal static MainForm MainForm { get; set; }
    public static bool SaveAppSettings { get; set; }

    /// <summary>Gets or specifies whether only partial documents are loaded when the PDF document is loaded.</summary>
    public static bool LoadPartialPdfFile { get; set; }

    /// <summary>Get or specify a list of source files to be processed.</summary>
    public static string[] SourceFiles
    {
        get => _SourceFiles;
        set => _SourceFiles = value ?? new string[0];
    }

    /// <summary>Get or specify the date of checking the update.</summary>
    public static DateTime CheckUpdateDate { get; set; }

    /// <summary>Get or specify the date interval of checking the update.</summary>
    public static int CheckUpdateInterval { get; set; }

    /// <summary>Get or specify whether to cancel the batch operation.</summary>
    public static bool Abort { get; set; }

    /// <summary>Gets or specifies the path to the bookmark file.</summary>
    public static string BookmarkFile { get; set; }

    /// <summary>Gets or specifies the path to the target file.</summary>
    public static string TargetFile { get; set; }

    /// <summary>Get export settings.</summary>
    public static ExporterOptions Exporter { get; internal set; }

    /// <summary>Get import settings.</summary>
    public static ImporterOptions Importer { get; internal set; }

    /// <summary>Get the settings for generating a document.</summary>
    public static MergerOptions Merger { get; internal set; }

    /// <summary>Get the settings for generating a document.</summary>
    public static PatcherOptions Patcher { get; internal set; }

    /// <summary>Get the settings for the document editor.</summary>
    public static PatcherOptions Editor { get; internal set; }

    /// <summary>Get the settings that automatically generate bookmarks.</summary>
    public static AutoBookmarkOptions AutoBookmarker { get; internal set; }

    /// <summary>Get the application settings.</summary>
    public static EncodingOptions Encodings { get; internal set; }

    /// <summary>Get the settings of the exported image.</summary>
    public static ImageExtracterOptions ImageExtracter { get; internal set; }

    /// <summary>Get the setting converted to a picture.</summary>
    public static ImageRendererOptions ImageRenderer { get; internal set; }

    /// <summary>Get the settings for extracting the page.</summary>
    public static ExtractPageOptions ExtractPage { get; internal set; }

    /// <summary>Get the setting of the optical character identification function.</summary>
    public static OcrOptions Ocr { get; internal set; }

    /// <summary>Get or specify the project of the custom toolbar.</summary>
    public static ToolbarOptions Toolbar { get; internal set; }

    public static RecentItems Recent { get; internal set; }

    internal static void CleanUpInexistentFiles(IList<string> list)
    {
        List<string> s = new(list.Count);
        s.AddRange(list.Where(item => FileHelper.HasFileNameMacro(item) || File.Exists(item)));

        list.Clear();
        list.AddRange(s);
    }

    internal static void CleanUpInexistentFolders(IList<string> list)
    {
        List<string> s = new(list.Count);
        s.AddRange(list.Where(item => FileHelper.HasFileNameMacro(item) || Directory.Exists(item)));

        list.Clear();
        list.AddRange(s);
    }

    internal static bool Load(string path) => LoadJson(path);

    internal static bool LoadJson(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            path = AppConfigFilePath;
        }

        if (File.Exists(path) == false)
        {
            return false;
        }

        ConfigurationSerialization conf;
        try
        {
            conf = Json.ToObject<ConfigurationSerialization>(File.ReadAllText(path, Encoding.UTF8), JsonSm);
            if (conf == null || conf.SaveAppSettings == false)
            {
                SaveAppSettings = false;
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }

        CheckUpdateDate = conf.CheckUpdateDate;
        CheckUpdateInterval = conf.CheckUpdateInterval;
        LoadPartialPdfFile = conf.PdfLoadMode == Configuration.OptimalMemoryUsage;
        if (conf.Recent != null)
        {
            Recent = conf.Recent;
        }

        if (conf.ExporterOptions != null)
        {
            Exporter = conf.ExporterOptions;
        }

        if (conf.ImporterOptions != null)
        {
            Importer = conf.ImporterOptions;
        }

        if (conf.MergerOptions != null)
        {
            Merger = conf.MergerOptions;
        }

        if (conf.PatcherOptions != null)
        {
            Patcher = conf.PatcherOptions;
        }

        if (conf.EditorOptions != null)
        {
            Editor = conf.EditorOptions;
        }

        if (conf.AutoBookmarkOptions != null)
        {
            AutoBookmarker = conf.AutoBookmarkOptions;
        }

        if (conf.Encodings != null)
        {
            Encodings = conf.Encodings;
        }

        if (conf.ImageExporterOptions != null)
        {
            ImageExtracter = conf.ImageExporterOptions;
        }

        if (conf.ImageRendererOptions != null)
        {
            ImageRenderer = conf.ImageRendererOptions;
        }

        if (conf.OcrOptions != null)
        {
            Ocr = conf.OcrOptions;
        }

        if (conf.ExtractPageOptions != null)
        {
            ExtractPage = conf.ExtractPageOptions;
        }

        if (conf.ToolbarOptions != null)
        {
            Toolbar = conf.ToolbarOptions;
        }

        return true;
    }

    /// <summary>
    ///     Save the application configuration.
    /// </summary>
    /// <param name="path">save route.When the path is empty, save it to the default location.</param>
    /// <param name="saveHistoryFileList">Whether to save a list of historical files.</param>
    internal static void Save(string path, bool saveHistoryFileList)
    {
        try
        {
            SaveJson(path ?? AppConfigFilePath, saveHistoryFileList);
        }
        catch (Exception ex)
        {
            FormHelper.ErrorBox("在保存程序设置时出错" + ex.Message);
        }
    }

    private static void SaveJson(string path, bool saveHistoryFileList)
    {
        ConfigurationSerialization s = SaveAppSettings
            ? new ConfigurationSerialization
            {
                SaveAppSettings = true,
                CheckUpdateDate = CheckUpdateDate,
                CheckUpdateInterval = CheckUpdateInterval,
                PdfLoadMode = LoadPartialPdfFile ? Configuration.OptimalMemoryUsage : Configuration.OptimalSpeed,
                MergerOptions = Merger,
                ExporterOptions = Exporter,
                ImporterOptions = Importer,
                PatcherOptions = Patcher,
                EditorOptions = Editor,
                AutoBookmarkOptions = AutoBookmarker,
                Encodings = Encodings,
                ImageExporterOptions = ImageExtracter,
                ImageRendererOptions = ImageRenderer,
                ExtractPageOptions = ExtractPage,
                OcrOptions = Ocr,
                ToolbarOptions = Toolbar,
                Recent = saveHistoryFileList ? Recent : null
            }
            : new ConfigurationSerialization { SaveAppSettings = false };
        File.WriteAllText(path, Json.ToJson(s, JsonSm), Encoding.UTF8);
    }

    [JsonSerializable]
    public sealed class RecentItems
    {
        /// <summary>Get a list of recently used PDF files.</summary>
        [JsonField("源文件")]
        public List<string> SourcePdfFiles { get; } = new();

        /// <summary>Get a list of recently used PDF output files.</summary>
        [JsonField("输出文件")]
        public List<string> TargetPdfFiles { get; } = new();

        /// <summary>Get the list of recently used information files.</summary>
        [JsonField("信息文件")]
        public List<string> InfoDocuments { get; } = new();

        /// <summary>Get the most recently used file name template list.</summary>
        [JsonField("文件名模板")]
        public List<string> FileNameTemplates { get; } = new();

        /// <summary>Get the most recently used folder list.</summary>
        [JsonField("文件夹")]
        public List<string> Folders { get; } = new();

        /// <summary>Get the most recently used lookup string list.</summary>
        [JsonField("查找项")]
        public List<string> SearchPatterns { get; } = new();

        /// <summary>Get the list of recently used replacement strings.</summary>
        [JsonField("替换项")]
        public List<string> ReplacePatterns { get; } = new();

        internal static void AddHistoryItem(IList<string> list, string item)
        {
            if (string.IsNullOrEmpty(item))
            {
                return;
            }

            int i = -1;
            bool m = false;
            foreach (string li in list)
            {
                i++;
                if (!string.Equals(li, item, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                m = true;
                break;
            }

            if (m)
            {
                if (i == 0)
                {
                    return;
                }

                if (i != -1)
                {
                    list.RemoveAt(i);
                }
            }

            list.Insert(0, item);
            while (list.Count > MaxHistoryItemCount)
            {
                list.RemoveAt(list.Count - 1);
            }
        }
    }
}
