using System;

namespace ConsoleAppTest.ProgramFlow
{
    public class ExceptionHandling
    {
        // Exception handling - by placing block to be protected inside try, exception handler code - in catch
        // Catches the exception and uses the Message and StackTrace properties of the exception to generate an error message.
        public void TryCatch()
        {
            try
            {
                Console.WriteLine("Enter an integer: ");
                string input = Console.ReadLine();
                int result;
                int.TryParse(input, out result);
                int div = 1 / result;
                Console.WriteLine("Divided: {0}", div);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Invalid number");
                Console.WriteLine("Message: " + ex.Message);
                Console.WriteLine("StackTrace: " + ex.StackTrace); // Position in the program at which the error occured
                Console.WriteLine("HelpLink: " + ex.HelpLink);
                Console.WriteLine("TargetSite: " + ex.TargetSite); // Name of the method that couses the exception
                Console.WriteLine("Source: " + ex.Source); // Name of the app that caused error
            }
        }

        // The order of catch is important, other order - compiler error. Must put most abstract at the end
        public void ExceptionTypes()
        {
            try
            {
                Console.WriteLine("Enter an integer: ");
                string input = Console.ReadLine();
                int result;
                int.TryParse(input, out result);
                int div = 1 / result;
                Console.WriteLine("Divided: {0}", div);
            }
            catch (NotFiniteNumberException)
            {
                Console.WriteLine("Invalid number");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Divide by zero");
            }
            catch (Exception)
            {
                Console.WriteLine("Unexpected exception");
            }
        }

        // Finally element - identifies code executed irrespective of whatever happens in the try construction
        // Not executed - when infinite loop or Enviroment.FailFast method used
        // Finally block - where program can release any resources that the prog may be using
        public void TryCatchFinally()
        {
            try
            {
                Console.WriteLine("Enter an integer: ");
                string input = Console.ReadLine();
                int result;
                int.TryParse(input, out result);
                int div = 1 / result;
                Console.WriteLine("Divided: {0}", div);
            }
            catch (NotFiniteNumberException)
            {
                Console.WriteLine("Invalid number");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Divide by zero");
            }
            catch (Exception)
            {
                Console.WriteLine("Unexpected exception");
            }
            finally
            {
                Console.WriteLine("Finally block");
            }
        }

        // Program can create and throw its own exceptions by using throw statement to throw ex. instance.
        // Exception constructor accepts string
        //
        public void ThrowingException()
        {
            try
            {
                throw new Exception("Message ");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex; // Rethrowing the exception - is a bad practice - will not preserve the original stack -
                // - location of the error will be reported in the handler
                throw new Exception("This is outer exception, second par - inner one", ex);
                //  Passing the original exception as an inner for high - level exc. handler to deal. 
                // The constructor is given a reference to the original exception.
            }
        }
    }
}
