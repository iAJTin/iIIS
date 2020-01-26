
namespace iTin.Core.Min
{
    using System.IO;
    using System.Text;

    /// <summary>
    /// Static class than contains extension methods for objects of type <see cref="string"/>.
    /// </summary> 
    public static class StringExtensions
    {
        /// <summary>
        /// Returns a new <see cref="Stream"/> from target <see cref="string"/> encoding by specified encoding type. If is <b>null</b> uses defaults encoding.
        /// If is <c>null</c> uses default encoding.
        /// </summary>
        /// <param name="target">Target string.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <returns>
        /// A new <see cref="Stream"/> from target string.
        /// </returns>
        public static Stream AsStream(this string target, Encoding encoding = null)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream, encoding ?? Encoding.Default);
            writer.Write(target);
            writer.Flush();
            stream.Position = 0;

            return stream;
        }
    }
}
