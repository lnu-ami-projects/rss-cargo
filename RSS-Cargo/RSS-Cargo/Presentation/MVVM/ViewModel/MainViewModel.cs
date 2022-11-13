// <copyright file="MainViewModel.cs" company="RSSCargo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RSS_Cargo.Presentation.MVVM.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using RSS_Cargo.Presentation.Core;

    public class MainViewModel : Core.Observable
    {
        private object? currentView;

        public MainViewModel()
        {
            this.HomeVM = new RSSHomeViewModel();
            this.FeedsFollowedVM = new RSSFeedsFollowedViewModel();
            this.CargosFollowNewVM = new RSSCargosFollowNewViewModel();
            this.CargosFollowedVM = new RSSCargosFollowedViewModel();
            this.NewsPageVM = new RSSNewsPageViewModel();

            this.CurrentView = this.HomeVM;

            this.HomeViewComand = new RelayCommand(o =>
            {
                this.CurrentView = this.HomeVM;
            });

            this.FeedsFollowedComand = new RelayCommand(o =>
            {
                this.CurrentView = this.FeedsFollowedVM;
            });

            this.CargosFollowNewCommand = new RelayCommand(o =>
            {
                this.CurrentView = this.CargosFollowNewVM;
            });

            this.CargosFollowedCommand = new RelayCommand(o =>
            {
                this.CurrentView = this.CargosFollowedVM;
            });

            this.NewsPageCommand = new RelayCommand(o =>
            {
                this.CurrentView = this.NewsPageVM;
            });
        }

        public Core.RelayCommand HomeViewComand { get; set; }

        public Core.RelayCommand FeedsFollowedComand { get; set; }

        public Core.RelayCommand CargosFollowNewCommand { get; set; }

        public Core.RelayCommand CargosFollowedCommand { get; set; }

        public Core.RelayCommand NewsPageCommand { get; set; }

        public RSSHomeViewModel HomeVM { get; set; }

        public RSSFeedsFollowedViewModel FeedsFollowedVM { get; set; }

        public RSSCargosFollowNewViewModel CargosFollowNewVM { get; set; }

        public RSSCargosFollowedViewModel CargosFollowedVM { get; set; }

        public RSSNewsPageViewModel NewsPageVM { get; set; }

        public object CurrentView
        {
            get
            {
                return this.currentView!;
            }

            set
            {
                this.currentView = value;
                this.OnPropertyChanged();
            }
        }
    }
}
