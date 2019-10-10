using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTest.Models
{
    // You can create your own attribute classes to help manage elements of your
    // application.These classes can serve as markers in the same way as the
    // Serializable attribute specifies that a class can be serialized, or you can
    // store data in attribute instances to give information about the items the attributes
    // are attached to. The data values stored in an attribute instances are set from the
    // class metadata when the attribute is loaded. A program can change them as it
    // runs, but these changes will be lost when the program ends.
    public class ProgrammerAttribute : Attribute
    {
        private string _programmer;

        public ProgrammerAttribute(string programmer)
        {
            _programmer = programmer;
        }

        public string Programmer { get => _programmer; }
    }
}
