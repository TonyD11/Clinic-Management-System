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
using Org.BouncyCastle.Asn1.X509;
using static CMS.Controller.AuthController;

namespace CMS.Views
{
    public partial class TimeScheduler : Form
    {
        public TimeScheduler()
        {
            InitializeComponent();
        }

        private void TimeScheduler_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "hh:mm tt";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "hh:mm tt";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string wod = comboBox1.Text;
            DateTime starttime = dateTimePicker1.Value;
            DateTime endtime = dateTimePicker2.Value;
            int noofpatients = Convert.ToInt32(textBox1.Text);

            string start = starttime.ToString("HH:mm");
            string end = endtime.ToString("HH:mm");

            Doctor doctor = new Doctor(Sessions.Name, Sessions.Password, Sessions.Age, Sessions.Gender, Sessions.Contact);
            doctor.Id = Sessions.Id;

            Schedule schedule = new Schedule(doctor, wod, start, end, noofpatients);
            
            new DoctorController().AddTimeSchedule(schedule);

        }
    }
}
