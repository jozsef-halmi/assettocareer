﻿using Assetto.Common.DTO;
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
    public class ResultsViewModel : PropertyChangedBase
    {
        #region Data
        private ResultDTO _result;

        public ResultDTO Result
        {
            get { return _result; }
            set
            {
                _result = value;
                NotifyOfPropertyChange(() => Result);
            }
        }

        private BindableCollection<ResultPlayer> _players;

        public BindableCollection<ResultPlayer> Players
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

        public ResultsViewModel(ILogService logService,
            INavigationService naviService,
            IConfigManager configManager,
            IPathManager pathManager)
        {
            this.LogService = logService;
            this.NavigationService = naviService;
            this.ConfigManager = configManager;
            this.PathManager = pathManager;
        }

        public void SetResults(ACExeTerminatedDTO acTerminatedDto)
        {
            try
            {
                Result = acTerminatedDto.Result;
                this.Players = new BindableCollection<ResultPlayer>(Result.Players);
            }
            catch (Exception ex)
            {
                LogService.Error($"Error while displaying results, result: {acTerminatedDto?.Result}, exception: {ex}");
            }
            var series = PathManager.GetCurrentSeries(ConfigManager.GetSelectedPathId());

        }

        public void Continue() {
            this.NavigationService.ShowStandings();
        }
    }
}
