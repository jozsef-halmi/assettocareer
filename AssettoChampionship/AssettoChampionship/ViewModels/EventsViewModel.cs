using Assetto.Common.Data;
using Assetto.Common.Framework;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.DTO;
using Assetto.Common.Interfaces.Manager;
using Assetto.Common.Interfaces.Service;
using Assetto.Service;
using AssettoChampionship.Utils;
using AssettoChampionship.ViewModels.Dialog;

namespace AssettoChampionship.ViewModels
{
    public class EventsViewModel : Screen
    {
        #region Properties

        private string _selectedSeriesId;

        private SeriesDTO _series;

        public SeriesDTO Series
        {
            get { return _series; }
            set
            {
                _series = value;
                NotifyOfPropertyChange(() => Series);
            }
        }

        #endregion

        #region BindedProperties

        private BindableCollection<EventData> _events { get; set; }

        public BindableCollection<EventData> Events
        {
            get { return _events; }
            set
            {
                _events = value;
                NotifyOfPropertyChange(() => Events);
            }
        }

        #endregion

        #region Injected

        // Managers
        public IEventAggregator EventAggregator { get; set; }
        public ISeriesManager SeriesManager { get; set; }
        public IEventManager EventManager { get; set; }
        public ILogService LogService { get; set; }


        #endregion

        public EventsViewModel(IEventAggregator eventAggregator
            , ISeriesManager seriesManager
            , IEventManager eventManager
            , ILogService logService)
        {
            this.EventAggregator = eventAggregator;
            this.SeriesManager = seriesManager;
            this.EventManager = eventManager;
            this.LogService = logService;
        }

        public void SetSeries(string seriesId)
        {
            this.Series = SeriesManager.GetSeries(seriesId);
            this._selectedSeriesId = seriesId;

        }

        public void EventSelected(string eventId)
        {
            try
            {
                if (this.Series.Events.FirstOrDefault(e => e.EventId == eventId).IsAvailable || AppConfigService.IsDebugMode())
                {
                    this.EventAggregator.Publish(new ChangePageMessage(typeof(SessionsViewModel), new ChangePageParameters()
                    {
                        SelectedSeriesId = this.Series.SeriesId,
                        SelectedEventId = eventId
                    }), action => { Task.Factory.StartNew(action); });
                }
            }
            catch (Exception ex)
            {
                LogService.Error($"Error while selecting event, id: {eventId}, exception: {ex}");
            }
           
        }

        protected override void OnActivate()
        {
            RefreshData();
            base.OnActivate();
            if (!Series.IsStarted && !EventManager.IsVideoAlreadyWatched(Series.Video.Url))
            {
                EventManager.VideoWatched(Series.Video.Url);
                OpenVideo();
            }
        }

        private void RefreshData()
        {
            this.Series = SeriesManager.GetSeries(this._selectedSeriesId);
        }

        public void OpenVideo() {
            //this.EventAggregator.Publish(new ChangePageMessage(typeof(VideoViewModel), new ChangePageParameters()
            //{
            //    Parameter = this.Series.VideoUrl
            //}), action => { Task.Factory.StartNew(action); });
        }

    }
}
