using ConsoleAppTest.Patterns.Creational.Singleton;
using ConsoleAppTest.Patterns.Creational.Builder;
using System;
using System.Collections.Generic;
using System.Text;
using ConsoleAppTest.Patterns.Creational.Prototype;
using ConsoleAppTest.Patterns.Creational.Factory;
using ConsoleAppTest.Patterns.Creational.AbstractFactory;

namespace ConsoleAppTest.Patterns
{
    class PatternService
    {
        /// <summary>
        /// CREATIONAL
        /// </summary>
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
            Creational.Builder.Product product = builder.GetProduct();
            Console.WriteLine(product.ToString());
        }

        // Prototype -> allows cloning of objects on the base of already created objects-prototypes. Gives technique for cloning
        // use when concrete type of new object has to be defined dynamically; when cloning is preferable to initialization; 
        public void ClientPrototype()
        {
            Prototype prototype = new ConcretePrototype1(1);
            Prototype clone = prototype.Clone();
            Console.WriteLine(clone.Id);
            prototype = new ConcretePrototype2(3);
            clone = prototype.Clone();
            Console.WriteLine(clone.Id);
        }

        // Factory -> creational pattern that uses a spezialized object to create other obj-s, abstracting the use of concrete objects. 
        public void FactoryClient()
        {
            Creator creator = new ConcreteCreatorA();
            Creational.Factory.Product product = creator.FactoryMethod();
        }

        // Abstract factory gives interface for creation of the famillies of interconnected objects with a given interfaces without specifing concrete 
        // types of given objects.
        public void AbstractFactoryClient()
        {
            AbstractFactory factory = new ConcreteFactory1();
            AbstractProductA product = factory.CreateProductA();
        }

        /// <summary>
        /// BEHAVIORAL
        /// </summary>
        public void ChainOfResponsibilityClient() 
        {
            
        }

        public void CommandClient() 
        {
        
        }

        public void IteratorClient() 
        {
        
        }

        public void MediatorClient() 
        {
        
        }

        public void MementoClient()
        {

        }

        public void ObserverClient()
        {

        }

        public void StateClient()
        {

        }

        public void StrategyClient()
        {

        }

        public void TemplateMethodClient()
        {

        }

        public void VisitorClient()
        {

        }

        /// <summary>
        /// STRUCTURAL
        /// </summary>
        public void AdapterClient()
        {

        }

        public void BridgeClient()
        {

        }

        public void CompositeClient()
        {

        }

        public void DecoratorClient()
        {

        }

        public void FacadeClient()
        {

        }

        public void FlyweightClient()
        {

        }

        public void ProxyClient()
        {

        }

    }
}
