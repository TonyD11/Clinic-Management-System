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

                        connection.Close();

                        return type;
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
    }
}
