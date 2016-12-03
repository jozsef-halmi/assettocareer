using Assetto.Common.Data;
using Assetto.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Interfaces.Manager;
using Assetto.Configurator;

namespace Assetto.Manager
{
    public class SeriesManager : ISeriesManager
    {
        public IEnumerable<SeriesData> GetAvailableSeries() {
            return new List<SeriesData>() {
                SupportedSeries.AbarthRaceSeries
            };
        }

        public void StartEvent(EventData eventData)
        {
            var eventConfig = new EventConfig(eventData);
            var str = eventConfig.ToString();
            var a = 5;
        }

    }
}
