using System;
using System.IO;

namespace OOP_13
{
    class KAALog
    {
        static public StreamWriter logfile;

        static KAALog()
        {
            using (logfile = new StreamWriter(@"..\KAALogFile.txt", true))
                logfile.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬Logger▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
        }

        static public void WriteToLog(string action, string fileName = "", string path = "")
        {
            using (logfile = new StreamWriter(@"..\KAALogFile.txt", true))
            {
                DateTime time = new DateTime();
                time = DateTime.Now;
                logfile.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
                logfile.WriteLine($"Действие: {action}");

                if (fileName.Length != 0)
                    logfile.WriteLine($"Имя файла: {fileName}");

                if (path.Length != 0)
                    logfile.WriteLine($"Путь: {path}");

                logfile.WriteLine($"Время: {time.ToLocalTime()}");
                logfile.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            }
        }
    }
   
}
