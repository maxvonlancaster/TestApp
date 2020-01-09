using System;
using System.Collections.Generic;
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

        }

        public void PerformanceMonitoring()
        {

        }
        // ^

        public void ImplementLogging()
        {

        }

        public void ExceptionHandlingGuidelines()
        {

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
