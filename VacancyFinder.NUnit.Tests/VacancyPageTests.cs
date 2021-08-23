using System;
using NUnit.Framework;
using VacancyFinder.Service;
using VacancyFinder.Controllers;
using OpenQA.Selenium;
using VacancyFinder.PageObjects;
using System.Drawing;
using TestProject.SDK.Interfaces;

namespace VacancyFinder.NUnit.Tests
{
    [TestFixture]
    public class VacancyPageTests
    {
        /// <summary>
        /// Поле для тестовых аргументов
        /// </summary>
        private String[]          _testArguments;
        private VacancyController _vacancyController;
        private IWebDriver        _webDriver;
        private VacancyPage       _vacancyPageUnderTests;

        [SetUp]
        public void Setup()
        {
            _testArguments          = new String[] { "Разработка продуктов", "Английский", "6" };
            _vacancyController      = new VacancyController(_testArguments);
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
            IWebElement departmentButton;
            _vacancyPageUnderTests.SignInSite();

            // Act
            departmentButton = _vacancyPageUnderTests.SelectDepartamentOnSite(_testArguments[0]);
            var text = departmentButton.Text;
            // Assert
            Assert.True(departmentButton.Text.Contains("Разработка продуктов"));
        }

        [Test]
        public void SelectLanguageFromDropDownListTest_PassWhenLanguageNameCorrect()
        {
            // Arrange            
            IWebElement languageButton;

            // Act
            languageButton = _vacancyPageUnderTests.SelectLanguageOnSite(_testArguments[1]);

            // Assert
            Assert.True(languageButton.Text.Contains("Английский"));
        }

        [Test]
        public void CheckIfWindowIsMaximized_PassIfBrowserSizeEqualsScreenSize()
        {
            // Arrange            
            var expectedWindowSize = new Size(1936, 1056);

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