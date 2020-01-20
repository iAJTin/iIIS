
namespace iTin.AspNet.Web.IIS.ComponentModel.Design
{
    using System;

    /// <summary>
    /// Provides data to the <see cref="FeatureCommandsCollection.NotifyFeatureCommandsCollectionStart"/> event of an <see cref="FeatureCommandsCollection"/> object.
    /// </summary>
    public class NotifyFeatureCommandsCollectionStartEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotifyFeatureCommandsCollectionStartEventArgs"/> class.
        /// </summary>
        /// <param name="commands">Reference to commands collection</param>
        public NotifyFeatureCommandsCollectionStartEventArgs(FeatureCommandsCollection commands)
        {
            Commands = commands;
        }


        /// <summary>
        /// Gets the total commands into a collection.
        /// </summary>
        /// <value>
        /// A <see cref="FeatureCommandsCollection"/> reference that contains the commands collection.
        /// </value>
        public FeatureCommandsCollection Commands { get; }
    }
}
