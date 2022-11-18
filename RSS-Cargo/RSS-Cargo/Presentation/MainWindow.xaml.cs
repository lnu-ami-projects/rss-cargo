// <copyright file="MainWindow.xaml.cs" company="RSSCargo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RSS_Cargo.Presentation
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using RSS_Cargo.BLL;
    using RSS_cargo.DAL.Repositories;
    using System.Collections.Generic;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();

            Program.Log.Info("Init main window");

            if (Program.LoggedUser == null)
            {
                LoginPage loginPage = new();
                loginPage.Show();
                this.Close();

                return;
            }

            this.usernameBox.Text = Program.LoggedUser.Username;

            var userFeeds = Program.DB!.UserFeeds.Where(f => f.UserId == Program.LoggedUser.Id);

            Program.UserFeeds = userFeeds.Select(f => new RssFeed(f.RssFeed)).ToList();

            Program.UserFeeds.ForEach(f =>
            {
                var tb = new TextBlock
                {
                    Text = f.Title,
                    FontSize = 16,
                    TextTrimming = TextTrimming.CharacterEllipsis,
                };

                this.followedList.Children.Add(tb);
            });

            Program.Log.Info("User feeds loaded");

            var cargos = Program.DB.Cargos.ToList();
            Program.Cargos = cargos;

            Program.CargoFeeds = new Dictionary<int, List<RssFeed>>();
            foreach (var cargo in cargos)
            {
                var feeds = new List<RssFeed>();
                var cargoFeeds = Program.DB!.CargoFeeds.Where(c => c.CargoId == cargo.Id).ToArray();
                foreach (var feed in cargoFeeds)
                {
                    feeds.Add(new RssFeed(feed.RssFeed));
                }

                Program.CargoFeeds[cargo.Id] = feeds;
            }

            Program.UserCargos = new List<RSS_cargo.DAL.Models.Cargo>();

            var userCargos = Program.DB!.UserCargos.Where(c => c.UserId == Program.LoggedUser.Id).ToArray();
            Console.WriteLine($"userCargos {userCargos.Length}");
            foreach (var cargo in userCargos)
            {
                var c = cargos.First(c => c.Id == cargo.CargoId);
                Program.UserCargos.Add(c);

                var tb = new TextBlock
                {
                    Text = c.Name,
                    FontSize = 16,
                    TextTrimming = TextTrimming.CharacterEllipsis,
                };

                this.cargosList.Children.Add(tb);
            }

            Program.MainW = this;
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

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SearchAddBtn_Click(object sender, RoutedEventArgs e)
        {
            var feed = this.searchBox.Text;

            Console.WriteLine($"Trying to add feed: {feed}");

            if (feed == string.Empty)
            {
                this.searchBox.BorderBrush = new SolidColorBrush(Colors.Red);
                return;
            }

            this.searchBox.BorderBrush = new SolidColorBrush(Colors.Transparent);

            RssFeed newFeed;
            try
            {
                newFeed = new RssFeed(feed);
                Program.UserFeeds!.Add(newFeed);
            }
            catch (Exception)
            {
                this.searchBox.BorderBrush = new SolidColorBrush(Colors.Red);
                return;
            }

            this.searchBox.BorderBrush = new SolidColorBrush(Colors.Transparent);

            var ur = new UserRepository(Program.DB!);

            try
            {
                ur.AddFeedUser(Program.LoggedUser!.Id, feed);
            }
            catch (Exception)
            {
                this.searchBox.BorderBrush = new SolidColorBrush(Colors.Red);
                return;
            }

            this.searchBox.BorderBrush = new SolidColorBrush(Colors.Transparent);
            this.searchBox.Text = string.Empty;

            var tb = new TextBlock
            {
                Text = newFeed.Title,
                FontSize = 16,
                TextTrimming = TextTrimming.CharacterEllipsis,
            };

            this.followedList.Children.Add(tb);

            Console.WriteLine($"Added feed: {feed}");
        }
    }
}
