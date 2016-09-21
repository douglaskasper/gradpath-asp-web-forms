using System.Collections.Generic;
using GradPath.App_Code.Model.Support;

namespace GradPath.App_Code.Model
{
    public class CourseClass
    {
        public int Id { get; set; }
        public string SectionNumber { get; set; }
        public Course Course { get; set; }
        public DateTimeSpan Dates { get; set; }
        public List<ClassMeetingTime> MeetingTimes { get; set; }
        public string Status { get; set; }
        public Classroom Classroom { get; set; }
        public Account Instructor { get; set; }
        public List<Course> Prerequisites { get; set; }
    }
}