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
using System.Windows.Shapes;

namespace TestingGiant.App.Views
{
    /// <summary>
    /// Interaction logic for ShellConductorView.xaml
    /// </summary>
    public partial class ShellConductorView : Window
    {
        public ShellConductorView()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void GridMainHeader_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
