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
    public partial class Signup : Form
    {
        public Signup()
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

            Patient patient = new Patient(name, password, age, gender,contact);

            new PatientController().AddPaitent(patient);

            this.Hide();
            new Form1().Show();

        }
    }
}
