using NUnit.Framework;
using System;
using VacancyFinder.Models;

namespace VacancyFinder.NUnit.Tests
{
    [TestFixture]
    public class FindVacancyModelTests
    {
        private FindVacancyModel    _findVacancyModelUnderTests;
        private string[]            _correctTestArgs;

        [SetUp]
        public void StartBeforeEachTest()
        {
            _correctTestArgs = new string[] { "DepartmentTestArg", "LanguageTestAr", "10" };
            _findVacancyModelUnderTests = new FindVacancyModel(_correctTestArgs);
        }

        [Test]
        public void GetDepartmentNameTest_PassIfEqualInputArgument()
        {
            // Arrange
            var expectedDeptName = _correctTestArgs[0];

            // Act
            var actualDeptName = _findVacancyModelUnderTests.DepartmentName;

            // Assert
            Assert.AreEqual(expectedDeptName, actualDeptName);
        }

        [Test]
        public void GetLanguageNameTest_PassIfEqualInputArgument()
        {
            // Arrange
            var expectedLangName = _correctTestArgs[1];

            // Act
            var actualLangName = _findVacancyModelUnderTests.LanguageName;

            // Assert
            Assert.AreEqual(expectedLangName, actualLangName);
        }

        [Test]
        public void GetExpectedVacancyNumberTest_PassIfEqualInputArgument()
        {
            // Arrange
            var expectedVacancyNumb = Convert.ToInt32(_correctTestArgs[2]);

            // Act
            var actualVacancyNumb = _findVacancyModelUnderTests.VacancyNumber;

            // Assert
            Assert.AreEqual(expectedVacancyNumb, actualVacancyNumb);
        }

        [Test]
        public void CheckNegativeVacancyNumberTest_PassIfThrowsAnArgumentException()
        {
            // Arrange
            var wrongVacancyTestArgs = new string[] { "DepartmentTestArg", "LanguageTestAr", "-10" };

            // Assert
            Assert.Throws<ArgumentException>( () => 
            {
                _findVacancyModelUnderTests = new FindVacancyModel(wrongVacancyTestArgs);
            });
        }

        [Test]
        public void CheckWrongNumberOfArgumentsTest_PassIfThrowsAnArgumentException()
        {
            // Arrange
            var wrongNumberOfTestArgs = new string[] { "DepartmentTestArg", "LanguageTestAr" };

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                _findVacancyModelUnderTests = new FindVacancyModel(wrongNumberOfTestArgs);
            });
        }

    }
}
