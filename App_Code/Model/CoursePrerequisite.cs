using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GradPath.App_Code.Model
{
    public class CoursePrerequisite
    {
        public int CourseId { get; set; }
        public string CourseDepartment { get; set; }
        public int Id { get; set; }
        public string DepartmentCode { get; set; }
    }
}