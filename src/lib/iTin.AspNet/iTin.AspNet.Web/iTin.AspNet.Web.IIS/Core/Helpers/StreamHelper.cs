
namespace iTin.Core.Helpers
{
    using System.Diagnostics.CodeAnalysis;
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

        /// <summary>
        /// Convert input file to memory stream.
        /// </summary>
        /// <param name="fileName">File to convert.</param>
        /// <returns>
        /// A <see cref="MemoryStream" /> than represent the input file.
        /// </returns>
        [SuppressMessage("Microsoft.Reliability", "CA2000:Eliminar (Dispose) objetos antes de perder el ámbito")]
        public static MemoryStream AsMemoryStreamFromFile(string fileName)
        {
            SentinelHelper.IsTrue(string.IsNullOrEmpty(fileName));

            MemoryStream ms;
            FileStream fs = null;
            MemoryStream mstemp = null;

            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                try
                {
                    mstemp = new MemoryStream(fs.AsByteArray());
                    ms = mstemp;
                    mstemp = null;
                }
                finally
                {
                    mstemp?.Dispose();
                }
            }
            finally
            {
                fs?.Dispose();
            }

            return ms;
        }

        /// <summary>
        /// Returns specified text file as <see cref="Stream"/>.
        /// </summary>
        /// <param name="file">Target file</param>
        /// <returns>
        /// A <see cref="Stream"/> from specified filename.
        /// </returns>
        public static Stream TextFileToStream(string file) => new MemoryStream(File.ReadAllBytes(TypeHelper.ToType<string>(file)));
    }
}
