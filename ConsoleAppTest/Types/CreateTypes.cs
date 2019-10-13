using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTest.Types
{
    public class CreateTypes
    {
        struct StructStore
        {
            public int Data { get; set; }
        }

        class ClassStore
        {
            public int Data { get; set; }
        }

        struct Alien
        {
            public int X;
            public int Y;
            public int Lives;

            public Alien(int x, int y)
            {
                X = x;
                Y = y;
                Lives = 3;
            }

            public override string ToString()
            {
                return base.ToString();
            }
        }


        // The diff between reference and value types is crucial
        public void ValueAndReferenceTypes()
        {
            StructStore xs, ys;
            ys = new StructStore();
            ys.Data = 99;
            xs = ys;
            xs.Data = 100;
            Console.WriteLine("xStruct:	{0}", xs.Data); // 100
            Console.WriteLine("yStruct:	{0}", ys.Data); // 99

            ClassStore xc, yc;
            yc = new ClassStore();
            yc.Data = 99;
            xc = yc;
            xc.Data = 100;
            Console.WriteLine("xClass:	{0}", xc.Data); // 100
            Console.WriteLine("yClass:	{0}", yc.Data); // 100
        }

        // immutable - instances can not be changed
        // 
        // 
        public void ImmutableTypes()
        {
            //	Create	a	DateTime	for	today 
            DateTime date = DateTime.Now;
            //	Move	the	date	on	to	tomorrow 
            date = date.AddDays(1); // does not change content of type - creates new date
        }

        // Value types: structures and enums
        // Structures	can	contain	methods,	data	values,	properties	and	can	have constructors.
        // The constructor must initialize all data members in structure
        // 
        public void CreateStruct()
        {
            Alien a;
            a.X = 50;
            a.Y = 50;
            a.Lives = 3;
            Console.WriteLine("a	{0}", a.ToString());

            Alien x = new Alien(100, 100);
            Console.WriteLine("x	{0}", x.ToString());

            Alien[] swarm = new Alien[100];
            Console.WriteLine("swarm	[0]	{0}", swarm[0].ToString());
            Console.ReadKey();
        }

    }
}
