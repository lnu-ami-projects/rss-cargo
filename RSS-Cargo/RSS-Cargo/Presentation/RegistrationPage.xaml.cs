using RSS_cargo.DAL.Context;
using RSS_cargo.DAL.Repositories;
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

namespace RSS_Cargo.Presentation
{
    /// <summary>
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Window
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            var login = txtEmail.Text;
            var username = txtName.Text;
            var pass = txtPassword.Password.ToString();
            var rePass = txtRePassword.Password.ToString();

            if (pass != rePass)
            {
                regError.Text = "Confirmation password does not match!";
                regError.Visibility = Visibility.Visible;

                Program.Log.Error($"Registration failed: confirmation password does not match");

                return;
            }
            regError.Visibility = Visibility.Hidden;

            var ur = new UserRepository(Program.DB);

            try
            {
                ur.RegisterUser(login, username, pass);
            } catch (Exception)
            {
                regError.Text = "Registration failed!";
                regError.Visibility = Visibility.Visible;

                Program.Log.Error($"Registration failed: database error");

                return;
            }
            regError.Visibility = Visibility.Hidden;

            Program.Log.Info($"registred user: {login}");

            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Close();
        }

        private void btnLoginInAcc_Click(object sender, RoutedEventArgs e)
        {
            LoginPage window_login = new LoginPage();
            window_login.Show();
            this.Close();
        }
    }
}
