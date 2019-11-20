using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTest.Patterns.Creational.Prototype
{
    public class ConcretePrototype1 : Prototype
    {
        public ConcretePrototype1(int id) : base(id)
        {
        }

        public override Prototype Clone()
        {
            return new ConcretePrototype1(Id); // Concrete realisation of cloning
        }
    }
}
