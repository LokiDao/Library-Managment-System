using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    internal class OrderController : ControllerInterface
    {
        public List<Order> list;

        public OrderController()
        {
            this.list = new List<Order>();
        }

        public void show(object o, string message)
        {
            Console.Clear();
            if (Util.isSet(message)) Console.WriteLine(message);
            if (!Util.isSet(o)) return;
            Order obj = (Order)o;
            Console.WriteLine(" ");
            Console.WriteLine("=======================");
            Console.WriteLine(" ");
            Console.WriteLine("Order ID: " + obj.id);
            Console.WriteLine("Member: [" + obj.member.getId() + "] " + obj.member.getName());
            Console.WriteLine("Number of Books: " + obj.books.Count);
            Console.WriteLine("Ordered Date: " + obj.orderedDate);
            Console.WriteLine("Returned Date: " + obj.returnedDate);
            string status = (obj.status) ? "OPEN" : "CLOSED";
            Console.WriteLine("Status: " + status);
            Console.WriteLine("------------------------");
            Console.WriteLine("| Book ID | Book Title | Author | Publisher | Published Date |");
            if (!Util.isSet(obj.books)) Console.WriteLine("No data found.");
            else
            {
                foreach (Book bk in obj.books)
                {
                    Console.WriteLine("| " + bk.getId() + " | "
                        + bk.getName() + " | "
                        + bk.getAuthor() + " | "
                        + bk.getPublisher() + " | "
                        + bk.getDoB() + " |");
                }
            }
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
            Console.WriteLine("| Order ID | Member | Number of Books | Ordered Date | Returned Date | Status |");
            if (!Util.isSet(objs)) Console.WriteLine("No data found.");
            else
            {
                foreach (Order obj in objs)
                {
                    string status = (obj.status) ? "OPEN" : "CLOSED";
                    Console.WriteLine("| " + obj.id + " | "
                        + "[" + obj.member.getId() + "] " + obj.member.getName() + " | "
                        + obj.books.Count + " | "
                        + obj.orderedDate + " | "
                        + obj.returnedDate + " | "
                        + status + " |");
                }
            }
            Console.WriteLine(" ");
            Console.WriteLine("=======================");
        }

        public object get(string id)
        {
            if (!Util.isSet(id) || !Util.isSet(this.list)) return null;

            foreach (Order obj in this.list)
            {
                if (Util.isSet(obj.id) && obj.id.Equals(id))
                {
                    return obj;
                }
            }

            return null;
        }

        public object[] getMore(string key)
        {
            if (this.list == null) this.list = new List<Order>();
            if (!Util.isSet(key) || Util.isAll(key))
            {
                return this.list.ToArray();
            }
            else
            {
                List<Order> objs = new List<Order>();

                foreach (Order obj in this.list)
                {
                    string status = (obj.status) ? "OPEN" : "CLOSED";
                    if (Util.isSet(obj) && (obj.id.Contains(key)
                        || obj.member.getId().Contains(key)
                        || obj.member.getName().Contains(key)
                        || obj.orderedDate.Contains(key)
                        || obj.returnedDate.Contains(key)
                        || status.Contains(key)))
                    {
                        objs.Add(obj);
                    }
                }

                return objs.ToArray();
            }
        }

        public void add(object o)
        {
            string message = null;
            Order obj = null;

            if (Util.isSet(o))
            {
                obj = (Order)o;
                this.list.Add(obj);
                message = "Book (" + obj.id + ") has been added successfully.";
                this.show(this.get(obj.id), message);
                return;
            }

            Console.Clear();
            obj = new Order();

            Console.WriteLine("Order ID:");
            bool rs = false;
            string input = null;
            do
            {
                input = Console.ReadLine();
                if (Util.isSet(this.get(input)))
                {
                    Console.WriteLine("Order ID (" + input + ") is already existed." +
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
                        else obj.id = input;
                    }
                }
            } while (!Util.isSet(input) || rs == false);

            Console.WriteLine("Member ID:");
            rs = false;
            input = null;
            do
            {
                input = Console.ReadLine();
                if (!Util.isSet(input))
                    Console.WriteLine("Member ID cannot be blank. Please try again or input \"C\" key to cancel.");
                else if (Util.isCancel(input))
                {
                    Console.WriteLine("Adding new process has been cancelled.");
                    return;
                }
                else
                {
                    Member mem = (Member)MemberController.find(input);
                    rs = Util.isSet(mem);
                    if (rs == false)
                        Console.WriteLine("Member ID (" + input + ") does not existed." +
                            " Please try again or input \"C\" key to cancel.");
                    else obj.member = mem;
                }
            } while (!Util.isSet(input) || rs == false);

            Console.WriteLine("Ordered Date:");
            rs = false;
            input = null;
            do
            {
                input = Console.ReadLine();
                if (!Util.isSet(input))
                    Console.WriteLine("Ordered Date cannot be blank. Please try again or input \"C\" key to cancel.");
                else if (Util.isCancel(input))
                {
                    Console.WriteLine("Adding new process has been cancelled.");
                    return;
                }
                else
                {
                    rs = Util.isDate(input);
                    if (rs == false)
                        Console.WriteLine("Incorrect date format. Please try again or input \"C\" key to cancel.");
                    else obj.orderedDate = input;
                }
            } while (!Util.isSet(input) || rs == false);

            obj.status = true;

            Console.WriteLine("Books list:");
            List<Book> books = new List<Book>();
            do
            {
                Console.WriteLine("Book ID:");
                input = Console.ReadLine();

                Book bk = (Book)BookController.find(input);
                rs = Util.isSet(bk);
                if (rs == false)
                    Console.WriteLine("Book ID (" + input + ") does not existed.");
                else books.Add(bk);
                Console.WriteLine("Do you want to continue? (Y/N)");
                input = Console.ReadLine();
            } while (!Util.isSet(input) || (!input.Equals("N") && !input.Equals("n")));

            obj.books = books;
            this.list.Add(obj);
            message = "Order (" + obj.id + ") has been added successfully.";
            this.show(this.get(obj.id), message);
        }

        public void update(object o)
        {
            string message = null;
            Order obj = null;

            if(Util.isSet(o))
            {
                obj = (Order)o;
                Order tmp = (Order) this.get(obj.id);
                if(!Util.isSet(tmp))
                {
                    Console.WriteLine("Order ID (" + obj.id + ") does not exist.");
                    return;
                }

                tmp.member = obj.member;
                tmp.orderedDate = obj.orderedDate;
                tmp.returnedDate = obj.returnedDate;
                tmp.status = obj.status;
                tmp.books = obj.books;
                message = "Order (" + obj.id + ") has been updated successfully.";
                this.show(this.get(tmp.id), message);
                return;
            }

            Console.Clear();
            Console.WriteLine("Order ID need to be updated:");
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
                    obj = (Order)this.get(input);
                    if (!Util.isSet(obj))
                        Console.WriteLine("Order ID (" + input + ") does not exist." +
                            " Please try again or input \"C\" key to cancel.");
                }
            } while (Util.isSet(input) && obj == null);

            message = "Current Order (" + obj.id + ") information.";
            this.show(obj, message);

            Console.WriteLine("New Member ID:");
            Console.WriteLine("(Input a new one or press \"Enter\" to skip this step.)");
            bool rs = false;
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
                    Member mem = (Member)MemberController.find(input);
                    rs = Util.isSet(mem);
                    if (rs == false)
                        Console.WriteLine("Member ID (" + input + ") does not existed." +
                            " Please try again or input \"C\" key to cancel.");
                    else obj.member = mem;
                }
            } while (Util.isSet(input) && rs == false);

            Console.WriteLine("Ordered Date:");
            Console.WriteLine("(Input a new one or press \"Enter\" to skip this step.)");
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
                    else obj.orderedDate = input;
                }
            } while (Util.isSet(input) && rs == false);

            Console.WriteLine("Returned Date:");
            Console.WriteLine("(Input a new one or press \"Enter\" to skip this step.)");
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
                    else obj.returnedDate = input;
                }
            } while (Util.isSet(input) && rs == false);

            Console.WriteLine("New Status:");
            Console.WriteLine("(Input a new one or press \"Enter\" to skip this step.)");
            input = Console.ReadLine();
            obj.status = (Util.isSet(input) && input.Equals("0") 
                && input.Equals("FALSE") && input.Equals("False") && input.Equals("false"))
                        ? false : true;

            Console.WriteLine("Books list:");
            Console.WriteLine("(Input a new one or press \"Enter\" to skip this step.)");
            List<Book> books = new List<Book>();
            do
            {
                Console.WriteLine("Book ID:");
                input = Console.ReadLine();

                if (Util.isCancel(input))
                {
                    Console.WriteLine("Updating process has been cancelled.");
                    return;
                }
                else if (Util.isSet(input))
                {
                    Book bk = (Book)BookController.find(input);
                    rs = Util.isSet(bk);
                    if (rs == false)
                        Console.WriteLine("Book ID (" + input + ") does not existed.");
                    else books.Add(bk);
                    Console.WriteLine("Do you want to continue? (Y/N)");
                    input = Console.ReadLine();
                }
            } while (Util.isSet(input) && (!input.Equals("N") && !input.Equals("n")));

            if(Util.isSet(books) && books.Count > 0) obj.books = books;

            message = "Order (" + obj.id + ") has been updated successfully.";
            this.show(this.get(obj.id), message);
            return;
        }

        public void delete(object o)
        {
            string message = null;
            Order obj = null;

            if (Util.isSet(o))
            {
                obj = (Order)o;
                Order tmp = (Order)this.get(obj.id);
                if (!Util.isSet(tmp))
                {
                    Console.WriteLine("Order ID (" + obj.id + ") does not exist.");
                    return;
                }

                this.list.Remove(obj);
                message = "Order (" + obj.id + ") has been deleted successfully.";
                this.showMore(this.getMore("ALL"), message);
                return;
            }

            Console.Clear();
            Console.WriteLine("Order ID need to be deleted:");
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
                    obj = (Order)this.get(input);
                    if (!Util.isSet(obj))
                        Console.WriteLine("Order ID (" + input + ") does not exist." +
                            " Please try again or input \"C\" key to cancel.");
                }
            } while (!Util.isSet(input));

            message = "Current Order (" + obj.id + ") information.";
            this.show(obj, message);

            Console.WriteLine("Are you sure to delete? (Y/N)");
            input = Console.ReadLine();
            if (Util.isConfirmed(input))
            {
                this.list.Remove(obj);
                message = "Order (" + obj.id + ") has been deleted successfully.";
                this.showMore(this.getMore("ALL"), message);
            }
            else Console.WriteLine("Deleting process has been denined.");
        }

    }
}
