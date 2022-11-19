using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RSS_Cargo.Presentation.MVVM.View
{
    /// <summary>
    /// Interaction logic for RSSNewsPageWindow.xaml
    /// </summary>
    public partial class RSSNewsPageWindow : Window
    {
        public RSSNewsPageWindow(BLL.RssFeed userFeed, BLL.RssFeedItem item)
        {
            InitializeComponent();

            var bc = new BrushConverter();

            var textBlock1 = new TextBlock
            {
                TextWrapping = TextWrapping.Wrap,
                HorizontalAlignment = HorizontalAlignment.Center,
                Height = 75,
                VerticalAlignment = VerticalAlignment.Center,
                Width = 603,
                Background = (Brush)bc.ConvertFrom("#FFF6F6F6"),
                Text = item.Title,
                FontFamily = new FontFamily("Lucida Sans"),
                FontSize = 20,
                IsEnabled = false,
            };

            var stackPanel1 = new StackPanel
            {
                Margin = new Thickness(30, 22, 31, 10),
                Orientation = Orientation.Vertical,
            };
            Grid.SetColumn(stackPanel1, 1);

            var textBlock1InSP1 = new TextBlock
            {
                TextWrapping = TextWrapping.Wrap,
                Text = item.PublishDate.Split(" ")[0],
                HorizontalAlignment = HorizontalAlignment.Right,
                FontSize = 16,
                FontFamily = new FontFamily("Lucida Sans"),
                FontWeight = FontWeights.Medium,
                MaxWidth = 225,
                Margin = new Thickness(0, 0, 0, 10),
            };

            var textBlock2InSP1 = new TextBlock
            {
                TextWrapping = TextWrapping.Wrap,
                Text = userFeed.Title.Split(">")[1],
                HorizontalAlignment = HorizontalAlignment.Right,
                FontSize = 16,
                FontFamily = new FontFamily("Lucida Sans"),
                FontWeight = FontWeights.Medium,
                MaxWidth = 225,
                Margin = new Thickness(0, 0, 0, 10),
            };

            var textBlock3InSP1 = new TextBlock
            {
                TextWrapping = TextWrapping.Wrap,
                Text = userFeed.Title.Split(">")[0],
                HorizontalAlignment = HorizontalAlignment.Right,
                FontSize = 16,
                FontFamily = new FontFamily("Lucida Sans"),
                FontWeight = FontWeights.Medium,
                VerticalAlignment = VerticalAlignment.Bottom,
            };

            stackPanel1.Children.Add(textBlock1InSP1);
            stackPanel1.Children.Add(textBlock2InSP1);
            stackPanel1.Children.Add(textBlock3InSP1);

            var border1 = new Border
            {
                Height = 1,
                BorderBrush = (Brush)bc.ConvertFrom("#000000"),
                BorderThickness = new Thickness(5),
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Top,
            };
            Grid.SetRow(border1, 1);
            Grid.SetColumn(border1, 0);

            var textBlockContent = new TextBlock
            {
                Background = (Brush)bc.ConvertFrom("#F6F6F6"),
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(34, 48, 0, 0),
                TextWrapping = TextWrapping.Wrap,
                VerticalAlignment = VerticalAlignment.Top,
                Width = 830,
                FontFamily = new FontFamily("Lucida Sans"),
                FontSize = 16,
                IsEnabled = false,
                TextAlignment = TextAlignment.Justify,
                Text = item.Summary + Environment.NewLine + item.Content + Environment.NewLine + "Read More On The Website: " + Environment.NewLine + item.Links[0].Item2,
            };
            Grid.SetColumnSpan(textBlockContent, 2);
            Grid.SetRow(textBlockContent, 1);

            newsPageList.Children.Add(textBlock1);
            newsPageList.Children.Add(stackPanel1);
            newsPageList.Children.Add(border1);
            newsPageList.Children.Add(textBlockContent);
        }
    }
}
