namespace WinWatcher.Models
{
    /// <summary>
    /// Модель подсчета интервалов времени для службы Мониторинга
    /// </summary>
    public sealed class CheckIntervalModel
    {

        #region Private Fields
        
        private int _lifeTimeInSeconds;
        private int _frequencyInSeconds;

        #endregion

        #region Constructor
        
        /// <summary>
        /// Конструктор модели проверки интервалов
        /// </summary>
        /// <param name="lifeTime"></param>
        /// <param name="frequency"></param>
        public CheckIntervalModel(int lifeTimeInSeconds, int frequencyInSeconds)
        {
            _lifeTimeInSeconds = lifeTimeInSeconds;
            _frequencyInSeconds = frequencyInSeconds;            
        }

        #endregion

        #region Public API

        public IntervalDto GetCalculatedIntervalData()
            =>
                new IntervalDto()
                {
                    ProcessLifeTimeInMsec = ConvertToMsec(_lifeTimeInSeconds),
                    CheckFrequencyInMsec    = ConvertToMsec(_frequencyInSeconds)
                };
        
        #endregion

        #region Private Methods

        /// <summary>
        /// Метод конвертации минут в милисекунды
        /// </summary>        
        private int ConvertToMsec(int inputVal)
        {
            var resultVal = 0;

            if (inputVal < 0)
            {
                resultVal = inputVal * (-1) * 60000;
            }
            else
            {
                resultVal = inputVal * 60000;
            }

            return resultVal;
        }

        #endregion

    }
}
