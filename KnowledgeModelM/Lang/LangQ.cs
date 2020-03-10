using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
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
            // The following data types are all of value type: bool,byte,char,decimal,double,enum,float,int,long,sbyte,short,struct,uint,ulong,ushort;
            // A data type is a value type if it holds a data value within its own memory space. It means variables of these data types directly 
            // contain their values.

            // The following data types are of reference type: String, All arrays(even if their elements are value types),Class,Delegates;
            // Unlike value types, a reference type doesn't store its value directly. Instead, it stores the address where the value is being 
            // stored. In other words, a reference type contains a pointer to another memory location that holds the data.
            // Reference types have null value by default, when they are not initialized.
        }

        // Properties and automatic properties
        public int Id { get; set; } // automatic property -> no additional logic of access
        public string Name { get; set; } = "Name"; // in C#6 and later -> automatic prop. can be initialized
        // 



        public void StructuredExceptionHandling()
        {
            // C# exceptions are represented by classes. The exception classes in C# are mainly directly or indirectly derived from the 
            // System.Exception class. Some of the exception classes derived from the System.Exception class are the System.ApplicationException 
            // and System.SystemException classes.


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
            // IComparable: Defines a generalized type-specific comparison method that a value type or class implements to order or sort its 
            // instances.
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


        delegate void Message();  // declare delegate
        delegate int Operation(int x, int y);
        public void DelegatesEventsLambdas()
        {
            // Делегаты представляют такие объекты, которые указывают на методы. То есть делегаты - это указатели на методы и с помощью делегатов 
            // мы можем вызвать данные методы.

            Message mes;// create variable of the delegate
            if (DateTime.Now.Hour < 12)
            {
                mes = GoodMorning; // assign adress of that method to a variable;
            }
            else 
            {
                mes = GoodEvening;
            };
            mes(); // call the delegate



            // Лямбда-выражения представляют упрощенную запись анонимных методов. Лямбда-выражения позволяют создать емкие лаконичные методы, 
            // которые могут возвращать некоторое значение и которые можно передать в качестве параметров в другие методы.
            Operation operation = (x, y) => x + y;
            Console.WriteLine(operation(10, 20));
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
            // linq -> strongly typed query language, embedded directly into the grammar of c# itself.

            // LINQ Queries to Primitive Arrays and Collections
            string[] stringArray = { "ab", "cd", "eq", "ce"};
            // when have array -> common to extract a subset of items based on a given requirement
            IEnumerable<string> subset = from s in stringArray
                                         where s.Contains("c")
                                         orderby s
                                         select s;
            foreach (string s in subset)
                Console.WriteLine(s);
            List<Point> list = new List<Point>()
            {
                new Point(){ X = 0, Y = 0 },
                new Point(){ X = 0, Y = 1 },
                new Point(){ X = 0, Y = 2 },
                new Point(){ X = 1, Y = 0 },
                new Point(){ X = 2, Y = 1 },
                new Point(){ X = 2, Y = 2 },
                new Point(){ X = 2, Y = 0 },
                new Point(){ X = -3, Y = 1 },
            };
            // linq query expressions can also manipulate data within members of System.Collections.Generic namespace.
            IEnumerable<Point> firstQuadrant = from p in list
                                               where p.X > 0 && p.Y > 0
                                               orderby p.X
                                               select p;
            foreach (Point p in firstQuadrant)
                Console.WriteLine("x = {0}, y = {1};", p.X, p.Y);
            // on non-generic collections:
            ArrayList arrayList = new ArrayList()
            {
                new Point(){ X = 0, Y = 0 },
                new Point(){ X = 0, Y = 1 },
                new Point(){ X = 0, Y = 2 },
                "item",
                new Point(){ X = 1, Y = 0 },
                5,
                new Point(){ X = 2, Y = 1 },
                new Point(){ X = 2, Y = 2 },
                new Point(){ X = 2, Y = 0 },
                new object(),
                new Point(){ X = -3, Y = 1 },
            };
            // Transform ArrayList into an IEnumerable<T>-compatible type. 
            IEnumerable<Point> pointsFromAL = arrayList.OfType<Point>();
            var subset2 = from p in pointsFromAL
                          where p.X > 0 && p.Y > 0
                          orderby p.X
                          select p;

            //LINQ Query Operators



            //Internal Representation of LINQ Query



            //Building Query Using Lambda Expressions

        }

        public void GeneralCodingConventions()
        {
            // Coding conventions -> consistent look, understand code more quickly, facilitate copiing, changing
            // Use namespace qualifiers. 
            // Layout -> default code editor setting (tabs, smart identiing etc.) only one statement per line, one declaration per line,
            // at least one blank line between line def. and property def., use paranteses to make clouses:
            var a = 1;
            var b = 1;
            if ((a > 0) && (b > 0))
            {

            }
            // Commenting -> place comment on a separate line, not at the end of current one, begin wwith upper case, end with a dot, one space between slashes 
            // and text.

            // Lnguage guidelines:
            // Strings -> use string interploation to concatenate short strings:
            string display = $"{a.ToString()},{b.ToString()}";
            // To append strings in loops -> use StringBuilder
            var bigString = new StringBuilder();
            for (var i = 0; i < 100; i++)
            {
                bigString.Append(display);
            }
            // Use implicit typing for variables when the type of the variable is obvious from the right hand of expression or is not important:
            var s = "string";
            // Do not use var when the type is not apparent; avoid the use of var in place of dynamic; 
            // Use implicit typing to determine the type of the loop variable in for and foreach statements
            // In general, use int rather than unsigned types -> more compatibility.
            // Use the concise syntax when you initialize arrays on the declaration line.
            // To avoid exceptions and increase performance by skipping unnecessary comparisons, use && instead of & and || instead of | when you perform comparisons
            // Use the concise form of object instantiation, with implicit typing
            // Use object initializers to simplify object creation:
            var point = new Point() { X = 0, Y = 1 };
            // 

            // Call static members by using the class name: ClassName.StaticMember. This practice makes code more readable by making static access clear. 
            // Do not qualify a static member defined in a base class with the name of a derived class.

            // Use implicit typing in the declaration of query variables and range variables.
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

        private static void GoodMorning()
        {
            Console.WriteLine("Good Morning");
        }
        private static void GoodEvening()
        {
            Console.WriteLine("Good Evening");
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
