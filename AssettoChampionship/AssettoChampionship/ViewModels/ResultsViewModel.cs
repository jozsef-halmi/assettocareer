using Assetto.Common.DTO;
using Assetto.Common.ProcessedResult;
using Assetto.Common.SaveGames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssettoChampionship.ViewModels
{
    public class ResultsViewModel
    {
        public Result CurrentResult { get; set; }
        public SavedSeason SavedSeason { get; set; }

        public void SetResults(ACExeTerminatedDTO resultsDto)
        {
            CurrentResult = resultsDto.CurrentResult;
            SavedSeason = resultsDto.SavedSeason;
        }
    }
}
