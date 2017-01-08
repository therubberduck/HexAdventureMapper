using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HexAdventureMapper.Database;
using HexAdventureMapper.DataObjects;

namespace HexAdventureMapper.TimeAndWeather
{
    public class TimeAndWeatherHandler
    {
        private List<ITimeAndWeatherListener> _listeners;

        private readonly DbInterface _db;
        private Session _session;

        public Session Session
        {
            get { return _session; }
            set { _session = value; }
        }

        public TimeAndWeatherHandler(DbInterface db)
        {
            if (db != null)
            {
                _db = db;
                _session = _db.Session.Get();
            }

            _listeners = new List<ITimeAndWeatherListener>();
        }

        public void Subscribe(ITimeAndWeatherListener listener)
        {
            _listeners.Add(listener);
        }

        private void CallListeners()
        {
            foreach (var listener in _listeners)
            {
                listener.TimeChanged();
            }
        }

        public string GetTime()
        {
            return DateTimePresenter.GetOrdinal(_session.Day % 30 + 1) + " of " + DateTimePresenter.GetMonth(_session.Day) + ", " + DateTimePresenter.GetTimeOfDay(_session.Day, (int) _session.Time.TotalMinutes);
        }

        public string GetActualYear()
        {
            return "Year " + _session.Year;
        }

        public string GetActualDate()
        {
            return DateTimePresenter.GetOrdinal(_session.Day %30 + 1) + " of " + DateTimePresenter.GetMonth(_session.Day);
        }

        public string GetActualTime()
        {
            return _session.TimeString;
        }

        public string GetWeather()
        {
            return WeatherGenerator.GetWeather(_session);
        }

        public string GetSunrise()
        {
            return DateTimePresenter.GetSunrise(_session.Day);
        }

        public string GetSunset()
        {
            return DateTimePresenter.GetSunset(_session.Day);
        }

        //
        // Editing Methods
        //

        public void AddTimes(int days, int hours, int minutes)
        {
            ChangeTimes(days, hours, minutes);
        }

        public void SubtractTimes(int days, int hours, int minutes)
        {
            ChangeTimes(-days, -hours, -minutes);
        }
        
        private void ChangeTimes(int days, int hours, int minutes)
        {
            var daysUpdated = false;
            var yearUpdated = false;

            //Update minutes in handler (and maybe day (and maybe year))
            if (hours != 0 || minutes != 0)
            {
                var totalMinutes = (int)_session.Time.TotalMinutes + hours * 60 + minutes;
                if (0 <= totalMinutes && totalMinutes < 1440)
                {
                    _session.Time = _session.Time.Add(new TimeSpan(hours, minutes, 0));
                }
                else
                {
                    _session.Time = new TimeSpan(0, totalMinutes % 1440, 0);
                    if (_session.Time.TotalMinutes < 0)
                    {
                        _session.Time = _session.Time.Add(new TimeSpan(0, 1440,0));
                    }

                    //On negative number subtract additional day to ensure we have an entire day in the next calculation
                    if (totalMinutes < 0)
                    {
                        totalMinutes -= 1440;
                    }

                    days = days + totalMinutes / 1440;
                }
            }

            //Update days (and maybe year) in handler
            if (days != 0)
            {
                var totalDays = _session.Day + days;
                if (0 <= totalDays && totalDays < 365)
                {
                    _session.Day = _session.Day + days;

                    daysUpdated = true;
                }
                else
                {
                    _session.Day = totalDays % 365;

                    if (_session.Day < 0)
                    {
                        _session.Day += 365;
                    }
                    //On negative number subtract additional year to ensure we have an entire year in the next calculation
                    if (totalDays < 0)
                    {
                        totalDays -= 365;
                    }

                    var yearChange = totalDays / 365;
                    _session.Year = _session.Year + yearChange;

                    daysUpdated = true;
                    yearUpdated = true;
                }
            }

            //Update in database
            if (_db != null)
            {
                if (hours != 0 || minutes != 0)
                {
                    _db.Session.UpdateTime(_session.Time);
                }
                if (daysUpdated)
                {
                    _db.Session.UpdateDays(_session.Day);
                }
                if (yearUpdated)
                {
                    _db.Session.UpdateYear(_session.Year);
                }
            }

            CallListeners();
        }
    }
}
