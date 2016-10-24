using System.Collections.Generic;


/// <summary>
/// Simple data structure for storing classes with prereqs
/// </summary>
namespace GradPath.App_Code.Model
{
    public class CourseTree
    {
        public int Count;
        public CourseTreeNode Root;
        public CourseTreeNode Current;
        //Maintain index of courses by ID, removes need to search tree directly.
        public List<int> Courses = new List<int>();
        private List<Course> ListResult = new List<Course>();
        public CourseTree(List<Course> requiredCourses)
        {
            Count = 0;
            Root = null;
            List<Course> SortedCourses = requiredCourses.Sort();
            //Create a dummy course to serve as the root
            Course dummy = new Course();
            dummy.Id = 00000;
            dummy.Number = 000;
            dummy.Department = new Department { Code = "NUL" };
            dummy.PeopleSoftNumber = 00000000;
            dummy.Title = "Root";
            dummy.Description = "Root course";
            dummy.Units = Convert.ToDecimal(0);
            dummy.Status = "ACTIVE";
            Root = new CourseTreeNode(this, dummy);
            //add each course to the 'tree'
            while (SortedCourses.Count > 0)
            {
                foreach (Course Course in SortedCourses)
                {
                    if (Course.Prereqs.Count == 0 || ContainsAllCourses(Course.Prereqs)) {
                        AddNode(new CourseTreeNode(this, Course));
                        Count += 1;
                        Courses.Add(Course.Id);
                        SortedCourses.Remove(Course);
                    }
                }
            }
        }
        public bool ContainsCourse(Course Course)
        {
            if (Courses.Contains(Course.Id))
                return true;
            return false;
        }
        public bool ContainsAllCourses(List<Course> Courses)
        {
            bool res = true;
            foreach (Course C in Courses)
            {
                if (!ContainsCourse(C))
                    res = false;
            }
            return res;
        }
        //Returns the node for a particular course
        public CourseTreeNode GetNode(CourseTreeNode curr, int CourseID)
        {
            if (curr.Course.Id == CourseID)
                return curr;
            else
            {
                foreach (CourseTreeNode Node in curr.Children)
                    GetNode(Node, CourseID);
            }
        }
        //add a node to the tree
        public void AddNode(CourseTreeNode Node)
        {
            //Connect to parents
            if (Node.Course.Prereqs.Length == 0) {
                Node.Parents.Add(Root);
                Root.Children.Add(Node);
            }
            else
                foreach (Course Pre in Node.Course.Prereqs)
                {
                    CourseTreeNode Temp = GetNode(Root, Pre);
                    Node.Parents.Add(Temp);
                    Temp.Children.Add(Node);
                }
        }
        public List<Course> GetList()
        {
            foreach (CourseTreeNode Node in Root.Children)
            {
                GetListHelper(Node);
            }
            return this.ListResult;
        }
        private void GetListHelper(CourseTreeNode Node)
        {
            foreach (CourseTreeNode Child in Node.Children)
            {
                GetListHelper(Child);
            }
            ListResult.Add(Node.Course);

        }
    }
}
