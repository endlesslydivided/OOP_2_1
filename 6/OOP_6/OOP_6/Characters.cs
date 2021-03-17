using System;
using System.Collections;
using System.Collections.Generic;


namespace OOP_5
{
    public abstract class ArmyController : IComparer<Army.Characters>
    {

        public Army.Characters GetTheStrongest(Army army)
        {
            int the_biggest_attack = 0;
            int the_strongest_number = 0;
            for (int i = 0; i < army.Count; i++)
            {
                if (army[i].attack < the_biggest_attack)
                {
                    the_biggest_attack = army[i].attack;
                    the_strongest_number = i;
                }
            }
            return army[the_strongest_number];
        }
        public int Compare(Army.Characters x, Army.Characters y)
        {
            if (x.attack < y.attack)
                return 1;
            if (x.attack > y.attack)
                return -1;
            else return 0;
        }
    }
    public  class Army: ArmyController, IEnumerator, IEnumerable
    {
        int count = 0;
        public int Count { get { return count; } }
        public Characters[] massive = new Characters[100];

        int position = -1; //позиция перебора начинается с -1 индекса
        int pos = -1; //по этой позиции производится запись в массив

        public void Clear() //метод очистки массива и обнуления всех счетчиков
        {
            massive = new Characters[1];
            count = 0;
            pos = -1;
        }
        public bool Contains(Characters item) //метод поиска элемента в массиве
        {

            foreach (Characters val in massive)
            {
                if (val.Equals(item))
                    return true;
            }
            return false;
        }
        public void Add(Characters massive) //метод добавления в массив элемента
        {
            count++;  //увеличиваем размер массива
            Array.Resize(ref this.massive, count);
            pos++; //увеличиваем индекс
            this.massive[pos] = massive; //добавляем значение
        }
        public bool MoveNext() //изменяет счетчик или ссылку на следующий элемент списка
        {
            position++;
            return (position < massive.Length);
        }
        public void Reset() //Сбросить счетчик.
        {
            position = -1;
        }
        public Characters Current
        {
            get { try { return massive[position]; } catch (IndexOutOfRangeException) { throw new InvalidOperationException(); } }
        }
        object IEnumerator.Current //Метод должен возвращать текущий элемент списка.
        {
            get { return Current; }
        }
        public IEnumerator GetEnumerator()//это метод интерфейса IEnumerable
        {
            return massive.GetEnumerator();
        }
        public Characters this[int index]  //тут создали индексатор
        {
            get { return massive[index]; }
            set { massive[index] = value; }
        }
        public void Sort()
        {
            bool sort_flag = false;
            do
            {
                sort_flag = false;
                for (int position = 0; position < count - 1; position++)
                {
                    if (Compare(this[position], this[position + 1]) == 1)
                    {
                        Characters temp = new Characters();
                        temp = this[position];
                        this[position] = this[position + 1];
                        this[position + 1] = temp;
                        sort_flag = true;
                    }
                    else
                    {
                        continue;
                    }
                }
            } while (sort_flag);
        }

        public class Characters : IActionable
        {
            
            enum eRace
            {
                Orcs = 0,
                Elphs = 1,
                Gnomes = 2
            };
            struct ArmyForce
            {
                int quantity;
                string race;
                int totalHealth;
                int totalAttack;
            }
            protected string type = "character";
            public int CurrentHP;
            public int attack;
            public static int count = 0;
            public string Username;
            public virtual int _CurrentHP
            {
                get { return this.CurrentHP; }
                set { this.CurrentHP = value; }
            }
            public int Attack
            {
                get { return this.attack; }
                set { this.attack = value; }
            }
            public string SuperPower
            {
                get { return this.SuperPower; }
            }
            public override string ToString()
            {
                return $" Суперсила: {this.SuperPower} Атака: {this.attack} ";
            }
            public override int GetHashCode()
            {
                return base.GetHashCode() * SuperPower.Length;
            }
            public override Boolean Equals(Object chr)
            {
                if (chr == null) return false;
                if (this.GetType() != chr.GetType()) return false;
                return true;
            }

            public virtual void ScreamMotto_Attack()
            {
                Console.WriteLine("Attack!");
            }
            public virtual void ScreamMotto_Defense()
            {
                Console.WriteLine("Hold the defense!");
            }
            public virtual void SayName()
            {
                Console.WriteLine($"My name is {Username}!");
            }

            void IActionable.Forward()
            {
                Console.WriteLine($"Moving forward");
            }
            void IActionable.Left()
            {
                Console.WriteLine($"Moving left");
            }
            void IActionable.Right()
            {
                Console.WriteLine($"Moving right");
            }
            void IActionable.Back()
            {
                Console.WriteLine($"Moving back");
            }


        }
       
        public class Warrior : Characters, IActionable
        {
            public int StartHP = 100;
            public readonly int MaxHP = 500;
            new string SuperPower = "Режим берсерка";
            public override void ScreamMotto_Attack()
            {
                Console.WriteLine("Attack the villains!");
            }
            public override sealed void SayName()
            {
                Console.WriteLine($"My comrades call me {Username} !");
            }
            void IActionable.Forward()
            {
                Console.WriteLine($"Only forward!");
            }
            public override string ToString()
            {
                return $"Максимальное здоровье:{this.MaxHP},Суперсила: {this.SuperPower}.Атака: {this.attack}. Войн - очень сильный персонаж с высоким уровнем здоровья.";
            }
            public Warrior(string UN, int att)
            {
                Username = String.Concat(UN, this.GetType()); count++;attack = att;
            }
            public Warrior()
            {
                MaxHP = 100; String.Concat("user_", Convert.ToString(Characters.count));
            }
            public int max_hp
            {
                get { return this.MaxHP; }
            }
        }
        public class Hunter : Characters, IActionable
        {
            private readonly int StartHP = 50;
            private readonly int MaxHP = 300;
            new string SuperPower = "Теневое клонирование";
            public override void ScreamMotto_Attack()
            {
                Console.WriteLine("I'll kill you quietly...");
            }
            void IActionable.Forward()
            {
                Console.WriteLine($"I'm faster than light!");
            }
            public override string ToString()
            {
                return $"Максимальное здоровье:{this.MaxHP},Суперсила: {this.SuperPower}.Атака: {this.attack}. Охотник знаменит своей скоростью и скрытностью.";
            }
            public override int _CurrentHP
            {
                get
                {
                    if (this.CurrentHP < MaxHP)
                    {
                        if (MaxHP - this.CurrentHP < 5)
                            return this.CurrentHP + 5;
                        else
                            return this.CurrentHP + (MaxHP - this.CurrentHP);
                    }
                    return this.CurrentHP;
                }
                set { this.CurrentHP = value; }
            }
            public Hunter(string UN, int att)
            {
                Username = String.Concat(UN, this.GetType()); count++;attack = att;
            }
            public Hunter()
            {
                MaxHP = 100; String.Concat("user_", Convert.ToString(Characters.count));
            }
            public int max_hp
            {
                get { return this.MaxHP; }
            }
        }
        public class Shaman : Characters
        {
            private readonly int StartHP = 50;
            private readonly int MaxHP = 200;
            new string SuperPower = "Восстановление здоровья";
            public override void ScreamMotto_Attack()
            {
                Console.WriteLine("My power has no limit!");
            }
            public override string ToString()
            {
                return $"Максимальное здоровье:{this.MaxHP},Суперсила: {this.SuperPower}.Атака: {this.attack}. Шаман способен восстанавливать здоровье и имеет повышенный запас маны.";
            }
            public override int _CurrentHP
            {
                get
                {
                    if (this.CurrentHP < MaxHP)
                    {
                        if (MaxHP - this.CurrentHP < 2)
                            return this.CurrentHP + 2;
                        else
                            return this.CurrentHP + (MaxHP - this.CurrentHP);
                    }
                    return this.CurrentHP;
                }
                set { this.CurrentHP = value; }
            }
            public Shaman(string UN, int att)
            {
                Username = String.Concat(UN, this.GetType()); count++;attack = att;
            }
            public Shaman()
            {
                MaxHP = 100; String.Concat("user_", Convert.ToString(Characters.count));
            }
            public int max_hp
            {
                get { return this.MaxHP; }
            }
        }
        public class Archer : Characters
        {
            private readonly int StartHP = 75;
            private readonly int MaxHP = 600;
            new string SuperPower = "Горящие стрелы";
            public override void ScreamMotto_Defense()
            {
                Console.WriteLine("Our arrows protect the castle!");
            }
            public override string ToString()
            {
                return $"Максимальное здоровье:{this.MaxHP},Суперсила: {this.SuperPower}.Атака: {this.attack}. Лучник способен атаковать с дальних расстояний.";
            }
            public override int _CurrentHP
            {
                get
                {
                    if (this.CurrentHP < MaxHP)
                    {
                        if (MaxHP - this.CurrentHP < 1)
                            return this.CurrentHP + 1;
                        else
                            return this.CurrentHP + (MaxHP - this.CurrentHP);
                    }
                    return this.CurrentHP;
                }
                set { this.CurrentHP = value; }
            }
            public Archer(string UN, int att)
            {
                Username = String.Concat(UN, this.GetType()); count++;attack = att;
            }
            public Archer()
            {
                MaxHP = 100; String.Concat("user_", Convert.ToString(Characters.count));
            }
            public int max_hp
            {
                get { return this.MaxHP; }
            }
        }
        public class Physic : Characters
        {
            private readonly int StartHP = 100;
            private readonly int MaxHP = 200;
            new string SuperPower = "Контроль разума";
            public override void ScreamMotto_Defense()
            {
                Console.WriteLine("Don't let the enemies pass!");
            }
            public override string ToString()
            {
                return $"Максимальное здоровье:{this.MaxHP},Суперсила: {this.SuperPower}.Атака: {this.attack}. Шаман умеет управлять разумом врагов и контролировать их действия.";
            }
            public override int _CurrentHP
            {
                get
                {
                    if (this.CurrentHP < MaxHP)
                    {
                        if (MaxHP - this.CurrentHP < 3)
                            return this.CurrentHP + 3;
                        else
                            return this.CurrentHP + (MaxHP - this.CurrentHP);
                    }
                    return this.CurrentHP;
                }
                set { this.CurrentHP = value; }
            }
            public Physic(string UN, int att)
            {
                Username = String.Concat(UN, this.GetType()); count++;attack = att;
            }
            public Physic()
            {
                Username = String.Concat("user_", Convert.ToString(Characters.count)); count++;
            }
            public int max_hp
            {
                get { return this.MaxHP; }
            }
        }
    }
}
