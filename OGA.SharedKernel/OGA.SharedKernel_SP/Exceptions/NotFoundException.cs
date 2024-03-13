using System;

namespace OGA.SharedKernel.Exceptions
{
    /// <summary>
    /// Represents error that occurs if a queried object by a particular key is null (not found).
    /// </summary>
    [Serializable]
    public class NotFoundException : BaseException
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public NotFoundException()
        {

        }

        /// <summary>
        /// Initializes a new instance of the NotFoundException class with a specified name of the queried object and its key.
        /// </summary>
        /// <param name="objectname">Name of the queried object.</param>
        /// <param name="key">The value by which the object is queried.</param>
        public NotFoundException(string key, string objectname)
            : base($"Queried object {objectname} was not found, Key: {key}")
        {

        }

        /// <summary>
        /// Initializes a new instance of the NotFoundException class with a specified name of the queried object, its key,
        /// and the exception that is the cause of this exception.
        /// </summary>
        /// <param name="objectname">Name of the queried object.</param>
        /// <param name="key">The value by which the object is queried.</param>
        /// <param name="innerexception">The exception that is the cause of the current exception.</param>
        public NotFoundException(string key, string objectname, Exception innerexception)
            : base($"Queried object {objectname} was not found, Key: {key}", innerexception)
        {

        }
    }
}
