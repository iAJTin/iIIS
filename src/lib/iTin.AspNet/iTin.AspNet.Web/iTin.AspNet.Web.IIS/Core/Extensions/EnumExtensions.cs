
namespace iTin.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;

    using iTin.Core.ComponentModel;
    using iTin.Core.Helpers;

    /// <summary>
    /// Static class than contains extension methods for items of type <see cref="Enum"/>.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Converts a value of the specified enumerated type into another enumerated type of type <c>T</c>.
        /// </summary>
        /// <typeparam name="T">Destination enum type</typeparam>
        /// <param name="target">Value to convert.</param>
        /// <returns>
        /// converted value.
        /// </returns>
        public static T AsEnumType<T>(this Enum target) where T : struct
        {
            int itemIndex = target.GetItemIndex();
            bool hasParse = Enum.TryParse(itemIndex.ToString(), out T result);
            if (hasParse)
            {
                return result;
            }

            return default;
        }

        /// <summary>
        /// Converts a set values of the specified enumerated type into another enumerated type of type <c>T</c>.
        /// </summary>
        /// <typeparam name="T">Destination enum type</typeparam>
        /// <param name="collection">Values to convert.</param>
        /// <returns>
        /// converted values.
        /// </returns>
        public static IEnumerable<T> AsEnumType<T>(this IEnumerable<Enum> collection) where T : struct => collection.Select(item => item.AsEnumType<T>()).ToList();

        /// <summary>
        /// Returns the value of attribute of type <see cref="EnumDescriptionAttribute"/> for this enum value. 
        /// If this attribute is not defined returns <b>null</b> (<b>Nothing</b> in Visual Basic)
        /// </summary>
        /// <param name="value">Target enum value.</param>
        /// <returns>
        /// A <see cref="string"/> that contains the value of attribute.
        /// </returns>
        public static string GetDescription(this Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name == null)
            {
                return null;
            }

            FieldInfo field = type.GetField(name);
            if (field == null)
            {
                return null;
            }

            DescriptionAttribute attr = Attribute.GetCustomAttribute(field, typeof(EnumDescriptionAttribute)) as EnumDescriptionAttribute;
            if (attr != null)
            {
                string result = attr.Description;

                return result;
            }

            return null;
        }

        /// <summary>
        /// Gets the next enum value. If it is the last item, the first item is returned.
        /// </summary>
        /// <typeparam name="T">Enumeration type</typeparam>
        /// <param name="value">Target value.</param>
        /// <returns>
        /// Returns next item of this enumeration. If it is the last item, the first item is returned.
        /// </returns>
        public static T GetNext<T>(this T value) where T : struct
        {
            List<string> items = EnumHelper.CreateListFromEnumValues<T>().ToList();
            string candidate = items.GetNextObject(value.ToString());
            bool isLastItem = string.IsNullOrEmpty(candidate);

            T result = 
                isLastItem
                    ? EnumHelper.CreateEnumTypeFromStringValue<T>(items.First())
                    : EnumHelper.CreateEnumTypeFromStringValue<T>(candidate);

            return result;
        }

        /// <summary>
        /// Gets the previous enum value. If it is the first item, the last item is returned.
        /// </summary>
        /// <typeparam name="T">Enumeration type</typeparam>
        /// <param name="value">Target value.</param>
        /// <returns>
        /// Returns previous item of this enumeration. If it is the first item, the last item is returned.
        /// </returns>
        public static T GetPrevious<T>(this T value) where T : struct
        {
            List<string> items = EnumHelper.CreateListFromEnumValues<T>().ToList();
            string candidate = items.GetPrevObject(value.ToString());
            bool isFirstItem = string.IsNullOrEmpty(candidate);

            T result =
                isFirstItem
                    ? EnumHelper.CreateEnumTypeFromStringValue<T>(items.Last())
                    : EnumHelper.CreateEnumTypeFromStringValue<T>(candidate);

            return result;
        }


        private static int GetItemIndex(this Enum value)
        {
            Type enumType = value.GetType();
            object enumTypedValue = Enum.Parse(enumType, value.ToString());

            return enumType.GetFields()[0].FieldType == typeof(byte)
               ? (byte)enumTypedValue 
               : (int)enumTypedValue;
        }
    }
}
