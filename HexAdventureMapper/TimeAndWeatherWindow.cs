using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HexAdventureMapper.TimeAndWeather;

namespace HexAdventureMapper
{
    public partial class TimeAndWeatherWindow : Form, ITimeAndWeatherListener
    {
        private TimeAndWeatherHandler _timeAndWeatherHandler;

        public TimeAndWeatherWindow(TimeAndWeatherHandler timeAndWeatherHandler)
        {
            InitializeComponent();

            _timeAndWeatherHandler = timeAndWeatherHandler;
            _timeAndWeatherHandler.Subscribe(this);

            UpdateDateTimeInView();
        }

        public void TimeChanged()
        {
            UpdateDateTimeInView();
        }

        private void UpdateDateTimeInView()
        {
            lblCurrentYear.Text = _timeAndWeatherHandler.GetActualYear();
            lblCurrentDate.Text = _timeAndWeatherHandler.GetActualDate();
            lblCurrentTime.Text = _timeAndWeatherHandler.GetActualTime();

            lblSunriseSunset.Text = "Sunrise: " + _timeAndWeatherHandler.GetSunrise() + " / Sunset: " +
                                    _timeAndWeatherHandler.GetSunset();
            lblWeather.Text = _timeAndWeatherHandler.GetWeather();
        }

        private void btnAddTime_Click(object sender, EventArgs e)
        {
            var days = 0;
            var hours = 0;
            var minutes = 0;
            if (!txtTimeValueDays.Text.Equals(""))
            {
                days = Convert.ToInt32(txtTimeValueDays.Text);
            }
            if (!txtTimeValueHours.Text.Equals(""))
            {
                hours = Convert.ToInt32(txtTimeValueHours.Text);
            }
            if (!txtTimeValueMinutes.Text.Equals(""))
            {
                minutes = Convert.ToInt32(txtTimeValueMinutes.Text);
            }

            _timeAndWeatherHandler.AddTimes(days, hours, minutes);

            UpdateDateTimeInView();
        }

        private void btnSubtractTime_Click(object sender, EventArgs e)
        {
            var days = 0;
            var hours = 0;
            var minutes = 0;
            if (!txtTimeValueDays.Text.Equals(""))
            {
                days = Convert.ToInt32(txtTimeValueDays.Text);
            }
            if (!txtTimeValueHours.Text.Equals(""))
            {
                hours = Convert.ToInt32(txtTimeValueHours.Text);
            }
            if (!txtTimeValueMinutes.Text.Equals(""))
            {
                minutes = Convert.ToInt32(txtTimeValueMinutes.Text);
            }

            _timeAndWeatherHandler.SubtractTimes(days, hours, minutes);

            UpdateDateTimeInView();
        }

        private void btnClearTimes_Click(object sender, EventArgs e)
        {
            txtTimeValueDays.Text = "";
            txtTimeValueHours.Text = "";
            txtTimeValueMinutes.Text = "";
        }

        private void numericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void lblDays_Click(object sender, EventArgs e)
        {
            txtTimeValueDays.Text = "";
        }

        private void lblHours_Click(object sender, EventArgs e)
        {
            txtTimeValueHours.Text = "";
        }

        private void lblMinutes_Click(object sender, EventArgs e)
        {
            txtTimeValueMinutes.Text = "";
        }
    }
}
