
using System.Threading.Tasks;

using iTin.Core.ComponentModel;

namespace iTin.AspNet.Web.IIS.ComponentModel
{
    /// <summary>
    /// Defines a generic operations for a command
    /// </summary>
    public interface IAsyncExecute
    {
        /// <summary>
        /// Executes the command asynchronously.
        /// </summary>
        /// <returns>
        /// Operation result
        /// </returns>
        Task<IResult> ExecuteAsync();
    }
}
