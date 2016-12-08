using Assetto.Common.Data;
using Assetto.Common.Framework;
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

        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyOfPropertyChange(() => Title);
            }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                NotifyOfPropertyChange(() => Description);
            }
        }

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
            this.Title = series.FriendlyName;
            this.Description = series.Description;
        }

        public void EventSelected(Guid eventId)
        {
            var selectedEvent = this.Events.Where(e => e.Id == eventId).FirstOrDefault();
            if (selectedEvent != null)
            {
                this.EventAggregator.Publish(new ChangePageMessage(typeof(SessionsViewModel), new ChangePageParameters()
                {
                    SeriesData = this.Series,
                    EventData = selectedEvent
                }), action => { Task.Factory.StartNew(action); });
            }
        }


    }
}
