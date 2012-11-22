﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace MyWeather.Views
{
    public partial class BackLiveTile : UserControl
    {
        public void SetProperties(ImageSource imageSource, string text)
        {
            this.backImage.Source = imageSource;
            this.backText.Text = text;
        }


        public BackLiveTile()
        {
            InitializeComponent();
        }
    }
}
