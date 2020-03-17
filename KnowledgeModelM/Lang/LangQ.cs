using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
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
            points.Insert(2, new Point { X = 2, Y = 2 }); // insert at speciefied index
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
            pointsSorted.Add(new Point { X = 0, Y = 9 });
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

            // Если требуется отсортировать коллекцию, состоящую из объектов определяемого пользователем класса, при условии, что они не сохраняются 
            // в коллекции класса SortedList, где элементы располагаются в отсортированном порядке, то в такой коллекции должен быть известен способ 
            // сортировки содержащихся в ней объектов. С этой целью можно, в частности, реализовать интерфейс IComparable для объектов сохраняемого 
            // типа. Интерфейс IComparable доступен в двух формах: обобщенной и необобщенной. Несмотря на сходство применения обеих форм данного 
            // интерфейса, между ними имеются некоторые, хотя и небольшие, отличия.

            // Для сортировки объектов по нарастающей конкретная реализация данного метода должна возвращать нулевое значение, если значения 
            // сравниваемых объектов равны; положительное — если значение вызывающего объекта больше, чем у объекта другого other; и отрицательное 
            // — если значение вызывающего объекта меньше, чем у другого объекта other. А для сортировки по убывающей можно обратить результат 
            // сравнения объектов.

            List<PointComparable> list = new List<PointComparable>()
            {
                new PointComparable(1, 2),
                new PointComparable(4, 4),
                new PointComparable(1, 5),
                new PointComparable(5, 9),
                new PointComparable(-20, 0),
                new PointComparable(9, -2),
                new PointComparable(1, 2),
                new PointComparable(356, 90),
                new PointComparable(2, 0)
            };
            list.Sort(); // 
            foreach (var p in list)
            {
                Console.WriteLine("X={0}, Y={1}", p.X, p.Y);
            }
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

        delegate void AccountHandler(string message);
        event AccountHandler Notify;
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



            // События сигнализируют системе о том, что произошло определенное действие. И если нам надо отследить эти действия, то как раз мы 
            // можем применять события.
            // События объявляются в классе с помощью ключевого слова event, после которого указывается тип делегата, который представляет событие:
            Notify += DisplayMessage;   // Добавляем обработчик для события Notify

            // Лямбда-выражения представляют упрощенную запись анонимных методов. Лямбда-выражения позволяют создать емкие лаконичные методы, 
            // которые могут возвращать некоторое значение и которые можно передать в качестве параметров в другие методы.
            Operation operation = (x, y) => x + y;
            Console.WriteLine(operation(10, 20));
        }

        private void DisplayMessage(string message)
        {
            Console.WriteLine(message);
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
                Item = new { Color = "Red", Speed = 50 },
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
            // stringBuilder - Represents a mutable string of characters. This class cannot be inherited. System.Text
            // 
            StringBuilder sb = new StringBuilder("string");
            sb.Append(new char[] { 'D', 'E', 'F' });
            sb.AppendFormat("GHI{0}{1}", 'J', 'k');
            Console.WriteLine("{0} chars: {1}", sb.Length, sb.ToString());
            sb.Insert(0, "A"); // inserts at the beggining
            sb.Replace("k", "K"); // replaces all
            Console.WriteLine(sb.ToString());



            // The $ special character identifies a string literal as an interpolated string. An interpolated string is a string literal that might 
            // contain interpolation expressions. When an interpolated string is resolved to a result string, items with interpolation expressions 
            // are replaced by the string representations of the expression results. This feature is available starting with C# 6.
            // String interpolation provides a more readable and convenient syntax to create formatted strings than a string composite formatting 
            // feature.

            int i = 1;
            string name = "Namen";
            int age = 30;

            Console.WriteLine($"i={i}, Name={name}, {age} year{(age == 1 ? "" : "s")} old");
            // To include a brace, "{" or "}", in the text produced by an interpolated string, use two braces, "{{" or "}}".
            // Possible to use conditional operator in an interpolation expression
        }




        public void Serialization()
        {
            //Configuring Objects for Serialization
            // Serialization is a process of storing the object instance to a disk file. Serialization stores state of the object i.e. member 
            // variable values to disk. Deserialization is reverse of serialization i.e. it's a process of reading objects from a file where 
            // they have been stored. In this code sample we will see how to serialize and deserialize objects using C#.


            //Choosing a Serialization Formatter(binary, soap, xml, etc)



            //Type Fidelity Among the Formatters
            // Как только типы сконфигурированы для участия в схеме сериализации.NET с применением необходимых атрибутов, следующий шаг состоит в 
            // выборе формата(двоичного, SOAP или XML) для сохранения состояния объектов. Перечисленные возможности представлены следующими классами:
            // BinaryFormatter
            // SoapFormatter
            // XmlSerializer

            // Наиболее очевидное отличие между тремя форматерами связано с тем, как граф объектов сохраняется в потоке(двоичном, SOAP или XML). 
            // Следует знать также о некоторых более тонких отличиях, в частности — каким образом форматеры добиваются точности типов(type fidelity).
            // Когда используется тип BinaryFormatter, он сохраняет не только данные полей объектов из графа, но также полное квалифицированное имя 
            // каждого типа и полное имя определяющей его сборки(имя, версия, маркер общедоступного ключа и культура). Эти дополнительные элементы 
            // данных делают BinaryFormatter идеальным выбором, когда необходимо передавать объекты по значению(т.е.полные копии) между границами 
            // машин для использования в .NET - приложениях.
            // Форматер SoapFormatter сохраняет трассировки сборок - источников за счет использования пространства имен XML. Например, вспомните тип 
            // Person, определенный в предыдущей статье. Если понадобится сохранить этот тип в сообщении SOAP, вы обнаружите, что открывающий элемент 
            // Person квалифицирован сгенерированным параметром xmlns.
            // Однако XmlSerializer не пытается предохранить точную информацию о типе, и потому не записывает его полного квалифицированного имени 
            // или сборки, в которой он определен.Хотя на первый взгляд это может показаться ограничением, причина состоит в открытой природе 
            // представления данных XML.
            // Если необходимо сохранить состояние объекта так, чтобы его можно было использовать в любой операционной системе(Windows ХР, Mac OS 
            // X и различных дистрибутивах Linux), на любой платформе приложений(.NET, Java Enterprise Edition, COM и т.п.) или в любом языке 
            // программирования, придерживаться полной точности типов не следует, поскольку нельзя рассчитывать, что все возможные адресаты смогут 
            // понять специфичные для.NET типы данных.Учитывая это, SoapFormatter и XmlSerializer являются идеальным выбором, когда требуется 
            // гарантировать как можно более широкое распространение объектов.

        }


        public void SystemIONameSpace()
        {
            //Abstract Stream Class
            // Provides a generic view of a sequence of bytes. This is an abstract class.
            // Stream is the abstract base class of all streams. A stream is an abstraction of a sequence of bytes, such as a file, an input/output 
            // device, an inter-process communication pipe, or a TCP/IP socket. The Stream class and its derived classes provide a generic view of 
            // these different types of input and output, and isolate the programmer from the specific details of the operating system and the 
            // underlying devices.


            //StreamWriters and StreamReaders
            // StremWriter -> Implements a TextWriter for writing characters to a stream in a particular encoding.
            // Get the directories currently on the C drive.
            DirectoryInfo[] cDirs = new DirectoryInfo(@"c:\").GetDirectories();
            using (StreamWriter sw = new StreamWriter("dummy.txt"))
            {
                foreach (DirectoryInfo directory in cDirs)
                {
                    sw.WriteLine(directory.Name);
                }
                sw.Close();
            }
            string line = "";

            // StremWriter -> Implements a TextReader that reads characters from a byte stream in a particular encoding.
            // Read and show each line from the file.
            using (StreamReader sr = new StreamReader("dummy.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            // 


            //StringWriters and StringReaders
            // StringWriter -> Implements a TextWriter for writing information to a string. The information is stored in an underlying StringBuilder.
            string textReaderText = "TextReader is the abstract base " +
            "class of StreamReader and StringReader, which read " +
            "characters from streams and strings, respectively.\n\n" +

            "Create an instance of TextReader to open a text file " +
            "for reading a specified range of characters, or to " +
            "create a reader based on an existing stream.\n\n" +

            "You can also use an instance of TextReader to read " +
            "text from a custom backing store using the same " +
            "APIs you would use for a string or a stream.\n\n";
            StringReader stringReader = new StringReader(textReaderText);
            string aLine;
            while (true) 
            {
                aLine = stringReader.ReadLine();
                if (aLine != null)
                {
                    Console.WriteLine("New Line: " + aLine);
                }
                else 
                {
                    break;
                }
            }
            // StringReader -> Implements a TextReader that reads from a string.
            StringBuilder stringToRead = new StringBuilder();
            stringToRead.AppendLine("Characters in 1st line to read");
            stringToRead.AppendLine("and 2nd line");
            stringToRead.AppendLine("and the end");

            using (StringReader reader = new StringReader(stringToRead.ToString()))
            {
                string readText = reader.ReadToEnd();
                Console.WriteLine(readText);
            }


            //Watching Files Programmatically
            // FileSystemWatcher Class -> Listens to the file system change notifications and raises events when a directory, or file in a 
            // directory, changes.
            // 
            string[] args = Environment.GetCommandLineArgs();
            // If a directory is not specified, exit program.
            if (args.Length != 2)
            {
                // Display the proper way to call the program.
                Console.WriteLine("Usage: Watcher.exe (directory)");
                return;
            }
            // Create a new FileSystemWatcher and set its properties.
            using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                watcher.Path = args[1];

                // Watch for changes in LastAccess and LastWrite times, and
                // the renaming of files or directories.
                watcher.NotifyFilter = NotifyFilters.LastAccess
                                     | NotifyFilters.LastWrite
                                     | NotifyFilters.FileName
                                     | NotifyFilters.DirectoryName;
                // Only watch text files.
                watcher.Filter = "*.txt";
                // Add event handlers.
                watcher.Changed += OnChanged;
                watcher.Created += OnChanged;
                watcher.Deleted += OnChanged;
                watcher.Renamed += OnRenamed;
                // Begin watching.
                watcher.EnableRaisingEvents = true;
                // Wait for the user to quit the program.
                Console.WriteLine("Press 'q' to quit the sample.");
                while (Console.Read() != 'q') ;
            }
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            // Specify what is done when a file is renamed.
            Console.WriteLine($"File: {e.OldFullPath} renamed to {e.FullPath}");
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed, created, or deleted.
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");
        }

        public void LinqToObjects()
        {
            // linq -> strongly typed query language, embedded directly into the grammar of c# itself.

            // LINQ Queries to Primitive Arrays and Collections
            string[] stringArray = { "ab", "cd", "eq", "ce" };
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
            // A set of extension methods forming a query pattern is known as LINQ Standard Query Operators. As building blocks of LINQ query 
            // expressions, these operators offer a range of query capabilities like filtering, sorting, projection, aggregation, etc.
            // Filtering: where (filter based on predicate function), OfType()
            // Join: Join (join … in … on … equals …), GroupJoin (join ... in … on … equals … into …)
            // Projection: 
            // Sorting: 
            // Grouping: 
            // Conversions: 
            // Concatenation: 
            // Aggregation: 
            // Quantifiers: 
            // Partition: 
            // Generation: 
            // Set: 
            // Equality: 
            // Element: 



            //Internal Representation of LINQ Query
            // Expression trees. These are representations of code as data. For instance, an expression tree could represent the notion of "take 
            // a string parameter, call the Length property on it, and return the result". The fact that these exist as data rather than as compiled 
            // code means that LINQ providers such as LINQ to SQL can analyze them and convert them into SQL.


            //Building Query Using Lambda Expressions
            // You do not use lambda expressions directly in query syntax, but you do use them in method calls, and query expressions can contain 
            // method calls. In fact, some query operations can only be expressed in method syntax.
            int[] scores = { 90, 71, 82, 93, 75, 82 };
            int highScoreCount = scores.Where(n => n > 10).Count();
            // Note that the Where method in this example has an input parameter of the delegate type Func<T,TResult> and that delegate takes an 
            // integer as input and returns a Boolean. The lambda expression can be converted to that delegate. If this were a LINQ to SQL query 
            // that used the Queryable.Where method, the parameter type would be an Expression<Func<int,bool>> but the lambda expression would look 
            // exactly the same
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
            return new Point() { X = p.X, Y = p.Y }; // Z is lost
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

    public class PointComparable : IComparable<PointComparable>
    {
        public PointComparable(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public int CompareTo(PointComparable other)
        {
            if (X > other.X)
            {
                return 1;
            }
            else if (X < other.X)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
