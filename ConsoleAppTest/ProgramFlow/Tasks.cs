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

        private void DoOtherWork()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Other work");
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

        private void DoChild(object state)
        {
            Console.WriteLine("Child starting on {0}", state);
            Thread.Sleep(2000);
            Console.WriteLine("Child ending on {0}", state);
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

        // Continuation task can be nominated to execute when existing one(antedecent) finishes, and its output can be used as an input for the continuation one
        // Can be used to create pipeline of operations, with each one starting when previous one finishes
        // Task object exposes ContinueWith method that can be used for that
        // 
        public void ContinuationTask()
        {
            Task task = Task.Run(() => DoWork());
            task.ContinueWith((prevTask) => DoOtherWork());

            // ContinueWith has an overload that specifies when a given continuation task has to run -> parameter TaskContinuationOptions
            task.ContinueWith((prevTask) => DoOtherWork(), TaskContinuationOptions.OnlyOnRanToCompletion); // only runs when previous is succesfull
            task.ContinueWith((prevTask) => DoOtherWork(), TaskContinuationOptions.OnlyOnFaulted); // only when previous fails

            Console.WriteLine("Finished processing!");
        }

        // Code	running	inside	a	parent	Task	can	create	other	tasks,	but	these	“child”	tasks will	execute	independently	
        // of the parent	in	which	they	were	created.	Such	tasks are	called	detached	child	tasks	or	detached	
        // nested	tasks.	A	parent	task	can	create child	tasks	with	a	task	creation	option	that	specifies	that	
        // the	child	task	is	attached to	the	parent.	The	parent	class	will	not	complete	until	all	of	the	attached	child tasks	have	
        // completed. 
        // 
        public void ChildTasks()
        {
            var parentTask = Task.Factory.StartNew(() => {
                Console.WriteLine("Parent starts");
                for (int i = 0; i < 10; i++)
                {
                    int taskNo = i;
                    Task.Factory.StartNew(
                        (x) => DoChild(x), // lambda
                        taskNo, // state object
                        TaskCreationOptions.AttachedToParent
                    );
                }
            });
            parentTask.Wait(); // Wait for all attached child tasks to complete

            // Can use TaskCreationOptions.DenyAttachedTasks. When using Task.Run it is default => cant have attached children.
            Console.WriteLine("Finished processing!");
        }

        // 
        // 
        // 
        // 
        public void CreateThread()
        {

        }
    }
}