
namespace iTin.Core.Min
{
    using System.Collections.Generic;

    /// <summary>
    /// Static class than contains extension methods for generic List.
    /// </summary> 
    public static class ListExtensions
    {
        /// <summary>
        /// Determines if specified value is a valid index in list
        /// </summary>
        /// <typeparam name="T">Type element</typeparam>
        /// <param name="items">Target list</param>
        /// <param name="index">Value to test</param>
        /// <returns>
        /// <b>true</b> if is a valid index; otherwise <b>false</b>.
        /// </returns>
        public static bool IsValidIndex<T>(this IList<T> items, int index) => items != null && index >= 0 && index < items.Count;
    }
}
