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

namespace Police2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Manager.MainFrame = MainFrame;
            Manager.MainFrame.Navigate(new PageAuthorization());
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (Manager.MainFrame.CanGoBack)
            {
                buttonGoBack.Visibility = Visibility.Visible;
            }
            else
            {
                buttonGoBack.Visibility = Visibility.Hidden;
            }
        }

        private void buttonGoBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }
    }
}
