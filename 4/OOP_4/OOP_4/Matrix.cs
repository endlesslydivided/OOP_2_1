using System;
using System.Collections.Generic;
using System.Text;

namespace Matrix_NS
{
    public class Matrix
    {
        public int str;
        public int col;
        private int[,] mass;

        public Matrix() { }
        public int _col
        {
            get { return col; }
            set { if (value > 0) col = value; }
        }
        public int _str
        {
            get { return str; }
            set { if (value > 0) str = value; }
        }

        public Matrix(int n,int k)
        {
            this.str = n;
            this.col = k;
            mass = new int[this.str, this.col];
        }

        public int this[int i, int j]
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

        public void WriteMat()
        {
            for (int i = 0; i < str; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.WriteLine("Введите элемент матрицы {0}:{1}", i + 1, j + 1);
                    mass[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
        public void ReadMat()
        {
            for (int i = 0; i < str; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write(mass[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public static Matrix minus_number(Matrix a, int n)
        {
            Matrix result = new Matrix(a.str,a.col);
            for (int i = 0; i < a.str; i++)
            {
                for (int j = 0; j < a.col; j++)
                {
                    result[i, j] = a[i, j] - n;
                }
            }
            return result;
        }
        public static Matrix matrix_increment(Matrix a)
        {
            Matrix result = new Matrix(a.str, a.col);
            for (int i = 0; i < a.str; i++)
            {
                for (int j = 0; j < a.col; j++)
                {
                    result[i, j] = a[i, j] + 1;
                }
            }
            return result;
        }
        public static bool matrix_abs_compare(Matrix a, Matrix b)
        {
            if (a.str != b.str || a.col != b.col)
                return true;
            for (int i = 0; i < a.str; i++)
            {
                for (int j = 0; j < a.col; j++)
                {
                    if (a[i, j] != b[i, j])
                        return true;
                }
            }
            return false;
        }
        public static int matrix_zero_elements(Matrix a)
        {
            int zero_q = 0;
            for (int i = 0; i < a.str; i++)
            {
                for (int j = 0; j < a.col; j++)
                {
                    if (a[i, j] == 0) zero_q++;
                }
            }
            return zero_q;
        }


        public static Matrix operator - (Matrix a, int n)
        {
            return minus_number(a, n);
        }
        public static Matrix operator ++(Matrix a)
        {
            return matrix_increment(a);
        }
        public static bool operator ==(Matrix a, Matrix b)
        {
            return !matrix_abs_compare(a, b);
        }
        public static bool operator !=(Matrix a,Matrix b)
        {
            return !(a==b);
        }
        public static implicit operator int(Matrix a)
        {
            return matrix_zero_elements(a);
        }

        object Owner = new { id = "324234", name = "Ковалё Александр", firm = "OOTP" };
        class Date
        {
            static int day_creation = 23;
            static int month_creation = 9;
            static int year_creation = 2020;
        }
        
       
    }
}
