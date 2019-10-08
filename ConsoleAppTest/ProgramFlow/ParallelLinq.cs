using ConsoleAppTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppTest.ProgramFlow
{
    // PLINQ can be used to allow elements of a query to be executed in a parallel
    public class ParallelLinq
    {
        private User[] GetData()
        {
            return new User[] {
                new User { Name = "Allan", City = "Seattle" },
                new User { Name = "Bob", City = "NY" },
                new User { Name = "Carl", City = "LA" },
                new User { Name = "Dylan", City = "LA" },
                new User { Name = "Erlond", City = "LA" },
                new User { Name = "Felix", City = "Seattle" },
                new User { Name = "Garold", City = "NY" },
                new User { Name = "Henry", City = "Seattle" },
                new User { Name = "Itan", City = "LA" },
                new User { Name = "Jenx", City = "Seattle" },
                new User { Name = "Nolan", City = "NY" },
                new User { Name = "Meryl", City = "Seattle" },
                new User { Name = "L", City = "NY" },
            };
        } 

        private bool CheckCity(string name)
        {
            if(name == "")
                throw new ArgumentException(name);
            
            return name == "Seattle";
        }

        // The AsParallel method from system.linq examines the query and determines if the parallelization would speed it up or not 
        // if yes - query is broken up into processes and executed parallely
        // if no - no. Design with that in mind
        // it is possible you might get the wrong answers
        public void PlinqAsParallel()
        {
            var users = GetData();

            var result = from user in users.AsParallel()
                         where user.City == "Seattle"
                         select user;
            foreach (var user in result)
                Console.WriteLine(user.Name);

            Console.WriteLine("Finished processing!");
        }

        // To be executed on maximum 4 processors
        // Enforces parallelism independently of wether it is optional
        // May produce data in different order
        public void InformingParallelization()
        {
            var users = GetData();

            var result = from user in users.AsParallel()
                         .WithDegreeOfParallelism(4)
                         .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                         where user.City == "Seattle"
                         select user;
            foreach (var user in result)
                Console.WriteLine(user.Name);

            Console.WriteLine("Finished processing!");
        }

        // 	Organizes the output so	that it	is in the same order as	the	original data. This	can	slow down the query. 
        public void PlinqAsOrdered()
        {
            var users = GetData();

            var result = from user in users.AsParallel()
                         .AsOrdered()
                         where user.City == "Seattle"
                         select user;
            foreach (var user in result)
                Console.WriteLine(user.Name);

            Console.WriteLine("Finished processing!");
        }

        // The query requests that the result be ordered by users name, and this ordering is preserved by the use of AsSequential
        // The AsSequential executes query in order whereas AsOrdered returns a sorted result but does not necessarily run the query in order.
        public void PlinqAsSequential()
        {
            var users = GetData();

            var result = (from user in users.AsParallel() 
                            where user.City == "Seattle"
                            orderby (user.Name)
                            select new {Name = user.Name }).AsSequential().Take(4);  

            foreach (var user in result)
                Console.WriteLine(user.Name);

            Console.WriteLine("Finished processing!");
        }

        // ForAll - iterate over res-s. Diff. from foreach - iteration takes place in parallel and will start before query is complete
        public void PlinqForAll()
        {
            var users = GetData();

            var result = from user in users.AsParallel()
                         where user.City == "Seattle"
                         select user;
            result.ForAll(user => Console.WriteLine(user.Name));
            Console.WriteLine("Finished processing!");
        }

        // If any queries generate exceptions an AggregateException will be thrown when query complete. Contains list (InnerExceptions) of the exceptions that were thrown 
        // during the query
        public void PlinqExceptions()
        {
            var users = GetData();
            try
            {
                var result = from user in users.AsParallel() 
                                where CheckCity(user.City)
                                select user;
                result.ForAll(user => Console.WriteLine(user.Name));
            }
            catch(AggregateException e)
            {
                Console.WriteLine(e.InnerExceptions.Count + " exceptions. ");
            }
        }
    }
}
