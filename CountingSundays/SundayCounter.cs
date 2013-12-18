using System.Collections.Generic;
using System.Linq;

namespace CountingSundays
{
    public class SundayCounter
    {
        private readonly int[] _nonLeapYear = new[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        private readonly int[] _leapYear = new[] { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        public bool IsSundayFirstOfMonth(int year, int month)
        {
            return GetSundaysAsFirstDayOfMonth(year, year).Contains(YearMonth(year,month));
        }

        public int GetMonthsWithFirstAsSunday(int startYear, int endYear)
        {
            return GetSundaysAsFirstDayOfMonth(startYear, endYear).Length;
        }

        private int[] GetSundaysAsFirstDayOfMonth(int startYear, int endYear)
        {
            const int yearIndex = 1900;
            int dayIndex = 0;
            var firstDayOfMonth = new List<int>();

            for (int currentYear = yearIndex; currentYear < startYear; currentYear++)
                dayIndex += AddYear(currentYear);

            for (int currentYear = startYear; currentYear <= endYear; currentYear++)
                for (int month = 1; month <= 12; month++)
                {
                    if (IsSunday(dayIndex))
                        firstDayOfMonth.Add(YearMonth(currentYear,month));
                    dayIndex += AddMonth(currentYear, month);
                }

            return firstDayOfMonth.ToArray();
        }

        private static int YearMonth(int currentYear, int month)
        {
            return currentYear * 100 + month;
        }

        private int AddYear(int year)
        {
            return IsLeapYear(year) ? _leapYear.Sum() : _nonLeapYear.Sum();
        }

        private int AddMonth(int year, int month)
        {
            return IsLeapYear(year) ? _leapYear[month - 1] : _nonLeapYear[month - 1];
        }

        private static bool IsLeapYear(int year)
        {
            return year%4 == 0 && year%400 != 0;
        }

        private static bool IsSunday(int day)
        {
            return day%7 == 0;
        }
    }
}
