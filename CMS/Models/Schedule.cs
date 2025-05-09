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
        private int _id;
        private Doctor _doctor;
        private string _dayofweek;
        private string _starttime;
        private string _endtime;
        private int _count;

        public Schedule(Doctor doctor, string dayOfWeek, string starttime, string endtime, int count)
        {
            Id = _id;
            Doctor = doctor;
            DayOfWeek = dayOfWeek;
            Starttime = starttime;
            Endtime = endtime;
            _count = count;
        }

        public int Id { get { return _id; } set { _id = value; } }
        public Doctor Doctor { get { return _doctor; } set { _doctor = value; } }
        public string DayOfWeek { get { return _dayofweek; } set { _dayofweek = value; } }
        public string Starttime { get { return _starttime; } set { _starttime = value; } }
        public string Endtime { get { return _endtime; } set { _endtime = value; } }
        public int Count { get { return _count;  }  set { _count = value; } }


    }
}
