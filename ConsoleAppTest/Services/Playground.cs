using System;
using System.Collections.Generic;
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

        //public class NClass { }
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
