using NUnit.Framework;
using System;
using WinWatcher.Models;

namespace WinWatcher.NUnit.Tests.ModelsUnderTests
{
    [TestFixture]
    public class InputArgumentsModelTests
    {
        private string[] _correctTestArgs;
        private InputArgumentsModel _inputModelUnderTests;

        [SetUp]
        public void Setup()
        {
            _correctTestArgs = new string[] { "testApp.exe", "15", "15" };
            _inputModelUnderTests = new InputArgumentsModel(_correctTestArgs);
        }

        [Test]
        public void CorrectProcessNameTest_PassIfProcessNameIsCorrect()
        {
            // Arrange
            // Exclude .exe extension
            var expectedProcessName = _correctTestArgs[0].Split(".")[0];

            // Act
            var actualProcessName = _inputModelUnderTests.ProcessName;

            // Assert
            Assert.AreEqual(expectedProcessName, actualProcessName);
        }

        [Test]
        public void CorrectProcessLifeTimeTest_PassIfProcessLifeTimeIsCorrect()
        {
            // Arrange
            var expectedProcessLifeTime = Convert.ToInt32(_correctTestArgs[1]);

            // Act
            var actualProcessLifeTime = _inputModelUnderTests.ProcessLifeTime;

            // Assert
            Assert.AreEqual(expectedProcessLifeTime, actualProcessLifeTime);
        }

        [Test]
        public void CorrectCheckFrequencyTest_PassIfCheckFrequencyIsCorrect()
        {
            // Arrange
            var expectedCheckFrequency = Convert.ToInt32(_correctTestArgs[2]);

            // Act
            var actualCheckFrequency = _inputModelUnderTests.CheckFrequency;

            // Assert
            Assert.AreEqual(expectedCheckFrequency, actualCheckFrequency);
        }

        [Test]
        public void WrongArgumentsNumberTest_PassIfThrowsArgumentException()
        {
            // Arrange
            var wrongNumberTestArgs = new string[] { "wrongArgs.exe", "15", "15", "999" };

            // Act

            // Assert
            Assert.Throws<ArgumentException>
            (() =>
            {
                _inputModelUnderTests = new InputArgumentsModel(wrongNumberTestArgs);
            });
        }

        [Test]
        public void WrongProcessLifeTimeTest_PassIfThrowsArgumentException()
        {
            // Arrange
            var wrongProcessLifeTimeArgs = new string[] { "wrongProcessLifeTime.exe", "-999", "15" };

            // Act

            // Assert
            Assert.Throws<ArgumentException>
            (() =>
            {
                _inputModelUnderTests = new InputArgumentsModel(wrongProcessLifeTimeArgs);
            });
        }

        [Test]
        public void WrongCheckFrequencyTest_PassIfThrowsArgumentException()
        {
            // Arrange
            var wrongCheckFrequencyArgs = new string[] { "wrongCheckFrequency.exe", "15", "-999" };

            // Act

            // Assert
            Assert.Throws<ArgumentException>
            (() =>
            {
                _inputModelUnderTests = new InputArgumentsModel(wrongCheckFrequencyArgs);
            });
        }

        [Test]
        public void WrongArgsWithoutExtensionTest_PassIfThrowsArgumentException()
        {
            // Arrange
            var wrongArgsWithoutExtensionArgs = new string[] { "TestProcess", "15", "15" };

            // Act

            // Assert
            Assert.Throws<ArgumentException>
            (() =>
            {
                _inputModelUnderTests = new InputArgumentsModel(wrongArgsWithoutExtensionArgs);
            });
        }

        [Test]
        public void WrongArgsWithIncorrectExtensionTest_PassIfThrowsArgumentException()
        {
            // Arrange
            var wrongArgsWithIncorrectExtension = new string[] { "TestProcess.uncorrect", "15", "15" };

            // Act

            // Assert
            Assert.Throws<ArgumentException>
            (() =>
            {
                _inputModelUnderTests = new InputArgumentsModel(wrongArgsWithIncorrectExtension);
            });
        }

    }
}