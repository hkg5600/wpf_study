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

namespace SongProject
{
    /// <summary>
    /// Interaction logic for ImageDetail.xaml
    /// </summary>
    public partial class ImageDetail : Window
    {
        public ImageDetail()
        {
            InitializeComponent();
            this.DataContext = App.imageDetailViewModel;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //구현 목적은 오류 방지였지만 내가 작성한 코드가 오류를 만들었고 지우니 아무 오류도 없다
        }
    }
}
