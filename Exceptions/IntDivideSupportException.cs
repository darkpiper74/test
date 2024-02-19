using System;

namespace ConsoleApp8
{
    public class IntDivideSupportException : Exception
    {
        public IntDivideSupportException() : base() { }
        public IntDivideSupportException(string message) : base(message) { }
        public IntDivideSupportException(string message, Exception innerException) : base(message, innerException) { }

    }
}
