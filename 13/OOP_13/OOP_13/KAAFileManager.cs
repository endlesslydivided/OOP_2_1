using System;
using System.IO;
using System.IO.Compression;

namespace OOP_13
{
    public static class KAAFileManager
    {
        static public void GetAllDirsAndFilesOfDisk(string diskName)
        {
            var allDrives = DriveInfo.GetDrives();
            foreach (var drive in allDrives)
            {
                if (drive.Name == diskName)
                {
                    DirectoryInfo dir = new DirectoryInfo(@"..\TestFolder");
                    if (dir.GetDirectories("KAAInspect").Length == 0)
                    {
                        DirectoryInfo subDir = dir.CreateSubdirectory("KAAInspect");
                        DirectoryInfo dr = new DirectoryInfo(diskName);
                        using (StreamWriter file = new StreamWriter(subDir.FullName + @"\" + "KAAdirinfo.txt"))
                        {
                            file.WriteLine("▬▬▬▬▬▬▬▬▬▬Directories▬▬▬▬▬▬▬▬▬▬");
                            foreach (var d in dr.GetDirectories())
                                file.WriteLine($"{d.Name}");
                            file.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");

                            file.WriteLine("▬▬▬▬▬▬▬▬▬▬Files▬▬▬▬▬▬▬▬▬▬");
                            foreach (var d in dr.GetFiles())
                                file.WriteLine($"{d.Name}");
                            file.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
                        }
                        FileInfo dirinfo = new FileInfo(subDir.FullName + @"\" + "KAAdirinfo.txt");
                        dirinfo.CopyTo(subDir.FullName + @"\" + "KAAdirinfoCOPY.txt");
                        dirinfo.Delete();
                    }
                    break;
                }
            }
        }

        static public void GetAllFilesWithExtension(string dirPath, string extension)
        {
            DirectoryInfo directory = new DirectoryInfo(dirPath);
            if (directory.Exists)
            {
                DirectoryInfo temp = new DirectoryInfo(@"..\OOP_13");
                if (temp.GetDirectories("KAAFiles").Length == 0 &&
                    temp.GetDirectories("KAAInspect")[0].GetDirectories("KAAFiles").Length == 0)
                {
                    DirectoryInfo Files = temp.CreateSubdirectory("KAAFiles");

                    foreach (var file in directory.GetFiles($"*{extension}"))
                        file.CopyTo(Files.FullName + @"\" + file.Name);

                    Files.MoveTo(temp.GetDirectories("KAAInspect")[0].FullName + "\\KAAFiles");
                }
            }
        }

        static public void CreateZIP(string dir)
        {
            string zipName = @"..\TestFolder\KAAInspect\KAAFiles.zip";
            if (new DirectoryInfo(@"..\TestFolder\KAAInspect").GetFiles("*.zip").Length == 0)
            {
                ZipFile.CreateFromDirectory(dir, zipName);
                DirectoryInfo direct = new DirectoryInfo(dir);
                foreach (var innerFile in direct.GetFiles())
                    innerFile.Delete();
                direct.Delete();
                ZipFile.ExtractToDirectory(zipName, dir);
            }
        }
    }
}
