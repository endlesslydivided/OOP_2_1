using System;

namespace OOP_13
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                KAADiskInfo.GetFreeDrivesSpace();
                KAALog.WriteToLog("KAADiskInfo.getFreeDrivesSpace()");

                KAAFileInfo.GetFileinfo(@"..\KAALogFile.txt");
                KAALog.WriteToLog("KAAFileInfo.getFileinfo()", "KAALogFile.txt", @"..\KAALogFile.txt");

                KAADirInfo.GetDirInfo(@"..\OOP_lab13");
                KAALog.WriteToLog("KAADirInfo.GetDirInfo()", "", @"..\OOP_lab13");

                KAAFileManager.GetAllDirsAndFilesOfDisk(@"D:\");
                KAALog.WriteToLog("KAAFileManager.GetAllDirsAndFilesOfDisk()", "", @"D:\");

                KAAFileManager.GetAllFilesWithExtension(@"..\Саша\Документы\Английский язык", ".docx");
                KAALog.WriteToLog("KAAFileManager.GetAllFilesWithExtensionk()", "", @"..\Саша\Документы\Английский язык");

                KAAFileManager.CreateZIP(@"..\TestFolder\KAAInspect\KAAFiles.txt");
                KAALog.WriteToLog("KAAFileManager.CreateZIP()");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
