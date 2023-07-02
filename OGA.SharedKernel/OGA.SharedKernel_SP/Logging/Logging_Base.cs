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

        /// <summary>
        /// Centralized method for quickly determining a method's name.
        /// Centralized method for quickly getting the source file, line number, and method name.
        /// To use, call it without setting any parameters.
        /// It returns a triplet of the source file, line, and method name.
        /// </summary>
        /// <returns></returns>
        static public (string filepath, int lineno, string function) Get_CallSite_Data(
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineno = -1,
            [CallerMemberName] string function = "")
        {
            return (filePath, lineno, function);
        }

        #endregion
    }
}
