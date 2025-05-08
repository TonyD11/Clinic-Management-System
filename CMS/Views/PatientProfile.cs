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
    }
}
