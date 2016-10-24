// A Hello World! program in C#.
using System;
namespace GradPath.App_Code.Model
{
    class Test 
    {
        static void Main() 
        {
            List<Course> courses = new List<Course>();
            courses = DummyDataHelper.CourseRetrieveAll();
            CourseTree testTree = new CourseTree(courses);
            List<Course> testCourseList = new List<Course>();
            testCourseList = testTree.getList();
            foreach (Course course in testCourseList)
                Console.WriteLine(course);
        }
    }
}