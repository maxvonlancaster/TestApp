#define DIAGNOSTICS
#undef DEBUG

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ConsoleAppTest.DebugAndSecurity
{
    // The C# compiler is the program that takes the C# source code and converts it into the Microsoft Intermediate Language(MSIL) code that will be stored in the
    // assembly file output.You can modify the behavior of the compiler by giving it compiler directives. These are commands that are pre-ceded by the # character.
    // These commands may also be called preprocessor directives.The C and C++languages have an explicit part of the compilation process in which the program
    // source file is scanned and pre-processor directives are acted on.The C and C++pre-processor understands a wide range of commands that allow programmers to
    // create and trigger pre-built macros, swap one symbol in a program for another, and even include the contents of one source file in another.
    // The C# compiler directives are more limited in scope, but they are still veryuseful.
    public class Debug
    {
        // One way to investigate the behavior of a program is to add code that produces diagnostic messages that can be used to work out what the program is doing.
        // This is sometimes called code instrumentation.You can use Boolean flags to determine whether or not to produce diagnostic output
        public void AddingDiagnostics()
        {
            DebugTrack.DebugMode = true;
            DebugTrack track = new DebugTrack("A", "B", 100);

            // It is useful if there is a way that you can leave out the diagnostic code
        }

        // The #if compiler directive can be used to control whether or not a particular set of statements in a program are actually processed by the compiler.It is used
        // with the #define directive that lets us define a symbol that controls the behavior of#if.
        public void ConditionalCompilation()
        {
            DebugTrackConditional track = new DebugTrackConditional("A", "B", 100);
        }

        [Conditional("DEBUG")]
        private void Display(string message)
        {
            Console.WriteLine(message);
        }

        // You can use the Conditional attribute to enable and disable a method in your program.The attribute is defined in the
        // System.Diagnostics namespace and can be used to flag a method as to only be executed if a given conditional compilation symbol is defined.
        public void ConditionalAttribute()
        {
            Display("this message will not be printed out since debug is undef");

            // Note that the use of the Conditional attribute does not control whether or not the method is included in the compiled assembly file output by the compiler.
            //The method is always included in the assembly output.However, the Conditional output will prevent the method from being called.

            OldMethod();
        }


        // You can mark classes, interfaces, methods and properties with the Obselete attribute to indicate that they have been superseded by new versions.The
        // Obselete attribute is applied to the superseded element and given a message and a Boolean value that indicates whether a compiler warning(false) 
        // or an error (true) should be produced if the element with the attribute is used by a program.
        [Obsolete("This method is obsolete. Call NewMethod instead", false)]
        private void OldMethod()
        {

        }


        // 
        // 



        private void Exploder()
        {
#line 1 "qwerty"
            throw new Exception("Exeption 1");
#line default
        }

        // Some of the code that you work with may contain auto-generated elements. These code components may be inserted into your program files.This happens
        // with systems such as ASP.NET.These can lead to confusion navigating error reports, where the line number that is reported doesn’t match the one you see in
        // the Visual Studio editor. The #line directive can be used to set the reported line
        // numbers of statements in your code. You can also use the #line directive to specify the file name delivered by error reporting.
        public void LineNumbers()
        {
#line hidden
            Console.WriteLine("The debugger will not step through this statement");
#line default

            try
            {
                Exploder();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        // 
        public void CodeOptimization()
        {

        }

        // 

    }

    public class DebugTrack
    {
        public DebugTrack(string artist, string title, int length)
        {
            Artist = artist;
            Title = title;
            Length = length;

            if (DebugMode)
            {
                Console.WriteLine("Music track created: {0}", this.ToString());
            }
        }

        public int ID { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }

        public static bool DebugMode = false;

        public override string ToString()
        {
            return Artist + " " + Title + " " + Length.ToString();
        }
    }

    // conditional compilation
    public class DebugTrackConditional
    {
        public DebugTrackConditional(string artist, string title, int length)
        {
            Artist = artist;
            Title = title;
            Length = length;

#if DIAGNOSTICS
            Console.WriteLine("Music track created: {0}", this.ToString());
#endif
            // if the condition is not fulfilled the code controlled by conditional compilation is
            // never included in the assembly file output.

            // The condition that is tested can be a logical expression that combines tests for multiple symbols. The symbols can only be declared right at the 
            // start of a source file.

            // Conditional compilation symbols can also be defined in the properties of an application.

            // 
        }

        public int ID { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }

        public static bool DebugMode = false;

        public override string ToString()
        {
            return Artist + " " + Title + " " + Length.ToString();
        }
    }

}
