using ConsoleAppTest.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleAppTest.ProgramFlow
{
    public class ExceptionHandling
    {
        private async Task<string> FetchWebPage(string uri)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(uri);
            return await response.Content.ReadAsStringAsync();
        }

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
                throw new Exception("This is outer exception, second parameter - inner one", ex);
                //  Passing the original exception as an inner for high - level exc. handler to deal. 
                // The constructor is given a reference to the original exception.
            }
        }

        // 
        public void CustomExeptions()
        {
            try
            {
                throw new CalcException("Fail", CalcException.CalcErrorCodes.InvalidNumberText);
            }
            catch(CalcException ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }

        // Handler that only catches exceptions that contain particular data values
        // when keyword followed by a conditional clausthat peforms a test. If false - exception is ignored.
        // If unheandled exception is thrown program is terminated immediately.
        // this mechanism is more efficient than rethrowing, because the runtime does not have to rebuild the exception object
        public void ConditionalClauses()
        {
            try
            {
                throw new CalcException("Fail", CalcException.CalcErrorCodes.InvalidNumberText);
            }
            catch (CalcException ex) when (ex.Error == CalcException.CalcErrorCodes.InvalidNumberText)
            {
                Console.WriteLine("Invalid number text");
            }
        }

        // An exception can contain inner ex-n that is set when it is constructed. Ex-n handler can extract it and use.
        // Use of inner exceptions must be planned.
        // 
        public void InnerExceptions()
        {
            try
            {
                try
                {
                    Console.Write("Enter an integer: ");
                    string numberText = Console.ReadLine();
                    int result;
                    result = int.Parse(numberText);
                    float div = 1 / result;
                }
                catch (Exception ex)
                {
                    throw new Exception("Calculation failure", ex);
                    // Throws new exception that contains inner exception that describes the error
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException.Message);
                Console.WriteLine(ex.InnerException.StackTrace);
            }
        }

        // Aggregate exceptions contain collections of inner exceptions. When more than one thing can fail or when the results 
        // of a series of actions need to be brought together
        // 
        public void AggregateExceptions()
        {
            try
            {
                Task<string> getPage = FetchWebPage("invalid uri");
                getPage.Wait();
                Console.WriteLine(getPage.Result);
            }
            catch (AggregateException ex)
            {
                foreach (Exception e in ex.InnerExceptions)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        // Make sure that code deals with any exceptions that may be thrown by methods, propagating the exception onward to make sure that exception
        // events are not hidden from different parts of app. Also throw ex-ns when it is not meaningful to continue with an action. 
        // If method throws ex-n the caller must deal with it if the program is to continue running
        // Consider how to manage error conditions during the design of app. Adding error management later is hard.
        // 
    }
}
