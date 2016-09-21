using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GradPath.App_Code.Model
{
    public class DegreeRequirement
    {
        public string DegreeName { get; set; }
        public int CourseId { get; set; }
        public string CourseDepartmentCode { get; set; }
        public string Status { get; set; }
        public string ElectiveDepartmentCode { get; set; }
    }
}