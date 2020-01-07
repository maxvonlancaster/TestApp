using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeModel.Concurrency
{
    public class TaskParallelism
    {
        // Parallel Framework concepts and components
        // The Task Parallel Library (TPL) is a set of public types and APIs in the System.Threading and System.Threading.Tasks namespaces. 
        // The purpose of the TPL is to make developers more productive by simplifying the process of adding parallelism and concurrency to 
        // applications. The TPL scales the degree of concurrency dynamically to most efficiently use all the processors that are available. 
        // In addition, the TPL handles the partitioning of the work, the scheduling of threads on the ThreadPool, cancellation support, 
        // state management, and other low-level details. By using TPL, you can maximize the performance of your code while focusing on the 
        // work that your program is designed to accomplish.


        // Parallel LINQ
        // AsParallel() -> redistribute query to datasource. Datasource is divided into parts that are executed separately.
        public void ParallelLINQ()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, };
            var factorials = from n in numbers.AsParallel()
                             select Factorial(n);
            foreach (var n in factorials)
                Console.WriteLine(n);
            Console.ReadLine();
            var factorialsNew = numbers.AsParallel().Select(x => Factorial(x));

            // ForAll() -> prints out in the same thread as executed
            (from n in numbers.AsParallel()
             where n > 0
             select Factorial(n))
            .ForAll(Console.WriteLine);

            // AsOrdered() -> order in the same oerder as arguments are given:
            var factorialsOrdered = from n in numbers.AsParallel().AsOrdered()
                             where n > 0
                             select Factorial(n);
            // AsUnordered() -> when ordering no longer needed:
            var query = from n in factorialsOrdered.AsUnordered()
                        where n > 100
                        select n;
        }


        // Exception-Handling Tasks



        // Continuation with Tasks



        // Canceling Tasks



        // Working with AggregateException
        public void WorkWithAggregateException()
        {
            var t = Task.Run(() => { throw new Exception("This exception is expected!"); });
            try
            {
                t.Wait();
            }
            catch (AggregateException ae)
            {
                // Call the Handle method to handle the custom exception,
                // otherwise rethrow the exception.
                ae.Handle(ex =>
                {
                    if (ex is Exception)
                        Console.WriteLine(ex.Message);
                    return ex is Exception;
                });
            }
        }

        static int Factorial(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            Console.WriteLine($"Factorial of {x} is equal to {result}");
            return result;
        }


    }
}
