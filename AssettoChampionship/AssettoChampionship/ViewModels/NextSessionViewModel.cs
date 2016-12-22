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

        private PathDTO _path;
        #endregion

        // Managers
        public IEventAggregator EventAggregator { get; set; }
        public IEventManager EventManager { get; set; }
        public IPathManager PathManager { get; set; }
        public ISeriesManager SeriesManager { get; set; }

        public NextSessionViewModel(
            IEventAggregator eventAggregator
            , IEventManager eventManager
            , IPathManager pathManager
            , ISeriesManager seriesManager)
        {
            this.EventAggregator = eventAggregator;
            this.EventManager = eventManager;
            this.PathManager = pathManager;
            this.SeriesManager = seriesManager;
        }

        public void SetPath(string pathId)
        {
            _path = PathManager.GetPath(pathId);
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            this.NextSession = PathManager.GetNextSession(_path.PathId);
            this.CurrentSeries = PathManager.GetNextSeries(_path.PathId);
        }
    }
}
