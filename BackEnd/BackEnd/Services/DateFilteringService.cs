using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using BackEnd.Models;

namespace BackEnd.Services
{
    public class DateFilteringService
    {
        public static IEnumerable<CursusInstantie> FilterOnWeek(IEnumerable<CursusInstantie> cursuses, int yearWeek)
        {
            var year = int.Parse(yearWeek.ToString().Substring(0, 4));
            var weekNumber = int.Parse(yearWeek.ToString().Substring(4));

            var firstAndLastDateOfWeek = FirstAndLastDateOfWeek(year, weekNumber);
            var firstDay = firstAndLastDateOfWeek[0];
            var lastDay = firstAndLastDateOfWeek[1];

            var cursussesForWeek = new List<CursusInstantie>();
            foreach (var item in cursuses.ToList())
            {
                if (item.StartDatum >= firstDay && item.StartDatum <= lastDay)
                {
                    cursussesForWeek.Add(item);
                }
            }

            //cursussesForWeek.AddRange(cursuses.ToList().Where(x => x.StartDatum >= firstDay && x.StartDatum <= lastDay));

            return cursussesForWeek;
        }

        private static List<DateTime> FirstAndLastDateOfWeek(int year, int weekOfYear)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            // Use first Thursday in January to get first week of the year as
            // it will never be in Week 52/53
            DateTime firstThursday = jan1.AddDays(daysOffset);
            var cal = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var weekNum = weekOfYear;
            // As we're adding days to a date in Week 1,
            // we need to subtract 1 in order to get the right date for week #1
            if (firstWeek == 1)
            {
                weekNum -= 1;
            }

            // Using the first Thursday as starting week ensures that we are starting in the right year
            // then we add number of weeks multiplied with days
            var result = firstThursday.AddDays(weekNum * 7);

            // Subtract 3 days from Thursday to get Monday, which is the first weekday
            var firstDay = result.AddDays(-3);

            // Subtract 3 days from Thursday to get sunday, which is the last weekday
            var lastDay = result.AddDays(3);

            return new List<DateTime> { firstDay, lastDay };
        }

    }
}