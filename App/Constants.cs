using iTextSharp.text.pdf;
using E = System.Text.Encoding;

namespace PDFPatcher;

internal enum Function
{
    FrontPage,
    InfoFileOptions,
    InfoExchanger,
    ExtractPages,
    ExtractImages,
    RenderPages,
    EditorOptions,
    Patcher,
    PatcherOptions,
    Merger,
    MergerOptions,
    About,
    BookmarkEditor,
    Options,
    BookmarkGenerator,
    Ocr,
    Inspector,
    Rename,
    Log,
    Default
}

internal static class Constants
{
    internal const string AppName = "PDFPatcher";
    internal const string AppEngName = "PDFPatcher";
    internal const string AppHomePage = "http://pdfpatcher.cnblogs.com";
    internal const string AppHubPage = "https://github.com/wmjordan/PDFPatcher\nhttps://gitee.com/wmjordan/pdfpatcher";
    internal const string AppUpdateFile = "http://files.cnblogs.com/pdfpatcher/pdfpatcher.update.xml";

    /// <summary>
    ///     Information file root elements.
    /// </summary>
    internal const string PdfInfo = "PdfInformation";

    internal const string InfoDocVersion = "0.3.3";
    internal const string ContentPrefix = "pdf";
    internal const string ContentNamespace = "pdf:ContentXml";

    internal static class FileExtensions
    {
        internal const string Json = ".json";
        internal const string JsonFilter = "Program configuration file (*.json)|*.json";
        internal const string Pdf = ".pdf";
        internal const string PdfFilter = "PDF file (*.pdf)|*.pdf";
        internal const string Txt = ".txt";
        internal const string TxtFilter = "Simple text bookmark file (*.txt)|*.txt";
        internal const string Xml = ".xml";
        internal const string XmlFilter = "PDF Information file (*.xml)|*.xml";
        internal const string XmlOrTxtFilter = "Bookmark file (*.xml, *.txt)|*.xml;*.txt";

        internal const string AllEditableFilter =
            "All files that contain PDF information (*.pdf,*.xml,*.txt)|*.pdf;*.xml;*.txt|" + PdfFilter +
            "|" + XmlFilter + "|" + TxtFilter;

        internal const string AllFilter = "All files|*.*";

        internal const string ImageFilter =
            "Image file (*.jpg, *.jpeg, *.tiff, *.tif, *.png, *.gif)|*.jpg;*.jpeg;*.tiff;*.tif;*.png;*.gif";

        internal const string Tif = ".tif";
        internal const string Tiff = ".tiff";
        internal const string Jpg = ".jpg";
        internal const string Jpeg = ".jpeg";
        internal const string Png = ".png";
        internal const string Gif = ".gif";
        internal const string Jp2 = ".jp2";
        internal const string Bmp = ".bmp";
        internal const string Dat = ".dat";
        internal const string Tmp = ".tmp";
        internal const string Ttf = ".ttf";
        internal const string Ttc = ".ttc";
        internal const string Otf = ".otf";
        internal static readonly string[] AllBookmarkExtension = { ".xml", ".txt" };
        internal static readonly string[] PdfAndAllBookmarkExtension = { ".pdf", ".xml", ".txt" };
        internal static readonly string[] AllSupportedImageExtension = { Tif, Jpg, Png, Gif, Tiff, Jpeg, Bmp, Jp2 };
    }

    #region PDF object type

    internal static class ObjectTypes
    {
        internal static readonly string[] Names =
        {
            "dictionary", "name", "Value", "text", "Array", "Boolean", "Quote"
        };

        internal static readonly int[] IDs =
        {
            PdfObject.DICTIONARY, PdfObject.NAME, PdfObject.NUMBER, PdfObject.STRING, PdfObject.ARRAY,
            PdfObject.BOOLEAN, PdfObject.INDIRECT
        };
    }

    #endregion

    #region File name alternative

    internal static class FileNameMacros
    {
        internal const string FileName = "<FileName>";
        internal const string FolderName = "<FolderName>";
        internal const string PathName = "<PathName>";
        internal const string TitleProperty = "<" + Info.Title + ">";
        internal const string AuthorProperty = "<" + Info.Author + ">";
        internal const string SubjectProperty = "<" + Info.Subject + ">";
        internal const string KeywordsProperty = "<" + Info.Keywords + ">";
    }

    #endregion

    #region Unit of measure

    internal static class Units
    {
        internal const string ThisName = "UnitOfMeasure";
        internal const string Unit = "unit";
        internal const string Point = "point";
        internal const string CM = "cm";
        internal const string MM = "mm";
        internal const string Inch = "inch";
        internal const float CmToPoint = 72f / 2.54f;
        internal const float MmToPoint = 7.2f / 2.54f;
        internal const float DefaultDpi = 72f;
        internal static readonly string[] Names = { CM, MM, Inch, Point };
        internal static readonly float[] Factors = { CmToPoint, MmToPoint, DefaultDpi, 1 };
    }

    #endregion

    #region Alignment

    internal static class Alignments
    {
    }

    #endregion

    #region Coordinates

    internal static class Coordinates
    {
        internal const string Left = "Left";
        internal const string Right = "Right";
        internal const string Top = "Top";
        internal const string Bottom = "Bottom";
        internal const string Width = "Width";
        internal const string Height = "Height";
        internal const string Direction = "Direction";
        internal const string Horizontal = "Horizontal";
        internal const string Vertical = "Vertical";
        internal const string ScaleFactor = "ScaleFactor";
        internal const string Unchanged = "Unchanged";
    }

    #endregion

    #region Encoding

    internal static class Encoding
    {
        internal const string SystemDefault = "SystemDefault";
        internal const string Automatic = "Automatic";

        internal static readonly string[] EncodingNames =
        {
            Automatic, SystemDefault, "UTF-16 Big Endian", "UTF-16 Little Endian", "UTF-8", "GB18030", "BIG5"
        };

        internal static readonly E[] Encodings =
        {
            null, E.Default, E.BigEndianUnicode, E.Unicode, E.UTF8, E.GetEncoding("gb18030"), E.GetEncoding("big5")
        };
    }

    #endregion

    #region Page content

    internal static class Content
    {
        internal const string Page = "Page";
        internal const string PageNumber = "PageNumber";
        internal const string ResourceID = "ResourceID";
        internal const string RefType = "RefType";
        internal const string Texts = "Texts";
        internal const string Operators = "Operators";
        internal const string Operands = "Operands";
        internal const string Name = "Name";
        internal const string Item = "Item";
        internal const string Path = "Path";
        internal const string Type = "Type";
        internal const string Length = "Length";
        internal const string Raw = "Raw";
        internal const string Value = "Value";

        internal static class PageSettings
        {
            internal const string ThisName = "PageSettings";
            internal const string MediaBox = "MediaBox";
            internal const string CropBox = "CropBox";
            internal const string TrimBox = "TrimBox";
            internal const string ArtBox = "ArtBox";
            internal const string BleedBox = "BleedBox";
            internal const string Rotation = "Rotation";
        }

        internal static class OperandNames
        {
            internal const string Matrix = "Matrix";
            internal const string ResourceName = "ResourceName";
            internal const string Size = "Size";
            internal const string Text = "Text";
        }

        internal static class RotationDirections
        {
            internal const string Zero = "Zero";
            internal const string Right = "Right";
            internal const string HalfClock = "HalfClock";
            internal const string Left = "Left";
            internal static readonly string[] Names = { Zero, Right, HalfClock, Left };
            internal static readonly int[] Values = { 0, 90, 180, 270 };
        }
    }

    #endregion

    #region Optical character identification

    internal static class Ocr
    {
        internal const int NoLanguage = 0;
        internal const int SimplifiedChineseLangID = 2052;
        internal const int TraditionalChineseLangID = 1028;
        internal const int JapaneseLangID = 1041;
        internal const int KoreanLangID = 1042;
        internal const int EnglishLangID = 1033;

        internal const int DanishLangID = 1030;
        internal const int DutchLangID = 1043;
        internal const int FinnishLangID = 1035;
        internal const int FrenchLangID = 1036;
        internal const int GermanLangID = 1031;
        internal const int ItalianLangID = 1040;
        internal const int NorskLangID = 1044;
        internal const int PortugueseLangID = 1046;
        internal const int SpanishLangID = 3082;
        internal const int SwedishLangID = 1053;
        internal const int CzechLangID = 1029;
        internal const int PolishLangID = 1045;
        internal const int HungarianLangID = 1038;
        internal const int GreekLangID = 1032;
        internal const int RussianLangID = 1049;
        internal const int TurkishLangID = 1055;
        internal const string Result = "Result";
        internal const string Text = "Text";
        internal const string Content = "Content";
        internal const string Image = "Image";

        internal static int[] LangIDs =
        {
            SimplifiedChineseLangID, TraditionalChineseLangID, EnglishLangID, JapaneseLangID, KoreanLangID,
            DanishLangID, DutchLangID, FinnishLangID, FrenchLangID, GermanLangID, ItalianLangID, NorskLangID,
            PortugueseLangID, SpanishLangID, SwedishLangID, CzechLangID, PolishLangID, HungarianLangID, GreekLangID,
            RussianLangID, TurkishLangID
        };

        internal static int[] OcrLangIDs =
        {
            SimplifiedChineseLangID, TraditionalChineseLangID, 9, 17, 18, 6, 19, 11, 12, 7, 16, 20, 22, 10, 29, 5,
            21, 14, 8, 25, 31
        };

        internal static string[] LangNames =
        {
            "SimplifiedChinese", "TraditionalChinese", "English", "Japanese", "Korean", "Danish", "Dutch",
            "Finnish", "French", "German", "Italian", "Norwegian", "Portuguese", "Spanish", "Swedish", "Czech",
            "Polish", "Hungarian", "Greek", "Russian", "Turkish"
        };
    }

    #endregion

    #region Export to image

    internal static class ColorSpaces
    {
        internal const string Rgb = "DeviceRGB";
        internal const string Gray = "DeviceGray";
        internal static string[] Names = { Rgb, Gray };
    }

    #endregion

    #region Caj naming rules

    internal static class CajNaming
    {
        internal const string Cover = "cov";
        internal const string TitlePage = "bok";
        internal const string CopyrightPage = "leg";
        internal const string Foreword = "fow";
        internal const string Contents = "!";
    }

    #endregion

    internal static class AutoBookmark
    {
        internal const string Group = "Group";
        internal const string Name = "Name";
        internal const string Description = "Description";
        internal const string IsInclusive = "PositiveFiltering";
    }

    #region function name

    #endregion

    #region Documentation

    internal static class Info
    {
        internal const string ThisName = "DocumentationInfo";

        internal const string ProductName = "ProductName";
        internal const string ProductVersion = "ProductVersion";
        internal const string ExportDate = "ExportDate";
        internal const string DocumentPath = "DocumentPath";
        internal const string PageNumber = "PageNumber";
        internal const string Title = "Title";
        internal const string Author = "Author";
        internal const string Subject = "Subject";
        internal const string Keywords = "Keywords";
        internal const string Creator = "Creator";
        internal const string Producer = "Producer";
        internal const string CreationDate = "CreationDate";
        internal const string ModDate = "ModDate";
        internal const string MetaData = "MetaData";
    }

    internal const string Version = "PdfVersion";
    internal const string Catalog = "Catalog";
    internal const string Body = "Body";
    internal const string DocumentBookmark = "DocumentBookmark";

    #endregion

    #region Reader setting

    internal const string PageLayout = "PageLayout";

    internal static class PageLayoutType
    {
        internal static readonly string[] Names =
        {
            "Constant", "SinglePageContinuous", "DoublePageContinuous", "DoublePageContinuousHome",
            "SinglePage", "DoublePage", "DoublePageHomePage"
        };

        internal static readonly PdfName[] PdfNames =
        {
            PdfName.NONE, PdfName.ONECOLUMN, PdfName.TWOCOLUMNLEFT, PdfName.TWOCOLUMNRIGHT, PdfName.SINGLEPAGE,
            PdfName.TWOPAGELEFT, PdfName.TWOPAGERIGHT
        };
    }

    internal const string PageMode = "PageMode";

    internal static class PageModes
    {
        internal static readonly string[] Names =
        {
            "Unchanged", "DoNotShowSidebar", "ShowDocumentBookmarks", "ShowPageThumbnails",
            "ShowFullScreen", "ShowOptionalContentGroups", "ShowAttachmentsBar"
        };

        internal static readonly PdfName[] PdfNames =
        {
            PdfName.NONE, PdfName.USENONE, PdfName.USEOUTLINES, PdfName.USETHUMBS, PdfName.FULLSCREEN,
            PdfName.USEOC, PdfName.USEATTACHMENTS
        };
    }

    internal const string ViewerPreferences = "ViewerPreferences";

    internal static class ViewerPreferencesType
    {
        internal const string Direction = "Direction";

        internal static readonly string[] Names =
        {
            "HideMenu", "HideToolbar", "ShowDocumentContentOnly",
            "FitTheWindowToTheFirstPageOfTheDocument", "CenterTheWindow", "ShowDocumentTitle"
        };

        internal static readonly PdfName[] PdfNames =
        {
            PdfName.HIDEMENUBAR, PdfName.HIDETOOLBAR, PdfName.HIDEWINDOWUI, PdfName.FITWINDOW, PdfName.CENTERWINDOW,
            PdfName.DISPLAYDOCTITLE
        };

        internal static class DirectionType
        {
            internal static readonly string[] Names = { "Keep", "LeftToRight", "RightToLeft" };
            internal static readonly PdfName[] PdfNames = { PdfName.NONE, PdfName.L2R, PdfName.R2L };
        }
    }

    #endregion

    #region Page code style

    internal const string PageLabels = "PageNumberStyle";

    internal static class PageLabelStyles
    {
        internal static readonly string[] Names =
        {
            "Number", "UppercaseRomanNumeral", "LowercaseRomanNumeral", "UppercaseEnglishLetter",
            "LowercaseEnglishLetter"
        };

        internal static readonly char[] PdfValues = { 'D', 'R', 'r', 'A', 'a' };
        internal static readonly char[] SimpleInfoIdentifiers = { '0', 'I', 'i', 'A', 'a' };

        internal static readonly int[] Values =
        {
            PdfPageLabels.DECIMAL_ARABIC_NUMERALS, PdfPageLabels.UPPERCASE_ROMAN_NUMERALS,
            PdfPageLabels.LOWERCASE_ROMAN_NUMERALS, PdfPageLabels.UPPERCASE_LETTERS, PdfPageLabels.LOWERCASE_LETTERS
        };
    }

    internal static class PageLabelsAttributes
    {
        internal const string PageNumber = "PageNumber";
        internal const string StartPage = "StartPage";
        internal const string Prefix = "Prefix";
        internal const string Style = "Style";
    }

    #endregion

    #region Page size range

    internal const string PageRange = "PageRange";

    internal static class PageFilterTypes
    {
        internal const string ThisName = "PageFilter";
        internal const string AllPages = "AllPages";
        internal static readonly string[] Names = { AllPages, "SingularPages", "EvenPages" };
        internal static readonly int[] Values = { -1, 1, 0 };
    }

    #endregion

    #region Destination

    internal const string NamedDestination = "NamedDestination";

    internal static class DestinationAttributes
    {
        internal const string Page = "Page";
        internal const string FirstPageNumber = "FirstPageNumber";
        internal const string Action = "Action";
        internal const string NewWindow = "NewWindow";
        internal const string Path = "Path";
        internal const string Name = "Name";
        internal const string Named = "Named";
        internal const string NamedN = "NamedN";
        internal const string View = "View";
        internal const string ScriptContent = "ScriptContent";

        internal static class ViewType
        {
            internal const string XYZ = "XYZ";
            internal const string Fit = "Fit";
            internal const string FitH = "FitH";
            internal const string FitV = "FitV";
            internal const string FitB = "FitB";
            internal const string FitBH = "FitBH";
            internal const string FitBV = "FitBV";
            internal const string FitR = "FitR";
            internal static readonly string[] Names = { XYZ, Fit, FitH, FitV, FitB, FitBH, FitBV, FitR };

            internal static readonly PdfName[] PdfNames =
            {
                PdfName.XYZ, PdfName.FIT, PdfName.FITH, PdfName.FITV, PdfName.FITB, PdfName.FITBH, PdfName.FITBV,
                PdfName.FITR
            };
        }
    }

    internal static class ActionType
    {
        internal const string Goto = "Goto";
        internal const string GotoR = "GotoR";
        internal const string Launch = "Launch";
        internal const string Uri = "Uri";
        internal const string Javascript = "Javascript";
        internal static readonly string[] Names = { Goto, GotoR, Launch, Uri, Javascript };
    }

    #endregion

    #region Bookmark

    internal const string Bookmark = "Bookmark";

    internal static class BookmarkAttributes
    {
        internal const string Title = "Text";
        internal const string Open = "OpenByDefault";
        internal const string Style = "Style";

        internal static class StyleType
        {
            internal const string Normal = "Normal";
            internal const string Bold = "bold";
            internal const string BoldItalic = "Bold Italic";
            internal const string Italic = "Italic";
            internal static readonly string[] Names = { Normal, Italic, Bold, BoldItalic };
        }
    }

    internal const string Color = "Color";

    internal static class Colors
    {
        internal const string Red = "Red";
        internal const string Green = "green";
        internal const string Blue = "Blue";
        internal const string Gray = "Gray";
        internal const string Transparent = "Transparent";
        internal const string Cyan = "cyan";
        internal const string Magenta = "Magenta";
        internal const string Yellow = "Yellow";
        internal const string Black = "Black";
    }

    internal static class Boolean
    {
        internal const string True = "True";
        internal const string False = "False";
    }

    #endregion

    #region Page link

    internal const string PageLink = "PageLink";

    internal static class PageLinkAttributes
    {
        internal const string Link = "Link";
        internal const string LinkAction = "LinkAction";
        internal const string PageNumber = "PageNumber";
        internal const string Border = "Border";
        internal const string Style = "Style";
        internal const string QuadPoints = "QuadPoints";
        internal const string Contents = "Contents";
    }

    #endregion

    #region Font properties

    internal static class Font
    {
        internal const string ThisName = "Font";
        internal const string DocumentFont = "DocumentFont";
        internal const string ID = "ID";
        internal const string Name = "Name";
        internal const string Size = "Size";
    }

    internal static class FontOccurance
    {
        internal const string Count = "Count";
        internal const string FirstText = "FirstText";
        internal const string FirstPage = "FirstPage";
    }

    #endregion
}

internal static class Messages
{
    internal const string Welcome = "PDFPatcher - Take the trouble out of PDF documents";

    internal const string SourceFileNotFound =
        "The source PDF file does not exist, please specify a valid source PDF file first.";

    internal const string TargetFileNotSpecified = "Please specify the path to the output PDF file.";
    internal const string InfoDocNotSpecified = "Please specify the path to the output information file.";
    internal const string TargetFileNameInvalid = "The output PDF filename is invalid.";
    internal const string InfoFileNameInvalid = "Invalid file name for info file.";
    internal const string SourceFileEqualsTargetFile = "The input and output PDF file names cannot be the same.";
    internal const string PasswordInvalid = "The entered password is incorrect, the PDF document cannot be opened.";

    internal const string UserRightRequired =
        "The author of this PDF file has set permission controls to modify the file.\nIf you continue, you must be authorized by the creator to modify this document.\nIf you cannot guarantee that you have permission to modify this document, press \"No\" key to exit, otherwise you will take all responsibility for modifying this document.";

    internal const string PageRanges =
        "Enter the page number range to be processed here.\nFor example: \"1-100\" means to process pages 1 to 100.\nIf there are multiple page number ranges, they can be separated by spaces, semicolons or commas.\nFor example: \" 1-10;12;14-20\" means processing pages 1-10, 12 and 14-20.";

    internal const string ModiNotAvailable =
        "The Microsoft Text Recognition Component (MODI) has not been installed on this machine, and the text recognition function cannot be used.";
}
