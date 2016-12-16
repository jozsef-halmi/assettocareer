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


        public SeriesViewModel(ISeriesManager seriesManager
             , IEventManager eventManager
             , IEventAggregator eventAggregator)
        {
            this.EventManager = eventManager;
            this.SeriesManager = seriesManager;
            this.EventAggregator = eventAggregator;

        }

        public void SeriesSelected(Guid seriesId)
        {
            var series = this.AvailableSeries.FirstOrDefault(s => s.SeriesId == seriesId);
            if (series.IsAvailable || AppConfigService.IsDebugMode()) { 
                this.EventAggregator.Publish(new ChangePageMessage(typeof(EventsViewModel), new ChangePageParameters()
                {
                    SelectedSeriesId = seriesId
                }), action => { Task.Factory.StartNew(action); });
            }
        }

        private void RefreshData() {
            this.AvailableSeries = new BindableCollection<SeriesDTO>(SeriesManager.GetAvailableSeries());
        }

        protected override void OnActivate()
        {
            RefreshData();
            // TODO: refresh elements
            base.OnActivate();
        }
    }

}
