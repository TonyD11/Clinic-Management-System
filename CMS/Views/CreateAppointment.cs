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
using CMS.Models;

namespace CMS.Views
{
    public partial class CreateAppointment : Form
    {
        public CreateAppointment()
        {
            InitializeComponent();
        }

        private void CreateAppointment_Load(object sender, EventArgs e)
        {
            DataTable dt = new DoctorController().GetAllDoctors();
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "name";  // what user sees
            comboBox1.ValueMember = "id";      // what you use internally
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int doctorId = (int)comboBox1.SelectedValue;
            string day = comboBox2.Text;

            AppoitmentController appoitmentController = new AppoitmentController();
            TimeSlots timeSlots = appoitmentController.GetDoctorTimeSlots(doctorId, day);

            var slotItems = new List<KeyValuePair<string, int>>();

            for (int i = 0; i < timeSlots.TimeSlot.Count; i++)
            {
                slotItems.Add(new KeyValuePair<string, int>(timeSlots.TimeSlot[i], timeSlots.Ids[i]));
            }

            comboBox3.DataSource = slotItems;
            comboBox3.DisplayMember = "Key";    
            comboBox3.ValueMember = "Value";
        }

        private async void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            await Task.Delay(100); 
            try
            {
                // Safely parse selected value to int
                int scheduleId;
                if (int.TryParse(comboBox3.SelectedValue.ToString(), out scheduleId))
                {
                    AppoitmentController appointmentController = new AppoitmentController();
                    int availableSlots = appointmentController.AvailablePatient(scheduleId);
                    textBox1.Text = availableSlots.ToString();
                }
                else
                {
                    textBox1.Text = "N/A";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving available slots: " + ex.Message);
                textBox1.Text = "N/A";
            }
        }

    }
}
