
namespace iTin.Core.Min
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Text;

    using iTin.Core.Min.ComponentModel;
    using iTin.Core.Min.Helpers;

    /// <summary>
    /// Static class than contains extension methods for objects of type <see cref="Stream"/>.
    /// </summary> 
    public static class StreamExtensions
    {
        #region public static methods

        #region [public] {static} (byte[]) AsByteArray(this Stream): Returns stream input as byte array.
        /// <summary>
        /// Returns stream input as byte array.
        /// </summary>
        /// <param name="stream">Stream to convert.</param>
        /// <returns>
        /// Array of byte that represent the input stream.
        /// </returns>
        public static byte[] AsByteArray(this Stream stream) => AsByteArray(stream, false);
        #endregion

        #region [public] {static} (byte[]) AsByteArray(this Stream, bool): Returns stream input as byte array.
        /// <summary>
        /// Returns stream input as byte array.
        /// </summary>
        /// <param name="stream">Stream to convert.</param>
        /// <param name="closeAfter">if set to <b>true</b> close stream after convert it.</param>
        /// <returns>
        /// Array of byte that represent the input stream.
        /// </returns>
        public static byte[] AsByteArray(this Stream stream, bool closeAfter)
        {
            SentinelHelper.ArgumentNull(stream, nameof(stream));

            byte[] buffer = new byte[stream.Length];
            long position = stream.Position;

            stream.Seek(0L, SeekOrigin.Begin);
            stream.Read(buffer, 0, (int)stream.Length);
            stream.Seek(position, SeekOrigin.Begin);

            if (closeAfter)
            {
                stream.Close();
            }

            return buffer;
        }
        #endregion

        #region [public] {static} (string) AsString(this Stream, Encoding = null): Returns stream input as string.
        /// <summary>
        /// Returns stream input as string.
        /// </summary>
        /// <param name="stream">Stream to convert.</param>
        /// <param name="encoding">Stream to convert.</param>
        /// <returns>
        /// <see cref="string"/> that represent the input stream.
        /// </returns>
        public static string AsString(this Stream stream, Encoding encoding = null)
        {
            var safeEncoding = encoding;
            if (encoding == null)
            {
                safeEncoding = Encoding.UTF8;
            }

            string result;
            stream.Position = 0;
            using (var reader = new StreamReader(stream, safeEncoding))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }
        #endregion

        #region [public] {static} (Stream) Clone(this Stream): Create a new object that is a copy of specified instance
        /// <summary>
        /// Create a new object that is a copy of the current instance.
        /// </summary>
        /// <param name="stream">Stream to clone.</param>
        /// <returns>
        /// A new <see cref="Stream" /> that is a copy of specified instance.
        /// </returns>
        public static Stream Clone(this Stream stream)
        {
            SentinelHelper.ArgumentNull(stream, nameof(stream));

            MemoryStream ms = new MemoryStream();
            stream.CopyTo(ms);
            ms.Position = 0;

            return ms;
        }
        #endregion

        #region [public] {static} (IEnumerable<Stream>) Clone(this IEnumerable<Stream>): Create a new object that is a copy of specified instance
        /// <summary>
        /// Create a new object that is a copy of the current instance.
        /// </summary>
        /// <param name="items">Stream to clone.</param>
        /// <returns>
        /// A new <see cref="Stream" /> that is a copy of specified instance.
        /// </returns>
        public static IEnumerable<Stream> Clone(this IEnumerable<Stream> items)
        {
            IList<Stream> streamList = items as IList<Stream> ?? items.ToList();
            SentinelHelper.ArgumentNull(streamList, nameof(items));

            return streamList.Select(item => item.Clone()).ToList();
        }
        #endregion

        #region [public] {static} (IResult) SaveToFile(this Stream, string, SaveOptions = null): Saves this stream into a file with name specified by filename
        /// <summary>
        /// Saves this stream into a file with name specified by parameter <paramref name="fileName" />.
        /// You can indicate whether to automatically create the destination path if it does not exist. By default it will try to create the destination path.
        /// The use of the <c>~</c> character is allowed to indicate relative paths.
        /// </summary>
        /// <param name="stream">Stream to save</param>
        /// <param name="fileName">Destination file path. Absolute or relative (~) paths are allowed</param>
        /// <param name="options">Output save options</param>
        /// <returns>
        /// A <see cref="IResult" /> object that contains the operation result
        /// </returns>
        public static IResult SaveToFile(this Stream stream, string fileName, SaveOptions options = null)
        {
            SentinelHelper.ArgumentNull(stream, nameof(stream));
            SentinelHelper.ArgumentNull(fileName, nameof(fileName));

            try
            {
                IResult saveResult;
                using (var memoryStream = stream as MemoryStream ?? stream.ToMemoryStream())
                {
                    saveResult = memoryStream.SaveToFile(fileName, options ?? SaveOptions.Default);
                }

                return saveResult;
            }
            catch (Exception ex)
            {
                return ResultBase.FromException(ex);
            }
        }
        #endregion

        #region [public] {static} (MemoryStream) ToMemoryStream(this Stream): Convert a Stream into MemoryStream.
        /// <summary>
        /// Convert a <see cref="Stream"/> into <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns>
        /// A <see cref="MemoryStream"/> with content of a <see cref="Stream"/>.
        /// </returns>
        [SuppressMessage("Microsoft.Reliability", "CA2000:Eliminar (Dispose) objetos antes de perder el ámbito")]
        public static MemoryStream ToMemoryStream(this Stream stream)
        {
            SentinelHelper.ArgumentNull(stream, nameof(stream));

            MemoryStream resultStream;
            MemoryStream tempStream = null;

            try
            {
                tempStream = new MemoryStream();
                tempStream.SetLength(stream.Length);
                stream.Read(tempStream.GetBuffer(), 0, (int)stream.Length);
                tempStream.Flush();

                resultStream = tempStream;
                tempStream = null;
            }
            finally
            {
                tempStream?.Dispose();
            }

            return resultStream;
        }
        #endregion

        #endregion

        #region private static methods

        #region [private] {static} (IResult) SaveToFile(MemoryStream, string, SaveOptions = null) Saves this memory stream into file.
        /// <summary>
        /// Saves this memory stream into a file with name specified by parameter <paramref name="fileName" />.
        /// You can indicate whether to automatically create the destination path if it does not exist. By default it will try to create the destination path.
        /// The use of the <c>~</c> character is allowed to indicate relative paths.
        /// </summary>
        /// <param name="stream">Stream to save</param>
        /// <param name="fileName">Destination file path. Absolute or relative (~) paths are allowed</param>
        /// <param name="options">Output save options</param>
        /// <returns>
        /// A <see cref="IResult" /> object that contains the operation result
        /// </returns>
        private static IResult SaveToFile(this MemoryStream stream, string fileName, SaveOptions options = null)
        {
            try
            {
                var safeOptions = options;
                if (options == null)
                {
                    safeOptions = SaveOptions.Default;
                }

                string parsedFullFilenamePath = PathHelper.ResolveRelativePath(fileName);
                string directoryName = Path.GetDirectoryName(parsedFullFilenamePath);
                DirectoryInfo di = new DirectoryInfo(directoryName);
                bool existDirectory = di.Exists;
                if (!existDirectory)
                {
                    if (safeOptions.CreateFolderIfNotExist)
                    {
                        Directory.CreateDirectory(directoryName);
                    }
                }

                using (var fs = new FileStream(parsedFullFilenamePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    stream.WriteTo(fs);
                }

                return ResultBase.SuccessResult;
            }
            catch(Exception ex)
            {
                return ResultBase.FromException(ex);
            }
        }
        #endregion

        #endregion
    }
}
