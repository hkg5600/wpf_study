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

namespace _0709study
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        TimeViewModel viewModel = new TimeViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext =viewModel;
            DispatcherTimer mainTimer = new DispatcherTimer();
            mainTimer.Interval = new TimeSpan(0, 0, 1);
            mainTimer.Tick += Timer_Tick;
            mainTimer.Start();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (AM.IsChecked == true)
            {
                viewModel.ConvertToTime(true);
            }
            else
            {
                viewModel.ConvertToTime(false);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Clock.Text = DateTime.Now.ToString();
        }
    }
}
