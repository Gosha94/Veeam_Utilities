using System;
using WinWatcher.Interfaces;

namespace WinWatcher.Services
{
    /// <summary>
    /// Конкретный логгер для вывода на консоль
    /// </summary>
    public class ConsoleLogger : ILogger
    {
        public void WriteToLog(string message)
        {
            Console.WriteLine(message);
        }
    }
}
