using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Core.Entity.Enums
{
    public static class DateNames
    {
        public static Dictionary<DayOfWeek, string> DayOfWeekNames =new Dictionary<DayOfWeek, string>()
        {
            { DayOfWeek.Monday,"Pazartesi" },
            { DayOfWeek.Tuesday,"Salı" },
            { DayOfWeek.Wednesday,"Çarşamba" },
            { DayOfWeek.Thursday,"Perşembe" },
            { DayOfWeek.Friday,"Cuma" },
            { DayOfWeek.Saturday,"Cumartesi" },
            { DayOfWeek.Sunday,"Pazar" },
        };
    }
}
