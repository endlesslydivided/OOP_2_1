using System;


namespace OOP_13
{
    static public class KAADiskInfo
    {
        static public void GetFreeDrivesSpace()
        {
            var AllDrives = System.IO.DriveInfo.GetDrives();
            foreach (var Drive in AllDrives)
            {
                Console.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
                Console.WriteLine($"Имя диска: {Drive.Name}");
                Console.WriteLine($"Тип диска: {Drive.DriveType}");
                if (!Drive.IsReady) continue;
                Console.WriteLine($"Метка тома: {Drive.VolumeLabel}");
                Console.WriteLine($"Файловая система: {Drive.DriveFormat}");
                Console.WriteLine($"Корневая директория: {Drive.RootDirectory}");
                Console.WriteLine($"Общий объём: {Drive.TotalSize / Math.Pow(10, 9)} Гб");
                Console.WriteLine($"Свободный объём: {Drive.TotalFreeSpace / Math.Pow(10, 9)} Гб");
                Console.WriteLine($"Доступный объём: {Drive.AvailableFreeSpace / Math.Pow(10, 9)} Гб");
                Console.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            }
        }
    }
}
