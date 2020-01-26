
namespace iTin.AspNet.Web.IIS.Model
{
    using System;
    using System.Diagnostics;
    using System.ComponentModel;
    using System.Xml.Serialization;

    using iTin.Core.Models;

    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.itin.com/utilities/iis/configurator/v1.0")]
    [XmlRoot("IIS", Namespace = "http://schemas.itin.com/utilities/iis/configurator/v1.0", IsNullable = false)]
    public partial class IISModel : BaseModel<IISModel>
    {
    }
}
