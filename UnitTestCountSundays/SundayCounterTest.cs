using CountingSundays;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCountSundays
{
    [TestClass]
    public class SundayCounterTest
    {
        [TestMethod]
        public void TestMethod_190101_FindFirstIsNotSunday()
        {
            TestIsNotFirstOfMonthSunday(1901, 1);
        }
        
        [TestMethod]
        public void TestMethod_190109_FindFirstIsSunday()
        {
            TestIsFirstOfMonthSunday(1901, 9);
        }
        
        [TestMethod]
        public void TestMethod_190112_FindFirstIsSunday()
        {
            TestIsFirstOfMonthSunday(1901, 12);
        }
        
        [TestMethod]
        public void TestMethod_190206_FindFirstIsSunday()
        {
            TestIsFirstOfMonthSunday(1902, 6);
        }

        [TestMethod]
        public void TestMethod_190302_FindFirstIsSunday()
        {
            TestIsFirstOfMonthSunday(1903, 2);
        }
        
        [TestMethod]
        public void TestMethod_190303_FindFirstIsSunday()
        {
            TestIsFirstOfMonthSunday(1903, 3);
        }
        
        [TestMethod]
        public void TestMethod_190311_FindFirstIsSunday()
        {
            TestIsFirstOfMonthSunday(1903, 11);
        }

        [TestMethod]
        public void TestMethod_190405_FindFirstIsSunday()
        {
            TestIsFirstOfMonthSunday(1904, 5);
        }

        [TestMethod]
        public void TestMethod_190501_FindFirstIsSunday()
        {
            TestIsFirstOfMonthSunday(1905, 1);
        }

        [TestMethod]
        public void TestMethod_1901_To_1905_NumberOfFirstIsSunday()
        {
            TestListOfSundays_Count(1901, 1905, 9);
        }

        [TestMethod]
        public void TestMethod_1901_To_2000_NumberOfFirstIsSunday()
        {
            TestListOfSundays_Count(1901, 2000, 171);
        }

        private static void TestListOfSundays_Count(int startYear, int endYear, int expectedCount)
        {
            var sundays = new SundayCounter();
            Assert.AreEqual(expectedCount, sundays.GetMonthsWithFirstAsSunday(startYear,endYear));
        }

        private static void TestIsFirstOfMonthSunday(int year, int month)
        {
            var sundays = new SundayCounter();
            Assert.IsTrue(sundays.IsSundayFirstOfMonth(year, month));
        }

        private static void TestIsNotFirstOfMonthSunday(int year, int month)
        {
            var sundays = new SundayCounter();
            Assert.IsFalse(sundays.IsSundayFirstOfMonth(year, month));
        }
    }
}
