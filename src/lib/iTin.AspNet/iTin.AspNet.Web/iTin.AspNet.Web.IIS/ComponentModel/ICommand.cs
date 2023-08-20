
using System;

namespace iTin.AspNet.Web.IIS.ComponentModel;

/// <summary>
/// Defines a generic command.
/// </summary>
public interface ICommand : IEquatable<ICommand>, ICloneable, IExecute, IAsyncExecute
{
    /// <summary>
    /// Gets or sets command optional arguments.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> that contains the command optional arguments.
    /// </value>
    string Arguments { get; set; }

    /// <summary>
    /// Gets command to executes.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> that contains the command to executes.
    /// </value>
    string Command { get; }

    /// <summary>
    /// Gets or sets the program responsible for executing the command.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> that program responsible for executing the command.
    /// </value>
    string Program { get; set; }

    /// <summary>
    /// Gets or sets the command options
    /// </summary>
    /// <value>
    /// A <see cref="CommandOptions"/> reference that contains command options.
    /// </value>
    CommandOptions Options { get; set; }
}
