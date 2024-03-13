using System;
using System.Globalization;

namespace OGA.SharedKernel.Exceptions
{
    /// <summary>
    /// Custom exception class for throwing application specific exceptions (e.g. for validation) 
    /// that can be caught and handled within the application.
    /// </summary>
    public class AppException : BaseException
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public AppException() : base() {}

        /// <summary>
        /// Use this constructor when no inner-exception to include.
        /// </summary>
        /// <param name="message"></param>
        public AppException(string message) : base(message) { }

        /// <summary>
        /// Use this constructor to include a list of object arguments that an application exception handler would parse for specific failure mode or diagnostic logging.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public AppException(string message, params object[] args) 
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }

        /// <summary>
        /// Use this constructor to include an inner-exception.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public AppException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}