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

        // 
        //public void CreatingAttributeClass()
        //{

        //}

        // The ProgrammerAttribute created earlier can be added to any item in program, including member variables, methods, and properties.It can also be
        // added to any type of object. When you create an attribute class, the proper practice is to add attribute usage information to the declaration of the attribute
        // class, so that the compiler can make sure that the attribute is only used in meaningful situations.Perhaps you don’t want to be able to assign
        // Programmer attributes to the methods in a class. You only want to assign a Programmer attribute to the class itself.
        // This is done by adding an attribute to the declaration of the attribute class. The attribute is called AttributeUseage and this is set with a number of values
        // that can control how the attribute is used.
        [AttributeUsage(AttributeTargets.Class)]
        class NewProgrammerAttribute : Attribute
        {
            // ...
        }
        // If you try to use the ProgrammerAttribute on anything other than a class you will find that the compiler will generate errors.Note that this means
        // that the compiler is performing reflection on our code as it compiles it, and you will find that Visual Studio does the same thing, in that invalid attempts to add
        // attributes will be flagged as errors in the editor.
        // You can set values of the AttributeUsage class to control whether  children of a class can be given the attribute, specify which elements of your
        // program can have the attribute assigned to them, identify specific types to be given the attribute and specify whether the given attribute can be applied
        // multiple times to the same item.You can also use the or operator (|) to set multiple targets for a given attribute.
        [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
        class FieldOrProp : Attribute
        {
            // ...
        }

        // The Attribute class also provides a method  called GetCustomAttribute to get an attribute from a particular type.        public void ReadAnAttribute()
        {
            Attribute a = Attribute.GetCustomAttribute(typeof(Person), typeof(ProgrammerAttribute));
            ProgrammerAttribute p = (ProgrammerAttribute)a;
            Console.WriteLine("Programmer : {0}", p.Programmer);
        }

    }

    [Serializable] // XMLSerializer and JsonSerializer do not need class to be marked
    [Programmer("F")] // Create own attributes to help manage elements of app. Program can change data but it is lost when program ends
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; }

        [NonSerialized] //No need to save this
        private int point;
    }
}
