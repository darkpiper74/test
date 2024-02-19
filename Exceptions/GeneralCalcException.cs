using System;

namespace ConsoleApp8
{
    public class GeneralCalcException : Exception
    {
        public GeneralCalcException() : base() { }
        public GeneralCalcException(string message) : base(message) { }
        public GeneralCalcException(string message, Exception innerException) : base(message, innerException) { }

    }
}
