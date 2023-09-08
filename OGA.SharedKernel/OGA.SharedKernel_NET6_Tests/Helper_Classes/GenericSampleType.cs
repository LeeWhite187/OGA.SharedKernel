using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGA.SharedKernel_NET6_Tests.Helper_Classes
{
    public class GenericSampleType<T>
    {
        public string DataType { get; set; }
        public T Data { get; set; }

        public GenericSampleType(T dat, string dtype)
        {
            DataType = dtype;
            Data = dat;
        }
    }
}
