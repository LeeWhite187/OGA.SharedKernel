using System;

namespace OGA.SharedKernel.Exceptions
{
    /// <summary>
    /// Represents the base exception for all custom exception types.
    /// </summary>

    [Serializable]
    public class BaseException : ApplicationException
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public BaseException()
        {

        }

        /// <summary>
        /// Use this constructor when no inner-exception to include.
        /// </summary>
        /// <param name="message"></param>
        public BaseException(string message) : base(message)
        {

        }

        /// <summary>
        /// Use this constructor to include an inner-exception.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public BaseException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
