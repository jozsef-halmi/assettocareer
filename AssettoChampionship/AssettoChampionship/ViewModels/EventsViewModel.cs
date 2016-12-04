using Assetto.Common.Data;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssettoChampionship.ViewModels
{
    public class EventsViewModel : PropertyChangedBase
    {
        public SeriesData Series { get; set; }
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

        // Managers
        public IEventAggregator EventAggregator { get; set; }

        public EventsViewModel(IEventAggregator eventAggregator)
        {
            this.EventAggregator = eventAggregator;
        }

        public void SetSeries(SeriesData series) {
            this.Series = series;
            this.Events = new BindableCollection<EventData>(series.Events);
        }


    }
}
