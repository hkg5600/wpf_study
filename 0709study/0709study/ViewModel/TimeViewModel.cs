using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace _0709study.ViewModel
{
    class TimeViewModel : INotifyPropertyChanged
    {
        DispatcherTimer timer = new DispatcherTimer();
        private string year, month, day, hour, minute, dueTime, ap, showTime;
        int i = 0;
        #region
        public string Year
        {
            get => year;
            set
            {
                year = value;
                OnPropertyChanged("Year");
            }
        }
        public string Month
        {
            get => month;
            set
            {
                month = value;
                OnPropertyChanged("Month");
            }
        }
        public string Day
        {
            get => day;
            set
            {
                day = value;
                OnPropertyChanged("Day");
            }
        }
        public string Hour
        {
            get => hour;
            set
            {
                hour = value;
                OnPropertyChanged("Hour");
            }
        }
        public string Minute
        {
            get => minute;
            set
            {
                minute = value;
                OnPropertyChanged("Minute");
            }
        }

        public string ShowTime
        {
            get { return showTime; }
            set
            {
                showTime = value;
                OnPropertyChanged("ShowTime");
            }
        }

        #endregion

        ObservableCollection<Data> items = new ObservableCollection<Data>();
        public ObservableCollection<Data> Items
        {
            get => items;
            set
            {
                items = value;
                OnPropertyChanged("Items");
            }
        }

        public void ConvertToTime(bool IsChecked)
        {
            if (IsChecked)
            {
                ap = "AM";
            }
            else
            {
                ap = "PM";
            }
            dueTime = Year + "/" + Month + "/" + Day + " " + Hour + ":" + Minute + ":" + "0" + " " + ap;
            CultureInfo cultures = CultureInfo.CreateSpecificCulture("ko-KR");
            DateTime time = Convert.ToDateTime(dueTime, cultures);
            SetTime(time);
        }

        public void SetTime(DateTime time)
        {
            ShowTime = Convert.ToString(time);
            int hours = 0; //time을 변환해야함
            int minutes = 0;
            int secs = 0;
            timer.Interval = new TimeSpan(hours, minutes, secs);
            Items.Add(new Data());
            Items[i].dueTime = time;
            Items[i].id = i;
            i++;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void ModifyTime(int id, DateTime time)
        {

        }

        private void DeleteTime(int id)
        {

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            EndOfTimer();
        }

        private void EndOfTimer()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
