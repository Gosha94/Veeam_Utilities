using System;
using System.Collections.ObjectModel;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Support.UI;

namespace VacancyFinder
{
    class Program
    {
        private static readonly string _dropDownDepartmentName = "Разработка продуктов";
        private static readonly string _dropDownLanguageName   = "Английский";
        private static readonly string _pathToWebDriverFolder  = "WebDriver";
        private static readonly string _veeamUrl               = "https://careers.veeam.ru/vacancies";

        static void Main(string[] args)
        {
            using(IWebDriver driver = new OperaDriver(_pathToWebDriverFolder) )
            {
                //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                GoToUrl(driver, _veeamUrl);                
                ExpandBrowser(driver);

                WaitForUserComfortWatch(8);

                IWebElement deptButtonElem = driver.FindElement(By.XPath("html/body/div[1]/div/div[1]/div/div[2]/div[1]/div/div[2]/div/div/button"));
                deptButtonElem.Click();

                //IWebElement deptAhRef = driver.FindElement(By.XPath(@"//*[@id=""root""]/div/div[1]/div/div[2]/div[1]/div/div[2]/div/div/div/a[4]"));
                //deptAhRef.Click();

                IWebElement languageButtonElem = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div[1]/div/div[3]/div/div/button"));
                languageButtonElem.Click();
                
                var languageDropDown = driver.FindElements(By.XPath(@"//*[@id=""root""]/div/div[1]/div/div[2]/div[1]/div/div[3]/div/div/div/div"));                
                ClickOnElementInDropDownList(languageDropDown, _dropDownLanguageName);

                //CountOfVacancies();

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
        private static void WaitForUserComfortWatch(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }

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
        private static void CountOfVacancies()
        { }

    }
}
