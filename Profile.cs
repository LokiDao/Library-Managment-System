using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    internal abstract class Profile
    {
        protected string? id;
        protected string? name;
        protected string? doB;

        public string getId() => this.id;

        public void setId(string id)
        {
            this.id = id;
        }

        public string getName() => this.name;
        
        public void setName(string name)
        {
            this.name = name;
        }

        public string getDoB() => this.doB;
        
        public void setDoB(string dob)
        {
            this.doB = dob;
        }
    }
}
