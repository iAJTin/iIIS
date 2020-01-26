
namespace iTin.Core.IO
{
    using System;
    using System.Reflection;

    using iTin.Registry.Windows;

    using NativePath = System.IO.Path;

    /// <summary>
    /// Helper class for works for path's.
    /// </summary>
    public static class Path
    {
        /// <summary>
        /// Returns a <see cref="char"/> that represents directory separator char. Returns <b>'/'</b> in <b>Unix</b> system or <b>'\'</b> in <b>Windows</b> system.
        /// </summary>
        public static readonly char DirectorySeparatorChar = PlatformInformation.IsUnix ? '/' : '\\';

        /// <summary>
        /// Returns a <see cref="char"/> that represents alternative directory separator char. Always returns <b>'/'</b> char.
        /// </summary>
        public const char AltDirectorySeparatorChar = '/';


        /// <summary>
        /// Gets a valid full path from a relative path, includes a paths on network drives
        /// </summary>
        /// <param name="path">Path</param>
        /// <returns>
        /// Valid full path.
        /// </returns>
        public static string PathResolver(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            return PathResolverImpl(path.Contains(":") ? UncPathResolver(path) : path);
        }

        /// <summary>
        /// Resolves a mapped network drive into valid <b>UNC</b> path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns>
        /// <b>UNC</b> path.
        /// </returns>
        public static string UncPathResolver(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            if (Environment.OSVersion.Platform == PlatformID.MacOSX || Environment.OSVersion.Platform == PlatformID.Unix)
            {
                return path;
            }

            if (IsNetworkDrive(path))
            {
                return $"{RegistryOperations.GetCurrentUserKeyValue<string>($@"Network\\{path.ToUpperInvariant()[0]}", "RemotePath")}{path.Remove(0, 2)}";
            }

            return path;
        }

        /// <summary>
        /// Checks if the given path is a network drive.
        /// </summary>
        /// <param name="path">The path to check.</param>
        /// <returns>
        /// <b>true</b> if is a network drive; otherwise <b>false</b>.
        /// </returns>
        public static bool IsNetworkDrive(string path) => !string.IsNullOrEmpty(path) && RegistryOperations.CheckCurrentUserKey($@"Network\\{path.ToUpperInvariant()[0]}");



        /// <summary>
        /// Gets a valid full path from a relative path.
        /// </summary>
        /// <param name="relativePath">Element to recover.</param>
        /// <returns>
        /// Valid full path.
        /// </returns>
        /// <exception cref="ArgumentNullException">The value specified is outside the range of valid values.</exception>
        private static string PathResolverImpl(string relativePath)
        {
            if (string.IsNullOrEmpty(relativePath))
            {
                throw new ArgumentNullException(nameof(relativePath));
            }

            var relativePathNormalized = relativePath.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
            var isRelativePath = relativePathNormalized.Trim().StartsWith("~", StringComparison.Ordinal);
            if (!isRelativePath)
            {
                return relativePath;
            }

            if (relativePathNormalized.Length.Equals(1))
            {
                relativePathNormalized = relativePathNormalized.Insert(1, Path.DirectorySeparatorChar.ToString());
            }
            else if (!relativePathNormalized[1].Equals(Path.DirectorySeparatorChar))
            {
                relativePathNormalized = relativePathNormalized.Insert(1, Path.DirectorySeparatorChar.ToString());
            }

            var callingUri = AssemblyHelper.GetFullAssemblyUri();
            var candidateUri = new UriBuilder(callingUri);
            var unscapedCandidateUri = Uri.UnescapeDataString(candidateUri.Path);
            var candidateRootPath = NativePath.GetDirectoryName(unscapedCandidateUri);

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

            return NativePath.Combine(runtimeRootPath, outputPartialPath);
        }
    }
}
