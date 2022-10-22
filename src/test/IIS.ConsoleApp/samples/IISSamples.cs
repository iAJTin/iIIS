
using System;
using System.Linq;
using System.Text;

using iTin.AspNet.Web.IIS;
using iTin.AspNet.Web.IIS.ComponentModel;
using iTin.AspNet.Web.IIS.ComponentModel.Design;
using iTin.AspNet.Web.IIS.Model;

namespace IIS.Samples
{
    public static class IISSamples
    {
        // Configures IIS features from XML configuration file
        public static void ExecuteFromXmlFile()
        {
            Console.WriteLine();
            Console.WriteLine($@"> Configures IIS features from XML configuration file");

            IISModel model = IISModel.LoadFromFile("~\\resources\\IIS-Features.xml");
            FeatureCommandsCollection commands = Configurator.CreateCommands(model, CommandOptions.SilentModeDeactivated);
            commands.NotifyFeatureCommandCollectionExecuting += NotifyFeatureCommandCollectionExecuting;
            commands.NotifyFeatureCommandCollectionExecuted += NotifyFeatureCommandCollectionExecuted;
            commands.NotifyFeatureCommandsCollectionStart += NotifyFeatureCommandsCollectionStart;
            commands.NotifyFeatureCommandsCollectionFinish += NotifyFeatureCommandsCollectionFinish;
            commands.Process();
        }


        // Configures IIS features from custom features
        public static void ExecuteFromCustomFeatures()
        {
            Console.WriteLine(string.Empty);
            Console.WriteLine($@"> Configures IIS features from custom features");

            FeatureCommandsCollection commands = Configurator.CreateCommands(Configurator.GetAllFeatures(), CommandOptions.SilentModeDeactivated);
            commands.NotifyFeatureCommandCollectionExecuting += NotifyFeatureCommandCollectionExecuting;
            commands.NotifyFeatureCommandCollectionExecuted += NotifyFeatureCommandCollectionExecuted;
            commands.NotifyFeatureCommandsCollectionStart += NotifyFeatureCommandsCollectionStart;
            commands.NotifyFeatureCommandsCollectionFinish += NotifyFeatureCommandsCollectionFinish;
            commands.Process();
        }


        private static void NotifyFeatureCommandCollectionExecuted(object sender, NotifyFeatureCommandCollectionExecutedEventArgs e)
        {
            var commands = (FeatureCommandsCollection)sender;
            var currentCommand = commands[e.Index];
            Console.WriteLine($@"      > Status: {(e.Detail.Result.Success ? "Installed" : "Not Installed")}");
            Console.WriteLine($@"      > Command: {currentCommand.Command}"); 
            //Console.WriteLine($"      > Output: {e.Detail.ProgramResult}");  // uncomment to see the detail
            Console.WriteLine();
        }

        private static void NotifyFeatureCommandCollectionExecuting(object sender, NotifyFeatureCommandCollectionExecutingEventArgs e)
        {
            Console.WriteLine($@"    > Feature: {e.Feature} ({e.Index + 1}/{e.Total})");
        }

        private static void NotifyFeatureCommandsCollectionFinish(object sender, NotifyFeatureCommandsCollectionFinishEventArgs e)
        {
            if (e.Result.Success)
            {
                Console.WriteLine($@"  > IIs configured correctly");
                Console.WriteLine($@"    > Enjoy!!! ;)");
            }
            else
            {
                var messages = new StringBuilder();
                foreach (var error in e.Result.Errors)
                {
                    messages.AppendLine(error.Message);
                }

                Console.WriteLine($@"   > Error(s) while configure IIS");
                Console.WriteLine(string.Empty);
                Console.WriteLine($@"{messages}");

                Console.WriteLine(string.Empty);
                Console.WriteLine(@"> End Logging < ");
            }
        }

        private static void NotifyFeatureCommandsCollectionStart(object sender, NotifyFeatureCommandsCollectionStartEventArgs e)
        {
            var commands = (FeatureCommandsCollection)sender;
            if (!(commands.FirstOrDefault() is FeatureCommand firstCommand))
            {
                return;
            }

            Console.WriteLine();
            Console.WriteLine($@"  > Features to install");
            foreach (var command in commands)
            {
                var currentFeatureCommand = command as FeatureCommand;
                if (currentFeatureCommand == null)
                {
                    continue;
                }

                if (!e.InternetInformationServerIsPresent && firstCommand.Equals(currentFeatureCommand))
                {
                    Console.WriteLine($@"    > {currentFeatureCommand.Feature}");
                    Console.WriteLine($@"      > Install Internet Information Services (IIS), is not present in your system");
                }

                Console.WriteLine($@"    > {currentFeatureCommand.Feature}");
            }

            Console.WriteLine();
            Console.WriteLine($@"  > Installing Features");
        }
    }
}
