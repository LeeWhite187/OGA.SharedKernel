using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGA.SharedKernel
{
    /// <summary>
    /// Used by some libraries that return a numeric error code and message.
    /// </summary>
    public class cReturnData
    {
        #region Public Properties

        /// <summary>
        /// The return code of the method call.
        /// Typically, positive returns are success, zero is a neutral response, and negatives are errors.
        /// </summary>
        public int Result { get; set; }
        /// <summary>
        /// Normally set when the called method returns an error status.
        /// This field will contain the error message.
        /// </summary>
        public string Message { get; set; }

        #endregion


        #region ctor / dtor

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public cReturnData()
        {
            this.Result = 0;
            this.Message = string.Empty;
        }

        #endregion
    }
}
