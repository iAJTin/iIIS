
using System;

using iTin.AspNet.Web.IIS.ComponentModel.Enums;

namespace iTin.AspNet.Web.IIS.ComponentModel.Design
{
    /// <summary>
    /// Provides data to the <see cref="FeatureCommandsCollection.NotifyFeatureCommandCollectionExecuted"/> event of an <see cref="FeatureCommandsCollection"/> object.
    /// </summary>
    public class NotifyFeatureCommandCollectionExecutedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotifyFeatureCommandCollectionExecutedEventArgs"/> class.
        /// </summary>
        /// <param name="index">Command index into a collection</param>
        /// <param name="count">Total commands into a collection</param>
        /// <param name="feature">Feature processed</param>
        /// <param name="nfce">Program execution detail</param>
        public NotifyFeatureCommandCollectionExecutedEventArgs(int index, int count, IISFeature feature, NotifyFeatureCommandExecutedEventArgs nfce)
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
        /// A <see cref="Int32"/> that contains current command index into a collection.
        /// </value>
        public int Index { get; }

        /// <summary>
        /// Gets the total commands into a collection.
        /// </summary>
        /// <value>
        /// A <see cref="Int32"/> that contains the total commands into a collection.
        /// </value>
        public int Total { get; }

        /// <summary>
        /// Gets a value that represents the processed feature.
        /// </summary>
        /// <value>
        /// One of the values of the <see cref="IISFeature"/> enumeration that represents the processed feature.
        /// </value>
        public IISFeature Feature { get; }

        /// <summary>
        /// Gets a value that represents the program execution detail
        /// </summary>
        /// <value>
        /// A <see cref="NotifyFeatureCommandExecutedEventArgs"/> reference.
        /// </value>
        public NotifyFeatureCommandExecutedEventArgs Detail { get; }
    }
}
