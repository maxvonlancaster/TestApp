using ConsoleAppTest.ProgramFlow;
using ConsoleAppTest.Types;
using System;
using ConsoleAppTest.DebugAndSecurity;
using ConsoleAppTest.DataAccess;
using ConsoleAppTest.Services;
using ConsoleAppTest.Patterns;
using KnowledgeModel.Lang;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new SpecialFeatures();
            service.Pointers();
            //Console.WriteLine(CalcService.Factorial(20));
        }
    }
}
