
namespace iTin.Core.Min.Helpers
{
    using System;
    using System.Linq;

    /// <summary>
    /// Static class than contains methods for manipulating objects of type <see cref="Enum"/>.
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Returns a <see cref="Enum"/> whose description matches the indicated value.
        /// </summary>
        /// <returns>
        /// A <see cref="Enum"/> whose description matches the indicated value.
        /// </returns>
        public static Enum CreateEnumTypeFromDescriptionAttribute<T>(string descriptionEnum) where T : struct
        {
            Type t = typeof(T);

            if (!t.IsEnum)
            {
                return null;
            }

            return Enum.GetValues(t).Cast<Enum>().FirstOrDefault(item => string.Equals(item.GetDescription(), descriptionEnum, StringComparison.InvariantCultureIgnoreCase));
        }

        /// <summary>
        /// Returns a <see cref="T:System.Enum" /> whose enum value matches the indicated value.
        /// </summary>
        /// <returns>
        /// An enum value whose enum value matches the indicated value.
        /// </returns>
        public static T CreateEnumTypeFromStringValue<T>(string enumValue) where T : struct
        {
            Type t = typeof(T);

            if (!t.IsEnum)
            {
                return default;
            }

            bool parsed = Enum.TryParse(enumValue, out T result);
            return parsed ? result : default;
        }

    }
}
