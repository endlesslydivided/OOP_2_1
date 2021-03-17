using OOP_7.Exceptions;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace OOP_7.Logger_
{
    static class Logger_
    {
        private static async Task ReportLog(bool toFile, string Path, string log)
        {
            if (toFile)
                using (StreamWriter writer = new StreamWriter(Path))
                {
                    await writer.WriteAsync(log);
                }
            
            else
            {
                var thread = new Thread(() =>
                {
                    Console.WriteLine(log);
                }
                );
                thread.Start();
            }
        }
        public static async Task WriteLog<T>(IControlException<T> exception = null, bool toFile = false, string Path = "log.txt")
        {
            DateTime time = DateTime.Now;
            string toLog = $"{time} INFO:\n" + $"{exception} \n{exception.Value}";

            await ReportLog(toFile, Path, toLog);
        }
        public static async Task WriteLog(Army.Characters element = null, bool toFile = false, string Path = "log.txt")
        {
            DateTime time = DateTime.Now;

            Debug.Assert(element != null, "Не существует персонажа!");
            string toLog = $"{time} INFO:\n" + $"{element.type} имя: {element.Username}; атака: {element.attack};  текущее здоровье: {element.CurrentHP}";

            await ReportLog(toFile, Path, toLog);
        }
    }

    static class ConsoleLogger
    {
        public static async Task WriteLog<T>(IControlException<T> exception = null, string _FilePath = "log.txt")
        {
            await Logger_.WriteLog<T>(exception, Path: _FilePath);
        }
    }
    static class FileLogger
    {
        public static async Task WriteLog<T>(IControlException<T> exception = null, string _FilePath = "log.txt")
        {
            await Logger_.WriteLog<T>(exception, true, Path: _FilePath);
        }
    }

}
