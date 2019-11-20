using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTest.Patterns.Creational.Prototype
{
    public class ConcretePrototype2 : Prototype
    {
        public ConcretePrototype2(int id) : base(id)
        {
        }

        public override Prototype Clone()
        {
            return new ConcretePrototype2(Id); // Concrete realisation of cloning
        }
    }
}
