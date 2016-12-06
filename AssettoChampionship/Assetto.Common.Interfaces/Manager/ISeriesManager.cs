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
        IEnumerable<SeriesData> GetAvailableSeries();

        SeriesDTO GetSeries(Guid id);

    }
}
