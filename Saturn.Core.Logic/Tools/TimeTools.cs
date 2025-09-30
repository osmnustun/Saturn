using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Core.Logic.Tools
{
    public static class TimeTools
    {
        public static List<DateTime> GetDatesBetween(DateTime start, DateTime end,List<DayOfWeek> days)
        {
            List<DateTime> dateList = new List<DateTime>();

            for (DateTime date = start; date <= end; date = date.AddDays(1))
            {
                if (!days.Contains(date.DayOfWeek))
                    dateList.Add(date);
                
            }

            return dateList;
        }

        public static List<DateTime> GetDatesBetween(DateTime start, DateTime end, DayOfWeek dayOfWeek)
        {
            List<DateTime> dateList = new List<DateTime>();

            for (DateTime date = start; date <= end; date = date.AddDays(1))
            {
               if (date.DayOfWeek == dayOfWeek)
                    dateList.Add(date);

            }

            return dateList;
        }


        public static List<string> GetDatesBetweenTr(DateTime start, DateTime end)
        {
            CultureInfo culture = new CultureInfo("tr-TR"); // Türkçe format
            List<string> dateList = new List<string>();

            for (DateTime date = start; date <= end; date = date.AddDays(1))
            {
                dateList.Add(date.ToString("d MMMM yyyy dddd", culture));
            }

            return dateList;
        }

        
    }
}
