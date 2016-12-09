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

namespace AssettoChampionship.ViewModels
{
    public class SeriesViewModel : PropertyChangedBase
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
            this.AvailableSeries = new BindableCollection<SeriesDTO>(SeriesManager.GetAvailableSeries());

        }

        public void SeriesSelected(Guid seriesId)
        {
            this.EventAggregator.Publish(new ChangePageMessage(typeof(EventsViewModel), new ChangePageParameters()
            {
                SelectedSeriesId = seriesId
            }), action => { Task.Factory.StartNew(action); });



            //var series = this.AvailableSeries.Select(s => s.SeriesData).Where(s => s.Id == seriesId).FirstOrDefault();
            //if (series != null)
            //{
            //    this.EventAggregator.Publish(new ChangePageMessage(typeof(EventsViewModel), new ChangePageParameters()
            //    {
            //        SeriesData = series
            //    }), action => { Task.Factory.StartNew(action); });
            //}
        }
    }

}
