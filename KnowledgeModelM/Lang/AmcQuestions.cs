using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeModel.Lang
{
    class AmcQuestions
    {
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
