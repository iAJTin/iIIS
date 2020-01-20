
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
    [XmlType(Namespace = "http://schemas.syntec.com/utilities/iis/configurator/v1.0")]
    public partial class ConfigurationModel : BaseModel<ConfigurationModel>
    {
    }
}
