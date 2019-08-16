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
        public static AppendPage appendpage = new AppendPage();
        public static AppendViewModel appendViewModel = new AppendViewModel();
        public static SelectPage selectPage = new SelectPage();
        public static SelectViewModel selectViewModel = new SelectViewModel();
        public static ImageDetailViewModel imageDetailViewModel = new ImageDetailViewModel();
        public static Web web = new Web();
    }
}
