using System;

namespace OOP_7.Exceptions
{
    class CharactersException : ArgumentException, IControlException<string>
    {
        public string Value { get; }
        public CharactersException(string message, string sp) : base(message)
        {
            Value = sp;
        }
    }
}
