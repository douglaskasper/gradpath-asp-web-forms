using System;
using System.Collections.Generic;

using GradPath.App_Code.DAL;
using GradPath.App_Code.Model;

public partial class Controls_CourseList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<Course> courses = new List<Course>();
        courses = DummyDataHelper.CourseRetrieveAll();
        
        /**
        foreach (Course course in courses)
        {
            int id = course.Id;
            string departmentCode = course.Department.Code;
            int peopleSoftNumber = course.PeopleSoftNumber;
            string title = course.Title;
            string description = course.Description;
            decimal units = course.Units;
        }
        */

        if (!IsPostBack)
        {
            repeater_courses.DataSource = courses;
            repeater_courses.DataBind();
        }
    }
}