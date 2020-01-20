
namespace iTin.Core.Min.Helpers
{
    using System.IO;

    /// <summary> 
    /// Static class than contains methods for manipulating objects of type <see cref="Stream" />.
    /// </summary>
    public static class StreamHelper
    {
        /// <summary>
        /// Returns the specified file as a byte array.
        /// </summary>
        /// <param name="fileName">File to convert.</param>
        /// <returns>
        /// Array of byte than represent the file.
        /// </returns>
        public static byte[] AsByteArrayFromFile(string fileName)
        {
            SentinelHelper.IsTrue(string.IsNullOrEmpty(fileName));

            byte[] buffer;

            using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                buffer = stream.AsByteArray();
            }

            return buffer;
        }
    }
}
