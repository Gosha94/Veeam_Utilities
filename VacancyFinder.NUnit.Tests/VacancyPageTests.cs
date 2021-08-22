using System;
using NUnit.Framework;
using VacancyFinder.Service;
using VacancyFinder.Controllers;
using OpenQA.Selenium;
using VacancyFinder.PageObjects;
using System.Drawing;

namespace VacancyFinder.NUnit.Tests
{
    [TestFixture]
    public class VacancyPageTests
    {
        /// <summary>
        /// Поле для тестовых аргументов
        /// </summary>
        private String[] _testArguments;

        private VacancyController _vacancyController;
        private IWebDriver        _webDriver;
        private VacancyPage       _vacancyPageUnderTests;

        [SetUp]
        public void Setup()
        {
            _testArguments      = new String[] { "Отдел разработки", "Английский", "6" };
            _vacancyController  = new VacancyController(_testArguments);
            _webDriver          = _vacancyController.ConfiguredWebDriverInstance;
        }

        [Test]        
        public void SelectDepartmentFromDropDownListTest_PassWhenDepartmentNameCorrect()
        {
            
            Assert.True(_webDriver.Title.Contains("Veeam"));
        }

        [Test]
        public void SelectLanguageFromDropDownListTest_PassWhenLanguageNameCorrect()
        {
            Assert.True(_webDriver.Title.Contains("Veeam"));
        }

        [Test]
        public void CheckIfWindowIsMaximized_PassIfBrowserSizeEqualsScreenSize()
        {
            // Arrange
            var displayServ = new DisplayService();
            var expectedWindowSize = displayServ.GetDisplayResolution();

            // Act
            _vacancyPageUnderTests.ExpandBrowser(_webDriver);
            var actualWindowSize = _vacancyPageUnderTests.PageSize;

            var isScreenMaximized = IsScreensSizesEqual(expectedWindowSize, actualWindowSize);
            // Assert
            Assert.IsTrue(isScreenMaximized);
        }

        #region Help Test Private Methods

        private bool IsScreensSizesEqual(Size firstScreenSz, Size secondScreenSz)
            => firstScreenSz.Width == secondScreenSz.Width
                 &&  firstScreenSz.Height == secondScreenSz.Height;

        #endregion

    }
}