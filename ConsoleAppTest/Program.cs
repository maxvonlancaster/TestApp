﻿using ConsoleAppTest.ProgramFlow;
using ConsoleAppTest.Types;
using System;
using ConsoleAppTest.DebugAndSecurity;
using ConsoleAppTest.DataAccess;
using ConsoleAppTest.Services;
using ConsoleAppTest.Patterns;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new PatternService();
            service.CreateSingleton();
        }
    }
}
