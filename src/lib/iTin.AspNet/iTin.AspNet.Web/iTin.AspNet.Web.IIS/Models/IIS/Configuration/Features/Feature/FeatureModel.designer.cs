﻿
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
    public partial class FeatureModel : BaseModel<FeatureModel>
    {
    }
}
