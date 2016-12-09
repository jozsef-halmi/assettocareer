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
        public IGoalService GoalService { get; set; }

        public SeriesManager(IFileService fileService
            , ISeriesService seriesService
            , ISaveService saveService
            , IGoalService goalService)
        {
            this.FileService = fileService;
            this.SeriesService = seriesService;
            this.SaveService = saveService;
            this.GoalService = goalService;
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
            var retVar = new SeriesDTO()
            {
                SeriesId = selectedSeries.Id,
                Description = selectedSeries.Description,
                Title = selectedSeries.FriendlyName,
                ImageUrl = selectedSeries.ImageUrl,
                IsAvailable = true,
                Events = selectedSeries.Events.Select(e => 
                            GetEvent(seriesId, e.Id)
                ).ToList()
            };

            retVar.IsDone = retVar.Events.All(s => s.IsDone);
            return retVar;
        }

        public EventDTO GetEvent(Guid seriesId, Guid eventId)
        {
            var selectedEvent = SeriesService.GetAvailableSeries()
                .FirstOrDefault(s => s.Id == seriesId)
                .Events.FirstOrDefault(e => e.Id == eventId);

            var retVar = new EventDTO()
            {
                Title =  selectedEvent.FriendlyName,
                Description = selectedEvent.FriendlyName, // TODO
                ImageUrl = selectedEvent.ImageUrl,
                EventId = selectedEvent.Id,
                SeriesId = seriesId,
                IsAvailable = true,
                Track = selectedEvent.Track.FriendlyName,
                Layout = selectedEvent.Layout?.FriendlyName,
                SessionsCount = selectedEvent.CareerSessions.Count,
                Sessions = selectedEvent.CareerSessions.Select(s => GetSessionDTO(seriesId, eventId, s.Id)).ToList()
            };

            retVar.IsDone = retVar.Sessions.All(s => s.IsDone);

            return retVar;
        }



        public SessionDTO GetSession(Guid seriesId, Guid eventId, Guid sessionId)
        {
            return GetSessionDTO(seriesId, eventId, sessionId);
        }

        private SessionData GetSessionData(Guid seriesId, Guid eventId, Guid sessionId)
        {
            return SeriesService.GetAvailableSeries().FirstOrDefault(series => series.Id == seriesId)
                   .Events.FirstOrDefault(e => e.Id == eventId)
                   .CareerSessions.FirstOrDefault(s => s.Id == sessionId);
        }

        private SessionDTO GetSessionDTO(Guid seriesId, Guid eventId, Guid sessionId)
        {
            var data = GetSessionData(seriesId, eventId, sessionId);
            return new SessionDTO()
            {
                Title = data.FriendlyName,
                Description = data.FriendlyName, // todo
                ImageUrl = data.ImageUrl,
                IsDone = data.PrimarySessionObjectives.Count() == GetAchievedGoalsCount(seriesId, eventId, data.Id),
                IsAvailable = true,
                SessionId = data.Id,
                Objectives = data.PrimarySessionObjectives.Select(pso => new ObjectiveDTO()
                {
                    IsDone = pso.Evaluate(SaveService.LoadResult(seriesId, eventId, sessionId)),
                    Text = pso.ToString()
                }).ToList()
            };
        }

        private int GetAchievedGoalsCount(Guid seriesId, Guid eventId, Guid sessionId)
        {
           return this.GoalService.GetAchievedGoalsCount(seriesId, eventId, sessionId,
                SaveService.LoadResult(seriesId, eventId, sessionId));
        }
    }
}
