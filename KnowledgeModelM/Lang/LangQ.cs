using System;
using System.Collections;
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
