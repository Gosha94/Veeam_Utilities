using NUnit.Framework;
using WinWatcher.Services;
using WinWatcher.Interfaces;
using WinWatcher.NUnit.Tests.Stubs;
using WinWatcher.Enums;

namespace WinWatcher.NUnit.Tests.ServicesUnderTests
{
    [TestFixture]
    public class ProcessWatcherServiceTests
    {        
        
        private TimerState              _actualTimerState;
        private IProcessInfo            _stubOfProcessInfo;
        private ProcessWatcherService   _processWatcherServiceUnderTests;

        [SetUp]
        public void Setup()
        {
            _stubOfProcessInfo = new ProcessInfoStub();
            _processWatcherServiceUnderTests = new ProcessWatcherService(_stubOfProcessInfo);
        }
        
        [Test]
        public void StartWatchProcessTest_PassedIfTimerIsStarted()
        {
            // Arrange
            var expectedTimerState = TimerState.Working;

            // Act
            _processWatcherServiceUnderTests.StartWatchProcess();
            _actualTimerState = _processWatcherServiceUnderTests.ActualTimerState;

            // Assert
            Assert.AreEqual(expectedTimerState, _actualTimerState);
        }

        [Test]
        public void StopWatchProcessTest_PassedIfTimerIsStopped()
        {
            // Arrange
            var expectedTimerState = TimerState.Stopped;

            // Act
            _processWatcherServiceUnderTests.StopWatchProcess();
            _actualTimerState = _processWatcherServiceUnderTests.ActualTimerState;

            // Assert
            Assert.AreEqual(expectedTimerState, _actualTimerState);
        }

        [Test]
        public void DisposingWatchProcessTest_PassedIfTimerIsDisposed()
        {
            // Arrange
            var expectedTimerState = TimerState.Disposed;

            // Act
            _processWatcherServiceUnderTests.Dispose();
            _actualTimerState = _processWatcherServiceUnderTests.ActualTimerState;

            // Assert
            Assert.AreEqual(expectedTimerState, _actualTimerState);
        }

    }
}
