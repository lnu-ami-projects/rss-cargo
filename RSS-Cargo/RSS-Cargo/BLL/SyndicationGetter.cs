// <copyright file="SyndicationGetter.cs" company="RSSCargo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RSS_Cargo.BLL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel.Syndication;
    using System.Text;
    using System.Threading.Tasks;

    internal static class SyndicationGetter
    {
        public static string GetValueOrEmpty(TextSyndicationContent? item)
        {
            return item is not { Type: "text" } ? string.Empty : item.Text;
        }

        public static string GetValueOrEmpty(SyndicationContent? item)
        {
            return item is not { Type: "text" } ? string.Empty : ((TextSyndicationContent)item).Text;
        }

        public static string GetValueOrEmpty(DateTimeOffset? item)
        {
            return item == null ? string.Empty : item.Value.ToString();
        }

        public static string[] GetValueOrEmpty(IReadOnlyCollection<SyndicationPerson>? item)
        {
            return item == null
                ? new string[] { }
                : item.Select(i => i.Email == string.Empty ? i.Name : i.Name + " (" + i.Email + ")").ToArray();
        }

        public static Tuple<string, string>[] GetValueOrEmpty(IReadOnlyCollection<SyndicationLink>? item)
        {
            return item == null
                ? new Tuple<string, string>[] { }
                : item.Select(i => new Tuple<string, string>(i.Title, i.Uri.ToString())).ToArray();
        }
    }
}
