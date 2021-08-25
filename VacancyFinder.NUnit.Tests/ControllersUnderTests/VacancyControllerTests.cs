using NUnit.Framework;
using System;
using VacancyFinder.Controllers;

namespace VacancyFinder.NUnit.Tests.ControllersUnderTests
{
    [TestFixture]
    public class VacancyControllerTests
    {
        private VacancyController   _controllerUnderTest;
        private string[]            _correctTestArgs;

        [SetUp]
        public void StartBeforeEachTest()
        {
            _correctTestArgs = new string[] { "Разработка продуктов", "Английский", "6" };
            _controllerUnderTest = new VacancyController(_correctTestArgs);
        }

        [Test]
        public void GetCorrectWebDriverInstance_PassIfPageTitleIsCorrect()
        {
            // Arrange
            var testUrl = "https://www.google.ru";
            var expectedPageTitle = "Google";
            var webDriverUnderTest = _controllerUnderTest.ConfiguredWebDriverInstance;

            // Act
            webDriverUnderTest.Navigate().GoToUrl(testUrl);
            var actualPageTitle = webDriverUnderTest.Title;

            // Assert
            Assert.AreEqual(expectedPageTitle, actualPageTitle);
        }

        [Test]
        public void GetVacanciesNumberTest_PassIfVacanciesNumberIsSame()
        {
            // Arrange
            var expectefVacanciesNumber = Convert.ToInt32(_correctTestArgs[2]);
            _controllerUnderTest = new VacancyController(_correctTestArgs);

            // Act
            var actualVacanciesNumber = _controllerUnderTest.CountConcreteVacancies();

            // Assert
            Assert.AreEqual(expectefVacanciesNumber, actualVacanciesNumber);
        }

        [Test]
        public void CheckWrongVacanciesNumberTest_PassIfThrowsAnArgumentException()
        {
            // Arrange
            var wrongVacanciesNumberTestArgs = new string[] { "Разработка продуктов", "Английский", "15" };
            _controllerUnderTest = new VacancyController(wrongVacanciesNumberTestArgs);

            // Assert
            Assert.Throws<ArithmeticException>(() =>
            {
                _controllerUnderTest.CountConcreteVacancies();
            });
        }

    }
}
