using System;

namespace OGA.SharedKernel.Exceptions
{
    /// <summary>
    /// Used by domain services to notify calling logic that a an entity already exists.
    /// This is typically used when attempting to create a duplicate record, duplicate username, etc.
    /// It is thrown by a domain service, caught by a REST action, and translated into an Http Status for the API caller.
    /// </summary>
    [Serializable]
    public class AlreadyExistsException : BaseException
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public AlreadyExistsException()
        {

        }

        /// <summary>
        /// Use this constructor when no inner-exception to include.
        /// </summary>
        /// <param name="message"></param>
        public AlreadyExistsException(string message) : base(message)
        {

        }

        /// <summary>
        /// Use this constructor to include an inner-exception.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public AlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
