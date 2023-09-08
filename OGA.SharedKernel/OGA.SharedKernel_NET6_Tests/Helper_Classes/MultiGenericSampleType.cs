using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGA.SharedKernel_NET6_Tests.Helper_Classes
{
    public class MultiGenericSampleType<T1, T2>
    {
        public string DataType1 { get; set; }
        public string DataType2 { get; set; }
        public T1 Data1 { get; set; }
        public T2 Data2 { get; set; }

        public MultiGenericSampleType(T1 dat1, T2 dat2, string dtype1, string dtype2)
        {
            DataType1 = dtype1;
            DataType2 = dtype2;
            Data1 = dat1;
            Data2 = dat2;
        }
    }
}
