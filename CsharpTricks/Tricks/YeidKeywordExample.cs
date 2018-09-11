using System;
using System.Collections.Generic;
using System.Linq;

namespace CsharpTricks.Tricks
{
    public class YeidKeywordExample
    {
        static IList<Books> _books = new List<Books>(10);

        public YeidKeywordExample()
        {

            CreateBooks();//Add items to the list _books object

            foreach (Books book_subset in GetPricedBoods())
            {
                Console.WriteLine("Yeild: List of books ={0}",book_subset.Title);
            }

            Console.WriteLine("\n");

        }

        static IEnumerable<Books> GetPricedBoods()
        {
            foreach (Books book in _books)
            {
                if(book.Price > 50.90)
                    yield return book;
            }
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

    class Books
    {
        public int ID
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public double Price
        {
            get;
            set;
        }             
    }
}
