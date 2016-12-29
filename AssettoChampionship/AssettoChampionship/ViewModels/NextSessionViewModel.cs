using Assetto.Common.Data;
using Assetto.Common.DTO;
using Assetto.Common.Framework;
using Assetto.Common.Interfaces.Manager;
using AssettoChampionship.Services;
using Caliburn.Micro;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AssettoChampionship.ViewModels
{
    public class NextSessionViewModel : Screen
    {
        #region Data
        private SessionDTO _nextSession;

        public SessionDTO NextSession
        {
            get { return _nextSession; }
            set
            {
                _nextSession = value;
                NotifyOfPropertyChange(() => NextSession);
            }
        }

        private SeriesDTO _currentSeries;

        public SeriesDTO CurrentSeries
        {
            get { return _currentSeries; }
            set
            {
                _currentSeries = value;
                NotifyOfPropertyChange(() => CurrentSeries);
            }
        }

        #endregion

        // Managers
        public IEventAggregator EventAggregator { get; set; }
        public IEventManager EventManager { get; set; }
        public IPathManager PathManager { get; set; }
        public ISeriesManager SeriesManager { get; set; }
        private IConfigManager ConfigManager { get; set; }
        private INavigationService NavigationService { get; set; }

        public NextSessionViewModel(
            IEventAggregator eventAggregator
            , IEventManager eventManager
            , IPathManager pathManager
            , ISeriesManager seriesManager
            , IConfigManager configManager
            , INavigationService navigationService)
        {
            this.EventAggregator = eventAggregator;
            this.EventManager = eventManager;
            this.PathManager = pathManager;
            this.SeriesManager = seriesManager;
            this.ConfigManager = configManager;
            this.NavigationService = navigationService;
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            string path = ConfigManager.GetSelectedPathId();
            this.NextSession = PathManager.GetCurrentSession(path);
            this.CurrentSeries = PathManager.GetCurrentSeries(path);
            if (!CurrentSeries.IsStarted && !EventManager.IsVideoAlreadyWatched(CurrentSeries.VideoUrl))
            {
                EventManager.VideoWatched(CurrentSeries.VideoUrl);
                NavigationService.ShowVideo(CurrentSeries.VideoUrl);
            }
        }

        public void StartSession() {
            EventManager.StartEvent(this.NextSession.SeriesId, this.NextSession.EventId, this.NextSession.SessionId);
        }
    }
}
