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
using System.Windows.Shapes;
using _0709study.ViewModel;
namespace _0709study
{
    /// <summary>
    /// Interaction logic for AddControl.xaml
    /// </summary>
    public partial class AddControl : Window
    {
        
        public AddControl()
        {
            InitializeComponent();
            DataContext = App.viewModel;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

            this.Visibility = Visibility.Collapsed;

            if (AM.IsChecked == true)
            {
                App.viewModel.ConvertToTime(true);
            }

            else
            {
                App.viewModel.ConvertToTime(false);
            }

            years.Text = string.Empty;
            months.Text = string.Empty;
            days.Text = string.Empty;
            hours.Text = string.Empty;
            minutes.Text = string.Empty;
            AM.IsChecked = true;
        }

        private void ModifyButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancleButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
