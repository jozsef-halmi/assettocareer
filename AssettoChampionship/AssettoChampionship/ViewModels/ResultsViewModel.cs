using Assetto.Common.DTO;
using Assetto.Common.ProcessedResult;
using Assetto.Common.SaveGames;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssettoChampionship.ViewModels
{
    public class ResultsViewModel : PropertyChangedBase
    {
        public Result Result { get; set; }
        public SavedSeason SavedSeason { get; set; }

        private BindableCollection<ResultPlayer> _players;
        public BindableCollection<ResultPlayer> Players { get
            {
                return _players;
            }
            set
            {
                _players = value;
                NotifyOfPropertyChange(() => Players);
            }
        }

        public void SetResults(ACExeTerminatedDTO resultsDto)
        {
            Result = resultsDto.CurrentResult;
            SavedSeason = resultsDto.SavedSeason;
            this.Players = new BindableCollection<ResultPlayer>(resultsDto.CurrentResult.Players);
        }
    }
}
