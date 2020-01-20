
namespace iTin.AspNet.Web.IIS.Model
{
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    /// <summary>
    /// Root element of a <b>Syntec Internet Information Services (SIIS)</b> configuration file that contains the custom definition of <b>Internet Information Services features</b>.
    /// </summary>
    /// <remarks>
    /// <para>Represents <b>iTin Internet Information Services (SIIS)</b> root element of a configuration file.
    /// <code lang="xml" title="SIIS Definition Usage">
    /// <![CDATA[
    /// <?xml version="1.0" encoding="utf-8">
    /// <IIS xmlns = "http://schemas.itin.com/utilities/iis/configurator/v1.0">
    ///   <Configuration>
    ///     <Features>
    ///       <Feature Name="WebServer"/>
    ///       <Feature Name="CommonHttpFeatures"/>
    ///       <Feature Name="HttpErrors"/>
    ///       <Feature Name="HttpRedirect"/>
    ///       <Feature Name="NetFxExtensibility"/>
    ///       <Feature Name="HealthAndDiagnostics"/>
    ///       <Feature Name="HttpLogging"/>
    ///       <Feature Name="HttpTracing"/>
    ///       <Feature Name="Security"/>
    ///       <Feature Name="RequestFiltering"/>
    ///       <Feature Name="IPSecurity"/>
    ///       <Feature Name="Performance"/>
    ///       <Feature Name="WebServerManagementTools"/>
    ///       <Feature Name="IIS6ManagementCompatibility"/>
    ///       <Feature Name="Metabase"/>
    ///       <Feature Name="StaticContent"/>
    ///       <Feature Name="DefaultDocument"/>
    ///       <Feature Name="DirectoryBrowsing"/>
    ///       <Feature Name="ISAPIExtensions"/>
    ///       <Feature Name="ISAPIFilter"/>
    ///       <Feature Name="ASPNET"/>
    ///       <Feature Name="CustomLogging"/>
    ///       <Feature Name="BasicAuthentication"/>
    ///       <Feature Name="HttpCompressionStatic"/>
    ///       <Feature Name="ManagementConsole"/>
    ///       <Feature Name="ManagementService"/>
    ///       <Feature Name="WMICompatibility"/>
    ///       <Feature Name="LegacyScripts"/>
    ///       <Feature Name="WindowsAuthentication"/>
    ///       <Feature Name="ASPNET45"/>
    ///     </Features>
    ///   </Configuration>
    /// </IIS >
    /// ]]>
    /// </code>
    /// </para>
    /// <para><strong>Elements</strong>
    /// </para>
    /// <list type="table">
    ///   <listheader>
    ///     <term>Element</term>
    ///     <description>Description</description>
    ///   </listheader>
    ///   <item>
    ///     <term><see cref="Configuration"/></term> 
    ///     <description>Reference that contains the features collection to install in a <b>Internet Information Services</b>.</description>
    ///   </item>
    /// </list>
    /// </remarks>
    public partial class IISModel : ICloneable
    {
        #region private members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ConfigurationModel _configuration;
        #endregion

        #region constructor/s

        #region [public] IISModel(): Initialize a new instance of the class
        /// <summary>
        /// Initialize a new instance of the <see cref="IISModel"/> class.
        /// </summary>
        public IISModel()
        {
        }
        #endregion

        #endregion

        #region interfaces

        #region ICloneable

        #region private methods

        #region [private] (object) Clone(): Create a new object copied from the current instance
        /// <summary>
        /// Create a new object copied from the current instance.
        /// </summary>
        /// <returns>
        /// New object that is a copy of this instance.
        /// </returns>
        object ICloneable.Clone() => Clone();
        #endregion

        #endregion

        #endregion

        #endregion

        #region public readonly properties

        #region [public] (bool) ConfigurationSpecified: Gets a value that indicates to the serializer if the item referenced is to be included
        /// <summary>
        /// Gets a value that indicates to the serializer if the item referenced is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool ConfigurationSpecified => !Configuration.IsDefault;
        #endregion

        #endregion

        #region public properties

        #region [public] (Configuration) Configuration: Gets or sets a value that contains the configuration of a Internet Information Services
        /// <summary>
        /// Gets or sets a value that contains the configuration of a <b>Internet Information Services</b>.
        /// </summary>
        /// <value>
        /// A <see cref="ConfigurationModel"/> that contains the configuration of a <b>Internet Information Services</b>.
        /// </value>
        /// <remarks>
        /// <code lang="xml" title="SIIS Definition Usage">
        /// <![CDATA[
        /// <Configuration/>
        ///   <Features/>
        /// </Configuration>
        /// ]]>
        /// </code>
        /// </remarks>
        [XmlElement]
        public ConfigurationModel Configuration
        {
            get => _configuration ?? (_configuration = new ConfigurationModel());
            set => _configuration = value;
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
        public override bool IsDefault => base.IsDefault && Configuration.IsDefault;
        #endregion

        #endregion

        #region public methods

        #region [public] (IISModel) Clone(): Creates in-depth copy of this instance
        /// <summary>
        /// Creates in-depth copy of this instance.
        /// </summary>
        /// <returns>
        /// In-depth copy of this <see cref="IISModel"/> instance.
        /// </returns>
        public IISModel Clone()
        {
            var clonned = (IISModel)MemberwiseClone();
            clonned.Configuration = Configuration.Clone();
            clonned.Properties = Properties.Clone();

            return clonned;
        }
        #endregion

        #endregion
    }
}
