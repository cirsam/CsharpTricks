using System;
using System.Collections.Generic;
using System.Linq;

namespace CsharpTricks.Tricks
{
    public class TuplesExamples
    {
        public TuplesExamples()
        {
            //unmaed tuples
            var some_unamed = ("Samuel",24);
            (string, int) firstset = ("Sam",1);
            Console.WriteLine("My unnamed tuples are item1 = {0} and item2 = {1}",some_unamed.Item1,some_unamed.Item2);
            Console.WriteLine("My unnamed tuples are item1 = {0} and item2 = {1}", firstset.Item1, firstset.Item2);
            some_unamed = firstset;
            Console.WriteLine("Assign firstset to some_unnamed which is {0}", some_unamed);
            Console.WriteLine(" ");



            //Tuple Projections and named Tuples
            string firstname = "Samuel";
            string lastname = "Antwi";
            DateTime? datofbirth = Convert.ToDateTime("04-09-2018");
            var projection = (name:firstname+lastname, birthday:datofbirth);
            (string name,long age) projection2 = (name: "John Mark", age: 3200);
            (string name,int age) projection3 = (name: "John Williams", age: 300);

            projection2 = projection3;//it can convert int to long but not long to int. This projection3 = projection2 will not work
            Console.WriteLine($"Tuples: My name is {projection3.name} and my age is ={projection3.age}");
            Console.WriteLine($"Tuples: Projection2 takes projection3 data:My name is {projection2.name} and my age is ={projection2.age}");
            Console.WriteLine($"Tuples: My name is {projection.name} and my date of bith is ={projection.birthday}");
            Console.WriteLine(" ");


            //Tuples as variables
            (string firstname,string lastname,string phone, int age) info = (firstname: "Samuel",lastname:"Antwi",phone:"(937)-536-9660",age:20);//named tuple
            string buildstring = string.Format("Tuples: My name is {0} {1} and my phone number is {2} and not my real age is {3}", info.firstname, info.lastname, info.phone,info.age);
            Console.WriteLine(buildstring);
            (int one, double two) numbers = (1,2);
            Add(numbers.one, numbers.two);// Add numbers from tuples
            Console.WriteLine(" ");
            

            //tuples as methods
            var tuple = (age:5, score:2, name:"Mike");
            (int age,string name) valuesFun = GetDataFromTuples(tuple);
            Console.WriteLine("Tuples: Values returned are age={0} and name= {1}", valuesFun.age, valuesFun.name);
            int[] sequence = new int [5];
            sequence[0] = 1;
            sequence[1] = 2;
            sequence[2] = 3;
            sequence[3] = 4;
            sequence[4] = 5;

            var resutl = GetSequenceAndReturnTuple(sequence);
            Console.WriteLine($"Tuple: The first number is {resutl.firstbumber} and the sum of the numbers are {resutl.sum}");

            int[] sequences = new int[] { 6, 7, 8, 9, 10 };
            var resutls = GetSequenceAndReturnTuple(sequences);
            Console.WriteLine($"Tuple: The first number is {resutls.firstbumber} and the sum of the numbers are {resutls.sum}");
            Console.WriteLine(" ");


            //using lambda expressions
            List<(string,int)>  NewObject() => new List<(string, int)>() { ("Samuel", 4) , ("Mike", 4) , ("Rick", 4) };
            var data = NewObject();
            var name_item_name = data.FirstOrDefault().Item1;
            Console.WriteLine("Tuple: The object values for first item name = "+name_item_name);

            //using real tubles and Object
            IList<Tuple<string, int>> TupleObject() => new List<Tuple<string, int>>() { new Tuple<string, int>("Samuel", 4), new Tuple<string, int>("Mike", 4) , new Tuple<string, int>("Rick", 4) };
            int get_second_item_age = TupleObject().Where(x=>x.Item1=="Mike").FirstOrDefault().Item2;
            Console.WriteLine("Tuple: The object values for the second item age in the IList = "+get_second_item_age);
            var tuple_first_item_name = GetSequenceAndReturnTuples(TupleObject());
            Console.WriteLine("Tuple: The object values for the second item age IList of Tuple = " + tuple_first_item_name.age);
            Console.WriteLine(" ");
            sequence.ToList().ForEach( p => Add(p,p));

            //Using create Tuple
            Tuple<int,string,bool> GetItems = new Tuple<int,string,bool>(2,"sam",true);
            Console.WriteLine("Tuple: Name = "+GetItems.Item2);
            Tuple<int, string, bool> GetItem = Tuple.Create(2,"Sam",false);
            Console.WriteLine("Tuple: Age = " + GetItem.Item1);
            Tuple<int, string, bool,Tuple<int, string, bool>> GetItemsn = new Tuple<int, string, bool, Tuple<int, string, bool>>(2, "Tom", true,GetItem);
            Console.WriteLine("Tuple: Get Name of Nested Tuple= "+GetItemsn.Item4.Item2+"\n");
        }



        static void Add(int one, double two)
        {
            int sum = one + (int)two;
            Console.WriteLine($"Tuple: Add one and two = {sum}");
        }

        private static (int sum,int firstbumber) GetSequenceAndReturnTuple(int[] sequence)
        {
            int total = 0;
            int firstnumber = sequence[0];

            foreach (int number in sequence.ToList())
            {
                total += number;
            }

            var tuple = (total, firstnumber);

            return tuple;
        }

        private static (int score,string name) GetDataFromTuples((int,int, string) tuple)
        {
            return (tuple.Item1,tuple.Item3);
        }


        private static (string name, int age) GetSequenceAndReturnTuples(IList<Tuple<string, int>> sequence)
        {
            var result = sequence.FirstOrDefault();

            var tuple = (result.Item1, result.Item2);

            return tuple;
        }
    }
}
