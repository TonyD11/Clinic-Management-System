using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CMS.Controller
{
    internal class AuthController
    {
        public string Login(string username, string password)
        {
            try
            {
                string query = "select * from users where name = @username";

                ConnectionString connectionString = new ConnectionString();
                MySqlConnection connection = new MySqlConnection(connectionString.db);

                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);

                MySqlDataReader reader = command.ExecuteReader();


                if (reader.Read())
                {
                    string dbPassword = reader["password"].ToString();

                    if (dbPassword == password)
                    {
                        string type = reader["type"].ToString();

                        bool availability = Convert.ToBoolean(reader["availability"]);

                        if (availability)
                        {
                            Sessions.Id = Convert.ToInt32(reader["id"]);
                            Sessions.Age = Convert.ToInt32(reader["age"]);
                            Sessions.Availability = Convert.ToBoolean(reader["availability"]);
                            Sessions.Name = Convert.ToString(reader["name"]);
                            Sessions.Gender = Convert.ToString(reader["gender"]);
                            Sessions.Contact = Convert.ToString(reader["contact"]);
                            Sessions.Password = Convert.ToString(reader["password"]);
                            Sessions.Type = type;


                            connection.Close();
                            return type;
                        }
                        else
                        {
                            MessageBox.Show("User is not available or has been deactivated.");
                            connection.Close();
                            return "not_available";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong Credentials");
                        return "wrong_password";
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Login Failed");
                return null;
            }


            return null;
        }

        public static class Sessions
        {
            public static int Id { get; set; }
            public static string Name { get; set; }
            public static string Password { get; set; }
            public static string Contact { get; set; }
            public static string Gender { get; set; }
            public static string Type { get; set; }
            public static int Age { get; set; }
            public static bool Availability { get; set; }
        }
    }
}
