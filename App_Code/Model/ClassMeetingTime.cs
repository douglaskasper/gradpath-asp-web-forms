using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GradPath.App_Code.Model
{
    public class ClassMeetingTime
    {
        public int ClassId { get; set; }
        public string DayOfWeek { get; set; }
        public TimeOfDay TimeOfDay { get; set; }
    }

    internal class TimeOfDay
    {
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
    }
}