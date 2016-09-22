using System;
using System.Collections.Generic;

using GradPath.App_Code.Model;
using GradPath.App_Code.Model.Support;

namespace GradPath.App_Code.DAL
{
    public abstract class DummyDataHelper
    {

        public static List<Account> AccountCreate(
            string username,
            string password,
            string firstName,
            string lastName,
            string role
            )
        {
            List<Account> accounts = new List<Account>();
            Account account = new Account();

            account.Id = 9001;
            account.Username = username;
            account.Password = password;
            account.Name = new Name {
                FirstName = firstName,
                LastName = lastName
            };
            account.Role = role;

            accounts.Add(account);

            return accounts;
        }

        public static List<Account> AccountLogin(
            string username,
            string password
            )
        {
            List<Account> accounts = new List<Account>();

            Account account = new Account();

            account.Id = 9001;
            account.Username = username;
            account.Password = password;
            account.Name = new Name
            {
                FirstName = "John",
                LastName = "Smith"
            };
            account.Role = "STUDENT";

            accounts.Add(account);

            return accounts;
        }

        public static List<Account> AccountRetrieve(
            int id,
            string username,
            string firstName,
            string lastName,
            string role
            )
        {
            List<Account> accounts = new List<Account>();

            Account account = new Account();

            account.Id = id;
            account.Username = username;
            account.Name = new Name
            {
                FirstName = firstName,
                LastName = lastName
            };
            account.Role = role;

            accounts.Add(account);

            return accounts;
        }

        public static List<Account> AccountRetrieveAll()
        {
            List<Account> accounts = new List<Account>();

            Account account = new Account();

            account.Id = 9001;
            account.Username = "johnsmith@email.com";
            account.Name = new Name
            {
                FirstName = "John",
                LastName = "Smith"
            };
            account.Role = "STUDENT";

            accounts.Add(account);

            return accounts;
        }

        public static List<GraduationPathSearch> GraduationPathSearchSave(
            int accountId,
            string option,
            string value
            )
        {
            List<GraduationPathSearch> searches = new List<GraduationPathSearch>();

            GraduationPathSearch search = new GraduationPathSearch();

            search.Id = 42;
            search.Account = new Account { Id = accountId };
            search.Options = new List<SearchOption>();
            search.Options.Add(new SearchOption
            {
                Option = option,
                Value = value
            });
            searches.Add(search);

            return searches;
        }

        public static List<GraduationPathSearch> GraduationPathSearchRetrieve(
            int pathId,
            int accountId
            )
        {
            List<GraduationPathSearch> searches = new List<GraduationPathSearch>();

            GraduationPathSearch search = new GraduationPathSearch();

            search.Id = 42;
            search.Account = new Account { Id = accountId };
            search.Options = new List<SearchOption>();
            search.Options.Add(new SearchOption
            {
                Option = "CLASSES_PER_QUARTER",
                Value = "2"
            });
            searches.Add(search);

            return searches;
        }

        public static List<GraduationPathSearch> GraduationPathSearchRetrieveAll()
        {
            List<GraduationPathSearch> searches = new List<GraduationPathSearch>();

            GraduationPathSearch search = new GraduationPathSearch();

            search.Id = 42;
            search.Account = new Account { Id = 9001 };
            search.Options = new List<SearchOption>();
            search.Options.Add(new SearchOption
            {
                Option = "CLASSES_PER_QUARTER",
                Value = "2"
            });
            searches.Add(search);

            return searches;
        }

        public static List<Degree> DegreeRetrieve(
            string degreeName,
            string college
            )
        {
            List<Degree> degrees = new List<Degree>();
            
            Degree degree = new Degree();

            degree.Name = degreeName;
            degree.Title = "Degree Title";
            degree.College = college;
            degree.Concentration = "Degree Concentration";
            degree.Description = "Degree Description";

            degrees.Add(degree);

            return degrees;
        }

        public static List<Degree> DegreeRetrieveAll()
        {
            List<Degree> degrees = new List<Degree>();

            Degree degree = new Degree();

            degree.Name = "Degree Name";
            degree.Title = "Degree Title";
            degree.College = "Degree College";
            degree.Concentration = "Degree Concentration";
            degree.Description = "Degree Description";

            degrees.Add(degree);

            return degrees;
        }

        public static List<Course> CourseRetrieve(
            int courseId,
            int courseNumber,
            string departmentCode,
            string title,
            string description,
            decimal units,
            string status,
            int isPrerequisiteOfCourseId,
            string isRequirementOfDegreeName
            )
        {
            List<Course> courses = new List<Course>();

            Course course = new Course();

            course.Id = courseId;
            course.Number = courseNumber;
            course.Department = new Department { Code = departmentCode };
            course.PeopleSoftNumber = 12121212;
            course.Title = title;
            course.Description = description;
            course.Units = units;
            course.Status = status;

            courses.Add(course);

            return courses;
        }

        public static List<Course> CourseRetrieveAll()
        {
            List<Course> courses = new List<Course>();

            Course course = new Course();

            course.Id = 83334;
            course.Number = 394;
            course.Department = new Department { Code = "CSC" };
            course.PeopleSoftNumber = 12121212;
            course.Title = "Capstone: Software Project";
            course.Description = "Design and build a software project";
            course.Units = Convert.ToDecimal(4.00);
            course.Status = "ACTIVE";

            courses.Add(course);

            return courses;
        }

        public static List<CourseClass> ClassRetrieve(
            int classId,
            string sectionNumber,
            int courseId,
            int courseNumber,
            string departmentCode,
            string status,
            int hasHistoryInAccountId
            )
        {
            List<CourseClass> courseClasses = new List<CourseClass>();

            CourseClass courseClass = new CourseClass();

            courseClass.Id = classId;
            courseClass.SectionNumber = sectionNumber;
            courseClass.Course = new Course
            {
                Id = courseId,
                Number = courseNumber,
                Department = new Department { Code = departmentCode }
            };
            courseClass.Dates = new DateTimeSpan
            {
                Begin = Convert.ToDateTime("09/01/2017"),
                End = Convert.ToDateTime("11/15/2017")
            };
            courseClass.Status = status;
            courseClass.Classroom = new Classroom
            {
                Id = 2001,
                Number = 103,
                Section = "C",
                Building = new Building
                {
                    Name = "DePaul Center",
                    Campus = new Campus { Name = "Loop" }
                }
            };
            courseClass.Instructor = new Account { Id = 9501 };

            courseClasses.Add(courseClass);

            return courseClasses;
        }

        public static List<CourseClass> ClassRetrieveAll()
        {
            List<CourseClass> courseClasses = new List<CourseClass>();

            CourseClass courseClass = new CourseClass();

            courseClass.Id = 9288556;
            courseClass.SectionNumber = "7000001";
            courseClass.Course = new Course
            {
                Id = 83334,
                Number = 394,
                Department = new Department { Code = "CSC" }
            };
            courseClass.Dates = new DateTimeSpan
            {
                Begin = Convert.ToDateTime("09/01/2017"),
                End = Convert.ToDateTime("11/15/2017")
            };
            courseClass.Status = "OPEN";
            courseClass.Classroom = new Classroom
            {
                Id = 2001,
                Number = 103,
                Section = "C",
                Building = new Building
                {
                    Name = "DePaul Center",
                    Campus = new Campus { Name = "Loop" }
                }
            };
            courseClass.Instructor = new Account { Id = 9501 };

            courseClasses.Add(courseClass);

            return courseClasses;
        }

    }
}