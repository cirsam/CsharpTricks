using System;
namespace CsharpTricks.Tricks
{
    public class ParamsKeywordExamples
    {
        /*Params keyword is used to send a list of variables to a method. Additional variables can not follow the params keyword.
         * eg you can not have MethodName(params object[] list, int y) but you can have MethodName(int y,params object[] list)
         */

        public ParamsKeywordExamples()
        {
            //Use the params,in and out keyword to pass and arry to a method
            string somestr = "Userid 30 is called Samuel Antwi and has a phone number (937)-536-9660";
            object[] obj = somestr.Split(' ');
            int age = 50;
            string[] info;
            GetUserInfor(age, out info, obj);
            Console.WriteLine($"Params: User ID = {info.GetValue(0)}, Name = {info.GetValue(1)} , phone = {info.GetValue(2)}");

            //Pass in a list of integers use ref keyword to get the total
            int[] numbers = {1,2,3,4,5,6,7,8,9,10};
            int total = 0;
            GetSum(out total, numbers);
            Console.WriteLine("Params: The total is = "+total);
            //pass a list of integers
            int totals = 0;
            GetSum(out totals, 1,2,3,4);
            Console.WriteLine("Params: The total is = " + totals);
            //pass a list of integers
            string result = GetNewString("Your name", "might be", "John", "Does");
            Console.WriteLine("Params: "+result+"\n");
        }


        private static void GetUserInfor(int age, out string[] info, params object[] obj)
        {
            info = new string[3];
         

            for (int i = 0; i < obj.Length; i++)// the in keyword is used here
            {
                if (i == 1)
                {
                    info[0] = obj[1].ToString();
                }

                if (i == 4 || i==5)
                {
                    info[1] = obj[4]+" "+obj[5];
                }

                if(i==11)
                {
                    info[2] = obj[11].ToString();
                }
            }
        }

        private static void GetSum(out int total, params int[] numbers)
        {
            total = 0;

            foreach(int number in numbers)
            {
                total += number;
            }
        }

        private static string GetNewString(params string[] strings)
        {
            string newstring = "";
            foreach(string part in strings)
            {
                newstring += part+" ";
            }

            return newstring;
        }

    }
}
