using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Weekdays.Models;

namespace Weekdays.Services
{
    public class WeekdaysService : IWeekdaysService
    {
        public WeekdaysInfo GetWeekDaysAsync(DateTime date)
        {
            var result = new WeekdaysInfo();
            result.Weekdays = new List<Weekday>();
            var d = date.Year != 1 ? date : DateTime.Now;
            for (int i = 0; i < 7; i++)
            {
                var day = d.AddDays(i);
                var dayInfo = new Weekday()
                {
                    Day = i + "." + " " + day.DayOfWeek,
                    IsUrlParameter = date.Year == 1 ? false : true,
                    Date = day
                };
                result.Weekdays.Add(dayInfo);
            }
            return result;
        }

        public List<WeekdaysInfo> SaveWeekDaysAsync(List<DateTime> dates)
        {
            var result = new List<WeekdaysInfo>();
            foreach (var date in dates)
            {
                var dateInfo = new WeekdaysInfo();
                dateInfo.Weekdays = new List<Weekday>();
                for (int i = 0; i < 7; i++)
                {
                    var day = date.AddDays(i);
                    var dayInfo = new Weekday()
                    {
                        Day = i + "." + " " + day.DayOfWeek,
                        IsUrlParameter = true,
                        Date = day
                    };
                    dateInfo.Weekdays.Add(dayInfo);
                }
                result.Add(dateInfo);
            }
            return result;
        }
    }
}
