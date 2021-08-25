using NUnit.Framework;
using WinWatcher.Services;

namespace WinWatcher.NUnit.Tests.ServicesUnderTests
{
    [TestFixture]
    public class ConsoleLoggerTests
    {

        private ConsoleLogger _consoleLoggerUnderTests;

        [SetUp]
        public void SetUpBeforeEachTest()
        {
            _consoleLoggerUnderTests = new ConsoleLogger();
        }

        [Test]
        public void WriteLogTest_PassedIfTheMessageWasSentSuccessfuly()
        {

            // Arrange
            var testMessage = "test message for consoleLogger";
            var expectedLogWriteCounter = 1;

            // Act
            _consoleLoggerUnderTests.WriteToLog(testMessage);
            var actualLogWriteCounter = _consoleLoggerUnderTests.SentMessageCounter;

            // Assert
            Assert.AreEqual(expectedLogWriteCounter, actualLogWriteCounter);

        }

    }
}
