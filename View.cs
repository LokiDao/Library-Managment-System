using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    internal class View
    {
        public MemberController memContr;
        public BookController bkContr;
        public OrderController ordContr;

        public View()
        {
            this.memContr = new MemberController();
            this.bkContr = new BookController();
            this.ordContr = new OrderController();
        }

        public void mainMenu()
        {
            string opt = null;
            do
            {
                Console.Clear();
                Console.WriteLine("=======================");
                Console.WriteLine(" ");
                Console.WriteLine("1.   Manage Orers");
                Console.WriteLine("2.   Manage Books");
                Console.WriteLine("3.   Manage Members");
                Console.WriteLine("4.   Exit");
                Console.WriteLine(" ");
                Console.WriteLine("=======================");
                Console.WriteLine(" ");
                Console.WriteLine("Please choose:");

                opt = Console.ReadLine();

                switch (opt)
                {
                    case "1":
                        this.orderMenu();
                        break;
                    case "2":
                        this.bookMenu();
                        break;
                    case "3":
                        this.memberMenu(); 
                        break;
                    case "4":
                        Console.WriteLine("Program has been stopped.");
                        break;
                    default:
                        Console.WriteLine("Incorrect option. Press any key to try again.");
                        Console.ReadLine();
                        break;
                }
            } while (opt != null && !opt.Equals("4"));
        }

        public void memberMenu()
        {
            string opt = null;
            do
            {
                Console.Clear();
                Console.WriteLine("=======================");
                Console.WriteLine(" ");
                Console.WriteLine("1.	Add new member");
                Console.WriteLine("2.	View all members");
                Console.WriteLine("3.	Search members");
                Console.WriteLine("4.	Delete members");
                Console.WriteLine("5.	Update members");
                Console.WriteLine("6.	Back to main menu");
                Console.WriteLine(" ");
                Console.WriteLine("=======================");
                Console.WriteLine(" ");
                Console.WriteLine("Please choose:");

                opt = Console.ReadLine();

                switch (opt)
                {
                    case "1":
                        this.memContr.add(null);
                        Console.WriteLine("Press any key to back to Member Management menu.");
                        Console.ReadLine();
                        break;
                    case "2":
                        this.memContr.showMore(this.memContr.getMore("ALL"), null);
                        Console.WriteLine("Press any key to back to Member Management menu.");
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Input searching key:");
                        string key = Console.ReadLine();

                        this.memContr.showMore(this.memContr.getMore(key), null);
                        Console.WriteLine("Press any key to back to Member Management menu.");
                        Console.ReadLine();
                        break;
                    case "4":
                        this.memContr.delete(null);
                        Console.WriteLine("Press any key to back to Member Management menu.");
                        Console.ReadLine();
                        break;
                    case "5":
                        this.memContr.update(null);
                        Console.WriteLine("Press any key to back to Member Management menu.");
                        Console.ReadLine();
                        break;
                    case "6":
                        break;
                    default:
                        Console.WriteLine("Incorrect option. Press any key to try again.");
                        Console.ReadLine();
                        break;
                }
            } while (opt != null && !opt.Equals("6"));
        }

        public void bookMenu()
        {
            string opt = null;
            do
            {
                Console.Clear();
                Console.WriteLine("=======================");
                Console.WriteLine(" ");
                Console.WriteLine("1.	Add new book");
                Console.WriteLine("2.	View all books");
                Console.WriteLine("3.	Search books");
                Console.WriteLine("4.	Delete book");
                Console.WriteLine("5.	Update book");
                Console.WriteLine("6.	Back to main menu");
                Console.WriteLine(" ");
                Console.WriteLine("=======================");
                Console.WriteLine(" ");
                Console.WriteLine("Please choose:");

                opt = Console.ReadLine();

                switch (opt)
                {
                    case "1":
                        this.bkContr.add(null);
                        Console.WriteLine("Press any key to back to Book Management menu.");
                        Console.ReadLine();
                        break;
                    case "2":
                        this.bkContr.showMore(this.bkContr.getMore("ALL"), null);
                        Console.WriteLine("Press any key to back to Book Management menu.");
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Input searching key:");
                        string key = Console.ReadLine();

                        this.bkContr.showMore(this.bkContr.getMore(key), null);
                        Console.WriteLine("Press any key to back to Book Management menu.");
                        Console.ReadLine();
                        break;
                    case "4":
                        this.bkContr.delete(null);
                        Console.WriteLine("Press any key to back to Book Management menu.");
                        Console.ReadLine();
                        break;
                    case "5":
                        this.bkContr.update(null);
                        Console.WriteLine("Press any key to back to Book Management menu.");
                        Console.ReadLine();
                        break;
                    case "6":
                        break;
                    default:
                        Console.WriteLine("Incorrect option. Press any key to try again.");
                        Console.ReadLine();
                        break;
                }
            } while (opt != null && !opt.Equals("6"));
        }

        public void orderMenu()
        {
            string opt = null;
            do
            {
                Console.Clear();
                Console.WriteLine("=======================");
                Console.WriteLine(" ");
                Console.WriteLine("1.	Add new order");
                Console.WriteLine("2.	View all orders");
                Console.WriteLine("3.	Search orders");
                Console.WriteLine("4.	Delete orders");
                Console.WriteLine("5.	Update orders");
                Console.WriteLine("6.	Back to main menu");
                Console.WriteLine(" ");
                Console.WriteLine("=======================");
                Console.WriteLine(" ");
                Console.WriteLine("Please choose:");

                opt = Console.ReadLine();

                switch (opt)
                {
                    case "1":
                        this.ordContr.add(null);
                        Console.WriteLine("Press any key to back to Order Management menu.");
                        Console.ReadLine();
                        break;
                    case "2":
                        this.ordContr.showMore(this.ordContr.getMore("ALL"), null);
                        Console.WriteLine("Press any key to back to Order Management menu.");
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Input searching key:");
                        string key = Console.ReadLine();

                        this.ordContr.showMore(this.ordContr.getMore(key), null);
                        Console.WriteLine("Press any key to back to Order Management menu.");
                        Console.ReadLine();
                        break;
                    case "4":
                        this.ordContr.delete(null);
                        Console.WriteLine("Press any key to back to Order Management menu.");
                        Console.ReadLine();
                        break;
                    case "5":
                        this.ordContr.update(null);
                        Console.WriteLine("Press any key to back to Order Management menu.");
                        Console.ReadLine();
                        break;
                    case "6":
                        break;
                    default:
                        Console.WriteLine("Incorrect option. Press any key to try again.");
                        Console.ReadLine();
                        break;
                }
            } while (opt != null && !opt.Equals("6"));
        }
    }
}
