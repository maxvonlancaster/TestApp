using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTest.Patterns.Creational.Prototype
{
    abstract public class Prototype
    {
        protected Prototype(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }

        public abstract Prototype Clone(); // defining interface for cloning itself
    }
}
