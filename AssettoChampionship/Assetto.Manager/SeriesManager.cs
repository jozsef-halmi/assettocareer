using Assetto.Common.Data;
using Assetto.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Interfaces.Manager;
using Assetto.Configurator;
using Assetto.Service;
using Assetto.Common.Interfaces.Service;

namespace Assetto.Manager
{
    public class SeriesManager : ISeriesManager
    {
        public IFileService FileService { get; set; }
        public ISeriesService SeriesService { get; set; }

        public SeriesManager(IFileService fileService
            , ISeriesService seriesService)
        {
            this.FileService = fileService;
            this.SeriesService = seriesService;
        }

        public IEnumerable<SeriesData> GetAvailableSeries()
        {
            try
            {
                return SeriesService.GetAvailableSeries();
            }
            catch (Exception)
            {
                // TODO: Log here
                throw;
            }

        }

        public void StartEvent(EventData eventData)
        {
            var eventConfig = new EventConfig(eventData);
            var str = eventConfig.ToString();
            var a = 5;
        }

    }
}
