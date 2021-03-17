using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_5
{
    static class Printer
    {
        public static string IAmPrinting(object someObj)
        {
            if      (someObj is Warrior)
                return String.Concat(someObj.ToString(), "- Войн");
            else if (someObj is Archer)
                return String.Concat(someObj.ToString(), "- Лучник");
            else if (someObj is Physic)
                return String.Concat(someObj.ToString(), "- Экстрасенс");
            else if (someObj is Shaman)
                return String.Concat(someObj.ToString(), "- Шаман");
            else if (someObj is Hunter)
                return String.Concat(someObj.ToString(), "- Охотник");
            else
            {
                    return someObj.ToString();
            }
        }
    }
}