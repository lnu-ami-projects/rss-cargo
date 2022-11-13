// <copyright file="RssFeed.cs" company="RSSCargo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RSS_Cargo.BLL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel.Syndication;
    using System.Xml;

    public class RssFeed
    {
        public RssFeed(string url)
        {
            Program.Log.Info($"Reading RSS Feed: {url}");

            using var reader = XmlReader.Create(url);
            var feed = SyndicationFeed.Load(reader);

            this.Title = SyndicationGetter.GetValueOrEmpty(feed.Title);
            this.Description = SyndicationGetter.GetValueOrEmpty(feed.Description);
            this.LastUpdatedTime = SyndicationGetter.GetValueOrEmpty(feed.LastUpdatedTime);
            this.Authors = SyndicationGetter.GetValueOrEmpty(feed.Authors);

            this.Items = feed.Items.Select(i => new RssFeedItem(i)).ToArray();

            Program.Log.Info($"For RSS Feed: {url}, found {this.Items.Length} items");
        }

        public string Title { get; }

        public string Description { get; }

        public string LastUpdatedTime { get; }

        public string[] Authors { get; }

        public RssFeedItem[] Items { get; }
    }
}
