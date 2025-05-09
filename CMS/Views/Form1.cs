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
using CMS.Views;
using MySql.Data.MySqlClient;

namespace CMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string password = textBox2.Text;

            AuthController authController = new AuthController();
            string type = authController.Login(name, password);

            if (type == "patient")
            {
                MessageBox.Show($"Welcome {name}");
                this.Hide();
                new PatientDashboard().Show();
            }else if (type == "admin")
            {
                this.Hide();
                new AdminDashboard().Show();
            }else if(type == "doctor"){
                this.Hide();
                new DoctorDashboard().Show();
            }
            else
            {
                MessageBox.Show("Unknown User");
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new Signup().Show();
        }
    }
}
