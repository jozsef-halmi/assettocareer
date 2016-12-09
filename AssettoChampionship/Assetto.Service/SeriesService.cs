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
            return new List<SeriesData>() {
                SupportedSeries.AbarthRaceSeries
            };
        }

        public SeriesData GetSeries(Guid seriesId)
        {
            return this.GetAvailableSeries().FirstOrDefault(series => series.Id == seriesId);
         
        }

        public EventData GetEvent(Guid seriesId, Guid eventId) {
            return this.GetSeries(seriesId).Events.FirstOrDefault(e => e.Id == eventId);
        }

        public SessionData GetSession(Guid seriesId, Guid eventId, Guid sessionId)
        {
            return this.GetEvent(seriesId, eventId).CareerSessions.FirstOrDefault(s => s.Id == sessionId);
            //return this.GetAvailableSeries().FirstOrDefault(series => series.Id == seriesId)
            //    .Events.FirstOrDefault(e => e.Id == eventId)
            //    .CareerSessions.FirstOrDefault(s => s.Id == sessionId);
        }
    }
}
