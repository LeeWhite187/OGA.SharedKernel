using Microsoft.VisualStudio.TestTools.UnitTesting;
using OGA.SharedKernel.Extensions.DateandTime;
using System;

namespace DateTimeUtils_Tests
{
    [TestClass]
    public class DateTimeUtils_Tests
    {
        // Test that truncate to seconds works.
        [TestMethod]
        public void Test1()
        {
            DateTime dd = new DateTime(2000, 1, 1);
            dd = dd.AddMilliseconds(10);

            if (dd.Millisecond == 0)
                Assert.Fail("Wrong value.");

            var ee = dd.TruncateToSecond();

            if (ee.Millisecond != 0)
                Assert.Fail("Wrong value.");
        }

        // Test that truncate to milli-seconds works.
        [TestMethod]
        public void Test2()
        {
            DateTime dd = new DateTime(2000, 1, 1);

            if (dd.Millisecond != 0)
                Assert.Fail("Wrong value.");

            // Add enough ticks to get it right up to the next millisecond, to ensure we have a non-zero microsecond value...
            var ee = dd.AddTicks(9999);

            // Now, truncate it back to the nearest millisecond...
            var ff = ee.TruncateToMilliSecond();

            // Check that its ticks are still in the millisecond range...
            var g = ff.Ticks & 10000;
            if (g != 0)
                Assert.Fail("Wrong value.");

            if(ff != dd)
                Assert.Fail("Wrong value.");
        }

        // Test that truncate returns null from a null.
        [TestMethod]
        public void Test3()
        {
            DateTime? dd = null;

            var ee = dd.TruncateToSecond();

            if(ee != null)
                Assert.Fail("Wrong value.");
        }

        // Test that truncate returns null from a null.
        [TestMethod]
        public void Test4()
        {
            DateTime? dd = null;

            var ee = dd.TruncateToMilliSecond();

            if(ee != null)
                Assert.Fail("Wrong value.");
        }
    }
}
