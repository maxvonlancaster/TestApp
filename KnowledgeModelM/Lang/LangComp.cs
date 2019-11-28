using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeModel.Lang
{
    public class LangComp
    {
        // Reflection - process of typediscovery in the runtime
        public void TypeReflection()
        {

        }

        public void CustomAttributes()
        {

        }

        public void DisposeAndFinalizePatterns()
        {

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
            var array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
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
    }
}
