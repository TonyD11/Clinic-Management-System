using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Models
{
    internal class Speciality
    {
        private Doctor doctor;
        private string speciality;

        public Speciality(Doctor doctor, string speciality)
        {
            this.doctor = doctor;
            this.speciality = speciality;
        }

        public Doctor Doctor { get { return doctor; } }
        public string GetSpeciality()
        { return speciality; }

        public void SetSpeciality(string value)
        { speciality = value; }
    }
}
