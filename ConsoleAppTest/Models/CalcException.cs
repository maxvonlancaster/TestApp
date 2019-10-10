using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTest.Models
{
    public class CalcException : Exception
    {
        // The name of the exception calss should end with "Exception"
        public CalcException(string message, CalcErrorCodes error)
            : base(message)
        {
            Error = error;
        }

        public enum CalcErrorCodes
        {
            InvalidNumberText,
            DivideByZero
        }

        public CalcErrorCodes Error { get; set; }

    }
}
