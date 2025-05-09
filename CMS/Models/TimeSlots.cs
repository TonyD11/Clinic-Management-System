using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Models
{
    internal class TimeSlots
    {
        public TimeSlots(List<string> timeSlot, List<int> ids)
        {
            TimeSlot = timeSlot;
            Ids = ids;
        }

        public List<string> TimeSlot { get; set; }
        public List<int> Ids { get; set; }
    }
}
