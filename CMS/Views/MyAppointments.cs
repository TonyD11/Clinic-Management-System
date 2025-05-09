using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CMS.Controller;
using static CMS.Controller.AuthController;

namespace CMS.Views
{
    public partial class MyAppointments : Form
    {
        public MyAppointments()
        {
            InitializeComponent();
        }

        private void MyAppointments_Load(object sender, EventArgs e)
        {
            DataTable dt = new AppoitmentController().GetAllAppointmentsOfPatient(Sessions.Id);

            if (dt != null)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].HeaderText = "Appointment ID";
                dataGridView1.Columns[1].HeaderText = "Doctor Name";
                dataGridView1.Columns[2].HeaderText = "Day of Week";
                dataGridView1.Columns[3].HeaderText = "Start Time";
                dataGridView1.Columns[4].HeaderText = "End Time";
                dataGridView1.Columns[5].HeaderText = "Status";
            }
            else
            {
                MessageBox.Show("No Appointments Found");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int appointmentId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                string status = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                if (status == "upcoming")
                {
                    new AppoitmentController().UpdateAppointmentStatus(appointmentId);
                }
                MyAppointments_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Please select an appointment to update.");
            }
        }
    }
}
