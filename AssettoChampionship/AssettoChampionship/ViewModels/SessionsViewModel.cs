using Assetto.Common.Data;
using Assetto.Common.Interfaces.Manager;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.DTO;
using Assetto.Common.Interfaces.Service;
using Assetto.Service;
using AssettoChampionship.Utils;

namespace AssettoChampionship.ViewModels
{
    public class SessionsViewModel : Screen
    {
        public EventDTO Event { get; set; }

        //private BindableCollection<SessionData> _sessions { get; set; }
        //public BindableCollection<SessionData> Sessions
        //{
        //    get { return _sessions; }
        //    set
        //    {
        //        _sessions = value;
        //        NotifyOfPropertyChange(() => Sessions);
        //    }
        //}

        public IEventAggregator EventAggregator { get; set; }
        public IEventManager EventManager { get; set; }
        public ISeriesManager SeriesManager { get; set; }
        public ILogService LogService { get; set; }



        public SessionsViewModel(IEventAggregator eventAggregator
            , IEventManager eventManager
            , ISeriesManager seriesManager
            , ILogService logService)
        {
            this.EventAggregator = eventAggregator;
            this.EventManager = eventManager;
            this.SeriesManager = seriesManager;
            this.LogService = logService;
        }


        public void SetEvent(Guid seriesId, Guid eventId)
        {
            this.Event = SeriesManager.GetEvent(seriesId, eventId);
        }

        public void SessionSelected(Guid sessionId)
        {
            try
            {
                if (this.Event.Sessions.FirstOrDefault(s => s.SessionId == sessionId).IsAvailable 
                    || AppConfigService.IsDebugMode())
                {
                    EventManager.StartEvent(this.Event.SeriesId, this.Event.EventId, sessionId);
                }
            }
            catch (Exception ex)
            {
                LogService.Error($"Error while selecting session, id: {sessionId}, exception: {ex}");
            }
        }
    }
}
