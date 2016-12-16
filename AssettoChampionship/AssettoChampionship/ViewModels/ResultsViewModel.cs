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

namespace AssettoChampionship.ViewModels
{
    public class ResultsViewModel : PropertyChangedBase
    {
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

        public ILogService LogService { get; set; }

        public ResultsViewModel(ILogService logService)
        {
            this.LogService = logService;
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

        }
    }
}
