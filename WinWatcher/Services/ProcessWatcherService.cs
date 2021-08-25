using System;
using WinWatcher.Enums;
using System.Threading;
using WinWatcher.Models;
using System.Diagnostics;
using WinWatcher.Interfaces;
using System.Collections.Generic;

namespace WinWatcher.Services
{
    /// <summary>
    /// Служба наблюдения за процессами в ОС Windows
    /// </summary>
    public sealed class ProcessWatcherService : IDisposable
    {

        #region Private Fields
        
        private ILogger              _logger;
        private IProcessInfo         _processInfo;
        
        private IntervalDto          _checkIntervalModel;
        private Timer                _timer;

        #endregion

        #region Constructor

        public ProcessWatcherService(IProcessInfo processInfo)
        {            
            _processInfo = processInfo;

            CheckIntervalModel checker = new CheckIntervalModel(processInfo.ProcessLifeTime, processInfo.CheckFrequency);
            _checkIntervalModel = checker.GetCalculatedIntervalData();
            _logger = new ConsoleLogger();            
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Свойство, определяющее Dispose-статус объекта-таймера
        /// </summary>
        public TimerState ActualTimerState { get; private set; } = TimerState.Stopped;

        #endregion

        #region Public Methods

        public void StartWatchProcess()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            _logger.WriteToLog($"Служба мониторинга: Имя процесса: {_processInfo.ProcessName}");
            _logger.WriteToLog($"Служба мониторинга: Частота проверки мсек: {_checkIntervalModel.CheckFrequencyInMsec}");
            _logger.WriteToLog($"Служба мониторинга: Время жизни процесса мсек: {_checkIntervalModel.ProcessLifeTimeInMsec}");
            _logger.WriteToLog("---------------------------------------------");
            _logger.WriteToLog("Начинаем мониторинг...");
            
            var doubleInterval = Convert.ToDouble(_checkIntervalModel.CheckFrequencyInMsec);

            _timer = new Timer(CheckProcess, null, TimeSpan.Zero,
                TimeSpan.FromMilliseconds(doubleInterval));
            
            this.ActualTimerState = TimerState.Working;
        }

        public void StopWatchProcess()
        {
            _logger.WriteToLog("Служба мониторинга остановлена!");
            _timer?.Change(Timeout.Infinite, 0);

            this.ActualTimerState = TimerState.Stopped;
        }

        public void Dispose()
        {
            _timer?.Dispose();
            
            this.ActualTimerState = TimerState.Disposed;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Метод проверяет процесс на время работы
        /// </summary>
        /// <param name="state"></param>
        private void CheckProcess(object state)
        {            
            var listOfKills = FindProcessToKill();
            listOfKills.ForEach(x => KillProcess(x));
            listOfKills.Clear();
        }

        private List<Process> FindProcessToKill()
        {
            var sameProcessesArr = Process.GetProcessesByName(_processInfo.ProcessName);

            var resultListOfProcess = new List<Process>();

            foreach (var process in sameProcessesArr)
            {
                var periodOpenedFile = (DateTime.Now - process.StartTime).TotalMilliseconds;                

                if (periodOpenedFile > _checkIntervalModel.ProcessLifeTimeInMsec )
                {
                    resultListOfProcess.Add(process);
                }                
            }

            return resultListOfProcess;
        }

        /// <summary>
        /// Метод уничтожает процесс
        /// </summary>
        /// <param name="process"></param>
        private void KillProcess(Process process)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            _logger.WriteToLog($"Процесс {process.ProcessName}: {process.Id} завершается!");
            process.Kill();
        }

        #endregion

    }
}