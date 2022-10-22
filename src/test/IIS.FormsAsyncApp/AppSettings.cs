
using System.Configuration;

namespace IIS.FormsApp
{
    public static class AppSettings
    {
        public static string AutoClose => ConfigurationManager.AppSettings["AutoClose"];
    }
}
