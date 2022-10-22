
using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using iTin.Core.ComponentModel;

namespace iTin.AspNet.Web.IIS.ComponentModel.Enums
{
    /// <summary>
    /// Defines known os programs
    /// </summary>
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum OsProgram
    {
        /// <summary>
        /// aspnet_regiis program
        /// </summary>aspnet_regiis
        [EnumDescription("aspnet_regiis")]
        AspNetRegiis,

        /// <summary>
        /// Dism program
        /// </summary>
        [EnumDescription("dism")]
        Dism,

        /// <summary>
        /// Notepad program
        /// </summary>
        [EnumDescription("Notepad")]
        Notepad
    }
}
