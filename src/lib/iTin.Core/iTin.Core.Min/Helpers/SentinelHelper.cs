
namespace iTin.Core.Min.Helpers
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// Static class than contains methods for perform tests and validate data types and parameters.
    /// <para><strong>- Warning -</strong></para>
    /// This class is temporary and will be replaced in future versions by using <a href="http://research.microsoft.com/en-us/projects/contracts/">code contracts</a>, 
    /// obtaining the same results, but with type checking at compile time (if an exception may occur at runtime will not compile the application) while avoiding possible exceptions in run time.    
    /// </summary>
    public static class SentinelHelper
    {
        #region [public] {static} (void) ArgumentNull<T>(T, string): Performs a test on the method argument, and throws an exception of type ArgumentNullException if is null
        /// <summary>
        /// Performs a check against an argument, and throws a ArgumentNullException if it is null.
        /// </summary>
        /// <typeparam name="T">Type of the argument to be checked</typeparam>
        /// <param name="value">The target object, which cannot be null.</param>
        /// <param name="parameterName">The name of the parameter that is to be checked.</param>
        public static void ArgumentNull<T>(T value, string parameterName) where T : class
        {
            ArgumentNull(value, parameterName, string.Empty);
        }
        #endregion

        #region [public] {static} (void) ArgumentNull<T>(T, string, string): Performs a test on the method argument, and throws an exception of type ArgumentNullException with specified error message if is null
        /// <summary>
        /// Performs a test on the method argument, and throws an exception of type <exception cref="ArgumentNullException"/> with specified error message if is <strong>null</strong>.
        /// </summary>
        /// <typeparam name="T">Type of the argument to be checked</typeparam>
        /// <param name="value">The target object, which cannot be null.</param>
        /// <param name="parameterName">The name of the parameter that is to be checked.</param>
        /// <param name="message">Error message.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="parameterName"/> is <strong>null</strong>.</exception>
        public static void ArgumentNull<T>(T value, string parameterName, string message) where T : class
        {
            if (value != null)
            {
                return;
            }

            throw new ArgumentNullException(parameterName, message);
        }
        #endregion

        #region [public] {static} (bool) IsEnumValid<T>(T): Performs a test on the method argument
        /// <summary>
        /// Performs a test on the method argument.
        /// </summary>
        /// <typeparam name="T">Type of the argument to be checked.</typeparam>
        /// <param name="value">Check value</param>
        /// <returns>
        /// <b>true</b> if <paramref name="value"/> is a valid enum; otherwise, <strong>false</strong>.
        /// </returns>
        /// <exception cref="ArgumentException">If <paramref name="value"/> isn't an enumerated type.</exception>
        /// <exception cref="InvalidEnumArgumentException">If <paramref name="value"/> not part of the enumeration.</exception>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
        public static bool IsEnumValid<T>(T value) where T : struct => IsEnumValid(value, false);
        #endregion

        #region [public] {static} (bool) IsEnumValid<T>(T, bool): Performs a test on the method argument, if testOnly is false throws an exception of type InvalidEnumArgumentException if the specified value doesn't belong to enumeration
        /// <summary>
        /// Performs a test on the method argument, if <paramref name="testOnly"/> is <strong>false</strong> throws an exception of type <exception cref="InvalidEnumArgumentException"/> if the specified value doesn't belong to enumeration.
        /// </summary>
        /// <typeparam name="T">Type of the argument to be checked.</typeparam>
        /// <param name="value">Check value</param>
        /// <param name="testOnly"><strong>true</strong> for performs only a test.</param>
        /// <returns>
        /// <strong>true</strong> if <paramref name="value"/> is a valid enum; otherwise, <strong>false</strong>.
        /// </returns>
        /// <exception cref="ArgumentException">If <paramref name="value"/> isn't an enumerated type.</exception>
        /// <exception cref="InvalidEnumArgumentException">If <paramref name="value"/> not part of the enumeration.</exception>
        public static bool IsEnumValid<T>(T value, bool testOnly) where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("EnumArgumentException");
            }

            bool found = Enum.GetValues(typeof(T)).Cast<T>().Any(item => item.ToString().ToUpperInvariant().Equals(value.ToString().ToUpperInvariant()));
            if (testOnly)
            {
                return found;
            }

            if (!found)
            {
                throw new InvalidEnumArgumentException("Not found");
            }

            return true;
        }
        #endregion

        #region [public] {static} (void) IsTrue(bool): Performs a test on the method argument, and throws an exception of type InvalidOperationException if the specified expression is true
        /// <summary>
        /// Performs a test on the method argument, and throws an exception of type <exception cref="InvalidOperationException" /> if the specified expression is <strong>true</strong>.
        /// </summary>
        /// <param name="expression">Expression to evaluate.</param>
        /// <exception cref="System.InvalidOperationException">If the result is <strong>true</strong></exception>
        [Conditional("DEBUG")]
        public static void IsTrue(bool expression)
        {
            IsTrue(expression, string.Empty);
        }
        #endregion

        #region [public] {static} (void) IsTrue(bool, string): Performs a test on the method argument, and throws an exception of type InvalidOperationException if the specified expression is true
        /// <summary>
        /// Performs a test on the method argument, and throws an exception of type <exception cref="InvalidOperationException" /> if the specified expression is <strong>true</strong>.
        /// </summary>
        /// <param name="expression">Expression to evaluate.</param>
        /// <param name="message">Error message.</param>
        /// <exception cref="System.InvalidOperationException">If the result is <strong>true</strong></exception>
        [Conditional("DEBUG")]
        public static void IsTrue(bool expression, string message)
        {
            if (!expression)
            {
                return;
            }

            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException();
            }

            throw new ArgumentException(message);
        }
        #endregion

        #region [public] {static} (void) IsTrue(bool, Exception): Performs a test on the method argument, and throws an exception of type InvalidOperationException if the specified expression is true
        /// <summary>
        /// Performs a test on the method argument, and throws an specified exception if the specified expression is <strong>true</strong>.
        /// </summary>
        /// <param name="expression">Expression to evaluate.</param>
        /// <param name="exception">Error message.</param>
        /// <exception cref="InvalidOperationException">If the <paramref name="exception"/> is <strong>null</strong>.</exception>
        [Conditional("DEBUG")]
        public static void IsTrue(bool expression, Exception exception)
        {
            if (!expression)
            {
                return;
            }

            if (exception != null)
            {
                throw exception;
            }

            throw new ArgumentException();
        }
        #endregion
    }
}
