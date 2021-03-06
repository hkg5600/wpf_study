﻿using System;
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

namespace TEST_1
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        int i = 0;
        readonly dynamic cars = new List<Car>();
        public MainWindow()
        {
            InitializeComponent();
            //var cars = new List<Car>();
            //for (int i = 0; i < 5; i++)
            //{
            //    cars.Add(new Car()
            //    {
            //        Speed = i * 10
            //    });
            //}
            //this.DataContext = cars;
        }

        private void Btnsend_Click(object sender, RoutedEventArgs e)
        {
            if (this.txtbox.Text != "" && this.txtbox2.Text != "")
            {
                cars.Add(new Car()
                {
                    Speed = Convert.ToDouble(this.txtbox.Text),
                    Color = (Color)ColorConverter.ConvertFromString(this.txtbox2.Text)
                });
                lb.Items.Add(cars[i]);
                i++;
            }

        }
    }
}
