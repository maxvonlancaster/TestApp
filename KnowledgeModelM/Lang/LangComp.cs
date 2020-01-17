using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Reflection;
using System.Text;

namespace KnowledgeModel.Lang
{
    public class LangComp
    {
        // Reflection - process of type discovery in the runtime
        public void TypeReflection()
        {
            // Obtain type info.
            Point p = new Point();
            Type t = p.GetType();
            Type t2 = typeof(Point); // Do not need to create instance of class. Expects strongly typed name of the type.
            // Using Type.GetType() method -> do not throw exception if cannot find and ignore case:
            Type t3 = Type.GetType("KnowledgeModel.Lang.Point", false, true);

            // Display methods: Type.GetMethods -> returns SYstem.Reflection.MethodInfo array:
            Console.WriteLine("Methods:");
            MethodInfo[] mi = t.GetMethods();
            foreach (MethodInfo m in mi)
            {
                Console.WriteLine("Method: {0}", m.Name);
            }

            Console.WriteLine("\nFields:");
            FieldInfo[] fi = t.GetFields();
            foreach (FieldInfo f in fi)
            {
                Console.WriteLine("Field: {0}", f.Name);
            }

            Console.WriteLine("\nProperties:");
            PropertyInfo[] pi = t.GetProperties();
            foreach (PropertyInfo pr in pi)
            {
                Console.WriteLine("Property: {0}", pr.Name);
            }

            Console.WriteLine("\nReflecting on implemented interfaces:");
            Type tl = typeof(List<string>);
            Type[] ifaces = tl.GetInterfaces();
            foreach (Type i in ifaces)
            {
                Console.WriteLine("Interface: {0}", i.Name);
            }

            Console.WriteLine("List various stats");
            Console.WriteLine("Base class: {0}", tl.BaseType);
            Console.WriteLine("Is abstract: {0}", tl.IsAbstract);
            Console.WriteLine("Is sealed: {0}", tl.IsSealed);
            Console.WriteLine("Is type generic: {0}", tl.IsGenericTypeDefinition);
            Console.WriteLine("Is a class type: {0}", tl.IsClass);

        }

        public void CustomAttributes()
        {
            // Attributes are metadata extensions that give additional information to the compiler about the elements in the program code at 
            // runtime.Attributes are used to impose conditions or to increase the efficiency of a piece of code. There are built -in 
            // attributes present in C# but programmers may create their own attributes, such attributes are called Custom attributes

            // You can create your own custom attributes by defining an attribute class, a class that derives 
            // directly or indirectly from Attribute, which makes identifying attribute definitions in metadata fast and easy.
            CustomMethod();
        }

        [System.AttributeUsage(System.AttributeTargets.Class |
                       System.AttributeTargets.Struct | AttributeTargets.Method)] // Determines how a custom attribute class can be used. AttributeUsageAttribute is an attribute you apply to custom attribute definitions. 
        public class Author : System.Attribute
        {
            private string name;
            public double version;

            public Author(string name)
            {
                this.name = name;
                version = 1.0;
            }
            // Any public read-write fields or properties are named parameters. 
        }

        [Author("Batman", version = 1.5)]
        public static void CustomMethod()
        {

        }



        public void DisposeAndFinalizePatterns()
        {
            // Implement Dispose method to release resources used by app. The .net garbage collector does not allocate or release unmanaged memory.
            // Dispose patern -> imposes order on the lifetime of an object. Used for resources that access unmanaged resources -> file and pipe handlers, wait handlers, pointers or blocks of unmanaged objects.
            // The dispose pattern has two variations: 
        }

        public void GcTriggers()
        {
            // Garbage collection occurs when one of the following conditions is true:

            // The system has low physical memory.
            // The memory that is used by allocated objects on the managed heap surpasses an acceptable threshold. This threshold is continuously adjusted as the process runs.
            // The GC.Collect method is called.In almost all cases, you do not have to call this method, because the garbage collector runs continuously. 
            // (This method is primarily used for unique situations and testing.)
            GC.Collect();
        }

        public void LargeObjects()
        {
            // In .NET 1.1 and 2.0 if an object is >= 85,000 bytes it’s considered a large object. This number was determined by performance tuning. When an object 
            // allocation request comes in, if it’s >= 85,000 bytes, we will allocate it on the large object heap. 

            // From the generation point of view, large objects belong to generation 2 because they are collected only when we do a generation 2 collection.
            // When a generation gets collected, all its younger generation(s) also get collected.So for example, when a generation 1 GC happens, both generation 1 and 0 get collected.And when a generation 2 
            // GC happens, the whole heap gets collected.For this reason a generation 2 GC is also called a full GC.


            // A garbage collection doesn't just get rid of unreferenced objects, it also compacts the heap. That's a very important optimization. It doesn't just make memory usage more efficient 
            // (no unused holes), it makes the CPU cache much more efficient. The cache is a really big deal on modern processors, they are an easy order of magnitude faster than the memory bus.
            // Compacting is done simply by copying bytes.That however takes time. The larger the object, the more likely that the cost of copying it outweighs the possible CPU cache usage improvements.
            // So they ran a bunch of benchmarks to determine the break-even point.And arrived at 85,000 bytes as the cutoff point where copying no longer improves perf. With a special exception for arrays 
            // of double, they are considered 'large' when the array has more than 1000 elements.That's another optimization for 32-bit code, the large object heap allocator has the special 
            // property that it allocates memory at addresses that are aligned to 8, unlike the regular generational allocator that only allocates aligned to 4. That alignment is a big deal for double, 
            // reading or writing a mis-aligned double is very expensive. Oddly the sparse Microsoft info never mention arrays of long, not sure what's up with that.
            // Fwiw, there's lots of programmer angst about the large object heap not getting compacted. This invariably gets triggered when they write programs that 
            // consume more than half of the entire available address space. Followed by using a tool like a memory profiler to find out why the program bombed even 
            // though there was still lots of unused virtual memory available. Such a tool shows the holes in the LOH, unused chunks of memory where previously a large 
            // object lived but got garbage collected. Such is the inevitable price of the LOH, the hole can only be re-used by an allocation for an object that's equal 
            // or smaller in size.The real problem is assuming that a program should be allowed to consume all virtual memory at any time.
            // A problem that otherwise disappears completely by just running the code on a 64-bit operating system.A 64-bit process has 8 terabytes of virtual memory address space available, 
            // 3 orders of magnitude more than a 32-bit process.You just can't run out of holes.
            // Long story short, the LOH makes code run more efficient.At the cost of using available virtual memory address space less efficient.
        }

        public void MonitoringAppMemoryUsage()
        {

        }

        // .Net diagnostics
        public void CodeContracts()
        {
            // Code Contracts – новинка, появившаяся с выходом четвертой версии .NET. Это библиотека, реализующая идею программирования по контракту. Несколько упрощая можно сказать, 
            // что её суть заключается в установке условий, которые должны соблюдать параметры методов и свойства объекта.
            // Code contracts are always defined at the starting of the method using a Contract class. 
            var p1 = GetCustomerPassword("cust");
            var p2 = GetCustomerPassword(null);
            var a = Division(6, 2);
            var b = Division(7, 17);
        }

        private string GetCustomerPassword(string customerId)
        {
            Contract.Requires(!string.IsNullOrEmpty(customerId), "Customer ID cannot be Null");
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(customerId), "Exception!!");
            Contract.Ensures(Contract.Result<string>() != null);
            string pass = "qwerty";
            if (customerId != null)
            {
                return pass;
            }
            else
            {
                return null;
            }
        }

        private int Division(int i, int j)
        {
            Contract.Requires(i > j, "i should be greater than j");
            return i / j;
        }



        public void EventTracingForWindows()
        {

        }

        public void EventLogging()
        {
            // EventLog -> Provides interaction with Windows event logs.

            // Create the source, if it does not already exist.
            if (!EventLog.SourceExists("MySource"))
            {
                //An event log source should not be created and immediately used.
                //There is a latency time to enable the source, it should be created
                //prior to executing the application that uses the source.
                //Execute this sample a second time to use the new source.
                EventLog.CreateEventSource("MySource", "MyNewLog");
                Console.WriteLine("CreatedEventSource");
                Console.WriteLine("Exiting, execute the application a second time to use the source.");
                // The source is created.  Exit the application to allow it to be registered.
                return;
            }

            // Create an EventLog instance and assign its source.
            EventLog myLog = new EventLog();
            myLog.Source = "MySource";

            // Write an informational entry to the event log.    
            myLog.WriteEntry("Writing to event log.");


            // EventLog lets you access or customize Windows event logs, which record information about important software or hardware events. 
            // Using EventLog, you can read from existing logs, write entries to logs, create or delete event sources, delete logs, 
            // and respond to log entries. You can also create new logs when creating an event source.


        }

        public void PerformanceMonitoring()
        {

        }
        // ^


        // NLOG
        public void ImplementLogging()
        {
            var config = new NLog.Config.LoggingConfiguration();

            // Targets where to log to: File and Console
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "file.txt" };
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

            // Rules for mapping loggers to targets            
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            // Apply config           
            NLog.LogManager.Configuration = config;

            NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

            try
            {
                Logger.Info("Hello world");
                System.Console.ReadKey();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Goodbye cruel world");
            }
        }

        public void ExceptionHandlingGuidelines()
        {
            // Use try/catch blocks around code that can potentially generate an exception and your code can recover from that exception. In catch blocks, 
            // always order exceptions from the most derived to the least derived. All exceptions derive from Exception. More derived exceptions are not 
            // handled by a catch clause that is preceded by a catch clause for a base exception class. When your code cannot recover from an exception, 
            // don't catch that exception. Enable methods further up the call stack to recover if possible.
            // Clean up resources allocated with either using statements, or finally blocks.Prefer using statements to automatically clean up resources when 
            // exceptions are thrown. Use finally blocks to clean up resources that don't implement IDisposable. Code in a finally clause is almost always executed even when exceptions are thrown.


            // When you create user-defined exceptions, ensure that the metadata for the exceptions is available to code that is executing remotely.
            // For example, on .NET implementations that support App Domains, exceptions may occur across App domains.Suppose App Domain A creates App 
            // Domain B, which executes code that throws an exception. For App Domain A to properly catch and handle the exception, it must be able 
            // to find the assembly that contains the exception thrown by App Domain B. If App Domain B throws an exception that is contained in an 
            // assembly under its application base, but not under App Domain A's application base, App Domain A will not be able to find the exception, 
            // and the common language runtime will throw a FileNotFoundException exception. To avoid this situation, you can deploy the assembly that
            // contains the exception information in two ways:
            // Put the assembly into a common application base shared by both app domains.
            // - or -
            // If the domains do not share a common application base, sign the assembly that contains the exception information with a strong name and 
            // deploy the assembly into the global assembly cache.

            // Include a localized string message in every exception
            // The error message that the user sees is derived from the Exception.Message property of the exception that was thrown, and not from the 
            // name of the exception class. Typically, you assign a value to the Exception.Message property by passing the message string to the message argument of an Exception constructor.
            // For localized applications, you should provide a localized message string for every exception that your application can throw. You use resource files to provide localized error messages.
        }

        // Span<T>
        // Typesafe realisation of contiguous region of any memory
        public void SpanT()
        {
            var array = new byte[100];
            var arraySpan = new Span<byte>(array);
            byte data = 0;
            for (int ctr = 0; ctr < arraySpan.Length; ctr++)
                arraySpan[ctr] = data++;

            int arraySum = 0;
            foreach (var value in array)
                arraySum += value;

            Console.WriteLine($"The sum is {arraySum}");
        }

        public void SpanArray()
        {
            var array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var slice = new Span<int>(array, 2, 5);

            for (int i = 0; i < slice.Length; i++)
            {
                slice[i] *= 2;
            }

            foreach (var value in array)
                Console.Write($"{value} ");
            Console.WriteLine(); // output 1 2 6 8 ...
        }

        public void ReadOnlySpan()
        {
            string contentLength = "Content-Length: 132";
            var charSpan = new ReadOnlySpan<char>(contentLength.ToCharArray());
            var slice = charSpan.Slice(16); // no creation of new string -> benefit
            int length;
            int.TryParse(slice, out length);
            Console.WriteLine($"Length: {length}");
        }

        public void CSharpNew()
        {

        }

        public void NetStandartOverview()
        {

        }
    }

    //public class Elephant
    //{
    //    public <T>Elephant(T id)
    //    {
    //    }
    //}
}
