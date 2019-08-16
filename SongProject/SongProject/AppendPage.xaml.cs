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
using Image = System.Drawing.Image;

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
            if (ValidTextBox())
            {
                if (App.appendViewModel.SendDataToSender())
                {
                    _ = MessageBox.Show("저장 완료.");
                }
                initBox();
                this.NavigationService.Navigate(new Uri("SelectMode.xaml", UriKind.Relative));
            }
            else
            {
                initBox();
                _ = MessageBox.Show("모든 항목을 입력해주세요");
            }
        }
        private void Cancle_Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("SelectMode.xaml", UriKind.Relative));
        }

        public bool ValidTextBox()
        {
            if (this.codeBox.Text != null && this.titleBox.Text != null && this.urlBox.Text != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void initBox()
        {
            this.codeBox.Text = null;
            this.titleBox.Text = null;
            this.urlBox.Text = null;
        }

        private static Image WebImageView(string URL)
        {
            WebClient wc = new WebClient();
            byte[] bytes = wc.DownloadData(URL);
            MemoryStream ms = new MemoryStream(bytes);
            Image img = System.Drawing.Image.FromStream(ms);
            return img;
        }

    }
}
