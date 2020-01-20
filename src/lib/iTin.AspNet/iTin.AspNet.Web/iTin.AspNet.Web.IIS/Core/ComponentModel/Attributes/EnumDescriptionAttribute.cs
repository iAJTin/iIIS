
namespace iTin.Core.ComponentModel
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Specifies a description for an item of type listed.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class EnumDescriptionAttribute : DescriptionAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumDescriptionAttribute"/> class. 
        /// </summary>
        /// <param name="description">Description text.</param>
        public EnumDescriptionAttribute(string description) : base(description)
        {
        }
    }
}
