using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace ConsoleAppTest.Types
{
    // Everything in C# is an object of a particular type and the compiler ensures that interactions between types are always meaningful.

    public class ConsumeTypes
    {
        // From a computational point of view, value types such as int and float have the advantage that the computer processor can manipulate value types
        // directly.Adding two int values together can be achieved by fetching the values into the processor, performing the addition operation, and then storing the result.
        // It can be useful to treat value types as reference types, and the C# runtime
        // system provides a mechanism called boxing that will perform this conversion when required.
        // Each built-in C# value type(int, float etc) has a matching C# type called its interface type to
        // which it is converted when boxing is performed.The interface type for int is int32.
        // if a program spends a lot of time boxing and unboxing values it slows the program down.The need to box and unbox values in a solution is a symptom of
        // poor design, you should be clear in your design which data items are value types and which references, and work with them correctly.
        // A .NET program processes data by moving values onto a stack (called the evaluation stack), performing actions on them, and then storing the results.
        public void BoxingAndUnboxing()
        {
            // the value 99 is boxed into the object
            object o = 99;
            // the boxed object is unboxed back into the int
            int oVal = (int)o;
            Console.WriteLine(oVal);
        }

        // C# program will not allow a programmer to perform a conversion between types that result in the loss of data.
        public void TypeCasting()
        {
            // It is an example of narrowing, when a value is transferred into a type which offers a narrower range of values.The integer type does not
            // handle the fractional part of a value, and so the .9 part of the value x is discarded when the assignment takes place. These statements will not compile successfully.

            // float x = 9.9f;
            // int i = x;

            // C# is perfectly capable of performing the conversion from floating point to integer, but it requires confirmation from the programmer that it is meaningful
            // for this conversion to be performed.This is called explicit conversion, in that the programmer is making an explicit request that the conversion be performed.In
            // C# the explicit conversion is requested by the use of a cast, which identifies the desired type of value being assigned. The type is given, enclosed in brackets,
            // before the value to be converted. 

            float x = 9.9f;
            int i = (int) x;

            // A conversion that performs widening, in which the destination type has a wider range of values than the source, does not require a cast, because there is no
            // prospect of data loss. Note that casting cannot be used to convert between different types, for 
            // example with an integer and string.In other words, the following statement will fail to compile:

            // int j = (int)"99";

            // Casting is also used when converting references to objects that may be part of class hierarchies or expose interfaces
        }

        class Miles
        {
            public Miles(double distance)
            {
                Distance = distance;
            }

            public double Distance { get; }

            public static implicit operator Kilometers(Miles t)
            {
                Console.WriteLine("Implicit conversion");
                return new Kilometers(t.Distance * 1.6);
            }

            public static explicit operator int(Miles t)
            {
                Console.WriteLine("Explicit conversion");
                return (int)(t.Distance + 0.5);
            }
        }

        class Kilometers
        {
            public Kilometers(double distance)
            {
                Distance = distance;
            }

            public double Distance { get; }
        }

        // The .NET runtime provides a set of conversion methods that are used to perform casting.You can also write your own type conversion operators for your data
        // classes so that programs can perform implicit and explicit conversions between types. 
        public void TypeConversion()
        {
            Miles m = new Miles(100);

            Kilometers k = m; // implicitly converts miles to km

            int intMiles = (int)m; // explicitly converts miles to int

            // The System.Convert class provides a set of static methods that can be used to perform type conversion between.NET types. As an example, the code next
            // converts a string into an integer:
            int age = Convert.ToInt32("24");
            // The convert method will throw an exception if the string provided cannot be converted into an integer.
        }

        class MessageDisplay
        {
            public void Display(string m)
            {
                Console.WriteLine(m);
            }
        }

        // C# is a strongly typed language. This means that when the program is compiled the compiler ensures that all actions that are performed are valid in the context of
        // the types that have been defined in the program.As an example, if a class does not contain a method with a particular name, the C# compiler will refuse to
        // generate a call to that method.As a way of making sure that C# programs are valid at the time that they are executed, strong typing works very well.Such a
        // strong typing regime, however, can cause problems when a C# program is required to interact with systems that do not have their origins in C# code. Such
        // situations arise when using Common Object Model(COM) interop, the Document Object Model(DOM), working with objects generated by C#
        // reflection, or when interworking with dynamic languages such as JavaScript. In these situations, you need a way to force the compiler to interact with
        // objects for which the strong typing information that is generated from compiled C# is not available. The keyword dynamic is used to identify items for which
        // the C# compiler should suspend static type checking. The compiler will then generate code that works with the items as described, without doing static
        // checking to make sure that they are valid.Note that this doesn’t mean that a program using dynamic objects will always work; if the description is incorrect
        // the program will fail at run time.
        public void DynamicTypes()
        {
            MessageDisplay m = new MessageDisplay();
            m.Display("Hello");

            dynamic d = new MessageDisplay();
            d.MethodThatDoesNotExist("Hello");
            //This program will compile, but when the program is executed an exception will be generated when the method is called.

            // This aspect of the dynamic keyword makes it possible to interact with objects that have behaviors, but not the C# type information that the C# compiler would
            // normally use to ensure that any interaction is valid.
        }

        // A variable declared as dynamic is allocated a type that is inferred from the
        // context in which it is used.This is a very similar behavior to that of variables in languages such as Python or JavaScript.
        public void DynamicVariables()
        {
            dynamic d = 99;
            d = d + 1;
            Console.WriteLine(d);

            d = "hello";
            d = d + " there";
            Console.WriteLine(d);
            // that just because you can do this doesn’t mean that you should. The flexibility of the dynamic type was not created so that C# programmers can stop
            // worrying about having to decide on the type of variables that they use in their programs.Instead, the flexibility was added to make it easy to interact with other
            // languages and libraries written using the Component Object Model


            // The ExpandoObject class allows a program to dynamically add properties to an object.

            dynamic person = new ExpandoObject();
            person.Name = "Rob";
            person.Age = 20;
            Console.WriteLine("Name: {0}, Age: {1}", person.Name, person.Age);
            // A program can add ExpandoObject properties to an ExpandoObject to create nested data structures. An ExpandoObject can also be queried using
            // LINQ and can exposes the IDictionary interface to allow its contents to be queried and items to be removed.ExpandoObject is especially useful when
            // creating data structures from markup languages, for example when reading a JSON or XML document.
        }

        // The Component Object Model (COM) is a mechanism that allows software components to interact.The model describes how to express an interface to
        // which other objects can connect.COM is interesting to programmers because a great many resources you would like to use are exposed via COM interfaces.
        // The code inside a COM object runs as unmanaged code, having direct access to the underlying system.While it is possible to run.NET applications in an
        // unmanaged mode, .NET applications usually run inside a managed environment, limiting the level of access that the applications have to the underlying system.
        // When a .NET application wants to interact with a COM object it has to perform the following:
        // 1. Convert any parameters for the COM object into an appropriate format 
        // 2. Switch to unmanaged execution for the COM behavior
        // 3. Invoke the COM behavior
        // 4. Switch back to managed execution upon completion of the COM behavior
        // 5. Convert any results of the COM request into the correct types of .NET objects
        // This is performed by a component called the Primary Interop Assembly (PIA) that is supplied along with the COM object. The results returned by the PIA can
        // be managed as dynamic objects, so that the type of the values can be inferred rather than having to be specified directly.As long as your program uses the
        // returned values in the correct way, the program will work correctly.You add a Primary Interop Assembly to an application as you would any other assembly.
        // he C# code uses dynamic types to make the interaction with the Office application very easy.There is no need to cast the various elements that the
        // program is interacting with, as they are exposed by the interop as dynamic types, so conversion is performed automatically based on the inferred type of an
        // assignment destination.
        public void InteractionWithExcel()
        {
            // Create the interop
            var excelApp = new ApplicationClass();

            // make the app visible
            excelApp.Visible = true;

            // Add a new workbook   
            excelApp.Worksheets.Add();

            // Obtain the active sheet from the app.
            Worksheet worksheet = (Worksheet) excelApp.ActiveSheet;

            // write into two cells
            worksheet.Cells[1, "A"] = "Hello";
            worksheet.Cells[1, "B"] = "from C#";

            // You can create applications that interact with different versions of Microsoft Office by embedding the Primary Interop Assembly in the application. This is
            // achieved by setting the Embed Interop Types option of the assembly reference to True.This removes the need for any interop assemblies on the machine running the application.
        }
    }
}
