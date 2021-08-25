namespace WinWatcher.Interfaces
{
    /// <summary>
    /// Интерфейс логирования действий
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Счетчик отправленных сообщений с момента создания объекта
        /// </summary>
        int SentMessageCounter { get; }

        /// <summary>
        /// Метод записи в лог
        /// </summary>
        void WriteToLog(string message);
    }
}
