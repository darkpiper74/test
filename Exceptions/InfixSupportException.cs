using System;

namespace ConsoleApp8
{
    public class InfixSupportException : Exception
    {
        public InfixSupportException() : base() { }
        public InfixSupportException(string message) : base(message) { }
        public InfixSupportException(string message, Exception innerException) : base(message, innerException) { }

    }
}
