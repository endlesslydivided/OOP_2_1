using System;
using System.Collections.Generic;
using System.Text;
using OOP_5;

namespace OOP_5
{
    abstract class Characters : IAction, IQualities
    {
        protected string type = "character";
        public int CurrentHP;
        public static int count = 0;
        public string Username;
        public virtual int _CurrentHP
        {
            get { return this.CurrentHP; }
            set { this.CurrentHP = value; }
        }
        public string SuperPower
        {
            get { return this.SuperPower; }
        }

        public override string ToString()
        {
            return $"Тип: {this.GetType()}, Суперсила: {this.SuperPower}";
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

        void IAction.Forward()
        {
            Console.WriteLine($"Moving forward");
        }
        void IAction.Left()
        {
            Console.WriteLine($"Moving left");
        }
        void IAction.Right()
        {
            Console.WriteLine($"Moving right");
        }
        void IAction.Back ()
        {
            Console.WriteLine($"Moving back");
        }

       
    }
    sealed class Warrior : Characters, IActions
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
        void IActions.Forward()
        {
            Console.WriteLine($"Only forward!");
        }
        public override string ToString()
        {
            return $"Тип: {this.GetType()}, Максимальное здоровье:{this.MaxHP},Суперсила: {this.SuperPower}. Войн - очень сильный персонаж с высоким уровнем здоровья.";
        }
        public Warrior(string UN)
        {
           Username =UN; count++;
        }
        public Warrior()
        {
          MaxHP = 100;String.Concat("user_", Convert.ToString(Characters.count));
        }
        public int max_hp
        {
            get { return this.MaxHP; }
        }
    }
    sealed class Hunter : Characters, IActions
    {
        private readonly int StartHP = 50;
        private readonly int MaxHP = 300;
        new string SuperPower = "Теневое клонирование";
        public override void ScreamMotto_Attack()
        {
            Console.WriteLine("I'll kill you quietly...");
        }
        void IActions.Forward()
        {
            Console.WriteLine($"I'm faster than light!");
        }
        public override string ToString()
        {
            return $"Тип: {this.GetType()}, Максимальное здоровье:{this.MaxHP},Суперсила: {this.SuperPower}. Охотник знаменит своей скоростью и скрытностью.";
        }
        public override int _CurrentHP
        {
            get { 
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
        public Hunter(string UN)
        {
           Username =UN; count++;
        }
        public Hunter()
        {
          MaxHP = 100;String.Concat("user_", Convert.ToString(Characters.count));
        }
        public int max_hp
        {
            get { return this.MaxHP; }
        }
    }
    sealed class Shaman : Characters
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
            return $"Тип: {this.GetType()}, Максимальное здоровье:{this.MaxHP},Суперсила: {this.SuperPower}. Шаман способен восстанавливать здоровье и имеет повышенный запас маны.";
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
        public Shaman(string UN)
        {
           Username =UN; count++;
        }
        public Shaman()
        {
          MaxHP = 100;String.Concat("user_", Convert.ToString(Characters.count));
        }
        public int max_hp
        {
            get { return this.MaxHP; }
        }
    }
    sealed class Archer : Characters
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
            return $"Тип: {this.GetType()}, Максимальное здоровье:{this.MaxHP},Суперсила: {this.SuperPower}. Лучник способен атаковать с дальних расстояний.";
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
        public Archer(string UN)
        {
           Username =UN; count++;
        }
        public Archer()
        {
          MaxHP = 100;String.Concat("user_", Convert.ToString(Characters.count));
        }
        public int max_hp
        {
            get { return this.MaxHP; }
        }
    }
    sealed class Physic : Characters
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
            return $"Тип: {this.GetType()}, Максимальное здоровье:{this.MaxHP},Суперсила: {this.SuperPower}. Шаман умеет управлять разумом врагов и контролировать их действия.";
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
        public Physic(string UN)
        {
            Username =UN; count++;
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
