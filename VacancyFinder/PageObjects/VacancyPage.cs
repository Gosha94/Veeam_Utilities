using System;
using System.Drawing;
using OpenQA.Selenium;
using System.Collections.Generic;
using OpenQA.Selenium.Support.PageObjects;
using VacancyFinder.Service;

namespace VacancyFinder.PageObjects
{
    /// <summary>
    /// Модель тестируемой веб-страницы Вакансии
    /// </summary>
    public class VacancyPage
    {

        #region Private Fields

        private IWebDriver      _driver;
        private ClickerService  _clickerServ;

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
            _clickerServ = new ClickerService();
            // Устанавливаем время опроса DOM элемента, если недоступен
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        

        #endregion

        #region Public Properties

        /// <summary>
        /// Свойство определяет размер веб-страницы в пикселях
        /// </summary>
        public Size PageSize { get; private set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Метод перехода по веб-ссылке
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="url"></param>
        public void GoToUrl() => _driver.Navigate().GoToUrl(_vacancyPageUrl);

        /// <summary>
        /// Метод разворачивает браузер на весь экран
        /// </summary>
        /// <param name="driver"></param>
        public void ExpandBrowser()
        {
            _driver.Manage().Window.Maximize();
            this.PageSize = _driver.Manage().Window.Size;
        }
        
        /// <summary>
        /// Метод входа на сайт
        /// </summary>
        /// <param name="driver"></param>
        public void SignInSite()
        {
            GoToUrl();
            ExpandBrowser();
        }

        /// <summary>
        /// Метод выбора отдела на сайте
        /// </summary>
        /// <param name="driver"></param>
        public bool SelectDepartamentOnSite(string departmentName)
        {
            var departmentButtonElement = GetElementFromDropDownMenu(_departmentsDropdownMenu);

            _clickerServ.ClickOnSingleElement(departmentButtonElement);

            _clickerServ.ClickOnElementInDropDownList(_departmentsDropdownMenu, departmentName);

            return true;
        }

        /// <summary>
        /// Метод выбора языка на сайте
        /// </summary>
        public bool SelectLanguageOnSite(string languageValue)
        {
            var languageButtonElement = GetElementFromDropDownMenu(_languageDropdownMenu);

            _clickerServ.ClickOnSingleElement(languageButtonElement);
            
            _clickerServ.ClickOnElementInDropDownList(_languageDropdownMenu, languageValue);
            _clickerServ.ClickOnSingleElement(languageButtonElement);
            
            return true;
        }

        /// <summary>
        /// Метод закрытия веб страницы
        /// </summary>
        public void ClosePage() => _driver.Quit();

        #endregion

        #region Private Methods

        /// <summary>
        /// Метод получения кнопки
        /// </summary>
        /// <returns></returns>
        private IWebElement GetElementFromDropDownMenu(List<IWebElement> webMenu, string searchElementName)
        {
            var comparer = StringComparer.OrdinalIgnoreCase;

            foreach (var item in webMenu)
            {
                if (comparer.Compare(item.Text, searchElementName) == 0)  // 0 - Both strings are equal in value
                {
                    var findedElementInDropDown = item;
                    return findedElementInDropDown;
                }
            }

            throw new WebDriverException($"Элемент с именем: {searchElementName} в списке не найден!");
        }

        /// <summary>
        /// Метод нажатия на отдельный элемент веб-интерфейса
        /// </summary>
        /// <param name="element"></param>
        private void ClickOnSingleElement(IWebElement element) => element.Click();

        /// <summary>
        /// Вспомогательный метод для информативного ожидания между действиями в браузере
        /// </summary>
        /// <param name="driver">экземпляр конкретного веб-драйвера</param>
        /// <param name="seconds">время ожидания драйвера в секундах</param>
        private void WaitForPageLoad(int seconds) => _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);

        #endregion

    }
}
