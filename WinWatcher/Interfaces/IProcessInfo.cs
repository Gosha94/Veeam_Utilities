namespace WinWatcher.Interfaces
{
    /// <summary>
    /// Интерфейс, необходим для передачи только необходимых полей между службами
    /// </summary>
    public interface IProcessInfo
    {
        string ProcessName { get; }
        int ProcessLifeTime { get; }
        int CheckFrequency { get; }
    }
}
