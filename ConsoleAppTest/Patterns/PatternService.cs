using ConsoleAppTest.Patterns.Creational.Singleton;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTest.Patterns
{
    class PatternService
    {
        public void CreateSingleton()
        {
            var instance = SingletonClass.getInstance();
            var instanceNew = SingletonClass.getInstance();
            Console.WriteLine("{0}; {1}", instance.GetHashCode(), instanceNew.GetHashCode());
        }
    }
}
