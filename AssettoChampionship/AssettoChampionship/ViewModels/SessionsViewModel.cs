using Assetto.Common.Data;
using Assetto.Common.Interfaces.Manager;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssettoChampionship.ViewModels
{
    public class SessionsViewModel : PropertyChangedBase
    {
        public EventData Event { get; set; }

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

        public SessionsViewModel(IEventAggregator eventAggregator
             , IEventManager eventManager)
        {
            this.EventAggregator = eventAggregator;
            this.EventManager = eventManager;

        }

        public void SetEvent(EventData selectedEvent)
        {
            this.Event = selectedEvent;
            this.Sessions = new BindableCollection<SessionData>(selectedEvent.CareerSessions);
        }

        public void SessionSelected(Guid eventId)
        {
            var selectedSession = this.Sessions.Where(e => e.Id == eventId).FirstOrDefault();
            if (selectedSession != null)
            {
                EventManager.StartEvent(this.Event, selectedSession);
            }
        }


    }
}
