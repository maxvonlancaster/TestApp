using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppTest.ProgramFlow
{
    // Asynchronous programming - the operations are not
    // synchronized.When you design asynchronous solutions that use multi-threading
    // you must be very careful to ensure that uncertainty about the timings of thread
    //    activity does not affect the working of the application or the results that are
    // produced. You’ll discover how to synchronize access to resources
    // that your application uses. You will see that if access to resources is not
    // synchronized correctly it can result in programs calculating the wrong result.A
    // badly written multi-threaded application might even get stuck because two
    // processes are waiting for each other to complete. You’ll discover how to stop
    // tasks that may have got stuck and how to ensure that threads work together
    // irrespective of the order in which they are performed.
    public class ManageMultithreading
    {
        private int[] _items = Enumerable.Range(0, 50000001).ToArray();

        // When an application is spread over several asynchronous tasks, it becomes
        // impossible to predict the sequencing and timing of individual actions.You need
        // to create applications with the understanding that any action may be interrupted
        // in a way that has the potential to damage your application.
        // Let’s start with a simple application that adds up the numbers in an array.
        // 
        // 
        public void SingleTaskSumming()
        {
            long total = 0;
            for (int i = 0; i < _items.Length; i++)
                total += _items[i];
            Console.WriteLine("Total is: {0}", total);
            // Total is: 1250000025000000
        }

        // 
        // 
        // 
        public void BadTaskInteraction()
        {

        }

        // 
        // 
        // 
        public void UsingLocking()
        {

        }


        // 
        // 
        // 
        public void SensibleLocking()
        {

        }

        // 
        // 
        // 
        public void UsingMonitors()
        {

        }

        // 
        // 
        // 
        public void SequentialLocking()
        {

        }

        // 
        // 
        // 
        public void DeadLockedTasks()
        {

        }

        // 
        // 
        // 
        public void InterlockTotal()
        {

        }

        // 
        // 
        // 
        public void CancellATask()
        {

        }

        // 
        // 
        // 
        public void CancellWithException()
        {

        }

        // 
        // 
        // 
        public void UnsafeThreadMethod()
        {

        }
    }
}
