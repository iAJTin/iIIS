
namespace iTin.Core.Helpers
{
    using System.Diagnostics;

    /// <summary>
    /// Static class than contains methods for retrieve system information.
    /// </summary>
    public static class SystemHelper
    {
        /// <summary>
        /// Gets a value that determines if the operating system is 64bit.
        /// </summary>
        /// <returns>
        /// <b>true</b> if operating system is 64bit; otherwise <b>false</b>.
        /// </returns>
        public static bool Is64BitOperatingSystem => System.Environment.Is64BitOperatingSystem;

        /// <summary>
        /// Gets a value that determines if the operating system is 32bit.
        /// </summary>
        /// <returns>
        /// <b>true</b> if operating system is 32bit; otherwise <b>false</b>.
        /// </returns>
        public static bool Is32BitOperatingSystem => !Is64BitOperatingSystem;


        /// <summary>
        /// Runs specified program with parameters.
        /// </summary>
        /// <param name="fileName">Program name</param>
        /// <param name="arguments">Program arguments</param>
        /// <returns>
        /// A <see cref="string"/> with output command result.
        /// </returns>
        public static string RunCommand(string fileName, string arguments)
        {
            using (var process =
                Process.Start(
                    new ProcessStartInfo
                    {
                        FileName = fileName,
                        Arguments = arguments,
                        CreateNoWindow = true,
                        WindowStyle = ProcessWindowStyle.Hidden,
                        RedirectStandardOutput = true,
                        UseShellExecute = false,                        
                    }))
            {
                process.WaitForExit();
                return process.StandardOutput.ReadToEnd();
            }
        }
    }
}
