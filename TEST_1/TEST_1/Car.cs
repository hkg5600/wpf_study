﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
namespace TEST_1
{
    class Car : Notifier
    {
        private double speed;
        private Color color;
        public double Speed
        {
            get { return speed; }
            set
            {
                speed = value;
                OnPropertyChanged("Speed");
            }
        }
        public Color Color {
            get { return color; }
            set
            {
                color = value;
                OnPropertyChanged("Color");
            }
        }
    }
}
