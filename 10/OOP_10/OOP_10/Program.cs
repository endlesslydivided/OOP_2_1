using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

/*          ВАРИАНТ 10           */

/*  ТИП     |     ИНТЕРФЕЙС     |       Коллекция           */
/*  Игра    |   IEnumerable<T>  |   BlockingCollection<T>   */


namespace OOP_10
{
    class Program
    {
        static void Main(string[] args)
        {
            #region TASK №1
            //ЗАДАНИЕ №1

            /*Создайте класс по варианту, определите в нем свойства и методы, реализуйте
            указанный интерфейс и другие при необходимости, соберите объекты класса в
            коллекцию (можно сделать специальных класс с вложенной коллекцией и
            методами ею управляющими), продемонстрируйте работу с ней
            (добавление/удаление/поиск/вывод):
            */

            Console.WriteLine("    ЗАДАНИЕ №1\n▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");

            Collection<Game> game_list = new Collection<Game>("Список игр:");
            game_list.Add(new Game("GameInc", "Dark Sauce", 15, AgeGroup.M));
            game_list.Add(new Game("Ybox", "Witch", 35.6, AgeGroup.A));
            game_list.Add(new Game("GameInc", "Melta", 15, AgeGroup.Eplus));
            game_list.Add(new Game("AUE", "FUFA20", 14.9, AgeGroup.E));
            game_list.Add(new Game("Vent", "Half-Wife", 3.33, AgeGroup.T));

            game_list.WriteCollection();

            game_list.DeleteByName("Witch");

            game_list.WriteCollection();

            game_list.DeleteByIndex(2);

            game_list.WriteCollection();
            #endregion
            #region TASK №2
            //ЗАДАНИЕ №2

            /*Создайте универсальную коллекцию в соответствии с вариантом задания и
            заполнить ее данными встроенного типа .Net (int, char,…).
            a. Выведите коллекцию на консоль
            b. Удалите из коллекции n последовательных элементов
            c. Добавьте другие элементы (используйте все возможные методы
            добавления для вашего типа коллекции).
            d. Создайте вторую коллекцию (из таблицы выберите другой тип
            коллекции) и заполните ее данными из первой коллекции.
            e. Выведите вторую коллекцию на консоль. В случае не совпадения
            количества параметров (например, LinkedList<T> и Dictionary<Tkey,
            TValue>), при нехватке - генерируйте ключи, в случае избыточности –
            оставляйте TValue.
            f. Найдите во второй коллекции заданное значение.*/

            Console.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬\n     ЗАДАНИЕ №2\n▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");

            //a
            BlockingCollection<int> BCollection = new BlockingCollection<int>();


            Random x = new Random();
            for (int iter = 0; iter < 100; iter++)
            {
                BCollection.Add(x.Next(-100, 100));
            }

            int iterator = 0;
            foreach (int item in BCollection)
            {
                if (iterator % 10 == 0) Console.WriteLine();
                Console.Write($"{item,4}");
                iterator++;
            };

            //b
            int n;
            iterator = 0;
            Console.Write("\n\nВведите количество удаляемых элементов: "); n = Convert.ToInt32(Console.ReadLine());
            for (int iter = 0; iter < n; iter++)
                BCollection.Take();
            foreach (int item in BCollection)
            {
                if (iterator % 10 == 0 && iterator != 0) Console.WriteLine();
                Console.Write($"{item,4}");
                iterator++;
            }

            //c
            Console.WriteLine();
            iterator = 0;
            BCollection.Add(1);
            BCollection.TryAdd(2);
            Console.Write("\nДобавлено два элемента при помощи Add() и TryAdd() : ");
            foreach (int item in BCollection)
            {
                if (iterator % 10 == 0 ) Console.WriteLine();
                Console.Write($"{item,4}");
                iterator++;
            }

            //d,e
            Console.WriteLine();
            Queue<int> QCollection = new Queue<int>(BCollection);
            iterator = 0;

            Console.Write("\nСоздана коллекция типа Queue: ");
            foreach (int item in QCollection)
            {
                if (iterator % 10 == 0) Console.WriteLine();
                Console.Write($"{item,4}");
                iterator++;
            }

            //f
            iterator = 0;
            Console.WriteLine("\n\nПроверка на наличие элементов: ");
            foreach (int item in QCollection)
            {
                if (QCollection.Contains(item))
                    Console.WriteLine($"{++iterator}. Коллекция QCollection содержит элемент {item}");
            }
            #endregion
            #region TASK №3
            //ЗАДАНИЕ №3

            /*Создайте объект наблюдаемой коллекции ObservableCollection<T>. Создайте
            произвольный метод и зарегистрируйте его на событие CollectionChange.
            Напишите демонстрацию с добавлением и удалением элементов. В качестве
            типа T используйте свой класс из таблицы.*/

            Console.WriteLine("\n▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬\n     ЗАДАНИЕ №3\n▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");

            ObservableCollection<Game> observableGames = new ObservableCollection<Game>()
            {
                new Game("GameInc", "Dark Sauce", 15, AgeGroup.M),
                new Game("Ybox", "Witch", 35.6, AgeGroup.A),
                new Game("GameInc", "Melta", 15, AgeGroup.Eplus),
                new Game("AUE", "FUFA20", 14.9, AgeGroup.E),
                new Game("Vent", "Half-Wife", 3.33, AgeGroup.T)
            };

            observableGames.CollectionChanged += observableGamess_CollectionChanged;

            observableGames.Add(new Game());
            observableGames.RemoveAt(0);
            observableGames[0] = new Game();
        }

        private static void observableGamess_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Game newGame = e.NewItems[0] as Game;
                    Console.WriteLine($"Добавлено:               {newGame.ToString()}");
                    break;

                case NotifyCollectionChangedAction.Remove:
                    Game oldGame = e.OldItems[0] as Game;
                    Console.WriteLine($"Удалено:                 {oldGame.ToString()}");
                    break;

                case NotifyCollectionChangedAction.Replace: 
                    Game replacedGame = e.OldItems[0] as Game;
                    Game replacingGame = e.NewItems[0] as Game;
                    Console.WriteLine($"({replacedGame.ToString()}) \nзаменено\n({replacingGame.ToString()})");
                    break;
            }
        }
        #endregion
    }
}
