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
using Assetto.Common.Output;
using Assetto.Common.ProcessedResult;

namespace Assetto.Manager
{
    public class EventManager : IEventManager
    {
        //TODO: BE USER INPUT
        private const string RACE_INI_PATH = "C:\\Users\\halmi\\Documents\\Assetto Corsa\\cfg\\race.ini";
        private const string ASSETTO_CORSA_EXE_PATH = "e:\\Games\\Steam\\steamapps\\common\\assettocorsa\\AssettoCorsa.exe";
        private const string ACS_EXE_X64 = "acs.exe";
        private const string ACS_EXE_X86 = "acs_x86.exe";
        private const string OUTPUT_LOG_PATH = "C:\\Users\\halmi\\Documents\\Assetto Corsa\\out\\race_out.json";


        public IFileService FileService { get; set; }
        public ISeriesService SeriesService { get; set; }
        public IProcessService ProcessService { get; set; }
        public IResultService ResultService { get; set; }

        public Action<object> ConfigurationStarted { get; set; }
        public Action<object> ConfigurationEnded { get; set; }
        public Action<object> ACProcessStarted { get; set; }
        public Action<object> ACProcessEnded { get; set; }

        // TODO: Refine this
        public EventData SelectedEvent { get; set; }
        public SessionData SelectedSession { get; set; }


        public EventManager(IFileService fileService
            , ISeriesService seriesService
            , IProcessService processService
            , IResultService resultService)
        {
            this.FileService = fileService;
            this.SeriesService = seriesService;
            this.ProcessService = processService;
            this.ResultService = resultService;
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


        public void StartEvent(EventData eventData, SessionData session)
        {
            this.SelectedEvent = eventData;
            this.SelectedSession = session;

            this.ConfigurationStarted(new object());
            ConfigureEvent(eventData, session);
            this.ConfigurationEnded(new object());

            StartAssettoCorsa();
        }


        private void ConfigureEvent(EventData eventData, SessionData session) {
            // TODO: Config, for example, race: starting positions!
            eventData.GameSessions = new List<SessionData>() { session };
            var eventConfig = new EventConfig(eventData);
            var raceIni = eventConfig.ToString();

            try
            {
                FileService.WriteFile(RACE_INI_PATH, raceIni);
            }
            catch (Exception)
            {
                //TODO: LOG
                throw;
            }
        }

        private void ProcessResults(OutputLog result)
        {

        }

        private void StartAssettoCorsa()
        {
            this.ProcessService.StartProcess(ASSETTO_CORSA_EXE_PATH);
            this.ProcessService.MonitorProcess(ACS_EXE_X64, AcsExeStartHandler, AcsExeTerminateHandler);
            this.ProcessService.MonitorProcess(ACS_EXE_X86, AcsExeStartHandler, AcsExeTerminateHandler);
        }

        private void AcsExeStartHandler(object sender, EventArgs e)
        {
            this.ACProcessStarted(new object());
        }

        private void AcsExeTerminateHandler(object sender, EventArgs e)
        {
            // Process Log
            Result result;
            try
            {
                var logFile = this.FileService.ReadFile(OUTPUT_LOG_PATH);
                result = this.ResultService.GetResult(logFile);

            }
            catch (Exception)
            {
                //TODO
                throw;
            }
            this.ACProcessEnded(result);

        }

    }
}
