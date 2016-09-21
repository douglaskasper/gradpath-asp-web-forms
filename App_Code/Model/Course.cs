using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace GradPath.App_Code.Model
{
    public class Course
    {
        public int Id { get; set; }
        public string DepartmentCode { get; set; }
        public int PeopleSoftNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Units { get; set; }
        public string Status { get; set; }
    }
}