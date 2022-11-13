using RSS_cargo.DAL.Repositories;
using RSS_Cargo.BLL;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RSS_Cargo.Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Program.Log.Info("Init main window");

            if (Program.LoggedUser == null)
            {
                LoginPage loginPage = new LoginPage();
                loginPage.Show();
                this.Close();

                return;
            }

            usernameBox.Text = Program.LoggedUser.Username;

            var userFeeds = Program.DB.UserFeeds.Where(f => f.UserId == Program.LoggedUser.Id);

            Program.Log.Info("Loading user feeds");

            Program.UserFeeds = userFeeds.Select(f => new RssFeed(f.RssFeed)).ToList();

            Console.WriteLine($"User feed found: {Program.UserFeeds.Count}");

            Program.UserFeeds.ForEach(f =>
            {
                var tb = new TextBlock();
                tb.Text = f.Title;
                tb.FontSize = 16;
                tb.TextTrimming = TextTrimming.CharacterEllipsis;

                followedList.Children.Add(tb);
            });

            Program.Log.Info("User feeds loaded");
        }

        private void FeedsAllBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void FeedsFollowedBtn_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void CargosAllBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void CargosFollowedBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void searchAddBtn_Click(object sender, RoutedEventArgs e)
        {
            var feed = searchBox.Text;

            Console.WriteLine($"Trying to add feed: {feed}");

            if (feed == "")
            {
                searchBox.BorderBrush = new SolidColorBrush(Colors.Red);
                return;
            }
            searchBox.BorderBrush = new SolidColorBrush(Colors.Transparent);

            RssFeed newFeed;
            try
            {
                newFeed = new RssFeed(feed);
                Program.UserFeeds!.Add(newFeed);
            } catch (Exception)
            {
                searchBox.BorderBrush = new SolidColorBrush(Colors.Red);
                return;
            }
            searchBox.BorderBrush = new SolidColorBrush(Colors.Transparent);

            var ur = new UserRepository(Program.DB);

            try
            {
                ur.AddFeedUser(Program.LoggedUser!.Id, feed);
            }
            catch (Exception)
            {
                searchBox.BorderBrush = new SolidColorBrush(Colors.Red);
                return;
            }
            searchBox.BorderBrush = new SolidColorBrush(Colors.Transparent);
            searchBox.Text = "";

            var tb = new TextBlock();
            tb.Text = newFeed.Title;
            tb.FontSize = 16;
            tb.TextTrimming = TextTrimming.CharacterEllipsis;

            followedList.Children.Add(tb);

            Console.WriteLine($"Added feed: {feed}");
        }
    }
}
