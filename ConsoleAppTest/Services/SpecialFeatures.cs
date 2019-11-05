using ConsoleAppTest.DebugAndSecurity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Transactions;

// Aliased generics:
using ASimpleName = System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>>>;

namespace ConsoleAppTest.Services
{
    // TODO: semaphore, Transaction, stackalloc, out, ref
    public class SpecialFeatures
    {
        private T DefaultValue<T>()
        {
            return default(T);
        }

        public void DeafultValues()
        {
            ArrayList list = new ArrayList();
            list.Add(DefaultValue<bool>());
            list.Add(DefaultValue<string>());
            list.Add(DefaultValue<int>());
            list.Add(DefaultValue<double>());
            list.Add(DefaultValue<float>());
            list.Add(DefaultValue<char>());
            list.Add(DefaultValue<MusicTrack>());
            list.Add(DefaultValue<object>());
            list.Add(DefaultValue<byte[]>());
            list.Add(DefaultValue<DateTime>());

            foreach (var elem in list)
            {
                Console.WriteLine(elem);
            }
        }

        public void HasValueProperty()
        {
            int? x = null;
            int y;
            if (x.HasValue)
                y = x.Value;
            bool b = x.HasValue;
        }

        public void StringJoin()
        {
            string outPut = String.Join(",", new string[] {"Hello", "There", "!" });
            Console.WriteLine(outPut);

            // TODO: Visual Studio feature. When you start your comment with TODO, it's added to your Visual Studio Task List (View -> Task List. Comments)

            var list = Enumerable.Range(0, 100);
            foreach (int elem in list)
            {
                Console.WriteLine(elem);
            }
        }

        public void MultipleObjectsUsing()
        {
            //using (Font f1 = )
            //{

            //}
        }

        // DefaultValue attribute -> Specifies the default value for a property.
        [DefaultValue(true)]
        public bool SomeProperty { get; set; }

        // Describes a clone of a transaction providing guarantee that the transaction cannot be committed until the application comes to 
        // rest regarding work on the transaction. This class cannot be inherited.
        public void Transactionc()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                // Perform transactional work here.
            }
        }

        public void StringIsNullOrEmptyUsage()
        {
            string s = "";
            if (String.IsNullOrEmpty(s))
                Console.WriteLine("Empty!");
        }

        // iterate through your generic list using a delegate method
        public void ListForeach()
        {
            List<string> list = new List<string>()
            {
                "a",
                "b",
                "c",
                "d"
            };

            list.ForEach(s => 
            {
                Console.WriteLine(s);
            });
        }

        // On-demand field initialization in one line:
        private string _str;

        public string Str
        {
            get { return _str ?? "new string"; }
        }

        // Auto properties can have different scopes
        public int MyInt { get; private set; }

        // You can use @ for variable names that are keywords
        public void UsingVariableNamesThatAreKeywors()
        {
            var @string = "hello";
            var @int = new object();
            var @object = 99;
            Console.WriteLine(@string);
        }

        // Events are really delegates under the hood and any delegate object can have multiple functions attached to it and detatched from it
        // Events can also be controlled with the add/remove, similar to get/set except they're invoked when += and -= are use
        private event EventHandler _handler;

        public event EventHandler Handler
        {
            add
            {
                if (value.Target == null)
                    throw new Exception("No static handlers!");
                _handler += value;
            }
            remove
            {
                _handler -= value;
            }
        }

        public void CheckedAndUnchecked()
        {
            short x = 32767; // maximum value for short
            int z2 = unchecked((short)(x + x)); // -2
            int z3 = (short)(x + x); // -2
            Console.WriteLine("z2={0}, z3={1}", z2, z3);

            int z1 = checked((short)(x + x)); // will throw OverflowException
        }

        // Preprocessor directives
        public void IfDebug()
        {
#if DEBUG
            Console.WriteLine("Debug version!");
#endif
        }

        public void AnonymuousFunctions()
        {
            var f = new Func<string>(() => { return "string"; });

            Func<int, int, string> add = (a, b) => Convert.ToString(a + b);
            Func<int, int, string> addAnother = (a, b) =>
            {
                var i = a + b;
                return i.ToString();
            };

            Console.WriteLine(f() + add(1,2) + addAnother(2,3));
        }

        public void FormatStringBrackets()
        {
            int foo = 3;
            string bar = "mice";
            string s = String.Format("{{I am in brackets!}} {0} {1}", foo, bar);
            Console.WriteLine(s);
            //Outputs "{I am in brackets!} 3 mice"
        }

        static Mutex mutObj = new Mutex();
        static int x = 0;

        private void Count()
        {
            mutObj.WaitOne();
            x = 1;
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine("Thread: {0}, x: {1}", Thread.CurrentThread.Name, x);
                x++;
                Thread.Sleep(200);
            }
            mutObj.ReleaseMutex();
        }

        public void UsingMutex()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread newThread = new Thread(Count);
                newThread.Name = "thread " + i.ToString();
                newThread.Start();
            }
        }


        // create semaphore
        static Semaphore semaphore = new Semaphore(3, 3);

        public void UsingSemaphore()
        {

        }

        // The DebuggerDisplayAttribute controls how an object, property, or field is displayed in the 
        // debugger variable windows. This attribute can be applied to types, delegates, properties, fields, and assemblies.
        [DebuggerDisplay("{value}", Name = "{key}")]
        public class KeyValuePair
        {
            public KeyValuePair(string key, string value)
            {
                this.key = key;
                this.value = value;
            }

            public string key { get; set; }
            public string value { get; set; }
        }


        // Weak references in .Net create references to large objects in your application that are used infrequently so that 
        // they can be reclaimed by the garbage collector if needed
        public void WeakRefernceUsage()
        {
            KeyValuePair keyValuePair = new KeyValuePair("a", "stuff");
            WeakReference reference = new WeakReference(keyValuePair);
            keyValuePair = null;
            if (reference.IsAlive)
            {
                Console.WriteLine("Obj is alive");
                KeyValuePair pair = reference.Target as KeyValuePair;
                Console.WriteLine(pair.value);
            }
        }

        // 
        public void UsingGoTo()
        {
            for (int i = 0; i < 10; i++)
            {
                if (i % 3 == 0)
                {
                    goto DivisibleBy3;
                }
            }

        DivisibleBy3:
            Console.WriteLine("Divisible by 3");
        }


    }
}
