// <copyright file="MainViewModel.cs" company="RSSCargo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RSS_Cargo.Presentation.MVVM.ViewModel
{
    using RSS_Cargo.Presentation.Core;

    /// <summary>
    /// Main view.
    /// </summary>
    public class MainViewModel : Core.Observable
    {
        private object? currentView;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
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

        /// <summary>
        /// Gets or sets home.
        /// </summary>
        public Core.RelayCommand HomeViewComand { get; set; }

        /// <summary>
        /// Gets or sets followd.
        /// </summary>
        public Core.RelayCommand FeedsFollowedComand { get; set; }

        /// <summary>
        /// Gets or sets cargos followed new.
        /// </summary>
        public Core.RelayCommand CargosFollowNewCommand { get; set; }

        /// <summary>
        /// Gets or sets cargos followed.
        /// </summary>
        public Core.RelayCommand CargosFollowedCommand { get; set; }

        /// <summary>
        /// Gets or sets new.
        /// </summary>
        public Core.RelayCommand NewsPageCommand { get; set; }

        /// <summary>
        /// Gets or sets home.
        /// </summary>
        public RSSHomeViewModel HomeVM { get; set; }

        /// <summary>
        /// Gets or sets feeds.
        /// </summary>
        public RSSFeedsFollowedViewModel FeedsFollowedVM { get; set; }

        /// <summary>
        /// Gets or sets cargo feeds.
        /// </summary>
        public RSSCargosFollowNewViewModel CargosFollowNewVM { get; set; }

        /// <summary>
        /// Gets or sets cargo followed.
        /// </summary>
        public RSSCargosFollowedViewModel CargosFollowedVM { get; set; }

        /// <summary>
        /// Gets or sets news.
        /// </summary>
        public RSSNewsPageViewModel NewsPageVM { get; set; }

        /// <summary>
        /// Gets or sets vews.
        /// </summary>
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
