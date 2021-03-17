using System;

namespace OOP_7.Exceptions
{
    class InvalidNameException : ArgumentException, IControlException<string>
    {
        public string Value { get; }
        public InvalidNameException(string message, string name) : base(message)
        {
            Value = name;
        }
    }
}
