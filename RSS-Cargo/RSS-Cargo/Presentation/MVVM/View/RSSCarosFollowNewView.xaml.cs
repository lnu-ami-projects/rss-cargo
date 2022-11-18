// <copyright file="RSSCarosFollowNewView.xaml.cs" company="RSSCargo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RSS_Cargo.Presentation.MVVM.View
{
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using static System.Net.Mime.MediaTypeNames;

    /// <summary>
    /// Interaction logic for RSSCarosFollowNewView.xaml.
    /// </summary>
    public partial class RSSCarosFollowNewView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RSSCarosFollowNewView"/> class.
        /// </summary>
        public RSSCarosFollowNewView()
        {
            this.InitializeComponent();

            //< StackPanel Background = "#FFF6F6F6" HorizontalAlignment = "Center" Height = "270" VerticalAlignment = "Center" Width = "279" >
            //    < TextBox BorderThickness = "0" Height = "60" TextWrapping = "Wrap" Text = "Cargo Title 1" Width = "279" HorizontalContentAlignment = "Center" VerticalContentAlignment = "Center" FontSize = "20" FontFamily = "Lucida Sans" FontWeight = "Normal" Background = "#FFF6F6F6" />
            //    < ListView BorderThickness = "0" Height = "120" Width = "279" d: ItemsSource = "{d:SampleData ItemCount=5}" BorderBrush = "White" Foreground = "Black" FontFamily = "Lucida Sans" FontSize = "16" HorizontalContentAlignment = "Left" Padding = "20,0,0,0" Background = "#FFF6F6F6" >
            //        < ListView.Resources >
            //            < Style TargetType = "{x:Type GridViewColumnHeader}" >
            //                < Setter Property = "Visibility" Value = "Collapsed" />
            //            </ Style >
            //        </ ListView.Resources >
            //        < ListView.View >
            //            < GridView >
            //                < GridViewColumn Width = "250" />
            //            </ GridView >
            //        </ ListView.View >
            //    </ ListView >
            //    < Button Height = "34" Width = "230" VerticalContentAlignment = "Center" VerticalAlignment = "Stretch" Margin = "0,35,0,0" BorderBrush = "Black" Background = "White" HorizontalAlignment = "Center" HorizontalContentAlignment = "Left" Style = "{StaticResource ContentControlButtonTheme}" >
            //        < StackPanel Orientation = "Horizontal" HorizontalAlignment = "Left" VerticalAlignment = "Stretch" Margin = "15,0,0,0" >
            //            < TextBlock Height = "25" TextWrapping = "Wrap" Text = "Follow" Width = "150" HorizontalAlignment = "Stretch" VerticalAlignment = "Stretch" FontSize = "16" FontFamily = "Lucida Sans" Background = "Transparent" IsEnabled = "False" Padding = "0,3,0,0" />
            //            < Image Source = "/Presentation/Images/streamlinehq-interface-add-1-interface-essential-30.png" Height = "22" Width = "28" HorizontalAlignment = "Stretch" Margin = "25,0,0,0" ></ Image >
            //        </ StackPanel >
            //    </ Button >
            //</ StackPanel >


            var cargos = Program.Cargos!.ToArray();
            Program.Log.Info($"Got {cargos.Length} cargos");

            var rows = (int)Math.Ceiling(cargos.Length / 3.0);
            Program.Log.Debug($"Added {rows} cargo rows");

            for (int i = 0; i < rows; i++)
            {
                this.cargosNewGrid.RowDefinitions.Add(new RowDefinition { 
                    Height = new GridLength(300),
                });
            }

            for (int i = 0; i < cargos.Length; i++) {
                var cargo = cargos[i];

                var cargoStack = new StackPanel();

                var cargoName = new TextBlock
                {
                    Text = cargo.Name,
                };
                cargoStack.Children.Add(cargoName);


                var feedList = new ListBox
                {
                    Height = 220,
                };

                foreach (var feed in Program.CargoFeeds![cargo.Id])
                {
                    var feedName = new TextBlock
                    {
                        Text = feed.Title,
                    };
                    feedList.Items.Add(feedName);
                }

                cargoStack.Children.Add(feedList);

                var addBtn = new Button
                {
                    Content = "Follow",
                };

                addBtn.Click += (s, e) =>
                {
                    if (!Program.UserCargos!.Contains(cargo))
                    {
                        Program.UserCargos!.Add(cargo);
                        Program.DB!.UserCargos.Add(new RSS_cargo.DAL.Models.UserCargo {
                            UserId = Program.LoggedUser!.Id,
                            CargoId = cargo.Id,
                        });
                        Program.DB.SaveChanges();

                        var tb = new TextBlock
                        {
                            Text = cargo.Name,
                            FontSize = 16,
                            TextTrimming = TextTrimming.CharacterEllipsis,
                        };

                        Program.MainW!.cargosList.Children.Add(tb);
                    }
                };

                cargoStack.Children.Add(addBtn);

                Grid.SetRow(cargoStack, i / 3);
                Grid.SetColumn(cargoStack, i % 3);

                this.cargosNewGrid.Children.Add(cargoStack);
            }
        }
    }
}
