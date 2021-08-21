﻿using System;
using System.Windows;
using OpenQA.Selenium;
using System.Collections.Generic;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace VacancyFinder.PageObjects
{
    /// <summary>
    /// Модель тестируемой веб-страницы Вакансии
    /// </summary>
    public class VacancyPage
    {
        
        #region Private Fields

        private IWebDriver _driver;

        /// <summary>
        /// URL путь к странице
        /// </summary>
        private string _vacancyPageUrl = "https://careers.veeam.ru/vacancies";

        #endregion

        #region Web Elements Under Test

        /// <summary>
        /// Выпадающий список с выбором отделов
        /// </summary>
        [FindsBy(How = How.XPath, Using = @"//*[@id=""root""]/div/div[1]/div/div[2]/div[1]/div/div[2]/div/div/div/a")]
        private List<IWebElement> _departmentsDropdownMenu;

        /// <summary>
        /// Выпадающий список с выбором языка
        /// </summary>
        [FindsBy(How = How.XPath, Using = @"//*[@id=""root""]/div/div[1]/div/div[2]/div[1]/div/div[3]/div/div/div/div")]
        private List<IWebElement> _languageDropdownMenu;

        /// <summary>
        /// Список вакансий на сайте
        /// </summary>
        [FindsBy(How = How.XPath, Using = @"//*[@id=""root""]/div/div[1]/div/div[2]/div[2]/div/a")]
        private List<IWebElement> _vacanciesList;

        #endregion

        #region Constructor

        public VacancyPage(IWebDriver driver)
        {
            _driver = driver;
            
            // Устанавливаем время опроса DOM элемента, если недоступен
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Метод перехода по веб-ссылке
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="url"></param>
        public void GoToUrl(IWebDriver driver, string url) => driver.Navigate().GoToUrl(url);

        /// <summary>
        /// Метод разворачивает браузер на весь экран
        /// </summary>
        /// <param name="driver"></param>
        public void ExpandBrowser(IWebDriver driver) => driver.Manage().Window.Maximize();

        private void CheckIfWindowIsMaximized(IWebDriver driver)
        {
            IWindow window = driver.Manage().Window;
            var size = window.Size;
            var currentScreenWidth  = SystemParameters.PrimaryScreenWidth;
            var currentScreenHeight = SystemParameters.PrimaryScreenHeight;
        }

        /// <summary>
        /// Метод входа на сайт
        /// </summary>
        /// <param name="driver"></param>
        public void SignInSite()
        {
            //_searchEngine.GoToUrl(driver, _veeamUrl);
            //_searchEngine.ExpandBrowser(driver);
            //_searchEngine.WaitForPageLoad(driver, 2);
        }

        /// <summary>
        /// Метод выбора отдела на сайте
        /// </summary>
        /// <param name="driver"></param>
        public void SelectDepartamentOnSite()
        {
            //var deptButtonElem = driver.FindElement(By.XPath(_departmentButtonFullXPath));
            //_clicker.ClickOnSingleElement(deptButtonElem);

            //_searchEngine.WaitForPageLoad(driver, 1);

            //var deptDropDown = driver.FindElements(By.XPath(_departmentDropDownXPath));
            //_clicker.ClickOnElementInDropDownList(deptDropDown, _vacancyModel.DepartmentName);

            //_searchEngine.WaitForPageLoad(driver, 1);
        }

        /// <summary>
        /// Метод выбора языка на сайте
        /// </summary>
        public void SelectLanguageOnSite()
        {
            //var languageButtonElem = driver.FindElement(By.XPath(_languageButtonFullXPath));
            //_clicker.ClickOnSingleElement(languageButtonElem);

            //_searchEngine.WaitForPageLoad(driver, 1);

            //var languageDropDown = driver.FindElements(By.XPath(_languageDropDownXPath));
            //_clicker.ClickOnElementInDropDownList(languageDropDown, _vacancyModel.LanguageName);

            //_searchEngine.WaitForPageLoad(driver, 1);

            //_clicker.ClickOnSingleElement(languageButtonElem);
        }

        /// <summary>
        /// Метод подсчета вакансий на сайте
        /// </summary>
        public void CountOfVacanciesOnSite()
        {
            //WaitForPageLoad(1);

            var vacanciesList = _driver.FindElements(By.XPath(_vacancyListXPath));

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

        /// <summary>
        /// Метод закрытия веб страницы
        /// </summary>
        public void ClosePage() => _driver.Quit();

        #endregion

        #region Private Methods

        /// <summary>
        /// Вспомогательный метод для информативного ожидания между действиями в браузере
        /// </summary>
        /// <param name="driver">экземпляр конкретного веб-драйвера</param>
        /// <param name="seconds">время ожидания драйвера в секундах</param>
        private void WaitForPageLoad(int seconds) => _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);

        #endregion

    }
}
