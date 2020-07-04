using Microsoft.Diagnostics.Tracing.Parsers.JSDumpHeap;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace ConsoleAppTest.Services
{
    public class Language
    {
        // public - The type or member can be accessed by any other code in the same assembly or another assembly that references it.
        public int a;

        // private - The type or member can only be accessed by code in the same class or struct.
        private int b;

        // protected - The type or member can only be accessed by code in the same class or struct, or in a derived class.
        protected int c;

        // private protected (added in C# 7.2) - The type or member can only be accessed by code in the same class or struct, 
        // or in a derived class from the same assembly, but not from another assembly.
        private protected int d;

        // internal - The type or member can be accessed by any code in the same assembly, but not from another assembly.
        internal int e;

        // protected internal - The type or member can be accessed by any code in the same assembly, or by any derived class in another assembly.
        protected internal int f;

        public void Params()
        {
            Generic<int> generic = new Generic<int>(1);

            Addition(1,2,3,4,5);
            Addition();
            int[] ints = new int[] {1,2,3 };
            Addition(ints);

        }

        // params - pass any numer of parameters:
        public void Addition(params int[] integers) // One dimentional!
        {
            int res = 0;
            foreach (int i in integers) 
            {
                res += i;
            }
            Console.WriteLine(res);
        }


        // Variables context:
        // Class context, method context, block of code context;
        static int x = 1; // class level variable
        // 
        public void VariableContext() 
        {
            int y = 2; // method level variable

            {
                int z = 3; // block of code level variable
            }

            //Console.WriteLine(z); - z does not exist in current context;

            // when working with variables it is important to remember that local variables can cover variable of the higher level:
            int x = 10;
            Console.WriteLine(x);
        }

        // Tuples - from c# 7
        public void TupleUsage() 
        {
            var tuple = (1, 10);
            Console.WriteLine(tuple.Item1);
            Console.WriteLine(tuple.Item2);

            // we can explicitly give type of the tuple:
            (int, string, byte) t = (2, "n", 0);

            // we can give names to tuple fields:
            var t2 = (sum: 10, count: 2);
            Console.WriteLine(t2.sum);
            Console.WriteLine(t2.count);

            // tuples can be used in methods:
            var res = GetTuple((1,2,3), "text");
        }

        public (int, int) GetTuple((int, int, int) tuple, string text) 
        {
            return (tuple.Item1 + tuple.Item2 + tuple.Item3, 3);
        }

    }

    // Generics:
    public class Generic<T> 
    {
        // Default value of generic:
        public T val = default(T);

        public Generic(T val)
        {
            this.val = val;
        }

        // Destructors in C# are methods inside the class used to destroy instances of that class when they are no longer needed. The Destructor 
        // is called implicitly by the .NET Framework’s Garbage collector and therefore programmer has no control as when to invoke the destructor. 
        // An instance variable or an object is eligible for destruction when it is no longer reachable.
        // only used with classes
        // cannot be overloaded or inherited
        // 
        ~Generic() 
        {
            Console.WriteLine("DESTRUCTOR called {0}", val);
        }
    }

    // inheritance of generics - three types:
    public class GenericInhOne<T> : Generic<T>
    {
        public GenericInhOne(T val) : base(val)
        {
        }
    }

    public class GenericInhTwo : Generic<int>
    {
        public GenericInhTwo(int val) : base(val)
        {
        }
    }

    public class GenericInhThree<T> : Generic<int>
    {
        public GenericInhThree(int val) : base(val)
        {
        }
    }


    // Enum type - data type; byte int long short (int by default)
    // by default first elem is 0, you can specify another
    enum Days : short 
    {
        Monday = 1,
        Tuesday,
        Wednesday
    }

    //public static class EnumDaysUsage 
    //{
    //    public static void Usage() 
    //    {
    //        Console.WriteLine(Days.Wednesday);
    //    }
    //}
}
