using System;

namespace OOP_11
{
    class SuperString : IComparable
    {
        private string _str;
        public string Str { get { return _str; } set { _str = value; } }
        
        private int _id;
        public int ID { get { return _id; } private set { _id= value; } }

        readonly string type = "string";
        private readonly string _comment;
        public string Comment { get { return _comment; } }

        static readonly int length;
        static int object_quantity = 0;

        public bool Symbol_in(char symbol)
        {
            for (int iter = 0; iter < _str.Length; iter++)
            {
                if (_str[iter] == symbol)
                {
                    return true;
                }
            }
            return false;
        }
        public int Str_length()
        {
            return this.Str.Length;
        }
        public string Str_change_symbol(char a, char b)
        {
            for (int iter = 0; iter < _str.Length; iter++)
            {
                if (_str[iter] == a)
                {
                    _str.Replace(_str[iter], b);
                    return _str;
                }
            }
            return _str;
        }

        public SuperString()
        {
            _str = "\0";
            _comment = "пустая строка";
            object_quantity++;
        }
        static SuperString()
        {
            length = 255;
            object_quantity++;
        }
        public SuperString(string str_insert,string comment_insert)
        {
           
            _str = str_insert;
            if (string.IsNullOrEmpty(_comment))
                _comment = "пустой комменарий";
            else
                _comment = comment_insert;
            ID = GetHashCode();
            object_quantity++;
           
        }
        public SuperString(string str_insert)
        {
            _str = str_insert;
            if (string.IsNullOrEmpty(str_insert))
                _comment = "пустая строка";
            else
                _comment = $"длина строки: {str_insert.Length}";
            object_quantity++;
        }

        public static void Copy(ref string x, out string y)
        {
            y = x;
        }

        public override bool Equals (object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                SuperString sp = (SuperString)obj;
                return (_str == sp._str);
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return string.Format($"{_str}");
        }

        public int CompareTo(object obj)
        {
            if (obj is SuperString)
            {
                SuperString obj_ss = obj as SuperString;
                if (this.Str_length() < obj_ss.Str_length())
                {
                    return -1;
                }
                else if (this.Str_length() > obj_ss.Str_length())
                {
                    return 1;
                }
                return 0;
            }
            return 0;
        }

    }
}