using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
