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

namespace SongProject
{
    /// <summary>
    /// Interaction logic for SelectMode.xaml
    /// </summary>
    public partial class SelectMode : Page
    {
        public SelectMode()
        {
            InitializeComponent();
        }

        private void Append_Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("AppendPage.xaml", UriKind.Relative));
        }

        private void Select_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
