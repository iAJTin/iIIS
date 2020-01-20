
namespace Syntec.AspNet.Web
{
    using ComponentModel;

    /// <summary>
    /// 
    /// </summary>
    public class AspDetector : IAspDetector
    {
        public bool AspIsRunning
        {
            get
            {
                #if DEBUG
					return HttpContextAccessor.Current != null;
                #else
                    return !Environment.UserInteractive || HttpContextAccessor.Current != null;
                #endif
            }
        }
    }
}
