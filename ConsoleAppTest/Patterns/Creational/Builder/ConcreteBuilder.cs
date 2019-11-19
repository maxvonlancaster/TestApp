using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTest.Patterns.Creational.Builder
{
    public class ConcreteBuilder : Builder
    {
        Product product = new Product();

        public override void BuildPartA()
        {
            product.Add("A");
        }

        public override void BuildPartB()
        {
            product.Add("B");
        }

        public override void BuildPartC()
        {
            product.Add("C");
        }

        public override Product GetProduct()
        {
            return product;
        }
    }
}
