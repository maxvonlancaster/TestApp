using ConsoleAppTest.ProgramFlow;
using System;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new Tasks();
            service.TaskWaitall();
        }
    }
}
