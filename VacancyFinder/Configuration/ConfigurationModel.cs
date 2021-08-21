namespace VacancyFinder.Configuration
{
    /// <summary>
    /// Класс, содержащий константы для веб-элементов и основные пути к папкам
    /// </summary>
    public static class ConfigurationModel
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
