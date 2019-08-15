using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
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
    /// Interaction logic for AppendPage.xaml
    /// </summary>
    public partial class AppendPage : Page
    {
        public AppendPage()
        {
            InitializeComponent();
            this.ShowsNavigationUI = false;
            this.DataContext = App.appendViewModel;
        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            App.web.Show();
        }

        private void Append_Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Cancle_Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("SelectMode.xaml", UriKind.Relative));
        }

        public Bitmap WebImageView(string URL)
        {
            try
            {
                WebClient Downloader = new WebClient();
                Stream ImageStream = Downloader.OpenRead(URL);
                Bitmap DownloadImage = Bitmap.FromStream(ImageStream) as Bitmap;
                return DownloadImage;
            }
            catch (Exception)
            {
                return null;
            }

        }

        
    }
}
