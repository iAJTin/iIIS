
namespace IIS.FormsApp
{
    using System.Diagnostics;

    using iTin.AspNet.Web.IIS;
    using iTin.AspNet.Web.IIS.ComponentModel;
    using iTin.AspNet.Web.IIS.Model;

    using iTin.Core.Min.Helpers;
    using iTin.Core.Models.Design.Enums;

    public class Launcher
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const string DefaultFeaturesFile = @"~\IIS-Features.xml";

        public Launcher()
        {
            IISModel model = IISModel.LoadFromFile(DefaultFeaturesFile);
            Commands = Configurator.CreateCommands(model);
            AutoClose = YesNo.No;
        }

        public static Launcher LoadFromSettings() => new Launcher
        {
            AutoClose = EnumHelper.CreateEnumTypeFromStringValue<YesNo>(AppSettings.AutoClose),
        };

        public YesNo AutoClose { get; set; }

        public FeatureCommandsCollection Commands { get; }
    }
}
