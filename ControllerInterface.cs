using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    internal interface ControllerInterface
    {
        public void show(object o, string message);
        public object get(string id);
        public void add(object o);
        public object[] getMore(string key);
        public void showMore(object[] os, string message);
        public void update(object o);
        public void delete(object o);
    }
}
