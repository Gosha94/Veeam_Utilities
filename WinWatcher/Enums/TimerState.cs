namespace WinWatcher.Enums
{
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
