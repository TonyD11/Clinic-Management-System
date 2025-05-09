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
    public partial class AddSpeciality : Form
    {
        public AddSpeciality()
        {
            InitializeComponent();
        }
        DataTable dt = new DoctorController().GetAllDoctors();
        private void AddSpeciality_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "name";  // what user sees
            comboBox1.ValueMember = "id";      // what you use internally
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string speciality_name = textBox1.Text;
            int selectedDoctorId = Convert.ToInt32(comboBox1.SelectedValue);

            Doctor doctor = new DoctorController().GetDoctorById(selectedDoctorId);
            doctor.Id = selectedDoctorId;

            Speciality speciality = new Speciality(doctor, speciality_name);

            new DoctorController().AddSpecialist(doctor, speciality_name);

            this.Hide();

            
        }
    }
}
