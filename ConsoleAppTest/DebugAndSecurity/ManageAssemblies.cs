using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTest.DebugAndSecurity
{
    // An assembly is an individual component of an application. It can be either an executable program(in which case it will have the language extension “.exe”) or
    // it will be a dynamically loaded library(in which case it will have the language extension “.dll”).
    // Source code | Assets  ->  Visual Studio Compiler  ->  DLL assembly MSIL | Exe assembly MSIL  ->  .net runtime Jit compiler  ->  machine code
    public class ManageAssemblies
    {
        //  changes to the behavior of the library might affect the behavior of the application.Note also
        // that this dependency is one-way, in that changes to the user interface will not affect the behavior of the library.Visual Studio will not allow you to create
        // circular dependencies, so it is not possible to make two libraries depend on each other.
        // Once you have added a library to a project you can use the classes contained in the library.
        //public void Assemblies()
        //{
        //    Track t = new Track("Kanye West", "Selah", 250);
        //    Console.WriteLine(t);
        //}

        //// 
        //public void StrongNames()
        //{
        //    string assemblyName = typeof(Track).Assembly.FullName;
        //    Console.WriteLine(assemblyName);
        //}

        // 
        public void WinRT()
        {

        }
    }
}
