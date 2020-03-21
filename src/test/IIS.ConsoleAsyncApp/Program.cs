
namespace IIS
{
    using System;
    using System.Text;
    using System.Threading.Tasks;

    using Samples;

    class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = KnownConstants.AppName;
            
            // Configures IIS features from XML configuration file
            await IISSamples.ExecuteFromXmlFileAsync();

            // Configures IIS features from custom features
            await IISSamples.ExecuteFromCustomFeaturesAsync();

            Console.WriteLine();
            Console.WriteLine($"Press any key to exit...");
            Console.ReadKey();
        }
    }
}
