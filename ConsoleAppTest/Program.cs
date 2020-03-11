using ConsoleAppTest.ProgramFlow;
using ConsoleAppTest.Types;
using System;
using ConsoleAppTest.DebugAndSecurity;
using ConsoleAppTest.DataAccess;
using ConsoleAppTest.Services;
using ConsoleAppTest.Patterns;
using KnowledgeModel.Lang;
using System.Threading.Tasks;
using KnowledgeModel.Concurrency;
using KnowledgeModel.DbAccess;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new LangQ();
            service.SystemIONameSpace();
            //AsyncMethods().Wait();
            //Console.WriteLine(CalcService.Factorial(20));
        }

        static async Task AsyncMethods() 
        {
            var service = new BasicSynchronisation();
            await service.UsingSynchronisationContext();
        }
    }
}
