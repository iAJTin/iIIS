
using System;

using iTin.AspNet.Web.IIS.ComponentModel.Enums;

namespace iTin.AspNet.Web.IIS.ComponentModel.Design;

/// <summary>
/// Provides data to the <see cref="FeatureCommand.NotifyFeatureCommandExecuting"/> event of an <see cref="FeatureCommand"/> object.
/// </summary>
public class NotifyFeatureCommandExecutingEventArgs : EventArgs
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NotifyFeatureCommandExecutedEventArgs"/> class.
    /// </summary>
    /// <param name="command">Feature to be processed</param>
    public NotifyFeatureCommandExecutingEventArgs(ICommand command)
    {
        Feature = ((FeatureCommand) command).Feature;
    }

    /// <summary>
    /// Gets a value that represents the feature to be processed.
    /// </summary>
    /// <value>
    /// One of the values of the <see cref="IISFeature"/> enumeration that represents the feature to be processed.
    /// </value>
    public IISFeature Feature { get; }
}
