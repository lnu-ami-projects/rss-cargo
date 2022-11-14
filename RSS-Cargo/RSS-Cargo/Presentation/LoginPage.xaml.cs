// <copyright file="LoginPage.xaml.cs" company="RSSCargo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RSS_Cargo.Presentation
{
    using System;
    using System.Windows;
    using System.Windows.Input;
    using RSS_cargo.DAL.Repositories;

    /// <summary>
    /// Interaction logic for LoginPage.xaml.
    /// </summary>
    public partial class LoginPage : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPage"/> class.
        /// </summary>
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

            MainWindow window_main = new();
            window_main.Show();
            this.Close();
        }

        private void BtnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            RegistrationPage window_registration = new();
            window_registration.Show();
            this.Close();
        }
    }
}
