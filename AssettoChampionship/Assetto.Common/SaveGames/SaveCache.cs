using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.SaveGames
{
    public class SaveCache
    {
        public Guid SeasonId { get; set; }
        public SavedSeason Save { get; set; }
    }
}
