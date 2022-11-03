using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;

namespace RSS_Cargo.BLL
{
    public class RssFeed
    {
        public string Title { get; }
        public string Description { get; }
        public string LastUpdatedTime { get; }
        public string[] Authors { get; }
        public RssFeedItem[] Items { get; }

        public RssFeed(string url)
        {
            using var reader = XmlReader.Create(url);
            var feed = SyndicationFeed.Load(reader);

            Title = SyndicationGetter.GetValueOrEmpty(feed.Title);
            Description = SyndicationGetter.GetValueOrEmpty(feed.Description);
            LastUpdatedTime = SyndicationGetter.GetValueOrEmpty(feed.LastUpdatedTime);
            Authors = SyndicationGetter.GetValueOrEmpty(feed.Authors);

            Items = feed.Items.Select(i => new RssFeedItem(i)).ToArray();
        }
    }

    public class RssFeedItem
    {
        public string Title { get; }
        public string PublishDate { get; }
        public Tuple<string, string>[] Links { get; } // Title & Link
        public string Summary { get; }
        public string Content { get; }

        public RssFeedItem(SyndicationItem item)
        {
            Title = SyndicationGetter.GetValueOrEmpty(item.Title);
            PublishDate = SyndicationGetter.GetValueOrEmpty(item.PublishDate);
            Links = SyndicationGetter.GetValueOrEmpty(item.Links);
            Summary = SyndicationGetter.GetValueOrEmpty(item.Summary);
            Content = SyndicationGetter.GetValueOrEmpty(item.Content);
        }
    }

    internal static class SyndicationGetter
    {
        public static string GetValueOrEmpty(TextSyndicationContent? item)
        {
            return item is not { Type: "text" } ? "" : item.Text;
        }

        public static string GetValueOrEmpty(SyndicationContent? item)
        {
            return item is not { Type: "text" } ? "" : ((TextSyndicationContent)item).Text;
        }

        public static string GetValueOrEmpty(DateTimeOffset? item)
        {
            return item == null ? "" : item.Value.ToString();
        }

        public static string[] GetValueOrEmpty(IReadOnlyCollection<SyndicationPerson>? item)
        {
            return item == null
                ? new string[] { }
                : item.Select(i => i.Email == "" ? i.Name : i.Name + " (" + i.Email + ")").ToArray();
        }

        public static Tuple<string, string>[] GetValueOrEmpty(IReadOnlyCollection<SyndicationLink>? item)
        {
            return item == null
                ? new Tuple<string, string>[] { }
                : item.Select(i => new Tuple<string, string>(i.Title, i.Uri.ToString())).ToArray();
        }
    }
}
