// <copyright file="LoginPage.xaml.cs" company="RSSCargo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RSS_Cargo.Presentation
{
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
    using RSS_cargo.DAL.Context;
    using RSS_cargo.DAL.Repositories;

    /// <summary>
    /// Interaction logic for LoginPage.xaml.
    /// </summary>
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            var login = this.txtEmail.Text;
            var pass = this.txtPassword.Password.ToString();

            var ur = new UserRepository(Program.DB!);

            var user = ur.LoginUser(login, pass);

            if (user == null)
            {
                this.loginError.Text = "Login or password does not match!";
                this.loginError.Visibility = Visibility.Visible;

                Program.Log.Error($"Login for user {login} failed");

                return;
            }

            this.loginError.Visibility = Visibility.Hidden;

            Program.LoggedUser = user;
            Console.WriteLine($"Logged as user: [{user.Id}] {user.Email}");

            Program.Log.Info($"Login as user {login} successful");

            MainWindow window_main = new MainWindow();
            window_main.Show();
            this.Close();
        }

        private void BtnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            RegistrationPage window_registration = new RegistrationPage();
            window_registration.Show();
            this.Close();
        }
    }
}
