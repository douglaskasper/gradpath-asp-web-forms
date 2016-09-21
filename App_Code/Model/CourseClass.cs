using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GradPath.App_Code.Model
{
    public class CourseClass
    {
        public int Id { get; set; }
        public string SectionNumber { get; set; }
        public int CourseId { get; set; }
        public string CourseDepartmentCode { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Status { get; set; }
        public string BuildingName { get; set; }
        public int ClassroomNumber { get; set; }
        public string ClassroomSection { get; set; }
        public int InstructorAccountId { get; set; }
    }
}