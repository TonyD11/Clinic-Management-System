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

        }
    }
}
