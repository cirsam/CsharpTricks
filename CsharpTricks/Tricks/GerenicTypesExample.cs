using System;
using System.Collections.Generic;

namespace CsharpTricks.Tricks
{
    public class GerenicTypesExample
    {
        private static IList<Books> _books = new List<Books>();

        public GerenicTypesExample()
        {
            CreateBooks();

            //Generic method
            int the_age = 12;
            Console.WriteLine($"Generic: Method overload with Generic type int {TakeStringAndInt<int>(the_age)}");

            string name = "Samuel Antwi";
            int age = 12;
            Console.WriteLine($"Generic: Method overload with Generic type string and int {TakeStringAndInt<string, int>(name, age)}");

            //string name = "Samuel Antwi";
            //int age = 12;
            IEnumerable<Books> results = TakeStringAndInt(_books);
            foreach(Books book in results )
            {
                Console.WriteLine($"Generic: List of objects Price = {book.Price} Title={book.Title}");
            }
        }

        static IList<M> TakeStringAndInt<M>(IList<M> somelist)
        {
            IList<M> newlist = new List<M>();

            foreach(M m in somelist)
            {
                dynamic myobj = m;

                if(myobj.Price > 50.90)
                {
                    newlist.Add(myobj);
                }
            }

            return newlist;
        }

        static I TakeStringAndInt<I>(I age)
        {
            return age;
        }

        internal static S TakeStringAndInt<S,I>(S name, I age)
        {
            return name;
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
