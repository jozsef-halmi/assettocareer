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

        SeriesData GetSeries(Guid seriesId);
        EventData GetEvent(Guid seriesId, Guid eventId);
        SessionData GetSession(Guid seriesId, Guid eventId, Guid sessionId);
        string GetFriendlySkinNameForOpponent(Guid sessionId, Guid eventId, string playerName);
        string GetFriendlySkinNameForPlayer(Guid sessionId, Guid eventId);
        string GetFriendlyCarNameForOpponent(Guid sessionId, Guid eventId, string playerName);
        string GetFriendlyCarNameForPlayer(Guid sessionId, Guid eventId);
    }
}
