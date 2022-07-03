using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    internal class BookController : ControllerInterface
    {
        public static List<Book> list = new List<Book>();

        public BookController()
        {
            
        }

        public void show(object o, string message)
        {
            Console.Clear();
            if (Util.isSet(message)) Console.WriteLine(message);
            if (!Util.isSet(o)) return;
            Book obj = (Book)o;
            Console.WriteLine(" ");
            Console.WriteLine("=======================");
            Console.WriteLine(" ");
            Console.WriteLine("Book ID: " + obj.getId());
            Console.WriteLine("Book Title: " + obj.getName());
            Console.WriteLine("Author: " + obj.getAuthor());
            Console.WriteLine("Publisher: " + obj.getPublisher());
            Console.WriteLine("Published Date: " + obj.getDoB());
            Console.WriteLine(" ");
            Console.WriteLine("=======================");
        }

        public void showMore(object[] objs, string message)
        {
            Console.Clear();
            if (Util.isSet(message)) Console.WriteLine(message);
            Console.WriteLine(" ");
            Console.WriteLine("=======================");
            Console.WriteLine(" ");
            Console.WriteLine("| Book ID | Book Title | Author | Publisher | Published Date |");
            if (!Util.isSet(objs)) Console.WriteLine("No data found.");
            else
            {
                foreach (Book obj in objs)
                {
                    Console.WriteLine("| " + obj.getId() + " | "
                        + obj.getName() + " | "
                        + obj.getAuthor() + " | "
                        + obj.getPublisher() + " | "
                        + obj.getDoB() + " |");
                }
            }
            Console.WriteLine(" ");
            Console.WriteLine("=======================");
        }

        public object get(string id)
        {
            if (!Util.isSet(id) || !Util.isSet(list)) return null;

            foreach (Book obj in list)
            {
                if (Util.isSet(obj.getId()) && obj.getId().Equals(id))
                {
                    return obj;
                }
            }

            return null;
        }

        public static object find(string id)
        {
            if (!Util.isSet(id) || !Util.isSet(list)) return new Book();

            foreach (Book obj in list)
            {
                if (Util.isSet(obj.getId()) && obj.getId().Equals(id))
                {
                    return obj;
                }
            }

            return new Book();
        }

        public object[] getMore(string key)
        {
            if (list == null) list = new List<Book>();
            if (!Util.isSet(key) || Util.isAll(key))
            {
                return list.ToArray();
            }
            else
            {
                List<Book> objs = new List<Book>();

                foreach (Book obj in list)
                {
                    if (Util.isSet(obj) && (obj.getId().Contains(key)
                        || obj.getName().Contains(key)
                        || obj.getDoB().Contains(key)
                        || obj.getAuthor().Contains(key)
                        || obj.getPublisher().Contains(key)))
                    {
                        objs.Add(obj);
                    }
                }

                return objs.ToArray();
            }
        }

        public static object[] findMore(object[] ids)
        {
            if (!Util.isSet(ids)) return null;
            if (list == null) list = new List<Book>();

            List<Book> objs = new List<Book>();
            foreach (Book obj in list)
            {
                foreach(string id in ids)
                if (Util.isSet(obj) && (obj.getId().Equals(id)))
                {
                    objs.Add(obj);
                }
            }

            return objs.ToArray();
        }

        public void add(object o)
        {
            string message = null;
            Book obj = null;

            if (Util.isSet(o))
            {
                obj = (Book)o;
                list.Add(obj);
                message = "Book (" + obj.getId() + ") has been added successfully.";
                this.show(this.get(obj.getId()), message);
                return;
            }

            Console.Clear();
            obj = new Book();

            Console.WriteLine("Book ID:");
            bool rs = false;
            string input = null;
            do
            {
                input = Console.ReadLine();
                if (Util.isSet(this.get(input)))
                {
                    Console.WriteLine("Book ID (" + input + ") is already existed." +
                        " Please try again or input \"C\" key to cancel.");
                }
                else
                {
                    if (!Util.isSet(input))
                        Console.WriteLine("ID cannot be blank. Please try again or input \"C\" key to cancel.");
                    else if (Util.isCancel(input))
                    {
                        Console.WriteLine("Adding new process has been cancelled.");
                        return;
                    }
                    else 
                    {
                        rs = Util.isNumber(input);
                        if (rs == false) 
                            Console.WriteLine("Incorrect ID. Please try again or input \"C\" key to cancel.");
                        else obj.setId(input);
                    }
                }
            } while (!Util.isSet(input) || rs == false);

            Console.WriteLine("Book Title:");
            rs = false;
            input = null;
            do
            {
                input = Console.ReadLine();
                if (!Util.isSet(input))
                    Console.WriteLine("Title cannot be blank. Please try again or input \"C\" key to cancel.");
                else if (Util.isCancel(input))
                {
                    Console.WriteLine("Adding new process has been cancelled.");
                    return;
                }
                else obj.setName(input);
            } while (!Util.isSet(input));

            Console.WriteLine("Author:");
            obj.setAuthor(Console.ReadLine());

            Console.WriteLine("Publisher:");
            obj.setPublisher(Console.ReadLine());

            Console.WriteLine("Published Date:");
            rs = false;
            input = null;
            do
            {
                input = Console.ReadLine();
                if (Util.isCancel(input))
                {
                    Console.WriteLine("Adding new process has been cancelled.");
                    return;
                }
                else if (Util.isSet(input))
                {
                    rs = Util.isDate(input);
                    if (rs == false)
                        Console.WriteLine("Incorrect date format. Please try again or input \"C\" key to cancel.");
                    else obj.setDoB(input);
                }
            } while (Util.isSet(input) && rs == false);

            list.Add(obj);
            message = "Book (" + obj.getId() + ") has been added successfully.";
            this.show(this.get(obj.getId()), message);
        }

        public void update(object o)
        {
            string message = null;
            Book obj = null;

            if(Util.isSet(o))
            {
                obj = (Book)o;
                Book tmp = (Book) this.get(obj.getId());
                if(!Util.isSet(tmp))
                {
                    Console.WriteLine("Book ID (" + obj.getId() + ") does not exist.");
                    return;
                }

                tmp.setName(obj.getName());
                tmp.setAuthor(obj.getAuthor());
                tmp.setPublisher(obj.getPublisher());
                tmp.setDoB(obj.getDoB());
                message = "Book (" + obj.getId() + ") has been updated successfully.";
                this.show(this.get(tmp.getId()), message);
                return;
            }

            Console.Clear();
            Console.WriteLine("Book ID need to be updated:");
            string input = null;
            do {
                input = Console.ReadLine();

                if (Util.isCancel(input))
                {
                    Console.WriteLine("Updating process has been cancelled.");
                    return;
                }
                else if (Util.isSet(input))
                {
                    obj = (Book)this.get(input);
                    if (!Util.isSet(obj))
                        Console.WriteLine("Book ID (" + input + ") does not exist." +
                            " Please try again or input \"C\" key to cancel.");
                }
            } while (Util.isSet(input) && obj == null);

            message = "Current Book (" + obj.getId() + ") information.";
            this.show(obj, message);

            Console.WriteLine("New Book Title:");
            Console.WriteLine("(Input a new one or press \"Enter\" to skip this step.)");
            input = Console.ReadLine();
            if (Util.isSet(input)) obj.setName(input);

            Console.WriteLine("New Author:");
            Console.WriteLine("(Input a new one or press \"Enter\" to skip this step.)");
            input = Console.ReadLine();
            if (Util.isSet(input)) obj.setAuthor(input);

            Console.WriteLine("New Publisher:");
            Console.WriteLine("(Input a new one or press \"Enter\" to skip this step.)");
            input = Console.ReadLine();
            if (Util.isSet(input)) obj.setPublisher(input);

            Console.WriteLine("New Published Date:");
            Console.WriteLine("(Please input a new one or press \"Enter\" to skip this step.)");
            bool rs = false;
            input = null;
            do
            {
                input = Console.ReadLine();
                if (Util.isCancel(input))
                {
                    Console.WriteLine("Updating process has been canceled.");
                    return;
                }
                else if (Util.isSet(input))
                {
                    rs = Util.isDate(input);
                    if (rs == false)
                        Console.WriteLine("Incorrect date format." +
                            " Please try again or press \"Enter\" to skip this step or input \"C\" key to cancel.");
                    else obj.setDoB(input);
                }
            } while (Util.isSet(input) && rs == false);

            message = "Book (" + obj.getId() + ") has been updated successfully.";
            this.show(this.get(obj.getId()), message);
            return;
        }

        public void delete(object o)
        {
            string message = null;
            Book obj = null;

            if (Util.isSet(o))
            {
                obj = (Book)o;
                Book tmp = (Book)this.get(obj.getId());
                if (!Util.isSet(tmp))
                {
                    Console.WriteLine("Book ID (" + obj.getId() + ") does not exist.");
                    return;
                }

                list.Remove(obj);
                message = "Book (" + obj.getId() + ") has been deleted successfully.";
                this.showMore(this.getMore("ALL"), message);
                return;
            }

            Console.Clear();
            Console.WriteLine("Book ID need to be deleted:");
            string input = null;
            do
            {
                input = Console.ReadLine();

                if (Util.isCancel(input))
                {
                    Console.WriteLine("Deleting process has been canceled.");
                    return;
                }
                else if (Util.isSet(input))
                {
                    obj = (Book)this.get(input);
                    if (!Util.isSet(obj))
                        Console.WriteLine("Book ID (" + input + ") does not exist." +
                            " Please try again or input \"C\" key to cancel.");
                }
            } while (!Util.isSet(input));

            message = "Current Book (" + obj.getId() + ") information.";
            this.show(obj, message);

            Console.WriteLine("Are you sure to delete? (Y/N)");
            input = Console.ReadLine();
            if (Util.isConfirmed(input))
            {
                list.Remove(obj);
                message = "Book (" + obj.getId() + ") has been deleted successfully.";
                this.showMore(this.getMore("ALL"), message);
            }
            else Console.WriteLine("Deleting process has been denined.");
        }

    }
}
