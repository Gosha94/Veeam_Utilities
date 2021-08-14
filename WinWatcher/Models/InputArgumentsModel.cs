using System;
using System.Linq;
using WinWatcher.Interfaces;

namespace WinWatcher.Models
{
    /// <summary>
    /// Класс-модель для хранения входных аргументов
    /// </summary>
    public sealed class InputArgumentsModel : IProcessInfo
    {

        #region Private Model Fields

        private string   _processName;
        private int      _processLifeTime;
        private int      _checkFrequency;
        private string[] _cmdArguments;

        #endregion

        #region Public Model Properties

        /// <summary>
        /// Свойство определяет имя процесса Windows
        /// </summary>
        public string ProcessName
        {
            get => _processName;

            private set
            {
                ClearInputString(ref value);
                var finalString = CheckExtensionOnProcess(ref value);
                _processName = finalString;
            }
        }

        /// <summary>
        /// Свойство определяет время жизни процесса в минутах
        /// </summary>
        public int ProcessLifeTime
        {
            get => _processLifeTime;
            private set
            {
                if (value <= 0 || value > 1440)
                {
                    PushArgumentException("Время жизни процесса в минутах не должно быть 0 и больше суток(1440 минут)!");
                }
                else
                {
                    _processLifeTime = value;
                }                
            }
        }

        /// <summary>
        /// Свойство определяет частоту проверки процесса в минутах
        /// </summary>
        public int CheckFrequency
        {
            get => _checkFrequency;
            private set
            {
                if (value <= 0 || value > 1440)
                {
                    PushArgumentException("Частота проверки процесса в минутах не должна быть 0 и больше суток(1440 минут)!");
                }
                _checkFrequency = value;
            }           
        }

        #endregion

        #region Default Constructor

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="cmdArguments"></param>
        public InputArgumentsModel(string[] cmdArguments)
        {
            _cmdArguments = cmdArguments;
            CheckArgumentsNumber(_cmdArguments);
            
            SetPublicProperties();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Метод установки публичных свойств
        /// </summary>
        private void SetPublicProperties()
        {
            int lifeTime, frequency;

            this.ProcessName = _cmdArguments.First();

            CheckAbleConvertToInt(_cmdArguments[1], out lifeTime);
            this.ProcessLifeTime = lifeTime;

            CheckAbleConvertToInt(_cmdArguments[2], out frequency);
            this.CheckFrequency = frequency;
        }

        /// <summary>
        /// Метод убирает лишние пробелы из строки, и переводит строку в нижний регистр
        /// </summary>
        /// <param name="dirtString"></param>
        /// <returns></returns>
        private string ClearInputString(ref string dirtString)
            => dirtString.ToLower().Trim();

        /// <summary>
        /// Метод проверяет расширение .exe у вводимого процесса
        /// </summary>
        /// <param name="inputString"></param>

        private string CheckExtensionOnProcess(ref string inputString)
        {
            var splittedArray = inputString.Split('.');
            var numbOfElemInArray = splittedArray.Length;
            
            if (numbOfElemInArray < 2)
            {
                PushArgumentException("Проверьте вводимое имя процесса на наличие расширения exe! Пример: notepad.exe");
            }
            else if( !splittedArray[1].Contains("exe") )
            {
                PushArgumentException("У процесса обязательно должно быть расширение exe! Пример: notepad.exe");
            }

            return splittedArray.First();
        }

        /// <summary>
        /// Метод проверяет возможность преобразовать строку в Int32 и возвращает результат, если возможность есть
        /// </summary>
        /// <param name="stringToConvert"></param>
        /// <param name="resultInt"></param>
        /// <returns></returns>
        private bool CheckAbleConvertToInt(string stringToConvert, out int resultInt)
            => Int32.TryParse(stringToConvert, out resultInt);

        /// <summary>
        /// Метод проверяет кол-во аргументов, передаваемых в модель
        /// </summary>
        /// <param name="inputArr"></param>
        private void CheckArgumentsNumber(string[] inputArr)
        {
            if (inputArr.Length != 3)
            {                
                PushArgumentException("Количество аргументов не соответствует заданию!" +
                    "Необходиом указать: Имя процеса(string), Время жизни(int), Частоту проверки(int)");
            }
        }

        /// <summary>
        /// Метод вызывает исключение по аргументу
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private void PushArgumentException(string message)
            => throw new ArgumentException(message);

        #endregion

    }
}
