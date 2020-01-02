using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KnowledgeModel.Concurrency
{
    public class AsyncBasics
    {
        private static void Method()
        {
            Thread.Sleep(20);
        }

        static int val;

        // Pausing for a Period of Time (chapter 2.1)
        // The Task type has a static method Delay that returns a task that completes after the specified time.
        static async Task<T> DelayResult<T>(T result, TimeSpan delay)
        {
            await Task.Delay(delay);
            return result;
        }

        // Reporting progress (chapter 2.3)
        // Use the provided IProgress<T> and Progress<T> types. -> invokes callbacks for each reported progress value.
        // Any handler provided to the constructor or event handlers registered with the ProgressChanged event are invoked 
        // through a SynchronizationContext instance captured when the instance is constructed. If there is no current 
        // SynchronizationContext at the time of construction, the callbacks will be invoked on the ThreadPool.
        static async Task MyMethodAsync()
        {
            IProgress<int> p = new Progress<int>(i => val = i);
            for (int i = 0; i <= 100; i++)
            {
                await Task.Run(() => Method());
                Console.WriteLine("Progress: " + i);
                p.Report(i);
            }
        }



        // Waiting for a Set of Tasks to Complete (chapter 2.4)
        // The framework provides a Task.WhenAll method for this purpose. This method takes several tasks and returns a task 
        // that completes when all of those tasks have completed
        static async Task WaitingSet() 
        {
            Task task1 = Task.Run(() => 
            {
                Thread.Sleep(1000);
                Console.WriteLine("t1");
            });
            Task task2 = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("t2");
            });
            Task task3 = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("t3");
            });
            Task t = Task.WhenAll(task1, task2, task3);
            await t;
        }

        // Waiting for Any Task to Complete(chapter 2.5)


        // Processing Tasks as They Complete(chapter 2.6)


        // Avoiding Context for Continuations(chapter 2.7)


        // Handling Exceptions from async Task Methods(chapter 2.8)


        // Handling Exceptions from async Void Methods(chapter 2.9)

    }
}
