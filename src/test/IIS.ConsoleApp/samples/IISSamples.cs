
namespace IIS.Samples
{
    using System;
    using System.Text;

    using iTin.AspNet.Web.IIS;
    using iTin.AspNet.Web.IIS.ComponentModel;
    using iTin.AspNet.Web.IIS.ComponentModel.Design;
    using iTin.AspNet.Web.IIS.Model;

    using iTin.Core.ComponentModel;

    public static class IISSamples
    {
        // Configures IIS features from custom features
        public static void ExecuteFromCustomFeatures()
        {
            Console.WriteLine(string.Empty);
            Console.WriteLine($"> Configures IIS features from XML configuration file");

            FeatureCommandsCollection commands = Configurator.CreateCommands(Configurator.GetAllFeatures());
            commands.NotifyFeatureCommandCollectionExecuted += NotifyFeatureCommandCollectionExecuted;
            IResult result = commands.Execute();
            if (result.Success)
            {
                Console.WriteLine($"    > IIs configured correctly, enjoy!!! ;)");
            }
            else
            {
                var messages = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    messages.AppendLine(error.Message);
                }

                Console.WriteLine($"    > Error(s) while configure IIS");
                Console.WriteLine(string.Empty);
                Console.WriteLine($"{messages}");
            }
        }

        // Configures IIS features from XML configuration file
        public static void ExecuteFromXmlFile()
        {
            Console.WriteLine(string.Empty);
            Console.WriteLine($"> Configures IIS features from XML configuration file");

            IISModel model = IISModel.LoadFromFile("~\\resources\\IIS-Features.xml");
            FeatureCommandsCollection commands = Configurator.CreateCommands(model);
            IResult result = commands.Execute();
            if (result.Success)
            {
                Console.WriteLine($"    > IIs configured correctly, enjoy!!! ;)");
            }
            else
            {
                var messages = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    messages.AppendLine(error.Message);
                }

                Console.WriteLine($"    > Error(s) while configure IIS");
                Console.WriteLine(string.Empty);
                Console.WriteLine($"{messages}");
            }
        }


        private static void NotifyFeatureCommandCollectionExecuted(object sender, NotifyFeatureCommandCollectionExecutedEventArgs e)
        {
            Console.WriteLine(string.Empty);
            Console.WriteLine($"  > Feature: {e.Feature}");
            Console.WriteLine($"    > Index: {e.Index} / {e.Total}");
            Console.WriteLine($"    > Status: {(e.Detail.Result.Success ? "Installed" : "Not Installed")}");
            Console.WriteLine($"    > Output: {e.Detail.RunResult}");        }
    }
}
