using Mathematics.Calculation;
using System;

namespace Mathematics
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new MatrixCalc();
            service.MatrixRangChecker();
            Console.WriteLine("This is math playground!");
        }
    }
}
