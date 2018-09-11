using System;
namespace CsharpTricks.Tricks
{
    public class ActionExample
    {
        /*
         * Actions unlike funs do not return a value. 
         */

        public ActionExample()
        {
            //Action does not return value
            Action<string> actionMessage = s => Console.WriteLine(s);
            actionMessage("Action: Actions only take in values and dont return anything.");

            //Use a method on the action delegate
            Action<string> actions = r => GetMessage(r);
            actions("Action: Print from a method.");

            //To return a value from an action use the out or ref parameter
            int numb = 0;
            Action<string> action = rs => GetMessages(rs, out numb);
            action("Print from a method. Count");
            Console.WriteLine($"Action: Count of Print from a method ={numb} \n");
        }

        static void GetMessages(string r, out int numb)
        {
            numb = 0;

            numb = r.Length;
        }

        static void GetMessage(string r)
        {
            Console.WriteLine(r);
        }
    }
}
