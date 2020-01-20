
namespace iTin.Core.Min.Helpers
{
    using System.Linq;
	using System.Reflection;
    using System.Runtime.Versioning;

	using iTin.Core.Min.ComponentModel;

	/// <summary>
	/// Static class which contains methods for retrieve <b>.NET Framework</b> information.
	/// </summary>
	public static class NetFrameworkHelper
    {
        /// <summary>
        /// Returns <see cref="FrameworkVersion"/> that contains full path to current assembly.
        /// </summary>
        /// <returns>
        /// A <see cref="FrameworkVersion"/> that contains full path to current assembly.
        /// </returns>
        public static FrameworkVersion GetAssemblyFrameworkVersion(Assembly assembly) => new FrameworkVersion((TargetFrameworkAttribute)assembly.GetCustomAttributes(typeof(TargetFrameworkAttribute), false).SingleOrDefault());
    }
}
