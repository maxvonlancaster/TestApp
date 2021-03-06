﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeModel.Concurrency
{
    public class ConcComp
    {
        // 1.1 Introduction to concurrency 

        // Concurrency -> doing more than one thing at a time
        // Multithreading  -> A form of concurrency that uses multiple threads of execution
        // Parallel Processing -> Doing lots of work by dividing it up among multiple threads that run concurrently
        // Asynchronous Programming -> A form of concurrency that uses futures or callbacks to avoid unnecessary threads.

        // A future (or promise) is a type that represents some operation that will complete in the future.The modern future types in 
        //.NET are Task and Task<TResult>.Older asynchronous APIs use callbacks or events instead of futures.Asynchronous programming
        // is centered around the idea of an asynchronous operation: some operation that is started that will complete some time later.W



        // 1.2 Introduction to Asynchronous Programming 
        public async Task DoSomethingAsync()
        {
            // async keyword -> to enable await keyword within that method
            int val = 13;

            // asynchronously wait 1 sec
            await Task.Delay(TimeSpan.FromSeconds(1));

            val *= 2;

            // asynchronously wait 1 sec
            await Task.Delay(TimeSpan.FromSeconds(1));

            Trace.WriteLine(val);

            // An async method begins executing synchronously, just like any other method. Within  an async method, the await keyword performs 
            // an asynchronous wait on its argument. First, it checks whether the operation is already complete; if it is, it continues executing
            //(synchronously).Otherwise, it will pause the async method and return an incomplete task.When that operation completes some time later, 
            // the async method will resume executing.

        }

        // To awaoid freezing of app (when using DoSomethingNewAsync().Result) -> ConfigureAwait -> 
        // The following code will start on the calling thread, and after it is paused by an await, it will resume on a thread-pool thread:
        public async Task DoSomethingNewAsync()
        {
            int val = 13;

            // asynchronously wait 1 sec
            await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);

            val *= 2;

            // asynchronously wait 1 sec
            await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);
            // good practice to always call ConfigureAwait in your core “library” methods, and only resume the context when you need it—in 
            // your outer “user interface” methods.

            Trace.WriteLine(val);
        }



        // 1.6 Introduction to Multithreaded Programming 
        // A thread is an independent executor.Each process has multiple threads in it, and each of those threads can be doing different things 
        // simultaneously.Each thread has its own independent stack but shares the same memory with all the other threads in a process.
        // In some applications, there is one thread that is special.User interface applications have a single UI thread; Console applications have a single main thread.

        // Every .NET application has a thread pool. The thread pool maintains a number of worker threads that are waiting to execute whatever work 
        // you have for them to do. The thread pool is responsible for determining how many threads are in the thread pool at any time.

        // There is almost no need to ever create a new thread yourself.The only time you should
        // ever create a Thread instance is if you need an STA thread for COM interop.





        // 1.7 Introduction to Concurrent Applications 

    }
}
