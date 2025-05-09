using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CMS.Models
{
    internal class Doctor : User
    {
        private int age;
        private string gender;
        private string contact;

        public Doctor(string name, string password, int age, string gender, string contact) : base(name, password)
        {
            
            this.age = age;
            this.gender = gender;
            this.contact = contact;
            Type = "doctor";
        }

        public int Age { get { return age; } set { age = value; } }
        public string Gender { get { return gender; } set { gender = value; } }
        public string Contact { get { return contact; } set { contact = value; } }
    }
}
