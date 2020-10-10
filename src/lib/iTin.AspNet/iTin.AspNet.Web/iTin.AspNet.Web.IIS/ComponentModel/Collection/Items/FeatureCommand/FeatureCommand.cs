
namespace iTin.AspNet.Web.IIS.ComponentModel
{
    using System;
    using System.Text;
    using System.Threading.Tasks;

    using iTin.Core;
    using iTin.Core.ComponentModel;
    using iTin.Core.ComponentModel.Results;
    using iTin.Core.Helpers;

    using Design;
    using Enums;

    /// <summary>
    /// Interface specialization <see cref="ICommand"/>.
    /// Class that defines a command that installs an <b>Internet Information Services (IIS)</b> feature.
    /// </summary>
    public sealed class FeatureCommand : ICommand
    {
        #region public events

        #region [public] {event} (EventHandler<NotifyFeatureCommandExecutedEventArgs>) NotifyFeatureCommandExecuted: Occurs when the FeatureCommand associated with a feature changed has been executed
        /// <summary>
        /// Occurs when the <see cref="FeatureCommand"/> associated with a feature changed has been executed.
        /// </summary>
        public event EventHandler<NotifyFeatureCommandExecutedEventArgs> NotifyFeatureCommandExecuted;
        #endregion

        #region [public] {event} (EventHandler<NotifyFeatureCommandExecutingEventArgs>) NotifyFeatureCommandExecuting: Occurs when the FeatureCommand starts with the command associated with a modified feature
        /// <summary>
        /// Occurs when the <see cref="FeatureCommand"/> starts with the command associated with a modified feature.
        /// </summary>
        public event EventHandler<NotifyFeatureCommandExecutingEventArgs> NotifyFeatureCommandExecuting;
        #endregion

        #endregion

        #region interfaces

        #region ICloneable

        #region private methods

        #region [private] (object) Clone(): Create a new object copied from the current instance
        /// <summary>
        /// Create a new object copied from the current instance.
        /// </summary>
        /// <returns>
        /// New object that is a copy of this instance.
        /// </returns>
        object ICloneable.Clone() => Clone();
        #endregion

        #endregion

        #endregion

        #region ICommand

        #region public properties

        #region [public] (string) Arguments: Gets or sets command optional arguments
        /// <summary>
        /// Gets or sets command optional arguments.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> that contains the command optional arguments.
        /// </value>
        public string Arguments { get; set; }
        #endregion

        #region [public] (string) Command: Gets command to executes
        /// <summary>
        /// Gets command to executes.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> that contains the command to executes.
        /// </value>
        public string Command
        {
            get
            {
                if (Options == null)
                {
                    return $"/NoRestart /Online /Quiet /Enable-Feature /FeatureName:{Feature.GetDescription()}";
                }

                return Options.SilentMode
                    ? $"/NoRestart /Online /Quiet /Enable-Feature /FeatureName:{Feature.GetDescription()}"
                    : $"/NoRestart /Online /Enable-Feature /FeatureName:{Feature.GetDescription()}";
            }
        } 
        #endregion

        #region [public] (CommandOptions) Options: Gets or sets the command options
        /// <summary>
        /// Gets or sets the command options.
        /// </summary>
        /// <value>
        /// A <see cref="CommandOptions"/> reference that contains command options.
        /// </value>
        public CommandOptions Options { get; set; }
        #endregion

        #region [public] (string) Program: Gets or sets the program responsible for executing the command
        /// <summary>
        /// Gets or sets the program responsible for executing the command.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> that program responsible for executing the command.
        /// </value>
        public string Program { get; set; }
        #endregion

        #endregion

        #region public async methods

        #region [public] {async} (Task<IResult>) ExecuteAsync(): Executes the command asynchronously
        /// <summary>
        /// Executes the command asynchronously.
        /// </summary>
        /// <returns>
        /// Operation result
        /// </returns>
        public async Task<IResult> ExecuteAsync()
        {
            try
            {
                OnNotifyFeatureCommandExecuting(new NotifyFeatureCommandExecutingEventArgs(this));
                StringBuilder programResult = await SystemHelper.RunCommandAsync("dism", Arguments == null ? Command : $"{Command} /{Arguments}");
                OnNotifyFeatureCommandExecuted(new NotifyFeatureCommandExecutedEventArgs(this, programResult, BooleanResult.SuccessResult));

                return await Task.FromResult(BooleanResult.SuccessResult);
            }
            catch (Exception ex)
            {
                return await Task.FromResult<IResult>(BooleanResult.FromException(ex));
            }
        }
        #endregion

        #endregion

        #region public methods

        #region [public] (IResult) Execute(): Executes the command synchronously
        /// <summary>
        /// Executes the command synchronously.
        /// </summary>
        /// <returns>
        /// Operation result
        /// </returns>
        public IResult Execute()
        {
            try
            {
                OnNotifyFeatureCommandExecuting(new NotifyFeatureCommandExecutingEventArgs(this));
                StringBuilder programResult = SystemHelper.RunCommand("dism", Arguments == null ? Command : $"{Command} /{Arguments}");
                OnNotifyFeatureCommandExecuted(new NotifyFeatureCommandExecutedEventArgs(this, programResult, BooleanResult.SuccessResult));

                return BooleanResult.SuccessResult;
            }
            catch(Exception ex)
            {
                return BooleanResult.FromException(ex);
            }
        }
        #endregion

        #endregion

        #endregion

        #region IEquatable

        #region public methods

        #region [public] (bool) Equals(ICommand): Indicates whether the current object is equal to another object of the same type.
        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// <b>true</b> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <b>false</b>.
        /// </returns>
        public bool Equals(ICommand other) => other != null && other.Equals((object)this);
        #endregion

        #endregion

        #endregion

        #endregion

        #region public properties

        #region [public] (IISFeature) Feature: Gets the Internet Information Services (IIS) feature to process
        /// <summary>
        /// Gets the <b>Internet Information Services (IIS)</b> <see cref="IISFeature"/> to process.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> that contains the command to executes.
        /// </value>
        public IISFeature Feature { get; private set; }
        #endregion

        #endregion

        #region public static methods

        #region [public] {static} (FeatureCommand) Create(IISFeature, string = null, CommandOptions = null): Create a command for the specified feature and additional arguments
        /// <summary>
        /// Create a command for the specified feature and additional arguments, If no argument is specified its default value will be an empty string.
        /// </summary>
        /// <param name="feature">Feature to use</param>
        /// <param name="arguments">Arguments to use</param>
        /// <param name="options">Command options to use</param>
        /// <returns>
        /// A reference to a new <see cref="FeatureCommand"/> associated with the specified feature.
        /// </returns>
        public static FeatureCommand Create(IISFeature feature, string arguments = null, CommandOptions options = null) => Create(feature.GetDescription(), arguments, options);
        #endregion

        #region [public] {static} (FeatureCommand) Create(string, string = null, CommandOptions = null): Create a command for the specified feature and additional arguments
        /// <summary>
        /// Create a command for the specified feature and additional arguments, If no argument is specified its default value will be an empty string.
        /// </summary>
        /// <param name="feature">Feature to use</param>
        /// <param name="arguments">Arguments to use</param>
        /// <param name="options">Command options to use</param>
        /// <returns>
        /// A reference to a new <see cref="FeatureCommand"/> associated with the specified feature.
        /// </returns>
        public static FeatureCommand Create(string feature, string arguments = null, CommandOptions options = null) =>
            new FeatureCommand
            {
                Arguments = arguments,
                Program = OsProgram.Dism.GetDescription(),
                Options = options ?? CommandOptions.SilentModeActivated,
                Feature = (IISFeature) EnumHelper.CreateEnumTypeFromDescriptionAttribute<IISFeature>(feature)
            };
        #endregion

        #endregion

        #region public methods

        #region [public] (FeatureCommand) Clone(): Clones this instance.
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public FeatureCommand Clone() => (FeatureCommand)MemberwiseClone();
        #endregion

        #endregion

        #region public override methods

        #region [public] {override} (int) GetHashCode(): Returns a value that represents the hash code for this class
        /// <summary>
        /// Returns a value that represents the hash code for this class.
        /// </summary>
        /// <returns>
        /// Hash code for this class.
        /// </returns>
        public override int GetHashCode() => ToString().GetHashCode();
        #endregion

        #region [public] {override} (bool) Equals(object): Returns a value that indicates whether this class is equal to another
        /// <summary>
        /// Returns a value that indicates whether this class is equal to another.
        /// </summary>
        /// <param name="obj">Class with which to compare.</param>
        /// <returns>
        /// Results equality comparison.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is FeatureCommand))
            {
                return false;
            }

            var other = (FeatureCommand)obj;

            if (other.Arguments == null && Arguments != null || other.Arguments != null && Arguments == null)
            {
                return false;
            }

            if (other.Arguments == null && Arguments == null)
            {
                return
                    other.Command.Equals(Command, StringComparison.OrdinalIgnoreCase) &&
                    other.Program.Equals(Program, StringComparison.OrdinalIgnoreCase) &&
                    other.Feature.Equals(Feature);
            }

            return
                other.Arguments.Equals(Arguments, StringComparison.OrdinalIgnoreCase) &&
                other.Command.Equals(Command, StringComparison.OrdinalIgnoreCase) &&
                other.Program.Equals(Program, StringComparison.OrdinalIgnoreCase) &&
                other.Feature.Equals(Feature);
        }
        #endregion

        #region [public] {override} (string) ToString(): Returns a string that represents the current object
        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A <see cref="string"/> that represents the current object.
        /// </returns>
        public override string ToString() => $"{Program} {(string.IsNullOrEmpty(Arguments) ? Command : $"{Command} /{Arguments}")}";
        #endregion

        #endregion

        #region protected virtual methods

        #region [protected] {virtual} (void) OnNotifyFeatureCommandExecuted(NotifyFeatureCommandExecutedEventArgs): Raises the NotifyFeatureCommandExecuted event
        /// <summary>
        /// Raises the <see cref="NotifyFeatureCommandExecuted"/> event.
        /// </summary>
        /// <param name="e">A <see cref="NotifyFeatureCommandExecutedEventArgs"/> that contains the event data.</param>
        private void OnNotifyFeatureCommandExecuted(NotifyFeatureCommandExecutedEventArgs e) => NotifyFeatureCommandExecuted?.Invoke(this, e);
        #endregion

        #region [protected] {virtual} (void) OnNotifyFeatureCommandExecuting(NotifyFeatureCommandExecutingEventArgs): Raises the NotifyFeatureCommandExecuting event
        /// <summary>
        /// Raises the <see cref="NotifyFeatureCommandExecuting"/> event.
        /// </summary>
        /// <param name="e">A <see cref="NotifyFeatureCommandExecutingEventArgs"/> that contains the event data.</param>
        private void OnNotifyFeatureCommandExecuting(NotifyFeatureCommandExecutingEventArgs e) => NotifyFeatureCommandExecuting?.Invoke(this, e);
        #endregion

        #endregion
    }
}
