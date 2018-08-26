using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace Task2
{
    public class Datahandler
    {
        private static string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        SqlConnection connection = new SqlConnection(connString);

        private string logText = @"C:\Users\Musman\Documents\Visual Studio 2017\Projects\Task2\Task2\log.txt";
        public List<Student> Students = new List<Student>();
        private bool isSuccess;
        public List<Student> GetStudents()
        {
            try
            {
                // open connection
                connection.Open();

                //check if connection is opened
                if (connection.State == ConnectionState.Open)
                {
                    DataSet ds = new DataSet();
                    string query = @"select * from Student";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(ds);

                    DataTable dt = ds.Tables[0];
                    foreach (DataRow item in dt.Rows)
                    {
                        Students.Add(new Student(int.Parse(item[0].ToString()),item[1].ToString(),item[2].ToString(),DateTime.Parse(item[3].ToString()),int.Parse(item[4].ToString()),bool.Parse(item[5].ToString())));
                    }
                }
                else
                {
                    throw new Exception("database not connected");
                }
            }
            catch (Exception e)
            {

                File.AppendAllText(logText, Environment.NewLine + DateTime.Now +"-- "+e.Message);
            }
            finally
            {
                connection.Close();
            }

            return Students;
        }

        public bool CreateNewStudent(string name, string surname, DateTime dob, int age, int fullTime)
        {
            try
            {
                string query = @"insert into Student
                                (name, surname, dateOfbirth,age,full_time)
                                values
                                (@name,@surname,@dob,@age,@fulltime)";

                SqlCommand cmd = new SqlCommand(query, connection);

                connection.Open();

                if (connection.State == ConnectionState.Open)
                {
                    cmd.Parameters.Add(new SqlParameter("@name", name));
                    cmd.Parameters.Add(new SqlParameter("@surname", surname));
                    cmd.Parameters.Add(new SqlParameter("@dob", dob));
                    cmd.Parameters.Add(new SqlParameter("@age", age));
                    cmd.Parameters.Add(new SqlParameter("@fulltime", fullTime));

                    cmd.ExecuteNonQuery();

                    isSuccess = true;
                }
                else
                {
                    throw new Exception("Database not connected");
                }
            }
            catch (Exception e)
            {
                File.AppendAllText(logText, Environment.NewLine + DateTime.Now + "-- " + e.Message);
            }
            finally
            {
                connection.Close();
            }
            return isSuccess;
        }

        public bool UpdateStudent(string surname, int fullTime, string id)
        {
            try
            {
                string query = @"update Student
                                set surname = @surname, full_time = @fulltime 
                                where id = @id";

                SqlCommand cmd = new SqlCommand(query, connection);

                connection.Open();

                if (connection.State == ConnectionState.Open)
                {
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.Parameters.Add(new SqlParameter("@surname", surname));
                    cmd.Parameters.Add(new SqlParameter("@fulltime", fullTime));

                    cmd.ExecuteNonQuery();

                    isSuccess = true;
                }
                else
                {
                    throw new Exception("Database not connected");
                }
            }
            catch (Exception e)
            {
                File.AppendAllText(logText, Environment.NewLine + DateTime.Now + "-- " + e.Message);
            }
            finally
            {
                connection.Close();
            }

            return isSuccess;
        }

        public bool DeleteUser(int id)
        {
            try
            {
                string query = @"delete
                                from Student
                                where id = @id";

                SqlCommand cmd = new SqlCommand(query, connection);

                connection.Open();

                if (connection.State == ConnectionState.Open)
                {
                    cmd.Parameters.Add(new SqlParameter("@id", id));

                    cmd.ExecuteNonQuery();

                    isSuccess = true;
                }
                else
                {
                    throw new Exception("Database not connected");
                }
            }
            catch (Exception e)
            {
                File.AppendAllText(logText, Environment.NewLine + DateTime.Now + "-- " + e.Message);
            }
            finally
            {
                connection.Close();
            }

            return isSuccess;
        }
    }
}