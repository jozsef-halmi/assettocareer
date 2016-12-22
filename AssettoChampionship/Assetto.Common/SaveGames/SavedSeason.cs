using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.SaveGames
{
    public class SavedSeason
    {
        public string SeasonId { get; set; }

        public Dictionary<string, SavedEventResult> SavedEventResults { get; set; }
    }
}
