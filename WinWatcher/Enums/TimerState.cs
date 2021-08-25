namespace WinWatcher.Enums
{
    /// <summary>
    /// Перечисление возможных состояний таймера
    /// </summary>
    public enum TimerState
    {
        /// <summary>
        /// В работе
        /// </summary>
        Working ,

        /// <summary>
        /// Остановлен
        /// </summary>
        Stopped ,

        /// <summary>
        /// Объект таймера собран Garbage Collector-ом
        /// </summary>
        Disposed
        
    }
}
