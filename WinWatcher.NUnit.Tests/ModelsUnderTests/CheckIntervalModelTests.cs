using NUnit.Framework;
using WinWatcher.Models;

namespace WinWatcher.NUnit.Tests
{
    [TestFixture]
    public class CheckIntervalModelTests
    {
        private int _testLifeTimeProcess;
        private int _testFrequencyCheckProcess;
        private CheckIntervalModel  _checkIntervalModelUnderTests;
        private IntervalDto         _correctTestIntervalDto;

        [SetUp]
        public void StartBeforeEachTest()
        {
            _testLifeTimeProcess = 10;
            _testFrequencyCheckProcess = 1;
            
            _checkIntervalModelUnderTests = new CheckIntervalModel(_testLifeTimeProcess, _testFrequencyCheckProcess);

            
        }

        [Test]
        [TestCase(10, 1)]
        [TestCase(20, 3)]
        [TestCase(13, 7)]
        public void CalculatedIntervalDataTest_PassIfReturnsCorrectIntervalDtoModel(int testLifeTimeInSec, int testFrequencyInSec)
        {
            // Arrange
            _correctTestIntervalDto = new IntervalDto()
            {
                ProcessLifeTimeInMsec = testLifeTimeInSec * 60000,
                CheckFrequencyInMsec = testFrequencyInSec * 60000
            };
            
            _checkIntervalModelUnderTests = new CheckIntervalModel(testLifeTimeInSec, testFrequencyInSec);
            var actualIntervalDto = 
            // Act


            // Assert



            var actualInvervalsDto = _checkIntervalModelUnderTests.GetCalculatedIntervalData();

            Assert.AreEqual();
        }
    }
}
