using OpenQA.Selenium;
using OpenQA.Selenium.Opera;
using VacancyFinder.Models;
using VacancyFinder.Service;
using VacancyFinder.Configuration;
using VacancyFinder.PageObjects;

namespace VacancyFinder.Controllers
{
    /// <summary>
    /// Контроллер для работы с вакансиями, главная точка входа
    /// </summary>
    public sealed class VacancyController
    {

        #region Private Fields

        private IWebDriver _driver;

        private ClickerService       _clickerServ;
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
            _clickerServ      = new ClickerService();
            _displayServ      = new DisplayService();
            _vacancyModel     = new FindVacancyModel(cmdArgs);
            _driver = ConfigureWebDriver();

            _vacancyPage = new VacancyPage();

        }

        #endregion

        #region Public API

        /// <summary>
        /// Публичный API контроллера для выполнения поиска вакансий
        /// </summary>
        public void FindVacancies()
        {
            _vacancyPage.SignInSite();
            _vacancyPage.SelectDepartamentOnSite();
            _vacancyPage.SelectLanguageOnSite();
            _vacancyPage.CountOfVacanciesOnSite();
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

            options.BinaryLocation = ConfigurationModel.PathToBrowserBinFolder;
            options.AddArgument($"--window-size={sizeWindow.Width},{sizeWindow.Height}");

            return new OperaDriver(ConfigurationModel.PathToWebDriverFolder, options);
        }

        #endregion

    }
}
