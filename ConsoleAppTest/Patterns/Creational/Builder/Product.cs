using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTest.Patterns.Creational.Builder
{
    public class Product
    {
        List<object> parts = new List<object>();

        public void Add(string part)
        {
            parts.Add(part);
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            foreach (var o in parts)
            {
                s.Append(o);
            }
            return s.ToString();
        }
    }
}
