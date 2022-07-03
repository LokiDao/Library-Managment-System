using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    internal class Member : Profile
    {
        protected string? gender;   // null -> Unknow. F -> Female. M -> Male. O -> Others.
        
        public string getGender() => this.gender;

        public void setGender(string gender)
        {
            this.gender = gender;
        }
    }
}
