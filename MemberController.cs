using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    internal class MemberController : ControllerInterface
    {
        public static List<Member> list = new List<Member>();

        public MemberController()
        {

        }

        public void show(object o, string message)
        {
            Console.Clear();
            if (Util.isSet(message)) Console.WriteLine(message);
            if (!Util.isSet(o)) return;
            Member obj = (Member)o;
            Console.WriteLine(" ");
            Console.WriteLine("=======================");
            Console.WriteLine(" ");
            Console.WriteLine("Member ID: " + obj.getId());
            Console.WriteLine("Member Name: " + obj.getName());
            Console.WriteLine("Date of Birth: " + obj.getDoB());
            Console.WriteLine("Gender: " + obj.getGender());
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
            Console.WriteLine("| Member ID | Member Name | Date of Birth | Gender |");
            if (!Util.isSet(objs)) Console.WriteLine("No data found.");
            else
            {
                foreach (Member obj in objs)
                {
                    Console.WriteLine("| " + obj.getId() + " | "
                        + obj.getName() + " | "
                        + obj.getDoB() + " | "
                        + obj.getGender() + " |");
                }
            }
            Console.WriteLine(" ");
            Console.WriteLine("=======================");
        }

        public object get(string id)
        {
            if (!Util.isSet(id) || !Util.isSet(list)) return null;

            foreach (Member obj in list)
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
            if (!Util.isSet(id) || !Util.isSet(list)) return new Member();

            foreach (Member obj in list)
            {
                if (Util.isSet(obj.getId()) && obj.getId().Equals(id))
                {
                    return obj;
                }
            }

            return new Member();
        }

        public object[] getMore(string key)
        {
            if (list == null) list = new List<Member>();
            if (!Util.isSet(key) || Util.isAll(key))
            {
                return list.ToArray();
            }
            else
            {
                List<Member> objs = new List<Member>();

                foreach (Member obj in list)
                {
                    if (Util.isSet(obj) && (obj.getId().Contains(key)
                        || obj.getName().Contains(key)
                        || obj.getDoB().Contains(key)
                        || obj.getGender().Contains(key)))
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
            Member obj = null;

            if (Util.isSet(o))
            {
                obj = (Member)o;
                list.Add(obj);
                message = "Member (" + obj.getId() + ") has been added successfully.";
                this.show(this.get(obj.getId()), message);
                return;
            }

            Console.Clear();
            obj = new Member();

            Console.WriteLine("Member ID:");
            bool rs = false;
            string input = null;
            do
            {
                input = Console.ReadLine();
                if (Util.isSet(this.get(input)))
                {
                    Console.WriteLine("Member ID (" + input + ") is already existed." +
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

            Console.WriteLine("Member Name:");
            rs = false;
            input = null;
            do
            {
                input = Console.ReadLine();
                if (!Util.isSet(input))
                    Console.WriteLine("Name cannot be blank. Please try again or input \"C\" key to cancel.");
                else if (Util.isCancel(input))
                {
                    Console.WriteLine("Adding new process has been cancelled.");
                    return;
                }
                else obj.setName(input);
            } while (!Util.isSet(input));

            
            
            Console.WriteLine("Date of Birth:");
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

            Console.WriteLine("Gender:");
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
                    rs = Util.isGender(input);
                    if (rs == false)
                        Console.WriteLine("Incorrect Gender. Please try again. Please try again or input \"C\" key to cancel.");
                    else obj.setGender(input);
                }
            } while (Util.isSet(input) && rs == false);

            list.Add(obj);
            message = "Member (" + obj.getId() + ") has been added successfully.";
            this.show(this.get(obj.getId()), message);
        }

        public void update(object o)
        {
            string message = null;
            Member obj = null;

            if(Util.isSet(o))
            {
                obj = (Member)o;
                Member tmp = (Member) this.get(obj.getId());
                if(!Util.isSet(tmp))
                {
                    Console.WriteLine("Member ID (" + obj.getId() + ") does not exist.");
                    return;
                }

                tmp.setName(obj.getName());
                tmp.setDoB(obj.getDoB());
                tmp.setGender(obj.getGender());
                message = "Member (" + obj.getId() + ") has been updated successfully.";
                this.show(this.get(tmp.getId()), message);
                return;
            }

            Console.Clear();
            Console.WriteLine("Member ID need to be updated:");
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
                    obj = (Member)this.get(input);
                    if (!Util.isSet(obj))
                        Console.WriteLine("Member ID (" + input + ") does not exist." +
                            " Please try again or input \"C\" key to cancel.");
                }
            } while (Util.isSet(input) && obj == null);

            message = "Current Member (" + obj.getId() + ") information.";
            this.show(obj, message);

            Console.WriteLine("New Member Name:");
            Console.WriteLine("(Input a new one or press \"Enter\" to skip this step.)");
            input = Console.ReadLine();
            if (Util.isSet(input)) obj.setName(input);

            Console.WriteLine("New Date of Birth:");
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

            Console.WriteLine("New Gender:");
            Console.WriteLine("(Please input a new one or press \"Enter\" to skip this step.)");
            rs = false;
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
                    rs = Util.isGender(input);
                    if (rs == false)
                        Console.WriteLine("Incorrect Gender." +
                            " Please try again or press \"Enter\" to skip this step or input \"C\" key to cancel.");
                    else obj.setGender(input);
                }
            } while (Util.isSet(input) && rs == false);

            message = "Member (" + obj.getId() + ") has been updated successfully.";
            this.show(this.get(obj.getId()), message);
            return;
        }

        public void delete(object o)
        {
            string message = null;
            Member obj = null;

            if (Util.isSet(o))
            {
                obj = (Member)o;
                Member tmp = (Member)this.get(obj.getId());
                if (!Util.isSet(tmp))
                {
                    Console.WriteLine("Member ID (" + obj.getId() + ") does not exist.");
                    return;
                }

                list.Remove(obj);
                message = "Member (" + obj.getId() + ") has been deleted successfully.";
                this.showMore(this.getMore("ALL"), message);
                return;
            }

            Console.Clear();
            Console.WriteLine("Member ID need to be deleted:");
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
                    obj = (Member)this.get(input);
                    if (!Util.isSet(obj))
                        Console.WriteLine("Member ID (" + input + ") does not exist." +
                            " Please try again or input \"C\" key to cancel.");
                }
            } while (!Util.isSet(input));

            message = "Current Member (" + obj.getId() + ") information.";
            this.show(obj, message);

            Console.WriteLine("Are you sure to delete? (Y/N)");
            input = Console.ReadLine();
            if (Util.isConfirmed(input))
            {
                list.Remove(obj);
                message = "Student (" + obj.getId() + ") has been deleted successfully.";
                this.showMore(this.getMore("ALL"), message);
            }
            else Console.WriteLine("Deleting process has been denined.");
        }

    }
}
