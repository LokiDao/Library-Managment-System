using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Library_Management_System
{
    internal static class Util
    {
        public static bool isMatch(String input, String regex)
        {
            if (!isSet(input) || !isSet(regex)) return false;

            // Class Regex Represents an
            // immutable regular expression.
            //   Format                Pattern
            // xxxxxxxxxx           ^[0 - 9]{ 10}$
            // +xx xx xxxxxxxx     ^\+[0 - 9]{ 2}\s +[0 - 9]{ 2}\s +[0 - 9]{ 8}$
            Regex re = new Regex(regex);

            // The IsMatch method is used to validate
            // a string or to ensure that a string
            // conforms to a particular pattern.
            return re.IsMatch(input);
        }

        public static bool isSet(object input)
        {
            try
            {
                string tmp = (string)input;
                if (tmp != null && !tmp.Equals("")) return true;
            }
            catch (Exception e1)
            {
                try
                {
                    Array tmp = (Array)input;
                    if (tmp != null && tmp.Length > 0) return true;
                }
                catch (Exception e2)
                {
                    if (input != null) return true;
                }
            }
            return false;
        }

        public static bool isCancel(string input)
        {
            if (isSet(input) && (input.Equals("C") || input.Equals("c"))) return true;
            return false;
        }

        public static bool isConfirmed(string input)
        {
            if (isSet(input) && (input.Equals("Y") || input.Equals("y"))) return true;
            return false;
        }

        public static bool isDenined(string input)
        {
            if (isSet(input) && (input.Equals("N") || input.Equals("n"))) return true;
            return false;
        }

        public static bool isAll(string input)
        {
            if (isSet(input) && (input.Equals("ALL") || input.Equals("All") || input.Equals("all") 
                || input.Equals("A") || input.Equals("a"))) 
                return true;
            return false;
        }

        public static bool isGender(string input)
        {
            if (!isSet(input) || input.Equals("F") || input.Equals("M") || input.Equals("O")) return true;
            return false;
        }

        public static bool isNumber(string input)
        {
            string regex = @"(^[0-9]{1,}$)";
            return isMatch(input, regex);
        }

        public static bool isDate(string input)
        {
            string regex = @"(^[0-9]{1,2})/([0-9]{1,2})/([0-9]{2,4}$)";
            return isMatch(input, regex);
        }

        public static bool isPhoneNUmber(string input)
        {
            bool rs = false;
            string regex = @"^[0-9]{10}$";
            rs = isMatch(input, regex);
            if (rs == true) return rs;

            regex = @"^\+[0 - 9]{ 2}\s +[0 - 9]{ 2}\s +[0 - 9]{ 8}$";
            rs = isMatch(input, regex);
            if (rs == true) return rs;

            regex = @"^[0 - 9]{ 3} -[0 - 9]{ 4}-[0 - 9]{ 4}$";
            rs = isMatch(input, regex);
            if (rs == true) return rs;

            return rs;
        }

        public static bool isEmail(string input)
        {
            string regex = @"\A(?:[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?\.)+[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?)\Z";
            return isMatch(input, regex);
        }
    }
}
