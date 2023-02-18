using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OGA.SharedKernel
{
    /// <summary>
    /// Logging Reference, placed in Shared Kernel, for process-wide logging.
    /// </summary>
    public class Logging_Base
    {
        #region Public Properties

        /// <summary>
        /// Global Logging Reference.
        /// Is set during process startup, so there is a global logging reference if needed, without the fuss or instanciation latency and indirection of DI.
        /// </summary>
        static public NLog.Logger Logger_Ref { get; set; }

        #endregion


        #region Public Methods

        /// <summary>
        /// Centralized method for quickly determining a method's name.
        /// </summary>
        /// <param name="caller"></param>
        /// <returns></returns>
        static public string GetCallerName([CallerMemberName] string caller = null)
        {
            return caller;
        }

        #endregion
    }
}
