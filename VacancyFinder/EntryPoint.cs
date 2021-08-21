using System;
using VacancyFinder.Controllers;

namespace VacancyFinder
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            try
            {
                var vacController = new VacancyController(args);
                vacController.FindVacancies();
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Возникло исключение: " + ex.Message);
            }

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Для продолжения нажмите любую кнопку...");
            Console.ReadKey();

        }
    }
}
