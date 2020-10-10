
namespace iTin.Core.IO
{
    using System;

    using iTin.Core;
    using iTin.Core.ComponentModel;
    using iTin.Core.ComponentModel.Results;
    using iTin.Core.Helpers;

    using NativeIO = System.IO;

    /// <summary>
    /// Static class than contains extension methods for objects of type <see cref="T:System.IO.Stream" />.
    /// </summary> 
    public static class StreamExtensions
    {
        /// <summary>
        /// Saves this stream into a file with name specified by parameter <paramref name="fileName"/>.
        /// You can indicate whether to automatically create the destination path if it does not exist. By default it will try to create the destination path.
        /// The use of the <c>~</c> character is allowed to indicate relative paths, and you can also use <b>UNC</b> path.
        /// </summary>
        /// <param name="stream">Stream to save</param>
        /// <param name="fileName">Destination file path. Absolute or relative (~) paths are allowed</param>
        /// <param name="options">Output save options</param>
        /// <returns>
        /// A <see cref="IResult"/> object that contains the operation result
        /// </returns>
        public static IResult SaveToFile(this NativeIO.Stream stream, string fileName, SaveOptions options = null)
        {
            SentinelHelper.ArgumentNull(stream, nameof(stream));
            SentinelHelper.ArgumentNull(fileName, nameof(fileName));

            try
            {
                IResult saveResult;
                using (var memoryStream = stream as NativeIO.MemoryStream ?? stream.ToMemoryStream())
                {
                    saveResult = memoryStream.SaveToFile(fileName, options);
                }

                return saveResult;
            }
            catch (Exception ex)
            {
                return BooleanResult.FromException(ex);
            }
        }


        private static IResult SaveToFile(this NativeIO.MemoryStream stream, string fileName, SaveOptions options = null)
        {
            try
            {
                var safeOptions = options;
                if (options == null)
                {
                    safeOptions = SaveOptions.Default;
                }

                string parsedFullFilenamePath = Path.PathResolver(fileName);
                string directoryName = NativeIO.Path.GetDirectoryName(parsedFullFilenamePath);
                NativeIO.DirectoryInfo di = new NativeIO.DirectoryInfo(directoryName);
                bool existDirectory = di.Exists;
                if (!existDirectory)
                {
                    if (safeOptions.CreateFolderIfNotExist)
                    {
                        NativeIO.Directory.CreateDirectory(directoryName);
                    }
                }

                using (var fs = new NativeIO.FileStream(parsedFullFilenamePath, NativeIO.FileMode.Create, NativeIO.FileAccess.ReadWrite, NativeIO.FileShare.ReadWrite))
                {
                    stream.WriteTo(fs);
                }

                return BooleanResult.SuccessResult;
            }
            catch(Exception ex)
            {
                return BooleanResult.FromException(ex);
            }
        }
    }
}
