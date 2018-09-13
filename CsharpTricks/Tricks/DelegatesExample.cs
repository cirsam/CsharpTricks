using System;
using System.Collections.Generic;
using System.Linq;

namespace CsharpTricks.Tricks
{
    delegate string SimpleDelegate(string mystring);
    delegate void SomeDelegate(string mystring,ref string results);
    delegate bool SomePredicateDelegate(Books book);
    delegate IList<Books> SomeObjectDelegate(IList<Books> books, SomePredicateDelegate predicate);
    delegate bool ReturnBooleanDelegate(int i);
    delegate bool ReturnBoolString(string somestring);

    public class DelegatesExample
    {
        private static IList<Books> _books = new List<Books>(10);

        /*
         * Delegates are pointers to a method or functions. It lets you invoke a function or chain them together.
         * 
         * You instantiate it by using the new keyword like a class. There are generic delegates like Func,Predicate and Action
         * 
         * Most important usage are call back functions
         * 
         */

        public DelegatesExample()
        {
            //Simple delegate
            SimpleDelegate simpleDelegate = new SimpleDelegate(SimpleMethod);
            string mystring = simpleDelegate("Delegate: Simple delegate");
            Console.WriteLine(mystring);

            //Basic deligate invokation with ref keyword
            SomeDelegate someDelegate = new SomeDelegate(MyDelegateMethod);
            string results = "";
            someDelegate("Delegate: The delegate is invoked", ref results);
            Console.WriteLine(results);

            //Delegate as a callback function. It can be called two ways
            CreateBooks();//Add items to the list _books object
            GetBooksSubSet subset = new GetBooksSubSet(_books);
            subset._books_subset.ToList<Books>().ForEach(x => Console.WriteLine($"Delegate: using class property {x.Title} {x.Price}"));

            //First way to call the reusable method by regular method call
            SomePredicateDelegate somePredicateDelegate = new SomePredicateDelegate(subset.IsgreaterThan);
            IList<Books> subsetofbooks = subset.ReUsableMethod(_books,somePredicateDelegate);
            subsetofbooks.ToList<Books>().ForEach(x => Console.WriteLine($"Delegate: using class method {x.Title} {x.Price}"));

            //Second way to call using delegate
            SomeObjectDelegate someObjectDelegate = new SomeObjectDelegate(subset.ReUsableMethod);
            IList<Books> subsetofbooks_delegate = someObjectDelegate(_books,somePredicateDelegate);
            subsetofbooks_delegate.ToList<Books>().ForEach(x=>Console.WriteLine($"Delegate: using class method invoked by a delegate {x.Title} {x.Price}"));

            //delegate with lambda expression
            int i = 1;
            TakeLambderExpression(i, x=>x<2);

            string somestring = "This is my string";
            TakeStringLambderExpression(somestring, a_string => a_string.Length.Equals(5));


            //First way to call the reusable method by regular method call
            SomePredicateDelegate somePredicate = new SomePredicateDelegate(subset.IsgreaterThan);
            IList<Books> subsetbooks = subset.ReUsableMethod(_books,x=>x.Price>50.90);
            subsetbooks.ToList<Books>().ForEach(x => Console.WriteLine($"Delegate: using class method and lambda expression {x.Title} {x.Price}"));

        }

        protected static string SimpleMethod(string some_string)
        {
            return some_string + " add string from Simple Method";
        }

        private static void MyDelegateMethod(string mystring, ref string results)
        {
            results = mystring + " added string from Delegate invoked";
        }

        private static void TakeLambderExpression(int i, ReturnBooleanDelegate returnBooleanDelegate)
        {
            if(returnBooleanDelegate(i))
            {
                Console.WriteLine("Delegate: Using delegate and lambda expression i is less than 2");
            }
        }

        static void TakeStringLambderExpression(string somestring, ReturnBoolString returnBoolString)
        {
            if(returnBoolString(somestring))
            {
                Console.WriteLine("Delegate: String length is equal to 5");
            }
            else
            {
                Console.WriteLine("Delegate: String length is not equal to 5");
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

    internal class GetBooksSubSet
    {
        private IList<Books> _mybooks;

        public IList<Books> _books_subset
        {
            get { return SubsetofBooks(); }
            private set {  _mybooks = value; }
        }

        public GetBooksSubSet(IList<Books> books)
        {
            _mybooks = books;
        }

        private IList<Books> SubsetofBooks()
        {
            IList<Books> _thesubset = new List<Books>();

            _mybooks.ToList<Books>().ForEach(listofbooks =>
            {
               if (listofbooks.Price > 50.90)
               {
                    if(listofbooks!=null)
                    {
                        _thesubset.Add(listofbooks);
                    }
                }
            });

            return _thesubset;
        }

        public IList<Books> ReUsableMethod(IList<Books> mybooks, SomePredicateDelegate somePredicateDelegate)
        {
            IList<Books> _thesubset = new List<Books>();

            mybooks.ToList<Books>().ForEach(listofbooks =>
            {
                //Make the method reusable bay using a call back somePredicateDelegate to check the price
                if (somePredicateDelegate(listofbooks))
                {
                     if(listofbooks!=null)
                      {
                        _thesubset.Add(listofbooks);
                      }
                }
            });

            return _thesubset;
        }

        public bool IsgreaterThan(Books books)
        {
            if (books.Price > 50.90)
            {
                return true;
            }

            return false;
        }
    }
}
