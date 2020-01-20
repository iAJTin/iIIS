
namespace Syntec.AspNet.Web.IIS.ComponentModel
{
    using System;
    using System.Diagnostics;

    using Syntec.Core;
    using Syntec.Core.ComponentModel;
    using Syntec.Core.Helpers;

    using Design;
    using Enums;

    /// <summary>
    /// Interface specialization <see cref="T:Syntec.AspNet.Web.IIS.ComponentModel.ICommand"/>.
    /// Class that defines a command that installs an <b>Internet Information Services (IIS)</b> feature.
    /// </summary>
    public class GenericCommand : ICommand
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
        /// A <see cref="T:System.String"/> that contains the command optional arguments.
        /// </value>
        public string Arguments { get; set; }
        #endregion

        #region [public] (string) Command: Gets command to executes
        /// <summary>
        /// Gets command to executes.
        /// </summary>
        /// <value>
        /// A <see cref="T:System.String"/> that contains the command to executes.
        /// </value>
        public string Command => $"/NoRestart /online /enable-feature /featurename:{Feature.GetDescription()}";
        #endregion

        #region [public] (string) Program: Gets or sets the program responsible for executing the command
        /// <summary>
        /// Gets or sets the program responsible for executing the command.
        /// </summary>
        /// <value>
        /// A <see cref="T:System.String"/> that program responsible for executing the command.
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
                string runResult = Run("dism", Arguments == null ? Command : $"{Command} /{Arguments}");
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
        /// Gets the <b>Internet Information Services (IIS)</b> <see cref="T:Syntec.AspNet.Web.IIS.ComponentModel.Enums.IISFeature"/> to process.
        /// </summary>
        /// <value>
        /// A <see cref="T:System.String"/> that contains the command to executes.
        /// </value>
        public IISFeature Feature { get; private set; }
        #endregion

        #endregion

        #region public static methods

        #region [public] {static} (FeatureCommand) Create(string, string = null): Create a command for the specified feature and additional arguments
        /// <summary>
        /// Create a command for the specified feature and additional arguments, If no argument is specified its default value will be an empty string.
        /// </summary>
        /// <param name="program">Feature to use</param>
        /// <param name="arguments">Arguments to use</param>
        /// <returns>
        /// A reference to a new <see cref="T:Syntec.AspNet.Web.IIS.ComponentModel.FeatureCommand"/> associated with the specified feature.
        /// </returns>
        public static GenericCommand Create(string program, string arguments = null) => new GenericCommand { Program ="dism", Arguments = arguments };
        #endregion

        #endregion

        #region public override methods

        #region [public] {override} (string) ToString(): Returns a string that represents the current object
        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current object.
        /// </returns>
        public override string ToString() => $"{Program} {(string.IsNullOrEmpty(Arguments) ? Command : $"{Command} /{Arguments}")}";
        #endregion

        #endregion

        #region protected virtual methods

        #region [protected] {virtual} (void) OnNotifyFeatureCommandExecuted(NotifyFeatureCommandExecutedEventArgs): Generates the NotifyFeatureCommandExecuted event
        /// <summary>
        /// Generates the <see cref="E:Syntec.AspNet.Web.IIS.ComponentModel.FeatureCommand.NotifyFeatureCommandExecuted"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:Syntec.AspNet.Web.IIS.ComponentModel.Design.NotifyFeatureCommandExecutedEventArgs"/> with the event data.</param>
        protected virtual void OnNotifyFeatureCommandExecuted(NotifyFeatureCommandExecutedEventArgs e) => NotifyFeatureCommandExecuted?.Invoke(this, e);
        #endregion

        #endregion

        #region private static methods

        private static string Run(string fileName, string arguments)
        {
            using (var process =
                Process.Start(
                    new ProcessStartInfo
                    {
                        FileName = fileName,
                        Arguments = arguments,
                        CreateNoWindow = true,
                        WindowStyle = ProcessWindowStyle.Hidden,
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                    }))
            {
                process.WaitForExit();
                return process.StandardOutput.ReadToEnd();
            }
        }

        #endregion
    }
}
