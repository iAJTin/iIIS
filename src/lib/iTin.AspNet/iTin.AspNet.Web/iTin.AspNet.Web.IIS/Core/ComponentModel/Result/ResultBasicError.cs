
namespace iTin.Core.ComponentModel
{
    /// <summary>
    /// Defines a generic basic result error
    /// </summary>
    public class ResultBasicError : IResultErrorData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResultBasicError"/> class.
        /// </summary>
        public ResultBasicError()
        {
            Code = string.Empty;
            Message = string.Empty;
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        public string Code { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }
    }
}
