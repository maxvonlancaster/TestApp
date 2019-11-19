using ConsoleAppTest.Patterns.Creational.Singleton;
using ConsoleAppTest.Patterns.Creational.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTest.Patterns
{
    class PatternService
    {
        public void CreateSingleton()
        {
            var instance = SingletonClass.getInstance();
            var instanceNew = SingletonClass.getInstance();
            Console.WriteLine("{0}; {1}", instance.GetHashCode(), instanceNew.GetHashCode());
        }

        // Builder -> separate constructor of a complex object from its representation
        public void ClientBuilder()
        {
            Builder builder = new ConcreteBuilder();
            Director director = new Director(builder);
            director.Construct();
            Product product = builder.GetProduct();
            Console.WriteLine(product.ToString());
        }
    }
}
