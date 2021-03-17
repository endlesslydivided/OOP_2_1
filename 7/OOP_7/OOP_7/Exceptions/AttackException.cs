using System;

namespace OOP_7.Exceptions
{
    class AttackException : ArgumentException, IControlException<int>
    {
        public int Value { get; }
        public AttackException(string message, int attack) : base(message) 
        {
            Value = attack;
        }
    }
}

