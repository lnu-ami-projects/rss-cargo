using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSS_Cargo.Presentation.Core;

namespace RSS_Cargo.Presentation.MVVM.ViewModel
{
    public class MainViewModel : Core.Observable
    {
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

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value; 
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVM = new RSSHomeViewModel();
            FeedsFollowedVM = new RSSFeedsFollowedViewModel();
            CargosFollowNewVM = new RSSCargosFollowNewViewModel();
            CargosFollowedVM = new RSSCargosFollowedViewModel();
            NewsPageVM = new RSSNewsPageViewModel();

            CurrentView = HomeVM;

            HomeViewComand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            FeedsFollowedComand = new RelayCommand(o =>
            {
                CurrentView = FeedsFollowedVM;
            });

            CargosFollowNewCommand = new RelayCommand(o =>
            {
                CurrentView = CargosFollowNewVM;
            });

            CargosFollowedCommand = new RelayCommand(o =>
            {
                CurrentView = CargosFollowedVM;
            });

            NewsPageCommand = new RelayCommand(o =>
            {
                CurrentView = NewsPageVM;
            });
        }
    }
}
