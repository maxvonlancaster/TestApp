using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppTest.ProgramFlow
{
    // How to create and manage tasks
    public class Tasks
    {
        private void DoWork()
        {
            Console.WriteLine("Work starting");
            Thread.Sleep(2000);
            Console.WriteLine("Work ending");
        }

        private void DoWork(int i)
        {
            Console.WriteLine("Work starting on {0}", i);
            Thread.Sleep(2000);
            Console.WriteLine("Work ending on {0}", i);
        }

        private int CalculateResult()
        {
            Console.WriteLine("Work starting");
            Thread.Sleep(2000);
            Console.WriteLine("Work ending");
            return 100;
        }

        private void Logger(int i)
        {
            Console.WriteLine("Logging {0}", i);
        }

        // Creates task, starts it running and then waits for the task to complete
        // Can also be created and started using a single method run. Can use this way 
        // If you want to start them and have them run to completion
        public void CreateTask()
        {
            Task newTask = new Task(() => DoWork());
            newTask.Start();
            newTask.Wait();

            Task newRunTask = new Task(() => DoWork());
            newRunTask.Wait();
        }

        // Task can return value. Program will wait for the task to deliver the result when the result property of the task instance is read
        // Task.Run uses TaskFactory.StartNew
        // 
        public void TaskReturnValue()
        {
            Task<int> task = Task.Run(() => 
            {
                return CalculateResult();
            });

            Console.WriteLine("Task result: " + task.Result);
        }

        // Task.Waitall - to pause a prog. untill a number of tasks are completed
        // Another use - provide a place to catch any exceptions that can be thrown by tasks (note that they are aggregated)
        // Task.WaitAny - pauses program untill one task completes
        // 
        public void TaskWaitall()
        {
            Task[] tasks = new Task[10];

            for(int i = 0; i < 10; i++)
            {
                int taskNum = i; // make a local copy of loop count so that the correct number is passed to lambda, 
                // otherwise 10 is passed for all tasks.

                tasks[i] = Task.Run(() => DoWork(i));
            }

            Task.WaitAll(tasks);
            Console.WriteLine("Finished processing!");
        }

    }
}