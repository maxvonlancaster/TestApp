using ConsoleAppTest.ProgramFlow;
using ConsoleAppTest.Types;
using System;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new ConsumeTypes();
            service.InteractionWithExcel();
        }
    }
}
