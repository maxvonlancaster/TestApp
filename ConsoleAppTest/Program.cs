using ConsoleAppTest.ProgramFlow;
using ConsoleAppTest.Types;
using System;
using ConsoleAppTest.ProgramFlow;
using ConsoleAppTest.DebugAndSecurity;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new ValidateInput();
            service.CreatingXml();
        }
    }
}
