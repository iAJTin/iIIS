
namespace iTin.AspNet.Web.IIS.ComponentModel.Design
{
    using System;

    using iTin.Core.ComponentModel;

    /// <summary>
    /// Provides data to the <see cref="FeatureCommandsCollection.NotifyFeatureCommandsCollectionFinish"/> event of an <see cref="FeatureCommandsCollection"/> object.
    /// </summary>
    public class NotifyFeatureCommandsCollectionFinishEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotifyFeatureCommandsCollectionFinishEventArgs"/> class.
        /// </summary>
        public NotifyFeatureCommandsCollectionFinishEventArgs(IResult processResult)
        {
            Result = processResult;
        }

        /// <summary>
        /// Gets a value that contains the commands execution result.
        /// </summary>
        /// <value>
        /// Operation result
        /// </value>
        public IResult Result { get; }
    }
}
