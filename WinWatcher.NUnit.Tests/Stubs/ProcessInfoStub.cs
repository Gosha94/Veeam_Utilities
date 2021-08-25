using WinWatcher.Interfaces;

namespace WinWatcher.NUnit.Tests.Stubs
{
    /// <summary>
    /// Класс-заглушка, для имитации информации о наблюдаемом процессе
    /// </summary>
    public class ProcessInfoStub : IProcessInfo
    {
        public string ProcessName { get; private set; } = "TestProcessName.exe";

        public int ProcessLifeTime { get; private set; } = -999;

        public int CheckFrequency { get; private set; } = -999;
    }
}
