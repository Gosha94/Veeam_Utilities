namespace WinWatcher.Models
{
    /// <summary>
    /// Модель подсчета интервалов времени для службы Мониторинга
    /// </summary>
    public sealed class CheckIntervalModel
    {

        #region Private Fields
        
        private int _lifeTime;
        private int _frequency;
        private int _checksNumber;
        private int _restTimeInMin;

        #endregion

        #region Constructor
        
        /// <summary>
        /// Конструктор модели проверки интервалов
        /// </summary>
        /// <param name="lifeTime"></param>
        /// <param name="frequency"></param>
        public CheckIntervalModel(int lifeTime, int frequency)
        {
            _lifeTime = lifeTime;
            _frequency = frequency;            
        }

        #endregion

        #region Public API

        public IntervalDto GetCalculatedIntervalData()
            =>
                new IntervalDto()
                {
                    CheckFrequencyInMsec = ConvertToMsec(_frequency),
                    ProcessLifeTimeInMsec = ConvertToMsec(_lifeTime)
                };

        #endregion

        #region Private Methods

        /// <summary>
        /// Метод конвертации минут в милисекунды
        /// </summary>        
        private int ConvertToMsec(int inputVal)
            => inputVal * 60000;

        #endregion

    }
}
