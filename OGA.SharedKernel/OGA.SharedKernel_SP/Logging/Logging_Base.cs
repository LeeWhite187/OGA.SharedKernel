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

#if NET452
        /// <summary>
        /// Global Logging Reference.
        /// Is set during process startup, so there is a global logging reference if needed, without the fuss or instanciation latency and indirection of DI.
        /// </summary>
        static public NLog.Logger Logger_Ref { get; set; }
#elif NET47
        /// <summary>
        /// Global Logging Reference.
        /// Is set during process startup, so there is a global logging reference if needed, without the fuss or instanciation latency and indirection of DI.
        /// </summary>
        static public NLog.Logger Logger_Ref { get; set; }
#else
        /// <summary>
        /// Global Logging Reference.
        /// Is set during process startup, so there is a global logging reference if needed, without the fuss or instanciation latency and indirection of DI.
        /// </summary>
        static public NLog.Logger Logger_Ref { get; set; }
#endif

        #endregion

        #region ctor / dtor

        /// <summary>
        /// This static constructor added, to ensure the LoggerRef property always returns an instance.
        /// NOTE: Your code MUST still perform propert logging setup, as this was not intended to create the default logger instance.
        /// NOTE: It is merely satisfying the compiler warning that props must be non-null at constructor exit, and the edge case that calls to the logger without proper setup will throw.
        /// </summary>
        static Logging_Base()
        {
            Logger_Ref = NLog.LogManager.GetLogger("");
        }


        #endregion


        #region Public Methods

        /// <summary>
        /// Centralized method for quickly determining a method's name.
        /// </summary>
        /// <param name="caller"></param>
        /// <returns></returns>
#if NET452
        static public string GetCallerName([CallerMemberName] string caller = null)
#elif NET47
        static public string GetCallerName([CallerMemberName] string caller = null)
#else
        static public string? GetCallerName([CallerMemberName] string? caller = null)
#endif
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
