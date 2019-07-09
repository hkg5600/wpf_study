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
namespace _0709study
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<DispatcherTimer> timer = new List<DispatcherTimer>();
        int i = 0;
        public MainWindow()
        {
            InitializeComponent();

            //DispatcherTimer timer = new DispatcherTimer();
            
            //timer.Add(new DispatcherTimer());
            //timer[0].Interval = new TimeSpan(0, 0, 1);
            //timer[0].Tick += Timer_Tick;
            //timer[0].Start();
            //timer.Add(new DispatcherTimer());
            //timer[1].Interval = new TimeSpan(0, 0, 2);
            //timer[1].Tick += Test;
            //timer[1].Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Clock.Text = DateTime.Now.ToString();
        }

        private void Test(object sender, EventArgs e)
        {
            test.Text = DateTime.Now.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int sec = int.Parse(txtbox.Text);
            timer.Add(new DispatcherTimer());
            timer[i].Interval = new TimeSpan(0, 0, sec);
            timer[i].Tick += Timer_Tick; // 같은 메소드를 쓰지만 인자값을 다르게 해야하고 같은 메소드인데 아 그게 그 뭐냐 
                                         //그그그그그 이 메소드의 형식으로 여러개의 메소드를 생성해야함
            timer[i].Start();
            i++;
        }
    }
}
