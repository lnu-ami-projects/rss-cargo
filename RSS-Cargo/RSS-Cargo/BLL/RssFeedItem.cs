namespace RSS_Cargo.BLL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel.Syndication;
    using System.Text;
    using System.Threading.Tasks;

    public class RssFeedItem
    {
        public RssFeedItem(SyndicationItem item)
        {
            this.Title = SyndicationGetter.GetValueOrEmpty(item.Title);
            this.PublishDate = SyndicationGetter.GetValueOrEmpty(item.PublishDate);
            this.Links = SyndicationGetter.GetValueOrEmpty(item.Links);
            this.Summary = SyndicationGetter.GetValueOrEmpty(item.Summary);
            this.Content = SyndicationGetter.GetValueOrEmpty(item.Content);
        }

        public string Title { get; }

        public string PublishDate { get; }

        public Tuple<string, string>[] Links { get; } // Title & Link

        public string Summary { get; }

        public string Content { get; }
    }
}
