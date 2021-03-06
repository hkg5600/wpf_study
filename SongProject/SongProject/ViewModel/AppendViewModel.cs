﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

        public bool SendDataToSender()
        {
            if("OK" == new RequestToSever().PostToServer(Title, Code, Url))
            {
                InitData();
                return true;
            }
            else
            {
                _ = MessageBox.Show("오류 발생 잠시 후 다시 시도해주세요.", "error");
                InitData();
                return false;
            }
        }

        public void InitData()
        {
            Url = string.Empty;
            Title = string.Empty;
            Code = string.Empty;
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
