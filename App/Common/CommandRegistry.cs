using System;
using System.Collections.Generic;

namespace PDFPatcher.Common;

/// <summary>
///     Indicates the processing command executed under the specified context.
/// </summary>
/// <typeparam name="TP">The context type when processing commands.</typeparam>
internal interface ICommand<in TP>
{
    void Process(TP context, params string[] parameters);
}

/// <summary>
///     Do not distinguish string case matches matching container collection. Used to edit command mode.
/// </summary>
/// <typeparam name="P">The processing parameter type of command mode.</typeparam>
internal sealed class CommandRegistry<P>
{
    private readonly Dictionary<string, ICommand<P>> _container = new(StringComparer.OrdinalIgnoreCase);

    /// <summary>
    ///     Register the command processor.
    /// </summary>
    /// <param name="command">Perform the processor of the command.</param>
    /// <param name="commandIDs">Trigger the command identifier of the command.</param>
    public void Register(ICommand<P> command, params string[] commandIDs)
    {
        foreach (string cmd in commandIDs)
        {
            _container.Add(cmd, command);
        }
    }

    /// <summary>
    ///     Execute the specified command.
    /// </summary>
    /// <param name="commandID">Command identifier.</param>
    /// <param name="context">The context variable when processing the command.</param>
    /// <param name="parameters">parameter.</param>
    /// <returns>Returns true if the corresponding command processing is found, otherwise returns false.</returns>
    public bool Process(string commandID, P context, params string[] parameters)
    {
        if (!_container.TryGetValue(commandID, out ICommand<P> cmd))
        {
            return false;
        }

        cmd.Process(context, parameters);
        return true;
    }
}
