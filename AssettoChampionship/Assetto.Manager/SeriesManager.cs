﻿using Assetto.Common.Data;
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
using Assetto.Common.ProcessedResult;
using Assetto.Common.Extensions;
using Assetto.Common.Helpers;

namespace Assetto.Manager
{
    public class SeriesManager : ManagerBase, ISeriesManager
    {
        private const string TRACK_REL_PATH = "content/tracks/";
        private const string CAR_REL_PATH = "content/cars/";


        public ISeriesService SeriesService { get; set; }
        public ISaveService SaveService { get; set; }
        public IGoalService GoalService { get; set; }
        public IChampionshipService ChampionshipService { get; set; }
        public IResultService ResultService { get; set; }

        public SeriesManager(ILogService logService
            , IFileService fileService
            , ISeriesService seriesService
            , ISaveService saveService
            , IGoalService goalService
            , IChampionshipService championshipService
            , IConfigService configService
            , IResultService resultService) : base(logService, fileService, configService)
        {
            this.SeriesService = seriesService;
            this.SaveService = saveService;
            this.GoalService = goalService;
            this.ChampionshipService = championshipService;
            this.ResultService = resultService;
        }

        public List<SeriesDTO> GetAvailableSeries()
        {
            var retVar = new List<SeriesDTO>();
            try
            {
                var availableSeasons = SeriesService.GetAvailableSeries();
                foreach (var availableSeason in availableSeasons)
                {
                    retVar.Add(GetSeries(availableSeason.Id));
                }
            }
            catch (Exception ex)
            {
                LogService.Fatal("Error getting available series! Exception: " + ex.ToString());
            }
            return retVar;
        }

        public SeriesDTO GetSeries(string seriesId)
        {
            try
            {
                var selectedSeries = SeriesService.GetAvailableSeries().FirstOrDefault(s => s.Id == seriesId);
                var retVar = new SeriesDTO()
                {
                    SeriesId = selectedSeries.Id,
                    Description = selectedSeries.Description,
                    Title = selectedSeries.FriendlyName,
                    ImageUrl = selectedSeries.ImageUrl,
                    IsAvailable = true,//IsSeasonAvailable(seriesId),
                    Events = selectedSeries.Events.Select(e =>
                                GetEvent(seriesId, e.Id)
                    ).ToList(),
                    Standings =
                        ChampionshipService.GetCurrentStandings(selectedSeries.Id)
                            .OrderByDescending(p => p.Points)
                            .ToList(),
                    Video = new VideoDTO()
                    {
                       Url  = selectedSeries.VideoUrl,
                       Message = selectedSeries.VideoMessage
                    },
                    Credits = new CreditsDTO()
                    {
                        ToolTip = selectedSeries.Credits?.ToolTip,
                        ExternalLink = selectedSeries.Credits?.ExternalLink,
                        TooltipTitle = selectedSeries.FriendlyName
                    },
                    Class = new ClassDTO() {
                        Name = selectedSeries.Class.Name,
                        FriendlyName = selectedSeries.Class.FriendlyName
                    }
                };

                // TODO: Test this
                retVar.IsDone = retVar.Events.All(s => s.IsDone)
                                && ChampionshipService.IsPlayerWinning(selectedSeries.Id);
                retVar.IsStarted = retVar.Events.First().Sessions.First().IsDone;
                    
                    //ChampionshipService.GetCurrentStandings(selectedSeries.Id).First().Points > 0;
                return retVar;
            }
            catch (Exception ex)
            {
                LogService.Fatal($"Error getting a specific season, id: {seriesId}, Exception: {ex}");
                return null;
            }

        }

        public EventDTO GetEvent(string seriesId, string eventId)
        {
            try
            {

                var selectedEvent = SeriesService.GetAvailableSeries()
                    .FirstOrDefault(s => s.Id == seriesId)
                    .Events.FirstOrDefault(e => e.Id == eventId);

                var retVar = new EventDTO()
                {
                    Title = selectedEvent.FriendlyName,
                    Description = selectedEvent.Description,
                    ImageUrl = selectedEvent.ImageUrl,
                    EventId = selectedEvent.Id,
                    SeriesId = seriesId,
                    IsAvailable = IsEventAvailable(seriesId, eventId),
                    Track = selectedEvent.Track.FriendlyName,
                    Layout = selectedEvent.Layout?.FriendlyName,
                    SessionsCount = selectedEvent.CareerSessions.Count,
                    Sessions = selectedEvent.CareerSessions.Select(s => GetSessionDTO(seriesId, eventId, s.Id)).ToList(),
                };

                retVar.IsDone = retVar.Sessions.All(s => s.IsDone);
                retVar.IsCarMissing = !FileService.DirExists(ConfigService.GetAssettoFolder()
                                                            + CAR_REL_PATH
                                                            + selectedEvent.Player.Car.Name)
                                        && selectedEvent.Opponents.Any(
                                            o => !FileService.DirExists(ConfigService.GetAssettoFolder()
                                                            + CAR_REL_PATH
                                                            + o.Car.Name));
                retVar.IsTrackMissing = !FileService.DirExists(ConfigService.GetAssettoFolder()
                                                            + TRACK_REL_PATH
                                                            + selectedEvent.Track.Name);

                return retVar;
            }
            catch (Exception ex)
            {
                LogService.Fatal(
                    $"Error getting a specific event, seriesId: {seriesId}, eventId: {eventId},  Exception: {ex}");
                return null;
            }
        }



        public SessionDTO GetSession(string seriesId, string eventId, string sessionId)
        {
            return GetSessionDTO(seriesId, eventId, sessionId);
        }

        private SessionData GetSessionData(string seriesId, string eventId, string sessionId)
        {
            return SeriesService.GetAvailableSeries().FirstOrDefault(series => series.Id == seriesId)
                .Events.FirstOrDefault(e => e.Id == eventId)
                .CareerSessions.FirstOrDefault(s => s.Id == sessionId);
        }

        private SessionDTO GetSessionDTO(string seriesId, string eventId, string sessionId)
        {
            try
            {
                var selectedSeries = SeriesService.GetSeries(seriesId);
                var selectedEvent = SeriesService.GetEvent(seriesId, eventId);
                var data = GetSessionData(seriesId, eventId, sessionId);
                var result = SaveService.LoadResult(seriesId, eventId, sessionId);
                return new SessionDTO()
                {
                    SeriesId = seriesId,
                    EventId = eventId,
                    SessionId = data.Id,
                    Title = data.FriendlyName,
                    Description = data.FriendlyName, // todo
                    ImageUrl = data.ImageUrl,
                    IsDone = data.PrimarySessionObjectives.Count() == GetAchievedGoalsCount(seriesId, eventId, data.Id),
                    IsAvailable = IsSessionAvailable(seriesId, eventId, sessionId),
                    Objectives = data.PrimarySessionObjectives.Select(pso => new ObjectiveDTO()
                    {
                        IsDone = pso.Evaluate(result),
                        Text = pso.ToString(),
                        DoneText = pso.GetDoneText(result)
                    }).ToList(),
                    FinishedPosition = ResultService.GetPlayerPosition(result),
                    Duration = data.Duration ?? 0,
                    LapCount = data.Laps ?? 0,
                    AmbientTemperature = data.AmbientTemperature.ToString() + "°C",
                    RoadTemperature = data.RoadTemperature.ToString() + "°C",
                    TimeOfDay = data.TimeOfDay.GetStringValue(),
                    TrackCondition = data.DynamicTrack.Preset.GetStringValue() + " track",
                    Weather = WeatherToFriendlyString.Convert(data.Weather),
                    TrackId = selectedEvent.Track.Name,
                    SessionCounterMax = selectedEvent.CareerSessions.Count,
                    SessionCounterCurrent = SeriesService.GetSessionIndex(seriesId, eventId, sessionId),
                    EventCounterMax = selectedSeries.Events.Count,
                    EventCounterCurrent = SeriesService.GetEventIndex(seriesId, eventId),
                    SeriesTitle = selectedSeries.FriendlyName
                };
            }
            catch (Exception ex)
            {
                LogService.Fatal(
                   $"Error getting a specific session, seriesId: {seriesId}, eventId: {eventId}, sessionId: {sessionId} Exception: {ex}");
                return null;
            }
           
        }

        private int GetAchievedGoalsCount(string seriesId, string eventId, string sessionId)
        {
           return this.GoalService.GetAchievedGoalsCount(seriesId, eventId, sessionId,
                SaveService.LoadResult(seriesId, eventId, sessionId));
        }

        private bool IsSessionAvailable(string seriesId, string eventId, string sessionId)
        {
            var selectedEvent = this.SeriesService.GetEvent(seriesId, eventId);
            var indexOfSelectedSession = selectedEvent.CareerSessions.IndexOf(
                    selectedEvent.CareerSessions.FirstOrDefault(s => s.Id == sessionId));

            // First session of the event
            if (indexOfSelectedSession == 0)
                return true;

            var prevSession = selectedEvent.CareerSessions.ElementAt(indexOfSelectedSession - 1);
            var prevResult = SaveService.LoadResult(seriesId, eventId, prevSession.Id);
            var achievedGoalCount = GoalService.GetAchievedGoalsCount(seriesId, eventId, prevSession.Id, prevResult);

            // Previous session has not been done
            if (prevResult == null || prevResult != null && prevSession.PrimarySessionObjectives.Count > achievedGoalCount)
                return false;

            return true;
        }

        private bool IsEventAvailable(string seriesId, string eventId)
        {
            var selectedSeries = this.SeriesService.GetSeries(seriesId);
            var indexOfSelectedEvent = selectedSeries.Events.IndexOf(
                    selectedSeries.Events.FirstOrDefault(s => s.Id == eventId));

            // First event of the series
            if (indexOfSelectedEvent == 0)
                return true;

            var prevEvent = selectedSeries.Events.ElementAt(indexOfSelectedEvent - 1);
            var isPrevEventDone = true;
            foreach (var prevEventSession in prevEvent.CareerSessions)
            {
                var result = SaveService.LoadResult(seriesId, prevEvent.Id, prevEventSession.Id);
                var goalCount = GoalService.GetAchievedGoalsCount(seriesId, prevEvent.Id, prevEventSession.Id, result);
                if (goalCount != prevEventSession.PrimarySessionObjectives.Count)
                    isPrevEventDone = false;
            }

            return isPrevEventDone;
        }

        private bool IsSeasonAvailable(string seriesId)
        {
            var availableSeries = this.SeriesService.GetAvailableSeries().ToList();
            var indexOfSelectedSeries = availableSeries.IndexOf(
                    availableSeries.FirstOrDefault(s => s.Id == seriesId));

            // First series
            if (indexOfSelectedSeries == 0)
                return true;

            var prevSeason = availableSeries.ElementAt(indexOfSelectedSeries - 1);
            var isPrevSeasonDone = true;
            foreach (var prevSeriesEvent in prevSeason.Events)
            {
                foreach (var prevSeriesEventSession in prevSeriesEvent.CareerSessions)
                {
                    var result = SaveService.LoadResult(seriesId, prevSeriesEvent.Id, prevSeriesEventSession.Id);
                    var goalCount = GoalService.GetAchievedGoalsCount(seriesId, prevSeriesEvent.Id, prevSeriesEventSession.Id, result);
                    if (goalCount != prevSeriesEventSession.PrimarySessionObjectives.Count)
                        isPrevSeasonDone = false;
                }
            }

            return isPrevSeasonDone;
        }

        public SessionDTO GetNextSession(string seriesId)
        {
            var series = GetSeries(seriesId);
            var nextEvent = series.Events.FirstOrDefault(e => e.Sessions.Any(s => s.IsDone != true && s.IsAvailable == true));
            return nextEvent.Sessions.FirstOrDefault(s => s.IsDone != true && s.IsAvailable == true);
        }

    }
}
