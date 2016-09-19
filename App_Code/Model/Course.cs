using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for course
/// </summary>
namespace GradPath.App_Code.Model
{
    public class Course
    {
        public int id { get; set; }
        public string department { get; set; }
        public int people_soft_number { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public decimal units { get; set; }
    }
}