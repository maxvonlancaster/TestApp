using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
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
        // For example, you could request stock quotes from multiple web services simultaneously, but you only care about the 
        // first one that responds.
        // Use the Task.WhenAny method. This method takes a sequence of tasks and returns a task that completes when any of the 
        // tasks complete.The result of the returned task is the task that completed
        public async Task WaitingAny()
        {
            string[] urls =
            {
                "https://www.google.com.ua/",
                "https://www.bing.com/"
            };

            var httpClient = new HttpClient();
            Task<string> task1 = httpClient.GetStringAsync(urls[0]);
            Task<string> task2 = httpClient.GetStringAsync(urls[1]);

            Task<string> completedTask = await Task.WhenAny(task1, task2);
            string data = await completedTask;
            Console.WriteLine(data);
        }
        // The task returned by Task.WhenAny never completes in a faulted or canceled state. It always results in the first Task to complete; 
        // if that task completed with an exception, then the exception is not propogated to the task returned by Task.WhenAny.For this
        // reason, you should usually await the task after it has completed
        // When the first task completes, consider whether to cancel the remaining tasks. If the other tasks are not canceled but are 
        // also never awaited, then they are abandoned.Aban‐doned tasks will run to completion, and their results will be ignored.Any exceptions
        // from those abandoned tasks will also be ignored.



        // Processing Tasks as They Complete(chapter 2.6)
        // You have a collection of tasks to await, and you want to do some processing on each task after it completes.However, you want 
        // to do the processing for each one as soon as it completes, not waiting for any of the other tasks.
        static async Task<int> DelayAndReturnAsync(int val)
        {
            await Task.Delay(TimeSpan.FromSeconds(val));
            return val;
        }

        static async Task AwaitAndProcessAsync(Task<int> task)
        {
            var result = await task;
            Trace.WriteLine(result);
        }

        // This method now prints "1", "2", and "3".
        public async Task ProcessTasksAsync()
        {
            // Create a sequence of tasks.
            Task<int> taskA = DelayAndReturnAsync(2);
            Task<int> taskB = DelayAndReturnAsync(3);
            Task<int> taskC = DelayAndReturnAsync(1);
            var tasks = new[] { taskA, taskB, taskC };
            var processingTasks = (from t in tasks
                                   select AwaitAndProcessAsync(t)).ToArray();
            // Await all processing to complete
            await Task.WhenAll(processingTasks);
        }




        // Avoiding Context for Continuations(chapter 2.7)
        // When an async method resumes after an await, by default it will resume executing
        // within the same context.This can cause performance problems if that context was a UI
        // context and a large number of async methods are resuming on the UI context.
        // To avoid resuming on a context, await the result of ConfigureAwait and pass false for its continueOnCapturedContext parameter:
        async Task ResumeOnContextAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            // This method resumes within the same context.
        }
        async Task ResumeWithoutContextAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);
            // This method discards its context when it resumes.
        }


        // Handling Exceptions from async Task Methods(chapter 2.8)
        // Fortunately, handling exceptions from async Task methods is straightforward.
        static async Task ThrowExceptionAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            throw new InvalidOperationException("Test");
        }
        static async Task TestAsync()
        {
            try
            {
                await ThrowExceptionAsync();
            }
            catch (InvalidOperationException)
            {
            }
        }



        // Handling Exceptions from async Void Methods(chapter 2.9)
        // You have an async void method and need to handle exceptions propagated out of that method.
        // There is no good solution. If at all possible, change the method to return Task instead of void.
    }
}
