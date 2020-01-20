
namespace iTin.AspNet.Web.IIS.Model
{
    using System;

    using Newtonsoft.Json;

    using iTin.Core.Helpers;

    /// <summary>
    /// Collection of Internet Information Services Feature. Each element defines a feature.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Belongs to: <b><c>Configuration</c></b>. For more information, please see <see cref="ConfigurationModel"/>.
    /// </para>
    /// <para>
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

        #region [public] FeaturesModelCollection(ConfigurationModel): Initialize a new instance of the class
        /// <summary>
        /// Initialize a new instance of the <see cref="FeaturesModelCollection"/> class
        /// </summary>
        /// <param name="parent">Reference to the parent of this <see cref="FeaturesModelCollection"/></param>
        public FeaturesModelCollection(ConfigurationModel parent) : base(parent)
        {
        }
        #endregion

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

        #region public methods

        #region [public] (FeaturesModelCollection) Clone(): Creates in-depth copy of this instance
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

        #endregion

        #region public override methods

        #region [public] {override} (FeatureModel) GetBy(string): Returns the BaseFieldModel reference using the value of the BaseFieldModel.Id field
        /// <summary>
        /// Returns the <see cref="FeatureModel"/> reference using the value of the <see cref="FeatureModel.Name"/> field. If you don't find any item, return <b>null</b>.
        /// </summary>
        /// <param name="name">Feature name.</param>
        /// <returns>
        /// A <see cref="FeatureModel"/> reference.
        /// </returns>
        public override FeatureModel GetBy(string name) => Find(item => item.Name.Equals(name));
        #endregion

        #endregion

        #region protected override methods

        #region [protected] {override} (void) SetOwner(FeatureModel): Sets the element that acts as the owner of a feature item
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

        #endregion
    }
}
