using SongProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SongProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static MainWindow mainWindow = new MainWindow();
        public static SelectMode selectMode = new SelectMode();
        public static AppendPage appendControl = new AppendPage();
        public static AppendViewModel appendViewModel = new AppendViewModel();
        public static Web web = new Web();
    }
}
