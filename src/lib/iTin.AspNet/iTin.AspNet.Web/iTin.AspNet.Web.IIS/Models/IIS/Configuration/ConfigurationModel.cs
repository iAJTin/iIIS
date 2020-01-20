
namespace iTin.AspNet.Web.IIS.Model
{
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    /// <summary>
    /// This class allow defines the features collection to install in a <b>Internet Information Services</b>.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Belongs to: <b><c>IIS</c></b>. For more information, please see <see cref="IISModel"/>.
    /// </para>
    /// <para>Represents <b>iTin Internet Information Services (SIIS)</b> root element of a configuration file.
    /// <code lang="xml" title="SIIS Definition Usage">
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
    /// <para><b>Elements</b></para>
    /// <list type="table">
    ///   <listheader>
    ///     <term>Element</term>
    ///     <description>Description</description>
    ///   </listheader>
    ///   <item>
    ///     <term><see cref="Features"/></term> 
    ///     <description>Reference that contains the features collection to install in a <b>Internet Information Services</b>.</description>
    ///   </item>
    /// </list>
    /// </remarks>
    public partial class ConfigurationModel : ICloneable
    {
        #region private members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private FeaturesModelCollection _features;
        #endregion

        #region interfaces

        #region ICloneable

        #region private methods

        #region [private] (object) Clone(): Creates a new object that is a copy of the current instance
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

        #endregion

        #region public readonly properties

        #region [public] (bool) FeaturesSpecified: Gets a value that indicates to the serializer if the item referenced is to be included
        /// <summary>
        /// Gets a value that indicates to the serializer if the item referenced is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool FeaturesSpecified => !Features.IsDefault;
        #endregion

        #endregion

        #region public properties

        #region [public] (FeaturesModelCollection) Features: Gets or sets a reference that contains a features collection
        /// <summary>
        /// Gets or sets a reference that contains a features collection.
        /// </summary>
        /// <value>
        /// A <see cref="FeaturesModelCollection"/> reference that contains a features collection.
        /// </value>
        /// <remarks>
        /// <code lang="xml" title="SIIS Definition Usage">
        /// <![CDATA[
        /// <Configuration>
        ///   <Features>
        ///     <Feature Name="WebServer"/>
        ///     <Feature Name="ASPNET"/>
        ///   </Features>
        /// </Configuration>
        /// ]]>
        /// </code>
        /// </remarks>
        [XmlArrayItem("Feature", typeof(FeatureModel))]
        public FeaturesModelCollection Features
        {
            get => _features ?? (_features = new FeaturesModelCollection(this));
            set => _features = value;
        }
        #endregion

        #endregion

        #region public override properties

        #region [public] {override} (bool) IsDefault: Gets a value indicating whether this instance is the default
        /// <summary>
        /// Gets a value indicating whether this instance is the default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
        /// </value>
        public override bool IsDefault => 
            base.IsDefault && 
            Features.IsDefault;
        #endregion

        #endregion

        #region public methods

        #region [public] (ConfigurationModel) Clone(): Creates in-depth copy of this instance
        /// <summary>
        /// Creates in-depth copy of this instance.
        /// </summary>
        /// <returns>
        /// In-depth copy of this <see cref="ConfigurationModel"/> instance.
        /// </returns>
        public ConfigurationModel Clone()
        {
            var clonned = (ConfigurationModel)MemberwiseClone();
            clonned.Features = Features.Clone();
            clonned.Properties = Properties.Clone();

            return clonned;
        }
        #endregion

        #endregion
    }
}
