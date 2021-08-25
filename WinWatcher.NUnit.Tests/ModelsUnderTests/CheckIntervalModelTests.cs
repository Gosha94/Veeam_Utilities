using NUnit.Framework;
using WinWatcher.Models;

namespace WinWatcher.NUnit.Tests
{
    [TestFixture]
    public class CheckIntervalModelTests
    {
        private int                 _testLifeTimeProcess;
        private int                 _testFrequencyCheckProcess;
        private CheckIntervalModel  _checkIntervalModelUnderTests;

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
        [TestCase(40, 8)]
        public void CalculateIntervalDataFromMinToMsecPositiveNumbersTest_PassIfReturnsCorrectIntervalDtoModel
            (int testLifeTimeInSec, int testFrequencyInSec)
        {
            // Arrange
            var expectedIntervalDto = new IntervalDto()
            {
                ProcessLifeTimeInMsec = testLifeTimeInSec  * 60000  ,
                CheckFrequencyInMsec  = testFrequencyInSec * 60000
            };
            
            _checkIntervalModelUnderTests = new CheckIntervalModel(testLifeTimeInSec, testFrequencyInSec);

            // Act
            var actualIntervalDto = _checkIntervalModelUnderTests.GetCalculatedIntervalData();            
            var isDtoEqual = actualIntervalDto.Equals(expectedIntervalDto);
            
            // Assert
            Assert.IsTrue(isDtoEqual);
        }

        [TestCase(-10, -1)]
        [TestCase(-20, -3)]
        [TestCase(-13, -7)]
        public void CalculateIntervalDataFromMinToMsecNegativeNumbersTest_PassIfReturnsCorrectIntervalDtoModel
            (int testLifeTimeInSec, int testFrequencyInSec)
        {
            // Arrange
            var expectedIntervalDto = new IntervalDto()
            {
                ProcessLifeTimeInMsec = testLifeTimeInSec * (-1) * 60000  ,
                CheckFrequencyInMsec = testFrequencyInSec * (-1) * 60000
            };

            _checkIntervalModelUnderTests = new CheckIntervalModel(testLifeTimeInSec, testFrequencyInSec);

            // Act
            var actualIntervalDto = _checkIntervalModelUnderTests.GetCalculatedIntervalData();
            var isDtoEqual = actualIntervalDto.Equals(expectedIntervalDto);

            // Assert
            Assert.IsTrue(isDtoEqual);
        }
        
    }
}
