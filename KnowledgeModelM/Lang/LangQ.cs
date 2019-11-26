using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using static System.DayOfWeek;
using static System.Math;

namespace KnowledgeModel.Lang
{
    public class LangQ
    {
        // Properties and automatic properties
        public int Id { get; set; } // automatic property -> no additional logic of access
        public string Name { get; set; } = "Name"; // in C#6 and later -> automatic prop. can be initialized
        // 


        // Static using -> allows all the accessible static members of a type to be imported, making them available without qualification in subseq. code.
        // great if you have a set of functions related to certain domain
        public void StaticUsing()
        {
            WriteLine(Sqrt(5));
            WriteLine(Friday - Monday);
        }


        // Span<T>
        // Typesafe realisation of contiguous region of any memory
        public void SpanT()
        {
            var array = new byte[100];
            var arraySpan = new Span<byte>(array);
            byte data = 0;
            for (int ctr = 0; ctr < arraySpan.Length; ctr++)
                arraySpan[ctr] = data++;

            int arraySum = 0;
            foreach (var value in array)
                arraySum += value;

            Console.WriteLine($"The sum is {arraySum}");
        }

        public void SpanArray()
        {
            var array = new int[] {1,2,3,4,5,6,7,8,9,10};
            var slice = new Span<int>(array, 2, 5);

            for (int i = 0; i < slice.Length; i++)
            {
                slice[i] *= 2;
            }

            foreach (var value in array)
                Console.Write($"{value} ");
            Console.WriteLine(); // output 1 2 6 8 ...
        }

        public void ReadOnlySpan()
        {
            string contentLength = "Content-Length: 132";
            var charSpan = new ReadOnlySpan<char>(contentLength.ToCharArray());
            var slice = charSpan.Slice(16); // no creation of new string -> benefit
            int length;
            int.TryParse(slice, out length);
            Console.WriteLine($"Length: {length}");
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
