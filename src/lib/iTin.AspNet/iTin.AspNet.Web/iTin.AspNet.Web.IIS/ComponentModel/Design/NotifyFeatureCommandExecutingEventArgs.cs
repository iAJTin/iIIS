
namespace iTin.AspNet.Web.IIS.ComponentModel.Design
{
    using System;

    using ComponentModel.Enums;

    /// <summary>
    /// Provides data to the <see cref="FeatureCommand.NotifyFeatureCommandExecuting"/> event of an <see cref="FeatureCommand"/> object.
    /// </summary>
    public class NotifyFeatureCommandExecutingEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotifyFeatureCommandExecutedEventArgs"/> class.
        /// </summary>
        /// <param name="feature">Feature to be processed</param>
        public NotifyFeatureCommandExecutingEventArgs(IISFeature feature)
        {
            Feature = feature;
        }

        /// <summary>
        /// Gets a value that represents the feature to be processed.
        /// </summary>
        /// <value>
        /// One of the values of the <see cref="IISFeature"/> enumeration that represents the feature to be processed.
        /// </value>
        public IISFeature Feature { get; private set; }
    }
}
