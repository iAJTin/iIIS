
namespace IIS.FormsApp
{
    using System.Configuration;

    public static class AppSettings
    {
        public static string AutoClose => ConfigurationManager.AppSettings["AutoClose"];
    }
}
