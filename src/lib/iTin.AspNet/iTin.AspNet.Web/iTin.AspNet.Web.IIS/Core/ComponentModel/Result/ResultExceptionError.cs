
namespace iTin.Core.ComponentModel
{
    /// <summary>
    /// Defines a generic basic result error
    /// </summary>
    public class ResultExceptionError : ResultBasicError
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="ResultExceptionError" /> class.
        /// </summary>
        public ResultExceptionError()
        {
            Exception = null;
            Code = string.Empty;
            Message = string.Empty;
        }

        /// <summary>
        /// Gets or sets exception.
        /// </summary>
        /// <value>The exception.</value>
        public System.Exception Exception { get; set; }
    }
}
