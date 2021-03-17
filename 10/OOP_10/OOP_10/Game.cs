using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Text;

namespace OOP_10
{
    enum AgeGroup
    {
        C = 0, E = 6, Eplus = 12, T = 16, M = 17, A = 18
    }

    class Game
    {

        #region Fields
        private static int counter;
        private int id;
        public string firm;
        public string Name;
        public double price;
        public AgeGroup ageGroup;
        #endregion

        #region Constructors
        public Game()
        {
            id = counter++;
        }

        public Game(string _firm, string _Name, double _price, AgeGroup _ageGroup)
        {
            id = counter++;
            firm = _firm;
            Name = _Name;
            price = _price;
            ageGroup = _ageGroup;
        }
        #endregion

        #region Accessors
        int _id
        {
            get => id;
            set => id = value;
        }

        int _count
        {
            get => counter;
        }
        #endregion

        #region Destructors
        ~Game()
        {
            counter--;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"Название игры: {Name,10}   |   Фирма производитель: {firm,10}   |   Возрастная группа: {(int)ageGroup,2}+   |   Цена:{price,5}$   |   ID игры:{_id,3}";
        }
        #endregion

    }

    class Collection<T> : IEnumerable<T>
    {
        #region Fields
        static int CollectionCounter;
        int count = 0;
        public string collectionName;
        public int Count { get { return count; } }
        public T[] massive = new T[1];
        int position = -1;      //позиция перебора начинается с -1 индекса
        int pos = -1;            //по этой позиции производится запись в массив
        #endregion

        #region Constructors
        public Collection()
        {
            collectionName = ("unnamedCollection_" + CollectionCounter++);
        }

        public Collection(string name)
        {
            collectionName = name;
            CollectionCounter++;
        }
        #endregion

        #region Methods
        public void Clear() //метод очистки массива и обнуления всех счетчиков
        {
            massive = new T[1];
            count = 0;
            pos = -1;
        }

        public bool Contains(T item) //метод поиска элемента в массиве
        {

            foreach (T val in massive)
            {
                if (val.Equals(item))
                    return true;
            }
            return false;
        }

        public void Add(T item)                  //метод добавления в массив элемента
        {
            count++;                                //увеличиваем размер массива
            Array.Resize(ref this.massive, count);
            pos++;                                  //увеличиваем индекс
            this.massive[pos] = item;            //добавляем значение
        }

        public void DeleteByName(string _Name)                  //метод добавления в массив элемента
        {
            int position = 0;
            bool flag = false;
            foreach (T item in this)
            {
                if (item is Game)
                {
                    Game item_game = item as Game;
                    if (item_game.Name == _Name)
                    {
                        flag = true;
                        break;
                    }
                    position++;
                }
            }
            if (position != count && flag)
            {
                for (int iter = position; iter < count - 1; iter++)
                {
                    massive[iter] = massive[iter + 1];
                    massive[iter + 1] = default;
                }
                pos--;
                count--;
            }
            else if (position == count && flag)
            {
                pos--;
                count--;
                massive[position] = default;
            }
        }

        public void DeleteByIndex(int _index)                  //метод добавления в массив элемента
        {
            if (_index != count)
            {
                for (int iter = _index; iter < count - 1; iter++)
                {
                    massive[iter] = massive[iter + 1];
                    massive[iter + 1] = default;
                }
                pos--;
                count--;
            }
            else if (_index == count)
            {
                pos--;
                count--;
                massive[position] = default;
            }
        }

        public void WriteCollection()
        {
            Console.WriteLine($"{collectionName}:");
            for (int iter = 0; iter < count; iter++)
                Console.WriteLine(massive[iter]);
            Console.WriteLine($"\n");
        }
        #endregion

        #region IEnumerator
        public IEnumerator GetEnumerator()  //это метод интерфейса IEnumerable
        {
            return massive.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)massive.GetEnumerator();
        }

        #endregion

        #region MassiveSearch
        public bool MoveNext()               //изменяет счетчик или ссылку на следующий элемент списка
        {
            position++;
            return (position < massive.Length);
        }
        public void Reset()                  //Сбросить счетчик.
        {
            position = -1;
        }



        public T Current
        {
            get { try { return massive[position]; } catch (IndexOutOfRangeException) { throw new InvalidOperationException(); } }
        }
        #endregion

        # region Indexer
        public T this[int index]            //индексатор
        {
            get { return massive[index]; }
            set { massive[index] = value; }
        }
        #endregion
    }
        
}

