using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ConsoleAppTest.Services
{
    public class Language
    {
        // public - The type or member can be accessed by any other code in the same assembly or another assembly that references it.
        public int a;

        // private - The type or member can only be accessed by code in the same class or struct.
        private int b;

        // protected - The type or member can only be accessed by code in the same class or struct, or in a derived class.
        protected int c;

        // private protected (added in C# 7.2) - The type or member can only be accessed by code in the same class or struct, 
        // or in a derived class from the same assembly, but not from another assembly.
        private protected int d;

        // internal - The type or member can be accessed by any code in the same assembly, but not from another assembly.
        internal int e;

        // protected internal - The type or member can be accessed by any code in the same assembly, or by any derived class in another assembly.
        protected internal int f;




    }
}
