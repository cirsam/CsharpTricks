using System;
using System.Collections.Generic;
using System.Linq;

namespace CsharpTricks.Tricks
{
    public class FuncKeywordExample
    {
        /*
         * A Func is simpily a generic delegate
         */

        static IList<Books> _books = new List<Books>(10);

        public FuncKeywordExample()
        {
            CreateBooks();//Add items to the list _books object

            //Get the price of the first item using lambda expression
            Func<IList<Books>, int> getfirstprice = arg =>(int)arg.First().Price;
            Console.WriteLine("Func: Get the price of the first item = " + getfirstprice(_books));

            //Get the price of the last 9th item using lambda expression
            Func<IList<Books>, int> getninthprice = arg => (int)arg.Take(9).Last().Price;
            Console.WriteLine("Func: Get the price of the 9th item = " + getninthprice(_books));

            //Return the price using the func delegate in a mothod
            Func<IList<Books>,int> getsecodprice = arg => GetPrice(arg);
            int price = getsecodprice(_books);
            Console.WriteLine($"Func: Get the price of the first three first item = {price}");

            //Add the first and the last price
            Func<IList<Books>, double> sumprices = listofbooks => listofbooks.Last().Price + listofbooks.First().Price;
            Console.WriteLine($"Func: Sum of the first Price and the last price = {sumprices(_books)}");

            //Add add two numbers
            Func<int,double, double> sumnumbers = (x,y) => x + y;
            Console.WriteLine($"Func: Sum of two numbers = {sumnumbers(2,5)} \n");

            //Perform logic or predicate
            Func<int, int, bool> predicate = (x, y) => x == y;
            Console.WriteLine($"Func: Compare 2 and 5 and return boolean False = {predicate(2, 5)}");

            Func<int, string, bool> predicates = (x, y) => x < y.Length;
            Console.WriteLine($"Func: Compare 2 and 5 and return boolean True = {predicates(2, "yams")} \n");
        }

        static int GetPrice(IList<Books> arg)
        {
            int prices = 0;

            arg.ToList().ForEach(args=>
            {
                prices = (int)args.Price;
            });

            return prices;
        }

        static void CreateBooks()
        {
            _books.Add(new Books { ID = 1, Title = "Book1", Price = 10.90 });
            _books.Add(new Books { ID = 1, Title = "Book2", Price = 20.90 });
            _books.Add(new Books { ID = 1, Title = "Book3", Price = 30.90 });
            _books.Add(new Books { ID = 1, Title = "Book4", Price = 40.90 });
            _books.Add(new Books { ID = 1, Title = "Book5", Price = 50.90 });
            _books.Add(new Books { ID = 1, Title = "Book6", Price = 60.90 });
            _books.Add(new Books { ID = 1, Title = "Book7", Price = 70.90 });
            _books.Add(new Books { ID = 1, Title = "Book8", Price = 80.90 });
            _books.Add(new Books { ID = 1, Title = "Book9", Price = 90.90 });
            _books.Add(new Books { ID = 1, Title = "Book10", Price = 100.90 });
        }
    }
}
