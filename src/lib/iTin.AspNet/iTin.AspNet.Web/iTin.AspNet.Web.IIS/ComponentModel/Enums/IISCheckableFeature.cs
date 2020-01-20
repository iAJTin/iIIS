
namespace iTin.AspNet.Web.IIS.ComponentModel.Enums
{
    using System;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Defines a <b>Internet Information Services (IIS)</b> checkable feature.
    /// </summary>
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum IISCheckableFeature
    {
        /// <summary>
        /// ASPNET feature.
        /// </summary>
        ASPNET,

        /// <summary>
        /// ASPNET45 feature.
        /// </summary>
        ASPNET45,

        /// <summary>
        /// BasicAuthentication feature.
        /// </summary>
        BasicAuthentication,

        /// <summary>
        /// CustomLogging feature.
        /// </summary>
        CustomLogging,

        /// <summary>
        /// DefaultDocument feature.
        /// </summary>
        DefaultDocument,

        /// <summary>
        /// DirectoryBrowsing feature.
        /// </summary>
        DirectoryBrowse,

        /// <summary>
        /// HttpCompressionStatic feature.
        /// </summary>
        HttpCompressionStatic,

        /// <summary>
        /// HttpErrors feature.
        /// </summary>
        HttpErrors,

        /// <summary>
        /// HttpLogging feature.
        /// </summary>
        HttpLogging,

        /// <summary>
        /// HttpRedirect feature.
        /// </summary>
        HttpRedirect,

        /// <summary>
        /// HttpTracing feature.
        /// </summary>
        HttpTracing,

        /// <summary>
        /// IPSecurity feature.
        /// </summary>
        IPSecurity,

        /// <summary>
        /// ISAPIExtensions feature.
        /// </summary>
        ISAPIExtensions,

        /// <summary>
        /// ISAPIFilter feature.
        /// </summary>
        ISAPIFilter,

        /// <summary>
        /// LegacyScripts feature.
        /// </summary>
        LegacyScripts,

        /// <summary>
        /// ManagementConsole feature.
        /// </summary>
        ManagementConsole,

        /// <summary>
        /// Metabase feature.
        /// </summary>
        Metabase,

        /// <summary>
        /// NetFxExtensibility feature.
        /// </summary>
        NetFxExtensibility,

        /// <summary>
        /// NetFxExtensibility45 feature.
        /// </summary>
        NetFxExtensibility45,

        /// <summary>
        /// PowerShellProvider feature.
        /// </summary>
        PowerShellProvider,

        /// <summary>
        /// RequestFiltering feature.
        /// </summary>
        RequestFiltering,

        /// <summary>
        /// StaticContent feature.
        /// </summary>
        StaticContent,

        /// <summary>
        /// WindowsAuthentication feature.
        /// </summary>
        WindowsAuthentication,

        /// <summary>
        /// WMICompatibility feature.
        /// </summary>
        WMICompatibility,
    }
}
