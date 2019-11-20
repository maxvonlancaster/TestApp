using ConsoleAppTest.Patterns.Creational.Singleton;
using ConsoleAppTest.Patterns.Creational.Builder;
using System;
using System.Collections.Generic;
using System.Text;
using ConsoleAppTest.Patterns.Creational.Prototype;

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

        // Prototype -> allows cloning of objects on the base of already created objects-prototypes. Gives technique for cloning
        // use when concrete type of new object has to be defined dynamically
        // when cloning is preferable to initialization; 
        public void ClientPrototype()
        {
            Prototype prototype = new ConcretePrototype1(1);
            Prototype clone = prototype.Clone();
            Console.WriteLine(clone.Id);
            prototype = new ConcretePrototype2(3);
            clone = prototype.Clone();
            Console.WriteLine(clone.Id);
        }
    }
}
