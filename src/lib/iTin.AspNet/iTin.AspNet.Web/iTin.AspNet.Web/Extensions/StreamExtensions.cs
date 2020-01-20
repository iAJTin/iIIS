
namespace Syntec.AspNet.Web
{
    using System.Globalization;
    using System.IO;
    using System.Web;

    using Core;
    using Core.Helpers;

    using ComponentModel;

    /// <summary>
    /// Static class than contains extension methods for objects of type <see cref="T:System.IO.Stream" />.
    /// </summary> 
    public static class StreamExtensions
    {
        #region public static methods

        #region [public] {static} (void) Download(this Stream, string, HttpResponse): Downloads the specified data with the name specified in fileName.
        /// <summary>
        /// Downloads the specified data with the name specified in <paramref name="fileName"/>.
        /// </summary>
        /// <param name="target">Data to download.</param>
        /// <param name="fileName">Name of the file to download.</param>
        /// <param name="response">The response to use.</param>
        public static void Download(this Stream target, string fileName, HttpResponse response)
        {
            SentinelHelper.ArgumentNull(target, nameof(target));
            SentinelHelper.ArgumentNull(fileName, nameof(fileName));
            SentinelHelper.IsFalse(FileHelper.IsValidFileName(fileName), "Filename does not have a valid name");

            HttpResponseEx info = new HttpResponseEx
            {
                ContentType = HttpResponseEx.GetMimeMapping(Path.GetExtension(fileName).Replace(".", string.Empty)),
                ContentDisposition = string.Format(CultureInfo.InvariantCulture, "attachment; filename={0}", fileName)
            };

            target.DownloadImpl(response, info);
        }
        #endregion

        #endregion

        #region private static methods

        #region [private] {static} (void) DownloadImpl(this Stream, HttpResponse, HttpResponseEx): Downloads specified file in responseInfo
        /// <summary>
        /// Downloads the specified file in <paramref name="responseInfo"/>.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="response">The response.</param>
        /// <param name="responseInfo">The response information.</param>
        private static void DownloadImpl(this Stream target, HttpResponse response, HttpResponseEx responseInfo)
        {
            response.Clear();
            response.ContentType = responseInfo.ContentType;
            response.AddHeader("content-disposition", responseInfo.ContentDisposition);
            response.BinaryWrite(target.AsByteArray());
            response.Flush();
            response.End();
        }
        #endregion
        
        #endregion
    }
}
