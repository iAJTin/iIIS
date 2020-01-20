﻿
namespace iTin.Core.Min.ComponentModel
{
    /// <summary>
    /// Defines a generic result error
    /// </summary>
    public class ResultError
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResultError"/> class.
        /// </summary>
        public ResultError()
        {
            Code = string.Empty;
            Type = string.Empty;
            Message = string.Empty;
            Exception = null;
        }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets exception.
        /// </summary>
        /// <value>The exception.</value>
        public System.Exception Exception { get; set; }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        public override string ToString() => $"Code = \"{Code}\"";
    }
}