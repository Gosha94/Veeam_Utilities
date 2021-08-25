using System;
using WinWatcher.Interfaces;

namespace WinWatcher.Services
{
    /// <summary>
    /// Конкретный логгер для вывода на консоль
    /// </summary>
    public class ConsoleLogger : ILogger
    {
        #region Public Properties

        public int SentMessageCounter { get; private set; } = default;

        #endregion

        #region Constructors

        public ConsoleLogger()
        { }

        #endregion

        #region Public API Methods

        public void WriteToLog(string message)
        {
            Console.WriteLine(message);
            this.SentMessageCounter++;
        }

        #endregion
    }
}
