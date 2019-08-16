using GalaSoft.MvvmLight.Command;
using SongProject.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SongProject.ViewModel
{
    public class SelectViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<SongDataModel> data = new ObservableCollection<SongDataModel>();
        public ObservableCollection<SongDataModel> Data
        {
            get => data;
            set
            {
                data = value;
                OnPropertyChanged("Data");
            }
        }

        private SongDataModel selectedItem;
        public SongDataModel SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        public bool ReceiveFromServer()
        {
            var data = new RequestToSever().GetFromServer();
            if (data != null)
            {
                foreach (var v in data)
                {
                    Data.Add(new SongDataModel() { id = v["id"].ToString(), title = v["title"].ToString(), code = v["code"].ToString(), url = v["url"].ToString() });
                }
                return true;
            }
            else
            {
                return false;
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
