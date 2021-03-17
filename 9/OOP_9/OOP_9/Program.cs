using System;
using System.Text;

namespace OOP_9
{
    public class User
    {
        public int сompression = 100;
        public int offset = 2;

        public void Replace()
        {
            Console.WriteLine("Вызвался метод перемещения");
            this.ReplaceEvent?.Invoke();
        }

        public void Сompress(int сompression_cof)
        {
            Console.WriteLine("Вызвался метод сжатия");
            if (СompressionEvent != null)
                сompression += this.СompressionEvent(сompression_cof);

            Console.WriteLine($"Текущее сжатие {сompression}");
        }

        public delegate void ReplaceHandler();
        public event ReplaceHandler ReplaceEvent;

        public delegate int СompressionHandler(int сompression_cof);
        public event СompressionHandler СompressionEvent;

    }

    class Program
    {
        public static int СompressUser(int сompression_cof)
        {
            Console.WriteLine("Сжатие информации о пользователе");
            return сompression_cof;
        }

        ////////////////////////////////////
        //for Func
        public static string DeletePunctSigns(string str)
        {
            StringBuilder rc = new StringBuilder();

            for (int i = 0, j = 0; i < str.Length; i++)
                if (str[i] != ',' && str[i] != '.' && str[i] != '!' && str[i] != ':' && str[i] != ';')
                    rc.Append(str[i], 1);

            Console.WriteLine($"Строка без знаков пунктуации: {rc}");
            return rc.ToString();
        }

        public static string ToUpperCase(string str)
        {
            Console.WriteLine($"Строка в верхнем регистре: {str.ToUpper()}");
            return str.ToUpper();
        }

        public static string DeleteUnnecessarySpace(string str)
        {
            StringBuilder rc = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
                if (str[i] == ' ' || str[i] == '\t')
                {
                    rc.Append(str[i], 1);
                    while (str[i + 1] == ' ')
                        i++;
                }
                else
                    rc.Append(str[i], 1);
            Console.WriteLine($"Строка без лишних пробелов: {rc}");
            return rc.ToString();
        }

        ////////////////////////////////////
        //for Action

        public static void AddSymbols(string str, string additionSymbols)
        {
            str = str.Insert(0, additionSymbols);
            str += additionSymbols;

            Console.WriteLine($"Результат: {str}");
        }

        static void Main(string[] args)
        {
            User userInstance = new User();
            userInstance.ReplaceEvent += () => Console.WriteLine("Начало перемещения пользователя");
            userInstance.ReplaceEvent += () => Console.WriteLine($"Смещение: {userInstance.offset}");
            userInstance.СompressionEvent += СompressUser;

            userInstance.Replace();
            userInstance.Сompress(20);

            Action<string, string> formatingForTitle;

            formatingForTitle = AddSymbols;
            formatingForTitle("qwerty", "!!!");

            string testString = "vE	|	vEM";
            Func<string, string> func;
            func = DeletePunctSigns;
            func += ToUpperCase;
            func += DeleteUnnecessarySpace;

            string result = func(testString);
        }


    }
}
