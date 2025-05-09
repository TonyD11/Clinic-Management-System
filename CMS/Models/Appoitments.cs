using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Models
{
    internal class Appoitments
    {
        private int _id;
        private Patient _patient;
        private Doctor _doctor;
        private Schedule _schedule;
        private string _status;

        public Appoitments(int id, Patient patient, Doctor doctor, Schedule schedule)
        {
            Id = id;
            Patient = patient;
            Doctor = doctor;
            Schedule = schedule;
            Status = "upcoming";
        }

        public int Id { get { return _id; } set { _id = value; } }
        public Patient Patient { get { return _patient; } set { _patient = value; } }
        public Doctor Doctor { get { return _doctor; } set { _doctor = value; } }
        public Schedule Schedule { get { return _schedule; } set { _schedule = value; } }
        public string Status { get { return _status; } set { _status = value; } }
    }
}
