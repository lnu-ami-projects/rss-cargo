// <copyright file="Program.cs" company="RSSCargo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RSS_Cargo
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using log4net;
    using RSS_Cargo.BLL;
    using RSS_cargo.DAL.Context;
    using RSS_cargo.DAL.Models;

    public static class Program
    {
        private static User? loggedUser;

        private static List<RssFeed>? userFeeds;

        public static RsscargoContext? DB { get; set; }

        public static User? LoggedUser { get => loggedUser; set => loggedUser = value; }

        public static List<RssFeed>? UserFeeds { get => userFeeds; set => userFeeds = value; }

        public static ILog Log { get; } = LogManager.GetLogger(type: MethodBase.GetCurrentMethod()!.DeclaringType);

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
