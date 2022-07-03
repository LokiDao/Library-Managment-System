using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    internal class Book : Profile
    {
        protected string? author;
        protected string? publisher;

        public string getAuthor() => this.author;

        public void setAuthor(string author)
        {
            this.author = author;
        }

        public string getPublisher() => this.publisher;
        public void setPublisher(string publisher)
        {
            this.publisher = publisher;
        }
    }
}
