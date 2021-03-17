using System;


namespace OOP_7.Exceptions
{
    class MaxHPException:ArgumentException, IControlException<int>
    { 
            public int Value { get; }
            public MaxHPException(string message, int HP) : base(message)
            {
                Value = HP;
            }
    }
}
