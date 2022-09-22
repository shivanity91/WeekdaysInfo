using System;
using System.Collections.Generic;

namespace Weekdays.Models
{
    public class WeekdaysInfo
    {
        public List<Weekday> Weekdays { get; set; }
    }

    public class Weekday
    {
        public string Day { get; set; }
        public bool IsUrlParameter { get; set; }
        public DateTime Date { get; set; }
    }
}
