using System;

namespace OGA.SharedKernel.Exceptions
{
    /// <summary>
    /// Thrown by domain entities or services when a business-level violation has occcurred.
    /// This is typically thrown by a domain service, caught by action logic in a REST endpoint, and turned into an appropriate http status code response.
    /// </summary>
    [Serializable]
    public class BusinessRuleBrokenException : BaseException
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public BusinessRuleBrokenException()
        {

        }

        /// <summary>
        /// Use this constructor when no inner-exception to include.
        /// </summary>
        /// <param name="message"></param>
        public BusinessRuleBrokenException(string message) : base(message)
        {

        }

        /// <summary>
        /// Use this constructor to include an inner-exception.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public BusinessRuleBrokenException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
