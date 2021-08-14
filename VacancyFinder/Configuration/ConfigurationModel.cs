namespace VacancyFinder.Configuration
{
    /// <summary>
    /// Класс, содержащий константы для веб-элементов и основные пути к папкам
    /// </summary>
    static class ConfigurationModel
    {

        /// <summary>
        /// URL путь к странице
        /// </summary>
        static readonly string VeeamUrl = "https://careers.veeam.ru/vacancies";

        /// <summary>
        /// Папка для веб драйвера Selenium внутри проекта .NET
        /// </summary>
        static readonly string PathToWebDriverFolder = "WebDriver";

        /// <summary>
        /// 
        /// </summary>
        static readonly string DepartmentButtonFullXPath = "/html/body/div[1]/div/div[1]/div/div[2]/div[1]/div/div[2]/div/div/button";
        
        /// <summary>
        /// 
        /// </summary>
        static readonly string DepartmentDropDownXPath   = @"//*[@id=""root""]/div/div[1]/div/div[2]/div[1]/div/div[2]/div/div/div/a";
        
        /// <summary>
        /// 
        /// </summary>
        static readonly string LanguageButtonFullXPath   = "/html/body/div[1]/div/div[1]/div/div[2]/div[1]/div/div[3]/div/div/button";
        
        /// <summary>
        /// 
        /// </summary>
        static readonly string LanguageDropDownXPath     = @"//*[@id=""root""]/div/div[1]/div/div[2]/div[1]/div/div[3]/div/div/div/div";
        
        /// <summary>
        /// 
        /// </summary>
        static readonly string VacancyListXPath          = @"//*[@id=""root""]/div/div[1]/div/div[2]/div[2]/div/a";
        
    }
}
