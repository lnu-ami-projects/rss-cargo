// <copyright file="RssFeed.cs" company="RSSCargo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RSS_Cargo.BLL
{
    using System.Linq;
    using System.ServiceModel.Syndication;
    using System.Xml;

    /// <summary>
    /// Repersents single feed.
    /// </summary>
    public class RssFeed
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RssFeed"/> class.
        /// </summary>
        /// <param name="url">Feed url.</param>
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

        /// <summary>
        /// Gets RSS post title.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Gets RSS post description.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Gets RSS post update time.
        /// </summary>
        public string LastUpdatedTime { get; }

        /// <summary>
        /// Gets RSS post authors.
        /// </summary>
        public string[] Authors { get; }

        /// <summary>
        /// Gets RSS post items.
        /// </summary>
        public RssFeedItem[] Items { get; }
    }
}
