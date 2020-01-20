
namespace iTin.Core
{
    using System;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Static class than contains extension methods for objects of type <see cref="string"/>.
    /// </summary> 
    public static class StringExtensions
    {
        #region [public] {static} (bool) AsBoolean(this string): Tries to convert the value specified in its boolean equivalent value. Defaults value is false
        /// <summary>
        /// <para>Tries to convert the value specified in its boolean equivalent value. Default value is <c>false</c>.</para>
        /// <para>Supported values are: "true", "false", "yes", "no", "si", "on", "off", "t", "f", "y", "n", "1", "0".</para>
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>
        /// Returns a <see cref="bool" /> value that represents specified value.
        /// </returns>
        /// <exception cref="ArgumentException">Value is not a boolean value.</exception>
        public static bool AsBoolean(this string value)
        {
            if (!value.HasValue())
            {
                return false;
            }

            string val = value.ToLowerInvariant().Trim();
            switch (val)
            {
                case "true":
                    return true;

                case "false":
                    return false;

                case "on":
                    return true;

                case "off":
                    return false;

                case "yes":
                    return true;

                case "si":
                    return true;

                case "no":
                    return false;

                case "t":
                    return true;

                case "f":
                    return false;

                case "y":
                    return true;

                case "n":
                    return false;

                case "1":
                    return true;

                case "0":
                    return false;
            }

            ArgumentException ex = new ArgumentException("Value is not a boolean value.");
            throw ex;
        }
        #endregion

        #region [public] {static} (Stream) AsStream(this string, Encoding = null): Returns a new stream from target string encoding by specified encoding type. If is null uses defaults encoding
        /// <summary>
        /// Returns a new <see cref="Stream"/> from target <see cref="string"/> encoding by specified encoding type. If is <b>null</b> uses defaults encoding.
        /// If is <c>null</c> uses default encoding.
        /// </summary>
        /// <param name="target">Target string.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <returns>
        /// A new <see cref="Stream"/> from target string.
        /// </returns>
        public static Stream AsStream(this string target, Encoding encoding = null)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream, encoding ?? Encoding.Default);
            writer.Write(target);
            writer.Flush();
            stream.Position = 0;

            return stream;
        }
        #endregion

        #region [public] {static} (bool) HasValue(this string): Determines whether this value has a value
        /// <summary>
        /// Determines whether this value has a value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>
        /// <c>true</c> if specified value not is <c>null</c> or <c>Empty</c>; Otherwise, <strong>false</strong>.
        /// </returns>
        public static bool HasValue(this string value)
        {
            var hasValue = !string.IsNullOrEmpty(value);

            return hasValue;
        }
        #endregion

        #region [public] {static} (T) ToEnum<T>(this string, T = default): Converts string to enum object
        /// <summary>
        /// Converts string to enum object
        /// </summary>
        /// <typeparam name="T">Type of enum</typeparam>
        /// <param name="value">String value to convert</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>
        /// Returns enum object.
        /// </returns>
        public static T ToEnum<T>(this string value, T defaultValue = default) where T : struct
        {
            if (!value.HasValue())
            {
                return defaultValue;
            }

            try
            {
                T result = (T) Enum.Parse(typeof(T), value, true);
                return result;
            }
            catch (ArgumentException)
            {
                return defaultValue;
            }
        }
        #endregion

        #region [public] {static} (T) ToEnumByDescription<T>(this string): Converts string to enum object by emun description attribute
        /// <summary>
        /// Converts string to enum object by emun description attribute.
        /// </summary>
        /// <typeparam name="T">Type of enum</typeparam>
        /// <param name="description">Description of target enum value</param>
        /// <returns>Returns enum object</returns>
        public static T ToEnumByDescription<T>(this string description) where T : struct
        {
            T result = default;
            var items = Enum.GetValues(typeof(T));
            foreach (Enum item in items)
            {
                if (item.GetDescription() != description)
                {
                    continue;
                }

                result = (T)Enum.Parse(typeof(T), item.ToString(), true);
                break;
            }

            return result;
        }
        #endregion
    }
}
