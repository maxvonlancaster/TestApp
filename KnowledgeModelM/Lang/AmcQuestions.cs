﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeModel.Lang
{
    public class AmcQuestions
    {
        // 1. What is the difference between value and reference types? Is it true that the value type is always stored in a stack?

        // 2. What is the output for this block of code?
        struct Num
        {
            public int i;
        }

        public void Main()
        {
            Num x = new Num();
            x.i = 10;
            Update(x);
            Console.Write(x.i);
        }

        static void Update(Num y)
        {
            y.i = 20;
        }


        // 3. What is the difference between classes and structures? Is it possible to inherit from structure? In what cases it's better to use structures?
        //struct NumNew : Num 
        //{}


        // 4. What is the purpose of namespaces? Is it good practice to keep your application in a single namespace?
        // They're used especially to provide the C# compiler a context for all the named information in your program, such as variable names. 
        // Without namespaces, for example, you wouldn't be able to make a class named Console, as .NET already uses one in its System namespace
        // Namespaces are used to organize code into logical groups and to prevent name collisions that can occur especially when your code base includes multiple libraries.


        // 5. Is the following code correct? - NO
        struct NumT
        {
            public const double x = 1.0;
            public NumT(double start)
            {
                //x = start;
            }
        }

        // 7. What will be the output for this block of code?
        public void CodeExample()
        {
            int i = 5;
            object b = i;
            i++;
            int c = ((int)b);
            c++;
            Console.Write(i.ToString(), b);

            // 6. Will the following code compile? (only with explicit cast to int)
            double d = 1.11;
            int j = (int)d;
        }

        // 8. Can you describe why the lock() statement is designed to only accept reference type parameters?
        // if the compiler let you lock on a value type, you would end up locking nothing at all... because each time you passed the value 
        // type to the lock, you would be passing a boxed copy of it; a different boxed copy. So the locks would be as if they were entirely different objects. 
        // You cannot lock a value type because it doesn't have a sync root record.
        // Locking is performed by CLR and OS internals mechanisms that rely upon an object having a record that can only be accessed by 
        // a single thread at a time - sync block root.

        // 9. How method arguments are passed in C#? Can this behavior be changed?

        // 10. What is the difference between Int.Parse and Int.TryParse?
        public void IntParseDiff()
        {
            string s1 = "incorrect";
            string s2 = "1";
            int i1;
            int i2;
            int i3;
            int i4;
            //i1 = int.Parse(s1, System.Globalization.NumberStyles.Integer); -> exception thrown
            i2 = int.Parse(s2, System.Globalization.NumberStyles.Integer);
            bool b1 = int.TryParse(s1, out i3);
            bool b2 = int.TryParse(s2, out i4);
            Console.WriteLine("{0}, {1}", b1, b2);
            Console.WriteLine("{0}, {1}", i3, i4);
        }

        // 11. What are the implicit and explicit type conversions?

        // 12. How do you cast from one reference type to another without risking to throw an exception?

        // 13. Why isn't it possible to create an instance of an abstract class?
        // Because it's abstract and an object is concrete. An abstract class is sort of like a template, 
        // or an empty/partially empty structure, you have to extend it and build on it before you can use it.

        // 14. Is it possible to invoke a method from an abstract class?
        public void MethodInvokingFromAbstractClass()
        {
            AbstractClass.DoStatic(); // Yes, possible
        }

        // 15. Is it true that Interface can only contain method declarations?
        // properties, events, indexers

        // 18. Is it possible to define two methods with the same name and arguments, but with a different return types? - NO
        //public int MyMethod(int arg) 
        //{
        //    return 0;
        //}

        //public double MyMethod(int arg) 
        //{
        //    return 0.0;
        //}

        // 19. What is the difference between method overriding and overloading?

        // 20. What does protected internal access modifier mean?
        // A protected internal member is accessible from the current assembly OR(!) from types that are derived from the containing class.

        // 21. Your class Shape has one constructor with parameters.Can you create an instances of this class by calling new Shape()? - NO
        public void CreateInstanceWithEmptyConstructor()
        {
            //Shape shape = new Shape();        No method that corresponds ...
        }

        // 22. Is it possible to override a method which is declared without a virtual keyword? - NO (but hiding with new is possible, but not advised)
        public void MethodNotVirtual()
        {
            Shape s1 = new Shape(1);
            int i = s1.ShapeMethod();
            Console.WriteLine(i); // 1
            Shape s2 = new ShapeNew(2);
            i = s2.ShapeMethod();
            Console.WriteLine(i); // 2 - the reference is wrong
            ShapeNew s3 = new ShapeNew(3);
            i = s3.ShapeMethod();
            Console.WriteLine(i); // 0 - the reference is correct
        }

        // 23. What is the difference between new and override keywords in method declaration?
        // Override: When a method of a base class is overridden in a derived class, the version in the derived class is used, even if the 
        // calling code didn't "know" that the object was an instance of the derived class.
        // New: If you use the new keyword instead of override, the method in the derived class doesn't override the method in the base class, it merely hides it.
        // If you don't specify either new or overrides, the resulting output is the same as if you specified new, but you'll also get a compiler warning 
        // (as you may not be aware that you're hiding a method in the base class method, or indeed you may have wanted to override it, and merely forgot 
        // to include the keyword).
        // Override: used with virtual/abstract/override type of method in base class
        // New : when base class has not declared method as virtual/abstract/override


        // 24. Is it possible to explicitly call a class’ static constructor?
        public void CallStaticConstructor()
        {

        }

        // 25. How can you override a static constructor?
        // A static constructor is used to initialize any static data, or to perform a particular action that needs to be performed once only. It is 
        // called automatically before the first instance is created or any static members are referenced.
        class SimpleClass
        {
            // Static variable that must be initialized at run time.
            public static readonly long baseline;

            // Static constructor is called at most one time, before any
            // instance constructor is invoked or member is accessed.
            static SimpleClass()
            {
                baseline = DateTime.Now.Ticks;
            }
        }
        // A static constructor does not take access modifiers or have parameters.
        // A class or struct can only have one static constructor.
        // Static constructors cannot be inherited or overloaded.
        // A static constructor cannot be called directly and is only meant to be called by the common language runtime(CLR). It is invoked 
        // automatically.
        // The user has no control on when the static constructor is executed in the program.
        // A static constructor is called automatically to initialize the class before the first instance is created or any static members 
        // are referenced.A static constructor will run before an instance constructor.A type's static constructor is called when a static 
        // method assigned to an event or a delegate is invoked and not when it is assigned. If static field variable initializers are 
        // present in the class of the static constructor, they will be executed in the textual order in which they appear in the class 
        // declaration immediately prior to the execution of the static constructor.
        // If you don't provide a static constructor to initialize static fields, all static fields are initialized to their default value 
        // as listed in Default values of C# types.
        // If a static constructor throws an exception, the runtime will not invoke it a second time, and the type will remain uninitialized 
        // for the lifetime of the application domain in which your program is running.Most commonly, a TypeInitializationException exception 
        // is thrown when a static constructor is unable to instantiate a type or for an unhandled exception occurring within a static 
        // constructor.For implicit static constructors that are not explicitly defined in source code, troubleshooting may require inspection 
        // of the intermediate language(IL) code.
        // The presence of a static constructor prevents the addition of the BeforeFieldInit type attribute.This limits runtime optimization.
        // A field declared as static readonly may only be assigned as part of its declaration or in a static constructor.When an explicit static 
        // constructor is not required, initialize static fields at declaration, rather than through a static constructor for better runtime optimization.
        public void SimpleClassUsage() 
        {
            Console.WriteLine(SimpleClass.baseline);
        }

        class NewSimpleClass : SimpleClass
        {
            public NewSimpleClass() : base()
            { }
        }
        // you can't override constructors. The concept makes no sense in C#, because constructors simply aren't invoked polymorphically. You 
        // always state which class you're trying to construct, and the arguments to the constructor.


        // 26. Can you use this keyword inside of a static method? - NO
        public static int StaticMethod()
        {
            //this.
            return 0;
        }

        // 27. What is the difference between using a static class and a Singleton pattern?

        // 28. What does immutable mean? Can you provide examples?

        // 29. How can you create delegates in C#?
        // A delegate is a reference type variable that holds the reference to a method. The reference can be changed at runtime.
        // Delegates are especially used for implementing events and the call-back methods. All delegates are implicitly derived from the System.Delegate class.
        delegate int NumberCalc(int n);
        public int Add(int p) 
        {
            return p + 1;
        }
        public int Mult(int p) 
        {
            return p * 2;
        }
        public void DelegateUsage() 
        {
            NumberCalc nc1 = new NumberCalc(Add);
            NumberCalc nc2 = new NumberCalc(Mult);

            int i = nc1(10);
            int j = nc2(2);
            Console.WriteLine("{0}, {1}", i, j);
        }



        // 30. Are delegates of a value or a reference type?
        // Delegates are ref. type -> One reason is clearly visible in the .NET Framework today. In the original design, there were two kinds of delegates: normal delegates and "multicast" delegates, 
        // which could have more than one target in their invocation list. The MulticastDelegate class inherits from Delegate. Since you can't inherit from a value type, Delegate had to be a reference type.

        // 31. What is the difference between events and multicast delegates?

        // 32. Is there any difference between Action and Function?
        public void ActionVsFunction()
        {
            Action<int> action = x => { Console.WriteLine(x); }; // action -> no return 
            Func<int, double> func = x => { return 1 / x; }; // returns value of last type
            // Predicate == Func<T, bool>
        }

        // 33. What are lambda expressions? What are they used for?

        // 34. Is it possible to access variables from the outside of a lambda expression?
        // The result variable should definitely be accessible from outside the scope of the lambda. That's a core feature of lambdas (or anonymous delegates for that matter, 
        // lambdas are just syntactic sugar for anonymous delegates), called a "lexical closure".
        public void AccessVariableOfLambda() 
        {
            string res = null;
            Action<int> act = i => { res = i.ToString(); };
            act(10);
            Console.WriteLine(res); // prints out 10
        }


        // 35. What is LINQ used for?

        // 36. What should usually be done inside of a catch statement?

        // 37. Does the following code make sense?
        public void Exceptions()
        {
            try
            {
                DoSomeWork();
            }
            catch (Exception ex) { }
            //catch (StackOverflowException ex) { }
            // A previous catch clause already catches all exceptions of this or of a super type 
        }

        public void DoSomeWork() { }

        // 38. What is reflection? Where can it be used?

        // 39. What are generics?

        // 40. What constrains can be applied to generics?

        // 41. Can Garbage Collection be forced manually?
        public void GCCall()
        {
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        // 42. What are the generations of.NET Garbage Collector?

        // 43. With the IDisposable interface, what logic is usually placed inside of the Dispose method?

        // 44. Can you extend the core.NET framework class with your own method?
        public void ExtensionOfFrameworkClass()
        {
            ArrayList ls = new ArrayList() { "a", "bs", "qwqertty" };
            ls.PrintSomeStuff(1); // yes
        }
    }

    // 17. Can you inherit from two interfaces with the same method name in both of them?
    public interface IOne
    {
        void MethodOne();
        void Method();
    }

    public interface ITwo
    {
        internal void MethodTwo();
        void Method();
    }

    public class Implement : IOne, ITwo
    {
        public void Method()
        {
            throw new NotImplementedException();
        }

        public void MethodOne()
        {
            throw new NotImplementedException();
        }

        internal void MethodTwo()
        {
            throw new NotImplementedException();
        }

        void ITwo.Method()
        {
            throw new NotImplementedException();
        }

        void ITwo.MethodTwo()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class AbstractClass
    {
        abstract public void DoSomething();

        static public void DoStatic()
        {
            Console.WriteLine("Static method in the abstract class");
        }
    }

    public class Shape
    {
        private int x;

        public Shape(int x)
        {
            this.x = x;
        }

        public int ShapeMethod()
        {
            return x;
        }
    }

    public class ShapeNew : Shape
    {
        public ShapeNew(int x) : base(x)
        {
        }

        public new int ShapeMethod()
        {
            return 0;
        }
    }

    public class ClassWithStatic
    {
        public static int X { get; set; }

        static ClassWithStatic()
        {
            X = 1;
            Console.WriteLine("Static called");
        }
    }

    // 16. Is it possible to specify access modifiers inside of an interface?
    public interface ITestInterface
    {
        void PublicMethod();
        public void NewPublicMethod();
        internal void IntMethod();
        //private void PrivMethod(); No
    }

    public static class SomeExtensions
    {
        public static void PrintSomeStuff(this ArrayList l, int i)
        {
            Console.WriteLine(l);
            Console.WriteLine(i);
        }
    }

    
}
