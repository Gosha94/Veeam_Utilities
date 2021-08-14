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
                Console.WriteLine(ex.Message);
            }

        }
    }
}
