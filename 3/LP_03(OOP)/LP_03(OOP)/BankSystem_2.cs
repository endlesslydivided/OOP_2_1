using System;
using System.Collections.Generic;
using System.Text;

namespace Bank_System
{
    partial class BankSystem
    {
        public BankSystem (int acc_num, int acc_stt)
        {
            account_State = acc_stt;
            account_Number = acc_num;
        }
    }
}
