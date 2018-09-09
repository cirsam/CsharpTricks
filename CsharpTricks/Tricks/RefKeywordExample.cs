using System;
namespace CsharpTricks.Tricks
{
    public class RefKeywordExample : CalculateMySquareArea
    {
        /*Ref and out key words solves a similar issue as tuples just that data can be returned without the return keyword.
         * The ref keyword is used to pass data into a mothod by reference and modify the data and return the data.
         *The arguement has to be initialized and assigned outside the method before passing it into the method but the initialized
         *value is changed when the reference pointer in memory is assigned a new value.
         *Unlike the out keyword the arguement may not be initialized instead the parameter may need to be intialized inside the method
        */

        public RefKeywordExample()
        {
            //Pass string by reference
            string somestring = "This is some string";
            ChangeString(ref somestring);
            Console.WriteLine("Ref: The referenced value of somestring should be New String = " + somestring);

            //Pass int by reference
            int someint = 5;
            ChangeInt(ref someint);
            Console.WriteLine("Ref: The referenced value of someint should be 25 = " + someint);

            //Calculate the area of a rectangle and get the area by reference
            int length = 5;
            int width = 6;
            int area = 0;
            CalculateRectangleArea(ref length, ref width, ref area);
            Console.WriteLine("Ref: The referenced area value of rectangel = " + area);

            //Modify the width and length in a class by reference
            CalculateMySquareArea myinfo = new CalculateMySquareArea("Samuel Antwi",3,4);//Get width and lenght
            Console.WriteLine("Ref: My area value of square = " + myinfo.Areasqr);
            //Pass the reference of length and with above and the reference of the class CalcaulateMySquareArea
            ChangeObjectReference(ref myinfo, width, length);
            Console.WriteLine("Ref: My reference value of width = " + myinfo.Width);

            //Get values from a string when passed into a method using the out approach
            string somestr = "Userid 30 is called Samuel Antwi and has a phone number (937)-536-9660";
            string username = "";
            string phone = "";
            int userid = 0;
            GetOutUserData(somestr, ref username, ref phone, ref userid);
            Console.WriteLine("Ref: Your name is {0} your number is {1} your userid is {2}",username, phone, userid.ToString());

            //Method Overload
            (string stringItem, int intItem) values = (stringItem: "10", intItem: 10);
            MethodOverload(ref values.stringItem);
            MethodOverload(ref values.intItem);
            Console.WriteLine($"Ref: Method overload string and int {values.stringItem}");
            Console.WriteLine($"Ref: Method overload string and int {values.intItem}");

            //Method Over ride with out
            int difference = 0;
            Subtract(15,10,ref difference);
            string concats = "";
            Subtract("Samuel", "Antwi", ref concats);
            Console.WriteLine($"Ref: Method override the substract using the Ref keyword {difference} and name {concats} \n");

        }

        static void Subtract(string name1,string name2,ref string concats)
        {
            concats = name1+" "+name2;
        }

        private void GetOutUserData(string somestr, ref string username, ref string phone, ref int userid)
        {
            string[] myarray = new string[3];
            string[] stringarray = somestr.Split(' ', '(', ')');
            myarray[0] = stringarray[1];
            myarray[1] = stringarray[4] + " " + stringarray[5];
            myarray[2] = "(" + stringarray[12] + ")" + stringarray[13];

            userid = Convert.ToInt32(myarray[0]);
            username = myarray[1];
            phone = myarray[2];
        }

        static void ChangeString(ref string somestring)
        {
            somestring = "New String";
        }

        static void ChangeInt(ref int someint)
        {
            someint = 25;
        }

        static void CalculateRectangleArea(ref int lenght, ref int width, ref int area)
        {
            area = lenght * width;
        }

        static void ChangeObjectReference(ref CalculateMySquareArea areaclass, int width, int length)
        {
            areaclass = new CalculateMySquareArea("Root Antwi", width, length);
            areaclass.Width = 57;
            int area = areaclass.Areasqr;
        }

        private static void MethodOverload(ref int num)
        {
            num = 300;
        }

        private static void MethodOverload(ref string text)
        {
            text = "STRING FROM METHOD";
        }
    }

    public class CalculateMySquareArea
    {
        public string Name { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public int Areasqr { get; }

        public CalculateMySquareArea(string name="", int width=0, int length=0)
        {
            Name = name;
            Width = width;
            Length = length;
            Areasqr = Area(width, length);
        }

        private int Area(int width, int lenght)
        {
            return width * lenght;
        }

        public virtual void Subtract(int number1,int number2, ref int difference)
        {
            difference = number1 - number2;
        }
    }
}
