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
        public BusinessRuleBrokenException()
        {

        }

        public BusinessRuleBrokenException(string message) : base(message)
        {

        }

        public BusinessRuleBrokenException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
