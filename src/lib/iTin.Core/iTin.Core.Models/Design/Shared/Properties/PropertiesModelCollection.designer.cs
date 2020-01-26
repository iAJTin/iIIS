
namespace iTin.Core.Models
{
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.itin.com/model/v1.0")]
    public partial class PropertiesModelCollection : BaseModel<PropertiesModelCollection>
    {
    }
}
