
namespace iTin.AspNet.Web.IIS.ComponentModel.Design
{
    using System;
    using System.Text;

    using iTin.Core.Min.ComponentModel;

    using Enums;

    /// <summary>
    /// Provides data to the <see cref="FeatureCommand.NotifyFeatureCommandExecuted"/> event of an <see cref="FeatureCommand"/> object.
    /// </summary>
    public class NotifyFeatureCommandExecutedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotifyFeatureCommandExecutedEventArgs"/> class.
        /// </summary>
        /// <param name="command">Current command</param>
        /// <param name="programResult">Program execution result</param>
        /// <param name="operationResult">Command execution result</param>
        public NotifyFeatureCommandExecutedEventArgs(ICommand command, StringBuilder programResult, IResult operationResult)
        {
            Command = command;
            Result = operationResult;
            Feature = ((FeatureCommand)command).Feature;
            ProgramResult = programResult;
        }

        /// <summary>
        /// Gets a value that contains the command execution result.
        /// </summary>
        /// <value>
        /// Operation result
        /// </value>
        public ICommand Command { get; }

        /// <summary>
        /// Gets a value that contains the command execution result.
        /// </summary>
        /// <value>
        /// Operation result
        /// </value>
        public IResult Result { get; }

        /// <summary>
        /// Gets a value that represents the processed feature.
        /// </summary>
        /// <value>
        /// One of the values of the <see cref="IISFeature"/> enumeration that represents the processed feature.
        /// </value>
        public IISFeature Feature { get; }

        /// <summary>
        /// Gets a value that contains the result produced by the native program execution.
        /// </summary>
        /// <value>
        /// A <see cref="StringBuilder"/> containing the result produced by the native program execution.
        /// </value>
        public StringBuilder ProgramResult { get; }
    }
}
