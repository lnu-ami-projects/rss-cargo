// <copyright file="RSSFeedsFollowedView.xaml.cs" company="RSSCargo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RSS_Cargo.Presentation.MVVM.View
{
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Effects;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media.Imaging;

    /// <summary>
    /// Interaction logic for RSSFeedsFollowedView.xaml.
    /// </summary>
    public partial class RSSFeedsFollowedView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RSSFeedsFollowedView"/> class.
        /// </summary>
        public RSSFeedsFollowedView()
        {
            this.InitializeComponent();

            var bc = new BrushConverter();

            for (int i = 0; i < Program.UserFeeds.Count; i++)
            {
                for (int j = 0; j < Program.UserFeeds[i].Items.Count(); j++)
                {
                    var feedItemBtn = new Button
                    {
                        Height = 134,
                        Width = 870,
                        Background = (Brush)bc.ConvertFrom("#F1F1F1"),
                        BorderThickness = new Thickness(0),
                        Margin = new Thickness(0, 0, 0, 40),
                        Style = (Style)this.FindResource("ContentNewsPageTheme"),
                        Uid = $"{i}_{j}",
                    };

                    var stackPanel = new StackPanel
                    {
                        Orientation = Orientation.Horizontal,
                        Background = (Brush)bc.ConvertFrom("#00FF0000"),
                        Height = 134,
                        Width = 880
                    };

                    var image = new Image
                    {
                        Height = 100,
                        Width = 100,
                        Source = new BitmapImage(new Uri("/Presentation/Images/streamlinehq-image-picture-landscape-1-images-photography-100.png", UriKind.Relative)),
                        Margin = new Thickness(20, 0, 0, 0)
                    };

                    var stackPanelInner1 = new StackPanel
                    {
                        Height = 100,
                        Width = 490,
                        Orientation = Orientation.Vertical
                    };

                    var textBlock1In1 = new TextBlock
                    {
                        Height = 34,
                        TextWrapping = TextWrapping.Wrap,
                        Text = Program.UserFeeds[i].Items[j].Title,
                        Width = 490,
                        FontSize = 20,
                        FontFamily = new FontFamily("Lucida Sans"),
                        VerticalAlignment = VerticalAlignment.Stretch,
                        Padding = new Thickness(20, 0, 0, 0),
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        TextTrimming = TextTrimming.WordEllipsis,
                    };

                    var textBlock2In1 = new TextBlock
                    {
                        Height = 60,
                        TextWrapping = TextWrapping.Wrap,
                        Text = Program.UserFeeds[i].Items[j].Summary,
                        Width = 490,
                        FontSize = 16,
                        FontFamily = new FontFamily("Lucida Sans"),
                        Padding = new Thickness(20, 0, 0, 0),
                        Margin = new Thickness(0, 6, 0, 0),
                        Foreground = (Brush)bc.ConvertFrom("#686868"),
                        TextTrimming = TextTrimming.WordEllipsis,
                    };

                    stackPanelInner1.Children.Add(textBlock1In1);
                    stackPanelInner1.Children.Add(textBlock2In1);

                    var stackPanelInner2 = new StackPanel
                    {
                        Height = 100,
                        Width = 225,
                        Margin = new Thickness(25, 0, 0, 0),
                        Orientation = Orientation.Vertical,
                    };

                    var textBlock1In2 = new TextBlock
                    {
                        TextWrapping = TextWrapping.Wrap,
                        Text = Program.UserFeeds[i].Items[j].PublishDate.Split(" ")[0],
                        HorizontalAlignment = HorizontalAlignment.Right,
                        FontSize = 16,
                        FontFamily = new FontFamily("Lucida Sans"),
                        FontWeight = FontWeights.Medium,
                        MaxWidth = 225,
                        Margin = new Thickness(0, 0, 0, 15),
                    };

                    var textBlock2In2 = new TextBlock
                    {
                        TextWrapping = TextWrapping.Wrap,
                        Text = Program.UserFeeds[i].Title.Split(">")[1],
                        HorizontalAlignment = HorizontalAlignment.Right,
                        FontSize = 16,
                        FontFamily = new FontFamily("Lucida Sans"),
                        FontWeight = FontWeights.Medium,
                        MaxWidth = 225,
                        Margin = new Thickness(0, 0, 0, 30),
                    };

                    var textBlock3In2 = new TextBlock
                    {
                        TextWrapping = TextWrapping.Wrap,
                        Text = Program.UserFeeds[i].Title.Split(">")[0],
                        HorizontalAlignment = HorizontalAlignment.Right,
                        FontSize = 16,
                        FontFamily = new FontFamily("Lucida Sans"),
                        FontWeight = FontWeights.Medium,
                        VerticalAlignment = VerticalAlignment.Bottom,
                    };

                    stackPanelInner2.Children.Add(textBlock1In2);
                    stackPanelInner2.Children.Add(textBlock2In2);
                    stackPanelInner2.Children.Add(textBlock3In2);


                    stackPanel.Children.Add(image);
                    stackPanel.Children.Add(stackPanelInner1);
                    stackPanel.Children.Add(stackPanelInner2);
                    feedItemBtn.Content = stackPanel;

                    feedItemBtn.Click += (ss, ee) =>
                    {
                        int index_i = Convert.ToInt32(feedItemBtn.Uid.Split("_")[0]);
                        int index_j = Convert.ToInt32(feedItemBtn.Uid.Split("_")[1]);
                        RSSNewsPageWindow news_page_window = new RSSNewsPageWindow(Program.UserFeeds[index_i], Program.UserFeeds[index_i].Items[index_j]);
                        news_page_window.Show();
                    };

                    this.followedItemsList.Children.Add(feedItemBtn);
                }
            }
        }
    }
}
