using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CMS.Models;
using MySql.Data.MySqlClient;
using static CMS.Controller.AuthController;

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

        public void EditPatient(Patient patient)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString.db);
                connection.Open();

                string query = @"UPDATE users 
                 SET name = @name, 
                     password = @password, 
                     age = @age, 
                     gender = @gender, 
                     contact = @contact,  
                 WHERE id = @id";

                MySqlCommand command = new MySqlCommand( query, connection);
                command.Parameters.AddWithValue("@name", patient.Name);
                command.Parameters.AddWithValue("@password", patient.Password);
                command.Parameters.AddWithValue("@age", patient.Age);
                command.Parameters.AddWithValue("@gender", patient.Gender);
                command.Parameters.AddWithValue("@contact", patient.Contact);
                command.Parameters.AddWithValue("@id", Sessions.Id);

                command.ExecuteNonQuery();

                connection.Close();

                MessageBox.Show("Profile Successfully edited");

                Sessions.Name = patient.Name;
                Sessions.Password = patient.Password;
                Sessions.Age = patient.Age;
                Sessions.Gender = patient.Gender;
                Sessions.Contact = patient.Contact;


            }
            catch
            {
                MessageBox.Show("Could Not Edit the Profile");
            }
        }

        public void DeactivateProfile(int id)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString.db);
                connection.Open();

                string query = $"Update users SET availability = 0 where id = {id}";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();

                connection.Close();
                MessageBox.Show("Account Deactivated");

            }catch 
            {
                MessageBox.Show("Deactivation Failed");
            }
        }

        public Patient SessionPatientDetails()
        {
            Patient patient = new Patient(null, null,0,null,null);

            patient.Id = Sessions.Id;
            patient.Name = Sessions.Name;
            patient.Password = Sessions.Password;
            patient.Age = Sessions.Age;
            patient.Gender = Sessions.Gender;
            patient.Contact = Sessions.Contact;
            patient.Type = Sessions.Type;
            return patient;
        }
    }
}
