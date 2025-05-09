using System;
using System.Collections.Generic;
using System.Data;
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

        public void AddAppointment(Appoitments appointment)
        {
            if (appointment != null)
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection(connectionString.db);
                    connection.Open();

                    string query = "INSERT INTO appointment (patient_id, doctor_id, schedule_id) VALUES(@patientId, @doctorId, @scheduleId)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@patientId", appointment.Patient.Id);
                    command.Parameters.AddWithValue("@doctorId", appointment.Doctor.Id);
                    command.Parameters.AddWithValue("@scheduleId", appointment.Schedule.Id);
                    command.ExecuteNonQuery();

                    string updateQuery = "UPDATE doctor_schedule SET no_of_patient = no_of_patient - 1 WHERE id = @scheduleId";
                    MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@scheduleId", appointment.Schedule.Id);
                    updateCommand.ExecuteNonQuery();

                    connection.Close();
                    MessageBox.Show("Appointment Created");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Unable to create appointment.\n" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please Enter All Details");
            }
        }

        public Schedule GetScheduleById(int id)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString.db);
                connection.Open();
                string query = $"SELECT * FROM doctor_schedule WHERE id = {id}";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string startTime = reader["start_time"].ToString();
                    string endTime = reader["end_time"].ToString();
                    string dayOfWeek = reader["day_of_week"].ToString();
                    int noOfPatient = Convert.ToInt32(reader["no_of_patient"]);

                    Doctor doctor = new DoctorController().GetDoctorById(Convert.ToInt32(reader["doctor_id"]));


                    Schedule schedule = new Schedule(doctor,startTime, endTime, dayOfWeek, noOfPatient);
                    schedule.Id = id;
                    connection.Close();
                    return schedule;
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Unable to fetch schedule.\n" + ex.Message);
            }
            return null;
        }
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

        public DataTable GetAllAppointmentsOfPatient(int userid)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString.db);
                connection.Open();
                string query = "SELECT appointment.id, users.name, doctor_schedule.day_of_week , doctor_schedule.start_time, doctor_schedule.end_time, appointment.status FROM appointment INNER JOIN doctor_schedule ON appointment.schedule_id = doctor_schedule.id INNER JOIN users ON appointment.doctor_id = users.id WHERE appointment.patient_id = @userid";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@userid", userid);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable appointmentTable = new DataTable();
                adapter.Fill(appointmentTable);
                connection.Close();
                return appointmentTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Unable to fetch appointments.\n" + ex.Message);
                return null;
            }
        }

        public void UpdateAppointmentStatus(int appointmentId)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString.db);
                connection.Open();
                string query = "UPDATE appointment SET status = 'Cancelled' WHERE id = @appointmentId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@appointmentId", appointmentId);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Appointment has been cancelled.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Unable to update appointment status.\n" + ex.Message);
            }
        }



    }
}
