
namespace iTin.AspNet.Web.IIS.ComponentModel
{
    /// <summary>
    /// Class that defines available command options.
    /// </summary>
    public class CommandOptions
    {
        #region public static properties

        #region [public] {static} (CommandOptions) SilentModeActivated: Returns a reference with silent mode activated
        /// <summary>
        /// Returns a <see cref="CommandOptions"/> reference with silent mode activated.
        /// </summary>
        /// <returns>
        /// A reference to a new <see cref="CommandOptions"/> with silent mode activated.
        /// </returns>
        public static CommandOptions SilentModeActivated => new CommandOptions { SilentMode = true };
        #endregion

        #region [public] {static} (CommandOptions) SilentModeDeactivated: Returns a reference with silent mode deactivated
        /// <summary>
        /// Returns a <see cref="CommandOptions"/> reference with silent mode deactivated.
        /// </summary>
        /// <returns>
        /// A reference to a new <see cref="CommandOptions"/> with silent mode deactivated.
        /// </returns>
        public static CommandOptions SilentModeDeactivated => new CommandOptions {SilentMode = false};
        #endregion

        #endregion

        #region public properties

        #region [public] (bool) SilentMode: Gets or sets a value that indicates whether silent mode should be used when a command is executed
        /// <summary>
        /// Gets or sets a value that indicates whether silent mode should be used when a command is executed.
        /// </summary>
        /// <value>
        /// <b>true</b> if uses a silent mode for command execution; otherwise <b>false</b>.
        /// </value>
        public bool SilentMode { get; set; }
        #endregion

        #endregion

        #region public override methods
        
        #region [public] {override} (string) ToString(): Returns a string that represents the current object
        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A <see cref="string"/> that represents the current object.
        /// </returns>
        public override string ToString() => $"{(SilentMode ? "Use silent mode activated": "Use silent mode deactivated")}";
        #endregion

        #endregion
    }
}
