using System;
using System.Collections.Generic;
using System.Linq;

namespace CsharpTricks.Tricks
{
    public class DotForEachExamples
    {
        /*
        * 
        * Calss Books is inside YeildKeywordsExample
        *
        */

        static IList<Books> _books = new List<Books>(10);

        public DotForEachExamples()
        {

           CreateBooks();//Add items to the list _books object
           
            //Print each element of the list
            List<int> listints = new List<int>(3);
            listints.Add(1);
            listints.Add(2);
            listints.Add(3);
            listints.ForEach(x => Console.WriteLine("NotForEach: The count = {0}", x));

            //Change the value of the list
            IList<Books> books = new List<Books>();
            _books.ToList().ForEach(x =>
            {
                if (x.Price > 50)
                {
                    x.Price += 10;
                    books.Add(x);
                    Console.WriteLine("NotForEach: The price = {0}",x.Price);
                }
            });
            Console.WriteLine("NotForEach: Get the second price of book = {0}", books.Take(2).Last().Price);

            //Assign a value from the list to a variable
            double price = 0;
            _books.ToList().ForEach(x =>
            {
                if (x.Price.Equals(80.90))
                {
                    price = x.Price;
                }
            });

            Console.WriteLine("NotForEach: Get the price of a book = {0}", price+"\n");

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
