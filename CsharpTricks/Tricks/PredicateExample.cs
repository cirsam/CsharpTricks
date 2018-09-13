using System;
namespace CsharpTricks.Tricks
{
    public class PredicateExample
    {
        /*
         * Predicates are for comparing values
         */

        public PredicateExample()
        {
            Predicate<int> predicate = r => r == 6;

            if (predicate(6))
            {
                Console.WriteLine("Predicate: This is it "+ predicate(6));
            }

            Predicate<int> predicates = r => r == 7;

            if (!predicates(6))
            {
                Console.WriteLine("Predicate: This is it " + predicates(6)+"\n");
            }
        }
    }
}
