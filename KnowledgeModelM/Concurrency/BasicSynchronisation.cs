using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace KnowledgeModel.Concurrency
{
    public class BasicSynchronisation
    {
        // 1. Synchronization Essentials
        // Synchronization is a technique that allows only one thread to access the resource for the particular time. 
        // No other thread can interrupt until the assigned thread finishes its task.
        // In multithreading program, threads are allowed to access any resource for the required execution time.
        // Threads share resources and executes asynchronously. Accessing shared resources (data) is critical task that sometimes 
        // may halt the system. We deal with it by making threads synchronized.
        // It is mainly used in case of transactions like deposit, withdraw etc.
        public void PrintStuff() 
        {
            for (int i = 1; i <= 10; i++)
            {
                Thread.Sleep(100);
                Console.WriteLine(i);
            }
        }

        // No synchronisation:
        public void NoSynch() 
        {
            Thread t1 = new Thread(PrintStuff);
            Thread t2 = new Thread(PrintStuff);
            t1.Start();
            t2.Start();
        }

        // 2. Locking
        // In this example, we are using lock. This example executes synchronously. In other words, there is no context-switching between 
        // the threads. In the output section, we can see that second thread starts working after first threads finishes its tasks.
        public object Obj = new object();

        public void PrintStuffLocked()
        {
            lock (Obj) {
                for (int i = 1; i <= 10; i++)
                {
                    Thread.Sleep(100);
                    Console.WriteLine(i);
                }
            }
        }

        public void LockUsage() 
        {
            Thread t1 = new Thread(PrintStuffLocked);
            Thread t2 = new Thread(PrintStuffLocked);
            t1.Start();
            t2.Start();
        }


        // 3. Thread Safety
        // Thread safety is a concept applicable in the context of multi-threaded programs. Multiple thread can access to the same address 
        // space at the same time. So, they can write to the exact same memory location at the same time. It is a defining property of threads. 
        // So, this property of thread is not good for the functionality.

        // So, Thread safety is a technique which manipulates shared data structure in a manner that guarantees the safe execution of a piece 
        // of code by the multiple threads at the same time. A code is called thread safe if it is being called from multiple threads 
        // concurrently without the breaking of functionalities.
        // Thread safety removes the following conditions in the code: 1)Race Condition 2)Deadlocks



        // 4. Signaling with Event Wait Handles
        // This is a class, which allows the threads to interact with each other by notifying through the signals.
        // EventWaithandle are the events, which signals and releases one or more waiting threads and once the threads are released, 
        // EventWaitHandle is reset; either automatically or manually.

        // WaitOne() - Blocks the current thread until a current WaitHandle receives the signal.
        // Set() - Sets the state of the event to be signaled, unblocking one or more waiting threads to execute.
        // Reset() - Resets the state of the event to non-signaled to block the threads.
        private EventWaitHandle _waitHandle = new AutoResetEvent(false);

        public void SignalingWithEvent() 
        {
            Thread t1 = new Thread(PrintStuffLocked);
            Thread t2 = new Thread(PrintStuffLocked);
            t1.Start();
            t2.Start();
            _waitHandle.Set();
        }


        // 5. Synchronization Context
        // Provides the basic functionality for propagating a synchronization context in various synchronization models.
        // The purpose of the synchronization model implemented by this class is to allow the internal asynchronous/synchronous 
        // operations of the common language runtime to behave properly with different synchronization models. This model also simplifies 
        // some of the requirements that managed applications have had to follow in order to work correctly under different synchronization 
        // environments. Providers of synchronization models can extend this class and provide their own implementations for these methods.
        public void UsingSynchronisationContext() 
        {
            var context = SynchronizationContext.Current;
            Thread t1 = new Thread(PrintStuffLocked);
            Thread t2 = new Thread(PrintStuffLocked);
            t1.Start();
            t2.Start();
            context = SynchronizationContext.Current;
        }

    }
}
