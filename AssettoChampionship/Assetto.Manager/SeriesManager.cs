using Assetto.Common.Data;
using Assetto.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.DTO;
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
        public ISaveService SaveService { get; set; }


        public SeriesManager(IFileService fileService
            , ISeriesService seriesService
            , ISaveService saveService)
        {
            this.FileService = fileService;
            this.SeriesService = seriesService;
            this.SaveService = saveService;
        }

        public List<SeriesDTO> GetAvailableSeries()
        {
            var retVar = new List<SeriesDTO>();
            try
            {
                var availableSeasons = SeriesService.GetAvailableSeries();
                foreach (var availableSeason in availableSeasons)
                {
                    retVar.Add(new SeriesDTO()
                    {
                        SeriesData = availableSeason,
                        SavedSeason = this.SaveService.GetSavedSeason(availableSeason.Id)
                    });
                }
            }
            catch (Exception)
            {
                // TODO: Log here
                throw;
            }
            return retVar;
        }

        public SeriesDTO GetSeries(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
