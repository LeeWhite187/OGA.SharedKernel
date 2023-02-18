using System;

namespace OGA.SharedKernel.Exceptions
{
    /// <summary>
    /// Represents the base exception for all custom exception types.
    /// </summary>

    [Serializable]
    public class BaseException : ApplicationException
    {
        public BaseException()
        {

        }

        public BaseException(string message) : base(message)
        {

        }

        public BaseException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
