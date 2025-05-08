using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CMS.Models;
using MySql.Data.MySqlClient;

namespace CMS.Controller
{
    internal class PatientController
    {
        ConnectionString connectionString = new ConnectionString();
        public void AddPaitent(Patient patient)
        {
             if (patient != null)
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection(connectionString.db);
                    connection.Open();

                    string query = "INSERT INTO users (name, password, age, gender, contact, type) VALUES(@name,@password,@age,@gender,@contact,@type)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@name",patient.Name);
                    command.Parameters.AddWithValue("@password", patient.Password);
                    command.Parameters.AddWithValue("@age", patient.Age);
                    command.Parameters.AddWithValue("@gender", patient.Gender);
                    command.Parameters.AddWithValue("@contact", patient.Contact);
                    command.Parameters.AddWithValue("@type", patient.Type);
                    command.ExecuteNonQuery();

                    connection.Close();

                    MessageBox.Show("Register Completed");


                }
                catch (Exception ex) {
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
