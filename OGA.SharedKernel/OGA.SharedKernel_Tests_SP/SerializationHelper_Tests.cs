using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OGA.SharedKernel.Extensions.DateandTime;
using OGA.SharedKernel_Tests.Helper_Classes;
using System;

namespace OGA.SharedKernel_Tests
{
    /*  Tests to verify functionality in Serialization_Helper.
         
        //  Test_1_1_1  Verify recovery of type name from a bool type as boolean.
        //              Verify recovery of type name from a nullable bool type as boolean?.
        //              Verify recovery of type name from a bool instance as boolean.
        //              Verify recovery of type name from a nullable bool instance as boolean.
        //  Test_1_1_2  Verify recovery of type name from a byte type as byte.
        //              Verify recovery of type name from a nullable byte type as byte?.
        //              Verify recovery of type name from a byte instance as byte.
        //              Verify recovery of type name from a nullable byte instance as byte.
        //  Test_1_1_3  Verify recovery of type name from a Int32 type as Int32.
        //              Verify recovery of type name from a nullable Int32 type as Int32?.
        //              Verify recovery of type name from a Int32 instance as Int32.
        //              Verify recovery of type name from a nullable Int32 instance as Int32.
        //  Test_1_1_4  Verify recovery of type name from a Int64 type as Int64.
        //              Verify recovery of type name from a nullable Int64 type as Int64?.
        //              Verify recovery of type name from a Int64 instance as Int64.
        //              Verify recovery of type name from a nullable Int64 instance as Int64.
        //  Test_1_1_5  Verify recovery of type name from a float type as float.
        //              Verify recovery of type name from a nullable float type as float?.
        //              Verify recovery of type name from a float instance as float.
        //              Verify recovery of type name from a nullable float instance as float.
        //  Test_1_1_6  Verify recovery of type name from a double type as double.
        //              Verify recovery of type name from a nullable double type as double?.
        //              Verify recovery of type name from a double instance as double.
        //              Verify recovery of type name from a nullable double instance as double.
        //  Test_1_1_7  Verify recovery of type name from a string type.
        //              The CLR has no runtime method of determining a nullable string type.
        //              And, attempting to do: Type val = typeof(string?); gives a compiler error.
        //              So, we will not specifically test for a nullable string type.
        //              Verify recovery of type name from a nullable string type as 'String'.
        //              Verify recovery of type name from a string instance as 'String'.
        //              Verify recovery of type name from a nullable string instance as 'String'.
        //  Test_1_1_8  Verify recovery of type name from a Guid type as Guid.
        //              Verify recovery of type name from a nullable Guid type as Guid?.
        //              Verify recovery of type name from a Guid instance as Guid.
        //              Verify recovery of type name from a nullable Guid instance as Guid.
        //  Test_1_1_9  Verify recovery of type name from a DateTime type as DateTime.
        //              Verify recovery of type name from a nullable DateTime type as DateTime?.
        //              Verify recovery of type name from a DateTime instance as DateTime.
        //              Verify recovery of type name from a nullable DateTime instance as DateTime.
        //  Test_1_1_10 Verify recovery of type name from a DateTimeOffset type as DateTimeOffset.
        //              Verify recovery of type name from a nullable DateTimeOffset type as DateTimeOffset?.
        //              Verify recovery of type name from a DateTimeOffset instance as DateTimeOffset.
        //              Verify recovery of type name from a nullable DateTimeOffset instance as DateTimeOffset.

        //  Test_1_2_1  Verify recovery of type name from a generic type...
        //  Test_1_2_2  Verify recovery of type name from a multi-type generic...
        //  Test_1_2_3  Verify recovery of type name from a complex, multi-type generic...

     */

    [TestClass]
    public class SerializationHelper_Tests
    {
        //  Test_1_1_1  Verify recovery of type name from a bool type as boolean.
        //              Verify recovery of type name from a nullable bool type as boolean?.
        //              Verify recovery of type name from a bool instance as boolean.
        //              Verify recovery of type name from a nullable bool instance as boolean.
        [TestMethod]
        public void Test_1_1_1()
        {
            // bool type...
            {
                Type val = typeof(bool);

                // Have the helper get the type...
                var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

                if(valtype != "Boolean")
                    Assert.Fail("Wrong value.");
            }

            // Nullable bool type...
            {
                Type val = typeof(bool?);

                // Have the helper get the type...
                var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

                if(valtype != "Boolean?")
                    Assert.Fail("Wrong value.");
            }

            // bool instance...
            {
                bool val = true;

                // Have the helper get the type...
                var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

                if(valtype != "Boolean")
                    Assert.Fail("Wrong value.");
            }

            // Nullable bool instance...
            {
                bool? val = true;

                // Have the helper get the type...
                var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

                if(valtype != "Boolean")
                    Assert.Fail("Wrong value.");
            }
        }

        //  Test_1_1_2  Verify recovery of type name from a byte type as byte.
        //              Verify recovery of type name from a nullable byte type as byte?.
        //              Verify recovery of type name from a byte instance as byte.
        //              Verify recovery of type name from a nullable byte instance as byte.
        [TestMethod]
        public void Test_1_1_2()
        {
            // byte type...
            {
                Type val = typeof(byte);

                // Have the helper get the type...
                var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

                if(valtype != "Byte")
                    Assert.Fail("Wrong value.");
            }

            // Nullable byte type...
            {
                Type val = typeof(byte?);

                // Have the helper get the type...
                var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

                if(valtype != "Byte?")
                    Assert.Fail("Wrong value.");
            }

            // byte instance...
            {
                byte val = 123;

                // Have the helper get the type...
                var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

                if(valtype != "Byte")
                    Assert.Fail("Wrong value.");
            }

            // Nullable byte instance...
            {
                byte? val = 123;

                // Have the helper get the type...
                var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

                if(valtype != "Byte")
                    Assert.Fail("Wrong value.");
            }
        }

        //  Test_1_1_3  Verify recovery of type name from a Int32 type as Int32.
        //              Verify recovery of type name from a nullable Int32 type as Int32?.
        //              Verify recovery of type name from a Int32 instance as Int32.
        //              Verify recovery of type name from a nullable Int32 instance as Int32.
        [TestMethod]
        public void Test_1_1_3()
        {
            // int type...
            {
                Type val = typeof(int);

                // Have the helper get the type...
                var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

                if(valtype != "Int32")
                    Assert.Fail("Wrong value.");
            }

            // Nullable int type...
            {
                Type val = typeof(int?);

                // Have the helper get the type...
                var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

                if(valtype != "Int32?")
                    Assert.Fail("Wrong value.");
            }

            // int instance...
            {
                int val = 123;

                // Have the helper get the type...
                var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

                if(valtype != "Int32")
                    Assert.Fail("Wrong value.");
            }

            // Nullable int instance...
            {
                int? val = 123;

                // Have the helper get the type...
                var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

                if(valtype != "Int32")
                    Assert.Fail("Wrong value.");
            }
        }

        //  Test_1_1_4  Verify recovery of type name from a Int64 type as Int64.
        //              Verify recovery of type name from a nullable Int64 type as Int64?.
        //              Verify recovery of type name from a Int64 instance as Int64.
        //              Verify recovery of type name from a nullable Int64 instance as Int64.
        [TestMethod]
        public void Test_1_1_4()
        {
            // long type...
            {
                Type val = typeof(long);

                // Have the helper get the type...
                var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

                if(valtype != "Int64")
                    Assert.Fail("Wrong value.");
            }

            // Nullable long type...
            {
                Type val = typeof(long?);

                // Have the helper get the type...
                var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

                if(valtype != "Int64?")
                    Assert.Fail("Wrong value.");
            }

            // long instance...
            {
                long val = 123;

                // Have the helper get the type...
                var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

                if(valtype != "Int64")
                    Assert.Fail("Wrong value.");
            }

            // Nullable long instance...
            {
                long? val = 123;

                // Have the helper get the type...
                var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

                if(valtype != "Int64")
                    Assert.Fail("Wrong value.");
            }
        }

        //  Test_1_1_5  Verify recovery of type name from a float type as float.
        //              Verify recovery of type name from a nullable float type as float?.
        //              Verify recovery of type name from a float instance as float.
        //              Verify recovery of type name from a nullable float instance as float.
        [TestMethod]
        public void Test_1_1_5()
        {
            // float type...
            {
                Type val = typeof(float);

                // Have the helper get the type...
                var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

                if(valtype != "Single")
                    Assert.Fail("Wrong value.");
            }

            // Nullable float type...
            {
                Type val = typeof(float?);

                // Have the helper get the type...
                var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

                if(valtype != "Single?")
                    Assert.Fail("Wrong value.");
            }

            // float instance...
            {
                float val = 123.45f;

                // Have the helper get the type...
                var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

                if(valtype != "Single")
                    Assert.Fail("Wrong value.");
            }

            // Nullable float instance...
            {
                float? val = 123.45f;

                // Have the helper get the type...
                var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

                if(valtype != "Single")
                    Assert.Fail("Wrong value.");
            }
        }

        //  Test_1_1_6  Verify recovery of type name from a double type as double.
        //              Verify recovery of type name from a nullable double type as double?.
        //              Verify recovery of type name from a double instance as double.
        //              Verify recovery of type name from a nullable double instance as double.
        [TestMethod]
        public void Test_1_1_6()
        {
            // double type...
            {
                Type val = typeof(double);

                // Have the helper get the type...
                var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

                if(valtype != "Double")
                    Assert.Fail("Wrong value.");
            }

            // Nullable double type...
            {
                Type val = typeof(double?);

                // Have the helper get the type...
                var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

                if(valtype != "Double?")
                    Assert.Fail("Wrong value.");
            }

            // double instance...
            {
                double val = 123.4567;

                // Have the helper get the type...
                var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

                if(valtype != "Double")
                    Assert.Fail("Wrong value.");
            }

            // Nullable double instance...
            {
                double? val = 123.4567;

                // Have the helper get the type...
                var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

                if(valtype != "Double")
                    Assert.Fail("Wrong value.");
            }
        }

        //  Test_1_1_7  Verify recovery of type name from a string type.
        //              The CLR has no runtime method of determining a nullable string type.
        //              And, attempting to do: Type val = typeof(string?); gives a compiler error.
        //              So, we will not specifically test for a nullable string type.
        //              Verify recovery of type name from a nullable string type as 'String'.
        //              Verify recovery of type name from a string instance as 'String'.
        //              Verify recovery of type name from a nullable string instance as 'String'.
        [TestMethod]
        public void Test_1_1_7()
        {
            // string type...
            {
                Type val = typeof(String);

                // Have the helper get the type...
                var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

                if(valtype != "String")
                    Assert.Fail("String value.");
            }

            // string instance...
            {
                string val = Guid.NewGuid().ToString();

                // Have the helper get the type...
                var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

                if(valtype != "String")
                    Assert.Fail("Wrong value.");
            }

            // Nullable string instance...
            {
                string? val = Guid.NewGuid().ToString();

                // Have the helper get the type...
                var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

                if(valtype != "String")
                    Assert.Fail("Wrong value.");
            }

            // Nullable string instance as null...
            {
                string? val = Guid.NewGuid().ToString();

                // Have the helper get the type...
                var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

                if(valtype != "String")
                    Assert.Fail("Wrong value.");
            }
        }

        //  Test_1_1_8  Verify recovery of type name from a Guid type as Guid.
        //              Verify recovery of type name from a nullable Guid type as Guid?.
        //              Verify recovery of type name from a Guid instance as Guid.
        //              Verify recovery of type name from a nullable Guid instance as Guid.
        [TestMethod]
        public void Test_1_1_8()
        {
            // Guid type...
            {
                Type val = typeof(Guid);

                // Have the helper get the type...
                var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

                if(valtype != "Guid")
                    Assert.Fail("Wrong value.");
            }

            // Nullable Guid type...
            {
                Type val = typeof(Guid?);

                // Have the helper get the type...
                var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

                if(valtype != "Guid?")
                    Assert.Fail("Wrong value.");
            }

            // Guid instance...
            {
                Guid val = Guid.NewGuid();

                // Have the helper get the type...
                var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

                if(valtype != "Guid")
                    Assert.Fail("Wrong value.");
            }

            // Nullable Guid instance...
            {
                Guid? val = Guid.NewGuid();

                // Have the helper get the type...
                var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

                if(valtype != "Guid")
                    Assert.Fail("Wrong value.");
            }
        }

        //  Test_1_1_9  Verify recovery of type name from a DateTime type as DateTime.
        //              Verify recovery of type name from a nullable DateTime type as DateTime?.
        //              Verify recovery of type name from a DateTime instance as DateTime.
        //              Verify recovery of type name from a nullable DateTime instance as DateTime.
        [TestMethod]
        public void Test_1_1_9()
        {
            // DateTime type...
            {
                Type val = typeof(DateTime);

                // Have the helper get the type...
                var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

                if(valtype != "DateTime")
                    Assert.Fail("Wrong value.");
            }

            // Nullable DateTime type...
            {
                Type val = typeof(DateTime?);

                // Have the helper get the type...
                var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

                if(valtype != "DateTime?")
                    Assert.Fail("Wrong value.");
            }

            // DateTime instance...
            {
                DateTime val = DateTime.UtcNow;

                // Have the helper get the type...
                var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

                if(valtype != "DateTime")
                    Assert.Fail("Wrong value.");
            }

            // Nullable DateTime instance...
            {
                DateTime? val = DateTime.UtcNow;

                // Have the helper get the type...
                var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

                if(valtype != "DateTime")
                    Assert.Fail("Wrong value.");
            }
        }

        //  Test_1_1_10 Verify recovery of type name from a DateTimeOffset type as DateTimeOffset.
        //              Verify recovery of type name from a nullable DateTimeOffset type as DateTimeOffset?.
        //              Verify recovery of type name from a DateTimeOffset instance as DateTimeOffset.
        //              Verify recovery of type name from a nullable DateTimeOffset instance as DateTimeOffset.
        [TestMethod]
        public void Test_1_1_10()
        {
            // DateTimeOffset type...
            {
                Type val = typeof(DateTimeOffset);

                // Have the helper get the type...
                var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

                if(valtype != "DateTimeOffset")
                    Assert.Fail("Wrong value.");
            }

            // Nullable DateTimeOffset type...
            {
                Type val = typeof(DateTimeOffset?);

                // Have the helper get the type...
                var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

                if(valtype != "DateTimeOffset?")
                    Assert.Fail("Wrong value.");
            }

            // DateTimeOffset instance...
            {
                DateTimeOffset val = DateTimeOffset.UtcNow;

                // Have the helper get the type...
                var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

                if(valtype != "DateTimeOffset")
                    Assert.Fail("Wrong value.");
            }

            // Nullable DateTimeOffset instance...
            {
                DateTimeOffset? val = DateTimeOffset.UtcNow;

                // Have the helper get the type...
                var valtype = OGA.SharedKernel.Serialization.Serialization_Helper.GetType_forSerialization(val);

                if(valtype != "DateTimeOffset")
                    Assert.Fail("Wrong value.");
            }
        }


        //  Test_1_2_1  Verify recovery of type name from a generic type...
        [TestMethod]
        public void Test_1_2_1()
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

        //  Test_1_2_2  Verify recovery of type name from a multi-type generic...
        [TestMethod]
        public void Test_1_2_2()
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

        //  Test_1_2_3  Verify recovery of type name from a complex, multi-type generic...
        [TestMethod]
        public void Test_1_2_3()
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
