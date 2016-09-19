using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

using GradPath.App_Code.Model;

/// <summary>
/// Summary description for Course
/// </summary>
namespace GradPath.App_Code.DAL
{
    public abstract class CourseDAL
    {
        /**
            CREATE TABLE `course` (
	            `id` INTEGER NOT NULL,
	            `department` TEXT NOT NULL,
	            `people_soft_number` INTEGER,
	            `title` TEXT,
	            `description` TEXT,
	            `units` NUMERIC,
	            PRIMARY KEY(`id`,`department`)
            );
        */
        public static List<Course> PopulateCourses()
        {
            string commandText = @" SELECT  c.id,
                                            c.department,
                                            c.people_soft_number,
                                            c.title,
                                            c.description,
                                            c.units
                                    FROM course c";

            DataTable dataTable = new DataTable();
            dataTable = SQLiteHelper.Retrieve(commandText);

            List<Course> courses = new List<Course>();

            var query = dataTable.AsEnumerable().
                Select(course => new
                {
                    id = (int)course.Field<Int64>("id"),
                    department = course.Field<string>("department"),
                    people_soft_number = (int)course.Field<Int64>("people_soft_number"),
                    title = course.Field<string>("title"),
                    description = course.Field<string>("description"),
                    units = course.Field<Decimal>("units"),
                });

            foreach (var courseInfo in query)
            {
                Course course = new Course();
                course.id = courseInfo.id;
                course.department = courseInfo.department;
                course.people_soft_number = courseInfo.people_soft_number;
                course.title = courseInfo.title;
                course.description = courseInfo.description;
                course.units = courseInfo.units;

                courses.Add(course);
            }

            return courses;
        }

    }
}