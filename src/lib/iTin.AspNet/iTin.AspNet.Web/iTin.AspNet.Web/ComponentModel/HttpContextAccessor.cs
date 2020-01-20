
namespace Syntec.AspNet.Web.ComponentModel
{
    using System;
    using System.Reflection;

    /// <summary>
    /// 
    /// </summary>
    public static class HttpContextAccessor
    {
        private static readonly PropertyInfo Property;

        static HttpContextAccessor()
        {
            if (SystemWebAssemblyLoader.SystemWeb == null)
                return;
            try
            {
                Type type = SystemWebAssemblyLoader.SystemWeb.GetType("System.Web.HttpContext");
                Property = type.GetProperty("Current", BindingFlags.Static | BindingFlags.Public);
            }
            catch
            {
            }
        }


        public static object Current
        {
            get
            {
                try
                {
                    return Property?.GetValue(null, new object[0]);
                }
                catch
                {
                    return null;
                }
            }
        }

        public static object Server => GetPropertyValue(Current, "Server");

        public static object Request => GetPropertyValue(Current, "Request");

        public static Uri Url => (Uri)GetPropertyValue(Request, "Url");


        private static object GetPropertyValue(object obj, string name)
        {
            if (obj == null)
            {
                return null;
            }

            PropertyInfo pi = obj.GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.Public);
            return pi.GetValue(obj, new object[0]);
        }
    }
}
