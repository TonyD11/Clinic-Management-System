using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Models
{
    internal class Medicine
    {
        private int _id;
        private string _name;
        private string _dosage;
        private string _instructions;
        private Prescription _prescription;

        public Medicine(string name, string dosage, string instructions, Prescription prescription)
        {
            Name = name;
            Dosage = dosage;
            Instructions = instructions;
            Prescription = prescription;
        }

        public int Id { get { return _id; } set { _id = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string Dosage { get { return _dosage; } set { _dosage = value; } }
        public string Instructions { get { return _instructions; } set { _instructions = value; } }
        public Prescription Prescription { get { return  _prescription; } set { _prescription = value; } }

    }
}
