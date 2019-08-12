using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using _0709study.Model;
using System.Windows;

namespace _0709study.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        CultureInfo cultures;
        DateTime time;
        private string ap, dueTime;

        public MainViewModel()
        {
            cultures = CultureInfo.CreateSpecificCulture("ko-KR");
        }

        #region
        private string year;
        public string Year
        {
            get => year;
            set
            {
                year = value;
                OnPropertyChanged("Year");
            }
        }

        private string month;
        public string Month
        {
            get => month;
            set
            {
                month = value;
                OnPropertyChanged("Month");
            }
        }

        internal void TestSetTime(DateTime value)
        {
            throw new NotImplementedException();
        }

        private string day;
        public string Day
        {
            get => day;
            set
            {
                day = value;
                OnPropertyChanged("Day");
            }
        }
        private string hour;
        public string Hour
        {
            get => hour;
            set
            {
                hour = value;
                OnPropertyChanged("Hour");
            }
        }
        private string minute;
        public string Minute
        {
            get => minute;
            set
            {
                minute = value;
                OnPropertyChanged("Minute");
            }
        }
        private string showTime;
        public string ShowTime
        {
            get { return showTime; }
            set
            {
                showTime = value;
                OnPropertyChanged("ShowTime");
            }
        }
        private Visibility isAdd;
        public Visibility IsAdd
        {
            get { return isAdd; }
            set
            {
                isAdd = value;
                OnPropertyChanged("IsAdd");
            }
        }
        private Visibility isModify;
        public Visibility IsModify

        {
            get { return isModify; }
            set
            {
                isModify = value;
                OnPropertyChanged("IsModify");
            }
        }

        #endregion

        private TimeModel selectedItem;
        public TimeModel SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        ObservableCollection<TimeModel> items = new ObservableCollection<TimeModel>();
        public ObservableCollection<TimeModel> Items
        {
            get => items;
            set
            {
                items = value;
                OnPropertyChanged("Items");
            }
        }

        public DateTime? ConvertToTime(bool ApIsChecked)
        {
            if (ApIsChecked)
            {
                ap = "AM";
            }
            else
            {
                ap = "PM";
            }

            dueTime = Year + "/" + Month + "/" + Day + " " + Hour + ":" + Minute + ":" + "0" + " " + ap;

            try
            {
                time = Convert.ToDateTime(dueTime, cultures);
                if (0 <= DateTime.Compare(DateTime.Now, time))
                {
                    _ = MessageBox.Show("지금 이후의 시간을 입력해주세요.", "ERROR");
                    return null;
                }
                else if (!ValidData(time).HasValue)
                {
                   _ = MessageBox.Show("이미 있는 설정입니다.", "ERROR");
                    return null;
                }
                else
                {
                    return time;
                }

            }
            catch (Exception)
            {
                _ = MessageBox.Show("정확한 시간을 입력해주세요.", "ERROR");
                return null;
            }

        }

        public void SetTime(DateTime time)
        {
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, ConvertToMin(time), 0)
            };
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();

            Items.Add(new TimeModel() { dueTime = time, modelTimer = timer });
        }

        public void ModifyTime(DateTime time)
        {
            DeleteTime();
            SetTime(time);
        }

        public void DeleteTime()
        {
            Items.Remove(SelectedItem);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            EndOfTimer(GetTime());
        }

        private void EndOfTimer(TimeModel time)
        {
            if (time != null)
            {
                time.modelTimer.Stop();
                Items.Remove(time);
                _ = MessageBox.Show("설정한 시간이 되었습니다");
            }
            else
            {
                _ = MessageBox.Show("무언가 잘못됨.", "ERROR");
            }
        }

        private TimeModel GetTime()
        {
            dynamic time = App.mainWindow.listView.Items;
            foreach (TimeModel t in time)
            {
                DateTime t1 = t.dueTime;
                DateTime t2 = DateTime.Now;
                if (t1.Year == t2.Year && t1.Month == t2.Month && t1.Day == t2.Day && t1.Hour == t2.Hour && t1.Minute == t2.Minute)
                {
                    return t;
                }
            }
            return null;
        }

        private DateTime? ValidData(DateTime time)
        {
            dynamic d = App.mainWindow.listView.Items;
            foreach (TimeModel t in d)
            {
                DateTime t1 = t.dueTime;
                DateTime t2 = time;
                if (t1.Year == t2.Year && t1.Month == t2.Month && t1.Day == t2.Day && t1.Hour == t2.Hour && t1.Minute == t2.Minute)
                {
                    return null;
                }
            }
            return time;
        }

        private int ConvertToMin(DateTime time)
        {
            DateTime t = new DateTime(time.Year, time.Month, time.Day);
            TimeSpan resultTime = t - DateTime.Now;
            if (DateTime.Now.Day == time.Day)
            {
                return ((time.Hour - DateTime.Now.Hour) * 60) + ((time.Minute - DateTime.Now.Minute));
            }
            else
            {
                return (resultTime.Days * 24 * 60) + ((time.Hour - DateTime.Now.Hour) * 60) + ((time.Minute - DateTime.Now.Minute));
            }
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
