﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTest.Patterns.Creational.AbstractFactory
{
    public class ConcreteFactory1 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA1();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB1();
        }
    }
}
