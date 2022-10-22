
using System;
using System.Text;

using IIS.Samples;

namespace IIS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = KnownConstants.AppName;
            
            // Configures IIS features from XML configuration file
            IISSamples.ExecuteFromXmlFile();

            // Configures IIS features from custom features
            IISSamples.ExecuteFromCustomFeatures();

            Console.WriteLine();
            Console.WriteLine($"Press any key to exit...");
            Console.ReadKey();
        }
    }
}
