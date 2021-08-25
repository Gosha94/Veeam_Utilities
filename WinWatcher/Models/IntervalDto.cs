using System;

namespace WinWatcher.Models
{
    /// <summary>
    /// Класс без методов для передачи данных между службами
    /// </summary>
    public sealed class IntervalDto
    {
        public int ProcessLifeTimeInMsec { get; set; }
        public int CheckFrequencyInMsec  { get; set; }

        public bool IsNull => throw new NotImplementedException();

        public override bool Equals(object secondDtoObj)
        {
            var _firstDto = this;
            IntervalDto _secondDto = secondDtoObj as IntervalDto;

            if (_secondDto == default(IntervalDto))
            {
                return false;
            }
            else
            {
                var isTwoDtoEqual =
                    (_firstDto.ProcessLifeTimeInMsec == _secondDto.CheckFrequencyInMsec)
                    &&
                    (_firstDto.CheckFrequencyInMsec == _secondDto.CheckFrequencyInMsec);
                
                return isTwoDtoEqual;
            }

        }
    }
}
