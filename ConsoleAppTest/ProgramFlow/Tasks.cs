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

        private int CalculateResult()
        {
            Console.WriteLine("Work starting");
            Thread.Sleep(2000);
            Console.WriteLine("Work ending");
            return 100;
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

        
    }
}