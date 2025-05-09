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
    internal class AppoitmentController
    {
        ConnectionString connectionString = new ConnectionString();
        public TimeSlots GetDoctorTimeSlots(int doctorId, string day)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString.db);
                connection.Open();

                string query = "SELECT id, start_time, end_time, no_of_patient FROM doctor_schedule WHERE doctor_id = @doctorId AND day_of_week = @day";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@doctorId", doctorId);
                command.Parameters.AddWithValue("@day", day);

                MySqlDataReader reader = command.ExecuteReader();
                TimeSlots timeSlots = new TimeSlots(new List<string>(), new List<int>());

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string startTime = reader["start_time"].ToString();
                    string endTime = reader["end_time"].ToString();
                    int noOfPatient = reader.GetInt32(3);

                    if (noOfPatient > 0)
                    {
                        string timeSlot = $"{startTime} - {endTime}";
                        timeSlots.TimeSlot.Add(timeSlot);
                        timeSlots.Ids.Add(id);
                    }
                }

                reader.Close();
                connection.Close();

                if (timeSlots.TimeSlot.Count == 0)
                {
                    timeSlots.TimeSlot.Add("No time slots available");
                    timeSlots.Ids.Add(1);
                }

                return timeSlots;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Unable to fetch time slots.\n" + ex.Message);
                return null;
            }
        }

        public int AvailablePatient(int scheduleId)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString.db);
                connection.Open();
                string query = "SELECT no_of_patient FROM doctor_schedule WHERE id = @scheduleId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@scheduleId", scheduleId);
                int availablePatient = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
                return availablePatient;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Unable to fetch available patients.\n" + ex.Message);
                return -1;
            }
        }



    }
}
