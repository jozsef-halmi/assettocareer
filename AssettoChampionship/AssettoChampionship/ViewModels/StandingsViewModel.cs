using Assetto.Common.DTO;
using Assetto.Common.ProcessedResult;
using Assetto.Common.SaveGames;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Interfaces.Service;
using Assetto.Service;
using AssettoChampionship.Services;
using Assetto.Common.Interfaces.Manager;

namespace AssettoChampionship.ViewModels
{
    public class StandingsViewModel : Screen
    {
        #region Data
        private SeriesDTO _currentSeries;

        public SeriesDTO CurrentSeries
        {
            get { return _currentSeries; }
            set
            {
                _currentSeries = value;
                NotifyOfPropertyChange(() => CurrentSeries);
            }
        }

        private BindableCollection<ChampionshipPlayerDTO> _players;

        public BindableCollection<ChampionshipPlayerDTO> Players
        {
            get { return _players; }
            set
            {
                _players = value;
                NotifyOfPropertyChange(() => Players);
            }
        }

        #endregion

        private ILogService LogService { get; set; }
        private INavigationService NavigationService { get; set; }
        private IConfigManager ConfigManager { get; set; }
        private IPathManager PathManager { get; set; }

        public StandingsViewModel(ILogService logService,
            INavigationService naviService,
            IConfigManager configManager,
            IPathManager pathManager)
        {
            this.LogService = logService;
            this.NavigationService = naviService;
            this.ConfigManager = configManager;
            this.PathManager = pathManager;
        }

        protected override void OnActivate()
        {
            CurrentSeries = PathManager.GetCurrentSeries(ConfigManager.GetSelectedPathId());
            Players = new BindableCollection<ChampionshipPlayerDTO>(CurrentSeries.Standings);
            base.OnActivate();
        }



        public void Continue() {
            this.NavigationService.ShowNextSession();
        }
    }
}
