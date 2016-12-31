using Assetto.Common.Data;
using Assetto.Common.Interfaces.Service;
using Assetto.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Service
{
    public class SeriesService : ISeriesService
    {
        public IEnumerable<SeriesData> GetAvailableSeries()
        {
            return SupportedSeries.GetAvailableSeries();
        }

        public SeriesData GetSeries(string seriesId)
        {
            return this.GetAvailableSeries().FirstOrDefault(series => series.Id == seriesId);
         
        }

        public EventData GetEvent(string seriesId, string eventId) {
            return this.GetSeries(seriesId).Events.FirstOrDefault(e => e.Id == eventId);
        }

        public SessionData GetSession(string seriesId, string eventId, string sessionId)
        {
            return this.GetEvent(seriesId, eventId).CareerSessions.FirstOrDefault(s => s.Id == sessionId);
            //return this.GetAvailableSeries().FirstOrDefault(series => series.Id == seriesId)
            //    .Events.FirstOrDefault(e => e.Id == eventId)
            //    .CareerSessions.FirstOrDefault(s => s.Id == sessionId);
        }


        public string GetFriendlySkinNameForOpponent(string sessionId, string eventId, string playerName)
        {
            return this.GetEvent(sessionId, eventId).Opponents.FirstOrDefault(p => p.Name == playerName).Skin.FriendlyName;
        }

        public string GetFriendlySkinNameForPlayer(string sessionId, string eventId)
        {
            return this.GetEvent(sessionId, eventId).Player.Skin.FriendlyName;
        }

        public string GetFriendlyCarNameForOpponent(string sessionId, string eventId, string playerName)
        {
            return this.GetEvent(sessionId, eventId).Opponents.FirstOrDefault(p => p.Name == playerName).Car.FriendlyName;
        }

        public string GetFriendlyCarNameForPlayer(string sessionId, string eventId)
        {
            return this.GetEvent(sessionId, eventId).Player.Car.FriendlyName;
        }

        public int GetSessionIndex(string seriesId, string eventId, string sessionId)
        {
            var selectedEvent = GetSeries(seriesId).Events.FirstOrDefault(e => e.Id == eventId);
            return selectedEvent.CareerSessions.IndexOf(
                    selectedEvent.CareerSessions.FirstOrDefault(s => s.Id == sessionId)
                    ) + 1;
        }

        public int GetEventIndex(string seriesId, string eventId)
        {
            var selectedSeries = GetSeries(seriesId);
            var selectedEvent = GetSeries(seriesId).Events.FirstOrDefault(e => e.Id == eventId);
            return selectedSeries.Events.IndexOf(selectedEvent) + 1;
        }
    }
}
