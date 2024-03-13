using System;

namespace OGA.SharedKernel.Exceptions
{
    /// <summary>
    /// Notifies calling logic that the user context has inadequate privilege/permission to work with a resource.
    /// Typically thrown by a domain service to indicate when a user lacks privilege for some action of a resource.
    /// For example: This will be thrown if a user attempts to change the password of a peer, without admin privileges.
    /// </summary>

    [Serializable]
    public class AccessControlException : BaseException
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public AccessControlException()
        {

        }

        /// <summary>
        /// Use this constructor when no inner-exception to include.
        /// </summary>
        /// <param name="message"></param>
        public AccessControlException(string message) : base(message)
        {

        }

        /// <summary>
        /// Use this constructor to include an inner-exception.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public AccessControlException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
