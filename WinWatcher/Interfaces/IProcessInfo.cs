namespace WinWatcher.Interfaces
{
    /// <summary>
    /// Интерфейс, необходим для передачи только необходимых полей между службами
    /// </summary>
    public interface IProcessInfo
    {
        /// <summary>
        /// Имя процесса
        /// </summary>
        string ProcessName { get; }

        /// <summary>
        /// Время жизни процесса в минутах
        /// </summary>
        int ProcessLifeTime { get; }

        /// <summary>
        /// Частота опроса на завершение процесса в минутах
        /// </summary>
        int CheckFrequency { get; }
    }
}
