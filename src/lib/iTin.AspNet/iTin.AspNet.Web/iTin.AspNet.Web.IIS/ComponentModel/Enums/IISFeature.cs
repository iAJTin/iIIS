
using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using iTin.Core.ComponentModel;

namespace iTin.AspNet.Web.IIS.ComponentModel.Enums
{
    /// <summary>
    /// Defines a <b>Internet Information Services (IIS)</b> feature.
    /// </summary>
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum IISFeature
    {
        /// <summary>
        /// IIS-WebServerRole feature.
        /// </summary>
        [EnumDescription("IIS-WebServerRole")]
        WebServerRole,

        /// <summary>
        /// IIS-WebServer feature.
        /// </summary>
        [EnumDescription("IIS-WebServer")]
        WebServer,

        /// <summary>
        /// IIS-CommonHttpFeatures feature.
        /// </summary>
        [EnumDescription("IIS-CommonHttpFeatures")]
        CommonHttpFeatures,

        /// <summary>
        /// IIS-HttpErrors feature.
        /// </summary>
        [EnumDescription("IIS-HttpErrors")]
        HttpErrors,

        /// <summary>
        /// IIS-HttpRedirect feature.
        /// </summary>
        [EnumDescription("IIS-HttpRedirect")]
        HttpRedirect,

        /// <summary>
        /// IIS-NetFxExtensibility feature.
        /// </summary>
        [EnumDescription("IIS-NetFxExtensibility")]
        NetFxExtensibility,

        /// <summary>
        /// IIS-HealthAndDiagnostics feature.
        /// </summary>
        [EnumDescription("IIS-HealthAndDiagnostics")]
        HealthAndDiagnostics,

        /// <summary>
        /// IIS-HttpLogging feature.
        /// </summary>
        [EnumDescription("IIS-HttpLogging")]
        HttpLogging,

        /// <summary>
        /// IIS-HttpTracing feature.
        /// </summary>
        [EnumDescription("IIS-HttpTracing")]
        HttpTracing,

        /// <summary>
        /// IIS-Security feature.
        /// </summary>
        [EnumDescription("IIS-Security")]
        Security,

        /// <summary>
        /// IIS-RequestFiltering feature.
        /// </summary>
        [EnumDescription("IIS-RequestFiltering")]
        RequestFiltering,

        /// <summary>
        /// IIS-IPSecurity feature.
        /// </summary>
        [EnumDescription("IIS-IPSecurity")]
        IPSecurity,

        /// <summary>
        /// WebServerRole feature.
        /// </summary>
        [EnumDescription("IIS-Performance")]
        Performance,

        /// <summary>
        /// IIS-WebServerManagementTools feature.
        /// </summary>
        [EnumDescription("IIS-WebServerManagementTools")]
        WebServerManagementTools,

        /// <summary>
        /// IIS-IIS6ManagementCompatibility feature.
        /// </summary>
        [EnumDescription("IIS-IIS6ManagementCompatibility")]
        IIS6ManagementCompatibility,

        /// <summary>
        /// IIS-Metabase feature.
        /// </summary>
        [EnumDescription("IIS-Metabase")]
        Metabase,

        /// <summary>
        /// IIS-StaticContent feature.
        /// </summary>
        [EnumDescription("IIS-StaticContent")]
        StaticContent,

        /// <summary>
        /// IIS-DefaultDocument feature.
        /// </summary>
        [EnumDescription("IIS-DefaultDocument")]
        DefaultDocument,

        /// <summary>
        /// IIS-DirectoryBrowsing feature.
        /// </summary>
        [EnumDescription("IIS-DirectoryBrowsing")]
        DirectoryBrowsing,

        /// <summary>
        /// IIS-ISAPIExtensions feature.
        /// </summary>
        [EnumDescription("IIS-ISAPIExtensions")]
        ISAPIExtensions,

        /// <summary>
        /// IIS-ISAPIFilter feature.
        /// </summary>
        [EnumDescription("IIS-ISAPIFilter")]
        ISAPIFilter,

        /// <summary>
        /// IIS-ASPNET feature.
        /// </summary>
        [EnumDescription("IIS-ASPNET")]
        ASPNET,

        /// <summary>
        /// IIS-CustomLogging feature.
        /// </summary>
        [EnumDescription("IIS-CustomLogging")]
        CustomLogging,

        /// <summary>
        /// IIS-BasicAuthentication feature.
        /// </summary>
        [EnumDescription("IIS-BasicAuthentication")]
        BasicAuthentication,

        /// <summary>
        /// IIS-HttpCompressionStatic feature.
        /// </summary>
        [EnumDescription("IIS-HttpCompressionStatic")]
        HttpCompressionStatic,

        /// <summary>
        /// IIS-ManagementConsole feature.
        /// </summary>
        [EnumDescription("IIS-ManagementConsole")]
        ManagementConsole,

        /// <summary>
        /// IIS-ManagementService feature.
        /// </summary>
        [EnumDescription("IIS-ManagementService")]
        ManagementService,

        /// <summary>
        /// IIS-WMICompatibility feature.
        /// </summary>
        [EnumDescription("IIS-WMICompatibility")]
        WMICompatibility,

        /// <summary>
        /// IIS-LegacyScripts feature.
        /// </summary>
        [EnumDescription("IIS-LegacyScripts")]
        LegacyScripts,

        /// <summary>
        /// IIS-WindowsAuthentication feature.
        /// </summary>
        [EnumDescription("IIS-WindowsAuthentication")]
        WindowsAuthentication,

        /// <summary>
        /// IIS-ASPNET45 feature.
        /// </summary>
        [EnumDescription("IIS-ASPNET45")]
        ASPNET45,



        /// <summary>
        /// IIS-ApplicationDevelopment feature.
        /// </summary>
        [EnumDescription("IIS-ApplicationDevelopment")]
        ApplicationDevelopment,


        /// <summary>
        /// IIS-NetFxExtensibility45 feature.
        /// </summary>
        [EnumDescription("IIS-NetFxExtensibility45")]
        NetFxExtensibility45
    }
}
