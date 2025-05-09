using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Asn1.Cms;

namespace CMS.Models
{
    internal class Schedule
    {
        private string _id;
        private Doctor _doctor;
        private string _dayofweek;
        private Time _starttime;
        private Time _endtime;

        public Schedule(string id, Doctor doctor, string dayOfWeek, Time starttime, Time endtime)
        {
            Id = id;
            Doctor = doctor;
            DayOfWeek = dayOfWeek;
            Starttime = starttime;
            Endtime = endtime;
        }

        public string Id { get { return _id; } set { _id = value; } }
        public Doctor Doctor { get { return _doctor; } set { _doctor = value; } }
        public string DayOfWeek { get { return _dayofweek; } set { _dayofweek = value; } }
        public Time Starttime { get { return _starttime; } set { _starttime = value; } }
        public Time Endtime { get { return _endtime; } set { _endtime = value; } }


    }
}
