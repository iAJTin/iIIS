
namespace iTin.Core.Min.ComponentModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <inheritdoc />
    /// <summary>
    /// Specialization of the interface <see cref="IResult"/> that acts as a base class that serves to defines a result.
    /// </summary>
    public class ResultBase : IResult
    {
        #region constructor/s

        #region [protected] ResultBase(): Initializes a new instance of the class
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="ResultBase" /> class.
        /// </summary>
        protected ResultBase() : this(null)
        {
        }
        #endregion

        #region [protected] ResultBase(IResultData): Initializes a new instance of the class
        /// <summary>
        /// Initializes a new instance of the <see cref="ResultBase" /> class.
        /// </summary>
        /// <param name="data">
        /// Result value.
        /// </param>
        protected ResultBase(IResultData data)
        {
            Data = data;
            Success = false;
            Warnings = new List<string>();
            Errors = new List<IResultErrorData>();
        }
        #endregion

        #endregion

        #region public static properties

        #region [public] {static} (IResult) ErrorResult: Returns a new result indicating that output result not has been successfully
        /// <summary>
        /// Returns a new result indicating that output result not has been successfully.
        /// </summary>
        public static IResult ErrorResult => new ResultBase {Success = false};
        #endregion

        #region [public] {static} (IResult) NullResult: Returns a new result indicating a null result
        /// <summary>
        /// Returns a new result indicating a null result.
        /// </summary>
        public static IResult NullResult => new ResultBase();
        #endregion

        #region [public] {static} (IResult) SuccessResult: Returns a new result indicating that output result has been successfully
        /// <summary>
        /// Returns a new result indicating that output result has been successfully.
        /// </summary>
        public static IResult SuccessResult => new ResultBase { Success = true };
        #endregion

        #endregion

        #region public readonly properties

        #region [public] (bool) HasWarnings: Gets a value that indicates whether the last operation has warnings
        /// <inheritdoc />
        /// <summary>
        /// Gets a value that indicates whether the last operation has warnings.
        /// </summary>
        /// <value>
        /// <c>true</c> if last operation has warnings; otherwise, <c>false</c>.
        /// </value>
        public bool HasWarnings => Warnings != null && Warnings.Any();

        #endregion

        #endregion

        #region public properties

        #region [public] (IResultData) Data: Gets or sets a value that contains the result information
        /// <inheritdoc />
        /// <summary>
        /// Gets or sets a value that contains the result information.
        /// </summary>
        /// <value>
        /// The result information.
        /// </value>
        public IResultData Data { get; set; }
        #endregion

        #region [public] (bool) Success: Gets or sets a value that indicates whether the current operation was executed successfully
        /// <inheritdoc />
        /// <summary>
        /// Gets or sets a value that indicates whether the current operation was executed successfully.
        /// </summary>
        /// <value>
        /// <c>true</c> if current operation was executed successfully; otherwise, <c>false</c>.
        /// </value>
        public bool Success { get; set; }
        #endregion

        #region [public] (IEnumerable<ResultError>) Errors: Gets or sets a value that contains an error list
        /// <inheritdoc />
        /// <summary>
        /// Gets or sets a value that contains an error list.
        /// </summary>
        /// <value>
        /// Error list.
        /// </value>
        public IEnumerable<IResultErrorData> Errors { get; set; }
        #endregion

        #region [public] (IEnumerable<string>) Warnings: Gets or sets a value that contains a warnings messages list
        /// <inheritdoc />
        /// <summary>
        /// Gets or sets a value that contains a warnings messages list.
        /// </summary>
        /// <value>
        /// Warnings list.
        /// </value>
        public IEnumerable<string> Warnings { get; set; }
        #endregion

        #endregion

        #region public static methods

        #region [public] {static} (ResultBase) FromException(Exception): Creates a new instance from known exception
        /// <summary>
        /// Creates a new instance from known exception.
        /// </summary>
        /// <param name="exception">Target exception.</param>
        /// <returns>
        /// A new <see cref="ResultBase"/> instance for specified exception.
        /// </returns>
        public static ResultBase FromException(Exception exception) => new ResultBase { Errors = new List<ResultExceptionError> { new ResultExceptionError { Exception = exception, Message = exception.Message } } };
        #endregion

        #endregion

        #region public override methods

        #region [public] {override} (string) ToString(): Returns a string than represents the current object.
        /// <summary>
        /// Returns a string that represents the current data type.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> than represents the current object.
        /// </returns>
        public override string ToString() => $"Success = {Success}, HasWarnings = {HasWarnings}";
        #endregion

        #endregion
    }
}
