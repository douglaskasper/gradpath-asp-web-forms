﻿using System.Collections.Generic;
using System;

namespace GradPath.App_Code.Model
{
    public class Course : IComparable<Course>
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public Department Department { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Units { get; set; }
        public string Status { get; set; }
        public List<Course> Prereqs { get; set; }
        public List<Course> PrereqOf { get; set; }

        //make sortable using course ID
        public int CompareTo(object obj)
        {
            if (Id < obj.Id)
                return -1;
            else if (Id > obj.Id)
                return 1;
            else
                return 0;
        }
    }
}
