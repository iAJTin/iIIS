
namespace iTin.AspNet.Web.IIS.ComponentModel
{
    using System;

    using iTin.Core;
    using iTin.Core.ComponentModel;
    using iTin.Core.Helpers;

    using Design;
    using Enums;

    /// <summary>
    /// Interface specialization <see cref="ICommand"/>.
    /// Class that defines a command that installs an <b>Internet Information Services (IIS)</b> feature.
    /// </summary>
    public class FeatureCommand : ICommand
    {
        #region public events

        #region [public] {event} (EventHandler<NotifyFeatureCommandExecutedEventArgs>) NotifyFeatureCommandExecuted: Occurs when the command associated with a feature changed has been executed
        /// <summary>
        /// Occurs when the command associated with a feature changed has been executed.
        /// </summary>
        public event EventHandler<NotifyFeatureCommandExecutedEventArgs> NotifyFeatureCommandExecuted;
        #endregion

        #endregion

        #region interfaces

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
        public string Command => $"/NoRestart /online /enable-feature /featurename:{Feature.GetDescription()}";
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

        #region public methods

        #region [public] (IResult) Execute(): Executes the command
        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <returns>
        /// Operation result
        /// </returns>
        public IResult Execute()
        {
            try
            {
                string runResult = SystemHelper.RunCommand("dism", Arguments == null ? Command : $"{Command} /{Arguments}");
                OnNotifyFeatureCommandExecuted(new NotifyFeatureCommandExecutedEventArgs(Feature, ResultBase.SuccessResult, runResult));

                return ResultBase.SuccessResult;
            }
            catch
            {
                return ResultBase.ErrorResult;
            }
        }
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

        #region [public] {static} (FeatureCommand) Create(IISFeature, string = null): Create a command for the specified feature and additional arguments
        /// <summary>
        /// Create a command for the specified feature and additional arguments, If no argument is specified its default value will be an empty string.
        /// </summary>
        /// <param name="feature">Feature to use</param>
        /// <param name="arguments">Arguments to use</param>
        /// <returns>
        /// A reference to a new <see cref="FeatureCommand"/> associated with the specified feature.
        /// </returns>
        public static FeatureCommand Create(IISFeature feature, string arguments = null) => Create(feature.GetDescription(), arguments);
        #endregion

        #region [public] {static} (FeatureCommand) Create(string, string = null): Create a command for the specified feature and additional arguments
        /// <summary>
        /// Create a command for the specified feature and additional arguments, If no argument is specified its default value will be an empty string.
        /// </summary>
        /// <param name="feature">Feature to use</param>
        /// <param name="arguments">Arguments to use</param>
        /// <returns>
        /// A reference to a new <see cref="FeatureCommand"/> associated with the specified feature.
        /// </returns>
        public static FeatureCommand Create(string feature, string arguments = null) => new FeatureCommand { Program ="dism", Feature = (IISFeature)EnumHelper.CreateEnumTypeFromDescriptionAttribute<IISFeature>(feature), Arguments = arguments };
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
        public override string ToString() => $"{Program} {(string.IsNullOrEmpty(Arguments) ? Command : $"{Command} /{Arguments}")}";
        #endregion

        #endregion

        #region protected virtual methods

        #region [protected] {virtual} (void) OnNotifyFeatureCommandExecuted(NotifyFeatureCommandExecutedEventArgs): Generates the NotifyFeatureCommandExecuted event
        /// <summary>
        /// Generates the <see cref="FeatureCommand.NotifyFeatureCommandExecuted"/> event.
        /// </summary>
        /// <param name="e">A <see cref="NotifyFeatureCommandExecutedEventArgs"/> with the event data.</param>
        protected virtual void OnNotifyFeatureCommandExecuted(NotifyFeatureCommandExecutedEventArgs e) => NotifyFeatureCommandExecuted?.Invoke(this, e);
        #endregion

        #endregion
    }
}
