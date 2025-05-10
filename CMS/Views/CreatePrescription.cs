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
        List<Medicine> medicine = new List<Medicine>();

        private void CreatePrescription_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            var item = new Medicine
            {
                Name = textBox1.Text,
                Dosage = textBox2.Text,
                Instructions = textBox3.Text
            };

            medicine.Add(item);
            listBox1.Items.Add(item);

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

        }
    }
}
