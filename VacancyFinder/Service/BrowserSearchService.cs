using OpenQA.Selenium;
using System.Threading;
using VacancyFinder.Interfaces;

namespace VacancyFinder.Service
{
    /// <summary>
    /// Служба поиска элементов в веб-интерфейсе
    /// </summary>
    public sealed class BrowserSearchService : IService
    {
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

        /// <summary>
        /// Вспомогательный метод для информативного ожидания между действиями в браузере
        /// </summary>
        /// <param name="seconds">Секунды ожидания</param>
        public void WaitForPageLoad(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }
    }
}
