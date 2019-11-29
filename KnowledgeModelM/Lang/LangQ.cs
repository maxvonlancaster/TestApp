using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using static System.Console;
using static System.DayOfWeek;
using static System.Math;

namespace KnowledgeModel.Lang
{
    public class LangQ
    {
        public void ValueAndReferenceTypes()
        {

        }

        // Properties and automatic properties
        public int Id { get; set; } // automatic property -> no additional logic of access
        public string Name { get; set; } = "Name"; // in C#6 and later -> automatic prop. can be initialized
        // 


        public void StructuredExceptionHandling()
        {

        }


        public void CollectionsAndGeneric()
        {
            string[] strArray = { "a", "b", "c" };
            //strArray[3] = "d";  -> would be a runtime exception

            // collections -> built to dynamically resize themselfs on the fly as you insert or remove items. Nongeneric (on objects) and generic (typesafe)
            // Nongeneric: ArrayList, BitArray, HashTable, Queue, SortedList, Stack, ICollection, ICloneable, IDictionary, IEnumerable, IEnumerator, IList
            ArrayList arrayList = new ArrayList();
            arrayList.AddRange(new string[] { "a", "b", "c" });
            Console.WriteLine("This collection has {0} items", arrayList.Count);

            arrayList.Add("d");
            arrayList.Add(1);
            Console.WriteLine("This collection has {0} items", arrayList.Count);
            // Problems: Performance (boxing), Typesafety


            // List<T>, Queue<T>, Stack<T>, SortedSet<T>, ObservableCollection<T>
            List<Point> points = new List<Point>()
            {
                new Point{ X = 0, Y = 0},
                new Point{ X = 1, Y = 0},
                new Point{ X = 0, Y = 1},
                new Point{ X = 1, Y = 1}
            };
            Console.WriteLine("# of items: {0}", points.Count);
            foreach (Point p in points)
                Console.WriteLine(p);
            points.Insert(2, new Point { X=2, Y=2}); // insert at speciefied index
            Console.WriteLine("# of items: {0}", points.Count);
            Point[] pointsArray = points.ToArray();
            foreach (Point p in pointsArray)
                Console.WriteLine(p);

            Queue<Point> pointsQ = new Queue<Point>(); // fifo
            pointsQ.Enqueue(new Point { X = 1, Y = 0 });
            pointsQ.Enqueue(new Point { X = 2, Y = 0 });
            pointsQ.Enqueue(new Point { X = 3, Y = 0 });
            Console.WriteLine(pointsQ.Peek().X); // view but not remove first item
            Console.WriteLine(pointsQ.Dequeue());
            Console.WriteLine(pointsQ.Dequeue());
            Console.WriteLine(pointsQ.Dequeue());
            try
            {
                Console.WriteLine(pointsQ.Dequeue());
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Error! {0}", e.Message);
            }

            Stack<Point> pointsS = new Stack<Point>(); // lifo
            pointsS.Push(new Point { X = 1, Y = 0 });
            pointsS.Push(new Point { X = 2, Y = 0 });
            pointsS.Push(new Point { X = 3, Y = 0 });
            Console.WriteLine(pointsS.Peek().X); // view but not remove first item
            Console.WriteLine(pointsS.Pop());
            Console.WriteLine(pointsS.Pop());
            Console.WriteLine(pointsS.Pop());
            try
            {
                Console.WriteLine(pointsS.Pop());
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Error! {0}", e.Message);
            }

            SortedSet<Point> pointsSorted = new SortedSet<Point>(new SortPoints())
            {
                new Point{ X = 3, Y = 0},
                new Point{ X = 1, Y = 0},
                new Point{ X = -10, Y = 1},
                new Point{ X = 1, Y = 1}
            };
            pointsSorted.Add(new Point { X = 0, Y = 9});
            foreach (Point p in pointsSorted)
            {
                Console.WriteLine(p.X);
            }

            ObservableCollection<Point> pointsO = new ObservableCollection<Point>()
            {
                new Point{ X = 0, Y = 0}, // Observable collection -> has an event that gets triggered whenever collection is changed
                new Point{ X = 1, Y = 0},
                new Point{ X = 0, Y = 1},
                new Point{ X = 1, Y = 1}
            };
            pointsO.CollectionChanged += PointsChanged;


            // Collection Initialization Syntax



            // Creating Custom Generic Classes



            // Constraining Type Parameters



        }


        public void Dictionaries()
        {
            //Dictionary<TKey, TValue>
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("c", "csfdsf");
            dict.Add("a", "asfdsf");
            dict.Add("b", "bsfdsf");
            dict.Add("y", "ysfdsf");
            try
            {
                dict.Add("a", "acv");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            dict["b"] = "bdv";
            dict["o"] = "onm";
            string val = "";
            dict.TryGetValue("t", out val);
            dict.Remove("c");
            Dictionary<string, string>.KeyCollection keys = dict.Keys;
            foreach (KeyValuePair<string, string> pair in dict)
            {
                Console.WriteLine("Key={0}, Value={1}", pair.Key, pair.Value);
            }

            //SortedDictionary<TKey, TValue>
            SortedDictionary<string, string> dictSorted = new SortedDictionary<string, string>(); // sorted by key
            dictSorted.Add("c", "csfdsf");
            dictSorted.Add("a", "asfdsf");
            dictSorted.Add("b", "bsfdsf");
            dictSorted.Add("y", "ysfdsf");
            try
            {
                dictSorted.Add("a", "acv");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            dictSorted["b"] = "bdv";
            dictSorted["o"] = "onm";
            string valS = "";
            dictSorted.TryGetValue("t", out valS);
            dictSorted.Remove("c");
            Dictionary<string, string>.KeyCollection keysS = dict.Keys;
            foreach (KeyValuePair<string, string> pair in dictSorted)
            {
                Console.WriteLine("Key={0}, Value={1}", pair.Key, pair.Value);
            }


            //SortedList<TKey, TValue>  - similiar to SortedDictionary, less memory used, but SortedDictionary is faster in insert.
            // stores keys sequentially in onde array and values in another


            //ConcurrentDictionary<TKey, TValue> -> thread safe collection key-value, access to which can be received by a couple of threads
            // We know how many items we want to insert into the ConcurrentDictionary.
            // So set the initial capacity to some prime number above that, to ensure that
            // the ConcurrentDictionary does not need to be resized while initializing it.
            int NUMITEMS = 64;
            int initialCapacity = 101;

            // The higher the concurrencyLevel, the higher the theoretical number of operations
            // that could be performed concurrently on the ConcurrentDictionary.  However, global
            // operations like resizing the dictionary take longer as the concurrencyLevel rises. 
            // For the purposes of this example, we'll compromise at numCores * 2.
            int numProcs = Environment.ProcessorCount;
            int concurrencyLevel = numProcs * 2;

            // Construct the dictionary with the desired concurrencyLevel and initialCapacity
            ConcurrentDictionary<int, int> cd = new ConcurrentDictionary<int, int>(concurrencyLevel, initialCapacity);

            // Initialize the dictionary
            for (int i = 0; i < NUMITEMS; i++) cd[i] = i * i;

            Console.WriteLine("The square of 23 is {0} (should be {1})", cd[23], 23 * 23);
        }


        // Static using -> allows all the accessible static members of a type to be imported, making them available without qualification in subseq. code.
        // great if you have a set of functions related to certain domain
        public void StaticUsing()
        {
            WriteLine(Sqrt(5));
            WriteLine(Friday - Monday);
        }






        // C# whats new
        // You can apply reaonly modifier to the members of a struct
        //public struct Point
        //{
        //    public double X { get; set; }
        //    public double Y { get; set; }
        //    //public readonly override string ToString() => "Point";
        //}

        static void PointsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class SortPoints : IComparer<Point>
    {
        public int Compare(Point x, Point y)
        {
            if (x.X > y.X)
                return 1;
            if (x.X < y.X)
                return -1;
            else
                return 0;
        }
    }
}
