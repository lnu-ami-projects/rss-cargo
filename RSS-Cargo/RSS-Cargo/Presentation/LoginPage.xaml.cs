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
using RSS_cargo.DAL.Context;
using RSS_cargo.DAL.Repositories;
namespace RSS_Cargo.Presentation
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState=WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window_main = new MainWindow();
            
            //this.Visibility = Visibility.Hidden;
            window_main.Show();
            this.Close();
        }

        private void btnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            RegistrationPage window_registration = new RegistrationPage();
            //this.Visibility = Visibility.Hidden;
            window_registration.Show();
            this.Close();
        }
    }
}