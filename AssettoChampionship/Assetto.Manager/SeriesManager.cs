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
                        SeriesId = availableSeason.Id,
                        Description = availableSeason.Description,
                        Title = availableSeason.FriendlyName,
                        ImageUrl = availableSeason.ImageUrl,
                        IsAvailable = true,
                        IsDone = false
                        //SeriesData = availableSeason,
                        //SavedSeason = this.SaveService.GetSavedSeason(availableSeason.Id)
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

        public SeriesDTO GetSeries(Guid seriesId)
        {
            var selectedSeries = SeriesService.GetAvailableSeries().FirstOrDefault(s => s.Id == seriesId);

            return new SeriesDTO()
            {
                SeriesId = selectedSeries.Id,
                Description = selectedSeries.Description,
                Title = selectedSeries.FriendlyName,
                ImageUrl = selectedSeries.ImageUrl,
                IsAvailable = true,
                IsDone = false,
                Events = selectedSeries.Events.Select(e => new EventDTO()
                    {
                        EventId = e.Id,
                        Description = e.FriendlyName, // TODO
                        ImageUrl = e.ImageUrl,
                        IsAvailable = true, //todo,
                        IsDone = false,
                        Title = e.FriendlyName,
                        Track = e.Track.FriendlyName,
                        Layout = e.Layout?.FriendlyName,
                        SessionsCount = e.CareerSessions.Count
                    }
                ).ToList()
            };
        }

        public EventDTO GetEvent(Guid seriesId, Guid eventId)
        {
            var selectedEvent = SeriesService.GetAvailableSeries()
                .FirstOrDefault(s => s.Id == seriesId)
                .Events.FirstOrDefault(e => e.Id == eventId);

            return new EventDTO()
            {
                Title =  selectedEvent.FriendlyName,
                Description = selectedEvent.FriendlyName, // TODO
                ImageUrl = selectedEvent.ImageUrl,
                EventId = selectedEvent.Id,
                IsAvailable = true,
                IsDone = false, // todo
                Track = selectedEvent.Track.FriendlyName,
                Layout = selectedEvent.Layout?.FriendlyName,
                SessionsCount = selectedEvent.CareerSessions.Count,
                Sessions = selectedEvent.CareerSessions.Select(s => new SessionDTO()
                {
                   Title = s.FriendlyName,
                   Description = s.FriendlyName, // todo
                   ImageUrl = s.ImageUrl,
                   IsDone = false,
                   IsAvailable = true,
                   SessionId = s.Id
                }).ToList()
            };
        }
    }
}
