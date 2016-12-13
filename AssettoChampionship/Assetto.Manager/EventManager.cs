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
using Assetto.Common.Output;
using Assetto.Common.ProcessedResult;
using Assetto.Service.Utils;

namespace Assetto.Manager
{
    public class EventManager : IEventManager
    {
        //TODO: BE USER INPUT
        //private const string RACE_INI_PATH = "C:\\Users\\halmi\\Documents\\Assetto Corsa\\cfg\\race.ini";
        //private const string ASSETTO_CORSA_EXE_PATH = "e:\\Games\\Steam\\steamapps\\common\\assettocorsa\\AssettoCorsa.exe";
        //private const string OUTPUT_LOG_PATH = "C:\\Users\\halmi\\Documents\\Assetto Corsa\\out\\race_out.json";


        public IFileService FileService { get; set; }
        public ISeriesService SeriesService { get; set; }
        public IProcessService ProcessService { get; set; }
        public IResultService ResultService { get; set; }
        public ISaveService SaveService { get; set; }
        public IConfigService ConfigService { get; set; }
        public IEventService EventService { get; set; }

        public Action<object> ConfigurationStarted { get; set; }
        public Action<object> ConfigurationEnded { get; set; }
        public Action<object> ACProcessStarted { get; set; }
        public Action<object> ACProcessEnded { get; set; }

        // TODO: Refine this
        public SeriesData SelectedSeries { get; set; }
        public EventData SelectedEvent { get; set; }
        public SessionData SelectedSession { get; set; }


        public EventManager(IFileService fileService
            , ISeriesService seriesService
            , IProcessService processService
            , IResultService resultService
            , ISaveService saveService
            , IConfigService configService
            , IEventService eventService)
        {
            this.FileService = fileService;
            this.SeriesService = seriesService;
            this.ProcessService = processService;
            this.ResultService = resultService;
            this.SaveService = saveService;
            this.ConfigService = configService;
            this.EventService = eventService;
        }

        public void SubscribeEvents(Action<object> configurationStarted
            , Action<object> configurationEnded
            , Action<object> processStarted
            , Action<object> processEnded) {
            this.ConfigurationStarted = configurationStarted;
            this.ConfigurationEnded = configurationEnded;
            this.ACProcessStarted = processStarted;
            this.ACProcessEnded = processEnded;

        }


        public void StartEvent(
            //SeriesData seriesData, EventData eventData, SessionData session
            Guid seriesId, Guid eventId, Guid sessionId
            )
        {
            this.SelectedSeries = SeriesService.GetSeries(seriesId);
            this.SelectedEvent = SeriesService.GetEvent(seriesId, eventId);
            this.SelectedSession = SeriesService.GetSession(seriesId, eventId, sessionId);

            this.ConfigurationStarted?.Invoke(SelectedEvent.ImageUrl);
            ConfigureEvent(seriesId, eventId, sessionId);
            this.ConfigurationEnded?.Invoke(new object());

            StartAssettoCorsa();
            //ReturnResult();
        }


        private ConfiguredSessionDTO ConfigureEvent(Guid seriesId, Guid eventId, Guid sessionId) {

            var eventData = SeriesService.GetEvent(seriesId, eventId);
            var sessionData = SeriesService.GetSession(seriesId, eventId, sessionId);

            var sessionDto = new ConfiguredSessionDTO();
            SessionData previousSession = eventData.CareerSessions.IndexOf(sessionData) > 0 
                ? eventData.CareerSessions[eventData.CareerSessions.IndexOf(sessionData) -1]
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
          

            // TODO: Config, for example, race: starting positions!
            //var savedSeason = this.SaveService.LoadResult(
            //    this.SelectedSeries.Id
            //    , this.SelectedEvent.Id
            //    , this.SelectedSession.Id);
            //eventData = this.EventService.OrderGrid(eventData, session);



            eventData.GameSessions = new List<SessionData>() { sessionData };
            var eventConfig = new EventConfig(sessionDto); 
            var raceIni = eventConfig.ToString();

            try
            {
                FileService.WriteFile(ConfigService.GetRaceIniPath(), raceIni);
            }
            catch (Exception)
            {
                //TODO: LOG
                throw;
            }
            return sessionDto;
        }

        private void ProcessResults(OutputLog result)
        {

        }

        private void StartAssettoCorsa()
        {
            this.ProcessService.StartProcess(ConfigService.GetAssettoCorsaExeLoc());
            this.ProcessService.MonitorProcess(ConfigService.GetAcX64ProcessName(), AcsExeStartHandler, AcsExeTerminateHandler);
            this.ProcessService.MonitorProcess(ConfigService.GetAcX86ProcessName(), AcsExeStartHandler, AcsExeTerminateHandler);
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

                // TODO: Where to do this?
                //foreach (var item in this.SelectedSession.PrimarySessionObjectives)
                //{
                //    var result = item.Evaluate(retVar.CurrentResult);
                //}

                retVar =  GetResultDTO(this.SelectedSeries.Id
                    , this.SelectedEvent.Id
                    , this.SelectedSession.Id
                    , currentResult);
            }
            catch (Exception ex)
            {
                // TODO: should not do this in the final version!!
                retVar.Error = ex.ToString();
            }
            this.ACProcessEnded?.Invoke(retVar);
        }

        private ACExeTerminatedDTO GetResultDTO(Guid seriesId, Guid eventId, Guid sessionId, Result result)
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
                        Gap = p.Position == 1 ? 0 : result.Players.FirstOrDefault(rp => rp.Position == 1).TotalTime - p.TotalTime 
                    }).ToList(),
                    SessionType = result.SessionType,
                    Track = result.Track
                }
            };
        }
    }
}
