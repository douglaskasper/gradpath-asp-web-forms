using System;
using System.Collections.Generic;
using System.Data;

using MySql.Data.MySqlClient;

using GradPath.App_Code.Model;
using GradPath.App_Code.Model.Support;

namespace GradPath.App_Code.DAL
{
    public abstract class MySqlHelper
    {

        private static MySqlConnection MySqlConnection()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection();
                connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySQLDatabase"].ConnectionString;
                connection.Open();

                return connection;
            }
            catch (MySqlException ex)
            {
                string errorMessage = ex.Message;
                return null;
            }
        }

        public static List<Account> AccountCreate(
            string username,
            string password,
            string firstName,
            string lastName,
            string role
            )
        {
            using (MySqlConnection connection = MySqlConnection())
            {
                using (MySqlCommand command = new MySqlCommand("account_create", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@in_username", username);
                    command.Parameters["@in_username"].Direction = ParameterDirection.Input;
                    command.Parameters.AddWithValue("@in_password", password);
                    command.Parameters["@in_password"].Direction = ParameterDirection.Input;
                    command.Parameters.AddWithValue("@in_first_name", firstName);
                    command.Parameters["@in_first_name"].Direction = ParameterDirection.Input;
                    command.Parameters.AddWithValue("@in_last_name", lastName);
                    command.Parameters["@in_last_name"].Direction = ParameterDirection.Input;
                    command.Parameters.AddWithValue("@in_role", role);
                    command.Parameters["@in_role"].Direction = ParameterDirection.Input;
                    
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        connection.Close();

                        List<Account> accounts = new List<Account>();

                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            Account account = new Account();

                            account.Id = Convert.ToInt32(dataRow["acc_id"]);
                            account.Username = Convert.ToString(dataRow["acc_username"]);
                            account.Password = Convert.ToString(dataRow["acc_password"]);
                            account.Name = new Name {
                                FirstName = Convert.ToString(dataRow["acc_first_name"]),
                                LastName = Convert.ToString(dataRow["acc_last_name"])
                            };
                            account.Role = Convert.ToString(dataRow["acc_role"]);

                            accounts.Add(account);
                        }
                        
                        return accounts;
                    }
                }
            }
        }

        public static List<Account> AccountLogin(
            string username,
            string password
            )
        {
            using (MySqlConnection connection = MySqlConnection())
            {
                using (MySqlCommand command = new MySqlCommand("account_login", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@in_username", username);
                    command.Parameters["@in_username"].Direction = ParameterDirection.Input;
                    command.Parameters.AddWithValue("@in_password", password);
                    command.Parameters["@in_password"].Direction = ParameterDirection.Input;

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        connection.Close();

                        List<Account> accounts = new List<Account>();

                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            Account account = new Account();

                            account.Id = Convert.ToInt32(dataRow["acc_id"]);
                            account.Username = Convert.ToString(dataRow["acc_username"]);
                            account.Password = Convert.ToString(dataRow["acc_password"]);
                            account.Name = new Name {
                                FirstName = Convert.ToString(dataRow["acc_first_name"]),
                                LastName = Convert.ToString(dataRow["acc_last_name"])
                            };
                            account.Role = Convert.ToString(dataRow["acc_role"]);

                            accounts.Add(account);
                        }

                        return accounts;
                    }
                }
            }
        }

        public static List<Account> AccountRetrieve(
            int id,
            string username,
            string firstName,
            string lastName,
            string role
            )
        {
            using (MySqlConnection connection = MySqlConnection())
            {
                using (MySqlCommand command = new MySqlCommand("account_retrieve", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@in_username", username);
                    command.Parameters["@in_username"].Direction = ParameterDirection.Input;
                    command.Parameters.AddWithValue("@in_first_name", firstName);
                    command.Parameters["@in_first_name"].Direction = ParameterDirection.Input;
                    command.Parameters.AddWithValue("@in_last_name", lastName);
                    command.Parameters["@in_last_name"].Direction = ParameterDirection.Input;
                    command.Parameters.AddWithValue("@in_role", role);
                    command.Parameters["@in_role"].Direction = ParameterDirection.Input;

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        connection.Close();

                        List<Account> accounts = new List<Account>();

                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            Account account = new Account();

                            account.Id = Convert.ToInt32(dataRow["acc_id"]);
                            account.Username = Convert.ToString(dataRow["acc_username"]);
                            account.Password = Convert.ToString(dataRow["acc_password"]);
                            account.Name = new Name {
                                FirstName = Convert.ToString(dataRow["acc_first_name"]),
                                LastName = Convert.ToString(dataRow["acc_last_name"])
                            };
                            account.Role = Convert.ToString(dataRow["acc_role"]);

                            accounts.Add(account);
                        }

                        return accounts;
                    }
                }
            }
        }

        public static List<GraduationPathSearch> GraduationPathSearchSave(
            int accountId,
            string option,
            string value
            )
        {
            using (MySqlConnection connection = MySqlConnection())
            {
                using (MySqlCommand command = new MySqlCommand("graduation_path_search_save", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@in_account_id", accountId);
                    command.Parameters["@in_account_id"].Direction = ParameterDirection.Input;
                    command.Parameters.AddWithValue("@in_option", option);
                    command.Parameters["@in_option"].Direction = ParameterDirection.Input;
                    command.Parameters.AddWithValue("@in_value", value);
                    command.Parameters["@in_value"].Direction = ParameterDirection.Input;

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        connection.Close();

                        List<GraduationPathSearch> searches = new List<GraduationPathSearch>();

                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            GraduationPathSearch search;
                            int id = Convert.ToInt32(dataRow["gra_id"]);

                            if (searches != null)
                                search = searches.Find(item => item.Id == id);
                            else
                                search = new GraduationPathSearch();

                            if (search.Id > 0) {
                                search.Options.Add(new SearchOption {
                                    Option = Convert.ToString(dataRow["gra_option"]),
                                    Value = Convert.ToString(dataRow["gra_value"])
                                });
                                searches.Add(search);
                            }
                            else
                            {
                                search.Id = Convert.ToInt32(dataRow["gra_id"]);
                                search.Account = new Account { Id = Convert.ToInt32(dataRow["gra_account_id"]) };
                                search.Options = new List<SearchOption>();
                                search.Options.Add(new SearchOption {
                                    Option = Convert.ToString(dataRow["gra_option"]),
                                    Value = Convert.ToString(dataRow["gra_value"])
                                });
                                searches.Add(search);
                            }
                        }

                        return searches;
                    }
                }
            }
        }

        public static List<GraduationPathSearch> GraduationPathSearchRetrieve(
            int pathId,
            int accountId
            )
        {
            using (MySqlConnection connection = MySqlConnection())
            {
                using (MySqlCommand command = new MySqlCommand("graduation_path_search_retrieve", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@in_path_id", pathId);
                    command.Parameters["@in_path_id"].Direction = ParameterDirection.Input;
                    command.Parameters.AddWithValue("@in_account_id", accountId);
                    command.Parameters["@in_account_id"].Direction = ParameterDirection.Input;

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        connection.Close();

                        List<GraduationPathSearch> searches = new List<GraduationPathSearch>();

                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            GraduationPathSearch search;
                            int id = Convert.ToInt32(dataRow["gra_id"]);

                            if (searches != null)
                                search = searches.Find(item => item.Id == id);
                            else
                                search = new GraduationPathSearch();

                            if (search.Id > 0)
                            {
                                search.Options.Add(new SearchOption {
                                    Option = Convert.ToString(dataRow["gra_option"]),
                                    Value = Convert.ToString(dataRow["gra_value"])
                                });
                                searches.Add(search);
                            }
                            else
                            {
                                search.Id = Convert.ToInt32(dataRow["gra_id"]);
                                search.Account = new Account { Id = Convert.ToInt32(dataRow["gra_account_id"]) };
                                search.Options = new List<SearchOption>();
                                search.Options.Add(new SearchOption {
                                    Option = Convert.ToString(dataRow["gra_option"]),
                                    Value = Convert.ToString(dataRow["gra_value"])
                                });
                                searches.Add(search);
                            }
                        }

                        return searches;
                    }
                }
            }
        }

        public static List<Degree> DegreeRetrieve(
            string degreeName,
            string college
            )
        {
            using (MySqlConnection connection = MySqlConnection())
            {
                using (MySqlCommand command = new MySqlCommand("degree_retrieve", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@in_degree_name", degreeName);
                    command.Parameters["@in_degree_name"].Direction = ParameterDirection.Input;
                    command.Parameters.AddWithValue("@in_college", college);
                    command.Parameters["@in_college"].Direction = ParameterDirection.Input;

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        connection.Close();

                        List<Degree> degrees = new List<Degree>();

                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            Degree degree = new Degree();

                            degree.Name = Convert.ToString(dataRow["deg_name"]);
                            degree.Title = Convert.ToString(dataRow["deg_title"]);
                            degree.College = Convert.ToString(dataRow["deg_college"]);
                            degree.Concentration = Convert.ToString(dataRow["deg_concentration"]);
                            degree.Description = Convert.ToString(dataRow["deg_description"]);

                            degrees.Add(degree);
                        }

                        return degrees;
                    }
                }
            }
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
            using (MySqlConnection connection = MySqlConnection())
            {
                using (MySqlCommand command = new MySqlCommand("course_retrieve", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@in_course_id", courseId);
                    command.Parameters["@in_course_id"].Direction = ParameterDirection.Input;
                    command.Parameters.AddWithValue("@in_course_number", courseNumber);
                    command.Parameters["@in_course_number"].Direction = ParameterDirection.Input;
                    command.Parameters.AddWithValue("@in_department_code", departmentCode);
                    command.Parameters["@in_department_code"].Direction = ParameterDirection.Input;
                    command.Parameters.AddWithValue("@in_title", title);
                    command.Parameters["@in_title"].Direction = ParameterDirection.Input;
                    command.Parameters.AddWithValue("@in_description", description);
                    command.Parameters["@in_description"].Direction = ParameterDirection.Input;
                    command.Parameters.AddWithValue("@in_units", units);
                    command.Parameters["@in_units"].Direction = ParameterDirection.Input;
                    command.Parameters.AddWithValue("@in_status", status);
                    command.Parameters["@in_status"].Direction = ParameterDirection.Input;
                    command.Parameters.AddWithValue("@in_prerequisite_of_course_id", isPrerequisiteOfCourseId);
                    command.Parameters["@in_prerequisite_of_course_id"].Direction = ParameterDirection.Input;
                    command.Parameters.AddWithValue("@in_requirement_of_degree_name", isRequirementOfDegreeName);
                    command.Parameters["@in_requirement_of_degree_name"].Direction = ParameterDirection.Input;

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        connection.Close();

                        List<Course> courses = new List<Course>();

                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            Course course = new Course();

                            course.Id = Convert.ToInt32(dataRow["cou_id"]);
                            course.Number = Convert.ToInt32(dataRow["cou_number"]);
                            course.Department = new Department { Code = Convert.ToString(dataRow["cou_department_code"]) };
                            course.Title = Convert.ToString(dataRow["cou_title"]);
                            course.Description = Convert.ToString(dataRow["cou_description"]);
                            course.Units = Convert.ToDecimal(dataRow["cou_units"]);
                            course.Status = Convert.ToString(dataRow["cou_status"]);

                            courses.Add(course);
                        }

                        return courses;
                    }
                }
            }
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
            using (MySqlConnection connection = MySqlConnection())
            {
                using (MySqlCommand command = new MySqlCommand("class_retrieve", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@in_class_id", classId);
                    command.Parameters["@in_class_id"].Direction = ParameterDirection.Input;
                    command.Parameters.AddWithValue("@in_section_number", sectionNumber);
                    command.Parameters["@in_section_number"].Direction = ParameterDirection.Input;
                    command.Parameters.AddWithValue("@in_course_id", courseId);
                    command.Parameters["@in_course_id"].Direction = ParameterDirection.Input;
                    command.Parameters.AddWithValue("@in_course_number", courseNumber);
                    command.Parameters["@in_course_number"].Direction = ParameterDirection.Input;
                    command.Parameters.AddWithValue("@in_department_code", departmentCode);
                    command.Parameters["@in_department_code"].Direction = ParameterDirection.Input;
                    command.Parameters.AddWithValue("@in_status", status);
                    command.Parameters["@in_status"].Direction = ParameterDirection.Input;
                    command.Parameters.AddWithValue("@in_history_in_account_id", hasHistoryInAccountId);
                    command.Parameters["@in_history_in_account_id"].Direction = ParameterDirection.Input;

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        connection.Close();

                        List<CourseClass> courseClasses = new List<CourseClass>();

                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            CourseClass courseClass = new CourseClass();

                            courseClass.Id = Convert.ToInt32(dataRow["cla_id"]);
                            courseClass.SectionNumber = Convert.ToString(dataRow["cla_section_number"]);
                            courseClass.Course = new Course {
                                Id = Convert.ToInt32(dataRow["cou_course_id"]),
                                Number = Convert.ToInt32(dataRow["cou_course_number"]),
                                Department = new Department { Code = Convert.ToString(dataRow["cou_course_department_code"]) }
                            };
                            courseClass.Dates = new DateTimeSpan {
                                Begin = Convert.ToDateTime(dataRow["cla_date_start"]),
                                End = Convert.ToDateTime(dataRow["cla_date_end"])
                            };
                            courseClass.Status = Convert.ToString(dataRow["cla_status"]);
                            courseClass.Classroom = new Classroom {
                                Id = Convert.ToInt32(dataRow["roo_classroom_id"]),
                                Number = Convert.ToInt32(dataRow["roo_classroom_number"]),
                                Section = Convert.ToString(dataRow["roo_classroom_section"]),
                                Building = new Building {
                                    Name = Convert.ToString(dataRow["roo_building_name"]),
                                    Campus = new Campus { Name = Convert.ToString(dataRow["roo_campus_name"]) }
                                }
                            };
                            courseClass.Instructor = new Account { Id = Convert.ToInt32(dataRow["cla_instructor_account_id"]) };

                            courseClasses.Add(courseClass);
                        }

                        return courseClasses;
                    }
                }
            }
        }

    }
}
