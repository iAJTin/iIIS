
namespace iTin.AspNet.Web.IIS.ComponentModel;

/// <summary>
/// Class that defines available command options.
/// </summary>
public class CommandOptions
{
    #region public static properties

    /// <summary>
    /// Returns a <see cref="CommandOptions"/> reference with silent mode activated.
    /// </summary>
    /// <returns>
    /// A reference to a new <see cref="CommandOptions"/> with silent mode activated.
    /// </returns>
    public static CommandOptions SilentModeActivated => new CommandOptions { SilentMode = true };

    /// <summary>
    /// Returns a <see cref="CommandOptions"/> reference with silent mode deactivated.
    /// </summary>
    /// <returns>
    /// A reference to a new <see cref="CommandOptions"/> with silent mode deactivated.
    /// </returns>
    public static CommandOptions SilentModeDeactivated => new CommandOptions {SilentMode = false};

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a value that indicates whether silent mode should be used when a command is executed.
    /// </summary>
    /// <value>
    /// <b>true</b> if uses a silent mode for command execution; otherwise <b>false</b>.
    /// </value>
    public bool SilentMode { get; set; }

    #endregion

    #region public override methods
        
    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>
    /// A <see cref="string"/> that represents the current object.
    /// </returns>
    public override string ToString() => $"{(SilentMode ? "Use silent mode activated": "Use silent mode deactivated")}";

    #endregion
}
