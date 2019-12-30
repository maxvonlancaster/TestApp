using ConsoleAppTest.DebugAndSecurity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppTest.Services
{
    public class TestService
    {
        object a = new object();
        object b = new object();

        public void TestMethod()
        {
            var переменная = "Cyrillic variable";
            Console.WriteLine(переменная);

            for (var i = 0; i < 10; i++) { }

            // deadlock
            Thread thread1 = new Thread(Task1);
            Thread thread2 = new Thread(Task2);
            thread1.Start();
            thread2.Start();

            Console.WriteLine("Finished ");
        }

        public void Task1() 
        {
            lock (a)
            {
                Thread.Sleep(10000);
                Console.WriteLine("ab1");

                lock (b) 
                {
                    Thread.Sleep(10000);
                    Console.WriteLine("ab2");
                }
            }
        }

        public void Task2() 
        {
            lock (b)
            {
                Thread.Sleep(10000);
                Console.WriteLine("ba1");

                lock (a) 
                {
                    Thread.Sleep(10000);
                    Console.WriteLine("ba2");
                }
            }
        }
    }
}
