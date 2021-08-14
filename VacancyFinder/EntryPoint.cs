using System;
using System.Collections.ObjectModel;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Opera;
using VacancyFinder.Controllers;

namespace VacancyFinder
{
    class EntryPoint
    {
        // Аргументы приложения
        private static readonly string _dropDownDepartmentName = "Разработка продуктов";
        private static readonly string _dropDownLanguageName   = "Английский";        
        private static readonly int    _expectedVacancyNumber  = 6;

        static void Main(string[] args)
        {
            var findVacancyModel = new 
            var vacController = new VacancyController(inputModel);
            vacController


            using(IWebDriver driver = new OperaDriver(_pathToWebDriverFolder) )
            {
                //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                

                GoToUrl(driver, _veeamUrl);                
                ExpandBrowser(driver);
                WaitForPageLoad(2);

                #region Выбор департамента на сайте

                var deptButtonElem = driver.FindElement(By.XPath(departmentButtonFullXPath));
                ClickOnSingleElement(deptButtonElem);

                WaitForPageLoad(2);

                var deptDropDown = driver.FindElements(By.XPath(departmentDropDownXPath));
                ClickOnElementInDropDownList(deptDropDown, _dropDownDepartmentName);

                WaitForPageLoad(2);

                #endregion                

                #region Выбор языка на сайте

                var languageButtonElem = driver.FindElement(By.XPath(languageButtonFullXPath));
                ClickOnSingleElement(languageButtonElem);

                WaitForPageLoad(2);

                var languageDropDown = driver.FindElements(By.XPath(languageDropDownXPath));
                ClickOnElementInDropDownList(languageDropDown, _dropDownLanguageName);

                WaitForPageLoad(2);

                ClickOnSingleElement(languageButtonElem);

                #endregion

                #region Подсчет кол-ва вакансий на сайте
                
                WaitForPageLoad(2);

                var vacanciesList = driver.FindElements(By.XPath(vacancyListXPath));

                var vacNumber = vacanciesList.Count;

                Console.Clear();

                if (vacNumber == _expectedVacancyNumber)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Кол-во вакансий соответствует ожидаемому: {_expectedVacancyNumber}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка! Кол-во вакансий отличается от ожидаемого!");
                }

                #endregion
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Метод перехода по веб-ссылке
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="url"></param>
        private static void GoToUrl(IWebDriver driver, string url) => driver.Navigate().GoToUrl(url);

        /// <summary>
        /// Метод разворачивает браузер на весь экран
        /// </summary>
        /// <param name="driver"></param>
        private static void ExpandBrowser(IWebDriver driver) => driver.Manage().Window.Maximize();

        /// <summary>
        /// Вспомогательный метод для информативного ожидания между действиями в браузере
        /// </summary>
        /// <param name="seconds">Секунды ожидания</param>
        private static void WaitForPageLoad(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }

        /// <summary>
        /// Метод нажатия на отдельный элемент веб-интерфейса
        /// </summary>
        /// <param name="element"></param>
        private static void ClickOnSingleElement(IWebElement element) => element.Click();

        /// <summary>
        /// Метод нажатия на элемент выпадающего списка
        /// </summary>
        /// <param name="dropDownList">Выпадающий список</param>
        /// <param name="expectedString">Наименование элемента, который необходимо выбрать</param>
        private static void ClickOnElementInDropDownList(ReadOnlyCollection<IWebElement> dropDownList, string expectedString)
        {
            var comparer = StringComparer.OrdinalIgnoreCase;

            foreach (var item in dropDownList)
            {
                if (comparer.Compare(item.Text, expectedString) == 0)  // 0 - Both strings are equal in value
                {
                    item.Click();
                    return;
                }
            }
        }

        /// <summary>
        /// Метод подсчета вакансий на веб-сайте Veeam
        /// </summary>
        private static int CountOfVacanciesOnSite()
        {
            return -1;
        }

    }
}
