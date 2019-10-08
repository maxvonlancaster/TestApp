using ConsoleAppTest.ProgramFlow;
using System;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var multiThreading = new MultiThreading();
            multiThreading.ParellelFor();
            Console.WriteLine("Hello World!");
        }
    }
}
