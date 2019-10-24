using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using static ConsoleAppTest.Types.ClassHierarchy;

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

        // call method -> finding MethodInfo and calling the invoke on that reference
        // Invoke method is supplied with reference to Person and array of object references that will be used as parameters
        // will be slower
        // 
        public void ReflectionMethodCall()
        {
            Type type;
            Person person = new Person();
            type = person.GetType();

            MethodInfo setMethod = type.GetMethod("set_Name");
            setMethod.Invoke(person, new object[] { "F" });
            Console.WriteLine(person.Name); // will print out "F"
        }

        // to        implement plugins you need to be able to search the classes in an assembly and
        // find components that implement particular interfaces.This behavior is the basis of the Managed Extensibility Framework(MEF). 
        // Find more at :  https://docs.microsoft.com/en-us/dotnet/framework/mef/
        // Find all classes that implement IAccount
        public void FindComponents()
        {
            Assembly thisAssembly = Assembly.GetExecutingAssembly();
            List<Type> AccountTypes = new List<Type>();
            foreach (Type t in thisAssembly.GetTypes())
            {
                if (t.IsInterface)
                    continue;
                if (typeof(IAccount).IsAssignableFrom(t))
                {
                    AccountTypes.Add(t);
                }
            } // BabyAccount and BankAccount will be added
        }

        // You can simplify the identification of the types by using a LINQ query
        public void LinqComponents()
        {
            Assembly thisAssembly = Assembly.GetExecutingAssembly();

            var AccountTypes = from type in thisAssembly.GetTypes()
                               where typeof(IAccount).IsAssignableFrom(type) && !type.IsInterface
                               select type;
            // It is possible to load an assembly from a file by using the Assembly.Load method.The statement below would load all the types in a file called
            // BankTypes.dll.This means that at its start an application could search aparticular folder for assembly files, load them and then search for classes that
            // can be used in the application.
            Assembly bankTypes = Assembly.Load("BankTypes.dll");
        }

        // 
        // 
        // 
        // 
        public void CodeDomObject()
        {

        }

        // 
        // 
        // 
        // 
        public void LambdaExpressionTree()
        {

        }

        // 
        // 
        // 
        // 
        public void ModifyingExpressionTree()
        {

        }

        // 
        // 
        // 
        // 
        public void AssemplyObject()
        {

        }

        // 
        // 
        // 
        // 
        public void PropertyInfo()
        {

        }

        // 
        // 
        // 
        // 
        public void MethodInfoReflection()
        {

        }
    }
}
