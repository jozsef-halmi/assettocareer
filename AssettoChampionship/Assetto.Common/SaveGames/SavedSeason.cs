using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.SaveGames
{
    public class SavedSeason
    {
        public Guid SeasonId { get; set; }

        public Dictionary<Guid, SavedEventResult> SavedEventResults { get; set; }
    }
}
