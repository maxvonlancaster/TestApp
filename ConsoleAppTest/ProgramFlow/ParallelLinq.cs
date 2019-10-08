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

        public void PlinqAsOrdered() { }
    }
}
