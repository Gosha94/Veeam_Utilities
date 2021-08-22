using System;
using System.Drawing;
using OpenQA.Selenium;
using System.Collections.Generic;
using SeleniumExtras.PageObjects;
using VacancyFinder.Service;
using TestProject.SDK.PageObjects;
using System.Collections.ObjectModel;
using System.Linq;

namespace VacancyFinder.PageObjects
{
    /// <summary>
    /// Модель тестируемой веб-страницы Вакансии
    /// </summary>
    public class VacancyPage
    {

        #region Private Fields

        private IWebDriver      _driver;

        /// <summary>
        /// URL путь к странице
        /// </summary>
        private string _vacancyPageUrl = "https://careers.veeam.ru/vacancies";

        #endregion

        #region Web Elements Under Test
        
        /// <summary>
        /// Кнопка для выбора отделов
        /// </summary>
        [FindsBy(How = How.XPath, Using = @"//*[@id=""root""]/div/div[1]/div/div[2]/div[1]/div/div[2]/div/div/button")]        
        private IWebElement _departmentsButton;

        /// <summary>
        /// Кнопка для выбора языков
        /// </summary>
        [FindsBy(How = How.XPath, Using = @"//*[@id=""root""]/div/div[1]/div/div[2]/div[1]/div/div[3]/div/div/button")]        
        private IWebElement _languageButton;

        /// <summary>
        /// Выпадающий список с выбором отделов
        /// </summary>        
        private List<IWebElement> _departmentsDropdownMenu;

        private const string _departmentDropDownXPath = @"//*[@id=""root""]/div/div[1]/div/div[2]/div[1]/div/div[2]/div/div/div/a";

        /// <summary>
        /// Выпадающий список с выбором языка
        /// </summary>        
        private List<IWebElement> _languageDropdownMenu;

        private const string _languageDropDownXPath = @"//*[@id=""root""]/div/div[1]/div/div[2]/div[1]/div/div[3]/div/div/div/div";

        /// <summary>
        /// Список вакансий на сайте
        /// </summary>        
        private List<IWebElement> _vacanciesList;

        private const string _vacanciesListXPath = @"//*[@id=""root""]/div/div[1]/div/div[2]/div[2]/div/a";

        #endregion

        #region Constructor

        public VacancyPage(IWebDriver driver)
        {
            _driver = driver;
            GoToUrl();
            // Устанавливаем время опроса DOM элемента, если недоступен
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            
            // Инициализируем поля объекта значениями
            PageFactory.InitElements(_driver, this);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Свойство определяет размер веб-страницы в пикселях
        /// </summary>
        public Size PageSize { get; private set; }

        /// <summary>
        /// Кол-во вакансий на странице
        /// </summary>
        public int NumberOfVacanсiesOnPage { get; private set; }

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
        public IWebElement SelectDepartamentOnSite(string departmentName)
        {
            ClickOnSingleElement(_departmentsButton);

            _departmentsDropdownMenu = _driver.FindElements(By.XPath(_departmentDropDownXPath)).ToList();
            
            var departmentButtonElement = GetElementFromDropDownMenu(_departmentsDropdownMenu, departmentName);

            ClickOnSingleElement(departmentButtonElement);

            return departmentButtonElement;
        }

        /// <summary>
        /// Метод выбора языка на сайте
        /// </summary>
        public IWebElement SelectLanguageOnSite(string languageValue)
        {
            ClickOnSingleElement(_languageButton);
            
            _languageDropdownMenu = _driver.FindElements(By.XPath(_languageDropDownXPath)).ToList();

            var languageButtonElement = GetElementFromDropDownMenu(_languageDropdownMenu, languageValue);
            
            ClickOnSingleElement(languageButtonElement);

            ClickOnSingleElement(_languageButton);
            
            return languageButtonElement;
        }

        /// <summary>
        /// Метод подсчета вакансий на странице
        /// </summary>
        public int CountVacanciesOnPage()
        {
            _vacanciesList = _driver.FindElements(By.XPath(_vacanciesListXPath)).ToList();
            NumberOfVacanсiesOnPage = _vacanciesList.Count;
            
            return _vacanciesList.Count;
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
        private IWebElement GetElementFromDropDownMenu(IEnumerable<IWebElement> webMenu, string searchElementName)
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
