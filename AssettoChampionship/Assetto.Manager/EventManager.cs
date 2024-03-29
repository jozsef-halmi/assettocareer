﻿using Assetto.Common.Data;
using Assetto.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.DTO;
using Assetto.Common.Enum;
using Assetto.Common.Interfaces.Manager;
using Assetto.Configurator;
using Assetto.Service;
using Assetto.Common.Interfaces.Service;
using Assetto.Common.Output;
using Assetto.Common.ProcessedResult;
using Assetto.Service.Utils;

namespace Assetto.Manager
{
    public class EventManager : ManagerBase, IEventManager
    {
        public ISeriesService SeriesService { get; set; }
        public IProcessService ProcessService { get; set; }
        public IResultService ResultService { get; set; }
        public ISaveService SaveService { get; set; }
        public IEventService EventService { get; set; }
        public IVideoService VideoService { get; set; }

        public IConfigManager ConfigManager { get; set; }


        public Action<object> ConfigurationStarted { get; set; }
        public Action<object> ConfigurationEnded { get; set; }
        public Action<object> ACProcessStarted { get; set; }
        public Action<object> ACProcessEnded { get; set; }

        public SeriesData SelectedSeries { get; set; }
        public EventData SelectedEvent { get; set; }
        public SessionData SelectedSession { get; set; }


        public EventManager(ILogService logService
            , IFileService fileService
            , ISeriesService seriesService
            , IProcessService processService
            , IResultService resultService
            , ISaveService saveService
            , IConfigService configService
            , IEventService eventService
            , IVideoService videoService
            , IConfigManager configManager) : base(logService, fileService, configService)
        {
            this.SeriesService = seriesService;
            this.ProcessService = processService;
            this.ResultService = resultService;
            this.SaveService = saveService;
            this.EventService = eventService;
            this.VideoService = videoService;
            this.ConfigManager = configManager;
        }

        public void SubscribeEvents(Action<object> configurationStarted
            , Action<object> configurationEnded
            , Action<object> processStarted
            , Action<object> processEnded)
        {
            this.ConfigurationStarted = configurationStarted;
            this.ConfigurationEnded = configurationEnded;
            this.ACProcessStarted = processStarted;
            this.ACProcessEnded = processEnded;

        }


        public void StartEvent(
            //SeriesData seriesData, EventData eventData, SessionData session
            string seriesId, string eventId, string sessionId, float difficulty, float sessionLength
        )
        {
            try
            {
                this.SelectedSeries = SeriesService.GetSeries(seriesId);
                this.SelectedEvent = SeriesService.GetEvent(seriesId, eventId);
                this.SelectedSession = SeriesService.GetSession(seriesId, eventId, sessionId);

                LogService.Log($"Starting event... {SelectedSeries.FriendlyName} ({SelectedSeries.Id})" +
                               $", {SelectedEvent.FriendlyName} ({SelectedEvent.Id})" +
                               $", {SelectedSession.FriendlyName} ({SelectedSession.Id}) ");


                LogService.Log("Starting configuration..");
                this.ConfigurationStarted?.Invoke(SelectedEvent.ImageUrl);

                ConfigureEvent(seriesId, eventId, sessionId, difficulty, sessionLength);

                LogService.Log("Configuration end..");
                this.ConfigurationEnded?.Invoke(new object());

                //StartAssettoCorsa();
            }
            catch (Exception ex)
            {
                LogService.Error($"Error while starting the event. SeriesId: {seriesId}, EventId: {eventId}, " +
                                 $" sessionId: {sessionId}, exception: {ex}");

            }

            ReturnResult();
        }


        private ConfiguredSessionDTO ConfigureEvent(string seriesId, string eventId, string sessionId,
            float difficulty, float sessionLength)
        {

            var eventData = SeriesService.GetEvent(seriesId, eventId);
            var sessionData = SeriesService.GetSession(seriesId, eventId, sessionId);

            var sessionDto = new ConfiguredSessionDTO();
            SessionData previousSession = eventData.CareerSessions.IndexOf(sessionData) > 0
                ? eventData.CareerSessions[eventData.CareerSessions.IndexOf(sessionData) - 1]
                : null;

            sessionDto.PreviousSessionResult = previousSession != null
                ? SaveService.LoadResult(this.SelectedSeries.Id
                    , this.SelectedEvent.Id
                    , previousSession.Id)
                : null;


            eventData.Player.Name = this.ConfigService.GetPlayerName();
            sessionDto.EventData = eventData;
            sessionDto.SessionData = sessionData;
            this.EventService.OrderGrid(sessionDto); // TODO!


            eventData.GameSessions = new List<SessionData>() {sessionData};
            var eventConfig = new EventConfig(sessionDto);

            // Calculate and save session length
            var calculatedLength = GetCalculatedSessionLength(this.SelectedSeries.Id
                , this.SelectedEvent.Id
                , this.SelectedSession.Id, sessionLength);
            SaveCalculatedSessionLength(eventConfig, calculatedLength);

            // Set difficulty
            SetSessionDifficulty(eventConfig,difficulty);

            // Store difficulty settings
            ConfigManager.SetDifficulty(Convert.ToInt32(difficulty * 100));

            var raceIni = eventConfig.ToString();

            try
            {
                FileService.WriteFile(ConfigService.GetRaceIniPath(), raceIni);
            }
            catch (Exception ex)
            {
                LogService.Fatal("Race ini could not be overwritten! Exception: " + ex.ToString());
                throw;
            }

           
            return sessionDto;
        }

  

        #region DurationLogic
        private int CalculateLapsCount(SessionData session, float lengthMultiplier)
        {
            int newLaps = Convert.ToInt32(Math.Round((float)session.Laps.Value * lengthMultiplier));
            return newLaps;
        }

        private int CalculateDuration(SessionData session, float lengthMultiplier)
        {
            int newDuration = Convert.ToInt32(Math.Round((float)session.Duration * lengthMultiplier));
            return newDuration;
        }



        private void SetRaceLaps(EventConfig eventConfig, int laps)
        {
            eventConfig.ConfiguredSessionDto.SessionData.Laps = laps;
        }


        private void SetDuration(EventConfig eventConfig, int duration)
        {
            eventConfig.ConfiguredSessionDto.SessionData.Duration = duration;
        }

        public int GetCalculatedSessionLength(string seriesId, string eventId, string sessionId, float lengthMultiplier)
        {
            var session = this.SeriesService.GetSession(seriesId, eventId, sessionId);
            switch (session.SessionType)
            {
                case SessionType.Race:
                {
                    return CalculateLapsCount(session, lengthMultiplier);
                }
                default:
                {
                    return CalculateDuration(session, lengthMultiplier);
                }
            }
        }

        public void SaveCalculatedSessionLength(EventConfig eventConfig, int length)
        {
            switch (eventConfig.ConfiguredSessionDto.SessionData.SessionType)
            {
                case SessionType.Race:
                {
                    SetRaceLaps(eventConfig, length);
                    break;
                }
                default:
                {
                    SetDuration(eventConfig, length);
                    break;
                }
            }
        }

        #endregion


        private void SetSessionDifficulty(EventConfig eventConfig, float difficulty)
        {
            foreach (var eventDataOpponent in eventConfig.ConfiguredSessionDto.EventData.Opponents)
            {
                //
                var opponentSkillToSubtract = 20-Convert.ToInt32(Math.Round(20*difficulty));
                eventDataOpponent.Level = eventDataOpponent.Level - opponentSkillToSubtract < 80
                    ? 80
                    : eventDataOpponent.Level - opponentSkillToSubtract;
            }
        }

        private void ProcessResults(OutputLog result)
        {

        }

        private void StartAssettoCorsa()
        {
            try
            {
                this.ProcessService.StartProcess(ConfigService.GetAssettoCorsaExeLoc());
                this.ProcessService.MonitorProcess(ConfigService.GetAcX64ProcessName(), AcsExeStartHandler, AcsExeTerminateHandler);
                this.ProcessService.MonitorProcess(ConfigService.GetAcX86ProcessName(), AcsExeStartHandler, AcsExeTerminateHandler);
            }
            catch (Exception ex)
            {
                LogService.Error($"Error while starting assetto corsa, exception: {ex}");
            }
           }

        private void AcsExeStartHandler(object sender, EventArgs e)
        {
            this.ACProcessStarted(new object());
        }

        private void AcsExeTerminateHandler(object sender, EventArgs e)
        {
            this.ReturnResult();

        }

        public void ReturnResult() {
            ACExeTerminatedDTO retVar = new ACExeTerminatedDTO();
            try
            {
                var logFile = this.FileService.ReadFile(ConfigService.GetOutputLogPath());
                var currentResult = this.ResultService.GetResultForLog(logFile);
                var savedSeason = this.SaveService.SaveResult(
                    this.SelectedSeries.Id
                    , this.SelectedEvent.Id
                    , this.SelectedSession.Id,
                    currentResult);


                retVar =  GetResultDTO(this.SelectedSeries.Id
                    , this.SelectedEvent.Id
                    , this.SelectedSession.Id
                    , currentResult);
            }
            catch (Exception ex)
            {
                LogService.Error("Results could not be returned! Exception: " + ex.ToString());
                retVar.Error = ex.ToString();
            }
            this.ACProcessEnded?.Invoke(retVar);
        }

        private ACExeTerminatedDTO GetResultDTO(string seriesId, string eventId, string sessionId, Result result)
        {
            return new ACExeTerminatedDTO()
            {
                Result = new ResultDTO()
                {
                    Duration = result.Duration,
                    LapCount = result.LapCount,
                    Name = result.FriendlyName,
                    PlayerPosition = result.Players.FirstOrDefault(p => p.Name == ConfigService.GetPlayerName()).Position,
                    Players = result.Players.Select(p => new PlayerDTO()
                    {
                        Position = p.Position,
                        IsPlayer = p.IsPlayer,
                        LapCount = p.LapCount,
                        Id = p.Id,
                        Laps = p.Laps,
                        Name = p.Name,
                        TotalTime = p.TotalTime,
                        Car = p.IsPlayer == false
                        ? SeriesService.GetFriendlyCarNameForOpponent(seriesId, eventId, p.Name)
                        : SeriesService.GetFriendlyCarNameForPlayer(seriesId, eventId),
                        Skin = p.IsPlayer == false
                        ? SeriesService.GetFriendlySkinNameForOpponent(seriesId, eventId, p.Name)
                        : SeriesService.GetFriendlySkinNameForPlayer(seriesId, eventId),
                        Gap = (result.SessionType == Common.Enum.SessionType.Race) 
                        ? p.Position == 1 ? 0 : result.Players.FirstOrDefault(rp => rp.Position == 1).TotalTime - p.TotalTime
                        : p.Position == 1 ? 0 : result.Players.FirstOrDefault(rp => rp.Position == 1).BestLap - p.BestLap
                    }).ToList(),
                    SessionType = result.SessionType,
                    Track = result.Track
                }
            };
        }

        public void VideoWatched(string videoUrl)
        {
            VideoService.VideoWatched(videoUrl);
        }

        public bool IsVideoAlreadyWatched(string videoUrl)
        {
            return VideoService.IsVideoAlreadyWatched(videoUrl);
        }
    }
}
