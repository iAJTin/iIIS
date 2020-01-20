
namespace iTin.Core.ComponentModel
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines a generic result.
    /// </summary>
    public interface IResult
    {
        /// <summary>
        /// Gets a value that indicates whether the current operation was executed successfully.
        /// </summary>
        /// <value>
        /// <c>true</c> if current operation was executed successfully; otherwise, <c>false</c>.
        /// </value>
        bool Success { get; set; }

        /// <summary>
        /// Gets a value that indicates whether the current operation was executed successfully with warnings.
        /// </summary>
        /// <value>
        /// <c>true</c> if current operation was executed successfully with warnings; otherwise, <c>false</c>.
        /// </value>
        bool HasWarnings { get; }

        /// <summary>
        /// Gets or sets a value that contains the result information.
        /// </summary>
        /// <value>
        /// The result information.
        /// </value>
        IResultData Data { get; set; }

        /// <summary>
        /// Gets or sets a value that contains an errors list.
        /// </summary>
        /// <value>
        /// Errors list.
        /// </value>
        IEnumerable<IResultErrorData> Errors { get; set; }

        /// <summary>
        /// Gets or sets a value that contains a warnings list.
        /// </summary>
        /// <value>
        /// Warnings list.
        /// </value>
        IEnumerable<string> Warnings { get; set; }
    }
}
