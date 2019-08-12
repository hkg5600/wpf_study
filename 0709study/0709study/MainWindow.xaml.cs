using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Globalization;
using _0709study.ViewModel;
using _0709study.Model;


namespace _0709study
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            DataContext = App.viewModel;
            DispatcherTimer mainTimer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 1)
            };
            mainTimer.Tick += Timer_Tick;
            mainTimer.Start();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            App.viewModel.IsAdd = Visibility.Visible;
            App.viewModel.IsModify = Visibility.Collapsed;
            App.addControl.Show();
        }

        private void ModifyButton_Click(object sender, RoutedEventArgs e)
        {
            App.viewModel.IsAdd = Visibility.Collapsed;
            App.viewModel.IsModify = Visibility.Visible;
            App.addControl.Show();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            App.viewModel.DeleteTime();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            Clock.Text = DateTime.Now.ToString();
        }
    }
}
