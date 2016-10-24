using System.Collections.Generic;

/// <summary>
/// Node for use in course trees. Contains a course and links to parent and child nodes
/// </summary>
namespace GradPath.App_Code.Model
{
    public class CourseTreeNode
    {
        private CourseTree Tree;
        public Course Course;
        public List<CourseTreeNode> Parents;
        public List<CourseTreeNode> Children;

        public CourseTreeNode(CourseTree Tree, Course Course)
        {
            this.Course = Course;
            this.Tree = Tree;
        }
        //Add a prerequisite course to the list of parents
        public void AddPrereq(CourseTreeNode Prereq) {
            Parents.Add(Prereq);
        }
        //Add a course for which this is a prerequisite to the children list
        public void AddRequiredFor(CourseTreeNode Course)
        {
            Children.Add(Course);
        }
    }
}