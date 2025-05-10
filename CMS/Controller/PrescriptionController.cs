using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace CMS.Controller
{
    internal class PrescriptionController
    {
        ConnectionString connectionString = new ConnectionString();
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
