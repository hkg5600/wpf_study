using SongProject.Model;
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
    /// Interaction logic for SelectPage.xaml
    /// </summary>
    public partial class SelectPage : Page
    {
        public SelectPage()
        {
            InitializeComponent();
            this.DataContext = App.selectViewModel;

        }

        private void BackToMenu(object sender, RoutedEventArgs e)
        {
            App.selectViewModel.Data.Clear();
            this.NavigationService.Navigate(new Uri("Menu.xaml", UriKind.Relative));
        }

        private void ShowDetail_Button_Click(object sender, RoutedEventArgs e)
        {
            SongDataModel sdm = (SongDataModel)dataGrid.SelectedItem;
            App.imageDetailViewModel.Url = sdm.url;
            ImageDetail imageDetail = new ImageDetail();
            imageDetail.Show();
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            SongDataModel sdm = (SongDataModel)dataGrid.SelectedItem;
            if(new RequestToSever().DeleteMothod(sdm.id) == "NoContent")
            {
                _ = MessageBox.Show("삭제 완료.");
            }
            else
            {
                _ = MessageBox.Show("오류 발생 잠시 후 다시 시도해주세요.", "error");
            }
            App.selectViewModel.Data.Remove(sdm);
        }
    }
}
