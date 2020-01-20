
namespace Syntec.AspNet.Web.ComponentModel
{
    using System;
    using System.Reflection;

    /// <summary>
    /// Loads SystemWeb assembly 
    /// </summary>
    public static class HttpRuntimeAccessor
    {
        static HttpRuntimeAccessor()
        {
            if (SystemWebAssemblyLoader.SystemWeb == null)
            {
                return;
            }

            try
            {
                Type type = SystemWebAssemblyLoader.SystemWeb.GetType("System.Web.HttpRuntime");
                PropertyInfo property = type.GetProperty("AppDomainAppVirtualPath", BindingFlags.Static | BindingFlags.Public);
                AppDomainAppVirtualPath = (string)property.GetValue(null, new object[0]);
            }
            catch
            {
            }
        }

        public static readonly string AppDomainAppVirtualPath;
    }
}
