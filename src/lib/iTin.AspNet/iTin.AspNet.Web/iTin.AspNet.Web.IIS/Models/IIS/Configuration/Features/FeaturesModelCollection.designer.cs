
using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Xml.Serialization;

using iTin.Core.Models.Collections;

namespace iTin.AspNet.Web.IIS.Model
{
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.itin.com/utilities/iis/configurator/v1.0")]
    public partial class FeaturesModelCollection : BaseComplexModelCollection<FeatureModel, object, string>
    {
    }
}
