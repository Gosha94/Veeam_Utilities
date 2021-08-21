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

        private IWebDriver _driver;

        private ClickerService       _clicker;
        private FindVacancyModel     _vacancyModel;
        //private BrowserNavigationService _searchEngine;

        #endregion

        #region Constructor

        /// <summary>
        /// Конструктор контроллера
        /// </summary>
        /// <param name="cmdArgs"></param>
        public VacancyController(string[] cmdArgs)
        {
            _clicker      = new ClickerService();
            //_searchEngine = new BrowserNavigationService();
            _vacancyModel = new FindVacancyModel(cmdArgs);

            ConfigureWebDriver();
        }

        #endregion

        #region Public API

        /// <summary>
        /// Публичный API контроллера для выполнения работы
        /// </summary>
        public void FindVacancies()
        {
            //SignInSite(_driver);

            //SelectDepartamentOnSite(_driver);

            //SelectLanguageOnSite(_driver);

            //CountOfVacanciesOnSite(_driver);

            _driver.Quit();

        }

        #endregion

        /// <summary>
        /// Конфигурация веб-драйвера
        /// </summary>
        private void ConfigureWebDriver()
        {
            var options = new OperaOptions();
            options.BinaryLocation = ConfigurationModel.PathToBrowserBinFolder;
            _driver = new OperaDriver(ConfigurationModel.PathToWebDriverFolder, options);
        }

    }
}
