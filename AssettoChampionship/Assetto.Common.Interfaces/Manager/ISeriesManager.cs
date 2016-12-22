using Assetto.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.DTO;

namespace Assetto.Common.Interfaces.Manager
{
    public interface ISeriesManager
    {
        List<SeriesDTO> GetAvailableSeries();

        SeriesDTO GetSeries(string id);

        EventDTO GetEvent(string seriesId, string eventId);
        SessionDTO GetSession(string seriesId, string eventId, string sessionId);
        SessionDTO GetNextSession(string seriesId);


    }
}
