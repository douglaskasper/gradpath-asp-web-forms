using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GradPath.App_Code.DAL;
using GradPath.App_Code.Model;

public partial class Controls_CourseList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<Course> courses = new List<Course>();
        courses = CourseDAL.PopulateCourses();

        if (!IsPostBack)
        {
            repeater_courses.DataSource = courses;
            repeater_courses.DataBind();
        }
    }
}