
namespace iTin.Core.Min.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    using iTin.Core.Min.Helpers;

    /// <summary>
    /// Defines a user custom property.
    /// </summary>
    public partial class PropertiesModelCollection : IList<PropertyModel>, ICloneable
    {
        #region private members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly List<PropertyModel> _list;
        #endregion

        #region constructor/s

        #region [public] PropertiesModelCollection(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertiesModelCollection"/> class.
        /// </summary>
        public PropertiesModelCollection()
        {
            _list = new List<PropertyModel>();
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

        #region public properties

        #region [public] (int) Count: Gets the number of elements contained in the collection
        /// <summary>
        /// Gets the number of elements contained in the <see cref="ICollection{PropertyModel}"/>.
        /// </summary>
        /// <returns>
        /// The number of elements contained in the <see cref="ICollection{PropertyModel}"/>.
        /// </returns>
        public int Count => _list.Count;
        #endregion

        #region [public] (bool) IsReadOnly: Gets a value indicating whether is a readonly collection.
        /// <inheritdoc />
        /// <summary>
        /// Gets a value indicating whether the <see cref="ICollection{PropertyModel}"/> is read-only.
        /// </summary>
        /// <returns>
        /// <b>true</b> if the <see cref="ICollection{PropertyModel}"/> is read-only; otherwise <b>false</b>.
        /// </returns>
        public bool IsReadOnly => false;
        #endregion

        #endregion

        #region public overrides properties

        #region [public] {overide} (bool) IsDefault: Gets a value indicating whether this instance contains the default
        /// <inheritdoc />
        public override bool IsDefault => !this.Any();
        #endregion

        #endregion

        #region public indexers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public PropertyModel this[int index]
        {
            get => _list[index];
            set => _list[index] = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public PropertyModel this[string name] => GetByName(name);

        #endregion

        #region public methods

        #region [public] (void) Add(PropertyModel):
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void Add(PropertyModel item)
        {
            SentinelHelper.ArgumentNull(item, nameof(item));

            item.SetOwner(this);
            _list.Add(item);
        }
        #endregion

        #region [public] (void) Clear():
        /// <summary>
        /// 
        /// </summary>
        public void Clear() => _list.Clear();
        #endregion

        #region [public] (PropertiesModel) Clone(): Clones this instance.
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public PropertiesModelCollection Clone()
        {
            var propertiesCloned = new PropertiesModelCollection();

            foreach (var property in this)
            {
                property.SetOwner(propertiesCloned);
                propertiesCloned.Add(property.Clone());
            }

            return propertiesCloned;
        }
        #endregion

        #region [public] (bool) Contains(PropertyModel): Returns a value indicating whether the style exist
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(PropertyModel item) => _list.Contains(item);
        #endregion

        #region [public] (bool) Contains(string): Returns a value indicating whether the style exist
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Contains(string name) => GetByName(name) != null;
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(PropertyModel item) => _list.IndexOf(item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, PropertyModel item) => _list.Insert(index, item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index) => _list.RemoveAt(index);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(PropertyModel[] array, int arrayIndex) => _list.CopyTo(array, arrayIndex);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(PropertyModel item) => _list.Remove(item);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<PropertyModel> GetEnumerator() => _list.GetEnumerator();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator() => _list.GetEnumerator();

        #endregion

        #region private methods

        #region [private] (PropertyModel) GetByName(string): Returns a reference to the specified style
        private PropertyModel GetByName(string name) => _list.Find(s => s.Name.Equals(name));
        #endregion

        #endregion
    }
}
