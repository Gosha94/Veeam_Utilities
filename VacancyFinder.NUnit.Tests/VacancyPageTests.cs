using System;
using NUnit.Framework;
using VacancyFinder.Controllers;

namespace VacancyFinder.NUnit.Tests
{
    [TestFixture]
    public class VacancyPageTests
    {
        /// <summary>
        /// Поле для тестовых аргументов
        /// </summary>
        private String[] _testArguments;
        private VacancyController _testController;

        [SetUp]
        public void Setup()
        {
            _testArguments  = new String[] { "Отдел разработки", "Английский", "6" };
            _testController = new VacancyController(_testArguments);
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

    }
}