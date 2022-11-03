using RSS_cargo.DAL.Context;
using RSS_cargo.DAL.Models;
using RSS_cargo.DAL.Repositories;
using RSS_Cargo.BLL;
using RSS_Cargo.Presentation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSS_Cargo
{
    public static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Console.WriteLine("==== Starting ====");

            var db = new RsscargoContext();

            var ur = new UserRepository(db);

            // ==== TESTING ====

            //try
            //{
            //    ur.RegisterUser("a@b.c", "a", "b");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.InnerException?.Message);
            //}

            Console.WriteLine("Users: " + db.Users.Count());

            var loggedUser = ur.LoginUser("a@b.c", "b");
            if (loggedUser != null)
            {
                Console.WriteLine("Username: " + loggedUser.Username);

                //var newFeed = new UserFeed
                //{
                //    RssFeed = "http://rss.cnn.com/rss/edition.rss"
                //};
                //loggedUser.UserFeeds.Add(newFeed);
                //db.SaveChanges();

                var loggedUserFeeds = db.UserFeeds.Where(f => f.UserId == loggedUser.Id);

                Console.WriteLine("Feeds: " + loggedUserFeeds.Count());

                var feeds = loggedUserFeeds.Select(f => new RssFeed(f.RssFeed));
                foreach (var feed in feeds)
                {
                    Console.WriteLine(feed.Title);

                    foreach (var item in feed.Items.Take(3))
                    {
                        Console.WriteLine("     " + item.Title + " | " + item.PublishDate);
                    }
                }
            }

            // ==== TESTING ====

            var app = new App();
            app.InitializeComponent();
            app.Run();

            Console.WriteLine("==== Done ====");
        }
    }
}
