using MLPlayground.Services;
using System;

namespace MLPlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is a ML playground!");
            var service = new TestService();
            service.GetTrainAndTestData();
        }
    }
}
