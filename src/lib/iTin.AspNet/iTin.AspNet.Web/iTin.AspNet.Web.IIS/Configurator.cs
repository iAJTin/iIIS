
namespace iTin.AspNet.Web.IIS
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using iTin.Registry.Windows;

    using ComponentModel;
    using ComponentModel.Enums;

    using Model;

    /// <summary>
    /// Static class that allows you to install <b>Internet Information Services (IIS)</b> on your system, as well as additional features through code or a configuration <b>XML</b> file.
    /// </summary>
    public static class Configurator
    {
        #region public static readonly properties

        #region [public] {static} (IISFeature[]) AllFeatures: Returns a array that contains all features to install on Internet Information Services (IIS)
        /// <summary>
        /// Returns a <see cref="System.Array"/> that contains all features to install on <b>Internet Information Services (IIS)</b>.
        /// </summary>
        /// <value>
        /// Set of features.
        /// </value>>
        public static IISFeature[] GetAllFeatures() => new[]
        {
            IISFeature.WebServer,
            IISFeature.CommonHttpFeatures,
            IISFeature.HttpErrors,
            IISFeature.HttpRedirect,
            IISFeature.NetFxExtensibility,
            IISFeature.HealthAndDiagnostics,
            IISFeature.HttpLogging,
            IISFeature.HttpTracing,
            IISFeature.Security,
            IISFeature.RequestFiltering,
            IISFeature.IPSecurity,
            IISFeature.Performance,
            IISFeature.WebServerManagementTools,
            IISFeature.IIS6ManagementCompatibility,
            IISFeature.Metabase,
            IISFeature.StaticContent,
            IISFeature.DefaultDocument,
            IISFeature.DirectoryBrowsing,
            IISFeature.ISAPIExtensions,
            IISFeature.ISAPIFilter,
            IISFeature.ASPNET,
            IISFeature.CustomLogging,
            IISFeature.BasicAuthentication,
            IISFeature.HttpCompressionStatic,
            IISFeature.ManagementConsole,
            IISFeature.ManagementService,
            IISFeature.WMICompatibility,
            IISFeature.LegacyScripts,
            IISFeature.WindowsAuthentication,
            IISFeature.ASPNET45
        };
        #endregion

        #endregion

        #region public static methods

        #region [public] {static} (FeatureCommandsCollection) CreateCommands(IISFeature[]): Returns a new FeatureCommandsCollection reference from Internet Information Services (IIS) FeatureCommand array
        /// <summary>
        /// Returns a new <see cref="FeatureCommandsCollection"/> reference from <b>Internet Information Services (IIS)</b> <see cref="FeatureCommand"/> array.
        /// </summary>
        /// <param name="features">Features array</param>
        /// <returns>
        /// A <see cref="FeatureCommandsCollection"/> reference.
        /// </returns>
        public static FeatureCommandsCollection CreateCommands(IISFeature[] features)
        {
            if (features == null)
            {
                return new FeatureCommandsCollection();
            }

            var featureNames = new Collection<IISFeature>();
            foreach (IISFeature feature in features)
            {
                featureNames.Add(feature);
            }

            return CreateCommandsImpl(featureNames);
        }
        #endregion

        #region [public] {static} (FeatureCommandsCollection) CreateCommands(IISModel): Returns a new FeatureCommandsCollection reference from Internet Information Services (IIS) IISModel (XML model)
        /// <summary>
        /// Returns a new <see cref="FeatureCommandsCollection"/> reference from <b>Internet Information Services (IIS)</b> <see cref="IISModel"/> (<b>XML</b> model).
        /// </summary>
        /// <param name="model">Features array</param>
        /// <returns>
        /// A <see cref="FeatureCommandsCollection"/> reference.
        /// </returns>
        public static FeatureCommandsCollection CreateCommands(IISModel model)
        {
            if (model == null)
            {
                return new FeatureCommandsCollection();
            }

            var features = new Collection<IISFeature>();
            foreach (var feature in model.Configuration.Features)
            {
                features.Add(feature.Name);
            }

            return CreateCommandsImpl(features);
        }
        #endregion

        #endregion

        #region private static methods

        private static FeatureCommandsCollection CreateCommandsImpl(IEnumerable<IISFeature> features)
        {
            var commands = new FeatureCommandsCollection();

            try
            {
                bool internetInformationServerIsPresent = RegistryOperations.CheckMachineKey(@"SOFTWARE\Microsoft\InetStp");
                if (!internetInformationServerIsPresent)
                {
                    // IIS not installed > Begin installation
                    commands.Add(FeatureCommand.Create("IIS-DefaultDocument", "All"));                                        
                }

                // IIS installed > Begin enable all features
                commands.Add(FeatureCommand.Create("IIS-WebServerRole"));

                // Features > Install
                foreach (IISFeature feature in features)
                {
                    commands.Add(FeatureCommand.Create(feature));
                }

                //// IIS > Enable
                //commands.Add(
                //    GenericCommand.Create(
                //        SystemHelper.Is32BitOperatingSystem
                //            ? @"C:\WINDOWS\Microsoft.NET\Framework\4.0.30319\aspnet_regiis.exe"
                //            : @"C:\WINDOWS\Microsoft.NET\Framework64\4.0.30319\aspnet_regiis.exe",
                //        "-ir -enable"));

                return commands;
            }
            catch
            {
                return commands;
            }
        }

        #endregion
    }
}
