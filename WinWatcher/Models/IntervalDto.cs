namespace WinWatcher.Models
{
    /// <summary>
    /// Класс без методов для передачи данных между службами
    /// </summary>
    public sealed class IntervalDto
    {
        public int ProcessLifeTimeInMsec { get; set; }
        public int CheckFrequencyInMsec  { get; set; }        
    }
}
