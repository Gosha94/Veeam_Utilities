using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Opera;
using VacancyFinder.Models;
using VacancyFinder.Service;
using VacancyFinder.PageObjects;
using VacancyFinder.WebDriver.Configuration;

namespace VacancyFinder.Controllers
{
    /// <summary>
    /// Контроллер для работы с вакансиями, главная точка входа
    /// </summary>
    public sealed class VacancyController
    {

        #region Private Fields

        private FindVacancyModel     _vacancyModel;
        private DisplayService       _displayServ;
        private VacancyPage          _vacancyPage;

        #endregion

        #region Constructor

        /// <summary>
        /// Конструктор контроллера с аргументами
        /// </summary>
        /// <param name="cmdArgs"></param>
        public VacancyController(string[] cmdArgs)
        {
            
            _displayServ                     = new DisplayService();
            _vacancyModel                    = new FindVacancyModel(cmdArgs);
            this.ConfiguredWebDriverInstance = ConfigureWebDriver();
            _vacancyPage                     = new VacancyPage(this.ConfiguredWebDriverInstance);
        }

        #endregion

        #region Public API

        /// <summary>
        /// Настроенный веб-драйвер
        /// </summary>
        public IWebDriver ConfiguredWebDriverInstance { get; private set; }

        /// <summary>
        /// Публичный API контроллера для выполнения поиска вакансий
        /// </summary>
        public void FindVacancies()
        {
            _vacancyPage.SignInSite();
            _vacancyPage.SelectDepartamentOnSite();
            _vacancyPage.SelectLanguageOnSite();
            CountOfVacanciesOnSite();
            _vacancyPage.ClosePage();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Конфигурация веб-драйвера
        /// </summary>
        private IWebDriver ConfigureWebDriver()
        {
            var sizeWindow = _displayServ.GetDisplayResolution();
            var options = new OperaOptions();

            options.BinaryLocation = OperaDriverConfigModel.PathToBrowserBinFolder;
            options.AddArgument($"--window-size={sizeWindow.Width},{sizeWindow.Height}");

            return new OperaDriver(OperaDriverConfigModel.PathToWebDriverFolder, options);
        }

        /// <summary>
        /// Метод подсчета вакансий на сайте
        /// </summary>
        public void CountOfVacanciesOnSite()
        {

            var vacNumber = _vacanciesList.Count;

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
