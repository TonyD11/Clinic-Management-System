using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using CMS.Models;
using System.Xml.Linq;

namespace CMS.Controller
{
    internal class PrescriptionController
    {
        ConnectionString connectionString = new ConnectionString();

        public int AddPrescription(int appointment_id)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString.db);
                connection.Open();

                string query = "INSERT INTO prescription (appointment_id) VALUES (@appointment_id); SELECT LAST_INSERT_ID();";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@appointment_id", appointment_id);

                int insertedId = Convert.ToInt32(command.ExecuteScalar());

                connection.Close();
                return insertedId;



            }
            catch
            {
                MessageBox.Show("Couldnt Add the Prescription");
                return -1;
            }
        }

        public void AddMedicine(int prescription_id, Medicine details)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString.db);
                connection.Open();

                string query = @"INSERT INTO medicine 
                             (prescription_id, name, dosage, instruction) 
                             VALUES (@prescription_id, @name, @dosage, @instruction)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@prescription_id", prescription_id);
                command.Parameters.AddWithValue("@name", details.Name);
                command.Parameters.AddWithValue("@dosage", details.Dosage);
                command.Parameters.AddWithValue("@instruction", details.Instructions);

                command.ExecuteNonQuery();

                connection.Close();
            }
            catch
            {
                MessageBox.Show("Could Not Add the Medicine to Prescription");
            }
        }

        public DataTable GetAppointmentsOfDoctor(int doctorId)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString.db);
                connection.Open();
                string query = "SELECT appointment.id, users.name, doctor_schedule.day_of_week , appointment.status FROM appointment INNER JOIN doctor_schedule ON appointment.schedule_id = doctor_schedule.id INNER JOIN users ON appointment.patient_id = users.id WHERE appointment.doctor_id = @doctorId AND appointment.status = 'Completed'";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@doctorId", doctorId);
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
    }
}
