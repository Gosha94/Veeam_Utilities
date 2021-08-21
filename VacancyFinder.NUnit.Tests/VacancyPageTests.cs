using NUnit.Framework;

namespace VacancyFinder.NUnit.Tests
{
    [TestFixture]
    public class VacancyPageTests
    {

        [SetUp]
        public void Setup()
        {

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