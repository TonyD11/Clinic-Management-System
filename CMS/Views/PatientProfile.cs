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
using static CMS.Controller.AuthController;


namespace CMS.Views
{
    public partial class PatientProfile : Form
    {
        public PatientProfile()
        {
            InitializeComponent();
        }

        private void PatientProfile_Load(object sender, EventArgs e)
        {
            textBox1.Text = Sessions.Name;
            textBox2.Text = Sessions.Password;
            textBox3.Text = Sessions.Age.ToString();
            textBox4.Text = Sessions.Contact;
            comboBox1.Text = Sessions.Gender;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string password = textBox2.Text;
            int age = Convert.ToInt32(textBox3.Text);
            string contact = textBox4.Text;
            string gender = comboBox1.Text;

            Patient patient = new Patient(name, password, age, gender, contact);

            new PatientController().EditPatient(patient);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            new PatientController().DeactivateProfile(Sessions.Id);

            Application.Restart();
        }
    }
}
