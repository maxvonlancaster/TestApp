using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeModel.Lang
{
    public class AmcQuestions
    {
        // 7. What will be the output for this block of code?
        public void CodeExample()
        {
            int i = 5;
            object b = i;
            i++;
            int c = ((int)b);
            c++;
            Console.Write(i.ToString(), b);

            // 6. Will the following code compile? (only with explicit cast to int)
            double d = 1.11;
            int j = (int)d;
        }

        // 8. Can you describe why the lock() statement is designed to only accept reference type parameters?

        // 9. How method arguments are passed in C#? Can this behavior be changed?

        // 10. What is the difference between Int.Parse and Int.TryParse?

        // 11. What are the implicit and explicit type conversions?

        // 12. How do you cast from one reference type to another without risking to throw an exception?

        // 13. Why isn't it possible to create an instance of an abstract class?

        // 14. Is it possible to invoke a method from an abstract class?

        // 15. Is it true that Interface can only contain method declarations?

        // 16. Is it possible to specify access modifiers inside of an interface?

        // 17. Can you inherit from two interfaces with the same method name in both of them?

        // 18. Is it possible to define two methods with the same name and arguments, but with a different return types?

        // 19. What is the difference between method overriding and overloading?

        // 20. What does protected internal access modifier mean?

        // 21. Your class Shape has one constructor with parameters.Can you create an instances of this class by calling new Shape()?

        // 22. Is it possible to override a method which is declared without a virtual keyword?

        // 23. What is the difference between new and override keywords in method declaration?

        // 24. Is it possible to explicitly call a class’ static constructor?

        // 25. How can you override a static constructor?

        // 26. Can you use this keyword inside of a static method?

        // 27. What is the difference between using a static class and a Singleton pattern?

        // 28. What does immutable mean? Can you provide examples?

        // 29. How can you create delegates in C#?

        // 30. Are delegates of a value or a reference type?

        // 31. What is the difference between events and multicast delegates?

        // 32. Is there any difference between Action and Function?

        // 33. What are lambda expressions? What are they used for?

        // 34. Is it possible to access variables from the outside of a lambda expression?

        // 35. What is LINQ used for?

        // 36. What should usually be done inside of a catch statement?

        // 37. Does the following code make sense?
        public void Exceptions()
        {
            try
            {
                DoSomeWork();
            }
            catch (Exception ex) { }
            //catch (StackOverflowException ex) { }
            // A previous catch clause already catches all exceptions of this or of a super type 
        }

        public void DoSomeWork() { }

        // 38. What is reflection? Where can it be used?

        // 39. What are generics?

        // 40. What constrains can be applied to generics?

        // 41. Can Garbage Collection be forced manually?

        // 42. What are the generations of.NET Garbage Collector?

        // 43. With the IDisposable interface, what logic is usually placed inside of the Dispose method?

        // 44. Can you extend the core.NET framework class with your own method?
    }

    // 17. Can you inherit from two interfaces with the same method name in both of them?
    public interface IOne
    {
        void MethodOne();
        void Method();
    }

    public interface ITwo
    {
        void MethodTwo();
        void Method();
    }

    public class Implement : IOne, ITwo
    {
        public void Method()
        {
            throw new NotImplementedException();
        }

        public void MethodOne()
        {
            throw new NotImplementedException();
        }

        public void MethodTwo()
        {
            throw new NotImplementedException();
        }
    }
}
