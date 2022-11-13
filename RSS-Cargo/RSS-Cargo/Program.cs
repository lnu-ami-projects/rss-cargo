using RSS_cargo.DAL.Context;
using RSS_cargo.DAL.Models;
using RSS_Cargo.BLL;
using System;
using System.Collections.Generic;
using System.Reflection;
using log4net;
using log4net.Config;
using System.IO;

namespace RSS_Cargo
{
    public static class Program
    {

        public static RsscargoContext DB;

        public static User? LoggedUser;

        public static List<RssFeed>? UserFeeds;

        public static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        [STAThread]
        public static void Main(string[] args)
        {
            Console.WriteLine("==== Starting ====");

            Log.Info("Starting");

            DB = new RsscargoContext();

            var app = new App();
            app.InitializeComponent();
            app.Run();

            Log.Info("Done");

            Console.WriteLine("==== Done ====");
        }
    }
}
