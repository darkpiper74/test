using System;

namespace ConsoleApp8
{
    public class BadNumberException : Exception
    {
        public BadNumberException() : base() { }
        public BadNumberException(string message) : base(message) { }
        public BadNumberException(string message, Exception innerException) : base(message, innerException) { }
    }
}
