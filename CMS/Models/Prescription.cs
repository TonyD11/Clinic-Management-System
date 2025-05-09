using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Models
{
    internal class Prescription
    {
        private int _id;
        private Appoitments _appoitments;

        public Prescription(Appoitments appoitments)
        {
            Appoitments = appoitments;
        }

        public int Id { get { return _id; } set { _id = value; } }
        public Appoitments Appoitments {  get { return this._appoitments;} set { this._appoitments = value; } }

    }
}
