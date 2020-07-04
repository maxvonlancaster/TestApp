using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ConsoleAppTest.Services
{
    public class Playground
    {
        public void TestInterviewMethod()
        {
            char ch = 'g';
            string s = ch.ToString();
            string s1 = "I am a human being" + ch;
            Console.WriteLine(s1);

            NStruct n1 = new NStruct();
            NClass n2 = new NClass();
            n1.x = 10;
            n2.x = 10;
            MethodOne(n1);
            MethodTwo(n2);
            Console.WriteLine(n1.x); // 10
            Console.WriteLine(n2.x); // 20
            n1.StructMethod();

            NChild child = new NChild();
            child.x = 100;
            child.y = 50;
            NClass nClass = child;
            Console.WriteLine(nClass.x);
            NChild child1 = (NChild)nClass;
            Console.WriteLine(child1.y); // 50

            Child c = new Child();
            Base b = c;
            b.MethodB(); // Child : MethodB
            b.MethodC(); // Base : MethodC
            Child c1 = (Child)b;
            c1.MethodB(); // Child : MethodB
            c1.MethodC(); // Child : MethodC
        }

        public void MethodOne(NStruct n)
        {
            n.x = 20;
        }

        public void MethodTwo(NClass n)
        {
            n.x = 20;
        }


        public delegate void MyDelegate(int i);

        public void TestDelegate()
        {
            var del = new MyDelegate(Method);
            bool isDelegate = typeof(Delegate).IsAssignableFrom(del.GetType());
            Console.WriteLine(isDelegate);
            Console.WriteLine();

        }

        private void Method(int j)
        {

        }

        public void ReflectIsMethodExtension() 
        {
            var extensionClass = typeof(Extensions);
            var extensionMethod = extensionClass.GetMethods().FirstOrDefault(m => m.Name == "WordCount");
            var isExtension = extensionMethod.IsDefined(typeof(ExtensionAttribute), true);
            var parameter = extensionMethod.GetParameters().FirstOrDefault();
            //var modifier = parameter.GetRequiredCustomModifiers().FirstOrDefault().Name;

            //bool isExtension = extensionClass.IsAbstract && extensionClass.IsSealed && extensionMethod.IsStatic ;
        }


        public void CheckIfMethodIsAnonymous() 
        {
        
        }

        public void MethodWithAnon() 
        {
            
        }

        public static event EventHandler Show;

        public void CheckIfEvent() 
        {
            var type = typeof(Playground);

        }
    }

    public static class Extensions
    {
        public static int WordCount(this string word) 
        {
            return word.Length;
        }
    }

    public struct NStruct
    {
        public int x;

        public void StructMethod() 
        {
            Console.WriteLine("Struct method");
        }
    }

    public class NClass 
    {
        public int x;
    }

    public interface IInter { }

    public struct NewStruct : IInter { }

    public class NChild : NClass 
    {
        public int y;
    }

    public class Base 
    {
        public virtual void MethodB() 
        {
            Console.WriteLine("Base : MethodB");
        }

        public void MethodC() 
        {
            Console.WriteLine("Base : MethodC");
        }
    }

    public class Child : Base 
    {
        public override void MethodB()
        {
            Console.WriteLine("Child : MethodB");
        }

        public new void MethodC()
        {
            Console.WriteLine("Child : MethodC");
        }
    }
}
