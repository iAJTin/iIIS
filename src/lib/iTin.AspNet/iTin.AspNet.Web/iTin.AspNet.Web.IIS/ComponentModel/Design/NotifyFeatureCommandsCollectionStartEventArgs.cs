
using System;

namespace iTin.AspNet.Web.IIS.ComponentModel.Design;

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
        InternetInformationServerIsPresent = commands?.InternetInformationServerIsPresent ?? false;
    }

    /// <summary>
    /// Gets a value that indicates if Internet Information Services (IIS) is present in this system.
    /// </summary>
    /// <value>
    /// <b>true</b> if Internet Information Server (IIS) is present on your system; Otherwise <b>false</b>.
    /// </value>
    public bool InternetInformationServerIsPresent { get; }
}
