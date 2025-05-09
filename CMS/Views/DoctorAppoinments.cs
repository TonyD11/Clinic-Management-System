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
    public partial class DoctorAppoinments : Form
    {
        public DoctorAppoinments()
        {
            InitializeComponent();
        }

        private void DoctorAppoinments_Load(object sender, EventArgs e)
        {
            int DoctorId = Sessions.Id;

            DataTable dt = new AppoitmentController().GetAppointmentsOfDoctor(DoctorId);

            if (dt != null)
            {
                dataGridView1.DataSource = dt;
                
            }
            else
            {
                MessageBox.Show("No Appointments Found");
            }
        }
    }
}
