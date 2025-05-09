using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Models;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

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

        public DataTable GetAllDoctors() {

            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString.db);
                connection.Open();

                string query = "Select * from users where type = 'doctor'";
                MySqlCommand command = new MySqlCommand( query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                DataTable doctorTable = new DataTable();
                adapter.Fill(doctorTable);

                connection.Close();

                return doctorTable;
            }
            catch
            {
                MessageBox.Show("Could not find doctor details!");
                return null;
            }
        }

        public Doctor GetDoctorById(int Id)
        {

            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString.db);
                connection.Open();

                string query = $"Select * from users where id = {Id}";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) {
                    string name = reader.GetString(1);
                    string password = reader.GetString(2);
                    int age = reader.GetInt32(3);
                    string gender = reader.GetString(4);
                    string contact = reader.GetString(5);

                    connection.Close();

                    Doctor doctor = new Doctor(name, password, age, gender, contact);

                    return doctor;
                }

                return null;
            }
            catch
            {
                MessageBox.Show("Could not find doctor details!");
                return null;
            }
        }

        public void AddSpecialist(Doctor doctor, string name)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection (connectionString.db);
                connection.Open();

                string query = "INSERT INTO doctor_specialties (user_id, specialty) VALUES (@user_id, @specialty)";
                MySqlCommand command = new MySqlCommand( query, connection);
                command.Parameters.AddWithValue("@user_id", doctor.Id);
                command.Parameters.AddWithValue("@specialty", name);
                command.ExecuteNonQuery();

                connection.Close();

                MessageBox.Show("Specialist Added Succefully");
            }
            catch
            {
                MessageBox.Show("Unable to add Specialist");
            }
        }

        public void AddTimeSchedule(Schedule schedule) 
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString.db);
                connection.Open();

                string query = "Insert Into doctor_schedule (doctor_id , day_of_week,start_time,end_time,no_of_patient) values (@doctor_id , @day_of_week, @start_time, @end_time, @no_of_patient)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@doctor_id", schedule.Doctor.Id);
                command.Parameters.AddWithValue("@day_of_week", schedule.DayOfWeek.ToString());
                command.Parameters.AddWithValue("@start_time", schedule.Starttime);
                command.Parameters.AddWithValue("@end_time", schedule.Endtime);
                command.Parameters.AddWithValue("@no_of_patient", schedule.Count);

                command.ExecuteNonQuery();

                connection.Close();

                MessageBox.Show("Appoitment Approval Time Added");

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
