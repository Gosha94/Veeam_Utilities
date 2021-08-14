using System;
using System.Linq;

namespace VacancyFinder.Models
{
    /// <summary>
    /// Класс для подготовки данных из агрументов CMD в модель поиска
    /// </summary>
    public sealed class FindVacancyModel
    {

        #region Private Model Fields

        private string   _departmentName;
        private string   _languageName;
        private int      _vacancyNumber;
        private string[] _cmdArguments;

        #endregion

        #region Public Model Properties

        /// <summary>
        /// Св-во отображает имя отдела, которое необходимо выбрать в браузере из списка
        /// </summary>
        public string DepartmentName
        {
            get => _departmentName;
            private set 
            {
                ClearInputString(ref value);
                _departmentName = value;
            }
        }

        /// <summary>
        /// Св-во отображает язык, выбираемый в CheckBox
        /// </summary>
        public string LanguageName
        {
            get => _languageName;
            private set
            {
                ClearInputString(ref value);
                _languageName = value;
            }
        }

        /// <summary>
        /// Ожидаемое кол-во вакансий в поиске
        /// </summary>
        public int VacancyNumber
        {
            get => _vacancyNumber;
            private set
            {
                if ( value < 0 )
                {
                    PushArgumentException("Кол-во вакансий не должно быть отрицательным!");
                }
                else
                {
                    _vacancyNumber = value;
                }
            }
        }

        #endregion

        #region Default Constructor

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="cmdArguments"></param>
        public FindVacancyModel(string[] cmdArguments)
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
            int vacancyNum;

            this.DepartmentName = _cmdArguments.First();

            this.LanguageName = _cmdArguments[1];

            CheckAbleConvertToInt(_cmdArguments[2], out vacancyNum);
            this.VacancyNumber = vacancyNum;
        }

        /// <summary>
        /// Метод убирает лишние пробелы из строки, и переводит строку в нижний регистр
        /// </summary>
        /// <param name="dirtString"></param>
        /// <returns></returns>
        private string ClearInputString(ref string dirtString)
            => dirtString.ToLower().Trim();

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
                Console.ForegroundColor = ConsoleColor.Red;

                PushArgumentException("Количество аргументов не соответствует заданию!" +
                    "Необходимо разделять аргументы кавычками \"\": Название отдела(string), Язык(string), Ожидаемое кол-во вакансий(int)");
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
