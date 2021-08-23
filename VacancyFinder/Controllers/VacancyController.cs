using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Opera;
using VacancyFinder.Models;
using VacancyFinder.Service;
using VacancyFinder.PageObjects;
using VacancyFinder.WebDriver.Configuration;
using TestProject.SDK.PageObjects;

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
        /// Публичный API контроллера для подсчета вакансий
        /// </summary>
        public int CountConcreteVacancies()
        {
            _vacancyPage.SignInSite();
            _vacancyPage.SelectDepartamentOnSite(_vacancyModel.DepartmentName);
            _vacancyPage.SelectLanguageOnSite(_vacancyModel.LanguageName);

            return CountOfSiteVacancies();
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
        private int CountOfSiteVacancies()
        {
            _vacancyPage.CountVacanciesOnPage();

            var vacNumber = _vacancyPage.NumberOfVacanсiesOnPage;

            if (vacNumber == _vacancyModel.VacancyNumber)
            {
                //Console.WriteLine($"Кол-во вакансий соответствует ожидаемому: {_vacancyModel.VacancyNumber}");
                return _vacancyModel.VacancyNumber;
            }
            else
            {
                throw new ArithmeticException("Ошибка! Кол-во вакансий отличается от ожидаемого!");
            }
        }

        #endregion

    }
}
