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
    using RSS_Cargo.Presentation;

    /// <summary>
    /// Entry point.
    /// </summary>
    public static class Program
    {
        private static User? loggedUser;

        private static List<RssFeed>? userFeeds;

        /// <summary>
        /// Gets or sets databse.
        /// </summary>
        public static RsscargoContext? DB { get; set; }

        /// <summary>
        /// Gets or sets user.
        /// </summary>
        public static User? LoggedUser { get => loggedUser; set => loggedUser = value; }

        /// <summary>
        /// Gets or sets feed.
        /// </summary>
        public static List<RssFeed>? UserFeeds { get => userFeeds; set => userFeeds = value; }

        public static List<Cargo>? Cargos { get; set; }

        public static Dictionary<int, List<RssFeed>>? CargoFeeds { get; set; }

        public static List<Cargo>? UserCargos { get; set; }

        public static MainWindow MainW { get; set; }

        /// <summary>
        /// Gets logger.
        /// </summary>
        public static ILog Log { get; } = LogManager.GetLogger(type: MethodBase.GetCurrentMethod()!.DeclaringType);

        /// <summary>
        /// Entrypoint.
        /// </summary>
        [STAThread]
        public static void Main()
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
