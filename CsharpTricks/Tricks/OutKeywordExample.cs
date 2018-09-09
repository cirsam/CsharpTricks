using System;
namespace CsharpTricks.Tricks
{
    public class OutKeywordExample: BaseClass
    {
        public OutKeywordExample()
        {
            /*The out keyword work is just like the ref keyword except that the out keyword
             * does not require assigning the out arguement out side the method instead it is done inside the method.
             * Also the out keyword does not modify the out argument it just strips off the value if it is assigned to a value
             * when passed into the method
             */

            //Use out as boolean
            string alphabets = "Abced";
            bool isNumber = Int32.TryParse(alphabets,out int value);
            Console.WriteLine("Out: This will return false ="+isNumber);
           
            //use it in conditional statement
            string numb = "798667";
            bool isStringNumbers = int.TryParse(numb, out int response);
            if (isStringNumbers)
            {
                Console.WriteLine($"Out: The condition is True = {isStringNumbers} and the value is int = {response}");
            }

            //Convert from string to number
            int results = 0;
            string text = "2345";
            ConvertToInt(text, out results);
            Console.WriteLine("Out: The string 2345 is now int = "+results);

            string somenewstring = "543";
            ConvertToInt(somenewstring, out results);
            Console.WriteLine("Out: The string 543 is now int = " + results);

            //Get values from a string when passed into a method using the out approach
            string somestr = "Userid 30 is called Samuel Antwi and has a phone number (937)-536-9660";
            string username;
            string phone;
            int userid;
            GetOutUserData(somestr, out username, out phone, out userid);
            Console.WriteLine("Out: Your name is {0} your number is {1} your userid is {2}",username, phone, userid.ToString());

            //Method overload on Out Keyword
            (string stringItem,int intItem) values = ( stringItem:"10", intItem:10 );
            MethodOverload( out values.stringItem);
            MethodOverload(out values.intItem);
            Console.WriteLine($"Out: Method overload string and int {values.stringItem}");
            Console.WriteLine($"Out: Method overload string and int {values.intItem}");

            //Method Over ride with out
            int difference = 0;
            Subtract(15, 10, out difference);
            string concats = "";
            Subtract("Samuel", "Antwi", out concats);
            Console.WriteLine($"Out: Method override the substract using the Out keyword {difference} and name {concats} \n");
        }

        static void Subtract(string name1, string name2, out string concats)
        {
            concats = name1 + " " + name2;
        }

        private void GetOutUserData(string somestr, out string username, out string phone, out int userid)
        {
            string[] myarray = new string[3];
            string[] stringarray = somestr.Split(' ', '(', ')');
            myarray[0] = stringarray[1];
            myarray[1] = stringarray[4] + " " + stringarray[5];
            myarray[2] = "("+stringarray[12]+")"+ stringarray[13];

            userid = Convert.ToInt32(myarray[0]);
            username = myarray[1];
            phone = myarray[2];
        }

        private static void ConvertToInt(string text,out int results)
        {
            results = 0;

            try
            {
                if (int.TryParse(text, out int result))
                {
                    results = result;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }



        private static void MethodOverload(out int num)
        {
            num = 300;
        }

        private static void MethodOverload(out string text)
        {
            text = "STRING FROM METHOD";
        }
    }

    public class BaseClass
    {
        public virtual void Subtract(int number1, int number2, out int difference)
        {
            difference = number1 - number2;
        }
    }
}
