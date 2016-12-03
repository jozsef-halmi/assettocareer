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
    public class EventManager : IEventManager
    {
        //TODO: BE USER INPUT
        private const string RACE_INI_PATH = "C:\\Users\\halmi\\Documents\\Assetto Corsa\\cfg\\race.ini";
        private const string ASSETTO_CORSA_EXE_PATH = "e:\\Games\\Steam\\steamapps\\common\\assettocorsa\\AssettoCorsa.exe";
        private const string ACS_EXE_X64 = "acs.exe";
        private const string ACS_EXE_X86 = "acs_x86.exe";


        public IFileService FileService { get; set; }
        public ISeriesService SeriesService { get; set; }
        public IProcessService ProcessService { get; set; }

        public EventManager(IFileService fileService
            , ISeriesService seriesService
            , IProcessService processService)
        {
            this.FileService = fileService;
            this.SeriesService = seriesService;
            this.ProcessService = processService;
        }


        public void StartEvent(EventData eventData)
        {
            ConfigureEvent(eventData);
            StartAssettoCorsa();
        }


        private void ConfigureEvent(EventData eventData) {
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

        private void StartAssettoCorsa()
        {
            this.ProcessService.StartProcess(ASSETTO_CORSA_EXE_PATH);
            this.ProcessService.MonitorProcess(ACS_EXE_X64, AcsExeStartHandler, AcsExeTerminateHandler);
            this.ProcessService.MonitorProcess(ACS_EXE_X86, AcsExeStartHandler, AcsExeTerminateHandler);
        }

        private void AcsExeStartHandler(object sender, EventArgs e)
        {

        }

        private void AcsExeTerminateHandler(object sender, EventArgs e)
        {

        }

    }
}
