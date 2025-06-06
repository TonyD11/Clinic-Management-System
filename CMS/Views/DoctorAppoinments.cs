﻿using System;
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
    public partial class DoctorAppoinments : Form
    {
        public DoctorAppoinments()
        {
            InitializeComponent();
        }

        private void DoctorAppoinments_Load(object sender, EventArgs e)
        {
            int DoctorId = Sessions.Id;

            DataTable dt = new AppoitmentController().GetAppointmentsOfDoctor(DoctorId);

            if (dt != null)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].HeaderText = "Appointment ID";
                dataGridView1.Columns[1].HeaderText = "Patient Name";
                dataGridView1.Columns[2].HeaderText = "Day Of Week";
                dataGridView1.Columns[3].HeaderText = "Status";

                

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
                string status = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                if (status == "upcoming")
                {
                    new AppoitmentController().CompleteAppointment(appointmentId);
                }
                DoctorAppoinments_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Please select an appointment to update.");
            }
        }
    }
}
