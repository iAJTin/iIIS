
using System;

using Newtonsoft.Json;

using iTin.Core.Helpers;

namespace iTin.AspNet.Web.IIS.Model;

/// <summary>
/// Collection of Internet Information Services Feature. Each element defines a feature.
/// </summary>
/// <remarks>
/// <para>
/// Belongs to: <b><c>Configuration</c></b>. For more information, please see <see cref="ConfigurationModel"/>.
/// </para>
/// <para>
/// <code lang="xml" title="IIIS Definition Usage">
/// <![CDATA[
/// <?xml version="1.0" encoding="utf-8">
/// <IIS xmlns = "http://schemas.itin.com/utilities/iis/configurator/v1.0">
///   <Configuration>
///     <Features>
///       <Feature/>
///     </Features>
///   </Configuration>
/// </IIS >
/// ]]>
/// </code>
/// </para>
/// <para><strong>Elements</strong></para>
/// <list type="table">
///   <listheader>
///     <term>Element</term>
///     <description>Description</description>
///   </listheader>
///   <item>
///     <term>Feature</term> 
///     <description>Represents a Internet Information Services Feature. For more information, please see <see cref="FeatureModel"/></description>
///   </item>
/// </list>
/// </remarks>
[JsonArray]
public partial class FeaturesModelCollection : ICloneable
{
    #region constructor/s

    /// <summary>
    /// Initialize a new instance of the <see cref="FeaturesModelCollection"/> class
    /// </summary>
    /// <param name="parent">Reference to the parent of this <see cref="FeaturesModelCollection"/></param>
    public FeaturesModelCollection(ConfigurationModel parent) : base(parent)
    {
    }

    #endregion

    #region interfaces

    #region ICloneable

    #region private methods

    /// <inheritdoc />
    object ICloneable.Clone() => Clone();

    #endregion

    #endregion

    #endregion

    #region public methods

    /// <summary>
    /// Creates in-depth copy of this instance.
    /// </summary>
    /// <returns>
    /// In-depth copy of this <see cref="FeaturesModelCollection"/> instance.
    /// </returns>
    public FeaturesModelCollection Clone()
    {
        var clonned = (FeaturesModelCollection)MemberwiseClone();
        clonned.Properties = Properties.Clone();

        return clonned;
    }

    #endregion

    #region public override methods

    /// <summary>
    /// Returns the <see cref="FeatureModel"/> reference using the value of the <see cref="FeatureModel.Name"/> field. If you don't find any item, return <b>null</b>.
    /// </summary>
    /// <param name="name">Feature name.</param>
    /// <returns>
    /// A <see cref="FeatureModel"/> reference.
    /// </returns>
    public override FeatureModel GetBy(string name) => Find(item => item.Name.Equals(name));

    #endregion

    #region protected override methods

    /// <summary>
    /// Sets the element that acts as the owner of a <see cref="FeatureModel"/> item.
    /// </summary>
    /// <param name="item">SubMenu item reference</param>
    protected override void SetOwner(FeatureModel item)
    {
        SentinelHelper.ArgumentNull(item, nameof(item));

        item.SetOwner(this);
    }

    #endregion
}
