using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    internal class Order
    {
        public string? id;
        public Member? member;
        public List<Book>? books;
        public string? orderedDate;
        public string? returnedDate;
        public bool status;     // false -> closed. true -> open.

        public Order()
        {
            this.member = new Member();
            this.books = new List<Book>();
            this.status = true;
        }
    }
}
