
namespace iTin.Core.Min.Helpers
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Reflection;

    using iTin.Core.Min.ComponentModel;

    /// <summary>
    /// Helper class for works for path's.
    /// </summary>
    public static class PathHelper
    {
        /// <summary>
        /// Returns a <see cref="char"/> that represents directory separator char. Returns <b>/</b> in <c>Unix</c> system or <b>\</b> in <c>Windows</c> system.
        /// </summary>
        public static readonly char DirectorySeparatorChar = PlatformInformation.IsUnix ? '/' : '\\';

        /// <summary>
        /// Returns a string that represents directory separator char. Returns <b>/</b> in <c>Unix</c> system or <b>\</b> in <c>Windows</c> system.
        /// </summary>
        public static readonly string DirectorySeparatorStr = new string(DirectorySeparatorChar, 1);


        /// <summary>
        /// Gets a valid full path from a relative path.
        /// </summary>
        /// <param name="relativePath">Element to recover.</param>
        /// <returns>
        /// Valid full path.
        /// </returns>
        public static string ResolveRelativePath(string relativePath)
        {
            SentinelHelper.ArgumentNull(relativePath, nameof(relativePath));

            var relativePathNormalized = relativePath.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
            var isRelativePath = relativePathNormalized.Trim().StartsWith("~", StringComparison.Ordinal);
            if (!isRelativePath)
            {
                return relativePath;
            }

            if (relativePathNormalized.Length.Equals(1))
            {
                relativePathNormalized = relativePathNormalized.Insert(1, Path.DirectorySeparatorChar.ToString(CultureInfo.InvariantCulture));
            }
            else if (!relativePathNormalized[1].Equals(Path.DirectorySeparatorChar))
            {
                relativePathNormalized = relativePathNormalized.Insert(1, Path.DirectorySeparatorChar.ToString(CultureInfo.InvariantCulture));
            }

            var callingUri = AssemblyHelper.GetFullAssemblyUri();
            var candidateUri = new UriBuilder(callingUri);
            var unscapedCandidateUri = Uri.UnescapeDataString(candidateUri.Path);
            var candidateRootPath = Path.GetDirectoryName(unscapedCandidateUri);

            var outputPartialPath = string.Empty;
            var rootPattern = $"~{Path.DirectorySeparatorChar}";
            if (!relativePathNormalized.Equals(rootPattern))
            {
                outputPartialPath = relativePathNormalized.Split(new[] { rootPattern }, StringSplitOptions.RemoveEmptyEntries)[0];
            }

            var rootPath = candidateRootPath.ToUpperInvariant()
                .Replace("BIN", string.Empty)
                .Replace($"{Path.DirectorySeparatorChar}DEBUG", string.Empty);

            var targetAssembly = Assembly.GetEntryAssembly();
            if (targetAssembly == null)
            {
                targetAssembly = Assembly.GetCallingAssembly();                
            }

            var runtimeRootPath = rootPath;
            var netFrameworkVersion = NetFrameworkHelper.GetAssemblyFrameworkVersion(targetAssembly);
            var hasRuntimeOutputFolder = !string.IsNullOrEmpty(netFrameworkVersion.RuntimeOutputFolder());
            if (hasRuntimeOutputFolder)
            {
                runtimeRootPath = rootPath.Replace($"{Path.DirectorySeparatorChar}{netFrameworkVersion.RuntimeOutputFolder().ToUpperInvariant()}", string.Empty);
            }

            return Path.Combine(runtimeRootPath, outputPartialPath);
        }
    }
}
