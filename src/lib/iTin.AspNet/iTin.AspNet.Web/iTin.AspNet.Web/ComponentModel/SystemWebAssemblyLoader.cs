
namespace Syntec.AspNet.Web.ComponentModel
{
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Loads SystemWeb assembly 
    /// </summary>
    internal static class SystemWebAssemblyLoader
    {
        static SystemWebAssemblyLoader()
        {
            int clrMajorVersion = 2;

            try
            {
                clrMajorVersion = GetClrMajorVersion();
            }
            catch (SecurityException)
            {
            }

            if (clrMajorVersion == 2)
            {
                SystemWeb = Load("System.Web, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a");
            }

            if (clrMajorVersion == 4 || SystemWeb == null)
            {
                SystemWeb = Load("System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a");
            }
        }

        public static Assembly SystemWeb { get; }


        private static int GetClrMajorVersion()
        {
            int clrVersion = 0;
            string versionStr = RuntimeEnvironment.GetSystemVersion();

            Regex regex = new Regex("[0-9]", RegexOptions.Compiled | RegexOptions.Singleline);
            Match match = regex.Match(versionStr);
            if (match.Success)
            {
                int.TryParse(match.Value, out clrVersion);
            }

            return clrVersion;
        }

        private static Assembly Load(string name)
        {
            try
            {
                return Assembly.Load(name);
            }
            catch (FileNotFoundException)
            {
                return null;
            }
        }
    }
}
