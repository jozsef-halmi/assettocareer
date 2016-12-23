using Assetto.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.Interfaces.Service
{
    public interface ISeriesService
    {
        IEnumerable<SeriesData> GetAvailableSeries();

        SeriesData GetSeries(string seriesId);
        EventData GetEvent(string seriesId, string eventId);
        SessionData GetSession(string seriesId, string eventId, string sessionId);
        string GetFriendlySkinNameForOpponent(string sessionId, string eventId, string playerName);
        string GetFriendlySkinNameForPlayer(string sessionId, string eventId);
        string GetFriendlyCarNameForOpponent(string sessionId, string eventId, string playerName);
        string GetFriendlyCarNameForPlayer(string sessionId, string eventId);
        int GetSessionIndex(string seriesId, string eventId, string sessionId);
        int GetEventIndex(string seriesId, string eventId);
    }
}
