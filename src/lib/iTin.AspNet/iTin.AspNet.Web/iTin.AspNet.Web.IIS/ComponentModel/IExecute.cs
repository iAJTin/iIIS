﻿
namespace iTin.AspNet.Web.IIS.ComponentModel
{
    using iTin.Core.Min.ComponentModel;

    /// <summary>
    /// Defines a generic operations for a command
    /// </summary>
    public interface IExecute
    {
        /// <summary>
        /// Executes the command synchronously.
        /// </summary>
        /// <returns>
        /// Operation result
        /// </returns>
        IResult Execute();
    }
}
