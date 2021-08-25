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
                    (_firstDto.ProcessLifeTimeInMsec == _secondDto.ProcessLifeTimeInMsec)
                    &&
                    (_firstDto.CheckFrequencyInMsec == _secondDto.CheckFrequencyInMsec);
                
                return isTwoDtoEqual;
            }

        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
