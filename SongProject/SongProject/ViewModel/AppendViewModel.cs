using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongProject.ViewModel
{
    public class AppendViewModel : INotifyPropertyChanged
    {

        private string title;
        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }
            
        private string code;
        public string Code
        {
            get => code;
            set
            {
                code = value;
                OnPropertyChanged("Code");
            }
        }

        private string url;
        public string Url
        {
            get => url;
            set
            {
                url = value;
                OnPropertyChanged("Url");
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
