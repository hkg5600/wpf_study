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

namespace _0709study.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        DispatcherTimer timer = new DispatcherTimer();
        private string ap, dueTime;

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

        #endregion

        private bool isAdd = false;
        public bool IsAdd
        {
            get => isAdd;
            set
            {
                isAdd = value;
                OnPropertyChanged("IsAdd");
            }
        }

        private bool isModify = false;
        public bool IsModify
        {
            get => isModify;
            set
            {
                isModify = value;
                OnPropertyChanged("IsModify");
            }
        }

        private ListViewItem selectedItem;
        public ListViewItem SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        ObservableCollection<ListViewItem> items = new ObservableCollection<ListViewItem>();
        public ObservableCollection<ListViewItem> Items
        {
            get => items;
            set
            {
                items = value;
                OnPropertyChanged("Items");
            }
        }

        public bool IsModify1 { get => isModify; set => isModify = value; }

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
            Items.Add(new ListViewItem() { dueTime = time}) ;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        public void ModifyTime(int id, DateTime time)
        {

        }

        public void DeleteTime()
        {
            Items.Remove(SelectedItem);
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
