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

        public static RsscargoContext DB;

        public static User? LoggedUser;

        public static List<RssFeed>? UserFeeds;

        [STAThread]
        public static void Main(string[] args)
        {
            Console.WriteLine("==== Starting ====");

            DB = new RsscargoContext();

            var app = new App();
            app.InitializeComponent();
            app.Run();

            Console.WriteLine("==== Done ====");
        }
    }
}
