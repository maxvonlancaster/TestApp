using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ConsoleAppTest.Types
{
    public class Reflection
    {
        // All objects expose GetType method, that returns a reference to the type that defines the object
        // Type contains all the fields of an object along with metadata describing it
        // methods and objects in System.Reflection namespace to work with Type obj-s
        // 
        public void InvestigateType()
        {
            Type type;
            Person person = new Person();
            type = person.GetType();
            Console.WriteLine("Person type: {0}", type.ToString());

            foreach (MemberInfo member in type.GetMembers())
            {
                // Printing all the members of Person type
                Console.WriteLine(member.ToString());
            }
        }

        // 
        // 
        // 
        // 
        public void ReflectionMethodCall()
        {

        }

        // 
        // 
        // 
        // 
        public void FindComponents()
        {

        }

        // 
        // 
        // 
        // 
        public void LinqComponents()
        {

        }
    }
}
