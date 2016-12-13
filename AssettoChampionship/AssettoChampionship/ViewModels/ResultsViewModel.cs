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
        private ResultDTO _result;
        public ResultDTO Result { get {
                return _result;
            }
            set {
                _result = value;
                NotifyOfPropertyChange(() => Result);
            }
        }
        //public SavedSeason SavedSeason { get; set; }

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

        public void SetResults(ACExeTerminatedDTO acTerminatedDto)
        {
            Result = acTerminatedDto.Result;
            this.Players = new BindableCollection<ResultPlayer>(Result.Players);
        }
    }
}
