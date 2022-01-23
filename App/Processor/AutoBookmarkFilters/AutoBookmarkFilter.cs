using PDFPatcher.Model;

namespace PDFPatcher.Processor;

public abstract class AutoBookmarkFilter
{
    /// <summary>
    ///     Check if the incoming <see cref="model.autobookmarkcontext" /> complies with the specified filtering criteria.
    /// </summary>
    /// <param name="text">
    ///     Contains text information that needs to be filtered and other context
    ///     <see cref="Model.AutoBookmarkContext" />.
    /// </param>
    /// <returns>Filter results.</returns>
    internal abstract bool Matches(AutoBookmarkContext context);

    /// <summary>
    ///     Reset the internal state of the filter.
    /// </summary>
    internal abstract void Reset();
}
