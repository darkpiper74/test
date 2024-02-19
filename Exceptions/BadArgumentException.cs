using System;

namespace ConsoleApp8
{
    public class BadArgumentException : Exception
    {
        public BadArgumentException() : base() { }
        public BadArgumentException(string message) : base(message) { }
        public BadArgumentException(string message, Exception innerException) : base(message, innerException) { }

    }
}
