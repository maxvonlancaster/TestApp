#define TERSE
//#define VERBOSE

using ConsoleAppTest.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ConsoleAppTest.Types
{
    public class Attributes
    {
        // Attrinute - instance of calss that extends the Attribute class -> adding metadata to an app in the form of attributes that are attached to
        // classes and class members
        // [serializable] -> class may be opened and read by a serializer, that takes contets of a class and sends it into stream
        // security implications -> c# requires a class to be opt in to serialization

        // Conditional attribute to activate and deactivate the contents of methods 
        // declared in System.Diagnostics. Code compiles but is not run.
        // Cond-l attrib. controls whether or not the body of a method is obeyed method is called.

        // if either terse or verbose are defined
        [Conditional("VERBOSE"), Conditional("TERSE")]
        private void Report()
        {
            Console.WriteLine("Report");
        }

        // only if verbose is defined
        [Conditional("VERBOSE")]
        private void ReportVerbose()
        {
            Console.WriteLine("ReportVerbose");
        }

        // only if terse is defined
        [Conditional("TERSE")]
        private void ReportTerse()
        {
            Console.WriteLine("ReportTerse");
        }

        public void ConditionalAttribute()
        {
            Report();
            ReportTerse();
            ReportVerbose();
        }

        // Program can check that a given class has an attribute attached to it -> static method IsDefined, accepts 2 parameters, class tested and attribute
        // 
        public void TestingAttribute()
        {
            if (Attribute.IsDefined(typeof(Person), typeof(SerializableAttribute)))
                Console.WriteLine("Class is serializable ");
        }

    }

    [Serializable] // XMLSerializer and JsonSerializer do not need class to be marked
    [Programmer("F")] // Create own attributes to help manage elements of app. Program can change data but it is lost when program ends
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        [NonSerialized] //No need to save this
        private int point;
    }
}
