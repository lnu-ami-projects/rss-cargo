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
            var db = new RsscargoContext();

            var ur = new UserRepository(db);
            if (txtPassword.Password == txtRePassword.Password)
            {
                ur.RegisterUser(txtEmail.Text, txtName.Text, txtPassword.Password);
            }
            else
            {
                txtRePassword.Clear();
                Re_password.Text = "Re-enter your password (Password was entered incorrectly)";
            }
        }

        private void btnLoginInAcc_Click(object sender, RoutedEventArgs e)
        {
            LoginPage window_login = new LoginPage();
            //this.Visibility = Visibility.Hidden;
            window_login.Show();
            this.Close();
        }
    }
}
