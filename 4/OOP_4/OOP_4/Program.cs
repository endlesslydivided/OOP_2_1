using Matrix_NS;
using System;

namespace OOP_4
{
    static class StatisticOperation
    {
        public static int elements_sum(Matrix a)
        {
            int sum = 0;
            for (int i = 0; i < a.str; i++)
            {
                for (int j = 0; j < a.col; j++)
                {
                    sum += a[i, j];
                }
            }
            return sum;
        }
        private static (int, int) max_min(Matrix a)
        {
            int min = 0, max = 0;
            for (int i = 0; i < a.str; i++)
            {
                for (int j = 0; j < a.col; j++)
                {
                    if (a[i, j] > max) max = a[i, j];
                }
            }
            min = max;
            for (int i = 0; i < a.str; i++)
            {
                for (int j = 0; j < a.col; j++)
                {
                    if (a[i, j] < max) min = a[i, j];
                }
            }
            return (max, min);
        }
        public static int max_min_dif(Matrix a)
        {
            (int, int) i = max_min(a);
            return (Math.Abs(i.Item1) - Math.Abs(i.Item2));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
         
        Console.Write("Введите количество строк первой матрицы: ");
            int str = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите количество столбцов первой матрицы: ");
            int col = Convert.ToInt32(Console.ReadLine());
            Matrix massive_1 = new Matrix(str, col);
            Console.Write("Введите количество строк второй матрицы: ");
            str = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите количество столбцов второй матрицы: ");
            col = Convert.ToInt32(Console.ReadLine());
            Matrix massive_2 = new Matrix(str, col);
            int choice = 0;
            do
            {
                Console.WriteLine("Выберите пункт:\n 1-Проиницилизировать матрицы " +
                    " \n 2-Отнять число от матрицы №1 " +
                    "\n 3-Инкремент матрицы №1 " +
                    "\n 4-Сравнить две матрицы " +
                    "\n 5-Посчитать кол-во нулевых элементов матрицы №1 " +
                    "\n 6-Вывод двух матриц " +
                    "\n 0-Выход");
                choice = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        {
                            massive_1.WriteMat();
                            massive_2.WriteMat(); break;
                        }
                    case 2:
                        {
                            Console.Write("Введите число для уменьшения: ");
                            int minus = Convert.ToInt32(Console.ReadLine());
                            massive_1 = massive_1 - minus;
                            (massive_1).ReadMat(); break;
                        }
                    case 3:
                        {
                            (massive_1++).ReadMat();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Матрица №1 {0} матрице №2", massive_1 != massive_2 ? "не равна" : "равна");
                            break;
                        }
                    case 5:
                        {
                            int x = massive_1;
                            Console.WriteLine("В матрице №1 {0} нулевых элементов", x);
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Матрица №1 :");
                            massive_1.ReadMat();
                            Console.WriteLine("Матрица №2 :");
                            massive_2.ReadMat();
                            break;
                        }
                    default: { break; }
                }
                
            } while (choice != 0);
        }
    }

}

namespace Matrix_NS
{
    public static class StatisticOperation_Extension
    {
        public static int element_q(this Matrix a)
        {
            int quantity = 0;
            for (int i = 0; i < a._str; i++)
            {
                for (int j = 0; j < a._col; j++)
                {
                    quantity++;
                }
            }
            return quantity;
        }
        public static bool is_square(this Matrix a)
        {
            return (a._str == a._col);
        }
    }
}