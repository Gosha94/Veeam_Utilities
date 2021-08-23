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
        private String[]          _correctTestArguments;
        private VacancyController _vacancyController;
        private IWebDriver        _webDriver;
        private VacancyPage       _vacancyPageUnderTests;

        [SetUp]
        public void Setup()
        {
            _correctTestArguments   = new string[] { "Разработка продуктов", "Английский", "6" };
            _vacancyController      = new VacancyController(_correctTestArguments);
            _webDriver              = _vacancyController.ConfiguredWebDriverInstance;
            _vacancyPageUnderTests  = new VacancyPage(_webDriver);
        }

        [TearDown]
        public void EachTestEnd()
        {
            _vacancyPageUnderTests.ClosePage();
            _webDriver.Dispose();
        }

        [Test]
        public void GoToUrlTest_PassWhenWebPageTitleIsCorrect()
        {

            // Arrange
            var expectedTitle = "Работа в IT компании Veeam Software";

            // Act
            _vacancyPageUnderTests.GoToUrl();
            var actualTitle = _webDriver.Title;

            // Assert
            Assert.AreEqual(expectedTitle, actualTitle);
        }

        [Test]        
        public void SelectDepartmentFromDropDownListTest_PassWhenDepartmentNameCorrect()
        {
            // Arrange
            _vacancyPageUnderTests.SignInSite();
            var expectedDeptBtnText = _correctTestArguments[0];

            // Act
            var actualDeptBtnText = _vacancyPageUnderTests.SelectDepartamentOnSite(_correctTestArguments[0]);
            
            // Assert
            Assert.AreEqual(expectedDeptBtnText, actualDeptBtnText);
        }

        [Test]
        public void SelectLanguageFromDropDownListTest_PassWhenLanguageNameCorrect()
        {
            // Arrange
            _vacancyPageUnderTests.SignInSite();
            var expectedLanguageBtnText = _correctTestArguments[1];

            // Act
            var actualLanguageBtnText = _vacancyPageUnderTests.SelectLanguageOnSite(_correctTestArguments[1]);

            // Assert
            Assert.AreEqual(expectedLanguageBtnText, actualLanguageBtnText);
        }

        [Test]
        public void CheckIfWindowIsMaximized_PassIfBrowserSizeEqualsScreenSize()
        {
            // Arrange
            var browserHeaderSize = ( Width: 16, Height: 24 );

            var displayService = new DisplayService();
            var displayResolution = displayService.GetDisplayResolution();
            var expectedWindowSize = new Size(displayResolution.Width + browserHeaderSize.Width, displayResolution.Height - browserHeaderSize.Height);

            // Act
            _vacancyPageUnderTests.ExpandBrowser();
            var actualWindowSize = _vacancyPageUnderTests.PageSize;
            var isScreenMaximized = IsScreensSizesEqual(expectedWindowSize, actualWindowSize);

            // Assert
            Assert.IsTrue(isScreenMaximized);
        }

        #region Help Test Private Methods

        private bool IsScreensSizesEqual(Size firstScreenSz, Size secondScreenSz)
        {
            if (firstScreenSz.Width == secondScreenSz.Width
                 && firstScreenSz.Height == secondScreenSz.Height)
            {
                return true;
            }
            return false;
        }

        #endregion

    }
}