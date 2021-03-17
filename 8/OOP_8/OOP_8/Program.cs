using System;
using System.IO;
using System.Linq;

namespace OOP_8
{
    class NullInputException : Exception
    {
        public NullInputException() : base("Передан пустой массив.") { }
    }

    interface Igeneric<T>
    {
        void AddEl(T el);
        T DeleteEl(int _str, int _col);
        T CheckEl(int _str, int _col);
    }

    public class Matrix<T> : Igeneric<T> where T : new()
    {
        private static int counter;
        public struct STR
        {
            public int str;
            public int col;
        }
        STR Str;
        private T[,] mass;

        private Owner infAboutCreator;
        public readonly DateTime creationTime;

        public readonly int maxstr;
        public readonly int maxcol;

        public int _col
        {
            get => Str.col;
            set { if (value > 0) Str.col = value; }
        }
        public int _str
        {
            get => Str.str;
            set { if (value > 0) Str.str = value; }
        }

        public Matrix(int n, int k)
        {
            this.Str.str = n;
            this.Str.col = k;
            mass = new T[this.Str.str, this.Str.col];
        }

        public T this[int i, int j]
        {
            get
            {
                return mass[i, j];
            }
            set
            {
                mass[i, j] = value;
            }
        }
        class Owner
        {
            int id;
            string name;
            string organization;

            public Owner(ref int counter)
            {
                this.id = counter++;
                this.name = "Kovalev Alexander";
                this.organization = "BSTU";
            }
        }
        public Matrix()
        {
            counter++;
            this.Str.str = 0;
            this.Str.col = 0;
            this.maxstr = 25;
            this.maxcol = 25;
            this.mass = new T[this.maxstr,this.maxcol];
            this.infAboutCreator = new Owner(ref counter);
            this.creationTime = DateTime.Now;
        }
        public Matrix(T[,] input)
        {
            if (input.Length == 0)
                throw new NullInputException();

            Matrix<T>.counter++;
            this.Str.str = 0;
            this.Str.col = 0;
            this.maxstr = 25;
            this.maxcol = 25;
            this.mass = new T[this.maxstr, this.maxcol];
            this.infAboutCreator = new Owner(ref counter);
            this.creationTime = DateTime.Now;
                for (int l = 0; l < this.maxstr && l < input.GetLength(0); l++)
                {
                    for (int j = 0; j < this.maxcol && j <input.GetLength(1); j++)
                    {
                        this.mass[l,j] = input[l,j];
                    }
                }
            this.Str.col = input.GetLength(1);
            this.Str.str = input.GetLength(0);
        }
        public void ReadMat()
        {
            for (int i = 0; i < Str.str; i++)
            {
                for (int j = 0; j < Str.col; j++)
                {
                    if(this is Matrix<Characters>)
                    Console.Write((mass[i, j] as Characters).Username + ":" + (mass[i, j] as Characters).GetType() + "   ");
                    else
                    Console.Write(mass[i, j] + "   ");
                }
                Console.WriteLine();
            }
        }

        public int Compare(Matrix<T> a)
        {
            if (this.Str.col * this.Str.str < a.Str.col * a.Str.str)
                return -1;
            else if (this.Str.col * this.Str.str == a.Str.col * a.Str.str)
                return 0;
            else
                return 1;
        }

        public static bool operator <(Matrix<T> var1, Matrix<T> var2)
        {
            if (var1.Str.col * var1.Str.str < var2.Str.col * var2.Str.str)
                return true;
            else
                return false;
        }

        public static bool operator >(Matrix<T> var1, Matrix<T> var2)
        {
            if (var1.Str.col * var1.Str.str > var2.Str.col * var2.Str.str)
                return true;
            else
                return false;
        }

        public static bool operator ==(Matrix<T> var1, Matrix<T> var2)
        {
            if (var1.Str.col * var1.Str.str == var2.Str.col * var2.Str.str)
                return true;
            else
                return false;
        }

        public static bool operator !=(Matrix<T> var1, Matrix<T> var2)
        {
            if (var1.Str.col * var1.Str.str != var2.Str.col * var2.Str.str)
                return true;
            else
                return false;
        }
        public static Matrix<T> operator +(Matrix<T> var, Matrix<T> var2)
        {

            Matrix<T> temp = new Matrix<T>();

            for (int i = 0; i < var.Str.str; i++)
            {
                for (int j = 0; j < var.Str.col; j++)
                {
                    temp.mass[i, j] = var.mass[i, j];
                }
            }
            temp.Str.str = var.Str.str;
            temp.Str.col = var.Str.col;
            for (int i = temp.Str.str; i < var.Str.str; i++)
            {
                temp.Str.str++;
                for (int j = temp.Str.str; j < var.Str.col; j++)
                {
                    temp.mass[i, j] = var.mass[i, j];
                    temp.Str.col++;
                }
            }
            return temp;
        }
        void Igeneric<T>.AddEl(T el)
        {
            T[,] tempArr = new T[maxstr, maxcol];

            for (int i = 0; i < Str.str; i++)
            {
                for (int j = 0; j < Str.col; j++)
                {
                    tempArr[i, j] = mass[i, j];
                }
            }
            if(Str.col == maxcol)
            {
                Str.str++;
            }    
            tempArr[Str.str, Str.col] = el;
            Str.col++;
            mass = tempArr;
        }

        T Igeneric<T>.CheckEl(int _str, int _col)
        {
            return mass[_str, _col];
        }

        T Igeneric<T>.DeleteEl(int _str, int _col)
        {
            T rc = default(T);
            T[,] tempArr = new T[maxstr, maxcol];

            for (int i = 0; i < Str.str; i++)
            {
                for (int j = 0; j < Str.col; j++)
                {
                    if (j == _str && j == _col)
                        rc = mass[i, j];
                    else
                        tempArr[i++, j++] = mass[i, j];
                }
            }
            Str.col--;
            mass = tempArr;

            return rc;
        }

        public void WriteToFile(string path = @"D:\Саша\Учёба\3_семестр_2_курс\Объектно ориентированное программирование и стандарты проектирования\Лабораторные работы\8\OOP_8\file.txt")
        {
            StreamWriter writer = new StreamWriter(path);
            if (writer == null)
                throw new Exception("Файл не открылся");

            for (int i = 0; i < Str.str; i++)
            {
                for (int j = 0; j < Str.col; j++)
                {
                    writer.Write(mass[i, j] + "\t");
                }
                writer.Write("\n");
            }

            writer.Close();
        }

        static public Matrix<char> ReadFromFile(string path = @"D:\Саша\Учёба\3_семестр_2_курс\Объектно ориентированное программирование и стандарты проектирования\Лабораторные работы\8\OOP_8\file_out.txt")
        {
            Matrix<char> d_read = new Matrix<char>();
            using (StreamReader reader = new StreamReader(path))
            {
                if (reader == null)
                    throw new Exception("Файл не открылся");

                char[] temp = reader.ReadLine().ToArray();
               
                int iter = 0;
                for (int l = 0; l < d_read.maxstr && iter < temp.GetLength(0); l++)
                {
                    d_read.Str.str++;
                    for (int j = 0; j < d_read.maxcol && iter < temp.GetLength(0); j++)
                    {
                        d_read.mass[l, j] = temp[iter++];
                        d_read.Str.col++;
                    }
                }
                if (d_read.Str.str >= 1)
                    d_read.Str.col = 25;
            };
            return d_read;
        }
    }

    class Characters
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
    }
    sealed class Warrior : Characters
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

        public override string ToString()
        {
            return $"Тип: {this.GetType()}, Максимальное здоровье:{this.MaxHP},Суперсила: {this.SuperPower}. Войн - очень сильный персонаж с высоким уровнем здоровья.";
        }
        public Warrior(string UN)
        {
            Username = UN; count++;
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
    sealed class Hunter : Characters
    {
        private readonly int StartHP = 50;
        private readonly int MaxHP = 300;
        new string SuperPower = "Теневое клонирование";
        public override void ScreamMotto_Attack()
        {
            Console.WriteLine("I'll kill you quietly...");
        }

        public override string ToString()
        {
            return $"Тип: {this.GetType()}, Максимальное здоровье:{this.MaxHP},Суперсила: {this.SuperPower}. Охотник знаменит своей скоростью и скрытностью.";
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
        public Hunter(string UN)
        {
            Username = UN; count++;
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
            Username = UN; count++;
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
            Username = UN; count++;
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
            Username = UN; count++;
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
    class Program
        {
            static void Main()
            {
            try
            {
                int[,] a = { { 1, 2, 3, 4, 5 }, { 2, 4, 6, 8, 10 }, { 3, 6, 9, 12, 15 } };
                int[,] c = { { 1, 2, 3, 4, 5 }, { 2, 4, 6, 8, 10 }, { 3, 6, 9, 12, 15 } };
                char[,] b = { { '1', '2', '3' }, { '4', '5', '4' }, { '6', '5', '7' } };

                Warrior player_warrior = new Warrior("Игрок 1");
                Hunter player_hunter = new Hunter("Игрок 2");
                Archer player_archer = new Archer("Игрок 3");
                Shaman player_shaman = new Shaman("Игрок 4");

                Characters[,] characters_matrix = { { player_warrior, player_hunter }, { player_archer, player_shaman } };
                Matrix<Characters> characters_M = new Matrix<Characters>(characters_matrix);
                Matrix<int> a_matrix = new Matrix<int>(a);
                Matrix<int> c_matrix = new Matrix<int>(c);
                Matrix<char> b_matrix = new Matrix<char>(b);

                a_matrix = a_matrix + c_matrix;
                Igeneric<char> temp = b_matrix;
                temp.AddEl('B');
                char rc = temp.CheckEl(1, 5);
                rc = temp.DeleteEl(0, 0);

                a_matrix.WriteToFile();

                Matrix<char> d_read = Matrix<char>.ReadFromFile();

                d_read.ReadMat();
                characters_M.ReadMat();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        }   
}

