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
        public void DeclareNamespacesClassesInterfacesStaticAndInstanceClassMembers()
        {

        }

        public void TypesCasting()
        {
            // important feature of CLR is typesafety
            // cast to base types is implicit, to derived -> explicit, possible runtime exception
            Object o = new Point(); // no cast needed -> object is base of Point
            Point p = (Point)o; // cast needed 

            // casting with is -> no exceptions thrown, returns bool
            Object o1 = new object();
            Boolean b1 = (o1 is Object); // true
            Boolean b2 = (o1 is Point); // false; if object is null, cast always returns false
            // cast with as -> clr checks if o1 is Point and if it is, returns a non-null reference, if not - returns null
            Point p1 = o1 as Point;

            // Following give runtime exceptions:
            Point p2 = (Point)o1;

            // Compile errors:
            //Point p3 = new object();

        }

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


            // Collection Initialization Syntax -> closely related to the object ininjtialization syntax(allows to set properties of new object at the time of construstion)
            // You can apply coll. init. syntax to classes that support Add() method, formalized by the ICollection interface
            int[] intArray = { 0, 1, 2, 3 };
            List<int> intList = new List<int> { 0, 1, 2, 3, 4 };
            ArrayList intArrayList = new ArrayList { 0, 1, 3 };
            // U can blend obj. initialization syntax with collection init. syntax:
            List<Point> listPoints = new List<Point>
            {
                new Point{ X = 1, Y = 2 },
                new Point{ X = 1, Y = 0 }
            };
            // benefit -> saving time


            // Creating Custom Generic Classes
            Point<int> p1 = new Point<int>(10, 10); // supports a single type parameter
            Point<double> p2 = new Point<double>(20.5, 0.3);
            p2.ResetPoint();


            // Constraining Type Parameters -> what given type parameter must look like
            // where T : struct -> T must have System.ValueType in its chain of inheritance (must be a structure)
            // where T : class -> must not have System.ValueType in inheritance  (must be a reference type)
            // where T : new() -> must have a default constructor - useful when creating instance of T -> this constraint must be listed last when multiple con-s
            // where T : NameOfBaseClass -> must be derived from NameOfBaseClass
            // where T : NameOfInterface -> you can write multiple interfaces separated by comma.
            // example -> where T : new(), class, IDrawable 

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
            // stores keys sequentially in one array and values in another


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


        public void BuildingEnumerableTypes()
        {
            // Iterate over an array of items:
            int[] arrayInt = { 1, 2, 3, 4 };
            foreach (int it in arrayInt)
            {
                Console.WriteLine(it); // any type supporting GetEnumerator() method can be evaluated by foreach construct
            }
            Points ps = new Points();
            foreach (Point p in ps) // implements IEnumerable (GetEnumerator)
            {
                Console.WriteLine(p.X);
            }

            // Manually work with IEnumerator:
            IEnumerator i = ps.GetEnumerator();
            i.MoveNext();
            Point point = (Point)i.Current;
            Console.WriteLine("X={0}, Y={1}", point.X, point.Y);

            // Using named iterator:
            foreach (Point p in ps.GetEnumeratorCustom())
            {
                Console.WriteLine(p.X);
            }
        }

        public void BuildingClonableObjects()
        {
            // MemberviceClone() -> shallow copy
            // ability to return identical copy -> implement IClonable
            // Clone returns plain object type -> need to cast
            PointClonable p1 = new PointClonable(10, -10);
            PointClonable p2 = (PointClonable)p1.Clone();
        }

        public void BuildingComparableTypes()
        {
            
        }

        public void NullableTypes()
        {
            //int i = null; bool b = null; -> compile errors -> value types can not be assigned null, as it is used to establish an empty object reference
            // nullable type can represent all the values of its underliyng type, plus the value null. Can be useful when working with relational db-s. To define nullable variable type ? is put in suffix
            int? ni = 10;
            bool? nb = null;
            char? nc = 'a';
            int?[] arrayInt = new int?[10];
            string? s = "str";

            // ? suffix notation is a shorthand for creating instance of the generic System.Nullable<T> structure. Provides set of members of use.
            Nullable<int> ni2 = 9;
            Console.WriteLine(ni2.HasValue); // true

            // operator ?? allows you to assign a value to nullable type if the retrieved value is in fact null. More compact version of if/else.
            int i = ni2 ?? 10;
        }

        public void DelegatesEventsLambdas()
        {

        }

        public void IndexersAndOperatorOverloading()
        {
            // Indexer method -> enables to build custom types that provide access to internal subitems using array-like syntax
            PointCollection pointCollection = new PointCollection();
            // Add object with indexer syntax
            pointCollection["Origin"] = new Point() { X = 0, Y = 0 };
            pointCollection["VectorX"] = new Point() { X = 1, Y = 0 };
            pointCollection["VectorY"] = new Point() { X = 0, Y = 1 };
            Point p = pointCollection["VectorX"];
            // Overloading Indexer methods: -> may be overloaded on single class or structure
            pointCollection[1] = new Point() { X = 1, Y = 1 };
            // Also indexers with multiple dimensions (this[int x, int y], indexers in interfaces)


            // Operator overloading:
            Point a = new Point() { X = 0, Y = 10 };
            Point b = new Point() { X = 20, Y = 30 };
            Point c = a + b;
            Console.WriteLine("X={0},Y={1}", c.X, c.Y);
            Console.WriteLine(a < b); // when define < also c# demands defining > -> otherwise compile error
            // use wisely - only when building atomic data types
        }

        public void AnonymuousTypes()
        {
            // Build anon. type using the var keyword -> compiler will automatically generate a new class definition at compile time. Initialization syntaxis used to tell the compiler to create private backing fields and (read-only)
            // properties for the newly created type.
            var point = new { X = 10, Y = 20, Z = -40 };
            // you can use this type to get the property data:
            Console.WriteLine("Point: {0}, {1}, {2}", point.X, point.Y, point.Z);
            //int t = point.T; // -> compile time error
            //point.X = 9; // -> compile error - all properties are readonly

            // Anon. types have custom implementations of each virtual method of System.Object:
            Console.WriteLine(point.ToString());
            Console.WriteLine("Instance of : {0}, Base class: {1}", point.GetType().Name, point.GetType().BaseType); // <>f__AnonymousType0`3 , base: System.Object

            // anon types can not support events, cust. methods, cust. operators or cust. overrides.; always are implicitly sealed; are always created using the default constructor.

            // It is possible to create an anonymous type that is composed of other anon. types.
            var itemPurchase = new
            {
                TimeBought = DateTime.Now,
                Item = new { Color = "Red", Speed = 50},
                Price = 34.00
            };
        }

        public void ExtensionMethods()
        {
            // Extension methods -> allow you to add new methods or properties to a class or structure without modifying the original type in any direct manner. 
            // Useful for -> backward compatibility, work with sealed classes or structures.
            // Must be within static classes, are marked with this keyword as a modifier on first param., top-level(not nested)
            int i = 12345;
            int reversed = i.ReverseDigits();
            Console.WriteLine(reversed);
            // extension methods are limited to namespaces -> need to import -> using!
            // Extending types implementig specific interfaces: -> also possible to define extension method that can only extend a class or struct that implements the correct interface.
            string[] data = { "a", "b", "c" };
            data.PrintAndBeep(); // any type that implements IEnumerable has a new method
        }

        public void CustomTypeConversions()
        {
            // In terms of the intrinsic numerical types (sbyte, int, float, etc.), an explicit conversion is required when
            //you attempt to store a larger value in a smaller container, as this could result in a loss of data. Conversely, an
            //implicit conversion happens automatically when you attempt to place a smaller type in a destination type that will not result in a loss of data: 
            int a = 123;
            long b = a; // implicit
            int c = (int)b; // explicit

            // C# provides two keywords,explicit and implicit, that you can use to control how your types respond during an attempted conversion. 
            Point p = new Point() { X = 2, Y = 1 };
            PointSpace ps = p;
            Point p2 = (Point)ps;
            // conversion routines make use of the C# operator keyword, in conjunction with the explicit or implicit keyword, and must be defined as static. The incoming parameter is the
            // entity you are converting from, while the operator type is the entity you are converting to. 

            PointSpace ps2 = 1;
            int i = (int)ps2;
            // the incoming operator -> entity converting from, operator type -> converting to;
        }

        // Strings and StringBuilder. String concatenation practices. String Interpolation
        public void StringsAndStringBuilder()
        {

        }




        public void Serialization()
        {
            //Configuring Objects for Serialization



            //Choosing a Serialization Formatter(binary, soap, xml, etc)



            //Type Fidelity Among the Formatters

        }


        public void SystemIONameSpace()
        {
            //Abstract Stream Class



            //StreamWriters and StreamReaders



            //StringWriters and StringReaders



            //Watching Files Programmatically

        }

        public void LinqToObjects()
        {
            //LINQ Queries to Primitive Arrays and Collections



            //LINQ Query Operators



            //Internal Representation of LINQ Query



            //Building Query Using Lambda Expressions

        }

        public void GeneralCodingConventions()
        {

        }

        // Static using -> allows all the accessible static members of a type to be imported, making them available without qualification in subseq. code.
        // great if you have a set of functions related to certain domain
        public void StaticUsing()
        {
            WriteLine(Sqrt(5)); // using static System.Console;
            WriteLine(Friday - Monday);
        }




        // ****************************************************************** //

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


        // Operator overloading: using keyword operator
        public static Point operator +(Point p1, Point p2)
        {
            return new Point() { X = p1.X + p2.X, Y = p1.Y + p2.Y };
        }

        public static bool operator <(Point p1, Point p2)
        {
            return (p1.X < p2.X) && (p1.Y < p2.Y); 
        }

        public static bool operator >(Point p1, Point p2)
        {
            return (p1.X > p2.X) && (p1.Y > p2.Y);
        }

        // 3d point can be explicitly converted to 2d point 
        public static explicit operator Point(PointSpace p)
        {
            return new Point() { X = p.X, Y = p.Y}; // Z is lost
        }
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

    public class Points : IEnumerable
    {
        private Point[] pointArray = new Point[4];

        public Points()
        {
            pointArray[0] = new Point() { X = 1, Y = 0 };
            pointArray[1] = new Point() { X = 0, Y = 0 };
            pointArray[2] = new Point() { X = 1, Y = 1 };
            pointArray[3] = new Point() { X = 0, Y = 1 };
        }

        public IEnumerator GetEnumerator()
        {
            return pointArray.GetEnumerator();
        }

        public IEnumerable GetEnumeratorCustom()
        {
            foreach (Point p in pointArray)
            {
                yield return p;
            }
        }
    }

    public class PointClonable : ICloneable
    {
        public PointClonable(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public object Clone()
        {
            return new PointClonable(this.X, this.Y);
        }
    }

    // Generic Point Struture:
    public struct Point<T> where T : struct
    {
        private T xPos;
        private T yPos;

        public T X { get => xPos; set => xPos = value; }
        public T Y { get => yPos; set => yPos = value; }

        public Point(T x, T y)
        {
            xPos = x;
            yPos = y;
        }

        // Reset fields to the default value of type parameter
        public void ResetPoint()
        {
            xPos = default(T);
            yPos = default(T); // 0 for numeric values, null for ref.
        }

        //public class MyCl : System.Int32 { }

    }

    public static class MyExtensions
    {
        public static int ReverseDigits(this int i)
        {
            char[] digits = i.ToString().ToCharArray();
            Array.Reverse(digits);
            return int.Parse(new string(digits));
        }

        public static void PrintAndBeep(this System.Collections.IEnumerable iterator)
        {
            foreach (var i in iterator)
            {
                Console.WriteLine(i);
                Console.Beep();
            }
        }
    }

    public class PointCollection : IEnumerable
    {
        private Dictionary<string, Point> listPoints = new Dictionary<string, Point>();

        // This indexer returns a point based on a string index:
        public Point this[string name]
        {
            get { return (Point)listPoints[name]; }
            set { listPoints[name] = value; }
        }

        public Point this[int id]
        {
            get { return (Point)listPoints[id.ToString()]; }
            set { listPoints[id.ToString()] = value; }
        }

        public IEnumerator GetEnumerator()
        {
            return listPoints.GetEnumerator();
        }

        public interface IStringContainer // indexer in interface
        {
            string this[int index] { get; set; }
        }
    }

    public class PointSpace
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        // 2d point can be implicitly converted into 3d point 
        public static implicit operator PointSpace(Point p)
        {
            return new PointSpace() { X = p.X, Y = p.Y, Z = 0 };
        }

        // additional explicit conversion:
        // cast from PointSpace to int
        public static explicit operator int(PointSpace p)
        {
            return p.X;
        }

        public static implicit operator PointSpace(int i)
        {
            return new PointSpace() { X = i, Y = i, Z = i };
        }
    }
}
