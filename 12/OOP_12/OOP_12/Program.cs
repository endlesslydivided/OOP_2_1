using OOP_12;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using static System.Console;

namespace OOP_12
{
    
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine(Reflector.GetAssemblyName(typeof(Int32)));
            Reflector.ContainPublicConstructors(typeof(List<int>));
            WriteLine("\n Вывод публичных методов в файл:");
            using (StreamWriter sw = new StreamWriter("publicMethods.txt"))
            {
                foreach (var item in Reflector.GerPublicMethods(typeof(List<int>)))
                {
                    WriteLine(item);
                    sw.WriteLine(item);
                }
            }
            WriteLine("\n Вывод свойтв и полей в файл:");
            using (StreamWriter sw = new StreamWriter("Properties_fields.txt"))
            {
                foreach (var item in Reflector.GetProperties(typeof(List<int>)))
                {
                    WriteLine(item);
                    sw.WriteLine(item);
                }
            }
            WriteLine("\n Вывод интерфесов в файл:");
            using (StreamWriter sw = new StreamWriter("Interfaces.txt"))
            {
                foreach (var item in Reflector.GetInterfaces(typeof(List<int>)))
                {
                    WriteLine(item);

                    sw.WriteLine(item);

                }
            }
            WriteLine("\n Вывод методов-по-параметрам в файл:");
            using (StreamWriter sw = new StreamWriter("Methodsbyparams.txt"))
            {
                foreach (var item in Reflector.GetMethodsByParams(typeof(List<int>), "Int32"))
                {
                    WriteLine(item);
                    sw.WriteLine(item);
                }
            }
            Reflector.GetResult(typeof(SuperString));
        }
    }
}
    
