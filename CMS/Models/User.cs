using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Models
{
    abstract class User
    {
        private int id;
        private string name;
        private string password;
        private string type;

        protected User(string name, string password)
        {
            Name = name;
            Password = password;
            
        }

        public int Id { get { return id; } }

        public string Name { get { return name; } set { name = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string Type { get { return type; } set { type = value; } }

    }
}
