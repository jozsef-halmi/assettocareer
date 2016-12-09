using Assetto.Common.Data;
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
    public class SessionsViewModel : PropertyChangedBase
    {
        //public EventData Event { get; set; }
        //public SeriesData Series { get; set; }

        public EventDTO Event { get; set; }

        private BindableCollection<SessionData> _sessions { get; set; }
        public BindableCollection<SessionData> Sessions
        {
            get { return _sessions; }
            set
            {
                _sessions = value;
                NotifyOfPropertyChange(() => Sessions);
            }
        }

        public IEventAggregator EventAggregator { get; set; }
        public IEventManager EventManager { get; set; }
        public ISeriesManager SeriesManager { get; set; }


        public SessionsViewModel(IEventAggregator eventAggregator
             , IEventManager eventManager
            , ISeriesManager seriesManager)
        {
            this.EventAggregator = eventAggregator;
            this.EventManager = eventManager;
            this.SeriesManager = seriesManager;
        }

        //public void SetEvent(SeriesData seriesData, EventData selectedEvent)
        //{
        //    this.Series = seriesData;
        //    this.Event = selectedEvent;
        //    this.Sessions = new BindableCollection<SessionData>(selectedEvent.CareerSessions);
        //}

        public void SetEvent(Guid seriesId, Guid eventId)
        {
            this.Event = SeriesManager.GetEvent(seriesId, eventId);
            //this.Series = seriesData;
            //this.Event = selectedEvent;
            //this.Sessions = new BindableCollection<SessionData>(selectedEvent.CareerSessions);
        }

        public void SessionSelected(Guid eventId)
        {
            //var selectedSession = this.Sessions.Where(e => e.Id == eventId).FirstOrDefault();
            //if (selectedSession != null)
            //{
            //    EventManager.StartEvent(this.Series, this.Event, selectedSession);
            //}
        }
    }
}
