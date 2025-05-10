using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CMS.Models;

namespace CMS.Views
{
    public partial class CreatePrescription : Form
    {
        private int appointmentId;
        public CreatePrescription(int appointmentId)
        {
            InitializeComponent();
            this.appointmentId = appointmentId;
        }

        private void CreatePrescription_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string dosage = textBox2.Text;
            string instruction = textBox3.Text;

            
        }
    }
}
