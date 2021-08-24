using NUnit.Framework;
using WinWatcher.Models;

namespace WinWatcher.NUnit.Tests
{
    [TestFixture]
    public class CheckIntervalModelTests
    {
        private CheckIntervalModel  _checkIntervalModelUnderTests;
        private IntervalDto         _testIntervalDto;

        [SetUp]
        public void StartBeforeEachTest()
        { }

        [Test]
        [TestCase(10, 20)]
        public void CalculatedIntervalDataTest_PassIfReturnsCorrectIntervalDtoModel(int testLifeTime, int testFrequency)
        {
            _checkIntervalModelUnderTests = new CheckIntervalModel(testLifeTime, testFrequency);
            _checkIntervalModelUnderTests.GetCalculatedIntervalData();
        }
    }
}
