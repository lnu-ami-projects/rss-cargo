// <copyright file="RegistrationPage.xaml.cs" company="RSSCargo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RSS_Cargo.Presentation
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Metrics;
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

    /// <summary>
    /// Interaction logic for RegistrationPage.xaml.
    /// </summary>
    public partial class RegistrationPage : Window
    {
        public RegistrationPage()
        {
            this.InitializeComponent();
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            var login = this.txtEmail.Text;
            var username = this.txtName.Text;
            var pass = this.txtPassword.Password.ToString();
            var rePass = this.txtRePassword.Password.ToString();

            if (pass != rePass)
            {
                this.regError.Text = "Confirmation password does not match!";
                this.regError.Visibility = Visibility.Visible;

                Program.Log.Error($"Registration failed: confirmation password does not match");

                return;
            }

            this.regError.Visibility = Visibility.Hidden;

            var ur = new UserRepository(Program.DB!);

            try
            {
                ur.RegisterUser(login, username, pass);
            }
            catch (Exception)
            {
                this.regError.Text = "Registration failed!";
                this.regError.Visibility = Visibility.Visible;

                Program.Log.Error($"Registration failed: database error");

                return;
            }

            this.regError.Visibility = Visibility.Hidden;

            Program.Log.Info($"registred user: {login}");

            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Close();
        }

        private void BtnLoginInAcc_Click(object sender, RoutedEventArgs e)
        {
            LoginPage window_login = new LoginPage();
            window_login.Show();
            this.Close();
        }
    }
}
