
namespace iTin.AspNet.Web.IIS.ComponentModel.Enums
{
    using System;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Defines a <b>Internet Information Services (IIS)</b> feature status.
    /// </summary>
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FeatureStatus
    {
        /// <summary>
        /// Feature installed
        /// </summary>
        Installed,

        /// <summary>
        /// Feature not installed
        /// </summary>
        NotInstalled
    }
}
