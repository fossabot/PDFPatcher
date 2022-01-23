using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using iTextSharp.text.pdf;
using PDFPatcher.Common;
using PDFPatcher.Processor;

namespace PDFPatcher.Model;

internal enum PdfPageCommandType
{
    Normal,
    Text,
    Enclosure,
    Matrix,
    Font,
    InlineImage
}

internal interface IPdfPageCommandContainer
{
    IList<PdfPageCommand> Commands { get; }
}

internal class PdfPageCommand
{
    public PdfPageCommand(PdfLiteral oper, List<PdfObject> operands)
    {
        Name = oper;
        if (!(operands?.Count > 0))
        {
            return;
        }

        Operands = new PdfObject[operands[operands.Count - 1] is PdfLiteral ? operands.Count - 1 : operands.Count];
        operands.CopyTo(0, Operands, 0, Operands.Length);
    }

    public virtual PdfLiteral Name { get; }
    public PdfObject[] Operands { get; }
    public virtual PdfPageCommandType Type => PdfPageCommandType.Normal;
    internal bool HasOperand => Operands?.Length > 0;

    internal static PdfPageCommand Create(string name, params PdfObject[] operands) =>
        new(new PdfLiteral(name), new List<PdfObject>(operands));

    internal virtual void WriteToPdf(Stream target)
    {
        if (Operands != null)
        {
            foreach (PdfObject oi in Operands)
            {
                WriteOperand(oi, target);
            }
        }

        WriteOperator(Name, target);
    }

    protected static void WriteOperand(PdfObject operand, Stream target)
    {
        operand.ToPdf(null, target);
        target.WriteByte((byte)' ');
    }

    protected static void WriteOperator(PdfLiteral opName, Stream target)
    {
        opName.ToPdf(null, target);
        target.WriteByte((byte)'\n');
    }

    internal static bool GetFriendlyCommandName(string oper, out string friendlyName) =>
        __OperatorNames.TryGetValue(oper, out friendlyName);

    internal string GetOperandsText() => Operands != null ? PdfHelper.GetArrayString(Operands) : null;

    #region Operator Chinese name

    private static readonly Dictionary<string, string> __OperatorNames = Init();

    private static Dictionary<string, string> Init()
    {
        Dictionary<string, string> d = new()
        {
            { "'", "Newline string" },
            { "\"", "Newline string" },
            { "b", "Closed non-zero line fill" },
            { "B", "Non-zero line drawing fill" },
            { "b*", "Closed parity line fill" },
            { "B*", "Odd and even line fill" },
            { "BDC", "Mark content area and attributes" },
            { "BI", "Inline Image" },
            { "BMC", "Mark Content Area" },
            { "BT", "Text Area" },
            { "BX", "Compatibility Zone" },
            { "c", "curve" },
            { "cm", "Matrix" },
            { "CS", "Line drawing color gamut" },
            { "cs", "Non-Linear Gamut" },
            { "d", "Dash pattern" },
            { "d0", "Type3 word width" },
            { "d1", "Type3 word width and container" },
            { "Do", "Drawing Object" },
            { "DP", "Mark content points and attributes" },
            { "EI", "End of inline image" },
            { "EMC", "Mark content end" },
            { "ET", "End of text area" },
            { "EX", "End of Compatibility Zone" },
            { "f", "Non-zero padding" },
            { "F", "Non-zero padding" },
            { "f*", "Parity Fill" },
            { "G", "Gray line drawing" },
            { "g", "Non-Line Gray" },
            { "gs", "Drawing parameters" },
            { "h", "end point" },
            { "i", "Smoothness Tolerance" },
            { "ID", "Inline image data" },
            { "J", "Line End Style" },
            { "j", "Connector style" },
            { "K", "Line drawing four colors" },
            { "k", "Non-Linear Four Colors" },
            { "l", "Line" },
            { "m", "Start point" },
            { "M", "Maximum Miter Face" },
            { "MP", "Mark Content Points" },
            { "n", "Closed path is not filled" },
            { "q", "Drawing state" },
            { "Q", "Plotting the drawing state" },
            { "re", "rectangle" },
            { "RG", "Three colors for drawing lines" },
            { "rg", "Non-Linear Tricolor" },
            { "ri", "Color rendering intent" },
            { "s", "Draw a closed line" },
            { "S", "Draw a line" },
            { "SC", "Line Color" },
            { "sc", "Non-Line Color" },
            { "SCN", "Line Color" },
            { "scn", "Non-Line Color" },
            { "sh", "Shadow" },
            { "T*", "Newline" },
            { "Tc", "kerning" },
            { "Td", "Newline" },
            { "TD", "Newline" },
            { "Tf", "Font" },
            { "Tj", "String" },
            { "TJ", "String" },
            { "Tk", "Individual character rendering" },
            { "TL", "Line spacing" },
            { "Tm", "Text Matrix" },
            { "Tr", "Text Rendering" },
            { "Ts", "Text vertical offset" },
            { "Tw", "Word Spacing" },
            { "Tz", "Text horizontal stretch" },
            { "v", "Tail control curve" },
            { "w", "Line width" },
            { "W", "Non-zero clipping" },
            { "W*", "Parity crop" },
            { "y", "Heading curve" }
        };
        return d;
    }

    #endregion
}

internal sealed class EnclosingCommand : PdfPageCommand, IPdfPageCommandContainer
{
    private const string BQ = "q";
    private const string BT = "BT";
    private const string BDC = "BDC";
    private const string BMC = "BMC";
    private const string BX = "BX";
    private const string EQ = "Q";
    private const string ET = "ET";
    private const string EMC = "EMC";
    private const string EX = "EX";

    private static readonly string[] __StartEnclosingCommands = { BQ, BT, BDC, BMC, BX };
    private static readonly string[] __EndEnclosingCommands = { EQ, ET, EMC, EX };

    private static readonly PdfLiteral[] __EnclosingCommands = { new(EQ), new(ET), new(EMC), new(EMC), new(EX) };

    public EnclosingCommand(PdfLiteral oper, List<PdfObject> operands)
        : base(oper, operands) =>
        Commands = new List<PdfPageCommand>();

    public override PdfPageCommandType Type => PdfPageCommandType.Enclosure;

    public bool HasCommand => Commands.Count > 0;
    public IList<PdfPageCommand> Commands { get; }

    internal static EnclosingCommand Create(string name, IEnumerable<PdfObject> operands,
        params PdfPageCommand[] subCommands)
    {
        EnclosingCommand c = new(new PdfLiteral(name), operands != null ? new List<PdfObject>(operands) : null);
        ((List<PdfPageCommand>)c.Commands).AddRange(subCommands);
        return c;
    }

    internal override void WriteToPdf(Stream target)
    {
        base.WriteToPdf(target);
        if (HasCommand)
        {
            foreach (PdfPageCommand cmd in Commands)
            {
                cmd.WriteToPdf(target);
            }
        }

        WriteOperator(ValueHelper.MapValue(Name.ToString(), __StartEnclosingCommands, __EnclosingCommands), target);
    }

    internal static bool IsStartingCommand(string oper) => __StartEnclosingCommands.Contains(oper);

    internal static bool IsEndingCommand(string oper) => __EndEnclosingCommands.Contains(oper);
}

internal class TextCommand : PdfPageCommand
{
    public TextCommand(PdfLiteral oper, List<PdfObject> operands, TextInfo text)
        : base(oper, operands) =>
        TextInfo = text;

    public TextInfo TextInfo { get; }
    public override PdfPageCommandType Type => PdfPageCommandType.Text;
}

internal sealed class PaceAndTextCommand : TextCommand
{
    public PaceAndTextCommand(PdfLiteral oper, List<PdfObject> operands, TextInfo text, FontInfo font)
        : base(oper, operands, text)
    {
        PdfArray a = Operands[0] as PdfArray;
        DecodedTexts = new string[a.Size];
        int i = 0;
        foreach (PdfObject item in a.ArrayList)
        {
            if (item.Type == PdfObject.STRING)
            {
                DecodedTexts[i] = font.DecodeText(item as PdfString);
            }

            ++i;
        }

        text.Text = string.Concat(DecodedTexts);
    }

    public string[] DecodedTexts { get; }
}

internal sealed class MatrixCommand : PdfPageCommand
{
    public static PdfLiteral CM = new("cm");
    public static PdfLiteral TM = new("Tm");

    public MatrixCommand(PdfLiteral oper, List<PdfObject> operands)
        : base(oper, operands)
    {
    }

    public MatrixCommand(PdfLiteral oper, float a, float b, float c, float d, float e, float f)
        : base(oper, new List<PdfObject>(6)
        {
            new PdfNumber(a),
            new PdfNumber(b),
            new PdfNumber(c),
            new PdfNumber(d),
            new PdfNumber(e),
            new PdfNumber(f)
        })
    {
    }

    public override PdfPageCommandType Type => PdfPageCommandType.Matrix;

    public void Multiply(double[] matrix)
    {
        double[] m1 = Array.ConvertAll(Operands, i => (i as PdfNumber).DoubleValue);
        Operands[0] = new PdfNumber(m1[0] * matrix[0] + m1[1] * matrix[2]);
        Operands[1] = new PdfNumber(m1[0] * matrix[1] + m1[1] * matrix[3]);
        Operands[2] = new PdfNumber(m1[2] * matrix[0] + m1[3] * matrix[2]);
        Operands[3] = new PdfNumber(m1[2] * matrix[1] + m1[3] * matrix[3]);
        Operands[4] = new PdfNumber(m1[4] * matrix[0] + m1[5] * matrix[2] + matrix[4]);
        Operands[5] = new PdfNumber(m1[4] * matrix[1] + m1[5] * matrix[3] + matrix[5]);
    }
}

internal sealed class FontCommand : PdfPageCommand
{
    public FontCommand(PdfLiteral oper, List<PdfObject> operands, string fontName)
        : base(oper, operands) =>
        FontName = fontName;

    public string FontName { get; }

    public PdfName ResourceName
    {
        get => Operands[0] as PdfName;
        set => Operands[0] = value;
    }

    public PdfNumber FontSize
    {
        get => Operands[1] as PdfNumber;
        set => Operands[1] = value;
    }

    public override PdfPageCommandType Type => PdfPageCommandType.Font;
}

internal sealed class InlineImageCommand : PdfPageCommand
{
    //static readonly PdfName __DCT = new PdfName ("DCT");
    //static readonly PdfName __CCF = new PdfName ("CCF");
    private static readonly PdfLiteral __ID = new("ID");
    private static readonly PdfLiteral __EI = new("EI");

    public InlineImageCommand(PdfLiteral oper, List<PdfObject> operands) : base(oper, operands)
    {
    }

    public PdfImageData Image => Operands[0] as PdfImageData;
    public override PdfPageCommandType Type => PdfPageCommandType.InlineImage;

    internal override void WriteToPdf(Stream target)
    {
        PdfImageData img = Image;
        WriteOperator(Name, target);
        foreach (KeyValuePair<PdfName, PdfObject> item in img)
        {
            item.Key.ToPdf(null, target);
            target.WriteByte((byte)' ');
            item.Value.ToPdf(null, target);
            target.WriteByte((byte)'\n');
        }

        WriteOperator(__ID, target);
        target.Write(img.RawBytes, 0, img.RawBytes.Length);
        target.WriteByte((byte)'\n');
        WriteOperator(__EI, target);
    }
}
