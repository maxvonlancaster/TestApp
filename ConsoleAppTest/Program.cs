using ConsoleAppTest.ProgramFlow;
using ConsoleAppTest.Types;
using System;
using ConsoleAppTest.ProgramFlow;
using ConsoleAppTest.DebugAndSecurity;
using ConsoleAppTest.DataAccess;
using ConsoleAppTest.Services;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new SpecialFeatures();
            service.UsingGoTo();
        }
    }
}
