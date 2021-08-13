using System;
using WinWatcher.Models;
using WinWatcher.Services;

namespace WinWatcher
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            try
            {
                var processInfo = new InputArgumentsModel(args);
                var watcher = new ProcessWatcherService(processInfo);
                watcher.StartWatchProcess();
            }

            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
