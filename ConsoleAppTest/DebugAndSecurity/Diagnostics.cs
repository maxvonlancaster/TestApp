﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace ConsoleAppTest.DebugAndSecurity
{
    // You can also use information generated by logging and tracing to investigate performance issues with systems out in the field.If is very useful to be able to
    // determine the loading levels and the nature of transactions being performed on the customer site.
    // You use logging to find out what your program is doing and what happened    when it failed.You use tracing to discover the path followed by the program to
    // perform a particular action.    public class Diagnostics
    {
        // The System.Diagnostics namespace contains Debug and Trace classes that can
        // be used to trace execution of a program.The classes contain methods that can be used to generate tracing output from a program when it runs.
        // By default, the output from the Debug statements is directed to the Output window in Visual Studio.
        // Note, that if the program is not compiled for debug, the debug statements are not included in the program that is produced.The debug code uses a conditional attribute
        public void DebugCodeTracing()
        {
            System.Diagnostics.Debug.WriteLine("Starting the program");
            System.Diagnostics.Debug.Indent();
            System.Diagnostics.Debug.WriteLine("Inside a function");
            System.Diagnostics.Debug.Unindent();
            System.Diagnostics.Debug.WriteLine("Outside a function");
            string name = "Alan";
            System.Diagnostics.Debug.WriteLineIf(string.IsNullOrEmpty(name), "This string will not be printed out");
        }

        // If you want to add this form of tracing output to production code you can use the Trace object, which can be used in the same way as the Debug object
        public void TraceCodeTracing()
        {
            Trace.WriteLine("Starting the program");
            Trace.TraceInformation("This is an information message");
            Trace.TraceWarning("This is a warning message");
            Trace.TraceError("this is an error message");
        }

        // An assertion is a statement that you make, believing it to be true. For example, in the application design you might assert that “the name of a customer is never an
        // empty string.” When my program fails, the first thing to do is make sure that allof the assertions about the state of the program are actually true. In the case of
        // the customer name you will add code to display the customer name so that you can check it, or you will add code to test the assertion.
        public void AssertionsInDebug()
        {
            string name = "Alan";
            System.Diagnostics.Debug.Assert(!string.IsNullOrEmpty(name));

            name = "";
            System.Diagnostics.Debug.Assert(!string.IsNullOrEmpty(name));
            // If the parameter is false, the assertion fails and the program will display a message offering the developer the option to continue the program.
        }

        // By default (unless specified otherwise) the output from the Debug and Trace classes is sent to the output window in Visual Studio.This will work during
        // development, but once the program has been deployed this will not be useful. A
        // program can attach listener objects to Debug and Trace, which will serve as destinations for tracing information.
        public void TraceListener()
        {
            //TraceListener consoleListener = new Con;
        }

        // The Trace and Debug classes provide tracing for a program in the form of simple messages.If you want to take a more managed approach to program tracing, you
        // can use the TraceSource class. An instance of the TraceSource class will create events that can be used to trace program execution
        public void SimpleTraceSource()
        {
            TraceSource trace = new TraceSource("Tracer", SourceLevels.All);
            trace.TraceEvent(TraceEventType.Start, 10000);
            trace.TraceEvent(TraceEventType.Warning, 10001);
            trace.TraceEvent(TraceEventType.Verbose, 10002, "At the end of the program");
            trace.TraceData(TraceEventType.Information, 1003, new object[] { "Note 1", "Message" });
            trace.Flush();
            trace.Close();
            // Each event is given a particular event type and an event number.The event number element of an event is just an integer value that identifies the particular
            // event. When you design the tracing in the application, you can define values that will be used to represent particular events, such as events 0 to 999 can mean user
            // interface, and 1,000 to 1,999 databases, and so on. There are a range of event types that are specified by a value of type TraceEventType.
            // TraceEventType: Stop, Start, Suspend, Resume, Transfer, Verbose, Information, Warning, Error, Critical.
        }

        // The TraceSwitch object is provided to help manage tracing output from a
        // program.The TraceSwitch object contains a Level property that can be set to determine the level of tracing output to be produced.        public void TraceSwitch()
        {
            TraceSwitch control = new TraceSwitch("Control", "Controls the trace output");
            control.Level = TraceLevel.Warning;

            if (control.TraceError)
            {
                Console.WriteLine("Error occured");
            }

            Trace.WriteLineIf(control.TraceWarning, "A warning message");
        }

        // The SourceSwitch can be used to directly control the behavior of a TraceSource object. It works in the same way as the TraceSwitch described above
        public void SourceSwitch()
        {
            TraceSource trace = new TraceSource("Tracer", SourceLevels.All);

            SourceSwitch control = new SourceSwitch("Control", "Controls the trace output");
            control.Level = SourceLevels.Information;
            trace.Switch = control;

            trace.TraceEvent(TraceEventType.Start, 10000);
            trace.TraceEvent(TraceEventType.Warning, 10001);
            trace.TraceEvent(TraceEventType.Verbose, 10002, "At the end of the program");
            trace.TraceData(TraceEventType.Information, 1003, new object[] { "Note 1", "Message" });
            trace.Flush();
            trace.Close();
        }

        // The examples earlier show how a program can configure tracing output when it
        // runs.However, it is also possible to configure tracing output using the application configuration file
        public void ConfigFile()
        {
            TraceSource trace = new TraceSource("configControl");

        }

        // 
        public void StopwatchClass()
        {

        }

        // 
        public void ReadPerformanceCounters()
        {

        }

        // 
        public void CreatePerformanceCounters()
        {

        }

        // 
        public void WriteToTheEventLog()
        {

        }

        // 
        public void ReadFromTheEventLog()
        {

        }

        // 
        public void BindToTheEventLog()
        {

        }
    }
}
