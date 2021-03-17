using System;
using System.Collections.Generic;
using System.Text;

namespace Bank_System
{
    partial class BankSystem
    {
       private int account_Number;
       private int account_State;
        public int ACCNUM { get { return account_Number;} }
        public int ACCSTT { get { return account_State; } }
    }
}
