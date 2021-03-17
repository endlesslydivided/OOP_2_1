using System;
using System.IO;

namespace OOP_13
{
    static public class KAADirInfo
    {
        static DirectoryInfo GetParentDirs(DirectoryInfo dirInfo)
        {
            if (dirInfo == null)
                return dirInfo;

            Console.WriteLine($"{dirInfo.Name}");
            return GetParentDirs(dirInfo.Parent);
        }

        static public string GetDirInfo(string dir)
        {
            System.Console.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            if (!dirInfo.Exists)
            {
                System.Console.WriteLine("Файл не найден");
                return "...";
            }
            Console.WriteLine($"Количество поддиректориев: {dirInfo.GetDirectories().Length}");
            Console.WriteLine($"Количество файлов: {dirInfo.GetFiles().Length}");
            Console.WriteLine($"Время создания директории: {dirInfo.CreationTime}");
            Console.WriteLine("\nРодительские директории:");
            GetParentDirs(dirInfo.Parent);
            System.Console.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            return Convert.ToString(dirInfo.GetDirectories());
        }
    }
}
