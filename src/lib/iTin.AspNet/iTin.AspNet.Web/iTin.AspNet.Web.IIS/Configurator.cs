
using System.Collections.Generic;
using System.Collections.ObjectModel;

using iTin.AspNet.Web.IIS.ComponentModel;
using iTin.AspNet.Web.IIS.ComponentModel.Enums;
using iTin.AspNet.Web.IIS.Model;

using iTin.Registry.Windows;

namespace iTin.AspNet.Web.IIS
{
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

        #region [public] {static} (FeatureCommandsCollection) CreateCommands(IISFeature[], CommandOptions = null): Returns a new FeatureCommandsCollection reference from Internet Information Services (IIS) FeatureCommand array
        /// <summary>
        /// Returns a new <see cref="FeatureCommandsCollection"/> reference from <b>Internet Information Services (IIS)</b> <see cref="FeatureCommand"/> array.
        /// </summary>
        /// <param name="features">Features array</param>
        /// <param name="commandOptions">Command options</param>
        /// <returns>
        /// A <see cref="FeatureCommandsCollection"/> reference.
        /// </returns>
        public static FeatureCommandsCollection CreateCommands(IISFeature[] features, CommandOptions commandOptions = null)
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

            return CreateCommandsImpl(featureNames, commandOptions ?? CommandOptions.SilentModeActivated);
        }
        #endregion

        #region [public] {static} (FeatureCommandsCollection) CreateCommands(IISModel, CommandOptions = null): Returns a new FeatureCommandsCollection reference from Internet Information Services (IIS) IISModel (XML model)
        /// <summary>
        /// Returns a new <see cref="FeatureCommandsCollection"/> reference from <b>Internet Information Services (IIS)</b> <see cref="IISModel"/> (<b>XML</b> model).
        /// </summary>
        /// <param name="model">Features array</param>
        /// <param name="commandOptions">Command options</param>
        /// <returns>
        /// A <see cref="FeatureCommandsCollection"/> reference.
        /// </returns>
        public static FeatureCommandsCollection CreateCommands(IISModel model, CommandOptions commandOptions = null)
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

            return CreateCommandsImpl(features, commandOptions ?? CommandOptions.SilentModeActivated);
        }
        #endregion

        #endregion

        #region private static methods

        private static FeatureCommandsCollection CreateCommandsImpl(IEnumerable<IISFeature> features, CommandOptions commandOptions)
        {
            var commands = new FeatureCommandsCollection();

            try
            {
                bool internetInformationServerIsPresent = RegistryOperations.CheckMachineKey(@"SOFTWARE\Microsoft\InetStp");
                if (!internetInformationServerIsPresent)
                {
                    // IIS not installed > :-( Begin installation
                    commands.Add(FeatureCommand.Create("IIS-DefaultDocument", "All"));
                }

                commands.InternetInformationServerIsPresent = internetInformationServerIsPresent;

                // IIS installed 
                //  > Enable All Features > Install
                foreach (IISFeature feature in features)
                {
                    commands.Add(FeatureCommand.Create(feature, options: commandOptions));
                }

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
