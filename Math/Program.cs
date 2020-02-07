using Mathematics.Approximation;
using Mathematics.Calculation;
using System;

namespace Mathematics
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new NumericalApproximation();
            service.BabylonianApproximation();
            Console.WriteLine("This is math playground!");
        }
    }
}
