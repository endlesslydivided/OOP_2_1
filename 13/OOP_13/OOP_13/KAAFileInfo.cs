using System.IO;
using System;

namespace OOP_13
{
    static public class KAAFileInfo
    {
        static public void GetFileinfo(string file)
        {
            Console.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            FileInfo fileInfo = new FileInfo(file);
            if (!fileInfo.Exists)
            {
                Console.WriteLine("Файл не найден");
                return;
            }
            Console.WriteLine($"Полный путь: {fileInfo.FullName}");
            Console.WriteLine($"Рамзер: {fileInfo.Length} byte");
            Console.WriteLine($"Имя: {fileInfo.Name}");
            Console.WriteLine($"Расширение: {fileInfo.Extension}");
            Console.WriteLine($"Время создания: {fileInfo.CreationTime}");
            Console.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
        }
    }
}
