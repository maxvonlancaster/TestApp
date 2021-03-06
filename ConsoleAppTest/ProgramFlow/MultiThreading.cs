﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppTest.ProgramFlow
{
    // You can think of a task as an abstraction of a unit of work to be performed. The work itself will be described by some C# program code, perhaps by a method or
    // a lambda expression.A task may be performed concurrently with other tasks.The Task Parallel Library(TPL) provides a range of resources that allow you
    // to use tasks in an application.The Task.Parallel class in the library provides three methods that can be used to create applications that contain tasks
    // that execute in parallel.
    class MultiThreading
    {
        private void Task1()
        {
            Console.WriteLine("Task 1 started");
            Thread.Sleep(2000);
            Console.WriteLine("Task 1 ending");
            return;
            Console.WriteLine("I am not executed");
        }

        private void Task2()
        {
            Console.WriteLine("Task 2 started");
            Thread.Sleep(2000);
            Console.WriteLine("Task 2 ending");
        }

        private void WorkOnItem(object item)
        {
            Console.WriteLine("Started work on item: " + item);
            Thread.Sleep(2000);
            Console.WriteLine("Finished work on item: " + item);
        }

        // The	Task.Parallel class	can	be	found	in	the System.Threading.Tasks  namespace. 
        // The Parallel.Invoke method accepts a   number of  Action delegates   and creates a Task 
        // for	each of  them.An Action  delegate    is	an encapsulation   of a   method that    
        // accepts no parameters and does not	return	a result.	It can be replaced    with a   lamba expression
        public void ParallelInvoke()
        {
            Parallel.Invoke(() => Task1(), () => Task2());
            Console.WriteLine("Finished processing!");
            // The Parallel.Invoke method can start a large number of tasks at once.You have no control over the order in which the tasks are started or which
            // processor they are assigned to. The Parallel.Invoke method returns when all of the tasks have completed.
        }

        // Task.Parallel provides a foreach method that performs a parallel implementation of foreach loop
        // Accepts two parameters => enumerable of items and an action to be performed on each of the items
        public void ParallelForEach()
        {
            var items = Enumerable.Range(0, 400).ToList();
            Parallel.ForEach(
                items,
                item =>
                {
                    WorkOnItem(item);
                });
            Console.WriteLine("Finished processing!");
        }

        // Parallel.For => to parallelize the execution of a for loop
        // Counter start, length and lambda expression
        public void ParellelFor()
        {
            var items = Enumerable.Range(0, 400).ToArray();
            Parallel.For(0, items.Count(), i =>
            {
                WorkOnItem(items[i]);
            });
            Console.WriteLine("Finished processing!");
        }

        // The lambda expression can be provided with additional parameter ParallelLoopState that controls to control the iteration process
        // The for and foreach methods return ParallelLoopResult that allows to determine wether the parallel loop was succesfully completed
        // Stop stops all iterations, loopState.Break() will allow iterations < 200 to be finished
        // Iterations > 200 may also run inb4
        public void ManagingForLoop()
        {
            var items = Enumerable.Range(0, 400).ToArray();

            ParallelLoopResult result = Parallel.For(0, items.Count(), (int i, ParallelLoopState loopState) =>
            {
                if (i == 200)
                    loopState.Stop();

                WorkOnItem(items[i]);
            });

            Console.WriteLine("Completed: " + result.IsCompleted);
            Console.WriteLine("Items: " + result.LowestBreakIteration);
            Console.WriteLine("Finished processing!");
        }
    }
}
