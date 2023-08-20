
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.AspNet.Web.IIS.ComponentModel.Enums;
using iTin.Core.Helpers;

namespace iTin.AspNet.Web.IIS.Model;

/// <summary>
/// Represents a <b>Internet Information Services</b> feature.
/// </summary>
/// <remarks>
/// <para>Belongs to: <b><c>Features</c></b>. For more information, please see <see cref="FeaturesModelCollection"/>.</para>
/// <para>
/// <code lang="xml" title="IIIS Definition Usage">
/// <![CDATA[
/// <?xml version="1.0" encoding="utf-8">
/// <IIS xmlns = "http://schemas.itin.com/utilities/iis/configurator/v1.0">
///   <Configuration>
///     <Features>
///       <Feature Name= "WebServer"/>
///       <Feature Name="CommonHttpFeatures"/>
///       <Feature Name= "HttpErrors"/>
///     </Features>
///   </Configuration>
/// </IIS >
/// ]]>
/// </code>
/// </para>
/// <para><b>Attributes</b></para>
/// <list type="table">
///   <listheader>
///     <term>Attribute</term>
///     <description>Description</description>
///   </listheader>
///   <item>
///     <term><see cref="Name"/></term> 
///     <description>Represents a Internet Information Services Feature. For more information, please see <see cref="Name"/></description>
///   </item>
/// </list>
/// <para><b>Elements</b></para>
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
public partial class FeatureModel : ICloneable
{
    #region private members
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private IISFeature _name;
    #endregion

    #region interfaces

    #region ICloneable

    #region private methods

    /// <inheritdoc />
    /// <summary>
    /// Creates a new object that is a copy of the current instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    object ICloneable.Clone() => Clone();

    #endregion

    #endregion

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets the feature's name.
    /// </summary>
    /// <value>
    /// One of the <see cref="IISFeature"/> enumeration values.
    /// </value>
    /// <para>
    /// <code lang="xml" title="SIIS Definition Usage">
    /// <![CDATA[
    /// ...
    /// ...
    /// <Features>
    ///   <Feature Name = "WebServer" | "CommonHttpFeatures" | "HttpErrors" | "HttpRedirect" | "HttpErrors"| .../>
    /// </Features>
    /// ...
    /// ...
    /// ]]>
    /// </code>
    /// </para>
    [JsonProperty]
    [XmlAttribute]
    public IISFeature Name
    {
        get => _name;
        set
        {
            SentinelHelper.IsEnumValid(_name);

            _name = value;
        }
    }

    /// <summary>
    /// Gets the element that acts as the owner of this <see cref="FeatureModel"/>.
    /// </summary>
    /// <value>
    /// The <see cref="FeaturesModelCollection"/> that currently owns this <see cref="FeatureModel"/>.
    /// </value>
    [XmlIgnore]
    [Browsable(false)]
    public FeaturesModelCollection Owner { get; private set; }

    #endregion

    #region public methods

    /// <summary>
    /// Creates in-depth copy of this instance.
    /// </summary>
    /// <returns>
    /// In-depth copy of this <see cref="FeatureModel"/> instance.
    /// </returns>
    public FeatureModel Clone() => (FeatureModel)MemberwiseClone();

    #endregion

    #region internal methods

    /// <summary>
    /// Sets the <see cref="FeaturesModelCollection"/> element that acts as the owner of this <see cref="FeatureModel"/> item.
    /// </summary>
    /// <param name="owner">A <see cref="FeaturesModelCollection"/> reference</param>
    internal void SetOwner(FeaturesModelCollection owner) => Owner = owner;

    #endregion
}
