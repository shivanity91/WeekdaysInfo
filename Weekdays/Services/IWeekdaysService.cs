using System;
using System.Collections.Generic;
using Weekdays.Models;

namespace Weekdays.Services
{
    public interface IWeekdaysService
    {
        WeekdaysInfo GetWeekDaysAsync(DateTime date);

        List<WeekdaysInfo> SaveWeekDaysAsync(List<DateTime> dates);
    }
}
