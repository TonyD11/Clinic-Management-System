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
    }
}
