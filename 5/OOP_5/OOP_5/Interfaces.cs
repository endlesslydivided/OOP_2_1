using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_5
{
    interface IAction
    {
        void Forward();
        void Right();
        void Left();
        void Back();
    }
    interface IQualities
    {
        int _CurrentHP { get; set; }
        string SuperPower { get; }
    }
}
