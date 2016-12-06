using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.ProcessedResult;
using Assetto.Common.SaveGames;

namespace Assetto.Common.DTO
{
    public class ACExeTerminatedDTO
    {
        public SavedSeason SavedSeason { get; set; }
        public Result CurrentResult { get; set; }

    }
}
