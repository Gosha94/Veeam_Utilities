namespace VacancyFinder.WebDriver.Configuration
{
    /// <summary>
    /// Модель конфигурации веб-драйвера
    /// </summary>
    public static class OperaDriverConfigModel
    {

        /// <summary>
        /// Папка для веб драйвера Selenium внутри проекта .NET
        /// </summary>
        public static readonly string PathToWebDriverFolder = "WebDriver";

        /// <summary>
        /// Путь к установленной версии Opera, совместимой с Opera WebDriver
        /// </summary>
        public static readonly string PathToBrowserBinFolder = @"D:\Program Files\Opera\78.0.4093.147\opera.exe";

    }
}
