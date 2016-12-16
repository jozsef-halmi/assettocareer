using Assetto.Common.Data;
using Assetto.Common.Framework;
using Assetto.Common.Interfaces.Manager;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.DTO;
using Assetto.Common.Interfaces.Service;
using AssettoChampionship.Utils;

namespace AssettoChampionship.ViewModels
{
    public class SeriesViewModel : Screen
    {
        // Databinded objects
        public BindableCollection<SeriesDTO> AvailableSeries { get; set; }

        // Managers
        public ISeriesManager SeriesManager { get; set; }
        public IEventManager EventManager { get; set; }
        public IEventAggregator EventAggregator { get; set; }

        public ILogService LogService { get; set; }


        public SeriesViewModel(ISeriesManager seriesManager
            , IEventManager eventManager
            , IEventAggregator eventAggregator
            , ILogService logService)
        {
            this.EventManager = eventManager;
            this.SeriesManager = seriesManager;
            this.EventAggregator = eventAggregator;
            this.LogService = logService;
        }

        public void SeriesSelected(Guid seriesId)
        {
            try
            {
                var series = this.AvailableSeries.FirstOrDefault(s => s.SeriesId == seriesId);
                if (series.IsAvailable || AppConfigService.IsDebugMode())
                {
                    this.EventAggregator.Publish(new ChangePageMessage(typeof(EventsViewModel), new ChangePageParameters()
                    {
                        SelectedSeriesId = seriesId
                    }), action => { Task.Factory.StartNew(action); });
                }
            }
            catch (Exception ex)
            {
                LogService.Error($"Error while selecting series, id: {seriesId}, exception: {ex}");
            }
           
        }

        private void RefreshData() {
            this.AvailableSeries = new BindableCollection<SeriesDTO>(SeriesManager.GetAvailableSeries());
        }

        protected override void OnActivate()
        {
            RefreshData();
            base.OnActivate();
        }
    }

}
