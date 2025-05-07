using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Models
{
    internal class Patient : User
    {
        private int age;
        private string gender;
        private string contact;

        public Patient(string name, string password, int age, string gender, string contact ) : base(name, password)
        {
            this.age = age;
            this.gender = gender;
            this.contact = contact;
            Type = "Patient";
        }

        public int Age {  get { return age; } set { age = value; } }
        public string Gender { get { return gender; } set { gender = value; } }
        public string Contact { get { return contact; } set { contact = value; } }
    }
}
