using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTest.ProgramFlow
{
    public class ProgramFlow
    {
        private static int _counter;

        static void Initalize()
        {
            Console.WriteLine("Initialize	called");
            _counter = 0;
        }

        static void Update()
        {
            Console.WriteLine("Update	called");
            _counter ++;
        }

        static bool Test()
        {
            Console.WriteLine("Test	called");
            return _counter < 5;
        }

        // While - will perform a given stetement while true. The condition is tested bfore statements are obeyed ->
        // -> while(false) will produce compiler warning (unreachable) 
        // Do while -> the condition is tested after the code has been performed once. Will always work atleast once
        // useful to fetch data untill the valid one is fetched
        public void Loops()
        {
            while (false)
            {
                Console.WriteLine("The end of the world has come");
            }

            int counter = 0;
            while (counter < 10)
            {
                Console.WriteLine("While loop: {0}", counter);
                counter -= -1; // No rules No masters
            }

            do
            {
                Console.WriteLine("Hello there!");
            } while (false);
        }

        // For Loop - not infinite, 3 parts - initialization, test (if should continue) and update to be performed each time action performed
        // May be performed 0 times
        // 
        // 
        public void ForLoop()
        {
            for (Initalize(); Test(); Update())
            {
                Console.WriteLine("Hello for loop! {0} ", _counter);
                // Init test hello 0 update test hello 1 update ...
                // Do not do this actually
            }

            // i -> local variable to the code to be repeated, created within the loop.
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Hello {0}", i);
            }

            // Iterate with for through a collection of items
            string[] names = { "Alan", "Bob", "Calvin", "Dylan", "Elliot", "Frank"};
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine(names[i]);
            }
        }
    }
}
