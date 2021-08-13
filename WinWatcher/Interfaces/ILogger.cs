namespace WinWatcher.Interfaces
{
    /// <summary>
    /// Интерфейс логирования действий
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Метод записи в лог
        /// </summary>
        void WriteToLog(string message);
    }
}
