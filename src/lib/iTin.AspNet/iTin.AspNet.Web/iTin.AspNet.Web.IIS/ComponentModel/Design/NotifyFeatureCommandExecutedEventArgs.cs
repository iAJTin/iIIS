
namespace iTin.AspNet.Web.IIS.ComponentModel.Design
{
    using System;

    using iTin.Core.ComponentModel;

    using ComponentModel.Enums;

    /// <summary>
    /// Provides data to the <see cref="FeatureCommand.NotifyFeatureCommandExecuted"/> event of an <see cref="FeatureCommand"/> object.
    /// </summary>
    public class NotifyFeatureCommandExecutedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotifyFeatureCommandExecutedEventArgs"/> class.
        /// </summary>
        /// <param name="feature">Feature processed</param>
        /// <param name="commandResult">Command execution result</param>
        /// <param name="runResult">Program execution result</param>
        public NotifyFeatureCommandExecutedEventArgs(IISFeature feature, IResult commandResult, string runResult)
        {
            Feature = feature;
            RunResult = runResult;
            Result = commandResult;
        }

        /// <summary>
        /// Gets a value that contains the command execution result.
        /// </summary>
        /// <value>
        /// Operation result
        /// </value>
        public IResult Result { get; private set; }

        /// <summary>
        /// Gets a value that represents the processed feature.
        /// </summary>
        /// <value>
        /// One of the values of the <see cref="IISFeature"/> enumeration that represents the processed feature.
        /// </value>
        public IISFeature Feature { get; private set; }

        /// <summary>
        /// Gets a value that contains the result produced by the native program execution.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> containing the result produced by the native program execution.
        /// </value>
        public string RunResult { get; private set; }
    }
}
