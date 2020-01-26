
namespace iTin.Core.Min
{
    using System;
    using System.ComponentModel;
    using System.Reflection;

    using ComponentModel;

    /// <summary>
    /// Static class than contains extension methods for items of type <see cref="Enum"/>.
    /// </summary>
    public static class EnumExtensions
    {
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
    }
}
