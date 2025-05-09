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
    public partial class CreateDoctors : Form
    {
        public CreateDoctors()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string password = textBox2.Text;
            int age = Convert.ToInt32(textBox3.Text);
            string contact = textBox4.Text;
            string gender = comboBox1.Text;

            Doctor doctor = new Doctor(name,password, age, gender, contact);

            new DoctorController().AddDoctor(doctor);

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.Text = "";
        }
    }
}
