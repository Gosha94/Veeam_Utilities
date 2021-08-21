using OpenQA.Selenium.Opera;
using System;
using VacancyFinder.Configuration;
using VacancyFinder.Controllers;
using VacancyFinder.Service;

namespace VacancyFinder
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            var disp = new DisplayService();
            var options = new OperaOptions();
            options.BinaryLocation = ConfigurationModel.PathToBrowserBinFolder;
            var sizeWindow = disp.GetDisplayResolution();
            options.AddArgument($"--window-size={sizeWindow.Width},{sizeWindow.Height}");
            var driver = new OperaDriver(ConfigurationModel.PathToWebDriverFolder, options);

            //driver.Manage().Window.Size = res;
            var rest = driver.Manage().Window.Size;

            //try
            //{
            //    var vacController = new VacancyController(args);
            //    vacController.FindVacancies();
            //}
            //catch (Exception ex)
            //{
            //    Console.Clear();
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine("Возникло исключение: " + ex.Message);
            //}

            //Console.ForegroundColor = ConsoleColor.DarkGray;
            //Console.WriteLine("Для продолжения нажмите любую кнопку...");
            Console.ReadKey();

        }
    }
}
