namespace PDFPatcher.Processor;

internal interface IProcessor
{
    /// <summary>
    ///     Returns the name of the processor。
    /// </summary>
    string Name { get; }
}
