﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;

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

        // DEBUG -> Performance profiler

        // Before you can speed up your application you need to know where it is spending most of its time.The StopWatch class can be used to measure elapsed time
        public void StopwatchClass()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Thread.Sleep(1234);
            stopwatch.Stop();
            Console.WriteLine("Elapsed time: {0}", stopwatch.ElapsedMilliseconds);

            stopwatch.Restart();
            Thread.Sleep(1000);
            stopwatch.Stop();
            Console.WriteLine("New elapsed time: {0}", stopwatch.ElapsedMilliseconds); // New elapsed time: 1000
        }

        // A program can read the values of the performance counters so that it can monitor the system in which it is running. A given performance counter is identified	
        // by its category name, counter name and instance name
        public void ReadPerformanceCounters()
        {
            PerformanceCounter processor = new PerformanceCounter(categoryName: "Processor information",
                counterName: "% Processor Time",
                instanceName: "_Total");
            Console.WriteLine("Press any key to stop");

            while (true)
            {
                Console.WriteLine("Processor time: {0}", processor.NextValue());
                Thread.Sleep(1000);
                if (Console.KeyAvailable)
                {
                    break;
                }
            }
        }

        // You can also create your own performance counters too. These are added to the performance counters on the host machine and can be accessed by other 
        // programs and viewed using the Performance Monitor program
        public void CreatePerformanceCounters()
        {

        }

        // 
        public void WriteToTheEventLog()
        {

        }

        // A program can also read from the event log.
        // The program reads the image processing event log and prints out every entry in it.If the log has not been created(or none of the earlier example
        // programs have been run on the computer) the program prints a warning message and ends.
        public void ReadFromTheEventLog()
        {
            string categoryName = "Image processing";

            if (!EventLog.SourceExists(categoryName))
            {
                Console.WriteLine("Event log not present");
            }
            else
            {
                EventLog eventLog = new EventLog();
                eventLog.Source = categoryName;
                foreach (EventLogEntry entry in eventLog.Entries)
                {
                    Console.WriteLine("Source: {0} Type: {1} Time: {2} Message: {3}", 
                        entry.Source, entry.EntryType, entry.TimeWritten, entry.Message);
                }
            }
        }

        // A program can bind to an event log and receive notification events when the log is written to.You can use this to create a dashboard that displays the activity of
        // your applications.The dashboard binds to log events that your application generates.
        public void BindToTheEventLog()
        {
            string categoryName = "Image processing";

            EventLog eventLog = new EventLog();
            eventLog.Source = categoryName;
            eventLog.EntryWritten += ImageEvent_LogEntryWritten;
            eventLog.EnableRaisingEvents = true;

            Console.WriteLine("Listening for log events");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static void ImageEvent_LogEntryWritten(object sender, EntryWrittenEventArgs e)
        {
            Console.WriteLine(e.Entry.Message);
        }
    }

    enum CreationResult
    {
        CreatedCounters,
        LoadedCounters
    }
}
