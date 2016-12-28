using Assetto.Common.Data;
using Assetto.Common.DTO;
using Assetto.Common.Framework;
using Assetto.Common.Interfaces.Manager;
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

        public NextSessionViewModel(
            IEventAggregator eventAggregator
            , IEventManager eventManager
            , IPathManager pathManager
            , ISeriesManager seriesManager
            , IConfigManager configManager)
        {
            this.EventAggregator = eventAggregator;
            this.EventManager = eventManager;
            this.PathManager = pathManager;
            this.SeriesManager = seriesManager;
            this.ConfigManager = configManager;
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            string path = ConfigManager.GetSelectedPathId();
            this.NextSession = PathManager.GetNextSession(path);
            this.CurrentSeries = PathManager.GetNextSeries(path);

        }
    }
}
