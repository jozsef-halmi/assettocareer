using Assetto.Common.Data;
using Assetto.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Interfaces.Manager;

namespace Assetto.Manager
{
    public class SeriesManager : ISeriesManager
    {
        public IEnumerable<SeriesData> GetAvailableSeries() {
            return new List<SeriesData>() {
                SupportedSeries.AbarthRaceSeries
            };
        }

    }
}
