using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP_11
{
    class Program
    {
        static void Main(string[] args)
        {
            #region TASK 1
            /*Задание №1*/
            Console.WriteLine("\n▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬\n     ЗАДАНИЕ №1\n▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            string[] month = {"Junuary", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};
            IEnumerable<string> LM = month.Where(n => n.Length < 5).Select(n => n);
            IEnumerable<string> SM = month.Where(n => n =="June" || n == "July" || n == "August" || n == "Junuary" || n == "February" || n == "December").Select(n => n);
            IEnumerable<string> OM = month.OrderBy(n => n);
            IEnumerable<string> U5M = month.Where(n =>n.Contains('u') && n.Length >4);
            Console.WriteLine("Месяца длиной слова меньше 5:");
            foreach (string item in LM)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nЛетние месяца:");
            foreach (string item in SM)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nОтсортированные месяца:");
            foreach (string item in OM)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nМесяц содержит \"u\" и длиной больше 4:");
            foreach (string item in U5M)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region TASK 2-3
            /*Задание №2,3*/
            Console.WriteLine("\n▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬\n     ЗАДАНИЕ №2,3\n▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            List<SuperString> SSL = new List<SuperString>
            { 
                new SuperString("Год"),
                new SuperString("Программирование"),
                new SuperString("Стол"),
                new SuperString("Здание стол"),
                new SuperString("Телефо.н"),
                new SuperString("Программа"),
                new SuperString("Преподаватель"),
                new SuperString("Коллекция")
            };


            int QSS = SSL.Count(t => t.Str.Length == 3 || t.Str.Length == 5);
            IEnumerable<SuperString> CS = SSL.Where(t => t.Str.Contains("стол"));
            SuperString MS = SSL.Max(t => t);
            SuperString FCPQ = SSL.First(t => t.Str.Contains("." ) || t.Str.Contains("?"));
            SuperString LSSW = SSL.Last(t => t.Str.Contains(SSL.Min().Str));
            IEnumerable<SuperString> SSS = SSL.OrderBy(t => t);

            Console.WriteLine($"Количество строк длиной 3 или 5:{QSS}");
            Console.WriteLine("Строка содержит слово \"стол\": ");
            foreach (SuperString item in CS)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Строка максимальной длины:{MS}");
            Console.WriteLine($"Первая строка, содержащая точку или вопрос: {FCPQ}");
            Console.WriteLine($"Последняя строка с самым коротким словом: {LSSW}");
            Console.WriteLine($"Список, упорядоченный по первому слову:");
            foreach (SuperString item in SSS)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region TASK 4
            //Задание №4
            Console.WriteLine("\n▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬\n     ЗАДАНИЕ №4\n▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            List<int> numbers = new List<int>();
            List<int> numbers_1 = new List<int>();
            Random x = new Random();
            for(int iter = 0; iter <100; iter++ )
            {
                numbers.Add(x.Next(-100, 100));
            }
            for (int iter = 0; iter < 100; iter++)
            {
                numbers_1.Add(x.Next(-100, 100));
            }
            Console.WriteLine($"\nСписок чисел №1:");
            int iter_1 = 0;
            foreach (int item in numbers)
            {  if (iter_1 % 10 == 0 && iter_1 != 0) Console.WriteLine();
                Console.Write($"{ item,5}");
                iter_1++;
            }
            Console.WriteLine($"\nСписок чисел №2:");
            iter_1 = 0;
            foreach (int item in numbers_1)
            {
                if (iter_1 % 10 == 0 && iter_1 != 0) Console.WriteLine();
                Console.Write($"{ item,5}");
                iter_1++;
            }
            IEnumerable<int> MOQ = numbers.Where(t => t > 0 && t % 2 == 0).Intersect(numbers_1).OrderBy(t => t);
            Console.WriteLine($"\nСписок после проведения запроса:");
            iter_1 = 0;
            foreach (int item in MOQ)
            {
                if (iter_1 % 10 == 0 && iter_1 != 0) Console.WriteLine();
                Console.Write($"{ item,5}");
                iter_1++;
            }
            #endregion

            #region TASK 5
            //Задание №5
            Console.WriteLine("\n▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬\n     ЗАДАНИЕ №5\n▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            List<SuperString> SSL_2 = new List<SuperString>
            {
                new SuperString("Еда"),
                new SuperString("Стул"),
                new SuperString("Окно"),
                new SuperString("Дорога"),
                new SuperString("Зеркало"),
                new SuperString("Сайт"),
                new SuperString("Облако"),
                new SuperString("Задание")
            };
            var MJQ = from ss in SSL
                      join t in SSL_2 on ss.Str.Length equals t.Str.Length
                      select new { Str = ss.Str + " - " + t.Str  } ;

            Console.WriteLine($"\nКоллекция, полученная после запроса Join:");
            foreach (var item in MJQ)
            {
                Console.WriteLine($"{item.Str}");
            }
            #endregion
        }
    }
}
