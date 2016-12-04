using Assetto.Common.Data;
using Assetto.Common.Framework;
using Assetto.Common.Interfaces.Manager;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssettoChampionship.ViewModels
{
    public class SeriesViewModel : PropertyChangedBase
    {
        // Databinded objects
        public BindableCollection<SeriesData> AvailableSeries { get; set; }

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
            this.AvailableSeries = new BindableCollection<SeriesData>(SeriesManager.GetAvailableSeries());

        }

        public void SeriesSelected(Guid seriesId)
        {
            var series = this.AvailableSeries.Where(s => s.Id == seriesId).FirstOrDefault();
            if (series != null)
            {
                this.EventAggregator.Publish(new ChangePageMessage(typeof(EventsViewModel), new ChangePageParameters()
                {
                    Parameter = series
                }), action => { Task.Factory.StartNew(action); });
            }
            //var seriesData = AvailableSeries.First();
            //var eventData = seriesData.Events.First();


          
            //this.EventManager.StartEvent(eventData);

            //EventAggregator.Publish(new ChangePageMessage(typeof(SeriesViewModel), new ChangePageParameters())
            //    , action =>
            //    {
            //        Task.Factory.StartNew(action);
            //    });
        }   
    }

}
