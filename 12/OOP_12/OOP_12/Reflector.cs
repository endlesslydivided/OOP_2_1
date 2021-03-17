using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace OOP_12
{
    static class Reflector
    {
        public static string GetAssemblyName(Type type)
        {
            return type.AssemblyQualifiedName;
        }
        public static void ContainPublicConstructors(Type type)
        {
            ConstructorInfo[] p = type.GetConstructors();
            Console.WriteLine($"Количество конструкторов класса {type.Name}: {p.Length}. Перечень конструкторов:");

            for (int i = 0; i < p.Length; i++)
            {
                Console.WriteLine(i + 1 + "." + p[i]);
            }
        }
        public static IEnumerable<string> GerPublicMethods(Type type)
        {
            var methods = type.GetMethods();
            List<string> methodsList = new List<string>();
            foreach (var item in methods)
            {
                methodsList.Add(item.ToString());
            }
            return methodsList;
        }
        public static IEnumerable<string> GetProperties(Type type)
        {

            var properties = type.GetProperties();
            var fields = type.GetFields();
            List<string> methods_list = new List<string>();
            foreach (var item in properties)
            {
                methods_list.Add(item.ToString());
            }
            methods_list.Add("");
            foreach (var item in fields)
            {
                methods_list.Add(item.ToString());
            }
            return methods_list;
        }
        public static IEnumerable<string> GetInterfaces(Type type)
        {

            var methods = type.GetInterfaces();
            List<string> methods_list = new List<string>();
            foreach (var item in methods)
            {
                methods_list.Add(item.ToString());
            }
            return methods_list;
        }
        public static IEnumerable<string> GetMethodsByParams(Type type, string paramType)
        {
            List<string> methods_list = new List<string>();
            int count = 0;
            foreach (MethodInfo method in type.GetMethods())
                foreach (ParameterInfo p in method.GetParameters())
                    if (paramType.Equals(p.ParameterType.Name))
                    {
                        methods_list.Add(method.Name);
                        count++;
                    }
            return methods_list;
        }

        public static void GetResult(Type classType, string methodName = "Str_length_sum")
        {
            object obj = Activator.CreateInstance(classType);
            MethodInfo methodInfo = classType.GetMethod(methodName);
            StreamReader streamReader = new StreamReader(@"..\paramsForSum.txt");

            object result = methodInfo.Invoke(obj, new object[] { Convert.ToString(streamReader.ReadLine()), Convert.ToString(streamReader.ReadLine()) });
            Console.WriteLine($"Результат вызванного метода: {result}");
        }
    }
}
