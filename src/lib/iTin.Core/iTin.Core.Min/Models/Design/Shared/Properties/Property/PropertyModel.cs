
namespace iTin.Core.Min.Models
{
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    /// <summary>
    /// Defines a user custom property.
    /// </summary>
    public partial class PropertyModel : ICloneable
    {
        #region private members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private PropertiesModelCollection _owner;
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

        #region public properties

        #region [public] (string) Name: Gets or sets the custom property name
        /// <summary>
        /// Gets or sets the custom property name.
        /// </summary>
        /// <value>
        /// Property name
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        public string Name { get; set; }
        #endregion

        #region [public] (string) Value: Gets or sets the custom property value
        /// <summary>
        /// Gets or sets the custom property value.
        /// </summary>
        /// <value>
        /// Property value
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        public string Value { get; set; }
        #endregion

        #region [public] (PropertiesModelCollection) Owner: Gets the element that owns this
        /// <summary>
        /// 
        /// </summary>
        [XmlIgnore]
        public PropertiesModelCollection Owner => _owner;
        #endregion

        #endregion

        #region public methods

        #region [public] (PropertyModel) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public PropertyModel Clone() => (PropertyModel)MemberwiseClone();
        #endregion

        #region [public] (void) SetOwner(PropertiesModelCollection): Sets the element that owns this
        internal void SetOwner(PropertiesModelCollection reference) => _owner = reference;
        #endregion

        #endregion

        #region public overrides methods

        #region [public] {override} (string) ToString(): Returns a string that represents the current object
        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents the current object.
        /// </returns>
        public override string ToString() => $"Name=\"{Name}\"";
        #endregion

        #endregion
    }
}
