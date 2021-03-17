using System;

namespace LP_03_OOP_
{
    class Program
    {
        static void Main(string[] args)
        {
            SSTR.SuperString str_one = new SSTR.SuperString("Программирование");
            SSTR.SuperString str_two = new SSTR.SuperString("Программирование");
            SSTR.SuperString str_three = new SSTR.SuperString("");
            Console.WriteLine(str_one.ToString());
            Console.WriteLine(str_one.GetHashCode());
            Console.WriteLine($"{str_one} = {str_two} : {str_one.Equals(str_two)}");
            Console.WriteLine($"{str_one.GetType()}");
            Console.WriteLine(str_two.ToString());
            Console.WriteLine(str_three.ToString());
            str_two.Str = "компьютер";
            string x = str_two.Str;
            Console.WriteLine($"x = {x}");

            string[] str_massive = { "Апельсин Яблоко", "Дом калитка ночь утро", "Человек яблоко овощи", "Дерево молния", "Телефон полоса день", "Стол стул табурет", "Кот", "Мяч", "Ноутбук", "Дерево гром " };
            SSTR.SuperString[] sprstr_massive = new SSTR.SuperString[10];
            for(int iter = 0;iter < str_massive.Length; iter++)
            {
                sprstr_massive[iter] = new SSTR.SuperString(str_massive[iter]);
            }
            Console.WriteLine("Элементы массива объектов класса:");
            foreach (SSTR.SuperString d in sprstr_massive)
            {
                Console.WriteLine(d.ToString());
            }
            Console.Write("Введите длину строк для вывода: ");
            int str_len = Convert.ToInt32(Console.ReadLine());
            foreach(SSTR.SuperString d in sprstr_massive)
            {
                if((d.Str).Length == str_len)
                {
                    Console.WriteLine(d.ToString());
                }
            }
            Console.Write("Введите слово для поиска: ");
            string str_word = Console.ReadLine();
            foreach (SSTR.SuperString d in sprstr_massive)
            {
                if (((d.Str).ToLower()).IndexOf((str_word).ToLower()) != -1)
                {
                    Console.WriteLine(d.ToString());
                }
            }
            var anonymous_str = new { _str = "Поле анонимного типа", _comment = "Комменатрий" };
            Console.WriteLine("Анонимный тип: ");
            Console.WriteLine($"SuperString({anonymous_str._str},{anonymous_str._comment})");

        }
    }
}
