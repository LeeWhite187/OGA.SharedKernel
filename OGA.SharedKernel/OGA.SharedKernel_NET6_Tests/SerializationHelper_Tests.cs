using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OGA.SharedKernel.Extensions.DateandTime;
using OGA.SharedKernel_NET6_Tests.Helper_Classes;
using System;

namespace OGA.SharedKernel_NET6_Tests
{
    [TestClass]
    public class SerializationHelper_Tests
    {
        // Verify recovery of type name from a primitive type...
        [TestMethod]
        public void Test1()
        {
            string val = Guid.NewGuid().ToString();

            // Have the helper get the type...
            var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

            if(valtype != "String")
                Assert.Fail("Wrong value.");
        }

        // Verify recovery of type name from a generic type...
        [TestMethod]
        public void Test2()
        {
            string val = Guid.NewGuid().ToString();

            // Have the helper get the type...
            var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

            var gt = new GenericSampleType<string>(val, valtype);


            // Have the helper get the type...
            var gentypename = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(gt);

            if(gentypename != "GenericSampleType<String>")
                Assert.Fail("Wrong value.");
        }

        // Verify recovery of type name from a multi-type generic...
        [TestMethod]
        public void Test3()
        {
            string val1 = Guid.NewGuid().ToString();
            string val2 = Guid.NewGuid().ToString();

            // Have the helper get the type...
            var valtype1 = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val1);
            var valtype2 = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val2);

            var gt = new MultiGenericSampleType<string, string>(val1, val2, valtype1, valtype2);


            // Have the helper get the type...
            var gentypename = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(gt);

            if(gentypename != "MultiGenericSampleType<String, String>")
                Assert.Fail("Wrong value.");
        }

        // Verify recovery of type name from a complex, multi-type generic...
        [TestMethod]
        public void Test4()
        {
            // Create the inner generic...
            var gt = new GenericSampleType<string>(Guid.NewGuid().ToString(), "String");

            string val1 = Guid.NewGuid().ToString();
            string val2 = Guid.NewGuid().ToString();

            // Have the helper get the type...
            var valtype1 = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val1);
            var valtype2 = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val2);

            var gt2 = new MultiGenericSampleType<GenericSampleType<string>, string>(gt, val2, "GenericSampleType<String>", valtype2);


            // Have the helper get the type...
            var gentypename = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(gt2);

            if(gentypename != "MultiGenericSampleType<GenericSampleType<String>, String>")
                Assert.Fail("Wrong value.");
        }
    }
}
