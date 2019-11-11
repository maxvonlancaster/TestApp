#define DIAGNOSTICS

using System;
using System.Collections.Generic;
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

        }

        // 
        public void ConditionalAttribute()
        {

        }

        // 
        public void LineNumbers()
        {

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
