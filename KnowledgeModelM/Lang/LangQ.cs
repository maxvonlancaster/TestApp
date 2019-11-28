using System;
using System.Collections;
using System.Collections.Generic;
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
        public struct Point
        {
            public double X { get; set; }
            public double Y { get; set; }
            //public readonly override string ToString() => "Point";
        }
    }
}
