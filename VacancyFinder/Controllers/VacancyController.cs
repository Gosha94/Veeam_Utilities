using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Opera;
using VacancyFinder.Models;
using VacancyFinder.Service;
using VacancyFinder.Configuration;

namespace VacancyFinder.Controllers
{
    /// <summary>
    /// Контроллер для работы с вакансиями, главная точка входа
    /// </summary>
    public sealed class VacancyController
    {

        #region Private Fields

        private FindVacancyModel _vacancyModel;
        private ClickerService _clicker;
        private BrowserSearchService _searchEngine;

        private string _pathToWebDriverFolder       = ConfigurationModel.PathToWebDriverFolder;
        private string _veeamUrl                    = ConfigurationModel.VeeamUrl;
        private string _departmentButtonFullXPath   = ConfigurationModel.DepartmentButtonFullXPath;
        private string _departmentDropDownXPath     = ConfigurationModel.DepartmentDropDownXPath;
        private string _languageButtonFullXPath     = ConfigurationModel.LanguageButtonFullXPath;
        private string _languageDropDownXPath       = ConfigurationModel.LanguageDropDownXPath;
        private string _vacancyListXPath            = ConfigurationModel.VacancyListXPath;

        #endregion

        #region Constructor

        /// <summary>
        /// Конструктор контроллера
        /// </summary>
        /// <param name="cmdArgs"></param>
        public VacancyController(string[] cmdArgs)
        {
            _vacancyModel = new FindVacancyModel(cmdArgs);
            _clicker = new ClickerService();
            _searchEngine = new BrowserSearchService();
        }

        #endregion

        #region Public API

        /// <summary>
        /// Публичный API контроллера для выполнения работы
        /// </summary>
        public void FindVacancies()
        {
            using (IWebDriver driver = new OperaDriver(_pathToWebDriverFolder))
            {
                SignInSite(driver);

                SelectDepartamentOnSite(driver);

                SelectLanguageOnSite(driver);

                CountOfVacanciesOnSite(driver);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Метод входа на сайт 
        /// </summary>
        /// <param name="driver"></param>
        private void SignInSite(IWebDriver driver)
        {
            _searchEngine.GoToUrl(driver, _veeamUrl);
            _searchEngine.ExpandBrowser(driver);
            _searchEngine.WaitForPageLoad(2);
        }

        /// <summary>
        /// Метод выбора отдела на сайте
        /// </summary>
        /// <param name="driver"></param>
        private void SelectDepartamentOnSite(IWebDriver driver)
        {
            var deptButtonElem = driver.FindElement(By.XPath(_departmentButtonFullXPath));
            _clicker.ClickOnSingleElement(deptButtonElem);

            _searchEngine.WaitForPageLoad(2);

            var deptDropDown = driver.FindElements(By.XPath(_departmentDropDownXPath));
            _clicker.ClickOnElementInDropDownList(deptDropDown, _vacancyModel.DepartmentName);

            _searchEngine.WaitForPageLoad(2);
        }

        /// <summary>
        /// Метод выбора языка на сайте
        /// </summary>
        private void SelectLanguageOnSite(IWebDriver driver)
        {
            var languageButtonElem = driver.FindElement(By.XPath(_languageButtonFullXPath));
            _clicker.ClickOnSingleElement(languageButtonElem);

            _searchEngine.WaitForPageLoad(2);

            var languageDropDown = driver.FindElements(By.XPath(_languageDropDownXPath));
            _clicker.ClickOnElementInDropDownList(languageDropDown, _vacancyModel.LanguageName);

            _searchEngine.WaitForPageLoad(2);

            _clicker.ClickOnSingleElement(languageButtonElem);
        }

        /// <summary>
        /// Метод подсчета вакансий на сайте
        /// </summary>
        private void CountOfVacanciesOnSite(IWebDriver driver)
        {
            _searchEngine.WaitForPageLoad(2);

            var vacanciesList = driver.FindElements(By.XPath(_vacancyListXPath));

            var vacNumber = vacanciesList.Count;

            Console.Clear();

            if (vacNumber == _vacancyModel.VacancyNumber)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Кол-во вакансий соответствует ожидаемому: {_vacancyModel.VacancyNumber}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка! Кол-во вакансий отличается от ожидаемого!");
            }
        }

        #endregion

    }
}
