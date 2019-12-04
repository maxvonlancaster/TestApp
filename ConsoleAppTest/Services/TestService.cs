using ConsoleAppTest.DebugAndSecurity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTest.Services
{
    public class TestService
    {
        public void TestMethod()
        {
            var переменная = "Cyrillic variable";
            Console.WriteLine(переменная);

            for (var i = 0; i < 10; i++) { }
        }
    }
}
