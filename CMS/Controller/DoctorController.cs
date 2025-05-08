using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Models;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace CMS.Controller
{
    internal class DoctorController
    {
        ConnectionString connectionString = new ConnectionString();
        public void AddDoctor(Doctor doctor)
        {
            if (doctor != null)
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection(connectionString.db);
                    connection.Open();

                    string query = "INSERT INTO users (name, password, age, gender, contact, type) VALUES(@name,@password,@age,@gender,@contact,@type)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@name", doctor.Name);
                    command.Parameters.AddWithValue("@password", doctor.Password);
                    command.Parameters.AddWithValue("@age", doctor.Age);
                    command.Parameters.AddWithValue("@gender", doctor.Gender);
                    command.Parameters.AddWithValue("@contact", doctor.Contact);
                    command.Parameters.AddWithValue("@type", doctor.Type);
                    command.ExecuteNonQuery();

                    connection.Close();

                    MessageBox.Show("Register Completed");


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Registartion Failed.");
                }
            }
            else
            {
                MessageBox.Show("Please Enter All Details");
            }
        }
    }
}
