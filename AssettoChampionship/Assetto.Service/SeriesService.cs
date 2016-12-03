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
    }
}
