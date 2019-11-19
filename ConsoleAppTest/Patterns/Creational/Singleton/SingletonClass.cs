using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTest.Patterns.Creational.Singleton
{
    // Guarantees that only one instance of object will be created, and gives acces point to that instance
    class SingletonClass
    {
        private static SingletonClass instance;

        private SingletonClass()
        {
        }

        public static SingletonClass getInstance()
        {
            if (instance == null)
                instance = new SingletonClass();
            return instance;
        }
    }
}
