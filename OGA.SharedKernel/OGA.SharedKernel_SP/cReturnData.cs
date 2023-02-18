using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGA.SharedKernel
{
    public class cReturnData
    {
        #region Public Properties

        public int Result { get; set; }
        public string Message { get; set; }

        #endregion


        #region ctor / dtor

        public cReturnData()
        {
            this.Result = 0;
            this.Message = string.Empty;
        }

        #endregion
    }
}
