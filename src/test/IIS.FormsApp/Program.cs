
namespace IIS.FormsApp
{
    using System;
    using System.Windows.Forms;

    using iTin.Core.Models.Design.Enums;

    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var launcher = new Launcher { AutoClose = YesNo.Yes };
            Application.Run(new IISFeaturesInstall(launcher));
        }
    }
}
