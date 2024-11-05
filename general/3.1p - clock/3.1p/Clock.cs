using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _3._1p
{
    public class Clock
    {
        Counter _hours = new Counter("Hours");
        Counter _minutes = new Counter("Minutes");
        Counter _seconds = new Counter("Seconds");
        string _ampm = "AM";
        public Clock(string name)
        {
        }
        public void Tick()
        {
            _seconds.Increment();
            if (_seconds.Tick >= 60)
            {
                _seconds.Reset();
                _minutes.Increment();
                if(_minutes.Tick >= 60)
                {
                    _minutes.Reset();
                    _hours.Increment();
                    if(_hours.Tick >= 12)
                    {
                        _hours.Reset();
                        if (_ampm == "AM")
                        {
                            _ampm = "PM";
                        } else
                        {
                            _ampm = "AM";
                        }
                    }
                } 
            } 
        }
        public void Reset()
        {
            _hours.Reset();
            _minutes.Reset();
            _seconds.Reset();
        }
        public string Time
        {
            get
            {
                // string _currentTime = _hours.Tick;
                string _isUnderTen(long count) => count < 10 ? $"0{count}" : $"{count}";
                string _checkHours = _hours.Tick == 0 ? "12" : _isUnderTen(_hours.Tick);
                string _checkMinutes = _isUnderTen(_minutes.Tick);
                string _checkSeconds = _isUnderTen(_seconds.Tick);
                return $"{_checkHours}:{_checkMinutes}:{_checkSeconds} {_ampm}";
            }
        }
    }
}
