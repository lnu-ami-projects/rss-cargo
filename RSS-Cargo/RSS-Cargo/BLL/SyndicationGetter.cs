// <copyright file="SyndicationGetter.cs" company="RSSCargo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RSS_Cargo.BLL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel.Syndication;

    /// <summary>
    /// Gets data from syndication.
    /// </summary>
    internal static class SyndicationGetter
    {
        /// <summary>
        /// Returns value of element.
        /// </summary>
        /// <param name="item">Text.</param>
        /// <returns>Text value.</returns>
        public static string GetValueOrEmpty(TextSyndicationContent? item)
        {
            return item is not { Type: "text" } ? string.Empty : item.Text;
        }

        /// <summary>
        /// Returns value of element.
        /// </summary>
        /// <param name="item">Text.</param>
        /// <returns>Text value.</returns>
        public static string GetValueOrEmpty(SyndicationContent? item)
        {
            return item is not { Type: "text" } ? string.Empty : ((TextSyndicationContent)item).Text;
        }

        /// <summary>
        /// Returns value of element.
        /// </summary>
        /// <param name="item">Text.</param>
        /// <returns>Text value.</returns>
        public static string GetValueOrEmpty(DateTimeOffset? item)
        {
            return item == null ? string.Empty : item.Value.ToString();
        }

        /// <summary>
        /// Returns value of element.
        /// </summary>
        /// <param name="item">Texts.</param>
        /// <returns>Text values.</returns>
        public static string[] GetValueOrEmpty(IReadOnlyCollection<SyndicationPerson>? item)
        {
            return item == null
                ? Array.Empty<string>()
                : item.Select(i => i.Email == string.Empty ? i.Name : i.Name + " (" + i.Email + ")").ToArray();
        }

        /// <summary>
        /// Returns value of element.
        /// </summary>
        /// <param name="item">Text pairs.</param>
        /// <returns>Text value pairs.</returns>
        public static Tuple<string, string>[] GetValueOrEmpty(IReadOnlyCollection<SyndicationLink>? item)
        {
            return item == null
                ? Array.Empty<Tuple<string, string>>()
                : item.Select(i => new Tuple<string, string>(i.Title, i.Uri.ToString())).ToArray();
        }
    }
}
