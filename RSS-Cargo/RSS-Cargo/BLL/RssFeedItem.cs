// <copyright file="RssFeedItem.cs" company="RSSCargo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RSS_Cargo.BLL
{
    using System;
    using System.ServiceModel.Syndication;

    /// <summary>
    /// Reperestnts single RSS post.
    /// </summary>
    public class RssFeedItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RssFeedItem"/> class.
        /// </summary>
        /// <param name="item">RSS Item.</param>
        public RssFeedItem(SyndicationItem item)
        {
            this.Title = SyndicationGetter.GetValueOrEmpty(item.Title);
            this.PublishDate = SyndicationGetter.GetValueOrEmpty(item.PublishDate);
            this.Links = SyndicationGetter.GetValueOrEmpty(item.Links);
            this.Summary = SyndicationGetter.GetValueOrEmpty(item.Summary);
            this.Content = SyndicationGetter.GetValueOrEmpty(item.Content);
        }

        /// <summary>
        /// Gets RSS post title.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Gets RSS post publish date.
        /// </summary>
        public string PublishDate { get; }

        /// <summary>
        /// Gets RSS post links.
        /// </summary>
        public Tuple<string, string>[] Links { get; } // Title & Link

        /// <summary>
        /// Gets RSS post summary.
        /// </summary>
        public string Summary { get; }

        /// <summary>
        /// Gets RSS post conent.
        /// </summary>
        public string Content { get; }
    }
}
