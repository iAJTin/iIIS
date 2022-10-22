
using System;

using iTin.AspNet.Web.IIS.ComponentModel.Enums;

namespace iTin.AspNet.Web.IIS.ComponentModel.Design
{
    /// <summary>
    /// Provides data to the <see cref="FeatureCommandsCollection.NotifyFeatureCommandCollectionExecuting"/> event of an <see cref="FeatureCommandsCollection"/> object.
    /// </summary>
    public class NotifyFeatureCommandCollectionExecutingEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotifyFeatureCommandCollectionExecutedEventArgs"/> class.
        /// </summary>
        /// <param name="index">Command index into a collection</param>
        /// <param name="count">Total commands into a collection</param>
        /// <param name="feature">Feature processed</param>
        /// <param name="nfce">Feature detaill</param>
        public NotifyFeatureCommandCollectionExecutingEventArgs(int index, int count, IISFeature feature, NotifyFeatureCommandExecutingEventArgs nfce)
        {
            Detail = nfce;
            Index = index;
            Total = count;
            Feature = feature;
        }

        /// <summary>
        /// Gets the current command index into a collection.
        /// </summary>
        /// <value>
        /// A <see cref="int"/> that contains current command index into a collection.
        /// </value>
        public int Index { get; }

        /// <summary>
        /// Gets the total commands into a collection.
        /// </summary>
        /// <value>
        /// A <see cref="int"/> that contains the total commands into a collection.
        /// </value>
        public int Total { get; }

        /// <summary>
        /// Gets a value that represents the processed feature.
        /// </summary>
        /// <value>
        /// One of the values of the <see cref="IISFeature"/> enumeration that represents the feature to be processed.
        /// </value>
        public IISFeature Feature { get; }

        /// <summary>
        /// Gets a value that represents the feature detail
        /// </summary>
        /// <value>
        /// A <see cref="NotifyFeatureCommandExecutingEventArgs"/> reference.
        /// </value>
        public NotifyFeatureCommandExecutingEventArgs Detail { get; }
    }
}
